namespace pryPlanificador
{
    partial class frmPlanificar
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
            this.dgvHora = new System.Windows.Forms.DataGridView();
            this.gpCmb = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).BeginInit();
            this.gpCmb.SuspendLayout();
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
            this.dgvHora.Location = new System.Drawing.Point(12, 43);
            this.dgvHora.Name = "dgvHora";
            this.dgvHora.Size = new System.Drawing.Size(1063, 667);
            this.dgvHora.TabIndex = 0;
            this.dgvHora.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHora_CellMouseDoubleClick);
            this.dgvHora.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvHora_RowsAdded);
            // 
            // gpCmb
            // 
            this.gpCmb.Controls.Add(this.btnModificar);
            this.gpCmb.Controls.Add(this.cmbTurno);
            this.gpCmb.Location = new System.Drawing.Point(1152, 196);
            this.gpCmb.Name = "gpCmb";
            this.gpCmb.Size = new System.Drawing.Size(200, 100);
            this.gpCmb.TabIndex = 1;
            this.gpCmb.TabStop = false;
            this.gpCmb.Text = "Seleccione un turno";
            this.gpCmb.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(60, 59);
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
            this.cmbTurno.Location = new System.Drawing.Point(38, 31);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(121, 21);
            this.cmbTurno.TabIndex = 0;
            this.cmbTurno.SelectedIndexChanged += new System.EventHandler(this.cmbTurno_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1321, 687);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(283, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(382, 29);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "PLANIFICADOR DE HORARIOS";
            // 
            // txtMes
            // 
            this.txtMes.Enabled = false;
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(1122, 127);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(100, 20);
            this.txtMes.TabIndex = 4;
            this.txtMes.Text = "OCTUBRE";
            // 
            // txtAnio
            // 
            this.txtAnio.Enabled = false;
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(1277, 127);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 5;
            this.txtAnio.Text = "2023";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(1149, 108);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(39, 16);
            this.lblMes.TabIndex = 6;
            this.lblMes.Text = "MES";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(1303, 108);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(39, 16);
            this.lblAnio.TabIndex = 7;
            this.lblAnio.Text = "AÑO";
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(1236, 687);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(75, 23);
            this.btnAyuda.TabIndex = 8;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = true;
            // 
            // frmPlanificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1408, 722);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gpCmb);
            this.Controls.Add(this.dgvHora);
            this.Name = "frmPlanificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEAMIENTO - PLANIFICADOR DE HORARIOS";
            this.Load += new System.EventHandler(this.fmPlanificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).EndInit();
            this.gpCmb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHora;
        private System.Windows.Forms.GroupBox gpCmb;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Button btnAyuda;
    }
}