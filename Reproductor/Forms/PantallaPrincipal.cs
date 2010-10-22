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

namespace Reproductor
{
    public partial class PantallaPrincipal : Form
    {
        #region Variables

        public Usuario user;
        public Configuracion config;

        List<Cancion> lista;
        private int cancionActual;
        private PanelReproduccion panelReproduccion;
        private Player player;
        private BaseDeDatos dbReproductor;
        private Login login;
        private UInt64 milisegundos;
        private TimeSpan actualPosition;

        #endregion

        #region Métodos funcionales
        
        public PantallaPrincipal()
        {
            InitializeComponent();

            //Creo instancia de objetos
            panelReproduccion = new PanelReproduccion();
            dbReproductor = new BaseDeDatos();
            login = new Login(this, ref dbReproductor);
            lista = new List<Cancion>();
            player = new Player();
            user = new Usuario();
            config = new Configuracion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Abro la base de datos
            dbReproductor.Open(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + config.Path);
            //dbReproductor.Open(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Universidad Fabio\Proyectos Visual Studio\Reproductor\Base_Reproductor.mdb");
            //dbReproductor.Open(ConfigurationManager.ConnectionStrings["StringDeConexion"].ConnectionString.ToString());

            //Inicializo variables, etc
            panelReproduccion.Asignar(this, ref dbReproductor, ref lista);
            panelReproduccion.CambiarPosicion();
            abrirArchivo.Multiselect = true;
            abrirArchivo.FileName = "";
            abrirArchivo.Filter = "MP3 files|*.mp3|WAV files|*.wav|All files|*.*";
            cancionActual = -1;

            //Muestro el login
            login.Show();

            //TODO:
            //Cuando cierra el login (seria conveniente sincronizar)
            //Si es nuevo el usuario, creo todos los registros de
            //la configuracion por defecto, como perfil, skin,
            //lista por defecto(Todos), etc.
            //Sino, cargo la configuracion del usuario
            //Y la aplico
        }
        
        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones opc = new Opciones(this, panelReproduccion, ref dbReproductor);
            opc.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acerca = new AcercaDe();
            acerca.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxCancion.Text = DesplazarString(textBoxCancion.Text.ToString());
            this.Text = DesplazarString(this.Text);
            if (trackBarReproduccion.Value < trackBarReproduccion.Maximum-499)
            {
                actualPosition = TimeSpan.FromMilliseconds(milisegundos);
                labelContador.Text = string.Format("{0:00}", actualPosition.Hours) + ":" + string.Format("{0:00}", actualPosition.Minutes) + ":" + string.Format("{0:00}", actualPosition.Seconds);
                milisegundos += (ulong)timerBarra.Interval;
                trackBarReproduccion.Value += timerBarra.Interval;
            }
            else
            {
                trackBarReproduccion.Value = 0;
                milisegundos = 0;
                actualPosition = TimeSpan.Zero;
                labelContador.Text = string.Format("{0:00}", actualPosition.Hours) + ":" + string.Format("{0:00}", actualPosition.Minutes) + ":" + string.Format("{0:00}", actualPosition.Seconds);
                timerBarra.Enabled = false;
                botonSiguiente_Click(null, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (PantallaPrincipal.ActiveForm.FormBorderStyle == FormBorderStyle.Sizable)
            {
                PantallaPrincipal.ActiveForm.FormBorderStyle = FormBorderStyle.None;
                menu.Hide();
            }
            else
            {
                PantallaPrincipal.ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
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
            Modificar_Artista m = new Modificar_Artista(this,panelReproduccion);
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar_Album al = new Modificar_Album(this, panelReproduccion);
            al.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modificar_Cancion c = new Modificar_Cancion(this, panelReproduccion);
            c.Show();
        }



        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            trackBarReproduccion.Value = 0;
            timerBarra.Enabled = false;
            if (cancionActual != -1)
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
            }
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            trackBarReproduccion.Value = 0;
            timerBarra.Enabled = false;
            if(cancionActual != -1)
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
            }
        }

