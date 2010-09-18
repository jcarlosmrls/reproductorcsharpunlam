﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        #region Variables

        List<Cancion> lista;
        private int cancionActual;
        private PanelReproduccion panelReproduccion;
        private Player player;
        private BaseDeDatos dbReproductor;
        private string usuario;


        #endregion

        public Form1()
        {
            InitializeComponent();
            panelReproduccion = new PanelReproduccion();
            dbReproductor = new BaseDeDatos();
            panelReproduccion.Asignar(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dbReproductor.Open(ConfigurationManager.ConnectionStrings["StringDeConexion"].ConnectionString.ToString());
            dbReproductor.Open(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Universidad Fabio\Proyectos Visual Studio\Reproductor\Base_Reproductor.mdb");
            panelReproduccion.CambiarPosicion();
            lista = new List<Cancion>();
            abrirArchivo.Multiselect = true;
            abrirArchivo.FileName = "";
            abrirArchivo.Filter = "MP3 files|*.mp3|WAV files|*.wav|All files|*.*";
            cancionActual = -1;
            player = new Player();
            Login login = new Login(this, ref dbReproductor);            
            login.Show();
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
            if (trackBarReproduccion.Value < trackBarReproduccion.Maximum)
            {
                TimeSpan actualPosition = TimeSpan.FromSeconds(player.CurrentPosition/1000);
                labelContador.Text = actualPosition.Hours.ToString() + ":" + actualPosition.Minutes.ToString() + ":" + actualPosition.Seconds.ToString();
                trackBarReproduccion.Value = (int) player.CurrentPosition;
            }
            else
            {
                trackBarReproduccion.Value = 0;
                timerBarra.Enabled = false;
                botonSiguiente_Click(null, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Form1.ActiveForm.FormBorderStyle == FormBorderStyle.Sizable)
            {
                Form1.ActiveForm.FormBorderStyle = FormBorderStyle.None;
                menuStrip1.Hide();
            }
            else
            {
                Form1.ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
                menuStrip1.Show();
            }
        }

        public void Cambiar_color_tabs(Color col)
        {
            tabPage1.BackColor = col;
            tabPage2.BackColor = col;
            tabPage3.BackColor = col;
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

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArchivo.ShowDialog();
        }

        private void ActualizarEtiquetas()  //Debe ir despues de un Play(....)
        {
            if (lista.Count != 0)
            {
                this.Text = lista[cancionActual].Nombre + "          ";
                textBoxCancion.Text = lista[cancionActual].Nombre + "          ";
                textBoxAlbum.Text = lista[cancionActual].Album;
                if (lista[cancionActual].Año.ToString() != "0")
                {
                    textBoxAño.Text = lista[cancionActual].Año.ToString();
                }
                else
                {
                    textBoxAño.Text = "";
                }
                textBoxArtista.Text = lista[cancionActual].Artista;
                textBoxGenero.Text = lista[cancionActual].Genero;
                richTextBoxLetras.Text = lista[cancionActual].Letra;
                //Calculo la longitud del trackbar
                ulong length = player.AudioLength;
                trackBarReproduccion.Maximum = (int) length;
            }
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

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (panelReproduccion.IsStuck && panelReproduccion.IsOpen)
                panelReproduccion.CambiarPosicion();
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
            tabControl1.Hide();
            this.MinimumSize = new Size(0,0);
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = new Size(655, 220);
        }

        private void CambiarAModoNormal()
        {
            this.MinimumSize = new Size(655, 481);
            this.MaximizeBox = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            tabControl1.Show();
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

        private string DesplazarString(string texto)
        {
            return texto.Substring(1) + texto.Substring(0, 1);
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
                }
                else
                {
                    player.Open(lista[cancionActual].Ruta.ToString());
                    player.Play(false);
                    timerBarra.Enabled = true;
                }
            }
        }

        private void abrirArchivo_FileOk(object sender, CancelEventArgs e)
        {
            string[] rutas;

            lista.Clear();      //Hay que ver si es asi o no
            rutas = abrirArchivo.FileNames;
            foreach (string path in rutas)
            {
                lista.Add(new Cancion(path));
            }
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
            }
            textBoxCancion.Text = lista[cancionActual].Nombre.ToString();
            this.Text = lista[cancionActual].Nombre.ToString();
        }

        private void trackBarReproduccion_MouseUp(object sender, MouseEventArgs e)
        {
            player.Seek((ulong)trackBarReproduccion.Value, (ulong)lista[cancionActual].Duracion.TotalMilliseconds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbReproductor.Close();
        }

        public void CambiarDeUsuario(string user)
        {
            usuario = user;
        }

        public string Usuario()
        {
            return usuario;
        }
    }
}