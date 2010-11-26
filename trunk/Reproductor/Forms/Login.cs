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

        private Usuario usuarioActual;
        private DialogResult estado;

        #endregion

        #region Propiedades

        public Usuario UsuarioActual
        {
            get
            {
                return usuarioActual;
            }
        }

        public DialogResult Estado
        {
            get
            {
                return estado;
            }
        }

        #endregion

        #region Metodos

        public Login()
        {
            InitializeComponent();
            UsuarioExistente.Checked = true;
            usuarioActual = new Usuario();
        }

        private void botonLogin_Click(object sender, EventArgs e)
        {
            estado = DialogResult.OK;

            //Si elijo loguearme
            if (UsuarioExistente.Checked)
            {
                usuarioActual.IsNewUser = false;
                usuarioActual.Id = txtUsuario.Text;
                usuarioActual.Password = txtPassword.Text;
                this.Close();
            }
            //Si es nuevo usuario
            else if(UsuarioNuevo.Checked)
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
                    this.Close();
                }
            }           
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            estado = DialogResult.Cancel;
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
    }
}
