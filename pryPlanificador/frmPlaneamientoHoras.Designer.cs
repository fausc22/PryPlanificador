namespace pryPlanificador
{
    partial class frmPlaneamientoHoras
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
            this.dgvTotales = new System.Windows.Forms.DataGridView();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblb = new System.Windows.Forms.Label();
            this.lblblblb = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
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
            this.dgvHora.Location = new System.Drawing.Point(281, 41);
            this.dgvHora.Name = "dgvHora";
            this.dgvHora.RowHeadersWidth = 51;
            this.dgvHora.Size = new System.Drawing.Size(1063, 533);
            this.dgvHora.TabIndex = 10;
            // 
            // dgvTotales
            // 
            this.dgvTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotales.Location = new System.Drawing.Point(281, 580);
            this.dgvTotales.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.RowHeadersWidth = 51;
            this.dgvTotales.RowTemplate.Height = 24;
            this.dgvTotales.Size = new System.Drawing.Size(1063, 50);
            this.dgvTotales.TabIndex = 27;
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.button1);
            this.gpEmpleado.Controls.Add(this.lblb);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Controls.Add(this.cmbAnio);
            this.gpEmpleado.Controls.Add(this.cmbMes);
            this.gpEmpleado.Location = new System.Drawing.Point(35, 41);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(170, 151);
            this.gpEmpleado.TabIndex = 33;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "SELECCIONE PERIODO";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(45, 112);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Modificar";
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
            this.lblTitulo.Location = new System.Drawing.Point(697, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 29);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "HORAS TRABAJADAS";
            // 
            // frmPlaneamientoHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1356, 643);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.dgvTotales);
            this.Controls.Add(this.dgvHora);
            this.Name = "frmPlaneamientoHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEAMIENTO - HORAS TRABAJADAS";
            this.Load += new System.EventHandler(this.frmPlaneamientoHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHora;
        private System.Windows.Forms.DataGridView dgvTotales;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblTitulo;
    }
}