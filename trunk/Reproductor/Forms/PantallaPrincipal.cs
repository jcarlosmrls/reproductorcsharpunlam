using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Net.NetworkInformation;

namespace Reproductor
{
    public partial class PantallaPrincipal : Form
    {
        #region Variables

        public string idInterpreteBiblioteca = "";
        public string idAlbumBiblioteca = "";
        public string idCancionBiblioteca = "";
        public Thread hiloActualizar;
        public Thread buscador;
        public Thread buscar_letra;

        private List<Cancion> lista;
        private int cancionActual;
        private PanelReproduccion panelReproduccion;
        private Player player;
        private BaseDeDatos dbReproductor;
        private Login login;
        private List<string> listaBusqueda;

        #endregion

        #region Propiedades

        public Usuario UsuarioActual
        {
            get
            {
                return login.UsuarioActual;
            }
        }

        #endregion

        #region Métodos funcionales

        public PantallaPrincipal()
        {
            InitializeComponent();

            //Creo instancia de objetos
            panelReproduccion = new PanelReproduccion();
            dbReproductor = new BaseDeDatos();
            login = new Login();
            lista = new List<Cancion>();
            player = new Player();
            CheckForIllegalCrossThreadCalls = false;    //Deberia ser con Delegates en vez de esta propiedad
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Abro la base de datos
            dbReproductor.Open(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + UsuarioActual.Configuracion.Path);

            // Inicializo variables, etc
            panelReproduccion.Asignar(this, ref dbReproductor, ref lista);
            panelReproduccion.CambiarPosicion();
            cancionActual = -1;
            trackBarVolumen.Value = player.Volume;

            // Muestro el login
            MostrarLogin();

            if (login.Estado != DialogResult.Cancel)
            {
                // Si es nuevo usuario, debo
                // crear la configuracion por defecto
                if (UsuarioActual.IsNewUser)
                {
                    CrearConfiguracionPorDefecto();
                }

                // Cargo y aplico la configuracion
                CargarConfiguracionDeUsuario();
                AplicarConfiguracionDeUsuario();
            }
        }

        private void MostrarLogin()
        {
            bool loggedIn = false;

            do
            {
                login.ShowDialog();
                if (login.Estado != DialogResult.Cancel)
                {
                    //Si no es nuevo usuario
                    if (!UsuarioActual.IsNewUser)
                    {
                        //Si entro como invitado, o si el Login es correcto
                        if (("Invitado" == UsuarioActual.Id) ||
                            (dbReproductor.ValidarLogin(UsuarioActual.Id, UsuarioActual.Password)))
                        {
                            loggedIn = true;
                        }
                    }
                    else if (UsuarioActual.IsNewUser)   //Si es nuevo usuario
                    {
                        //Si no hubo error al registrar un usuario nuevo
                        if (dbReproductor.AddUser(UsuarioActual.Id, UsuarioActual.Password) != -1)
                        {
                            loggedIn = true;
                        }
                    }
                }
            } while ( !loggedIn && (login.DialogResult != DialogResult.Cancel));
            SetUserLabel(login.UsuarioActual.Id);
        }

        private void CrearConfiguracionPorDefecto()
        {
            UsuarioActual.Configuracion.UltimoPerfilUsado = "Normal";
            UsuarioActual.Configuracion.UltimoSkinUsado = "Normal";
            dbReproductor.AgregarConfiguracionDeUsuario(UsuarioActual.Id, UsuarioActual.Configuracion.UltimoSkinUsado, UsuarioActual.Configuracion.UltimoPerfilUsado);
        }

        private void CargarConfiguracionDeUsuario()
        {
            UsuarioActual.Configuracion.CargarPerfiles(ref dbReproductor, UsuarioActual.Id);
            UsuarioActual.Configuracion.CargarUltimaConfiguracion(ref dbReproductor, UsuarioActual.Id);

            // Cargo las listas de reproduccion
            panelReproduccion.CargarComboDeListas(dbReproductor.Leer_Columna("Perfil", "Id_Perfil", "Nombre", UsuarioActual.Configuracion.UltimoPerfilUsado)[0]);
        }

