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
            //Crear nueva lista
        }

        private void botonBorrarLista_Click(object sender, EventArgs e)
        {
            //Borrar una lista de reproduccion
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
                    //TODO:
                    //Crear un nuevo registro en la tabla ListaDeReproduccion con nombre Guardar.nombreDeLista,
                    //y con el perfil actualmente utilizado. Obtener su id
                    foreach (Cancion song in listaDeReproduccion)
                    {
                        //TODO:
                        //Guardar la cancion en la base de datos con el id de la lista
                    }
                    //TODO:
                    //Actualizar el combobox que contiene las listas
                    MessageBox.Show("Se guardó la lista con el nombre " + guardar.NombreDeLista);
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
    }
}