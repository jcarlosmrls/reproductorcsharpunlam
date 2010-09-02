using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        #region Variables

        List<Cancion> lista;
        private int cancionActual;
        private bool panelAbierto = true;
        private bool panelPegado = true;
        private PanelReproduccion panelReproduccion = new PanelReproduccion();

        #endregion

        public Form1()
        {
            InitializeComponent();
            panelReproduccion.Asignar(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelReproduccion.CambiarPosicion();
            Reproductor.Form1.ActiveForm.Hide();
            lista = new List<Cancion>();
            abrirArchivo.Multiselect = true;
            abrirArchivo.FileName = "";
            abrirArchivo.Filter = "MP3 files|*.mp3|WAV files|*.wav|All files|*.*";
            cancionActual = 0;
            Login login = new Login();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelAbierto)
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
            panelAbierto = false;            
        }

        private void Abrir_Panel()
        {
            panelReproduccion.Show();
            panelAbierto = true;
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
            Opciones opc = new Opciones(this, panelReproduccion);
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
            trackBar1.BackColor = Color.FromName("Control");
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
            trackBar1.BackColor = Color.Black;
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
            string []rutas;
            lista.Clear();      //Hay que ver si es asi o no

            abrirArchivo.ShowDialog();
            rutas = abrirArchivo.FileNames;
            foreach (string path in rutas)
            {
                lista.Add(new Cancion(path));
            }
            ActualizarEtiquetas();
            ObtenerImagen();
        }

        private void ActualizarEtiquetas()
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
                labelContador.Text = lista[cancionActual].Duracion.ToString();
            }
        }
                

        private void ObtenerImagen()
        {
            pictureBoxTapaDeAlbum.Image = lista[cancionActual].Imagen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panelPegado)
                panelPegado = false;
            else
            {
                panelPegado = true;
                if (panelAbierto)
                    panelReproduccion.CambiarPosicion();
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (panelPegado && panelAbierto)
                panelReproduccion.CambiarPosicion();
        }

        public void CambiarPosicion()
        {
            this.Location = new Point(panelReproduccion.Location.X - this.Width, panelReproduccion.Location.Y);
            this.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (panelPegado && panelAbierto)
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
            panelPegado = true;
        }

        public void DespegarPanel()
        {
            panelPegado = false;
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
            cancionActual++;
            if (cancionActual == lista.Count)
                cancionActual = 0;
            ActualizarEtiquetas();
            ObtenerImagen();
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            cancionActual--;
            if (cancionActual < 0)
                cancionActual = lista.Count - 1;
            ActualizarEtiquetas();
            ObtenerImagen();
        }
    }
}