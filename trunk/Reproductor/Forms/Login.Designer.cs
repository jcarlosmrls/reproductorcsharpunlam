namespace Reproductor
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.botonLogin = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.UsuarioNuevo = new System.Windows.Forms.RadioButton();
            this.UsuarioExistente = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonLogin
            // 
            this.botonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonLogin.Location = new System.Drawing.Point(153, 226);
            this.botonLogin.Name = "botonLogin";
            this.botonLogin.Size = new System.Drawing.Size(76, 28);
            this.botonLogin.TabIndex = 0;
            this.botonLogin.Text = "Login";
            this.botonLogin.UseVisualStyleBackColor = true;
            this.botonLogin.Click += new System.EventHandler(this.botonLogin_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(235, 226);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(76, 28);
            this.botonCancelar.TabIndex = 1;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.UsuarioNuevo);
            this.panel1.Controls.Add(this.UsuarioExistente);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 208);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPass2);
            this.panel3.Controls.Add(this.txtPass1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtNick);
            this.panel3.Location = new System.Drawing.Point(20, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 80);
            this.panel3.TabIndex = 15;
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(111, 55);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(154, 20);
            this.txtPass2.TabIndex = 13;
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(111, 30);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(154, 20);
            this.txtPass1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password Elegido: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reingrese Password: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nick:";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(111, 5);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(154, 20);
            this.txtNick.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUsuario);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.labelPass);
            this.panel2.Controls.Add(this.labelUsuario);
            this.panel2.Location = new System.Drawing.Point(20, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 63);
            this.panel2.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(71, 10);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(194, 20);
            this.txtUsuario.TabIndex = 16;
            this.txtUsuario.Text = "Invitado";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 15;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(6, 39);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(59, 13);
            this.labelPass.TabIndex = 6;
            this.labelPass.Text = "Password: ";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(6, 13);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(49, 13);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Usuario: ";
            // 
            // UsuarioNuevo
            // 
            this.UsuarioNuevo.AutoSize = true;
            this.UsuarioNuevo.Location = new System.Drawing.Point(3, 97);
            this.UsuarioNuevo.Name = "UsuarioNuevo";
            this.UsuarioNuevo.Size = new System.Drawing.Size(96, 17);
            this.UsuarioNuevo.TabIndex = 4;
            this.UsuarioNuevo.TabStop = true;
            this.UsuarioNuevo.Text = "Usuario Nuevo";
            this.UsuarioNuevo.UseVisualStyleBackColor = true;
            this.UsuarioNuevo.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // UsuarioExistente
            // 
            this.UsuarioExistente.AutoSize = true;
            this.UsuarioExistente.Location = new System.Drawing.Point(3, 3);
            this.UsuarioExistente.Name = "UsuarioExistente";
            this.UsuarioExistente.Size = new System.Drawing.Size(107, 17);
            this.UsuarioExistente.TabIndex = 3;
            this.UsuarioExistente.TabStop = true;
            this.UsuarioExistente.Text = "Usuario Existente";
            this.UsuarioExistente.UseVisualStyleBackColor = true;
            this.UsuarioExistente.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.botonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(324, 266);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonLogin;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton UsuarioExistente;
        private System.Windows.Forms.RadioButton UsuarioNuevo;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}