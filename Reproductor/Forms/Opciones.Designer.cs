﻿namespace Reproductor
{
    partial class Opciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opciones));
            this.botonAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSkins = new System.Windows.Forms.ComboBox();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboPerfiles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxRutas = new System.Windows.Forms.ListBox();
            this.botonAgregarRuta = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.botonQuitarRuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(174, 254);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(84, 27);
            this.botonAceptar.TabIndex = 0;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selección de skin:";
            // 
            // comboSkins
            // 
            this.comboSkins.FormattingEnabled = true;
            this.comboSkins.Items.AddRange(new object[] {
            "Normal",
            "Pacman"});
            this.comboSkins.Location = new System.Drawing.Point(201, 16);
            this.comboSkins.Name = "comboSkins";
            this.comboSkins.Size = new System.Drawing.Size(112, 21);
            this.comboSkins.TabIndex = 3;
            this.comboSkins.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(264, 254);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(84, 27);
            this.botonCancelar.TabIndex = 1;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selección de perfil:";
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Location = new System.Drawing.Point(201, 57);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(111, 21);
            this.comboPerfiles.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Origen de archivos multimedia";
            // 
            // listBoxRutas
            // 
            this.listBoxRutas.FormattingEnabled = true;
            this.listBoxRutas.Location = new System.Drawing.Point(28, 132);
            this.listBoxRutas.Name = "listBoxRutas";
            this.listBoxRutas.Size = new System.Drawing.Size(284, 82);
            this.listBoxRutas.TabIndex = 7;
            // 
            // botonAgregarRuta
            // 
            this.botonAgregarRuta.Location = new System.Drawing.Point(193, 95);
            this.botonAgregarRuta.Name = "botonAgregarRuta";
            this.botonAgregarRuta.Size = new System.Drawing.Size(57, 24);
            this.botonAgregarRuta.TabIndex = 8;
            this.botonAgregarRuta.Text = "Agregar";
            this.botonAgregarRuta.UseVisualStyleBackColor = true;
            this.botonAgregarRuta.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonQuitarRuta
            // 
            this.botonQuitarRuta.Location = new System.Drawing.Point(256, 95);
            this.botonQuitarRuta.Name = "botonQuitarRuta";
            this.botonQuitarRuta.Size = new System.Drawing.Size(57, 24);
            this.botonQuitarRuta.TabIndex = 9;
            this.botonQuitarRuta.Text = "Quitar";
            this.botonQuitarRuta.UseVisualStyleBackColor = true;
            this.botonQuitarRuta.Click += new System.EventHandler(this.button4_Click);
            // 
            // Opciones
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(360, 293);
            this.Controls.Add(this.botonQuitarRuta);
            this.Controls.Add(this.botonAgregarRuta);
            this.Controls.Add(this.listBoxRutas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboSkins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Opciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Opciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSkins;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPerfiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxRutas;
        private System.Windows.Forms.Button botonAgregarRuta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button botonQuitarRuta;
    }
}