namespace Reproductor
{
    partial class PanelReproduccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelReproduccion));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonGuardarLista = new System.Windows.Forms.Button();
            this.botonBorrarLista = new System.Windows.Forms.Button();
            this.botonNuevaLista = new System.Windows.Forms.Button();
            this.listBoxLista = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(54, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista:";
            // 
            // botonGuardarLista
            // 
            this.botonGuardarLista.BackgroundImage = global::Reproductor.Properties.Resources.guardar;
            this.botonGuardarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonGuardarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardarLista.Location = new System.Drawing.Point(88, 10);
            this.botonGuardarLista.Name = "botonGuardarLista";
            this.botonGuardarLista.Size = new System.Drawing.Size(27, 27);
            this.botonGuardarLista.TabIndex = 5;
            this.botonGuardarLista.UseVisualStyleBackColor = true;
            this.botonGuardarLista.Click += new System.EventHandler(this.botonGuardarLista_Click);
            // 
            // botonBorrarLista
            // 
            this.botonBorrarLista.BackgroundImage = global::Reproductor.Properties.Resources.borrar;
            this.botonBorrarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonBorrarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBorrarLista.Location = new System.Drawing.Point(54, 10);
            this.botonBorrarLista.Name = "botonBorrarLista";
            this.botonBorrarLista.Size = new System.Drawing.Size(27, 27);
            this.botonBorrarLista.TabIndex = 4;
            this.botonBorrarLista.UseVisualStyleBackColor = true;
            this.botonBorrarLista.Click += new System.EventHandler(this.botonBorrarLista_Click);
            // 
            // botonNuevaLista
            // 
            this.botonNuevaLista.BackgroundImage = global::Reproductor.Properties.Resources.añadir;
            this.botonNuevaLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonNuevaLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonNuevaLista.Location = new System.Drawing.Point(21, 10);
            this.botonNuevaLista.Name = "botonNuevaLista";
            this.botonNuevaLista.Size = new System.Drawing.Size(27, 27);
            this.botonNuevaLista.TabIndex = 3;
            this.botonNuevaLista.UseVisualStyleBackColor = true;
            this.botonNuevaLista.Click += new System.EventHandler(this.botonNuevaLista_Click);
            // 
            // listBoxLista
            // 
            this.listBoxLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLista.FormattingEnabled = true;
            this.listBoxLista.Location = new System.Drawing.Point(12, 77);
            this.listBoxLista.Name = "listBoxLista";
            this.listBoxLista.Size = new System.Drawing.Size(214, 355);
            this.listBoxLista.TabIndex = 6;
            this.listBoxLista.DoubleClick += new System.EventHandler(this.listBoxLista_DoubleClick);
            // 
            // PanelReproduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 449);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxLista);
            this.Controls.Add(this.botonGuardarLista);
            this.Controls.Add(this.botonBorrarLista);
            this.Controls.Add(this.botonNuevaLista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PanelReproduccion";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lista de Reproducción";
            this.Load += new System.EventHandler(this.PanelReproduccion_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PanelReproduccion_FormClosed);
            this.LocationChanged += new System.EventHandler(this.PanelReproduccion_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonNuevaLista;
        private System.Windows.Forms.Button botonBorrarLista;
        private System.Windows.Forms.Button botonGuardarLista;
        private System.Windows.Forms.ListBox listBoxLista;

    }
}