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
        private bool hubo_cambio_paths = false;
        private List<string> paths;

        public Opciones(PantallaPrincipal form, PanelReproduccion pan, ref BaseDeDatos bd)
        {
            InitializeComponent();
            ventana_principal = form;
            panel = pan;
            baseDatos = bd;
            paths = new List<string>();
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            foreach (string cad in baseDatos.Leer_Columna("Ruta_De_Archivos", "Path", "Id_Usuario", ventana_principal.UsuarioActual.Id))
            {
                paths.Add(new string(cad.ToCharArray()));
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
            if (hubo_cambio_paths)
            {
                baseDatos.ActualizarRutaDeArchivos(ventana_principal.UsuarioActual.Id, paths);
                // aca esta actualizamdo, habria que cambiarlo por un thread.
                baseDatos.ActualizarCanciones(ventana_principal);
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

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            //Si eligio carpeta
            if (folderBrowserDialog1.SelectedPath != "")
            {
                paths.Add(new string(folderBrowserDialog1.SelectedPath.ToCharArray()));

                listBox1.Items.Clear();
                for (int x = 0; x < paths.Count; x++)
                    listBox1.Items.Add(paths[x]);
            }
            hubo_cambio_paths = true;
        }

        //agregado funcion de boton quitar rutas
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string path in listBox1.SelectedItems)
            {
                paths.Remove(path);

            }
            listBox1.Items.Clear();
            for (int x = 0; x < paths.Count; x++)
                listBox1.Items.Add(paths[x]);

            hubo_cambio_paths = true;
        }
    }
}
