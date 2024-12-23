namespace Planificador
{
    partial class frmAuxRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuxRecibo));
            this.gpFinal = new System.Windows.Forms.GroupBox();
            this.btnSelec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gpFinal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpFinal
            // 
            this.gpFinal.Controls.Add(this.button1);
            this.gpFinal.Controls.Add(this.btnSelec);
            this.gpFinal.Controls.Add(this.label1);
            this.gpFinal.Controls.Add(this.label2);
            this.gpFinal.Controls.Add(this.txtDescripcion);
            this.gpFinal.Controls.Add(this.label3);
            this.gpFinal.Controls.Add(this.label4);
            this.gpFinal.Controls.Add(this.txtMonto);
            this.gpFinal.Controls.Add(this.txtCategoria);
            this.gpFinal.Location = new System.Drawing.Point(12, 41);
            this.gpFinal.Name = "gpFinal";
            this.gpFinal.Size = new System.Drawing.Size(304, 366);
            this.gpFinal.TabIndex = 51;
            this.gpFinal.TabStop = false;
            // 
            // btnSelec
            // 
            this.btnSelec.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSelec.Location = new System.Drawing.Point(92, 239);
            this.btnSelec.Name = "btnSelec";
            this.btnSelec.Size = new System.Drawing.Size(120, 45);
            this.btnSelec.TabIndex = 48;
            this.btnSelec.Text = "MODIFICAR EXTRA";
            this.btnSelec.UseVisualStyleBackColor = false;
            this.btnSelec.Click += new System.EventHandler(this.btnSelec_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "CATEGORIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "MONTO ($)";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(29, 132);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(236, 101);
            this.txtDescripcion.TabIndex = 38;
            this.txtDescripcion.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "DESCRIPCION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "$";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(77, 78);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(145, 20);
            this.txtMonto.TabIndex = 36;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(77, 36);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(145, 20);
            this.txtCategoria.TabIndex = 46;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(23, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(278, 29);
            this.lblTitulo.TabIndex = 52;
            this.lblTitulo.Text = "EDITAR PAGO EXTRA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(92, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 49;
            this.button1.Text = "ELIMINAR EXTRA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAuxRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(329, 419);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gpFinal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAuxRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECIBO - EDITAR PAGO EXTRA";
            this.Load += new System.EventHandler(this.frmAuxRecibo_Load);
            this.gpFinal.ResumeLayout(false);
            this.gpFinal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnSelec;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button button1;
    }
}