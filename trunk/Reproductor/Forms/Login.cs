using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Reproductor
{
    public partial class Login : Form
    {
        private PantallaPrincipal ventanaPrincipal;
        private BaseDeDatos baseDatos;
        private string user;
        private string password;
        
        public Login(PantallaPrincipal vent, ref BaseDeDatos db)
        {
            InitializeComponent();
            UsuarioExistente.Checked = true;
            ventanaPrincipal = vent;
            baseDatos = db;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ventanaPrincipal.Enabled = false;
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            //Si elijo usuario nuevo
            if (UsuarioExistente.Checked)
            {
                user = txtUsuario.Text;
                password = txtPassword.Text;
                //Si entro como invitado, o si el Login es correcto
                if ( ("Invitado" == user) || (baseDatos.ValidarLogin(user, txtPassword.Text)))
                {
                    ventanaPrincipal.CambiarDeUsuario(txtUsuario.Text);
                    ventanaPrincipal.Enabled = true;
                    this.Close();
                }
            }
            else//Si es nuevo usuario
            {
                user  = txtNick.Text;
                password = txtPass1.Text;
                //Si no hubo error al registrar un usuario nuevo
                if (baseDatos.AddUser(txtNick.Text, txtPass1.Text) != -1)
                {
                    ventanaPrincipal.Enabled = true;
                    this.Close();
                }
            }           
        }

        public string GetCurrentUser()
        {
            return user;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true ;
            panel3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Enabled = true;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventanaPrincipal.SetUserLabel(user);
        }


    }
}
