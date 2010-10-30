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
        private string idInterprete;
        private string nombre;
        private BaseDeDatos db;

        public Modificar_Artista(string id, BaseDeDatos db)
        {
            InitializeComponent();
            this.db = db;
            idInterprete = id;
            this.db.DatosInterprete(id, ref nombre);
            txtNombre.Text = nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != nombre)
            {
                string[] aux = db.Leer_Columna("Interprete", "Id", "Nombre", txtNombre.Text);
                if (aux.Length > 0)
                {
                    MessageBox.Show("el artista ya existe");
                    //se pasan los albunes  a este artista y se borra la antreda acutal.
                }
                else
                {

                    db.ModificarInterprete(idInterprete, txtNombre.Text);// aqui se modifica la base de datos
                    List<Cancion> lista = db.CancionesDeArtista(idInterprete);

                    for (int x = 0; x < lista.Count; x++)
                    {
                        lista[x].Artista = txtNombre.Text;
                        lista[x].Save();
                    }
                    this.Close();
                }

            }
            else
            {
                this.Close();
            }
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
