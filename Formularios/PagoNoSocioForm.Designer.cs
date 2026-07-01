namespace ClubDeportivoApp.Formularios
{
    partial class PagoNoSocioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoNoSocioForm));
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbConceptoPago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbMetodosPago = new System.Windows.Forms.ComboBox();
            this.btnValidarReserva = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReserva = new System.Windows.Forms.Label();
            this.btnConfirmarPago = new System.Windows.Forms.Button();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbActividades = new System.Windows.Forms.ComboBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(49, 724);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(116, 20);
            this.lblFechaHoy.TabIndex = 48;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Location = new System.Drawing.Point(1015, 724);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 58);
            this.btnVolver.TabIndex = 47;
            this.btnVolver.Text = "<- VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMinimizar.Location = new System.Drawing.Point(1080, -1);
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
            this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.Location = new System.Drawing.Point(1134, -1);
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
            this.panelLogin.Location = new System.Drawing.Point(10, 5);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1187, 50);
            this.panelLogin.TabIndex = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPago.Location = new System.Drawing.Point(720, 291);
            this.txtMontoPago.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(400, 40);
            this.txtMontoPago.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(351, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(564, 39);
            this.label8.TabIndex = 50;
            this.label8.Text = "REGISTRO DE PAGO NO SOCIO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(723, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Concepto pago";
            // 
            // cbConceptoPago
            // 
            this.cbConceptoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConceptoPago.FormattingEnabled = true;
            this.cbConceptoPago.ItemHeight = 25;
            this.cbConceptoPago.Location = new System.Drawing.Point(720, 380);
            this.cbConceptoPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.MaxLength = 32767;
            this.cbConceptoPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.Name = "cbConceptoPago";
            this.cbConceptoPago.Size = new System.Drawing.Size(400, 33);
            this.cbConceptoPago.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(716, 436);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "Medio pago";
            // 
            // cbMetodosPago
            // 
            this.cbMetodosPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMetodosPago.FormattingEnabled = true;
            this.cbMetodosPago.Location = new System.Drawing.Point(720, 468);
            this.cbMetodosPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbMetodosPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbMetodosPago.Name = "cbMetodosPago";
            this.cbMetodosPago.Size = new System.Drawing.Size(400, 33);
            this.cbMetodosPago.TabIndex = 53;
            // 
            // btnValidarReserva
            // 
            this.btnValidarReserva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValidarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarReserva.Location = new System.Drawing.Point(358, 346);
            this.btnValidarReserva.Name = "btnValidarReserva";
            this.btnValidarReserva.Size = new System.Drawing.Size(190, 53);
            this.btnValidarReserva.TabIndex = 65;
            this.btnValidarReserva.Text = "Validar Reserva";
            this.btnValidarReserva.UseVisualStyleBackColor = true;
            this.btnValidarReserva.Click += new System.EventHandler(this.btnValidarReserva_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(723, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 56;
            this.label10.Text = "Monto a pagar";
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReserva.Location = new System.Drawing.Point(263, 257);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(211, 20);
            this.lblReserva.TabIndex = 57;
            this.lblReserva.Text = "Ingrese DNI o Nro Reserva";
            // 
            // btnConfirmarPago
            // 
            this.btnConfirmarPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirmarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnConfirmarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPago.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirmarPago.Location = new System.Drawing.Point(802, 532);
            this.btnConfirmarPago.Name = "btnConfirmarPago";
            this.btnConfirmarPago.Size = new System.Drawing.Size(257, 82);
            this.btnConfirmarPago.TabIndex = 58;
            this.btnConfirmarPago.Text = "CONFIRMAR PAGO";
            this.btnConfirmarPago.UseVisualStyleBackColor = false;
            this.btnConfirmarPago.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // txtReserva
            // 
            this.txtReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReserva.Location = new System.Drawing.Point(260, 289);
            this.txtReserva.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtReserva.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(400, 40);
            this.txtReserva.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Seleccione Actividad";
            // 
            // cbActividades
            // 
            this.cbActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActividades.FormattingEnabled = true;
            this.cbActividades.ItemHeight = 25;
            this.cbActividades.Location = new System.Drawing.Point(247, 468);
            this.cbActividades.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbActividades.MaxLength = 32767;
            this.cbActividades.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbActividades.Name = "cbActividades";
            this.cbActividades.Size = new System.Drawing.Size(400, 33);
            this.cbActividades.TabIndex = 64;
            this.cbActividades.SelectedIndexChanged += new System.EventHandler(this.cbActividades_SelectedIndexChanged);
            // 
            // ReservasForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnValidarReserva);
            this.Controls.Add(this.cbActividades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReserva);
            this.Controls.Add(this.btnConfirmarPago);
            this.Controls.Add(this.lblReserva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMontoPago);
            this.Controls.Add(this.cbMetodosPago);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbConceptoPago);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservasForm2";
            this.Text = "ReservasForm2";
            this.Load += new System.EventHandler(this.ReservasForm2_Load);
            this.panelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtMontoPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbConceptoPago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbMetodosPago;
        private System.Windows.Forms.Button btnValidarReserva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.Button btnConfirmarPago;
        private System.Windows.Forms.TextBox txtReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbActividades;
    }
}