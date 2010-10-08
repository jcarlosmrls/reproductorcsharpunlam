using System;
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
        private bool isOpen;    //Indica si el panel es visible
        private bool isStuck;   //Indica si el panel esta "pegado"
        private List<Cancion> listaDeReproduccion;

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
            listaDeReproduccion = new List<Cancion>();
        }

        public void Asignar(PantallaPrincipal form)
        {
            ventana_principal = form;
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

        public void AgregarCancion(Cancion song)
        {
            listaDeReproduccion.Add(song);
            listViewLista.Items.Add(new ListViewItem(song.Nombre));           
        }

        public void LimpiarLista()
        {
            listaDeReproduccion.Clear();
            listViewLista.Clear();
        }

        public void SeleccionarCancion(int num)
        {
            listViewLista.Items[num].Focused = true;
        }

        private void listViewLista_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ventana_principal.ReproducirCancion(listViewLista.SelectedIndices[0]);
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
            //Guardar la lista actual, preguntar por un nombre
        }

        private void PanelReproduccion_Load(object sender, EventArgs e)
        {
            //Tomar las listas de reproduccion del usuario que se conecta
            //y completar el combobox
        }
    }
}