        private void AplicarConfiguracionDeUsuario()
        {
            if (UsuarioActual.Configuracion.UltimoSkinUsado != "Normal")
                CambiarASkin(UsuarioActual.Configuracion.UltimoSkinUsado, UsuarioActual.Configuracion.ColorClaro, UsuarioActual.Configuracion.ColorOscuro);
        }

        private void GuardarConfiguracionDeUsuario()
        {
            dbReproductor.ModificarConfiguracionesSkin(UsuarioActual.Configuracion.UltimoSkinUsado, UsuarioActual.Id, UsuarioActual.Configuracion.ColorClaro.Name, UsuarioActual.Configuracion.ColorOscuro.Name);
            dbReproductor.ModificarConfiguracionesPerfil(UsuarioActual.Configuracion.UltimoPerfilUsado, UsuarioActual.Id);
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones opc = new Opciones(this, panelReproduccion, ref dbReproductor);
            opc.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acerca = new AcercaDe();
            acerca.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                textBoxCancion.Text = DesplazarString(textBoxCancion.Text.ToString());
                this.Text = DesplazarString(this.Text);
                if (trackBarReproduccion.Value < trackBarReproduccion.Maximum)
                {
                    TimeSpan actualPosition = TimeSpan.FromSeconds(player.CurrentPosition / 1000);
                    labelContador.Text = string.Format("{0:00}", actualPosition.Hours) + ":" + string.Format("{0:00}", actualPosition.Minutes) + ":" + string.Format("{0:00}", actualPosition.Seconds);
                    trackBarReproduccion.Value = (int)player.CurrentPosition;
                }
                else
                {
                    trackBarReproduccion.Value = 0;
                    timerBarra.Enabled = false;
                    botonSiguiente_Click(null, null);
                }
            }
            catch(Exception ex)
            {
                botonStop_Click(null, null);
                //MessageBox.Show(ex.Message, "Excepcion en el timer");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (PantallaPrincipal.ActiveForm.FormBorderStyle == FormBorderStyle.Sizable)
            {
                PantallaPrincipal.ActiveForm.FormBorderStyle = FormBorderStyle.None;
                PantallaPrincipal.ActiveForm.SendToBack();
                PantallaPrincipal.ActiveForm.TopMost = false;
                panelReproduccion.FormBorderStyle = FormBorderStyle.None;
                panelReproduccion.SendToBack();
                panelReproduccion.TopMost = false;
                botonBordes.BackgroundImage = Reproductor.Properties.Resources.pin2;
                menu.Hide();
            }
            else
            {
                PantallaPrincipal.ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
                panelReproduccion.FormBorderStyle = FormBorderStyle.Sizable;
                botonBordes.BackgroundImage = Reproductor.Properties.Resources.pin1;
                menu.Show();
            }
        }
        
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArchivo.ShowDialog();
        }     

