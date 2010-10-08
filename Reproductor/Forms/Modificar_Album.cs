using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Modificar_Album : Form
    {
        private PantallaPrincipal ventana_principal;
        private PanelReproduccion panel;
        
        public Modificar_Album(PantallaPrincipal form, PanelReproduccion pan)
        {
            ventana_principal = form;
            panel = pan;
            InitializeComponent();
            ventana_principal.Enabled = false;
            panel.Enabled = false;
        }

        

        private void Modificar_Album_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana_principal.Enabled = true;
            panel.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
