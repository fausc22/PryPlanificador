namespace pryPlanificador
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gpInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblid2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
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
            this.btnActualizarHuella = new System.Windows.Forms.Button();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.btnActualizarFoto = new System.Windows.Forms.Button();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSelec = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.gpEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(70, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(439, 29);
            this.lblTitulo.TabIndex = 59;
            this.lblTitulo.Text = "ADMINISTRACIÓN DE EMPLEADOS";
            // 
            // gpInfo
            // 
            this.gpInfo.Controls.Add(this.btnEliminar);
            this.gpInfo.Controls.Add(this.label4);
            this.gpInfo.Controls.Add(this.btnLimpiar);
            this.gpInfo.Controls.Add(this.lblid2);
            this.gpInfo.Controls.Add(this.label3);
            this.gpInfo.Controls.Add(this.txtApellido);
            this.gpInfo.Controls.Add(this.label9);
            this.gpInfo.Controls.Add(this.txtDiaVacaciones);
            this.gpInfo.Controls.Add(this.label1);
            this.gpInfo.Controls.Add(this.lblxd);
            this.gpInfo.Controls.Add(this.txtMail);
            this.gpInfo.Controls.Add(this.txtAntiguedad);
            this.gpInfo.Controls.Add(this.label2);
            this.gpInfo.Controls.Add(this.label11);
            this.gpInfo.Controls.Add(this.txtNombre);
            this.gpInfo.Controls.Add(this.txtHoraNormal);
            this.gpInfo.Controls.Add(this.txtFecha);
            this.gpInfo.Controls.Add(this.label10);
            this.gpInfo.Controls.Add(this.btnActualizarHuella);
            this.gpInfo.Controls.Add(this.pbHuella);
            this.gpInfo.Controls.Add(this.btnActualizarFoto);
            this.gpInfo.Controls.Add(this.pbFoto);
            this.gpInfo.Controls.Add(this.button1);
            this.gpInfo.Location = new System.Drawing.Point(12, 170);
            this.gpInfo.Name = "gpInfo";
            this.gpInfo.Size = new System.Drawing.Size(589, 409);
            this.gpInfo.TabIndex = 60;
            this.gpInfo.TabStop = false;
            this.gpInfo.Text = "INFORMACION";
            this.gpInfo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "$";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLimpiar.Location = new System.Drawing.Point(82, 370);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(138, 29);
            this.btnLimpiar.TabIndex = 87;
            this.btnLimpiar.Text = "LIMPIAR ";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblid2
            // 
            this.lblid2.AutoSize = true;
            this.lblid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid2.Location = new System.Drawing.Point(567, 326);
            this.lblid2.Name = "lblid2";
            this.lblid2.Size = new System.Drawing.Size(22, 16);
            this.lblid2.TabIndex = 80;
            this.lblid2.Text = "ID";
            this.lblid2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 86;
            this.label3.Text = "APELLIDO";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(226, 63);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(102, 20);
            this.txtApellido.TabIndex = 85;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 73;
            this.label9.Text = "NOMBRE";
            // 
            // txtDiaVacaciones
            // 
            this.txtDiaVacaciones.Location = new System.Drawing.Point(226, 258);
            this.txtDiaVacaciones.Name = "txtDiaVacaciones";
            this.txtDiaVacaciones.Size = new System.Drawing.Size(102, 20);
            this.txtDiaVacaciones.TabIndex = 75;
            this.txtDiaVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiaVacaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaVacaciones_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "MAIL";
            // 
            // lblxd
            // 
            this.lblxd.AutoSize = true;
            this.lblxd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblxd.Location = new System.Drawing.Point(18, 181);
            this.lblxd.Name = "lblxd";
            this.lblxd.Size = new System.Drawing.Size(106, 16);
            this.lblxd.TabIndex = 84;
            this.lblxd.Text = "ANTIGÜEDAD";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(226, 101);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(102, 20);
            this.txtMail.TabIndex = 74;
            this.txtMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Location = new System.Drawing.Point(226, 177);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(102, 20);
            this.txtAntiguedad.TabIndex = 83;
            this.txtAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAntiguedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAntiguedad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "DIAS DE VACACIONES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 16);
            this.label11.TabIndex = 82;
            this.label11.Text = "HORA NORMAL";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(228, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 78;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtHoraNormal
            // 
            this.txtHoraNormal.Location = new System.Drawing.Point(226, 217);
            this.txtHoraNormal.Name = "txtHoraNormal";
            this.txtHoraNormal.Size = new System.Drawing.Size(102, 20);
            this.txtHoraNormal.TabIndex = 81;
            this.txtHoraNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraNormal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraNormal_KeyPress);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(226, 139);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(102, 20);
            this.txtFecha.TabIndex = 79;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 16);
            this.label10.TabIndex = 80;
            this.label10.Text = "FECHA INGRESO";
            // 
            // btnActualizarHuella
            // 
            this.btnActualizarHuella.BackColor = System.Drawing.SystemColors.Info;
            this.btnActualizarHuella.Location = new System.Drawing.Point(407, 361);
            this.btnActualizarHuella.Name = "btnActualizarHuella";
            this.btnActualizarHuella.Size = new System.Drawing.Size(133, 29);
            this.btnActualizarHuella.TabIndex = 72;
            this.btnActualizarHuella.Text = "ACTUALIZAR HUELLA";
            this.btnActualizarHuella.UseVisualStyleBackColor = false;
            this.btnActualizarHuella.Click += new System.EventHandler(this.btnActualizarHuella_Click);
            // 
            // pbHuella
            // 
            this.pbHuella.Location = new System.Drawing.Point(367, 208);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(199, 147);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHuella.TabIndex = 71;
            this.pbHuella.TabStop = false;
            this.pbHuella.Click += new System.EventHandler(this.pbHuella_Click);
            // 
            // btnActualizarFoto
            // 
            this.btnActualizarFoto.BackColor = System.Drawing.SystemColors.Info;
            this.btnActualizarFoto.Location = new System.Drawing.Point(407, 161);
            this.btnActualizarFoto.Name = "btnActualizarFoto";
            this.btnActualizarFoto.Size = new System.Drawing.Size(133, 29);
            this.btnActualizarFoto.TabIndex = 70;
            this.btnActualizarFoto.Text = "ACTUALIZAR FOTO";
            this.btnActualizarFoto.UseVisualStyleBackColor = false;
            this.btnActualizarFoto.Click += new System.EventHandler(this.btnActualizarFoto_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(367, 10);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(199, 147);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 69;
            this.pbFoto.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(82, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 29);
            this.button1.TabIndex = 64;
            this.button1.Text = "ACTUALIZAR DATOS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.lblId);
            this.gpEmpleado.Controls.Add(this.btnSelec);
            this.gpEmpleado.Controls.Add(this.label7);
            this.gpEmpleado.Controls.Add(this.cmbEmpleado);
            this.gpEmpleado.Location = new System.Drawing.Point(199, 41);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(183, 123);
            this.gpEmpleado.TabIndex = 61;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "SELECCIONE EMPLEADO";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(154, 82);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(22, 16);
            this.lblId.TabIndex = 79;
            this.lblId.Text = "ID";
            this.lblId.Visible = false;
            // 
            // btnSelec
            // 
            this.btnSelec.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelec.Enabled = false;
            this.btnSelec.Location = new System.Drawing.Point(30, 71);
            this.btnSelec.Name = "btnSelec";
            this.btnSelec.Size = new System.Drawing.Size(118, 39);
            this.btnSelec.TabIndex = 31;
            this.btnSelec.Text = "HABILITAR EDICIÓN";
            this.btnSelec.UseVisualStyleBackColor = false;
            this.btnSelec.Click += new System.EventHandler(this.btnSelec_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "EMPLEADO";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(19, 44);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(144, 21);
            this.cmbEmpleado.TabIndex = 30;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(489, 592);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 29);
            this.btnSalir.TabIndex = 65;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAyuda.Location = new System.Drawing.Point(376, 592);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(107, 29);
            this.btnAyuda.TabIndex = 66;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(82, 335);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(138, 29);
            this.btnEliminar.TabIndex = 88;
            this.btnEliminar.Text = "ELIMINAR ";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(608, 633);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.gpInfo);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLEADOS - EDITAR EMPLEADO";
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            this.gpInfo.ResumeLayout(false);
            this.gpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gpInfo;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Button btnSelec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Button btnActualizarHuella;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.Button btnActualizarFoto;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
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
        private System.Windows.Forms.Label lblid2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
    }
}