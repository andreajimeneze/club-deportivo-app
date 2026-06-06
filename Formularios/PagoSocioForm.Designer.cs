namespace ClubDeportivoApp.Formularios
{
    partial class PagoCarnetForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoCarnetForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbConceptoPago = new System.Windows.Forms.ComboBox();
            this.cbMedioPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimirCarnet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnValidarPago = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Concepto pago";
            // 
            // cbConceptoPago
            // 
            this.cbConceptoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConceptoPago.FormattingEnabled = true;
            this.cbConceptoPago.ItemHeight = 25;
            this.cbConceptoPago.Location = new System.Drawing.Point(221, 331);
            this.cbConceptoPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.MaxLength = 32767;
            this.cbConceptoPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbConceptoPago.Name = "cbConceptoPago";
            this.cbConceptoPago.Size = new System.Drawing.Size(400, 33);
            this.cbConceptoPago.TabIndex = 8;
            // 
            // cbMedioPago
            // 
            this.cbMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedioPago.FormattingEnabled = true;
            this.cbMedioPago.Location = new System.Drawing.Point(221, 419);
            this.cbMedioPago.MaximumSize = new System.Drawing.Size(400, 0);
            this.cbMedioPago.MinimumSize = new System.Drawing.Size(400, 0);
            this.cbMedioPago.Name = "cbMedioPago";
            this.cbMedioPago.Size = new System.Drawing.Size(400, 33);
            this.cbMedioPago.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medio pago";
            // 
            // btnImprimirCarnet
            // 
            this.btnImprimirCarnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirCarnet.Location = new System.Drawing.Point(114, 194);
            this.btnImprimirCarnet.Name = "btnImprimirCarnet";
            this.btnImprimirCarnet.Size = new System.Drawing.Size(172, 60);
            this.btnImprimirCarnet.TabIndex = 6;
            this.btnImprimirCarnet.Text = "IMPRIMIR";
            this.btnImprimirCarnet.UseVisualStyleBackColor = true;
            this.btnImprimirCarnet.Click += new System.EventHandler(this.btnImprimirCarnet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 29);
            this.label3.TabIndex = 7;
            this.label3.Tag = "";
            this.label3.Text = "Generar Carnet";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPago.Location = new System.Drawing.Point(221, 247);
            this.txtMontoPago.MaximumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.MinimumSize = new System.Drawing.Size(400, 40);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(400, 40);
            this.txtMontoPago.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Monto a pagar";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimirCarnet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(763, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 299);
            this.panel1.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 2);
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
            this.panelLogin.Location = new System.Drawing.Point(-4, 2);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1187, 50);
            this.panelLogin.TabIndex = 18;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
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
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
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
            this.lblFechaHoy.Location = new System.Drawing.Point(39, 662);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(116, 20);
            this.lblFechaHoy.TabIndex = 21;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Location = new System.Drawing.Point(1001, 643);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 58);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "<- VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(371, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(376, 39);
            this.label5.TabIndex = 22;
            this.label5.Text = "REGISTRO DE PAGO";
            // 
            // btnValidarPago
            // 
            this.btnValidarPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnValidarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarPago.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValidarPago.Location = new System.Drawing.Point(456, 527);
            this.btnValidarPago.Name = "btnValidarPago";
            this.btnValidarPago.Size = new System.Drawing.Size(241, 75);
            this.btnValidarPago.TabIndex = 23;
            this.btnValidarPago.Text = "VALIDAR PAGO";
            this.btnValidarPago.UseVisualStyleBackColor = false;
            // 
            // PagoCarnetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.btnValidarPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMontoPago);
            this.Controls.Add(this.cbMedioPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbConceptoPago);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PagoCarnetForm";
            this.Text = "InscripcionSocio";
            this.Load += new System.EventHandler(this.InscripcionSocio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConceptoPago;
        private System.Windows.Forms.ComboBox cbMedioPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimirCarnet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoPago;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnValidarPago;
    }
}