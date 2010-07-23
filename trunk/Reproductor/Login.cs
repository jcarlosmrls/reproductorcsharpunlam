using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Enabled = true;
        }
    }
}
