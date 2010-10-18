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
        private BaseDeDatos dbReproductor;

        public IngresarNombreDeLista(ref List<Cancion> lista, ref BaseDeDatos db)
        {
            InitializeComponent();
            this.lista = lista;
            this.dbReproductor = db;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                //TODO: Agregar el registro de la lista en la tabla Lista de reproduccion
             /*   foreach (Cancion song in lista)
                {
                    dbReproductor.AgregarCancion(song.Album, txtNombre.Text, song.Nombre, 0, song.Duracion, song.Ruta);
                }   */
            }
            else
            {
                MessageBox.Show("El nombre de la lista no puede ser vacío!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
