using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class IngresarNombreDeLista : Form
    {
        private List<Cancion> lista;
        private string nombreDeLista;

        public IngresarNombreDeLista(ref List<Cancion> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        public string NombreDeLista
        {
            get
            {
                return nombreDeLista;
            }
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                nombreDeLista = txtNombre.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("El nombre de la lista no puede ser vacío!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            nombreDeLista = "";
            this.Close();
        }
    }
}
