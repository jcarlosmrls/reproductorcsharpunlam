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
            //Si elijo loguearme
            if (UsuarioExistente.Checked)
            {
                ventanaPrincipal.user.IsNewUser = false;
                ventanaPrincipal.user.Id = txtUsuario.Text;
                ventanaPrincipal.user.Password = txtPassword.Text;
                //Si entro como invitado, o si el Login es correcto
                if ( ("Invitado" == ventanaPrincipal.user.Id) || (baseDatos.ValidarLogin(ventanaPrincipal.user.Id, txtPassword.Text)))
                {
                    ventanaPrincipal.Enabled = true;
                    ventanaPrincipal.SetUserLabel(ventanaPrincipal.user.Id);
                    this.Close();
                }
            }
            else//Si es nuevo usuario
            {
                ventanaPrincipal.user.IsNewUser = true;
                ventanaPrincipal.user.Id = txtNick.Text;
                ventanaPrincipal.user.Password = txtPass1.Text;

                if ((txtPass1.Text == "") || (txtPass2.Text == "") ||      //Si algun campo de contraseña esta vacio
                   (txtPass1.Text != txtPass2.Text))                      //O si son distintas las contraseñas ingresadas
                {
                    MessageBox.Show("Los campos de contraseña no coinciden, o bien no pueden estar en blanco");
                }
                else
                {
                    //Si no hubo error al registrar un usuario nuevo
                    if (baseDatos.AddUser(txtNick.Text, txtPass1.Text) != -1)
                    {
                        ventanaPrincipal.Enabled = true;
                        ventanaPrincipal.SetUserLabel(ventanaPrincipal.user.Id);
                        this.Close();
                    }
                }
            }           
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
    }
}
