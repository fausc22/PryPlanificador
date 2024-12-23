namespace Planificador
{
    partial class frmGraficos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraficos));
            this.gpDatos = new System.Windows.Forms.GroupBox();
            this.lblGananciaDiaMenosProductivo = new System.Windows.Forms.Label();
            this.lblTotalDiaMenosProductivo = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.lblTotalGanancias = new System.Windows.Forms.Label();
            this.lblDiaMenosProductivo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblGananciaDiaMasProductivo = new System.Windows.Forms.Label();
            this.lblTotalDiaMasProductivo = new System.Windows.Forms.Label();
            this.lblDiaMasProductivo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chartPromediosGanancias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPromedioIngresos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpEmpleado = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblb = new System.Windows.Forms.Label();
            this.lblblblb = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.dgVentasDia = new System.Windows.Forms.DataGridView();
            this.chartMediosPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tcContenido = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartVariacionHoras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelCargando = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCargando = new System.Windows.Forms.PictureBox();
            this.gpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromediosGanancias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromedioIngresos)).BeginInit();
            this.gpEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).BeginInit();
            this.tcContenido.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVariacionHoras)).BeginInit();
            this.panelCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // gpDatos
            // 
            this.gpDatos.Controls.Add(this.lblGananciaDiaMenosProductivo);
            this.gpDatos.Controls.Add(this.lblTotalDiaMenosProductivo);
            this.gpDatos.Controls.Add(this.lblTotalIngresos);
            this.gpDatos.Controls.Add(this.lblTotalGanancias);
            this.gpDatos.Controls.Add(this.lblDiaMenosProductivo);
            this.gpDatos.Controls.Add(this.label10);
            this.gpDatos.Controls.Add(this.lblGananciaDiaMasProductivo);
            this.gpDatos.Controls.Add(this.lblTotalDiaMasProductivo);
            this.gpDatos.Controls.Add(this.lblDiaMasProductivo);
            this.gpDatos.Controls.Add(this.label3);
            this.gpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDatos.Location = new System.Drawing.Point(435, 6);
            this.gpDatos.Name = "gpDatos";
            this.gpDatos.Size = new System.Drawing.Size(681, 577);
            this.gpDatos.TabIndex = 77;
            this.gpDatos.TabStop = false;
            this.gpDatos.Text = "DATOS RELEVANTES";
            this.gpDatos.Visible = false;
            // 
            // lblGananciaDiaMenosProductivo
            // 
            this.lblGananciaDiaMenosProductivo.AutoSize = true;
            this.lblGananciaDiaMenosProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGananciaDiaMenosProductivo.ForeColor = System.Drawing.Color.Green;
            this.lblGananciaDiaMenosProductivo.Location = new System.Drawing.Point(6, 525);
            this.lblGananciaDiaMenosProductivo.Name = "lblGananciaDiaMenosProductivo";
            this.lblGananciaDiaMenosProductivo.Size = new System.Drawing.Size(316, 37);
            this.lblGananciaDiaMenosProductivo.TabIndex = 9;
            this.lblGananciaDiaMenosProductivo.Text = "GANANCIAS: $2222";
            // 
            // lblTotalDiaMenosProductivo
            // 
            this.lblTotalDiaMenosProductivo.AutoSize = true;
            this.lblTotalDiaMenosProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiaMenosProductivo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalDiaMenosProductivo.Location = new System.Drawing.Point(11, 475);
            this.lblTotalDiaMenosProductivo.Name = "lblTotalDiaMenosProductivo";
            this.lblTotalDiaMenosProductivo.Size = new System.Drawing.Size(266, 37);
            this.lblTotalDiaMenosProductivo.TabIndex = 8;
            this.lblTotalDiaMenosProductivo.Text = "TOTAL: $200000";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTotalIngresos.Location = new System.Drawing.Point(19, 49);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(484, 39);
            this.lblTotalIngresos.TabIndex = 79;
            this.lblTotalIngresos.Text = "TOTAL INGRESOS: $ 22222";
            this.lblTotalIngresos.Visible = false;
            // 
            // lblTotalGanancias
            // 
            this.lblTotalGanancias.AutoSize = true;
            this.lblTotalGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGanancias.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalGanancias.Location = new System.Drawing.Point(19, 104);
            this.lblTotalGanancias.Name = "lblTotalGanancias";
            this.lblTotalGanancias.Size = new System.Drawing.Size(506, 39);
            this.lblTotalGanancias.TabIndex = 78;
            this.lblTotalGanancias.Text = "TOTAL GANANCIAS: $ 22222";
            this.lblTotalGanancias.Visible = false;
            // 
            // lblDiaMenosProductivo
            // 
            this.lblDiaMenosProductivo.AutoSize = true;
            this.lblDiaMenosProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaMenosProductivo.ForeColor = System.Drawing.Color.Orange;
            this.lblDiaMenosProductivo.Location = new System.Drawing.Point(19, 426);
            this.lblDiaMenosProductivo.Name = "lblDiaMenosProductivo";
            this.lblDiaMenosProductivo.Size = new System.Drawing.Size(291, 37);
            this.lblDiaMenosProductivo.TabIndex = 7;
            this.lblDiaMenosProductivo.Text = "LUNES 01/10/2024";
            this.lblDiaMenosProductivo.Click += new System.EventHandler(this.lblDiaMenosProductivo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 384);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(437, 37);
            this.label10.TabIndex = 6;
            this.label10.Text = "DÍA MENOS PRODUCTIVO";
            // 
            // lblGananciaDiaMasProductivo
            // 
            this.lblGananciaDiaMasProductivo.AutoSize = true;
            this.lblGananciaDiaMasProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGananciaDiaMasProductivo.ForeColor = System.Drawing.Color.Green;
            this.lblGananciaDiaMasProductivo.Location = new System.Drawing.Point(19, 317);
            this.lblGananciaDiaMasProductivo.Name = "lblGananciaDiaMasProductivo";
            this.lblGananciaDiaMasProductivo.Size = new System.Drawing.Size(316, 37);
            this.lblGananciaDiaMasProductivo.TabIndex = 5;
            this.lblGananciaDiaMasProductivo.Text = "GANANCIAS: $2222";
            // 
            // lblTotalDiaMasProductivo
            // 
            this.lblTotalDiaMasProductivo.AutoSize = true;
            this.lblTotalDiaMasProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiaMasProductivo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalDiaMasProductivo.Location = new System.Drawing.Point(19, 268);
            this.lblTotalDiaMasProductivo.Name = "lblTotalDiaMasProductivo";
            this.lblTotalDiaMasProductivo.Size = new System.Drawing.Size(266, 37);
            this.lblTotalDiaMasProductivo.TabIndex = 4;
            this.lblTotalDiaMasProductivo.Text = "TOTAL: $200000";
            // 
            // lblDiaMasProductivo
            // 
            this.lblDiaMasProductivo.AutoSize = true;
            this.lblDiaMasProductivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaMasProductivo.ForeColor = System.Drawing.Color.Orange;
            this.lblDiaMasProductivo.Location = new System.Drawing.Point(19, 215);
            this.lblDiaMasProductivo.Name = "lblDiaMasProductivo";
            this.lblDiaMasProductivo.Size = new System.Drawing.Size(291, 37);
            this.lblDiaMasProductivo.TabIndex = 2;
            this.lblDiaMasProductivo.Text = "LUNES 01/10/2024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "DÍA MAS PRODUCTIVO";
            // 
            // chartPromediosGanancias
            // 
            this.chartPromediosGanancias.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea1.Name = "ChartArea1";
            this.chartPromediosGanancias.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPromediosGanancias.Legends.Add(legend1);
            this.chartPromediosGanancias.Location = new System.Drawing.Point(15, 304);
            this.chartPromediosGanancias.Name = "chartPromediosGanancias";
            this.chartPromediosGanancias.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPromediosGanancias.Series.Add(series1);
            this.chartPromediosGanancias.Size = new System.Drawing.Size(449, 265);
            this.chartPromediosGanancias.TabIndex = 13;
            this.chartPromediosGanancias.Text = "chart2";
            this.chartPromediosGanancias.Visible = false;
            // 
            // chartPromedioIngresos
            // 
            this.chartPromedioIngresos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.Name = "ChartArea1";
            this.chartPromedioIngresos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPromedioIngresos.Legends.Add(legend2);
            this.chartPromedioIngresos.Location = new System.Drawing.Point(15, 42);
            this.chartPromedioIngresos.Name = "chartPromedioIngresos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPromedioIngresos.Series.Add(series2);
            this.chartPromedioIngresos.Size = new System.Drawing.Size(449, 256);
            this.chartPromedioIngresos.TabIndex = 12;
            this.chartPromedioIngresos.Text = "chart1";
            this.chartPromedioIngresos.Visible = false;
            // 
            // gpEmpleado
            // 
            this.gpEmpleado.Controls.Add(this.btnLimpiar);
            this.gpEmpleado.Controls.Add(this.button1);
            this.gpEmpleado.Controls.Add(this.lblb);
            this.gpEmpleado.Controls.Add(this.lblblblb);
            this.gpEmpleado.Controls.Add(this.cmbAnio);
            this.gpEmpleado.Controls.Add(this.cmbMes);
            this.gpEmpleado.Location = new System.Drawing.Point(12, 13);
            this.gpEmpleado.Name = "gpEmpleado";
            this.gpEmpleado.Size = new System.Drawing.Size(164, 151);
            this.gpEmpleado.TabIndex = 75;
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            "2018",
            "2019",
            "2020",
            "2021",
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
            // dgVentasDia
            // 
            this.dgVentasDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVentasDia.Location = new System.Drawing.Point(6, 6);
            this.dgVentasDia.Name = "dgVentasDia";
            this.dgVentasDia.Size = new System.Drawing.Size(423, 577);
            this.dgVentasDia.TabIndex = 74;
            this.dgVentasDia.Visible = false;
            // 
            // chartMediosPago
            // 
            this.chartMediosPago.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea3.Name = "ChartArea1";
            this.chartMediosPago.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMediosPago.Legends.Add(legend3);
            this.chartMediosPago.Location = new System.Drawing.Point(588, 42);
            this.chartMediosPago.Name = "chartMediosPago";
            this.chartMediosPago.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMediosPago.Series.Add(series3);
            this.chartMediosPago.Size = new System.Drawing.Size(449, 256);
            this.chartMediosPago.TabIndex = 80;
            this.chartMediosPago.Text = "chart2";
            this.chartMediosPago.Visible = false;
            // 
            // tcContenido
            // 
            this.tcContenido.Controls.Add(this.tabPage1);
            this.tcContenido.Controls.Add(this.tabPage2);
            this.tcContenido.Location = new System.Drawing.Point(182, 19);
            this.tcContenido.Name = "tcContenido";
            this.tcContenido.SelectedIndex = 0;
            this.tcContenido.Size = new System.Drawing.Size(1130, 615);
            this.tcContenido.TabIndex = 81;
            this.tcContenido.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.dgVentasDia);
            this.tabPage1.Controls.Add(this.gpDatos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1122, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DATOS";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.chartVariacionHoras);
            this.tabPage2.Controls.Add(this.chartMediosPago);
            this.tabPage2.Controls.Add(this.chartPromediosGanancias);
            this.tabPage2.Controls.Add(this.chartPromedioIngresos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1122, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GRAFICOS";
            // 
            // chartVariacionHoras
            // 
            this.chartVariacionHoras.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea4.Name = "ChartArea1";
            this.chartVariacionHoras.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartVariacionHoras.Legends.Add(legend4);
            this.chartVariacionHoras.Location = new System.Drawing.Point(588, 313);
            this.chartVariacionHoras.Name = "chartVariacionHoras";
            this.chartVariacionHoras.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartVariacionHoras.Series.Add(series4);
            this.chartVariacionHoras.Size = new System.Drawing.Size(449, 256);
            this.chartVariacionHoras.TabIndex = 81;
            this.chartVariacionHoras.Text = "chart2";
            this.chartVariacionHoras.Visible = false;
            // 
            // panelCargando
            // 
            this.panelCargando.BackColor = System.Drawing.SystemColors.Menu;
            this.panelCargando.Controls.Add(this.label2);
            this.panelCargando.Controls.Add(this.label1);
            this.panelCargando.Controls.Add(this.pbCargando);
            this.panelCargando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCargando.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelCargando.Location = new System.Drawing.Point(0, 0);
            this.panelCargando.Name = "panelCargando";
            this.panelCargando.Size = new System.Drawing.Size(1324, 646);
            this.panelCargando.TabIndex = 82;
            this.panelCargando.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(401, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(476, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "POR FAVOR AGUARDE UN MOMENTO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESCARGANDO DATOS DEL SERVIDOR";
            // 
            // pbCargando
            // 
            this.pbCargando.InitialImage = global::Planificador.Properties.Resources.carga;
            this.pbCargando.Location = new System.Drawing.Point(397, 195);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(480, 227);
            this.pbCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargando.TabIndex = 0;
            this.pbCargando.TabStop = false;
            // 
            // frmGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1324, 646);
            this.Controls.Add(this.panelCargando);
            this.Controls.Add(this.tcContenido);
            this.Controls.Add(this.gpEmpleado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGraficos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURACION";
            this.Load += new System.EventHandler(this.frmGraficos_Load);
            this.gpDatos.ResumeLayout(false);
            this.gpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromediosGanancias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromedioIngresos)).EndInit();
            this.gpEmpleado.ResumeLayout(false);
            this.gpEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).EndInit();
            this.tcContenido.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVariacionHoras)).EndInit();
            this.panelCargando.ResumeLayout(false);
            this.panelCargando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpDatos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPromediosGanancias;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPromedioIngresos;
        private System.Windows.Forms.Label lblGananciaDiaMenosProductivo;
        private System.Windows.Forms.Label lblTotalDiaMenosProductivo;
        private System.Windows.Forms.Label lblDiaMenosProductivo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblGananciaDiaMasProductivo;
        private System.Windows.Forms.Label lblTotalDiaMasProductivo;
        private System.Windows.Forms.Label lblDiaMasProductivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpEmpleado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblb;
        private System.Windows.Forms.Label lblblblb;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.DataGridView dgVentasDia;
        private System.Windows.Forms.Label lblTotalGanancias;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMediosPago;
        private System.Windows.Forms.TabControl tcContenido;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVariacionHoras;
        private System.Windows.Forms.Panel panelCargando;
        private System.Windows.Forms.PictureBox pbCargando;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}