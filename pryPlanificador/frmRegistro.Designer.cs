namespace Planificador
{
    partial class frmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistro));
            this.gpForm = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optEgreso = new System.Windows.Forms.RadioButton();
            this.optIngreso = new System.Windows.Forms.RadioButton();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpForm
            // 
            this.gpForm.Controls.Add(this.label4);
            this.gpForm.Controls.Add(this.txtHora);
            this.gpForm.Controls.Add(this.txtContrasenia);
            this.gpForm.Controls.Add(this.label2);
            this.gpForm.Controls.Add(this.optEgreso);
            this.gpForm.Controls.Add(this.optIngreso);
            this.gpForm.Controls.Add(this.btnRegistrar);
            this.gpForm.Controls.Add(this.label3);
            this.gpForm.Controls.Add(this.txtNombre);
            this.gpForm.Controls.Add(this.txtFecha);
            this.gpForm.Controls.Add(this.label1);
            this.gpForm.Location = new System.Drawing.Point(11, 11);
            this.gpForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpForm.Name = "gpForm";
            this.gpForm.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpForm.Size = new System.Drawing.Size(373, 279);
            this.gpForm.TabIndex = 11;
            this.gpForm.TabStop = false;
            this.gpForm.Text = "INGRESE SUS DATOS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "HORA (hh:mm:ss)";
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(204, 101);
            this.txtHora.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(139, 20);
            this.txtHora.TabIndex = 21;
            this.txtHora.TextChanged += new System.EventHandler(this.txtHora_TextChanged);
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Enabled = false;
            this.txtContrasenia.Location = new System.Drawing.Point(20, 99);
            this.txtContrasenia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContrasenia.MaxLength = 4;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(128, 20);
            this.txtContrasenia.TabIndex = 20;
            this.txtContrasenia.UseSystemPasswordChar = true;
            this.txtContrasenia.TextChanged += new System.EventHandler(this.txtContrasenia_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "CONTRASEÑA";
            // 
            // optEgreso
            // 
            this.optEgreso.AutoSize = true;
            this.optEgreso.Enabled = false;
            this.optEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEgreso.Location = new System.Drawing.Point(125, 175);
            this.optEgreso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.optEgreso.Name = "optEgreso";
            this.optEgreso.Size = new System.Drawing.Size(97, 22);
            this.optEgreso.TabIndex = 18;
            this.optEgreso.TabStop = true;
            this.optEgreso.Text = "EGRESO";
            this.optEgreso.UseVisualStyleBackColor = true;
            this.optEgreso.CheckedChanged += new System.EventHandler(this.optEgreso_CheckedChanged);
            // 
            // optIngreso
            // 
            this.optIngreso.AutoSize = true;
            this.optIngreso.Enabled = false;
            this.optIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optIngreso.Location = new System.Drawing.Point(125, 149);
            this.optIngreso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.optIngreso.Name = "optIngreso";
            this.optIngreso.Size = new System.Drawing.Size(102, 22);
            this.optIngreso.TabIndex = 17;
            this.optIngreso.TabStop = true;
            this.optIngreso.Text = "INGRESO";
            this.optIngreso.UseVisualStyleBackColor = true;
            this.optIngreso.CheckedChanged += new System.EventHandler(this.optIngreso_CheckedChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Location = new System.Drawing.Point(90, 214);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(167, 44);
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "FECHA (dd/mm/aaaa)";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(20, 49);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(128, 20);
            this.txtNombre.TabIndex = 14;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(204, 49);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(139, 20);
            this.txtFecha.TabIndex = 13;
            this.txtFecha.TextChanged += new System.EventHandler(this.txtFecha_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "NOMBRE";
            // 
            // frmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 304);
            this.Controls.Add(this.gpForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Manual";
            this.Load += new System.EventHandler(this.frmRegistro_Load);
            this.gpForm.ResumeLayout(false);
            this.gpForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpForm;
        private System.Windows.Forms.RadioButton optEgreso;
        private System.Windows.Forms.RadioButton optIngreso;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHora;
    }
}