        private void ObtenerImagen()
        {
            pictureBoxTapaDeAlbum.Image = lista[cancionActual].Imagen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panelReproduccion.IsStuck)
                panelReproduccion.IsStuck = false;
            else
            {
                panelReproduccion.IsStuck = true;
                if (panelReproduccion.IsOpen)
                    panelReproduccion.CambiarPosicion();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            object aux = listBox1.SelectedItem;
            if (idInterpreteBiblioteca != "")
            {
                Modificar_Artista m = new Modificar_Artista(idInterpreteBiblioteca, dbReproductor);
                m.ShowDialog();
            }
            if (listBox1.SelectedItems.Count == 1)
                listBox1.Items.Remove(listBox1.SelectedItem);
            MostrarInterpretes();
            if (listBox1.Items.Contains(aux))
                listBox1.SelectedItem = aux;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (idAlbumBiblioteca != "")
            {
                Modificar_Album al = new Modificar_Album(idAlbumBiblioteca, dbReproductor);
                al.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idCancionBiblioteca != "")
            {
                Modificar_Cancion c = new Modificar_Cancion(idCancionBiblioteca, idInterpreteBiblioteca, dbReproductor);
                c.ShowDialog();
            }
        }


        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            trackBarReproduccion.Value = 0;
            timerBarra.Enabled = false;
            if (lista.Count > 0)
            {
                player.Close();
                cancionActual++;
                if (cancionActual == lista.Count)   //Si es la ultima cancion de la lista, detengo la reproduccion
                    botonStop_Click(null, null);
                else
                {
                    player.Open(lista[cancionActual].Ruta.ToString());
                    player.Play(false);
                    timerBarra.Enabled = true;
                    ActualizarEtiquetas();
                }
                if (lista.Count != 0)
                    ObtenerImagen();
                panelReproduccion.SeleccionarCancion(cancionActual);
                if (buscar_letra != null && buscar_letra.ThreadState == ThreadState.Running)
                    buscar_letra.Abort();
                ThreadStart comienzo = new ThreadStart(Buscar_Letra);
                buscar_letra = new Thread(comienzo);
                buscar_letra.Start();
            }
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            trackBarReproduccion.Value = 0;
            timerBarra.Enabled = false;
            if (lista.Count > 0)
            {
                player.Close();
                cancionActual--;
                if (cancionActual < 0)
                    cancionActual = lista.Count - 1;
                if (lista.Count != 0)
                    ObtenerImagen();
                player.Open(lista[cancionActual].Ruta.ToString());
                player.Play(false);
                timerBarra.Enabled = true;
                ActualizarEtiquetas();
                panelReproduccion.SeleccionarCancion(cancionActual);
                if (buscar_letra != null && buscar_letra.ThreadState == ThreadState.Running)
                    buscar_letra.Abort();
                ThreadStart comienzo = new ThreadStart(Buscar_Letra);
                buscar_letra = new Thread(comienzo);
                buscar_letra.Start();
            }
        }

        private void botonPlay_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                if (player.Reproduciendo())
                {
                    player.Pause();
                    timerBarra.Enabled = false;
                }
                else
                {
                    player.Open(lista[cancionActual].Ruta.ToString());
                    player.Play(false);
                    timerBarra.Enabled = true;

                    // Creo hilo para buscar letra de canciones
                    if (buscar_letra != null && buscar_letra.ThreadState == ThreadState.Running)
                        buscar_letra.Abort();
                    ThreadStart comienzo = new ThreadStart(Buscar_Letra);
                    buscar_letra = new Thread(comienzo);
                    buscar_letra.Start();
                }
                panelReproduccion.SeleccionarCancion(cancionActual);
            }
        }

        private void Buscar_Letra()
        {
            buscar_letra = Thread.CurrentThread;
            try
            {
                if (cancionActual >= 0)
                {
                    string letra = lista[cancionActual].GetLyrics();

                    if (letra.Equals("Not found"))
                    {
                        richTextBoxLetras.Text = "No se encontraron letras para la cancion";
                    }
                    else
                    {
                        richTextBoxLetras.Text = letra;
                    }
                    richTextBoxLetras.SelectAll();
                    richTextBoxLetras.SelectionAlignment = HorizontalAlignment.Center;
                }
                buscar_letra = null;
            }
            catch (Exception)
            {
                richTextBoxLetras.Text = "No hay conexion a internet para buscar las letras.";
            }
        }

        private void abrirArchivo_FileOk(object sender, CancelEventArgs e)
        {
            string[] rutas;

            panelReproduccion.LimpiarLista();
            lista.Clear();      //Hay que ver si es asi o no
            rutas = abrirArchivo.FileNames;
            foreach (string path in rutas)
            {
                Cancion song = new Cancion(path);
                lista.Add(song);
            }
            panelReproduccion.CargarLista();
            player.Close();
            player.Open(lista[0].Ruta.ToString());
            player.Play(false);
            cancionActual = 0;
            ActualizarEtiquetas();
            ObtenerImagen();
            timerBarra.Enabled = true;  
        }

        private void botonStop_Click(object sender, EventArgs e)
        {
            timerBarra.Enabled = false;
            trackBarReproduccion.Value = 0;
            if (lista.Count != 0)
            {
                cancionActual = 0;
                player.Close();
                textBoxCancion.Text = lista[cancionActual].Nombre.ToString();
                this.Text = lista[cancionActual].Nombre.ToString();
            }
        }

        private void trackBarReproduccion_MouseUp(object sender, MouseEventArgs e)
        {
            if (cancionActual >= 0 && lista.Count > 0)
            {
                player.Seek((ulong)trackBarReproduccion.Value, (ulong)lista[cancionActual].Duracion.TotalMilliseconds);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (login.DialogResult != DialogResult.Cancel)
            {
                if ((hiloActualizar != null) && hiloActualizar.IsAlive)
                {
                    hiloActualizar.Abort();
                    GuardarConfiguracionDeUsuario();
                }
                else
                {
                    if (buscador != null)
                        buscador.Abort();
                    if (buscar_letra != null)
                        buscar_letra.Abort();
                    GuardarConfiguracionDeUsuario();
                }
            }
            dbReproductor.Close();
        }
        
        public void ReproducirCancion(int num)
        {
            botonStop_Click(null, null);
            cancionActual = num;
            botonPlay_Click(null, null);
            ActualizarEtiquetas();
            ObtenerImagen();
        }

        public void DetenerReproduccion()
        {
            botonStop_Click(null, null);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if ("" != txtBuscador.Text)
            {
                ThreadStart comienzo = new ThreadStart(Buscador);
                Thread buscador = new Thread(comienzo);

                listBoxBuscador.Items.Clear();
                listBoxBuscador.Items.Add("Buscando...");

                buscador.Start();
            }
            else
            {
                MessageBox.Show("Debes ingresar algo para buscar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Buscador()
        {
            buscador = Thread.CurrentThread;
            string busqueda = "%" + txtBuscador.Text + "%";

            List<string> canciones = dbReproductor.Buscar(busqueda);

            listBoxBuscador.Items.Clear();

            if (canciones.Count == 0)
            {
                MessageBox.Show("La Búsqueda no ha arrojado ningun resultado.");
            }
            else
            {
                foreach (string cancion in canciones)
                {
                    Cancion aux = new Cancion(cancion);
                    listBoxBuscador.Items.Add(aux.Nombre);
                }
                listaBusqueda = canciones;
            }
            //Si no encuentra, informa en pantalla
            //Sino, toma los datos necesarios y ahce la lista*/
            buscador = null;
        }

        public void MostrarInterpretes()    //completa el listbox1 con la lista de interpretes de la base de datos
        {
            //listBox1.Items.Clear();
            foreach (string interprete in dbReproductor.Leer_Columna("Interprete", "Nombre"))
            {
                if (!listBox1.Items.Contains(interprete))
                    listBox1.Items.Add(interprete);
            }
            listBox1.Sorted = true;
        }

        private void tabControlPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPrincipal.SelectedTab == tabControlPrincipal.TabPages[1])
            {
                MostrarInterpretes();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                List<Cancion> canciones = new List<Cancion>(dbReproductor.CancionDeCadaAlbum(listBox1.SelectedItem.ToString()));
                idInterpreteBiblioteca = dbReproductor.InterpreteId(listBox1.SelectedItem.ToString());
                idAlbumBiblioteca = "";
                idCancionBiblioteca = "";

                ImageList imagenes = new ImageList();
                listView1.LargeImageList = imagenes;
                listView1.LargeImageList.ImageSize = new Size(50, 50);
                listView1.Clear();
                listBox2.Items.Clear();
                if (canciones.Count == 0)
                {
                    dbReproductor.BorrarRegistro("Interprete", "Id", idInterpreteBiblioteca);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    idInterpreteBiblioteca = "";
                }
                else
                {
                    foreach (Cancion song in canciones)
                    {
                        imagenes.Images.Add(song.Album, song.Imagen);
                        listView1.Items.Add(new ListViewItem(song.Album, song.Album));
                    }
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                idAlbumBiblioteca = dbReproductor.AlbumId(listView1.SelectedItems[0].Text.ToString(), idInterpreteBiblioteca);
                idCancionBiblioteca = "";
                listBox2.Items.Clear();

                foreach (string cad in dbReproductor.Leer_Columna("Cancion", "Titulo", "Id_Album", idAlbumBiblioteca))
                {
                    listBox2.Items.Add(cad);
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 && listBox2.SelectedItems.Count == 1)    //SGUNDA PARTE DE IIF
            {

                string[] paths = dbReproductor.Leer_Columna("Cancion", "Path", "Id_Album", idAlbumBiblioteca);

                int x = listBox2.SelectedIndex;
                //lista.Clear();

                try
                {
                    Cancion song = new Cancion(paths[x]);
                    //Agrego la cancion a la lista
                    lista.Add(song);

                    //Actualizo la lista del reproductor
                    panelReproduccion.LimpiarLista();
                    panelReproduccion.CargarLista();

                    //Detengo la reproduccion actual
                    botonStop_Click(null, null);
                    cancionActual = lista.Count - 1;

                    //Comienzo reproduccion actual
                    botonPlay_Click(null, null);
                    ActualizarEtiquetas();
                    ObtenerImagen();
                }
                catch (Exception)
                {
                    dbReproductor.BorrarCancion(idInterpreteBiblioteca, idAlbumBiblioteca, paths[x]);
                    MessageBox.Show("No se ha encontrado la canción solicitada");
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string[] paths;

            if (listView1.SelectedItems.Count == 1)
            {
                idAlbumBiblioteca = dbReproductor.AlbumId(listView1.SelectedItems[0].Text.ToString(), idInterpreteBiblioteca);
                paths = dbReproductor.Leer_Columna("Cancion", "Path", "Id_Album", idAlbumBiblioteca);

                //Detengo la reproduccion actual
                botonStop_Click(null, null);

                //Borro la lista de canciones
                lista.Clear();
                panelReproduccion.LimpiarLista();

                //Cargo el album elegido
                foreach (string path in paths)
                {
                    try
                    {
                        lista.Add(new Cancion(path));
                    }
                    catch (Exception)
                    {
                        dbReproductor.BorrarCancion(idInterpreteBiblioteca, idAlbumBiblioteca, path);
                        MessageBox.Show("No se ha encontrado la canción solicitada");
                    }
                }
                //Actualizo la lista de reproduccion en el panel
                panelReproduccion.CargarLista();
                cancionActual = 0;

                //Comienzo la reproduccion
                ActualizarEtiquetas();
                botonPlay_Click(null, null);
                ActualizarEtiquetas();
                ObtenerImagen();
            }

            //Muestro la pestaña reproduccion
            tabControlPrincipal.SelectedIndex = 0;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count == 1)
            {
                idCancionBiblioteca = dbReproductor.Leer_Columna("Cancion", "Id_Cancion", "Id_Album", idAlbumBiblioteca)[listBox2.SelectedIndex];
            }
        }

        private void listBoxBuscador_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxBuscador.SelectedItems.Count > 0)
            {
                //Detengo la reproduccion actual
                botonStop_Click(null, null);

                //Borro la lista de canciones
                lista.Clear();
                panelReproduccion.LimpiarLista();

                //Cargo las canciones
                foreach (string song in listaBusqueda)
                {
                    Cancion aux = new Cancion(song);
                    lista.Add(aux);
                }

                //Actualizo la lista de reproduccion en el panel
                panelReproduccion.CargarLista();
                cancionActual = listBoxBuscador.SelectedIndex;

                //Comienzo la reproduccion
                ActualizarEtiquetas();
                botonPlay_Click(null, null);
                ActualizarEtiquetas();
                ObtenerImagen();

                //Muestro la pestaña reproduccion
                tabControlPrincipal.SelectedIndex = 0;
            }
        }

        #endregion

        #region Metodos Visuales y demás

        public void SetUserLabel(string name)
        {
            labelUsuarioActual.Text = name;
        }

        public void CambiarASkinNormal()
        {
            //Ventana principal
            this.BackColor = Color.FromName("Control");
            panelBotones.BackColor = Color.FromName("Control");
            //Trackbar de tiempo de reproduccion
            trackBarReproduccion.BackColor = Color.FromName("Control");
            //Boton izquierda
            botonAnterior.BackColor = Color.FromName("Control");
            botonAnterior.Text = "l◄◄";
            botonAnterior.BackgroundImage = null;
            botonAnterior.FlatStyle = FlatStyle.System;
            //Boton derecha
            botonSiguiente.BackColor = Color.FromName("Control");
            botonSiguiente.Text = "►►l";
            botonSiguiente.BackgroundImage = null;
            botonSiguiente.FlatStyle = FlatStyle.System;
            //Boton play
            botonPlay.BackColor = Color.FromName("Control");
            botonPlay.Text = "►";
            botonPlay.BackgroundImage = null;
            botonPlay.FlatStyle = FlatStyle.System;
            //Boton stop
            botonStop.Text = "■";
            botonStop.BackColor = Color.FromName("Control");
            botonStop.BackgroundImage = null;
            botonStop.FlatStyle = FlatStyle.System;
            //Panel lista de reproduccion
            panelReproduccion.BackColor = Color.FromName("Control");
            //Panel inferior
            panelBotones.BackgroundImage = null;
            //paneles con pestaña
            Cambiar_color_tabs(Color.FromName("Control"));
            //Color de contador
            labelContador.ForeColor = Color.FromName("ControlText");
            labelContador.BackColor = Color.FromName("Control");
            // Color de botones
            botonBordes.BackColor = Color.FromName("Control");
            botonPanel.BackColor = Color.FromName("Control");
            botonVolumen.BackColor = Color.FromName("Control");
            botonBordes.ForeColor = Color.Black;
            botonPanel.ForeColor = Color.Black;
            botonVolumen.ForeColor = Color.Black;
        }

        public void CambiarASkin(string skinName, Color colorClaro, Color colorOscuro)
        {
            try
            {
                //Asigno las imagenes
                botonAnterior.BackgroundImage = Image.FromFile(UsuarioActual.Configuracion.SkinsPath + "\\" + skinName + "\\botonizq.png");
                botonSiguiente.BackgroundImage = Image.FromFile(UsuarioActual.Configuracion.SkinsPath + "\\" + skinName + "\\botonder.png");
                botonPlay.BackgroundImage = Image.FromFile(UsuarioActual.Configuracion.SkinsPath + "\\" + skinName + "\\boton.png");
                botonStop.BackgroundImage = Image.FromFile(UsuarioActual.Configuracion.SkinsPath + "\\" + skinName + "\\botonstop.png");
                panelBotones.BackgroundImage = Image.FromFile(UsuarioActual.Configuracion.SkinsPath + "\\" + skinName + "\\panel.png");
                
                //Cambio el estilo, para poder visualizar las imagenes, y pongo color
                botonAnterior.FlatStyle = FlatStyle.Popup;
                botonSiguiente.FlatStyle = FlatStyle.Popup;
                botonPlay.FlatStyle = FlatStyle.Popup;
                botonStop.FlatStyle = FlatStyle.Popup;

                //Asigno la propiedad layout para dimensionar las imagenes
                botonAnterior.BackgroundImageLayout = ImageLayout.Stretch;
                botonSiguiente.BackgroundImageLayout = ImageLayout.Stretch;
                botonPlay.BackgroundImageLayout = ImageLayout.Stretch;
                botonStop.BackgroundImageLayout = ImageLayout.Stretch;
                panelBotones.BackgroundImageLayout = ImageLayout.Stretch;

                //Borro el texto de los botones o cambio color
                botonAnterior.Text = "";
                botonSiguiente.Text = "";
                botonPlay.Text = "";
                botonStop.Text = "";
                panelBotones.Text = "";
                botonVolumen.ForeColor = colorClaro;
                botonPanel.ForeColor = colorClaro;
                botonBordes.ForeColor = colorClaro;
                labelContador.ForeColor = colorClaro;

                //Asigno colores
                botonAnterior.BackColor = colorOscuro;
                botonSiguiente.BackColor = colorOscuro;
                botonStop.BackColor = colorOscuro;
                botonPlay.BackColor = colorOscuro;
                this.BackColor = colorOscuro;
                panelReproduccion.BackColor = colorOscuro;
                botonVolumen.BackColor = colorOscuro;
                botonPanel.BackColor = colorOscuro;
                botonVolumen.BackColor = colorOscuro;
                labelContador.BackColor = colorOscuro;
                botonBordes.BackColor = colorOscuro;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("No se encontraron las imagenes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CambiarASkinNormal();
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                if (panelReproduccion.IsStuck && panelReproduccion.IsOpen)
                    panelReproduccion.CambiarPosicion();
            }
            catch
            {
            }
        }

        public void CambiarPosicion()
        {
            this.Location = new Point(panelReproduccion.Location.X - this.Width, panelReproduccion.Location.Y);
            this.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (panelReproduccion.IsStuck && panelReproduccion.IsOpen)
                panelReproduccion.CambiarPosicion();
        }

        private void CambiarAModoCompacto()
        {
            this.WindowState = FormWindowState.Normal;
            this.CenterToScreen();
            tabControlPrincipal.Hide();
            this.MinimumSize = new Size(0, 0);
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = new Size(655, 220);
        }

        private void CambiarAModoNormal()
        {
            this.MinimumSize = new Size(655, 481);
            this.MaximizeBox = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            tabControlPrincipal.Show();
        }

        private void modoCompactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarAModoCompacto();
        }

        private void modoNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarAModoNormal();
        }

        public void PegarPanel()
        {
            panelReproduccion.IsStuck = true;
        }

        public void DespegarPanel()
        {
            panelReproduccion.IsStuck = false;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (panelReproduccion.IsOpen)
            {
                Cerrar_Panel();
            }
            else
            {
                Abrir_Panel();
            }
        }

        private void Cerrar_Panel()
        {
            panelReproduccion.Hide();
            panelReproduccion.IsOpen = false;
        }

        private void Abrir_Panel()
        {
            panelReproduccion.Show();
            panelReproduccion.IsOpen = true;
        }

        private void trackBar2_Leave(object sender, EventArgs e)
        {
            trackBarVolumen.Hide();
        }

        private void boton_volumen_Click(object sender, EventArgs e)
        {
            if (trackBarVolumen.Visible.ToString() == "True")
                trackBarVolumen.Hide();
            else
                trackBarVolumen.Show();
        }
        
        private string DesplazarString(string texto)
        {
            return texto.Substring(1) + texto.Substring(0, 1);
        }

        public void Cambiar_color_tabs(Color col)
        {
            tabPage1.BackColor = col;
            tabPage2.BackColor = col;
            tabPage3.BackColor = col;
        }

        public void ActualizarEtiquetas()  //Debe ir despues de un Play(....)
        {
            if (lista.Count != 0)
            {
                this.Text = lista[cancionActual].Nombre + "          ";
                textBoxCancion.Text = lista[cancionActual].Nombre + "          ";
                textBoxAlbum.Text = lista[cancionActual].Album;
                textBoxAño.Text = lista[cancionActual].Año.ToString();
                textBoxArtista.Text = lista[cancionActual].Artista;
                textBoxGenero.Text = lista[cancionActual].Genero;
                richTextBoxLetras.Text = lista[cancionActual].Letra;

                //Calculo la longitud del trackbar
                ulong length = player.AudioLength;
                trackBarReproduccion.Maximum = (int)length;
            }
        }

        #endregion

        private void trackBarVolumen_Scroll(object sender, EventArgs e)
        {
            player.Volume = (ushort) trackBarVolumen.Value;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] rutas = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<string> paths = new List<string>(rutas);

                // Realizo un filtrado, es decir, elimino todos
                // aquellos strings que no pertenezcan a directorios
                for (int i = 0; i < paths.Count; i++)
                {
                    if (!Directory.Exists(paths[i]))
                    {
                        paths.Remove(paths[i]);
                        i--;
                    }
                }

                // Ahora actualizo y comienzo el hilo de actualizacion
                dbReproductor.ActualizarRutaDeArchivos(UsuarioActual.Id, paths);

                hiloActualizar = new Thread(new ThreadStart(Actualizar));
                hiloActualizar.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Actualizar()
        {
            labelTrabajando.Text = "Actualizando";
            dbReproductor.ActualizarCanciones(this);
            labelTrabajando.Text = "";
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void reproducirPausarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botonPlay_Click(null, null);
        }

        private void detenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botonStop_Click(null, null);
        }

        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botonSiguiente_Click(null, null);
        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botonAnterior_Click(null, null);
        }
    }
}