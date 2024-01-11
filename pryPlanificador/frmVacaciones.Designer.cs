namespace pryPlanificador
{
    partial class frmVacaciones
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnNuevoFeriado = new System.Windows.Forms.Button();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.dtpRegreso = new System.Windows.Forms.DateTimePicker();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtCantDia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSelec = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblb = new System.Windows.Forms.Label();
            this.lblblblb = new System.Windows.Forms.Label();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.dgvCalendario = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.rbPagas = new System.Windows.Forms.RadioButton();
            this.rbSin = new System.Windows.Forms.RadioButton();
            this.gpEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(169, 390);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 29);
            this.lblTitulo.TabIndex = 35;
            this.lblTitulo.Text = "EMPLEADOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "CALENDARIO";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(654, 592);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 22);
            this.btnSalir.TabIndex = 47;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(554, 592);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(92, 22);
            this.btnAyuda.TabIndex = 46;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnNuevoFeriado
            // 
            this.btnNuevoFeriado.BackColor = System.Drawing.Color.Green;
            this.btnNuevoFeriado.Location = new System.Drawing.Point(539, 41);
            this.btnNuevoFeriado.Name = "btnNuevoFeriado";
            this.btnNuevoFeriado.Size = new System.Drawing.Size(179, 39);
            this.btnNuevoFeriado.TabIndex = 48;
            this.btnNuevoFeriado.Text = "AGREGAR VACACIONES";
            this.btnNuevoFeriado.UseVisualStyleBackColor = false;
            this.btnNuevoFeriado.Click += new System.EventHandler(this.btnNuevoFeriado_Click);
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.rbSin);
            this.gpEmpleado.Controls.Add(this.rbPagas);
            this.gpEmpleado.Controls.Add(this.dtpRegreso);
            this.gpEmpleado.Controls.Add(this.dtpSalida);
            this.gpEmpleado.Controls.Add(this.lblDias);
            this.gpEmpleado.Controls.Add(this.lblId);
            this.gpEmpleado.Controls.Add(this.txtCantDia);
            this.gpEmpleado.Controls.Add(this.label4);
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.btnSelec);
            this.gpEmpleado.Controls.Add(this.label7);
            this.gpEmpleado.Controls.Add(this.cmbEmpleado);
            this.gpEmpleado.Controls.Add(this.lblb);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Location = new System.Drawing.Point(496, 99);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(263, 299);
            this.gpEmpleado.TabIndex = 49;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "COMPLETE LOS SIGUIENTOS DATOS";
            this.gpEmpleado.Visible = false;
            // 
            // dtpRegreso
            // 
            this.dtpRegreso.Location = new System.Drawing.Point(42, 131);
            this.dtpRegreso.Name = "dtpRegreso";
            this.dtpRegreso.Size = new System.Drawing.Size(180, 20);
            this.dtpRegreso.TabIndex = 56;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Location = new System.Drawing.Point(42, 89);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(177, 20);
            this.dtpSalida.TabIndex = 55;
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(225, 57);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(27, 29);
            this.lblDias.TabIndex = 54;
            this.lblDias.Text = "1";
            this.lblDias.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(224, 14);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 29);
            this.lblId.TabIndex = 53;
            this.lblId.Text = "1";
            this.lblId.Visible = false;
            // 
            // txtCantDia
            // 
            this.txtCantDia.Location = new System.Drawing.Point(43, 173);
            this.txtCantDia.Name = "txtCantDia";
            this.txtCantDia.Size = new System.Drawing.Size(176, 20);
            this.txtCantDia.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "CANTIDAD DÍAS";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Info;
            this.btnLimpiar.Location = new System.Drawing.Point(139, 246);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 38);
            this.btnLimpiar.TabIndex = 32;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSelec
            // 
            this.btnSelec.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSelec.Location = new System.Drawing.Point(22, 246);
            this.btnSelec.Name = "btnSelec";
            this.btnSelec.Size = new System.Drawing.Size(101, 38);
            this.btnSelec.TabIndex = 31;
            this.btnSelec.Text = "CARGAR VACACIONES";
            this.btnSelec.UseVisualStyleBackColor = false;
            this.btnSelec.Click += new System.EventHandler(this.btnSelec_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "EMPLEADO";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(43, 46);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(176, 21);
            this.cmbEmpleado.TabIndex = 30;
            // 
            // lblb
            // 
            this.lblb.AutoSize = true;
            this.lblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblb.Location = new System.Drawing.Point(72, 70);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(114, 16);
            this.lblb.TabIndex = 23;
            this.lblb.Text = "FECHA SALIDA";
            // 
            // lblblblb
            // 
            this.lblblblb.AutoSize = true;
            this.lblblblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblblblb.Location = new System.Drawing.Point(72, 112);
            this.lblblblb.Name = "lblblblb";
            this.lblblblb.Size = new System.Drawing.Size(135, 16);
            this.lblblblb.TabIndex = 24;
            this.lblblblb.Text = "FECHA REGRESO";
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.AllowUserToResizeColumns = false;
            this.dgvEmpleados.AllowUserToResizeRows = false;
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.EnableHeadersVisualStyles = false;
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 422);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.Size = new System.Drawing.Size(478, 136);
            this.dgvEmpleados.TabIndex = 51;
            // 
            // dgvCalendario
            // 
            this.dgvCalendario.AllowUserToAddRows = false;
            this.dgvCalendario.AllowUserToDeleteRows = false;
            this.dgvCalendario.AllowUserToResizeColumns = false;
            this.dgvCalendario.AllowUserToResizeRows = false;
            this.dgvCalendario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCalendario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendario.EnableHeadersVisualStyles = false;
            this.dgvCalendario.Location = new System.Drawing.Point(12, 41);
            this.dgvCalendario.Name = "dgvCalendario";
            this.dgvCalendario.ReadOnly = true;
            this.dgvCalendario.RowHeadersWidth = 51;
            this.dgvCalendario.Size = new System.Drawing.Size(478, 323);
            this.dgvCalendario.TabIndex = 52;
            this.dgvCalendario.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCalendario_CellMouseDoubleClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(571, 404);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 38);
            this.btnEliminar.TabIndex = 53;
            this.btnEliminar.Text = "ELIMINAR VACACIONES";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // rbPagas
            // 
            this.rbPagas.AutoSize = true;
            this.rbPagas.Location = new System.Drawing.Point(43, 213);
            this.rbPagas.Name = "rbPagas";
            this.rbPagas.Size = new System.Drawing.Size(67, 17);
            this.rbPagas.TabIndex = 57;
            this.rbPagas.TabStop = true;
            this.rbPagas.Text = "Pagadas";
            this.rbPagas.UseVisualStyleBackColor = true;
            // 
            // rbSin
            // 
            this.rbSin.AutoSize = true;
            this.rbSin.Location = new System.Drawing.Point(134, 213);
            this.rbSin.Name = "rbSin";
            this.rbSin.Size = new System.Drawing.Size(116, 17);
            this.rbSin.TabIndex = 58;
            this.rbSin.TabStop = true;
            this.rbSin.Text = "Sin goce de sueldo";
            this.rbSin.UseVisualStyleBackColor = true;
            // 
            // frmVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(770, 624);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvCalendario);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.btnNuevoFeriado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmVacaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLEADOS - VACACIONES";
            this.Load += new System.EventHandler(this.frmVacaciones_Load);
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnNuevoFeriado;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.TextBox txtCantDia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSelec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.DataGridView dgvCalendario;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DateTimePicker dtpRegreso;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.RadioButton rbSin;
        private System.Windows.Forms.RadioButton rbPagas;
    }
}