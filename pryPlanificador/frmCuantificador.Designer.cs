namespace pryPlanificador
{
    partial class frmCuantificador
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
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvHora = new System.Windows.Forms.DataGridView();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(1750, 135);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(39, 16);
            this.lblAnio.TabIndex = 22;
            this.lblAnio.Text = "AÑO";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(1545, 135);
            this.lblMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(39, 16);
            this.lblMes.TabIndex = 21;
            this.lblMes.Text = "MES";
            // 
            // txtAnio
            // 
            this.txtAnio.Enabled = false;
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(1715, 159);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(132, 20);
            this.txtAnio.TabIndex = 20;
            this.txtAnio.Text = "2023";
            // 
            // txtMes
            // 
            this.txtMes.Enabled = false;
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(1509, 159);
            this.txtMes.Margin = new System.Windows.Forms.Padding(4);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(132, 20);
            this.txtMes.TabIndex = 19;
            this.txtMes.Text = "OCTUBRE";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(390, 13);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(482, 29);
            this.lblTitulo.TabIndex = 18;
            this.lblTitulo.Text = "HORAS TRABAJADAS + TARIFA ($ARS)";
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
            this.dgvHora.Location = new System.Drawing.Point(29, 55);
            this.dgvHora.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHora.Name = "dgvHora";
            this.dgvHora.Size = new System.Drawing.Size(1417, 821);
            this.dgvHora.TabIndex = 17;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Location = new System.Drawing.Point(1651, 848);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(4);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(100, 28);
            this.btnAyuda.TabIndex = 24;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1764, 848);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmCuantificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1877, 889);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvHora);
            this.Name = "frmCuantificador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANEAMIENTO - CUANTIFICADOR";
            this.Load += new System.EventHandler(this.frmCuantificador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvHora;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;
    }
}