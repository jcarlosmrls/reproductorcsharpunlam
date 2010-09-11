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
        Form1 ventanaPrincipal;

        public Login(Form1 vent)
        {
            InitializeComponent();
            radioButton1.Checked = true;
            ventanaPrincipal = vent;
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            ventanaPrincipal.Enabled = true;
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

        private void Login_Load(object sender, EventArgs e)
        {
            ventanaPrincipal.Enabled = false;
        }
    }
}
