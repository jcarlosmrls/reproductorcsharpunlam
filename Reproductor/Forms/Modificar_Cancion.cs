using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Reproductor
{
    public partial class Modificar_Cancion : Form
    {
        private BaseDeDatos db;
        private string idCancion;
        private string titulo;
        private string idAlbum;
        private string album;
        private string numero;
        private string path;
        private string idInterprete;

        public Modificar_Cancion(string id, string idint, BaseDeDatos db)
        {
            InitializeComponent();
            this.db = db;
            idCancion = id;
            this.db.DatosCancion(idCancion,ref titulo,ref idAlbum,ref numero,ref path);
            album = this.db.Leer_Columna("Album","Nombre","Id_Album",idAlbum)[0];
            txtAlbum.Text = album;
            txtNumero.Text = numero;
            txtTitulo.Text = titulo;
            idInterprete = idint;
        }

        private void Modificar_Cancion_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitulo.Text != titulo || txtNumero.Text != numero || txtAlbum.Text != album)
                {
                    Cancion cancion = new Cancion(path);
                    if (txtAlbum.Text != album)
                    {
                        string[] aux = db.Leer_Columna("Album", "Id_Album", "Nombre", txtAlbum.Text);
                        if (aux.Length == 0)
                        {
                            MessageBox.Show("El album no existe");
                            cancion.Album = txtAlbum.Text;
                            cancion.Save();
                            idAlbum = db.AgregarAlbum(cancion, idInterprete);
                        }
                        else
                            idAlbum = aux[0];
                    }
                    db.ModificarCancion(idCancion, txtTitulo.Text, idAlbum, txtNumero.Text, path);
                    cancion.Nombre = txtTitulo.Text;
                    cancion.Album = txtAlbum.Text;
                    cancion.NumeroDeCancion = uint.Parse(txtNumero.Text);
                    cancion.Save();
                }
                this.Close();
                //hay q actualizar las canciones en la biblioteca
            }
            catch (Exception)
            {
                MessageBox.Show("Los cambios seran aplicados cuando la cancion deje de estar en reproduccion.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
