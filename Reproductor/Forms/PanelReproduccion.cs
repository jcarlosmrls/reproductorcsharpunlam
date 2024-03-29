﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class PanelReproduccion : Form
    {
        #region Variables

        private PantallaPrincipal ventana_principal;
        private List<Cancion> listaDeReproduccion;
        private BaseDeDatos dBase;
        private bool isOpen;    //Indica si el panel es visible
        private bool isStuck;   //Indica si el panel esta "pegado"

        #endregion

        #region Propiedades

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
            }
        }

        public bool IsStuck
        {
            get
            {
                return isStuck;
            }
            set
            {
                isStuck = value;
            }
        }

        #endregion
        
        public PanelReproduccion()
        {
            InitializeComponent();
            isOpen = true;
            isStuck = true;
        }

        public void Asignar(PantallaPrincipal form, ref BaseDeDatos db, ref List<Cancion> lista)
        {
            ventana_principal = form;
            dBase = db;
            listaDeReproduccion = lista;
        }

        public void CambiarPosicion()
        {
            this.Location = new Point(ventana_principal.Location.X + ventana_principal.Width, ventana_principal.Location.Y);
            this.Show();
        }

        private void PanelReproduccion_LocationChanged(object sender, EventArgs e)
        {
            if ( (this.Location.X >= ventana_principal.Location.X + ventana_principal.Width - 30) &&
                 (this.Location.X <= ventana_principal.Location.X + ventana_principal.Width + 30) &&
                 (this.Location.Y >= ventana_principal.Location.Y - 30) &&
                 (this.Location.Y <= ventana_principal.Location.Y + 30) )
            {
                ventana_principal.CambiarPosicion();
                ventana_principal.PegarPanel();
            }
            else
                ventana_principal.DespegarPanel();
        }

        private void PanelReproduccion_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventana_principal.Close();
        }

        public void CargarLista()
        {
            foreach (Cancion song in listaDeReproduccion)
                listBoxLista.Items.Add(song.Nombre);
        }

        public void LimpiarLista()
        {
            listBoxLista.Items.Clear();
        }

        public void SeleccionarCancion(int num)
        {
            listBoxLista.SetSelected(num, true);
        }

        private void listViewLista_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ventana_principal.ReproducirCancion(listBoxLista.SelectedIndex);
                ventana_principal.ActualizarEtiquetas();
            }
            catch(Exception)
            {
            }
        }

        private void botonNuevaLista_Click(object sender, EventArgs e)
        {
            ventana_principal.DetenerReproduccion();
            listaDeReproduccion.Clear();
            LimpiarLista();
        }

        private void botonBorrarLista_Click(object sender, EventArgs e)
        {
            // Si hay una lista seleccionada
            if (comboBoxListas.SelectedIndex != -1)
            {
                // Pido confirmacion
                if(MessageBox.Show("¿Está seguro que desea borrar la lista seleccionada?", "Borrar Lista", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string lista = comboBoxListas.SelectedItem.ToString();
                    ventana_principal.DetenerReproduccion();
                    dBase.BorrarListaDeReproduccion(lista);
                    comboBoxListas.Items.Remove(lista);
                }
            }
        }

        private void botonGuardarLista_Click(object sender, EventArgs e)
        {
            IngresarNombreDeLista guardar;

            if (listaDeReproduccion.Count != 0)
            {
                guardar  = new IngresarNombreDeLista();
                guardar.ShowDialog();
                if (guardar.NombreDeLista != "")
                {
                    // Obtengo el id del skin
                    string id = dBase.Leer_Columna("Perfil", "Id_Perfil", "Nombre", ventana_principal.UsuarioActual.Configuracion.UltimoPerfilUsado)[0];

                    // Por cada cancion, llamo al metodo para agregar un registro
                    foreach (Cancion song in listaDeReproduccion)
                    {
                        dBase.AgregarListaDeReproduccion(guardar.NombreDeLista, id, song.Ruta);
                    }
                    MessageBox.Show("Se guardó la lista con el nombre " + guardar.NombreDeLista);

                    // Ahora actualizo el combobox
                    CargarComboDeListas(id);
                }
            }
            else
            {
                MessageBox.Show("No hay canciones actualmente en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelReproduccion_Load(object sender, EventArgs e)
        {
            this.CambiarPosicion();
            //Tomar las listas de reproduccion del usuario que se conecta
            //y completar el combobox
        }

        private void listBoxLista_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxLista.SelectedItems.Count == 1)
            {
                ventana_principal.ReproducirCancion(listBoxLista.SelectedIndex);
            }
        }

        public void CargarComboDeListas(string id_perfil)
        {
            comboBoxListas.Items.Clear();
            foreach (string lista in dBase.Leer_Columna("ListaDeReproduccion", "Nombre", "Id_Perfil", id_perfil))
            {
                if(comboBoxListas.FindString(lista) < 0)
                    comboBoxListas.Items.Add(lista);
            }
        }

        private void comboBoxListas_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBoxListas.SelectedIndex != -1) && ("" != comboBoxListas.SelectedItem.ToString()))
            {
                // Detengo la reproduccion
                ventana_principal.DetenerReproduccion();

                // Borro la lista de canciones actuales
                listaDeReproduccion.Clear();

                string id = dBase.Leer_Columna("Perfil", "Id_Perfil", "Nombre", ventana_principal.UsuarioActual.Configuracion.UltimoPerfilUsado)[0];

                // Tomo de la base aquellas canciones de la lista seleccionada
                foreach (string idCancion in dBase.Leer_Columna("ListaDeReproduccion", "Id_Cancion", "Nombre", comboBoxListas.SelectedItem.ToString()))
                {
                    // Una vez obtenidos los ids de las canciones que coinciden con el nombre de la lista indicado
                    // Busco su ruta en la tabla canciones y creo la cancion, agregandola a la listas
                    listaDeReproduccion.Add(new Cancion(dBase.Leer_Columna("Cancion", "Path", "Id_Cancion", idCancion.ToString())[0]));
                    //MessageBox.Show(dBase.Leer_Columna("Cancion", "Path", "Id_Cancion", idCancion.ToString())[0])
                }

                // Muestro la lista de reproduccion
                LimpiarLista();
                CargarLista();

                // Comienzo a reproducir la lista
                ventana_principal.ReproducirCancion(0);
            }
        }

        private void listBoxLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBoxLista.SelectedIndex != -1)
            {
                // Si presiona enter
                if (e.KeyCode == Keys.Return)
                {
                    ventana_principal.ReproducirCancion(listBoxLista.SelectedIndex);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    // Si es la unica que hay
                    if (listBoxLista.Items.Count == 1)
                    {
                        ventana_principal.DetenerReproduccion();
                        ventana_principal.LimpiarEtiquetas();
                    }
                    // Si es la que estoy reproduciendo
                    if (listBoxLista.SelectedIndex == ventana_principal.CancionActual)
                    {
                        // Me fijo si es la ultima
                        if (listBoxLista.SelectedIndex == listaDeReproduccion.Count - 1)
                        {
                            // Reproduzco la primer cancion
                            listaDeReproduccion.RemoveAt(listaDeReproduccion.Count - 1);
                            ventana_principal.ReproducirCancion(0);
                        }
                        else
                        {
                            listaDeReproduccion.RemoveAt(listBoxLista.SelectedIndex);
                            ventana_principal.ReproducirCancion(listBoxLista.SelectedIndex);
                        }
                    }
                    else
                    {
                        listaDeReproduccion.RemoveAt(listBoxLista.SelectedIndex);
                    }
                    LimpiarLista();
                    CargarLista();
                }
            }
        }
    }
}
