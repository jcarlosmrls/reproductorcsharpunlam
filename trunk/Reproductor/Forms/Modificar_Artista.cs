using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Modificar_Artista : Form
    {        
        public Modificar_Artista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Modificar_Artista_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
