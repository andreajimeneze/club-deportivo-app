using System.Windows.Forms;

namespace ClubDeportivoApp
{
    public partial class DashboardForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.btnRegistro = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCarnet = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnMorosos = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistro
            // 
            this.btnRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistro.AutoSize = true;
            this.btnRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(102)))), ((int)(((byte)(152)))));
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegistro.Location = new System.Drawing.Point(320, 151);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(50);
            this.btnRegistro.MaximumSize = new System.Drawing.Size(800, 80);
            this.btnRegistro.MinimumSize = new System.Drawing.Size(550, 42);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(800, 80);
            this.btnRegistro.TabIndex = 0;
            this.btnRegistro.Text = "Registrar Socio - No Socio";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(452, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(514, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "DASHBOARD DE GESTIÓN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCarnet
            // 
            this.btnCarnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarnet.AutoSize = true;
            this.btnCarnet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(73)))), ((int)(((byte)(148)))));
            this.btnCarnet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarnet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCarnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarnet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCarnet.Location = new System.Drawing.Point(320, 257);
            this.btnCarnet.Margin = new System.Windows.Forms.Padding(50);
            this.btnCarnet.MaximumSize = new System.Drawing.Size(800, 80);
            this.btnCarnet.MinimumSize = new System.Drawing.Size(450, 42);
            this.btnCarnet.Name = "btnCarnet";
            this.btnCarnet.Size = new System.Drawing.Size(800, 80);
            this.btnCarnet.TabIndex = 5;
            this.btnCarnet.Text = "Reimprimir Carnet Socio";
            this.btnCarnet.UseVisualStyleBackColor = false;
            this.btnCarnet.Click += new System.EventHandler(this.btnCarnet_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagos.AutoSize = true;
            this.btnPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(48)))), ((int)(((byte)(144)))));
            this.btnPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPagos.Location = new System.Drawing.Point(320, 376);
            this.btnPagos.Margin = new System.Windows.Forms.Padding(50);
            this.btnPagos.MaximumSize = new System.Drawing.Size(800, 80);
            this.btnPagos.MinimumSize = new System.Drawing.Size(450, 42);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(800, 80);
            this.btnPagos.TabIndex = 6;
            this.btnPagos.Text = "Gestión de Pagos";
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnMorosos
            // 
            this.btnMorosos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMorosos.AutoSize = true;
            this.btnMorosos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(35)))), ((int)(((byte)(142)))));
            this.btnMorosos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMorosos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMorosos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMorosos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMorosos.Location = new System.Drawing.Point(320, 486);
            this.btnMorosos.Margin = new System.Windows.Forms.Padding(50);
            this.btnMorosos.MaximumSize = new System.Drawing.Size(800, 80);
            this.btnMorosos.MinimumSize = new System.Drawing.Size(450, 42);
            this.btnMorosos.Name = "btnMorosos";
            this.btnMorosos.Size = new System.Drawing.Size(800, 80);
            this.btnMorosos.TabIndex = 7;
            this.btnMorosos.Text = "Emitir Listado Vencimientos";
            this.btnMorosos.UseVisualStyleBackColor = false;
            this.btnMorosos.Click += new System.EventHandler(this.btnMorosos_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(1038, 76);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(119, 25);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Bienvenido, ";
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoy.Location = new System.Drawing.Point(65, 552);
            this.lblFechaHoy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(137, 25);
            this.lblFechaHoy.TabIndex = 15;
            this.lblFechaHoy.Text = "Fecha y hora: ";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(32)))), ((int)(((byte)(23)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(1159, 575);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.btnSalir.MaximumSize = new System.Drawing.Size(180, 57);
            this.btnSalir.MinimumSize = new System.Drawing.Size(180, 42);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(180, 42);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1369, 654);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblFechaHoy);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnMorosos);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.btnCarnet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Club Deportivo ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCarnet;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnMorosos;
        private Label lblUsuario;
        private Label lblFechaHoy;
        private Button btnSalir;
        private PictureBox pictureBox1;
    }
}