namespace pryPlanificador
{
    partial class frmFeriados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeriados));
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblblblb = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.dgvFeriado = new System.Windows.Forms.DataGridView();
            this.gpNuevoFeriado = new System.Windows.Forms.GroupBox();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtFestejo = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAnioGp = new System.Windows.Forms.ComboBox();
            this.btnNuevoFeriado = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.gpEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriado)).BeginInit();
            this.gpNuevoFeriado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.button1);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Controls.Add(this.cmbAnio);
            this.gpEmpleado.Location = new System.Drawing.Point(12, 50);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(179, 89);
            this.gpEmpleado.TabIndex = 34;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "SELECCIONE PERIODO";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(98, 51);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(9, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblblblb
            // 
            this.lblblblb.AutoSize = true;
            this.lblblblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblblblb.Location = new System.Drawing.Point(6, 26);
            this.lblblblb.Name = "lblblblb";
            this.lblblblb.Size = new System.Drawing.Size(39, 16);
            this.lblblblb.TabIndex = 24;
            this.lblblblb.Text = "AÑO";
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAnio.Location = new System.Drawing.Point(52, 24);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(101, 21);
            this.cmbAnio.TabIndex = 26;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // dgvFeriado
            // 
            this.dgvFeriado.AllowUserToAddRows = false;
            this.dgvFeriado.AllowUserToDeleteRows = false;
            this.dgvFeriado.AllowUserToResizeColumns = false;
            this.dgvFeriado.AllowUserToResizeRows = false;
            this.dgvFeriado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFeriado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFeriado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeriado.EnableHeadersVisualStyles = false;
            this.dgvFeriado.Location = new System.Drawing.Point(206, 50);
            this.dgvFeriado.Name = "dgvFeriado";
            this.dgvFeriado.ReadOnly = true;
            this.dgvFeriado.RowHeadersWidth = 51;
            this.dgvFeriado.Size = new System.Drawing.Size(497, 528);
            this.dgvFeriado.TabIndex = 33;
            this.dgvFeriado.Visible = false;
            this.dgvFeriado.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFeriado_CellMouseDoubleClick);
            // 
            // gpNuevoFeriado
            // 
            this.gpNuevoFeriado.Controls.Add(this.cmbDia);
            this.gpNuevoFeriado.Controls.Add(this.lblId);
            this.gpNuevoFeriado.Controls.Add(this.label4);
            this.gpNuevoFeriado.Controls.Add(this.btnEliminar);
            this.gpNuevoFeriado.Controls.Add(this.btnCancelar);
            this.gpNuevoFeriado.Controls.Add(this.txtFestejo);
            this.gpNuevoFeriado.Controls.Add(this.txtFecha);
            this.gpNuevoFeriado.Controls.Add(this.label3);
            this.gpNuevoFeriado.Controls.Add(this.label2);
            this.gpNuevoFeriado.Controls.Add(this.btnAgregar);
            this.gpNuevoFeriado.Controls.Add(this.label1);
            this.gpNuevoFeriado.Controls.Add(this.cmbAnioGp);
            this.gpNuevoFeriado.Location = new System.Drawing.Point(12, 190);
            this.gpNuevoFeriado.Name = "gpNuevoFeriado";
            this.gpNuevoFeriado.Size = new System.Drawing.Size(173, 388);
            this.gpNuevoFeriado.TabIndex = 35;
            this.gpNuevoFeriado.TabStop = false;
            this.gpNuevoFeriado.Text = "NUEVO FERIADO";
            this.gpNuevoFeriado.Visible = false;
            // 
            // cmbDia
            // 
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.Enabled = false;
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.cmbDia.Location = new System.Drawing.Point(23, 184);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(119, 21);
            this.cmbDia.TabIndex = 41;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(136, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 16);
            this.lblId.TabIndex = 40;
            this.lblId.Text = "1";
            this.lblId.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "DÍA";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(25, 325);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 23);
            this.btnEliminar.TabIndex = 37;
            this.btnEliminar.Text = "ELIMINAR FERIADO";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelar.Location = new System.Drawing.Point(25, 354);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 23);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtFestejo
            // 
            this.txtFestejo.Enabled = false;
            this.txtFestejo.Location = new System.Drawing.Point(22, 110);
            this.txtFestejo.Name = "txtFestejo";
            this.txtFestejo.Size = new System.Drawing.Size(119, 20);
            this.txtFestejo.TabIndex = 32;
            this.txtFestejo.TextChanged += new System.EventHandler(this.txtFestejo_TextChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(25, 45);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(119, 20);
            this.txtFecha.TabIndex = 31;
            this.txtFecha.TextChanged += new System.EventHandler(this.txtFecha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "FESTEJO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "FECHA (dd/mm/aaaa)";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(25, 296);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 23);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "AÑO";
            // 
            // cmbAnioGp
            // 
            this.cmbAnioGp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioGp.Enabled = false;
            this.cmbAnioGp.FormattingEnabled = true;
            this.cmbAnioGp.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAnioGp.Location = new System.Drawing.Point(25, 245);
            this.cmbAnioGp.Name = "cmbAnioGp";
            this.cmbAnioGp.Size = new System.Drawing.Size(119, 21);
            this.cmbAnioGp.TabIndex = 26;
            this.cmbAnioGp.SelectedIndexChanged += new System.EventHandler(this.cmbAnioGp_SelectedIndexChanged);
            // 
            // btnNuevoFeriado
            // 
            this.btnNuevoFeriado.BackColor = System.Drawing.Color.Green;
            this.btnNuevoFeriado.Enabled = false;
            this.btnNuevoFeriado.Location = new System.Drawing.Point(12, 145);
            this.btnNuevoFeriado.Name = "btnNuevoFeriado";
            this.btnNuevoFeriado.Size = new System.Drawing.Size(179, 39);
            this.btnNuevoFeriado.TabIndex = 36;
            this.btnNuevoFeriado.Text = "NUEVO FERIADO";
            this.btnNuevoFeriado.UseVisualStyleBackColor = false;
            this.btnNuevoFeriado.Visible = false;
            this.btnNuevoFeriado.Click += new System.EventHandler(this.btnNuevoFeriado_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(231, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(142, 29);
            this.lblTitulo.TabIndex = 37;
            this.lblTitulo.Text = "FERIADOS";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(613, 584);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 22);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(513, 584);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(92, 22);
            this.btnAyuda.TabIndex = 38;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // frmFeriados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(715, 616);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnNuevoFeriado);
            this.Controls.Add(this.gpNuevoFeriado);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.dgvFeriado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFeriados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDICION - FERIADOS";
            this.Load += new System.EventHandler(this.frmFeriados_Load);
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriado)).EndInit();
            this.gpNuevoFeriado.ResumeLayout(false);
            this.gpNuevoFeriado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.DataGridView dgvFeriado;
        private System.Windows.Forms.GroupBox gpNuevoFeriado;
        private System.Windows.Forms.TextBox txtFestejo;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAnioGp;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevoFeriado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.ComboBox cmbDia;
    }
}