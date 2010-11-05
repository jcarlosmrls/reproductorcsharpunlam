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
                    if (MessageBox.Show("Se ha encontrado otro artista con el mismo nombre.\n¿Desea combinarlos?", "Artista repetido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        db.CombinarInterpretes(idInterprete, aux[0]);
                        idInterprete = aux[0];
                        this.Close();
                        //hay q modificar los artistas en la blblioteca
                    }
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
                    //hay q modificar los artistas en la blblioteca
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
