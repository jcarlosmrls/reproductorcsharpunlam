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
            //Cargo las rutas del usuario
            foreach (string cad in baseDatos.Leer_Columna("Ruta_De_Archivos", "Path", "Id_Usuario", ventana_principal.UsuarioActual.Id))
            {
                paths.Add(new string(cad.ToCharArray()));
                listBoxRutas.Items.Add(cad);
            }

            //Cargo los skins del usuario
            foreach (string skin in ventana_principal.UsuarioActual.Configuracion.Skins)
            {
                comboSkins.Items.Add(skin);
            }

            //Cargo los perfiles del usuario
            comboPerfiles.Items.Clear();
            foreach (string perfil in ventana_principal.UsuarioActual.Configuracion.Perfiles)
            {
                comboPerfiles.Items.Add(perfil);
            }

            //Selecciono las ultimas opciones utilizadas en los combobox
            comboPerfiles.SelectedIndex =  comboPerfiles.Items.IndexOf(ventana_principal.UsuarioActual.Configuracion.UltimoPerfilUsado);
            comboSkins.SelectedIndex = comboSkins.Items.IndexOf(ventana_principal.UsuarioActual.Configuracion.UltimoSkinUsado);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Si se eligio un skin distinto al ultimo utilizado
            if (comboSkins.SelectedItem.ToString() != ventana_principal.UsuarioActual.Configuracion.UltimoSkinUsado)
            {
                //Como cambio el skin, guardo el cambio
                ventana_principal.UsuarioActual.Configuracion.UltimoSkinUsado = comboSkins.SelectedItem.ToString();

                if(comboSkins.SelectedItem.ToString() == "Normal")
                {
                    ventana_principal.CambiarASkinNormal();
                }
                else
                {
                    ventana_principal.CambiarASkin(comboSkins.SelectedItem.ToString());
                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            //Si eligio carpeta
            if (folderBrowserDialog1.SelectedPath != "")
            {
                paths.Add(new string(folderBrowserDialog1.SelectedPath.ToCharArray()));

                listBoxRutas.Items.Clear();
                for (int x = 0; x < paths.Count; x++)
                    listBoxRutas.Items.Add(paths[x]);
            }
            hubo_cambio_paths = true;
        }

        //agregado funcion de boton quitar rutas
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string path in listBoxRutas.SelectedItems)
            {
                paths.Remove(path);

            }
            listBoxRutas.Items.Clear();
            for (int x = 0; x < paths.Count; x++)
                listBoxRutas.Items.Add(paths[x]);

            hubo_cambio_paths = true;
        }
    }
}
