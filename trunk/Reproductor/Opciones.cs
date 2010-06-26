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
        private Color color_nuevo;
        private bool hubo_cambio = false;

        public Opciones(Form1 form)
        {
            InitializeComponent();
            ventana_principal = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if(hubo_cambio)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        //Poner Skin Default;
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

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            ventana_principal.Cambiar_color_tabs(colorDialog2.Color);
        }
    }
}
