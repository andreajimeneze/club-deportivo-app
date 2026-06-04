namespace ClubDeportivoApp.Formularios
{
    partial class InscripcionNoSocioForm
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
            this.cbActividades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dtActividad = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMetodos = new System.Windows.Forms.ComboBox();
            this.txtpago = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbActividades
            // 
            this.cbActividades.FormattingEnabled = true;
            this.cbActividades.Location = new System.Drawing.Point(139, 154);
            this.cbActividades.Name = "cbActividades";
            this.cbActividades.Size = new System.Drawing.Size(214, 24);
            this.cbActividades.TabIndex = 0;
            this.cbActividades.SelectedIndexChanged += new System.EventHandler(this.cbActividades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selección de Actividad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selección Fecha y hora";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(294, 324);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(221, 57);
            this.btAceptar.TabIndex = 6;
            this.btAceptar.Text = "CONFIRMAR RESERVA";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtActividad
            // 
            this.dtActividad.Location = new System.Drawing.Point(446, 156);
            this.dtActividad.Name = "dtActividad";
            this.dtActividad.Size = new System.Drawing.Size(200, 22);
            this.dtActividad.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Monto a pagar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Método de Pago";
            // 
            // cbMetodos
            // 
            this.cbMetodos.FormattingEnabled = true;
            this.cbMetodos.Location = new System.Drawing.Point(446, 255);
            this.cbMetodos.Name = "cbMetodos";
            this.cbMetodos.Size = new System.Drawing.Size(214, 24);
            this.cbMetodos.TabIndex = 10;
            this.cbMetodos.SelectedIndexChanged += new System.EventHandler(this.cbMetodos_SelectedIndexChanged);
            // 
            // txtpago
            // 
            this.txtpago.Location = new System.Drawing.Point(141, 257);
            this.txtpago.Name = "txtpago";
            this.txtpago.Size = new System.Drawing.Size(151, 22);
            this.txtpago.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 22);
            this.textBox1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "DNI No socio";
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(45, 404);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(102, 18);
            this.lblFechaHoy.TabIndex = 16;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // InscripcionNoSocioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpago);
            this.Controls.Add(this.cbMetodos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtActividad);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbActividades);
            this.Name = "InscripcionNoSocioForm";
            this.Text = "Inscripcion Actividades NO SOCIO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActividades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.DateTimePicker dtActividad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMetodos;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFechaHoy;
    }
}