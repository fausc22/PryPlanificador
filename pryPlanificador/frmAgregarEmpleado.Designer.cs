namespace pryPlanificador
{
    partial class frmAgregarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEmpleado));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.bnInit = new System.Windows.Forms.Button();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.btnActualizarFoto = new System.Windows.Forms.Button();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiaVacaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblxd = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtAntiguedad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtHoraNormal = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtJornada = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtJornada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.bnInit);
            this.groupBox1.Controls.Add(this.pbHuella);
            this.groupBox1.Controls.Add(this.btnActualizarFoto);
            this.groupBox1.Controls.Add(this.pbFoto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDiaVacaciones);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblxd);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtAntiguedad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtHoraNormal);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(216, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 89;
            this.label4.Text = "$";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(626, 335);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 16);
            this.lblId.TabIndex = 69;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLimpiar.Location = new System.Drawing.Point(82, 383);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(149, 42);
            this.btnLimpiar.TabIndex = 73;
            this.btnLimpiar.Text = "LIMPIAR ";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // bnInit
            // 
            this.bnInit.BackColor = System.Drawing.SystemColors.Info;
            this.bnInit.Location = new System.Drawing.Point(465, 370);
            this.bnInit.Name = "bnInit";
            this.bnInit.Size = new System.Drawing.Size(133, 29);
            this.bnInit.TabIndex = 72;
            this.bnInit.Text = "CARGAR HUELLA";
            this.bnInit.UseVisualStyleBackColor = false;
            this.bnInit.LocationChanged += new System.EventHandler(this.bnInit_LocationChanged);
            this.bnInit.Click += new System.EventHandler(this.btnActualizarHuella_Click);
            // 
            // pbHuella
            // 
            this.pbHuella.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbHuella.Location = new System.Drawing.Point(425, 217);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(199, 147);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHuella.TabIndex = 71;
            this.pbHuella.TabStop = false;
            this.pbHuella.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pbHuella_LoadCompleted);
            this.pbHuella.LocationChanged += new System.EventHandler(this.pbHuella_LocationChanged);
            // 
            // btnActualizarFoto
            // 
            this.btnActualizarFoto.BackColor = System.Drawing.SystemColors.Info;
            this.btnActualizarFoto.Location = new System.Drawing.Point(465, 170);
            this.btnActualizarFoto.Name = "btnActualizarFoto";
            this.btnActualizarFoto.Size = new System.Drawing.Size(133, 29);
            this.btnActualizarFoto.TabIndex = 70;
            this.btnActualizarFoto.Text = "CARGAR FOTO";
            this.btnActualizarFoto.UseVisualStyleBackColor = false;
            this.btnActualizarFoto.Click += new System.EventHandler(this.btnActualizarFoto_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pbFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbFoto.InitialImage = null;
            this.pbFoto.Location = new System.Drawing.Point(425, 19);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(199, 147);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 69;
            this.pbFoto.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "APELLIDO";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(236, 70);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(102, 20);
            this.txtApellido.TabIndex = 67;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(82, 335);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(149, 42);
            this.btnAgregar.TabIndex = 64;
            this.btnAgregar.Text = "CREAR NUEVO EMPLEADO";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "NOMBRE";
            // 
            // txtDiaVacaciones
            // 
            this.txtDiaVacaciones.Enabled = false;
            this.txtDiaVacaciones.Location = new System.Drawing.Point(236, 265);
            this.txtDiaVacaciones.Name = "txtDiaVacaciones";
            this.txtDiaVacaciones.Size = new System.Drawing.Size(102, 20);
            this.txtDiaVacaciones.TabIndex = 48;
            this.txtDiaVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiaVacaciones.TextChanged += new System.EventHandler(this.txtHoraVacaciones_TextChanged);
            this.txtDiaVacaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraVacaciones_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "MAIL";
            // 
            // lblxd
            // 
            this.lblxd.AutoSize = true;
            this.lblxd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblxd.Location = new System.Drawing.Point(28, 188);
            this.lblxd.Name = "lblxd";
            this.lblxd.Size = new System.Drawing.Size(106, 16);
            this.lblxd.TabIndex = 58;
            this.lblxd.Text = "ANTIGÜEDAD";
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(236, 108);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(102, 20);
            this.txtMail.TabIndex = 47;
            this.txtMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Enabled = false;
            this.txtAntiguedad.Location = new System.Drawing.Point(236, 184);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(102, 20);
            this.txtAntiguedad.TabIndex = 57;
            this.txtAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAntiguedad.TextChanged += new System.EventHandler(this.txtHoraFeriado_TextChanged);
            this.txtAntiguedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraFeriado_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "DIAS DE VACACIONES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "HORA NORMAL";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(238, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtHoraNormal
            // 
            this.txtHoraNormal.Enabled = false;
            this.txtHoraNormal.Location = new System.Drawing.Point(236, 224);
            this.txtHoraNormal.Name = "txtHoraNormal";
            this.txtHoraNormal.Size = new System.Drawing.Size(102, 20);
            this.txtHoraNormal.TabIndex = 55;
            this.txtHoraNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraNormal.TextChanged += new System.EventHandler(this.txtHoraNormal_TextChanged);
            this.txtHoraNormal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraNormal_KeyPress);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(236, 146);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(102, 20);
            this.txtFecha.TabIndex = 53;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFecha.TextChanged += new System.EventHandler(this.txtFecha_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 16);
            this.label10.TabIndex = 54;
            this.label10.Text = "FECHA INGRESO ";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(194, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "NUEVO EMPLEADO";
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAyuda.Location = new System.Drawing.Point(437, 486);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(107, 29);
            this.btnAyuda.TabIndex = 68;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(550, 486);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 29);
            this.btnSalir.TabIndex = 67;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtJornada
            // 
            this.txtJornada.Enabled = false;
            this.txtJornada.Location = new System.Drawing.Point(235, 299);
            this.txtJornada.Name = "txtJornada";
            this.txtJornada.Size = new System.Drawing.Size(102, 20);
            this.txtJornada.TabIndex = 90;
            this.txtJornada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJornada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJornada_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 91;
            this.label5.Text = "JORNADA (HS)";
            // 
            // frmAgregarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(669, 527);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgregarEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLEADOS - NUEVO EMPLEADO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgregarEmpleado_FormClosing);
            this.Load += new System.EventHandler(this.frmAgregarEmpleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnInit;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.Button btnActualizarFoto;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiaVacaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblxd;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtAntiguedad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtHoraNormal;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJornada;
        private System.Windows.Forms.Label label5;
    }
}