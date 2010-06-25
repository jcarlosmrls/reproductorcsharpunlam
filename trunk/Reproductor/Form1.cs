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
                panel1.Anchor = AnchorStyles.Left;
                panelAbierto = 0;
                button3.Text = ">>";
                Form1.ActiveForm.Width -= 150;
                label2.Hide();
                panel2.Hide();
                tabControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
                trackBar1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                panel1.Anchor = AnchorStyles.Bottom;
                trackBar2.Anchor = AnchorStyles.Bottom;
            }
        }

        private void Abrir_Panel()
        {
            if (Form1.ActiveForm.Width + 150 <= maxTamH && panelAbierto == 0 && Form1.ActiveForm.WindowState != FormWindowState.Maximized)
            {
                tabControl1.Anchor -= AnchorStyles.Right;
                trackBar1.Anchor -= AnchorStyles.Right;
                panel1.Anchor = AnchorStyles.Left;
                trackBar2.Anchor = AnchorStyles.Left;
                panelAbierto = 1;
                button3.Text = "<<";
                Form1.ActiveForm.Width += 150;
                label2.Show();
                panel2.Show();
                trackBar1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                tabControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
                panel1.Anchor = AnchorStyles.Bottom;
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
            label3.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
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
        }

        
    }
}
