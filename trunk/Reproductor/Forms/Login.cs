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
        #region Variables

        private BaseDeDatos baseDatos;
        private Usuario usuarioActual;

        #endregion

        #region Metodos

        public Login(ref BaseDeDatos db)
        {
            InitializeComponent();
            UsuarioExistente.Checked = true;
            baseDatos = db;
            usuarioActual = new Usuario();
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            //Si elijo loguearme
            if (UsuarioExistente.Checked)
            {
                usuarioActual.IsNewUser = false;
                usuarioActual.Id = txtUsuario.Text;
                usuarioActual.Password = txtPassword.Text;

                //Si entro como invitado, o si el Login es correcto
                if ( ("Invitado" == usuarioActual.Id) || (baseDatos.ValidarLogin(usuarioActual.Id, usuarioActual.Password)))
                {
                    this.Close();
                }
            }
            else//Si es nuevo usuario
            {
                usuarioActual.IsNewUser = true;
                usuarioActual.Id = txtNick.Text;
                usuarioActual.Password = txtPass1.Text;

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

        #endregion

        #region Propiedades

        public Usuario UsuarioActual
        {
            get
            {
                return usuarioActual;
            }
        }
        #endregion
    }
}
