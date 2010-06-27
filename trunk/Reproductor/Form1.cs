using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        public bool panelAbierto = true;
        public bool panelPegado = true;
        PanelReproduccion panelReproduccion = new PanelReproduccion();

        public Form1()
        {
            InitializeComponent();
            panelReproduccion.Asignar(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelReproduccion.CambiarPosicion();
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
            panelReproduccion.CambiarPosicion();
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
            Opciones opc = new Opciones(this);
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
            label3.Text = DateTime.Now.ToString("HH:mm:ss");
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
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArchivo.FileName = "";
            abrirArchivo.Filter = "MP3 files|*.mp3|WAV files|*.wav|All files|*.*";
            abrirArchivo.ShowDialog();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (panelPegado)
                panelPegado = false;
            else
                panelPegado = true;
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
    }
}