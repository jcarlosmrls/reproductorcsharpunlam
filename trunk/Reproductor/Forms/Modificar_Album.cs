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
        }
        
        private void Modificar_Album_FormClosed(object sender, FormClosedEventArgs e)
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
