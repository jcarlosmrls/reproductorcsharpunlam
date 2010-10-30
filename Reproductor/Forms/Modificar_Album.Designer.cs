namespace Reproductor
{
    partial class Modificar_Album
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
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtInterprete = new System.Windows.Forms.TextBox();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.botonImagenDeTapa = new System.Windows.Forms.Button();
            this.picBoxTapa = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTapa)).BeginInit();
            this.SuspendLayout();
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(333, 194);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(64, 28);
            this.botonCancelar.TabIndex = 5;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(263, 194);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(64, 28);
            this.botonAceptar.TabIndex = 4;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Intérprete:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Género:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Año:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(103, 37);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(122, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtInterprete
            // 
            this.txtInterprete.Location = new System.Drawing.Point(103, 67);
            this.txtInterprete.Name = "txtInterprete";
            this.txtInterprete.Size = new System.Drawing.Size(122, 20);
            this.txtInterprete.TabIndex = 11;
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(103, 94);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(122, 20);
            this.txtGenero.TabIndex = 12;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(103, 119);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(122, 20);
            this.txtAnio.TabIndex = 13;
            // 
            // botonImagenDeTapa
            // 
            this.botonImagenDeTapa.Location = new System.Drawing.Point(132, 148);
            this.botonImagenDeTapa.Name = "botonImagenDeTapa";
            this.botonImagenDeTapa.Size = new System.Drawing.Size(93, 23);
            this.botonImagenDeTapa.TabIndex = 14;
            this.botonImagenDeTapa.Text = "Imagen de Tapa";
            this.botonImagenDeTapa.UseVisualStyleBackColor = true;
            this.botonImagenDeTapa.Click += new System.EventHandler(this.button3_Click);
            // 
            // picBoxTapa
            // 
            this.picBoxTapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxTapa.Location = new System.Drawing.Point(263, 37);
            this.picBoxTapa.Name = "picBoxTapa";
            this.picBoxTapa.Size = new System.Drawing.Size(157, 134);
            this.picBoxTapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxTapa.TabIndex = 15;
            this.picBoxTapa.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Modificar_Album
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(439, 238);
            this.Controls.Add(this.picBoxTapa);
            this.Controls.Add(this.botonImagenDeTapa);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.txtInterprete);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Modificar_Album";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Album";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Modificar_Album_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtInterprete;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Button botonImagenDeTapa;
        private System.Windows.Forms.PictureBox picBoxTapa;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}