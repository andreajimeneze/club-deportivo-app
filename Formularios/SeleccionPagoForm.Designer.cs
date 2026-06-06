namespace ClubDeportivoApp.Formularios
{
    partial class SeleccionPagoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionPagoForm));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.Location = new System.Drawing.Point(606, 342);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(359, 75);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "NO SOCIO";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(189, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(359, 75);
            this.button1.TabIndex = 9;
            this.button1.Text = "SOCIO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(453, 463);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLogin.Controls.Add(this.btnMinimizar);
            this.panelLogin.Controls.Add(this.btnCerrar);
            this.panelLogin.Location = new System.Drawing.Point(2, 1);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1179, 50);
            this.panelLogin.TabIndex = 18;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMinimizar.Location = new System.Drawing.Point(1079, 0);
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
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.Location = new System.Drawing.Point(1129, 0);
            this.btnCerrar.MaximumSize = new System.Drawing.Size(50, 50);
            this.btnCerrar.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 50);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(373, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 42);
            this.label2.TabIndex = 20;
            this.label2.Text = "GESTIÓN DE PAGOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(36, 685);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(116, 20);
            this.lblFechaHoy.TabIndex = 22;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            this.lblFechaHoy.Click += new System.EventHandler(this.lblFechaHoy_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Location = new System.Drawing.Point(998, 666);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 58);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "<- VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // SeleccionPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionPagoForm";
            this.Text = "SeleccionPagoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Button btnVolver;
    }
}