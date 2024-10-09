namespace pryPlanificador
{
    partial class frmRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibo));
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtConsumos = new System.Windows.Forms.TextBox();
            this.txtADescontar = new System.Windows.Forms.TextBox();
            this.lblblblb = new System.Windows.Forms.Label();
            this.lblb = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gpDatos = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTotalResta = new System.Windows.Forms.Label();
            this.lblTotalSuma = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbExtrasResta = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbExtrasSuma = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPdf = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHsTrabajadas = new System.Windows.Forms.Label();
            this.txtHsTrabajadas = new System.Windows.Forms.TextBox();
            this.lblHsPlanificadas = new System.Windows.Forms.Label();
            this.txtHsPlanificadas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSelec = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gpInfo = new System.Windows.Forms.GroupBox();
            this.txtJornada = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiaVaca = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtAntiguedad = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtHoraNormal = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gpDatos.SuspendLayout();
            this.gpEmpleado.SuspendLayout();
            this.gpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.LimeGreen;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Transparent;
            this.txtTotal.Location = new System.Drawing.Point(148, 412);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(125, 29);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // txtConsumos
            // 
            this.txtConsumos.BackColor = System.Drawing.Color.Tomato;
            this.txtConsumos.Location = new System.Drawing.Point(239, 86);
            this.txtConsumos.MaxLength = 7;
            this.txtConsumos.Name = "txtConsumos";
            this.txtConsumos.Size = new System.Drawing.Size(108, 20);
            this.txtConsumos.TabIndex = 4;
            this.txtConsumos.Text = "0";
            this.txtConsumos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConsumos.TextChanged += new System.EventHandler(this.txtConsumos_TextChanged);
            // 
            // txtADescontar
            // 
            this.txtADescontar.BackColor = System.Drawing.Color.Tomato;
            this.txtADescontar.Location = new System.Drawing.Point(239, 119);
            this.txtADescontar.Name = "txtADescontar";
            this.txtADescontar.ReadOnly = true;
            this.txtADescontar.Size = new System.Drawing.Size(108, 20);
            this.txtADescontar.TabIndex = 6;
            this.txtADescontar.Text = "0";
            this.txtADescontar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtADescontar.TextChanged += new System.EventHandler(this.txtADescontar_TextChanged);
            // 
            // lblblblb
            // 
            this.lblblblb.AutoSize = true;
            this.lblblblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblblblb.Location = new System.Drawing.Point(8, 90);
            this.lblblblb.Name = "lblblblb";
            this.lblblblb.Size = new System.Drawing.Size(39, 16);
            this.lblblblb.TabIndex = 24;
            this.lblblblb.Text = "AÑO";
            // 
            // lblb
            // 
            this.lblb.AutoSize = true;
            this.lblb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblb.Location = new System.Drawing.Point(8, 61);
            this.lblb.Name = "lblb";
            this.lblb.Size = new System.Drawing.Size(39, 16);
            this.lblb.TabIndex = 23;
            this.lblb.Text = "MES";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Enabled = false;
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
            this.cmbMes.Location = new System.Drawing.Point(102, 62);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(145, 21);
            this.cmbMes.TabIndex = 25;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.Enabled = false;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.cmbAnio.Location = new System.Drawing.Point(102, 89);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(145, 21);
            this.cmbAnio.TabIndex = 26;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(313, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(392, 29);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "RECIBO DE SUELDO MENSUAL";
            // 
            // gpDatos
            // 
            this.gpDatos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gpDatos.Controls.Add(this.label23);
            this.gpDatos.Controls.Add(this.label22);
            this.gpDatos.Controls.Add(this.lblTotalResta);
            this.gpDatos.Controls.Add(this.lblTotalSuma);
            this.gpDatos.Controls.Add(this.label21);
            this.gpDatos.Controls.Add(this.lbExtrasResta);
            this.gpDatos.Controls.Add(this.label20);
            this.gpDatos.Controls.Add(this.lbExtrasSuma);
            this.gpDatos.Controls.Add(this.label11);
            this.gpDatos.Controls.Add(this.btnPdf);
            this.gpDatos.Controls.Add(this.label25);
            this.gpDatos.Controls.Add(this.label24);
            this.gpDatos.Controls.Add(this.label10);
            this.gpDatos.Controls.Add(this.label8);
            this.gpDatos.Controls.Add(this.lblHsTrabajadas);
            this.gpDatos.Controls.Add(this.txtHsTrabajadas);
            this.gpDatos.Controls.Add(this.lblHsPlanificadas);
            this.gpDatos.Controls.Add(this.txtHsPlanificadas);
            this.gpDatos.Controls.Add(this.label9);
            this.gpDatos.Controls.Add(this.label4);
            this.gpDatos.Controls.Add(this.label3);
            this.gpDatos.Controls.Add(this.label2);
            this.gpDatos.Controls.Add(this.label1);
            this.gpDatos.Controls.Add(this.txtTotal);
            this.gpDatos.Controls.Add(this.txtConsumos);
            this.gpDatos.Controls.Add(this.txtADescontar);
            this.gpDatos.Location = new System.Drawing.Point(651, 45);
            this.gpDatos.Name = "gpDatos";
            this.gpDatos.Size = new System.Drawing.Size(425, 513);
            this.gpDatos.TabIndex = 28;
            this.gpDatos.TabStop = false;
            this.gpDatos.Text = "DATOS MENSUALES";
            this.gpDatos.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(57, 335);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 20);
            this.label23.TabIndex = 76;
            this.label23.Text = "$";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(254, 335);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 20);
            this.label22.TabIndex = 75;
            this.label22.Text = "$";
            // 
            // lblTotalResta
            // 
            this.lblTotalResta.AutoSize = true;
            this.lblTotalResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResta.Location = new System.Drawing.Point(279, 335);
            this.lblTotalResta.Name = "lblTotalResta";
            this.lblTotalResta.Size = new System.Drawing.Size(19, 20);
            this.lblTotalResta.TabIndex = 74;
            this.lblTotalResta.Text = "0";
            // 
            // lblTotalSuma
            // 
            this.lblTotalSuma.AutoSize = true;
            this.lblTotalSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSuma.Location = new System.Drawing.Point(82, 335);
            this.lblTotalSuma.Name = "lblTotalSuma";
            this.lblTotalSuma.Size = new System.Drawing.Size(19, 20);
            this.lblTotalSuma.TabIndex = 73;
            this.lblTotalSuma.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(255, 166);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 16);
            this.label21.TabIndex = 72;
            this.label21.Text = "DEDUCCIONES";
            // 
            // lbExtrasResta
            // 
            this.lbExtrasResta.FormattingEnabled = true;
            this.lbExtrasResta.Location = new System.Drawing.Point(214, 185);
            this.lbExtrasResta.Name = "lbExtrasResta";
            this.lbExtrasResta.Size = new System.Drawing.Size(203, 147);
            this.lbExtrasResta.TabIndex = 72;
            this.lbExtrasResta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbExtrasResta_MouseDoubleClick);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Lime;
            this.label20.Location = new System.Drawing.Point(33, 166);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 16);
            this.label20.TabIndex = 71;
            this.label20.Text = "BONIFICACIONES";
            // 
            // lbExtrasSuma
            // 
            this.lbExtrasSuma.FormattingEnabled = true;
            this.lbExtrasSuma.Location = new System.Drawing.Point(5, 185);
            this.lbExtrasSuma.Name = "lbExtrasSuma";
            this.lbExtrasSuma.Size = new System.Drawing.Size(203, 147);
            this.lbExtrasSuma.TabIndex = 71;
            this.lbExtrasSuma.SelectedIndexChanged += new System.EventHandler(this.lbExtrasSuma_SelectedIndexChanged);
            this.lbExtrasSuma.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbExtrasSuma_MouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(128, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "$";
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(104, 458);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(207, 49);
            this.btnPdf.TabIndex = 62;
            this.btnPdf.Text = "CREAR PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(219, 122);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 68;
            this.label25.Text = "$";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(219, 90);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 67;
            this.label24.Text = "$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(219, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(219, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "$";
            // 
            // lblHsTrabajadas
            // 
            this.lblHsTrabajadas.AutoSize = true;
            this.lblHsTrabajadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHsTrabajadas.Location = new System.Drawing.Point(349, 48);
            this.lblHsTrabajadas.Name = "lblHsTrabajadas";
            this.lblHsTrabajadas.Size = new System.Drawing.Size(22, 13);
            this.lblHsTrabajadas.TabIndex = 61;
            this.lblHsTrabajadas.Text = "(0)";
            // 
            // txtHsTrabajadas
            // 
            this.txtHsTrabajadas.BackColor = System.Drawing.Color.Turquoise;
            this.txtHsTrabajadas.Enabled = false;
            this.txtHsTrabajadas.Location = new System.Drawing.Point(239, 44);
            this.txtHsTrabajadas.Name = "txtHsTrabajadas";
            this.txtHsTrabajadas.Size = new System.Drawing.Size(108, 20);
            this.txtHsTrabajadas.TabIndex = 60;
            this.txtHsTrabajadas.Text = "0";
            this.txtHsTrabajadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHsTrabajadas.TextChanged += new System.EventHandler(this.txtHsTrabajadas_TextChanged);
            // 
            // lblHsPlanificadas
            // 
            this.lblHsPlanificadas.AutoSize = true;
            this.lblHsPlanificadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHsPlanificadas.Location = new System.Drawing.Point(349, 23);
            this.lblHsPlanificadas.Name = "lblHsPlanificadas";
            this.lblHsPlanificadas.Size = new System.Drawing.Size(22, 13);
            this.lblHsPlanificadas.TabIndex = 59;
            this.lblHsPlanificadas.Text = "(0)";
            // 
            // txtHsPlanificadas
            // 
            this.txtHsPlanificadas.BackColor = System.Drawing.Color.Turquoise;
            this.txtHsPlanificadas.Enabled = false;
            this.txtHsPlanificadas.Location = new System.Drawing.Point(239, 19);
            this.txtHsPlanificadas.Name = "txtHsPlanificadas";
            this.txtHsPlanificadas.Size = new System.Drawing.Size(108, 20);
            this.txtHsPlanificadas.TabIndex = 58;
            this.txtHsPlanificadas.Text = "0";
            this.txtHsPlanificadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(70, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "HS PLANIFICADAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "DESCUENTO 20%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "CONSUMOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 31);
            this.label2.TabIndex = 31;
            this.label2.Text = "TOTAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "HS TRABAJADAS";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(103, 35);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(144, 21);
            this.cmbEmpleado.TabIndex = 30;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "EMPLEADO";
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.btnSelec);
            this.gpEmpleado.Controls.Add(this.label7);
            this.gpEmpleado.Controls.Add(this.cmbEmpleado);
            this.gpEmpleado.Controls.Add(this.lblb);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Controls.Add(this.cmbAnio);
            this.gpEmpleado.Controls.Add(this.cmbMes);
            this.gpEmpleado.Location = new System.Drawing.Point(373, 45);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(263, 171);
            this.gpEmpleado.TabIndex = 31;
            this.gpEmpleado.TabStop = false;
            this.gpEmpleado.Text = "SELECCIONE EMPLEADO Y PERÍODO";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Info;
            this.btnLimpiar.Location = new System.Drawing.Point(142, 129);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 26);
            this.btnLimpiar.TabIndex = 32;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSelec
            // 
            this.btnSelec.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelec.Enabled = false;
            this.btnSelec.Location = new System.Drawing.Point(26, 129);
            this.btnSelec.Name = "btnSelec";
            this.btnSelec.Size = new System.Drawing.Size(101, 26);
            this.btnSelec.TabIndex = 31;
            this.btnSelec.Text = "SELECCIONAR";
            this.btnSelec.UseVisualStyleBackColor = false;
            this.btnSelec.Click += new System.EventHandler(this.btnSelec_Click);
            // 
            // gpInfo
            // 
            this.gpInfo.Controls.Add(this.txtJornada);
            this.gpInfo.Controls.Add(this.label12);
            this.gpInfo.Controls.Add(this.lblId);
            this.gpInfo.Controls.Add(this.label13);
            this.gpInfo.Controls.Add(this.txtApellido);
            this.gpInfo.Controls.Add(this.label14);
            this.gpInfo.Controls.Add(this.txtDiaVaca);
            this.gpInfo.Controls.Add(this.label15);
            this.gpInfo.Controls.Add(this.label16);
            this.gpInfo.Controls.Add(this.txtMail);
            this.gpInfo.Controls.Add(this.txtAntiguedad);
            this.gpInfo.Controls.Add(this.label17);
            this.gpInfo.Controls.Add(this.label18);
            this.gpInfo.Controls.Add(this.txtNombre);
            this.gpInfo.Controls.Add(this.txtHoraNormal);
            this.gpInfo.Controls.Add(this.txtFecha);
            this.gpInfo.Controls.Add(this.label19);
            this.gpInfo.Controls.Add(this.pbFoto);
            this.gpInfo.Location = new System.Drawing.Point(12, 45);
            this.gpInfo.Name = "gpInfo";
            this.gpInfo.Size = new System.Drawing.Size(298, 459);
            this.gpInfo.TabIndex = 61;
            this.gpInfo.TabStop = false;
            this.gpInfo.Text = "INFORMACION";
            this.gpInfo.Visible = false;
            // 
            // txtJornada
            // 
            this.txtJornada.Enabled = false;
            this.txtJornada.Location = new System.Drawing.Point(176, 264);
            this.txtJornada.Name = "txtJornada";
            this.txtJornada.Size = new System.Drawing.Size(103, 20);
            this.txtJornada.TabIndex = 92;
            this.txtJornada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 16);
            this.label12.TabIndex = 93;
            this.label12.Text = "JORNADA (HS)";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(278, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(14, 13);
            this.lblId.TabIndex = 62;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 16);
            this.label13.TabIndex = 86;
            this.label13.Text = "APELLIDO";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(177, 51);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(102, 20);
            this.txtApellido.TabIndex = 85;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 78;
            this.label14.Text = "NOMBRE";
            // 
            // txtDiaVaca
            // 
            this.txtDiaVaca.Enabled = false;
            this.txtDiaVaca.Location = new System.Drawing.Point(177, 229);
            this.txtDiaVaca.Name = "txtDiaVaca";
            this.txtDiaVaca.Size = new System.Drawing.Size(102, 20);
            this.txtDiaVaca.TabIndex = 74;
            this.txtDiaVaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 75;
            this.label15.Text = "MAIL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 16);
            this.label16.TabIndex = 84;
            this.label16.Text = "ANTIGÜEDAD";
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(177, 89);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(102, 20);
            this.txtMail.TabIndex = 73;
            this.txtMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Enabled = false;
            this.txtAntiguedad.Location = new System.Drawing.Point(178, 162);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(102, 20);
            this.txtAntiguedad.TabIndex = 83;
            this.txtAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(142, 16);
            this.label17.TabIndex = 76;
            this.label17.Text = "DIAS VACACIONES";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 202);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 16);
            this.label18.TabIndex = 82;
            this.label18.Text = "HORA NORMAL";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(177, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 77;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHoraNormal
            // 
            this.txtHoraNormal.Enabled = false;
            this.txtHoraNormal.Location = new System.Drawing.Point(178, 198);
            this.txtHoraNormal.Name = "txtHoraNormal";
            this.txtHoraNormal.Size = new System.Drawing.Size(102, 20);
            this.txtHoraNormal.TabIndex = 81;
            this.txtHoraNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(177, 127);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(102, 20);
            this.txtFecha.TabIndex = 79;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(17, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(129, 16);
            this.label19.TabIndex = 80;
            this.label19.Text = "FECHA INGRESO";
            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(40, 306);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(199, 147);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 69;
            this.pbFoto.TabStop = false;
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAyuda.Location = new System.Drawing.Point(855, 564);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(107, 29);
            this.btnAyuda.TabIndex = 70;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(970, 564);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 29);
            this.btnSalir.TabIndex = 69;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1083, 605);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gpInfo);
            this.Controls.Add(this.gpEmpleado);
            this.Controls.Add(this.gpDatos);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLEADOS - RECIBO";
            this.Load += new System.EventHandler(this.frmRecibo_Load);
            this.gpDatos.ResumeLayout(false);
            this.gpDatos.PerformLayout();
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            this.gpInfo.ResumeLayout(false);
            this.gpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtConsumos;
        private System.Windows.Forms.TextBox txtADescontar;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gpDatos;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSelec;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gpInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiaVaca;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtAntiguedad;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtHoraNormal;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblHsTrabajadas;
        private System.Windows.Forms.TextBox txtHsTrabajadas;
        private System.Windows.Forms.Label lblHsPlanificadas;
        private System.Windows.Forms.TextBox txtHsPlanificadas;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtJornada;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbExtrasSuma;
        private System.Windows.Forms.ListBox lbExtrasResta;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTotalResta;
        private System.Windows.Forms.Label lblTotalSuma;
    }
}