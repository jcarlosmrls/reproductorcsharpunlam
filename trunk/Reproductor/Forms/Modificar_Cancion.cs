using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        public Modificar_Cancion(string id, BaseDeDatos db)
        {
            InitializeComponent();
            this.db = db;
            idCancion = id;
            this.db.DatosCancion(idCancion,ref titulo,ref idAlbum,ref numero,ref path);
            album = this.db.Leer_Columna("Album","Nombre","Id_Album",idAlbum)[0];
            txtAlbum.Text = album;
            txtNumero.Text = numero;
            txtTitulo.Text = titulo;
            txtUbicacion.Text = path;
        }


        private void Modificar_Cancion_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
