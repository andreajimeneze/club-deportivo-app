namespace ClubDeportivoApp.Forms
{
    partial class RegistroClientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroClientesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbSocio = new System.Windows.Forms.RadioButton();
            this.rbNoSocio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAptoFisico = new System.Windows.Forms.CheckBox();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(213, 277);
            this.txtNombre.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtNombre.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(400, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(219, 350);
            this.txtApellido.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtApellido.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(400, 22);
            this.txtApellido.TabIndex = 4;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(219, 424);
            this.txtDni.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtDni.MaxLength = 10;
            this.txtDni.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(400, 22);
            this.txtDni.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.Location = new System.Drawing.Point(477, 581);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(241, 75);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Location = new System.Drawing.Point(1017, 713);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 58);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "<- VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(766, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seleccione calidad de inscripto";
            // 
            // rbSocio
            // 
            this.rbSocio.AutoSize = true;
            this.rbSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSocio.Location = new System.Drawing.Point(769, 306);
            this.rbSocio.Name = "rbSocio";
            this.rbSocio.Size = new System.Drawing.Size(79, 28);
            this.rbSocio.TabIndex = 10;
            this.rbSocio.TabStop = true;
            this.rbSocio.Text = "Socio";
            this.rbSocio.UseVisualStyleBackColor = true;
            // 
            // rbNoSocio
            // 
            this.rbNoSocio.AutoSize = true;
            this.rbNoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoSocio.Location = new System.Drawing.Point(769, 345);
            this.rbNoSocio.Name = "rbNoSocio";
            this.rbNoSocio.Size = new System.Drawing.Size(109, 28);
            this.rbNoSocio.TabIndex = 11;
            this.rbNoSocio.TabStop = true;
            this.rbNoSocio.Text = "No Socio";
            this.rbNoSocio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Presenta apto físico?";
            // 
            // cbAptoFisico
            // 
            this.cbAptoFisico.AutoSize = true;
            this.cbAptoFisico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAptoFisico.Location = new System.Drawing.Point(769, 456);
            this.cbAptoFisico.Name = "cbAptoFisico";
            this.cbAptoFisico.Size = new System.Drawing.Size(48, 28);
            this.cbAptoFisico.TabIndex = 13;
            this.cbAptoFisico.Text = "SÍ";
            this.cbAptoFisico.UseVisualStyleBackColor = true;
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(55, 732);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(116, 20);
            this.lblFechaHoy.TabIndex = 14;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(384, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(451, 39);
            this.label6.TabIndex = 15;
            this.label6.Text = "REGISTRO DE CLIENTES";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMinimizar.Location = new System.Drawing.Point(1101, -3);
            this.btnMinimizar.MaximumSize = new System.Drawing.Size(50, 50);
            this.btnMinimizar.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(50, 50);
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.Text = "-";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.Location = new System.Drawing.Point(1146, -3);
            this.btnCerrar.MaximumSize = new System.Drawing.Size(50, 50);
            this.btnCerrar.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 50);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLogin.Controls.Add(this.btnMinimizar);
            this.panelLogin.Controls.Add(this.btnCerrar);
            this.panelLogin.Location = new System.Drawing.Point(1, 1);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1199, 50);
            this.panelLogin.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // RegistroClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.cbAptoFisico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbNoSocio);
            this.Controls.Add(this.rbSocio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroClientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.panelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbSocio;
        private System.Windows.Forms.RadioButton rbNoSocio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAptoFisico;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}