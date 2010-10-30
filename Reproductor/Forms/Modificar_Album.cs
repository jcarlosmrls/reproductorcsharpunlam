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
                        MessageBox.Show("hay otro album con el mismo nombre");
                        //Se borra el album actual, se pasan las canciones a el album encontrado, y se realizan los cambios pedidos en ese album.
                        //obtener el nuevo id de album.
                        //obtener una nueva lista de canciones
                    }
                }

                db.ModificarAlbum(idAlbum, txtNombre.Text, idInterprete, txtGenero.Text, txtAnio.Text);
                for (int x = 0; x < canciones.Count; x++)
                {
                    canciones[x].Album = txtNombre.Text;
                    canciones[x].Artista = txtInterprete.Text;
                    canciones[x].Año = uint.Parse(txtAnio.Text);
                    canciones[x].Genero = txtGenero.Text;

                    canciones[x].Save();
                }
                this.Close();
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
                picBoxTapa.Image = Image.FromFile(openFileDialog1.FileName);
                foreach (Cancion cn in canciones)
                {
                    cn.Imagen = Image.FromFile(openFileDialog1.FileName);
                }
            }
            //Se guardan los tags aca?
            //Esta bien el foreach anterior??
        }
    }
}
