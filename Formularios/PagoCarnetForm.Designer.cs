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
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConceptoPago = new System.Windows.Forms.ComboBox();
            this.cbMedioPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValidarPago = new System.Windows.Forms.Button();
            this.btnImprimirCarnet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(33, 23);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(49, 18);
            this.lblFechaHoy.TabIndex = 0;
            this.lblFechaHoy.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Concepto pago";
            // 
            // cbConceptoPago
            // 
            this.cbConceptoPago.FormattingEnabled = true;
            this.cbConceptoPago.Location = new System.Drawing.Point(111, 202);
            this.cbConceptoPago.Name = "cbConceptoPago";
            this.cbConceptoPago.Size = new System.Drawing.Size(187, 24);
            this.cbConceptoPago.TabIndex = 2;
            // 
            // cbMedioPago
            // 
            this.cbMedioPago.FormattingEnabled = true;
            this.cbMedioPago.Location = new System.Drawing.Point(111, 278);
            this.cbMedioPago.Name = "cbMedioPago";
            this.cbMedioPago.Size = new System.Drawing.Size(187, 24);
            this.cbMedioPago.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medio pago";
            // 
            // btnValidarPago
            // 
            this.btnValidarPago.Location = new System.Drawing.Point(167, 332);
            this.btnValidarPago.Name = "btnValidarPago";
            this.btnValidarPago.Size = new System.Drawing.Size(172, 60);
            this.btnValidarPago.TabIndex = 5;
            this.btnValidarPago.Text = "VALIDAR PAGO";
            this.btnValidarPago.UseVisualStyleBackColor = true;
            this.btnValidarPago.Click += new System.EventHandler(this.btnValidarPago_Click);
            // 
            // btnImprimirCarnet
            // 
            this.btnImprimirCarnet.Location = new System.Drawing.Point(100, 121);
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
            this.label3.Location = new System.Drawing.Point(135, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 7;
            this.label3.Tag = "";
            this.label3.Text = "Generar Carnet";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Location = new System.Drawing.Point(111, 119);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(187, 22);
            this.txtMontoPago.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
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
            this.panel1.Location = new System.Drawing.Point(417, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 240);
            this.panel1.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // InscripcionSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMontoPago);
            this.Controls.Add(this.btnValidarPago);
            this.Controls.Add(this.cbMedioPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbConceptoPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFechaHoy);
            this.Name = "InscripcionSocio";
            this.Text = "InscripcionSocio";
            this.Load += new System.EventHandler(this.InscripcionSocio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConceptoPago;
        private System.Windows.Forms.ComboBox cbMedioPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValidarPago;
        private System.Windows.Forms.Button btnImprimirCarnet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoPago;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}