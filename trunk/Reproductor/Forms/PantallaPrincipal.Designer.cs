namespace Reproductor
{
    partial class PantallaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoCompactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reproducirPausarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siguienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anteriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.labelContador = new System.Windows.Forms.Label();
            this.botonVolumen = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.botonAnterior = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.botonSiguiente = new System.Windows.Forms.Button();
            this.botonStop = new System.Windows.Forms.Button();
            this.botonPlay = new System.Windows.Forms.Button();
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBoxAño = new System.Windows.Forms.TextBox();
            this.textBoxGenero = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxArtista = new System.Windows.Forms.TextBox();
            this.textBoxCancion = new System.Windows.Forms.TextBox();
            this.labelLetras = new System.Windows.Forms.Label();
            this.labelAño = new System.Windows.Forms.Label();
            this.labelGenero = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelArtista = new System.Windows.Forms.Label();
            this.richTextBoxLetras = new System.Windows.Forms.RichTextBox();
            this.pictureBoxTapaDeAlbum = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.botonModificarCanciones = new System.Windows.Forms.Button();
            this.botonModificarAlbum = new System.Windows.Forms.Button();
            this.botonModificarInterprete = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listViewBuscador = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.comboBoxBuscador = new System.Windows.Forms.ComboBox();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.trackBarReproduccion = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.timerBarra = new System.Windows.Forms.Timer(this.components);
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.labelUsuarioActual = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.tabControlPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTapaDeAlbum)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReproduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem,
            this.accionesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ayudaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(639, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modoCompactoToolStripMenuItem,
            this.modoNormalToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // modoCompactoToolStripMenuItem
            // 
            this.modoCompactoToolStripMenuItem.Name = "modoCompactoToolStripMenuItem";
            this.modoCompactoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modoCompactoToolStripMenuItem.Text = "Modo Compacto";
            this.modoCompactoToolStripMenuItem.Click += new System.EventHandler(this.modoCompactoToolStripMenuItem_Click);
            // 
            // modoNormalToolStripMenuItem
            // 
            this.modoNormalToolStripMenuItem.Name = "modoNormalToolStripMenuItem";
            this.modoNormalToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modoNormalToolStripMenuItem.Text = "Modo Normal";
            this.modoNormalToolStripMenuItem.Click += new System.EventHandler(this.modoNormalToolStripMenuItem_Click);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reproducirPausarToolStripMenuItem,
            this.detenerToolStripMenuItem,
            this.siguienteToolStripMenuItem,
            this.anteriorToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // reproducirPausarToolStripMenuItem
            // 
            this.reproducirPausarToolStripMenuItem.Name = "reproducirPausarToolStripMenuItem";
            this.reproducirPausarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reproducirPausarToolStripMenuItem.Text = "Reproducir/Pausar";
            // 
            // detenerToolStripMenuItem
            // 
            this.detenerToolStripMenuItem.Name = "detenerToolStripMenuItem";
            this.detenerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.detenerToolStripMenuItem.Text = "Detener";
            // 
            // siguienteToolStripMenuItem
            // 
            this.siguienteToolStripMenuItem.Name = "siguienteToolStripMenuItem";
            this.siguienteToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.siguienteToolStripMenuItem.Text = "Siguiente";
            // 
            // anteriorToolStripMenuItem
            // 
            this.anteriorToolStripMenuItem.Name = "anteriorToolStripMenuItem";
            this.anteriorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.anteriorToolStripMenuItem.Text = "Anterior";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(90, 20);
            this.toolStripMenuItem1.Text = "Herramientas";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            this.opcionesToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelBotones.BackColor = System.Drawing.SystemColors.Control;
            this.panelBotones.Controls.Add(this.labelContador);
            this.panelBotones.Controls.Add(this.botonVolumen);
            this.panelBotones.Controls.Add(this.button6);
            this.panelBotones.Controls.Add(this.botonAnterior);
            this.panelBotones.Controls.Add(this.button3);
            this.panelBotones.Controls.Add(this.botonSiguiente);
            this.panelBotones.Controls.Add(this.botonStop);
            this.panelBotones.Controls.Add(this.botonPlay);
            this.panelBotones.Location = new System.Drawing.Point(7, 350);
            this.panelBotones.MaximumSize = new System.Drawing.Size(621, 113);
            this.panelBotones.MinimumSize = new System.Drawing.Size(621, 93);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(621, 101);
            this.panelBotones.TabIndex = 1;
            // 
            // labelContador
            // 
            this.labelContador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContador.AutoSize = true;
            this.labelContador.Location = new System.Drawing.Point(543, 69);
            this.labelContador.Name = "labelContador";
            this.labelContador.Size = new System.Drawing.Size(49, 13);
            this.labelContador.TabIndex = 4;
            this.labelContador.Text = "00:00:00";
            this.labelContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botonVolumen
            // 
            this.botonVolumen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.botonVolumen.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolumen.Location = new System.Drawing.Point(452, 39);
            this.botonVolumen.Name = "botonVolumen";
            this.botonVolumen.Size = new System.Drawing.Size(65, 31);
            this.botonVolumen.TabIndex = 5;
            this.botonVolumen.Text = "♫-=≡";
            this.botonVolumen.UseVisualStyleBackColor = true;
            this.botonVolumen.Click += new System.EventHandler(this.boton_volumen_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(568, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(22, 21);
            this.button6.TabIndex = 8;
            this.button6.Text = "X";
            this.button6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // botonAnterior
            // 
            this.botonAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.botonAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAnterior.Location = new System.Drawing.Point(189, 29);
            this.botonAnterior.Name = "botonAnterior";
            this.botonAnterior.Size = new System.Drawing.Size(74, 52);
            this.botonAnterior.TabIndex = 3;
            this.botonAnterior.Text = "l◄◄";
            this.botonAnterior.UseVisualStyleBackColor = true;
            this.botonAnterior.Click += new System.EventHandler(this.botonAnterior_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(541, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 21);
            this.button3.TabIndex = 4;
            this.button3.Text = "Panel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonSiguiente
            // 
            this.botonSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.botonSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSiguiente.Location = new System.Drawing.Point(347, 29);
            this.botonSiguiente.Name = "botonSiguiente";
            this.botonSiguiente.Size = new System.Drawing.Size(74, 52);
            this.botonSiguiente.TabIndex = 2;
            this.botonSiguiente.Text = "►►l";
            this.botonSiguiente.UseVisualStyleBackColor = true;
            this.botonSiguiente.Click += new System.EventHandler(this.botonSiguiente_Click);
            // 
            // botonStop
            // 
            this.botonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.botonStop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.botonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.botonStop.Location = new System.Drawing.Point(279, 63);
            this.botonStop.Name = "botonStop";
            this.botonStop.Size = new System.Drawing.Size(53, 32);
            this.botonStop.TabIndex = 1;
            this.botonStop.Text = "■";
            this.botonStop.UseVisualStyleBackColor = true;
            this.botonStop.Click += new System.EventHandler(this.botonStop_Click);
            // 
            // botonPlay
            // 
            this.botonPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.botonPlay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.botonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPlay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.botonPlay.Location = new System.Drawing.Point(269, 8);
            this.botonPlay.Name = "botonPlay";
            this.botonPlay.Size = new System.Drawing.Size(72, 49);
            this.botonPlay.TabIndex = 0;
            this.botonPlay.Text = "►";
            this.botonPlay.UseVisualStyleBackColor = true;
            this.botonPlay.Click += new System.EventHandler(this.botonPlay_Click);
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPrincipal.Controls.Add(this.tabPage1);
            this.tabControlPrincipal.Controls.Add(this.tabPage2);
            this.tabControlPrincipal.Controls.Add(this.tabPage3);
            this.tabControlPrincipal.Location = new System.Drawing.Point(12, 31);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(620, 275);
            this.tabControlPrincipal.TabIndex = 2;
            this.tabControlPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabControlPrincipal_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.richTextBoxLetras);
            this.tabPage1.Controls.Add(this.pictureBoxTapaDeAlbum);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reproducción Actual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBoxAño);
            this.panel1.Controls.Add(this.textBoxGenero);
            this.panel1.Controls.Add(this.textBoxAlbum);
            this.panel1.Controls.Add(this.textBoxArtista);
            this.panel1.Controls.Add(this.textBoxCancion);
            this.panel1.Controls.Add(this.labelLetras);
            this.panel1.Controls.Add(this.labelAño);
            this.panel1.Controls.Add(this.labelGenero);
            this.panel1.Controls.Add(this.labelAlbum);
            this.panel1.Controls.Add(this.labelArtista);
            this.panel1.Location = new System.Drawing.Point(260, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 157);
            this.panel1.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(78, 126);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 27);
            this.button5.TabIndex = 14;
            this.button5.Text = "Obtener!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBoxAño
            // 
            this.textBoxAño.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxAño.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAño.Location = new System.Drawing.Point(89, 107);
            this.textBoxAño.Name = "textBoxAño";
            this.textBoxAño.ReadOnly = true;
            this.textBoxAño.Size = new System.Drawing.Size(253, 19);
            this.textBoxAño.TabIndex = 13;
            // 
            // textBoxGenero
            // 
            this.textBoxGenero.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxGenero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGenero.Location = new System.Drawing.Point(89, 84);
            this.textBoxGenero.Name = "textBoxGenero";
            this.textBoxGenero.ReadOnly = true;
            this.textBoxGenero.Size = new System.Drawing.Size(253, 19);
            this.textBoxGenero.TabIndex = 12;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxAlbum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAlbum.Location = new System.Drawing.Point(89, 60);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.ReadOnly = true;
            this.textBoxAlbum.Size = new System.Drawing.Size(253, 19);
            this.textBoxAlbum.TabIndex = 11;
            // 
            // textBoxArtista
            // 
            this.textBoxArtista.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxArtista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxArtista.Location = new System.Drawing.Point(89, 36);
            this.textBoxArtista.Name = "textBoxArtista";
            this.textBoxArtista.ReadOnly = true;
            this.textBoxArtista.Size = new System.Drawing.Size(253, 19);
            this.textBoxArtista.TabIndex = 10;
            // 
            // textBoxCancion
            // 
            this.textBoxCancion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxCancion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCancion.Location = new System.Drawing.Point(4, 4);
            this.textBoxCancion.Name = "textBoxCancion";
            this.textBoxCancion.ReadOnly = true;
            this.textBoxCancion.Size = new System.Drawing.Size(338, 19);
            this.textBoxCancion.TabIndex = 9;
            this.textBoxCancion.Text = "     ";
            this.textBoxCancion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLetras
            // 
            this.labelLetras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLetras.AutoSize = true;
            this.labelLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLetras.Location = new System.Drawing.Point(4, 132);
            this.labelLetras.Name = "labelLetras";
            this.labelLetras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelLetras.Size = new System.Drawing.Size(48, 16);
            this.labelLetras.TabIndex = 8;
            this.labelLetras.Text = "Letras:";
            // 
            // labelAño
            // 
            this.labelAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAño.AutoSize = true;
            this.labelAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAño.Location = new System.Drawing.Point(4, 108);
            this.labelAño.Name = "labelAño";
            this.labelAño.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelAño.Size = new System.Drawing.Size(38, 16);
            this.labelAño.TabIndex = 6;
            this.labelAño.Text = "Año: ";
            // 
            // labelGenero
            // 
            this.labelGenero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGenero.AutoSize = true;
            this.labelGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenero.Location = new System.Drawing.Point(4, 83);
            this.labelGenero.Name = "labelGenero";
            this.labelGenero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelGenero.Size = new System.Drawing.Size(59, 16);
            this.labelGenero.TabIndex = 5;
            this.labelGenero.Text = "Genero: ";
            // 
            // labelAlbum
            // 
            this.labelAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlbum.Location = new System.Drawing.Point(4, 60);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelAlbum.Size = new System.Drawing.Size(52, 16);
            this.labelAlbum.TabIndex = 4;
            this.labelAlbum.Text = "Album: ";
            // 
            // labelArtista
            // 
            this.labelArtista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArtista.AutoSize = true;
            this.labelArtista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArtista.Location = new System.Drawing.Point(4, 37);
            this.labelArtista.Name = "labelArtista";
            this.labelArtista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelArtista.Size = new System.Drawing.Size(51, 16);
            this.labelArtista.TabIndex = 3;
            this.labelArtista.Text = "Artista: ";
            // 
            // richTextBoxLetras
            // 
            this.richTextBoxLetras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLetras.DetectUrls = false;
            this.richTextBoxLetras.Location = new System.Drawing.Point(260, 170);
            this.richTextBoxLetras.Name = "richTextBoxLetras";
            this.richTextBoxLetras.ReadOnly = true;
            this.richTextBoxLetras.Size = new System.Drawing.Size(346, 73);
            this.richTextBoxLetras.TabIndex = 7;
            this.richTextBoxLetras.Text = "";
            // 
            // pictureBoxTapaDeAlbum
            // 
            this.pictureBoxTapaDeAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTapaDeAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxTapaDeAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTapaDeAlbum.Image = global::Reproductor.Properties.Resources.SinTapa;
            this.pictureBoxTapaDeAlbum.InitialImage = null;
            this.pictureBoxTapaDeAlbum.Location = new System.Drawing.Point(6, 3);
            this.pictureBoxTapaDeAlbum.Name = "pictureBoxTapaDeAlbum";
            this.pictureBoxTapaDeAlbum.Size = new System.Drawing.Size(230, 244);
            this.pictureBoxTapaDeAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTapaDeAlbum.TabIndex = 0;
            this.pictureBoxTapaDeAlbum.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.botonModificarCanciones);
            this.tabPage2.Controls.Add(this.botonModificarAlbum);
            this.tabPage2.Controls.Add(this.botonModificarInterprete);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Biblioteca";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // botonModificarCanciones
            // 
            this.botonModificarCanciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonModificarCanciones.Location = new System.Drawing.Point(532, 6);
            this.botonModificarCanciones.Name = "botonModificarCanciones";
            this.botonModificarCanciones.Size = new System.Drawing.Size(66, 26);
            this.botonModificarCanciones.TabIndex = 9;
            this.botonModificarCanciones.Text = "Modificar";
            this.botonModificarCanciones.UseVisualStyleBackColor = true;
            this.botonModificarCanciones.Click += new System.EventHandler(this.button4_Click);
            // 
            // botonModificarAlbum
            // 
            this.botonModificarAlbum.Location = new System.Drawing.Point(322, 9);
            this.botonModificarAlbum.Name = "botonModificarAlbum";
            this.botonModificarAlbum.Size = new System.Drawing.Size(66, 26);
            this.botonModificarAlbum.TabIndex = 8;
            this.botonModificarAlbum.Text = "Modificar";
            this.botonModificarAlbum.UseVisualStyleBackColor = true;
            this.botonModificarAlbum.Click += new System.EventHandler(this.button2_Click);
            // 
            // botonModificarInterprete
            // 
            this.botonModificarInterprete.Location = new System.Drawing.Point(114, 9);
            this.botonModificarInterprete.Name = "botonModificarInterprete";
            this.botonModificarInterprete.Size = new System.Drawing.Size(66, 26);
            this.botonModificarInterprete.TabIndex = 7;
            this.botonModificarInterprete.Text = "Modificar";
            this.botonModificarInterprete.UseVisualStyleBackColor = true;
            this.botonModificarInterprete.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(415, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(191, 199);
            this.listBox2.TabIndex = 6;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(412, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Canciones";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Álbum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Intérprete";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(212, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(186, 198);
            this.listView1.TabIndex = 1;
            this.listView1.TileSize = new System.Drawing.Size(160, 80);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(191, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listViewBuscador);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(612, 249);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Buscador";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewBuscador
            // 
            this.listViewBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBuscador.Location = new System.Drawing.Point(182, 11);
            this.listViewBuscador.Name = "listViewBuscador";
            this.listViewBuscador.Size = new System.Drawing.Size(419, 222);
            this.listViewBuscador.TabIndex = 1;
            this.listViewBuscador.UseCompatibleStateImageBehavior = false;
            this.listViewBuscador.View = System.Windows.Forms.View.List;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.botonBuscar);
            this.panel3.Controls.Add(this.comboBoxBuscador);
            this.panel3.Controls.Add(this.txtBuscador);
            this.panel3.Location = new System.Drawing.Point(8, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 225);
            this.panel3.TabIndex = 0;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(9, 89);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(87, 26);
            this.botonBuscar.TabIndex = 2;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // comboBoxBuscador
            // 
            this.comboBoxBuscador.FormattingEnabled = true;
            this.comboBoxBuscador.Items.AddRange(new object[] {
            "Intérprete",
            "Álbum",
            "Canción",
            "Género"});
            this.comboBoxBuscador.Location = new System.Drawing.Point(9, 51);
            this.comboBoxBuscador.Name = "comboBoxBuscador";
            this.comboBoxBuscador.Size = new System.Drawing.Size(114, 21);
            this.comboBoxBuscador.TabIndex = 1;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(9, 25);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(141, 20);
            this.txtBuscador.TabIndex = 0;
            // 
            // trackBarReproduccion
            // 
            this.trackBarReproduccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarReproduccion.Location = new System.Drawing.Point(12, 310);
            this.trackBarReproduccion.Maximum = 100;
            this.trackBarReproduccion.Name = "trackBarReproduccion";
            this.trackBarReproduccion.Size = new System.Drawing.Size(615, 45);
            this.trackBarReproduccion.TabIndex = 3;
            this.trackBarReproduccion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarReproduccion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarReproduccion_MouseUp);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar2.Location = new System.Drawing.Point(469, 216);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 178);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Visible = false;
            this.trackBar2.MouseLeave += new System.EventHandler(this.trackBar2_Leave);
            // 
            // timerBarra
            // 
            this.timerBarra.Interval = 500;
            this.timerBarra.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.FileName = "openFileDialog1";
            this.abrirArchivo.FileOk += new System.ComponentModel.CancelEventHandler(this.abrirArchivo_FileOk);
            // 
            // labelUsuarioActual
            // 
            this.labelUsuarioActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsuarioActual.AutoSize = true;
            this.labelUsuarioActual.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelUsuarioActual.Location = new System.Drawing.Point(583, 6);
            this.labelUsuarioActual.Name = "labelUsuarioActual";
            this.labelUsuarioActual.Size = new System.Drawing.Size(34, 13);
            this.labelUsuarioActual.TabIndex = 8;
            this.labelUsuarioActual.Text = "         ";
            this.labelUsuarioActual.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(639, 463);
            this.Controls.Add(this.labelUsuarioActual);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.tabControlPrincipal);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.trackBarReproduccion);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(655, 481);
            this.Name = "PantallaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproductor                   ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTapaDeAlbum)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReproduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button botonPlay;
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxTapaDeAlbum;
        private System.Windows.Forms.TrackBar trackBarReproduccion;
        private System.Windows.Forms.Button botonStop;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button botonSiguiente;
        private System.Windows.Forms.Label labelContador;
        private System.Windows.Forms.Button botonAnterior;
        private System.Windows.Forms.Label labelAño;
        private System.Windows.Forms.Label labelGenero;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelArtista;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.Button botonVolumen;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Timer timerBarra;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reproducirPausarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siguienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anteriorToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.ComboBox comboBoxBuscador;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoCompactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoNormalToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxLetras;
        private System.Windows.Forms.Label labelLetras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button botonModificarInterprete;
        private System.Windows.Forms.Button botonModificarCanciones;
        private System.Windows.Forms.Button botonModificarAlbum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCancion;
        private System.Windows.Forms.TextBox textBoxAño;
        private System.Windows.Forms.TextBox textBoxGenero;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxArtista;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Label labelUsuarioActual;
        private System.Windows.Forms.ListView listViewBuscador;
    }
}

