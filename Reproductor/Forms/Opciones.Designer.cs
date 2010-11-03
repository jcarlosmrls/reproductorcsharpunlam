namespace Reproductor
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.botonColorClaro = new System.Windows.Forms.Button();
            this.gpBoxSkin = new System.Windows.Forms.GroupBox();
            this.botonColorOscuro = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpBoxSkin.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(174, 299);
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
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del skin: ";
            // 
            // comboSkins
            // 
            this.comboSkins.FormattingEnabled = true;
            this.comboSkins.Items.AddRange(new object[] {
            "Normal"});
            this.comboSkins.Location = new System.Drawing.Point(106, 24);
            this.comboSkins.Name = "comboSkins";
            this.comboSkins.Size = new System.Drawing.Size(224, 21);
            this.comboSkins.TabIndex = 3;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(264, 299);
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
            this.label2.Location = new System.Drawing.Point(25, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selección de perfil:";
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Location = new System.Drawing.Point(145, 137);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(167, 21);
            this.comboPerfiles.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Origen de archivos multimedia";
            // 
            // listBoxRutas
            // 
            this.listBoxRutas.FormattingEnabled = true;
            this.listBoxRutas.Location = new System.Drawing.Point(11, 198);
            this.listBoxRutas.Name = "listBoxRutas";
            this.listBoxRutas.Size = new System.Drawing.Size(337, 95);
            this.listBoxRutas.TabIndex = 7;
            // 
            // botonAgregarRuta
            // 
            this.botonAgregarRuta.Location = new System.Drawing.Point(193, 166);
            this.botonAgregarRuta.Name = "botonAgregarRuta";
            this.botonAgregarRuta.Size = new System.Drawing.Size(57, 24);
            this.botonAgregarRuta.TabIndex = 8;
            this.botonAgregarRuta.Text = "Agregar";
            this.botonAgregarRuta.UseVisualStyleBackColor = true;
            this.botonAgregarRuta.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonQuitarRuta
            // 
            this.botonQuitarRuta.Location = new System.Drawing.Point(256, 166);
            this.botonQuitarRuta.Name = "botonQuitarRuta";
            this.botonQuitarRuta.Size = new System.Drawing.Size(57, 24);
            this.botonQuitarRuta.TabIndex = 9;
            this.botonQuitarRuta.Text = "Quitar";
            this.botonQuitarRuta.UseVisualStyleBackColor = true;
            this.botonQuitarRuta.Click += new System.EventHandler(this.button4_Click);
            // 
            // botonColorClaro
            // 
            this.botonColorClaro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonColorClaro.Location = new System.Drawing.Point(157, 77);
            this.botonColorClaro.Name = "botonColorClaro";
            this.botonColorClaro.Size = new System.Drawing.Size(30, 31);
            this.botonColorClaro.TabIndex = 10;
            this.botonColorClaro.UseVisualStyleBackColor = true;
            this.botonColorClaro.Click += new System.EventHandler(this.botonColorClaro_Click);
            // 
            // gpBoxSkin
            // 
            this.gpBoxSkin.Controls.Add(this.comboSkins);
            this.gpBoxSkin.Controls.Add(this.botonColorOscuro);
            this.gpBoxSkin.Controls.Add(this.label6);
            this.gpBoxSkin.Controls.Add(this.botonColorClaro);
            this.gpBoxSkin.Controls.Add(this.label5);
            this.gpBoxSkin.Controls.Add(this.label4);
            this.gpBoxSkin.Controls.Add(this.label1);
            this.gpBoxSkin.Location = new System.Drawing.Point(12, 12);
            this.gpBoxSkin.Name = "gpBoxSkin";
            this.gpBoxSkin.Size = new System.Drawing.Size(336, 119);
            this.gpBoxSkin.TabIndex = 11;
            this.gpBoxSkin.TabStop = false;
            this.gpBoxSkin.Text = "Selección de Skin: ";
            // 
            // botonColorOscuro
            // 
            this.botonColorOscuro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonColorOscuro.Location = new System.Drawing.Point(250, 77);
            this.botonColorOscuro.Name = "botonColorOscuro";
            this.botonColorOscuro.Size = new System.Drawing.Size(30, 31);
            this.botonColorOscuro.TabIndex = 10;
            this.botonColorOscuro.UseVisualStyleBackColor = true;
            this.botonColorOscuro.Click += new System.EventHandler(this.botonColorOscuro_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Color 2 (Oscuro): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Color 1 (Claro): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Combinacion de colores: ";
            // 
            // Opciones
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(360, 333);
            this.Controls.Add(this.gpBoxSkin);
            this.Controls.Add(this.botonQuitarRuta);
            this.Controls.Add(this.botonAgregarRuta);
            this.Controls.Add(this.listBoxRutas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.label2);
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
            this.gpBoxSkin.ResumeLayout(false);
            this.gpBoxSkin.PerformLayout();
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
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button botonColorClaro;
        private System.Windows.Forms.GroupBox gpBoxSkin;
        private System.Windows.Forms.Button botonColorOscuro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}