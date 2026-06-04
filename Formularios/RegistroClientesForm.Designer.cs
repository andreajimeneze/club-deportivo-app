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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 111);
            this.txtNombre.MaximumSize = new System.Drawing.Size(300, 40);
            this.txtNombre.MinimumSize = new System.Drawing.Size(300, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(130, 173);
            this.txtApellido.MaximumSize = new System.Drawing.Size(300, 40);
            this.txtApellido.MinimumSize = new System.Drawing.Size(300, 40);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(300, 22);
            this.txtApellido.TabIndex = 4;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(130, 234);
            this.txtDni.MaximumSize = new System.Drawing.Size(300, 40);
            this.txtDni.MinimumSize = new System.Drawing.Size(300, 40);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(300, 22);
            this.txtDni.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(328, 410);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(162, 40);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(579, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(200, 40);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver a pantalla principal";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(524, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seleccione calidad de inscripto";
            // 
            // rbSocio
            // 
            this.rbSocio.AutoSize = true;
            this.rbSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSocio.Location = new System.Drawing.Point(527, 155);
            this.rbSocio.Name = "rbSocio";
            this.rbSocio.Size = new System.Drawing.Size(72, 24);
            this.rbSocio.TabIndex = 10;
            this.rbSocio.TabStop = true;
            this.rbSocio.Text = "Socio";
            this.rbSocio.UseVisualStyleBackColor = true;
            // 
            // rbNoSocio
            // 
            this.rbNoSocio.AutoSize = true;
            this.rbNoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoSocio.Location = new System.Drawing.Point(527, 185);
            this.rbNoSocio.Name = "rbNoSocio";
            this.rbNoSocio.Size = new System.Drawing.Size(98, 24);
            this.rbNoSocio.TabIndex = 11;
            this.rbNoSocio.TabStop = true;
            this.rbNoSocio.Text = "No Socio";
            this.rbNoSocio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(524, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Presenta apto físico?";
            // 
            // cbAptoFisico
            // 
            this.cbAptoFisico.AutoSize = true;
            this.cbAptoFisico.Location = new System.Drawing.Point(527, 296);
            this.cbAptoFisico.Name = "cbAptoFisico";
            this.cbAptoFisico.Size = new System.Drawing.Size(41, 20);
            this.cbAptoFisico.TabIndex = 13;
            this.cbAptoFisico.Text = "SÍ";
            this.cbAptoFisico.UseVisualStyleBackColor = true;
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(28, 22);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(102, 18);
            this.lblFechaHoy.TabIndex = 14;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // RegistroClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 517);
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
            this.Name = "RegistroClientesForm";
            this.Text = "Registro";
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
    }
}