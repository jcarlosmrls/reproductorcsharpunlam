using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Opciones : Form
    {        
        private PantallaPrincipal ventana_principal;
        private PanelReproduccion panel;
        private BaseDeDatos baseDatos;
        private bool hubo_cambio = false;

        public Opciones(PantallaPrincipal form, PanelReproduccion pan, ref BaseDeDatos bd)
        {
            InitializeComponent();
            ventana_principal = form;
            panel = pan;
            baseDatos = bd;
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            ventana_principal.Enabled = false;
            panel.Enabled = false;
            foreach (string cad in baseDatos.Leer_Columna("Ruta_De_Archivos", "Path"))
            {
                listBox1.Items.Add(cad);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if(hubo_cambio)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        ventana_principal.CambiarASkinNormal();
                        break;
                    case 1:
                        ventana_principal.CambiarASkinPacman();
                        break;
                    default:
                        break;
                }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hubo_cambio = true;
        }

        private void Opciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana_principal.Enabled = true;
            panel.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            baseDatos.AgregarRutaDeArchivos(ventana_principal.user.Id, folderBrowserDialog1.SelectedPath);

            listBox1.Items.Clear();
            foreach (string cad in baseDatos.Leer_Columna("Ruta_De_Archivos", "Path", "Id_Usuario", ventana_principal.user.Id))
            {
                listBox1.Items.Add(cad);
            }
        }

        //agregado funcion de boton quitar rutas
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string path in listBox1.SelectedItems)
            {
                baseDatos.QuitarRutaDeArchivos(ventana_principal.user.Id, path);
            }
            listBox1.Items.Clear();
            foreach (string cad in baseDatos.Leer_Columna("Ruta_De_Archivos", "Path", "Id_Usuario", ventana_principal.user.Id))
            {
                listBox1.Items.Add(cad);
            }
        }
    }
}
