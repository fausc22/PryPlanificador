namespace Planificador
{
    partial class frmAuxFiltroProduc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuxFiltroProduc));
            this.label11 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lbProductos = new System.Windows.Forms.ListBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(43, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "BUSCAR PRODUCTO";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(47, 32);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(182, 20);
            this.txtProducto.TabIndex = 83;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // lbProductos
            // 
            this.lbProductos.FormattingEnabled = true;
            this.lbProductos.Location = new System.Drawing.Point(12, 129);
            this.lbProductos.Name = "lbProductos";
            this.lbProductos.Size = new System.Drawing.Size(248, 225);
            this.lbProductos.TabIndex = 85;
            this.lbProductos.Visible = false;
            this.lbProductos.DoubleClick += new System.EventHandler(this.lbProductos_DoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Info;
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(89, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 32);
            this.btnBuscar.TabIndex = 86;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmAuxFiltroProduc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(272, 496);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lbProductos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtProducto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAuxFiltroProduc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR PRODUCTO";
            this.Load += new System.EventHandler(this.frmAuxFiltroProduc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.ListBox lbProductos;
        private System.Windows.Forms.Button btnBuscar;
    }
}