namespace pryPlanificador
{
    partial class frmHoras
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
            this.btnAyuda = new System.Windows.Forms.Button();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvHora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(1647, 847);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(100, 28);
            this.btnAyuda.TabIndex = 17;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = true;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(1736, 134);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(39, 16);
            this.lblAnio.TabIndex = 16;
            this.lblAnio.Text = "AÑO";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(1531, 134);
            this.lblMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(39, 16);
            this.lblMes.TabIndex = 15;
            this.lblMes.Text = "MES";
            // 
            // txtAnio
            // 
            this.txtAnio.Enabled = false;
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(1701, 158);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(132, 20);
            this.txtAnio.TabIndex = 14;
            this.txtAnio.Text = "2023";
            // 
            // txtMes
            // 
            this.txtMes.Enabled = false;
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(1495, 158);
            this.txtMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(132, 20);
            this.txtMes.TabIndex = 13;
            this.txtMes.Text = "OCTUBRE";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(376, 12);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 29);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "HORAS TRABAJADAS";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1760, 847);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.dgvHora.Location = new System.Drawing.Point(15, 54);
            this.dgvHora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHora.Name = "dgvHora";
            this.dgvHora.Size = new System.Drawing.Size(1417, 821);
            this.dgvHora.TabIndex = 9;
            this.dgvHora.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHora_CellMouseDoubleClick);
            // 
            // frmHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1876, 887);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvHora);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEAMIENTO - HORAS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvHora;
    }
}