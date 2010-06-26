using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Opciones : Form
    {        
        private Form1 ventana_principal;
        private Color color_actual;
        private Color color_nuevo;
        private bool hubo_cambio = false;

        public Opciones(Form1 form)
        {
            InitializeComponent();
            ventana_principal = form;
            color_actual = ventana_principal.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if(color_nuevo != color_actual && hubo_cambio)
                foreach (Control ctl in ventana_principal.Controls)
                {
                    ctl.BackColor = color_nuevo;
                    ventana_principal.BackColor = color_nuevo;
                }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hubo_cambio = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    color_nuevo = Color.FromName("Control");
                    break;
                case 1:
                    ventana_principal.CambiarASkinPacman();
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            ventana_principal.Cambiar_color_tabs(colorDialog2.Color);
        }
    }
}
