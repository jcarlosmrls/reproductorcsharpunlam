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
        private Form1 ventana_principal;

        public PanelReproduccion()
        {
            InitializeComponent();
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
            if (this.Location.X >= ventana_principal.Location.X + ventana_principal.Width - 30 && this.Location.X <= ventana_principal.Location.X + ventana_principal.Width + 30)
            {
                ventana_principal.CambiarPosicion();
                ventana_principal.PegarPanel();
            }
            else
                ventana_principal.DespegarPanel();
        }
    }
}