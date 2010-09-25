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

        private Form1 ventana_principal;
        private bool isOpen;
        private bool isStuck;
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

        public void Asignar(Form1 form)
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
    }
}
