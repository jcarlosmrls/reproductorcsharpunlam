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
            this.Close();
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
