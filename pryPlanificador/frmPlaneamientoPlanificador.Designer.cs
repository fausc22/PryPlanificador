namespace pryPlanificador
{
    partial class frmPlaneamientoPlanificador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaneamientoPlanificador));
            this.dgvHora = new System.Windows.Forms.DataGridView();
            this.gpCmb = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblb = new System.Windows.Forms.Label();
            this.lblblblb = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).BeginInit();
            this.gpCmb.SuspendLayout();
            this.gpEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHora
            // 
            this.dgvHora.AllowUserToAddRows = false;
            this.dgvHora.AllowUserToDeleteRows = false;
            this.dgvHora.AllowUserToResizeColumns = false;
            this.dgvHora.AllowUserToResizeRows = false;
            this.dgvHora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHora.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHora.EnableHeadersVisualStyles = false;
            this.dgvHora.Location = new System.Drawing.Point(188, 60);
            this.dgvHora.Name = "dgvHora";
            this.dgvHora.ReadOnly = true;
            this.dgvHora.RowHeadersWidth = 51;
            this.dgvHora.Size = new System.Drawing.Size(1156, 529);
            this.dgvHora.TabIndex = 1;
            this.dgvHora.Visible = false;
            this.dgvHora.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHora_CellMouseDoubleClick);
            // 
            // gpCmb
            // 
            this.gpCmb.Controls.Add(this.btnModificar);
            this.gpCmb.Controls.Add(this.cmbTurno);
            this.gpCmb.Location = new System.Drawing.Point(12, 217);
            this.gpCmb.Name = "gpCmb";
            this.gpCmb.Size = new System.Drawing.Size(170, 95);
            this.gpCmb.TabIndex = 2;
            this.gpCmb.TabStop = false;
            this.gpCmb.Text = "SELECCIONE UN TURNO";
            this.gpCmb.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(45, 55);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbTurno
            // 
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Location = new System.Drawing.Point(29, 28);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(101, 21);
            this.cmbTurno.TabIndex = 0;
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.button1);
            this.gpEmpleado.Controls.Add(this.lblb);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Controls.Add(this.cmbAnio);
            this.gpEmpleado.Controls.Add(this.cmbMes);
            this.gpEmpleado.Location = new System.Drawing.Point(12, 60);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(170, 151);
            this.gpEmpleado.TabIndex = 32;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "SELECCIONE PERIODO";
            this.gpEmpleado.Enter += new System.EventHandler(this.gpEmpleado_Enter);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(45, 112);
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
            this.button1.Location = new System.Drawing.Point(45, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblb
            // 
            this.lblb.AutoSize = true;
            this.lblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblb.Location = new System.Drawing.Point(6, 29);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(39, 16);
            this.lblb.TabIndex = 23;
            this.lblb.Text = "MES";
            // 
            // lblblblb
            // 
            this.lblblblb.AutoSize = true;
            this.lblblblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblblblb.Location = new System.Drawing.Point(6, 58);
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
            this.cmbAnio.Location = new System.Drawing.Point(52, 56);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(101, 21);
            this.cmbAnio.TabIndex = 26;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cmbMes.Location = new System.Drawing.Point(52, 29);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(101, 21);
            this.cmbMes.TabIndex = 25;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(440, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(382, 29);
            this.lblTitulo.TabIndex = 33;
            this.lblTitulo.Text = "PLANIFICADOR DE HORARIOS";
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(1140, 595);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(92, 22);
            this.btnAyuda.TabIndex = 34;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1240, 595);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 22);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmPlaneamientoPlanificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1356, 629);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.gpCmb);
            this.Controls.Add(this.dgvHora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlaneamientoPlanificador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEAMIENTO - PLANIFICADOR DE HORARIOS";
            this.Load += new System.EventHandler(this.frmPlaneamientoPlanificador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).EndInit();
            this.gpCmb.ResumeLayout(false);
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHora;
        private System.Windows.Forms.GroupBox gpCmb;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;
    }
}