        private void botonPlay_Click(object sender, EventArgs e)
        {
            if (cancionActual != -1)
            {
                if (player.Reproduciendo())
                {
                    player.Pause();
                    timerBarra.Enabled = false;
                    //
                    botonPlay.Text = "►";
                }
                else
                {
                    player.Open(lista[cancionActual].Ruta.ToString());
                    player.Play(false);
                    timerBarra.Enabled = true;
                    //
                    botonPlay.Text = "ll";
                }
                panelReproduccion.SeleccionarCancion(cancionActual);
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
            //
            milisegundos = 0;
            panelReproduccion.CargarLista();
            player.Close();
            player.Open(lista[0].Ruta.ToString());
            player.Play(false);
            cancionActual = 0;
            ActualizarEtiquetas();
            ObtenerImagen();
            panelReproduccion.SeleccionarCancion(cancionActual);
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
                //
                botonPlay.Text = "►";
            }
        }

        private void trackBarReproduccion_MouseUp(object sender, MouseEventArgs e)
        {
            player.Seek((ulong)trackBarReproduccion.Value, (ulong)lista[cancionActual].Duracion.TotalMilliseconds);
            milisegundos = (ulong)trackBarReproduccion.Value;
            labelContador.Text = string.Format("{0:00}", actualPosition.Hours) + ":" + string.Format("{0:00}", actualPosition.Minutes) + ":" + string.Format("{0:00}", actualPosition.Seconds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbReproductor.Close();
        }

        public void CambiarDeUsuario(string user)
        {
            //usuarioActual = user;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            string letra = lista[cancionActual].GetLyrics();

            if(letra.Equals("Not found"))
            {
                richTextBoxLetras.Text = "No se encontraron letras para la cancion";
            }
            else
            {
                richTextBoxLetras.Text = letra;
            }
        }

        public void ReproducirCancion(int num)
        {
            botonStop_Click(null, null);
            cancionActual = num;
            ActualizarEtiquetas();
            botonPlay_Click(null, null);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if ("" != txtBuscador.Text && comboBoxBuscador.SelectedItem != null)
            {
                ThreadStart comienzo = new ThreadStart(Buscador);
                Thread buscador = new Thread(comienzo);

                ImageList imagenes = new ImageList();
                listView1.LargeImageList = imagenes;
                listView1.LargeImageList.ImageSize = new Size(50, 50);
                foreach (Cancion song in lista)
                {
                    imagenes.Images.Add(song.Album, song.Imagen);
                    listView1.Items.Add(new ListViewItem(song.Album, song.Album));
                }
                listViewBuscador.Items.Clear();
                //listViewBuscador.Items.Add(new ListViewItem("Cargando..."));
                buscador.Start();
            }
            else if (comboBoxBuscador.SelectedItem != null)
            {
                MessageBox.Show("Debes ingresar algo para buscar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Debes elegir un criterio para buscar", "Ojo", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void Buscador()
        {
            //Busca en la base de datos
            //Si no encuentra, informa en pantalla
            //Sino, toma los datos necesarios y ahce la lista
        }

        public void MostrarInterpretes()    //completa el listbox1 con la lista de interpretes de la base de datos
        {
            listBox1.Items.Clear();
            foreach (string interprete in dbReproductor.Leer_Columna("Interprete", "Nombre"))
            {
                listBox1.Items.Add(interprete);
            }
            listBox1.Sorted = true;
        }

        private void tabControlPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPrincipal.SelectedTab == tabControlPrincipal.TabPages[1])
                MostrarInterpretes();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
                List<Cancion> canciones = dbReproductor.CancionDeCadaAlbum(listBox1.SelectedItem.ToString());

                ImageList imagenes = new ImageList();
                listView1.LargeImageList = imagenes;
                listView1.LargeImageList.ImageSize = new Size(50, 50);
                listView1.Clear();
                listBox2.Items.Clear();

                foreach (Cancion song in canciones)
                {
                    imagenes.Images.Add(song.Album, song.Imagen);
                    listView1.Items.Add(new ListViewItem(song.Album, song.Album));
                }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                listBox2.Items.Clear();
                foreach (string cad in dbReproductor.Leer_Columna("Cancion", "Titulo", "Id_Album", dbReproductor.AlbumId(listView1.SelectedItems[0].Text, dbReproductor.InterpreteId(listBox1.SelectedItem.ToString()))))
                {
                    listBox2.Items.Add(cad);
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            string[] paths = dbReproductor.Leer_Columna("Cancion", "Path", "Titulo", listBox2.SelectedItem.ToString());

            Cancion song = new Cancion(paths[0]);
            //lista.Clear();

            try
            {
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
                //aca tiene q borrar si no existe, despues lo agrego por las dudas
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string[] paths;

            if (listView1.SelectedItems.Count == 1)
            {
                paths = dbReproductor.Leer_Columna("Cancion", "Path", "Id_Album", dbReproductor.AlbumId(listView1.SelectedItems[0].Text, dbReproductor.InterpreteId(listBox1.SelectedItem.ToString())));

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
                        //aca borra si la cancion no existe
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
                /*if (!player.Reproduciendo())
                {
                    //tiene que reproducir la primer cancion del album
                }*/
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
        }

        public void CambiarASkinPacman()
        {
            //Ventana principal
            this.BackColor = Color.Black;
            panelBotones.BackColor = Color.Black;
            //Trackbar de tiempo de reproduccion
            trackBarReproduccion.BackColor = Color.Black;
            //Boton izquierda
            botonAnterior.BackColor = Color.Black;
            botonAnterior.Text = "";
            botonAnterior.FlatStyle = FlatStyle.Popup;
            botonAnterior.BackgroundImage = Reproductor.Properties.Resources.botonizq;
            botonAnterior.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton derecha
            botonSiguiente.BackColor = Color.Black;
            botonSiguiente.Text = "";
            botonSiguiente.FlatStyle = FlatStyle.Popup;
            botonSiguiente.BackgroundImage = Reproductor.Properties.Resources.botonder;
            botonSiguiente.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton play
            botonPlay.Text = "";
            botonPlay.BackColor = Color.Black;
            botonPlay.FlatStyle = FlatStyle.Popup;
            botonPlay.BackgroundImage = Properties.Resources.boton;
            botonPlay.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton stop
            botonStop.BackColor = Color.Black;
            botonStop.Text = "";
            botonStop.FlatStyle = FlatStyle.Popup;
            botonStop.BackgroundImage = Properties.Resources.botonstop;
            botonStop.BackgroundImageLayout = ImageLayout.Stretch;
            //Panel lista de reproduccion
            panelReproduccion.BackColor = Color.Black;
            //Panel inferior
            panelBotones.BackgroundImage = Properties.Resources.panel;
            panelBotones.BackgroundImageLayout = ImageLayout.Stretch;
            //paneles con pestaña
            Cambiar_color_tabs(Color.Yellow);
            //Color del contador
            labelContador.ForeColor = Color.White;
        }

        public void CambiarSkin()
        {
            //Ventana principal
            this.BackColor = Color.Black;
            panelBotones.BackColor = Color.Black;
            //Trackbar de tiempo de reproduccion
            trackBarReproduccion.BackColor = Color.Black;
            //Boton izquierda
            botonAnterior.BackColor = Color.Black;
            botonAnterior.Text = "";
            botonAnterior.FlatStyle = FlatStyle.Popup;
            botonAnterior.BackgroundImage = Reproductor.Properties.Resources.botonizq;
            botonAnterior.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton derecha
            botonSiguiente.BackColor = Color.Black;
            botonSiguiente.Text = "";
            botonSiguiente.FlatStyle = FlatStyle.Popup;
            botonSiguiente.BackgroundImage = Reproductor.Properties.Resources.botonder;
            botonSiguiente.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton play
            botonPlay.Text = "";
            botonPlay.BackColor = Color.Black;
            botonPlay.FlatStyle = FlatStyle.Popup;
            botonPlay.BackgroundImage = Properties.Resources.boton;
            botonPlay.BackgroundImageLayout = ImageLayout.Stretch;
            //Boton stop
            botonStop.BackColor = Color.Black;
            botonStop.Text = "";
            botonStop.FlatStyle = FlatStyle.Popup;
            botonStop.BackgroundImage = Properties.Resources.botonstop;
            botonStop.BackgroundImageLayout = ImageLayout.Stretch;
            //Panel lista de reproduccion
            panelReproduccion.BackColor = Color.Black;
            //Panel inferior
            panelBotones.BackgroundImage = Properties.Resources.panel;
            panelBotones.BackgroundImageLayout = ImageLayout.Stretch;
            //paneles con pestaña
            Cambiar_color_tabs(Color.Yellow);
            //Color del contador
            labelContador.ForeColor = Color.White;
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
            trackBar2.Hide();
        }

        private void boton_volumen_Click(object sender, EventArgs e)
        {
            if (trackBar2.Visible.ToString() == "True")
                trackBar2.Hide();
            else
                trackBar2.Show();
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

                botonPlay.Text = "ll";
                milisegundos = 0;
                trackBarReproduccion.Value = 0;
                trackBarReproduccion.Maximum = (int)lista[cancionActual].Duracion.TotalMilliseconds;
            }
        }                

        #endregion
    }
}