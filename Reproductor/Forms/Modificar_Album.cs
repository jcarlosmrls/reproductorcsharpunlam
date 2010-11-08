using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Modificar_Album : Form
    {
        private BaseDeDatos db;
        private string idAlbum;
        private string nombre;
        private string interprete;
        private string idInterprete;
        private string genero;
        private string anio;
        private string rutaImagen;
        private bool imagenModificada = false;
        private List<Cancion> canciones;

        public Modificar_Album(string id, BaseDeDatos db)
        {
            InitializeComponent();
            this.db = db;
            idAlbum = id;
            db.DatosAlbum(idAlbum, ref nombre, ref idInterprete, ref genero, ref anio);
            txtNombre.Text = nombre;
            interprete = this.db.Leer_Columna("Interprete", "Nombre", "Id", idInterprete)[0];
            txtInterprete.Text = interprete;
            txtGenero.Text = genero;
            txtAnio.Text = anio;
            canciones = this.db.CancionesDeAlbum(idAlbum, idInterprete);
            picBoxTapa.Image = canciones[0].Imagen;
            openFileDialog1.Filter = "Imagenes en formato .jpg|*.jpg";
            openFileDialog1.FileName = "";
        }
        
        private void Modificar_Album_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != nombre || txtInterprete.Text != interprete || txtGenero.Text != genero || txtAnio.Text != anio || imagenModificada)
            {
                if (txtInterprete.Text != interprete)
                {
                    string[] aux = db.Leer_Columna("Interprete", "Id", "Nombre", txtInterprete.Text);
                    if (aux.Length == 0)
                    {
                        idInterprete = db.AgregarInterprete(txtInterprete.Text);
                    }
                    else
                        idInterprete = aux[0];
                }
                if (txtNombre.Text != nombre)
                {
                    string[] albunes = db.Leer_Columna("Album", "Id_Album", "Nombre", txtNombre.Text);
                    if (albunes.Length > 0)
                    {
                        if (MessageBox.Show("Se ha encontrado otro album con el mismo nombre.\n¿Desea combinarlos?", "Album repetido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            db.CombinarAlbunes(idAlbum, albunes[0]);
                            idAlbum = albunes[0];
                            canciones = db.CancionesDeAlbum(idAlbum, idInterprete);
                        }
                        else
                            txtNombre.Text = nombre;
                    }
                }

                // Verifico si se cambio la imagen
                if (imagenModificada)
                {
                    for (int x = 0; x < canciones.Count; x++)
                    {
                        canciones[x].CambiarImagen(openFileDialog1.FileName);
                    }
                }

                db.ModificarAlbum(idAlbum, txtNombre.Text, idInterprete, txtGenero.Text, txtAnio.Text);
                for (int x = 0; x < canciones.Count; x++)
                {
                    canciones[x].Album = txtNombre.Text;
                    canciones[x].Artista = txtInterprete.Text;
                    canciones[x].Año = uint.Parse(txtAnio.Text);
                    canciones[x].Genero = txtGenero.Text;

                    // Guardo los cambios
                    canciones[x].Save();
                }
                this.Close();
                // hay q actualizar los artistas y albunes en la biblioteca
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

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                imagenModificada = true;
                rutaImagen = openFileDialog1.FileName;
                picBoxTapa.Image = Image.FromFile(openFileDialog1.FileName);
            }
            //Se guardan los tags aca?
            //Esta bien el foreach anterior??
        }
    }
}
