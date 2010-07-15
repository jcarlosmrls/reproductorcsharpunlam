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
        private PanelReproduccion panel;
        private bool hubo_cambio = false;

        public Opciones(Form1 form, PanelReproduccion pan)
        {
            InitializeComponent();
            ventana_principal = form;
            panel = pan;
            ventana_principal.Enabled = false;
            panel.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if(hubo_cambio)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        ventana_principal.CambiarASkinNormal();
                        break;
                    case 1:
                        ventana_principal.CambiarASkinPacman();
                        break;
                    default:
                        break;
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
        }

        private void Opciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana_principal.Enabled = true;
            panel.Enabled = true;
        }
    }
}
