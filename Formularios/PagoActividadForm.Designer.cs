namespace ClubDeportivoApp.Formularios
{
    partial class PagoActividadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoActividadForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtActividad = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.cbMetodosPago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbConceptoPago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbActividades = new System.Windows.Forms.ComboBox();
            this.btnValidarPago = new System.Windows.Forms.Button();
            this.btnReserva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(770, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selección de Actividad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(761, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selección Fecha y hora";
            // 
            // dtActividad
            // 
            this.dtActividad.Location = new System.Drawing.Point(764, 347);
            this.dtActividad.Name = "dtActividad";
            this.dtActividad.Size = new System.Drawing.Size(200, 22);
            this.dtActividad.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLogin.Controls.Add(this.btnMinimizar);
            this.panelLogin.Controls.Add(this.btnCerrar);
            this.panelLogin.Location = new System.Drawing.Point(11, 5);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1187, 50);
            this.panelLogin.TabIndex = 22;
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
            // lblFechaHoy
            // 
            this.lblFechaHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(50, 711);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(116, 20);
            this.lblFechaHoy.TabIndex = 25;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Location = new System.Drawing.Point(1012, 692);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 58);
            this.btnVolver.TabIndex = 24;
            this.btnVolver.Text = "<- VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(347, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(564, 39);
            this.label8.TabIndex = 26;
            this.label8.Text = "REGISTRO DE PAGO NO SOCIO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(259, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "DNI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(259, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Monto a pagar";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Enabled = false;
            this.txtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPago.Location = new System.Drawing.Point(256, 322);
            this.txtMontoPago.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(400, 26);
            this.txtMontoPago.TabIndex = 30;
            // 
            // cbMetodosPago
            // 
            this.cbMetodosPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMetodosPago.FormattingEnabled = true;
            this.cbMetodosPago.Location = new System.Drawing.Point(256, 499);
            this.cbMetodosPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbMetodosPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbMetodosPago.Name = "cbMetodosPago";
            this.cbMetodosPago.Size = new System.Drawing.Size(400, 33);
            this.cbMetodosPago.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(252, 467);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Medio pago";
            // 
            // cbConceptoPago
            // 
            this.cbConceptoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConceptoPago.FormattingEnabled = true;
            this.cbConceptoPago.ItemHeight = 25;
            this.cbConceptoPago.Location = new System.Drawing.Point(256, 411);
            this.cbConceptoPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.MaxLength = 32767;
            this.cbConceptoPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.Name = "cbConceptoPago";
            this.cbConceptoPago.Size = new System.Drawing.Size(400, 33);
            this.cbConceptoPago.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(259, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Concepto pago";
            // 
            // cbActividades
            // 
            this.cbActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActividades.FormattingEnabled = true;
            this.cbActividades.ItemHeight = 25;
            this.cbActividades.Location = new System.Drawing.Point(765, 239);
            this.cbActividades.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbActividades.MaxLength = 32767;
            this.cbActividades.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbActividades.Name = "cbActividades";
            this.cbActividades.Size = new System.Drawing.Size(400, 33);
            this.cbActividades.TabIndex = 35;
            // 
            // btnValidarPago
            // 
            this.btnValidarPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnValidarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarPago.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValidarPago.Location = new System.Drawing.Point(363, 579);
            this.btnValidarPago.Name = "btnValidarPago";
            this.btnValidarPago.Size = new System.Drawing.Size(241, 75);
            this.btnValidarPago.TabIndex = 36;
            this.btnValidarPago.Text = "VALIDAR PAGO";
            this.btnValidarPago.UseVisualStyleBackColor = false;
            this.btnValidarPago.Click += new System.EventHandler(this.btnValidarPago_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserva.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReserva.Location = new System.Drawing.Point(670, 579);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(241, 75);
            this.btnReserva.TabIndex = 37;
            this.btnReserva.Text = "CONFIRMAR RESERVA";
            this.btnReserva.UseVisualStyleBackColor = false;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // PagoActividadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ControlBox = false;
            this.Controls.Add(this.btnReserva);
            this.Controls.Add(this.btnValidarPago);
            this.Controls.Add(this.cbActividades);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMontoPago);
            this.Controls.Add(this.cbMetodosPago);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbConceptoPago);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dtActividad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PagoActividadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripcion Actividades NO SOCIO";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtActividad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMontoPago;
        private System.Windows.Forms.ComboBox cbMetodosPago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbConceptoPago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbActividades;
        private System.Windows.Forms.Button btnValidarPago;
        private System.Windows.Forms.Button btnReserva;
    }
}