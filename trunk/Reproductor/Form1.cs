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
        private int panelAbierto = 1;
        private int maxTamV = Screen.PrimaryScreen.Bounds.Height;
        private int maxTamH = Screen.PrimaryScreen.Bounds.Width;
        private int minTamH = 655;

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(maxTamH, maxTamV);   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelAbierto == 1)
                Cerrar_Panel();
            else
                Abrir_Panel(); 
        }

        private void Cerrar_Panel()
        {
            if (Form1.ActiveForm.Width - 150 >= minTamH && panelAbierto == 1 && Form1.ActiveForm.WindowState != FormWindowState.Maximized)
            {
                tabControl1.Anchor -= AnchorStyles.Right;
                trackBar1.Anchor -= AnchorStyles.Right;
                trackBar2.Anchor = AnchorStyles.Left;
                panelBotones.Anchor = AnchorStyles.Left;
                panelAbierto = 0;
                button3.Text = ">>";
                Form1.ActiveForm.Width -= 150;
                label2.Hide();
                panelListaDeReproduccion.Hide();
                tabControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
                trackBar1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                panelBotones.Anchor = AnchorStyles.Bottom;
                trackBar2.Anchor = AnchorStyles.Bottom;
            }
        }

        private void Abrir_Panel()
        {
            if (Form1.ActiveForm.Width + 150 <= maxTamH && panelAbierto == 0 && Form1.ActiveForm.WindowState != FormWindowState.Maximized)
            {
                tabControl1.Anchor -= AnchorStyles.Right;
                trackBar1.Anchor -= AnchorStyles.Right;
                panelBotones.Anchor = AnchorStyles.Left;
                trackBar2.Anchor = AnchorStyles.Left;
                panelAbierto = 1;
                button3.Text = "<<";
                Form1.ActiveForm.Width += 150;
                label2.Show();
                panelListaDeReproduccion.Show();
                trackBar1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                tabControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
                panelBotones.Anchor = AnchorStyles.Bottom;
                trackBar2.Anchor = AnchorStyles.Bottom;
            }
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
            //Panel derecho
            panelListaDeReproduccion.BackColor = Color.Gray;
            panelListaDeReproduccion.ForeColor = Color.White;
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
    }
}