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
            this.Show();
        }
    }
}
