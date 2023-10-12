namespace pryPlanificador
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnSalir;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pLANEAMIENTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planificadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuantificadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSTADISTICASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logueoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlHorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reciboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoEficienciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eDICIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feriadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConexion = new System.Windows.Forms.Button();
            btnSalir = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = System.Drawing.Color.Red;
            btnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSalir.Location = new System.Drawing.Point(2213, 1087);
            btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(191, 46);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pLANEAMIENTOToolStripMenuItem,
            this.eSTADISTICASToolStripMenuItem,
            this.eDICIONToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2440, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pLANEAMIENTOToolStripMenuItem
            // 
            this.pLANEAMIENTOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planificadorToolStripMenuItem,
            this.horasToolStripMenuItem,
            this.cuantificadorToolStripMenuItem});
            this.pLANEAMIENTOToolStripMenuItem.Name = "pLANEAMIENTOToolStripMenuItem";
            this.pLANEAMIENTOToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.pLANEAMIENTOToolStripMenuItem.Text = "PLANEAMIENTO";
            // 
            // planificadorToolStripMenuItem
            // 
            this.planificadorToolStripMenuItem.Name = "planificadorToolStripMenuItem";
            this.planificadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planificadorToolStripMenuItem.Text = "Planificador";
            this.planificadorToolStripMenuItem.Click += new System.EventHandler(this.planificadorToolStripMenuItem_Click);
            // 
            // horasToolStripMenuItem
            // 
            this.horasToolStripMenuItem.Name = "horasToolStripMenuItem";
            this.horasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.horasToolStripMenuItem.Text = "Horas";
            this.horasToolStripMenuItem.Click += new System.EventHandler(this.horasToolStripMenuItem_Click);
            // 
            // cuantificadorToolStripMenuItem
            // 
            this.cuantificadorToolStripMenuItem.Name = "cuantificadorToolStripMenuItem";
            this.cuantificadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuantificadorToolStripMenuItem.Text = "Cuantificador";
            this.cuantificadorToolStripMenuItem.Click += new System.EventHandler(this.cuantificadorToolStripMenuItem_Click);
            // 
            // eSTADISTICASToolStripMenuItem
            // 
            this.eSTADISTICASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logueoToolStripMenuItem,
            this.facturaciónToolStripMenuItem,
            this.controlHorasToolStripMenuItem,
            this.reciboToolStripMenuItem,
            this.cashFlowToolStripMenuItem,
            this.vacacionesToolStripMenuItem,
            this.actualizarDatosToolStripMenuItem,
            this.graficoToolStripMenuItem});
            this.eSTADISTICASToolStripMenuItem.Name = "eSTADISTICASToolStripMenuItem";
            this.eSTADISTICASToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.eSTADISTICASToolStripMenuItem.Text = "ESTADISTICAS";
            // 
            // logueoToolStripMenuItem
            // 
            this.logueoToolStripMenuItem.Name = "logueoToolStripMenuItem";
            this.logueoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.logueoToolStripMenuItem.Text = "Logueo";
            // 
            // facturaciónToolStripMenuItem
            // 
            this.facturaciónToolStripMenuItem.Name = "facturaciónToolStripMenuItem";
            this.facturaciónToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.facturaciónToolStripMenuItem.Text = "Facturación";
            // 
            // controlHorasToolStripMenuItem
            // 
            this.controlHorasToolStripMenuItem.Name = "controlHorasToolStripMenuItem";
            this.controlHorasToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.controlHorasToolStripMenuItem.Text = "Control Horas";
            // 
            // reciboToolStripMenuItem
            // 
            this.reciboToolStripMenuItem.Name = "reciboToolStripMenuItem";
            this.reciboToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.reciboToolStripMenuItem.Text = "Recibo";
            // 
            // cashFlowToolStripMenuItem
            // 
            this.cashFlowToolStripMenuItem.Name = "cashFlowToolStripMenuItem";
            this.cashFlowToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.cashFlowToolStripMenuItem.Text = "Cash Flow";
            // 
            // vacacionesToolStripMenuItem
            // 
            this.vacacionesToolStripMenuItem.Name = "vacacionesToolStripMenuItem";
            this.vacacionesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.vacacionesToolStripMenuItem.Text = "Vacaciones";
            // 
            // actualizarDatosToolStripMenuItem
            // 
            this.actualizarDatosToolStripMenuItem.Name = "actualizarDatosToolStripMenuItem";
            this.actualizarDatosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.actualizarDatosToolStripMenuItem.Text = "Actualizar Datos";
            // 
            // graficoToolStripMenuItem
            // 
            this.graficoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graficoEficienciaToolStripMenuItem,
            this.graficoToolStripMenuItem1});
            this.graficoToolStripMenuItem.Name = "graficoToolStripMenuItem";
            this.graficoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.graficoToolStripMenuItem.Text = "Grafico";
            this.graficoToolStripMenuItem.Click += new System.EventHandler(this.graficoToolStripMenuItem_Click);
            // 
            // graficoEficienciaToolStripMenuItem
            // 
            this.graficoEficienciaToolStripMenuItem.Name = "graficoEficienciaToolStripMenuItem";
            this.graficoEficienciaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.graficoEficienciaToolStripMenuItem.Text = "Grafico Eficiencia";
            // 
            // graficoToolStripMenuItem1
            // 
            this.graficoToolStripMenuItem1.Name = "graficoToolStripMenuItem1";
            this.graficoToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.graficoToolStripMenuItem1.Text = "Grafico Facturacion";
            this.graficoToolStripMenuItem1.Click += new System.EventHandler(this.graficoToolStripMenuItem1_Click);
            // 
            // eDICIONToolStripMenuItem
            // 
            this.eDICIONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feriadosToolStripMenuItem,
            this.turnosToolStripMenuItem,
            this.colaboradoresToolStripMenuItem});
            this.eDICIONToolStripMenuItem.Name = "eDICIONToolStripMenuItem";
            this.eDICIONToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.eDICIONToolStripMenuItem.Text = "EDICION";
            // 
            // feriadosToolStripMenuItem
            // 
            this.feriadosToolStripMenuItem.Name = "feriadosToolStripMenuItem";
            this.feriadosToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.feriadosToolStripMenuItem.Text = "Feriados";
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            this.turnosToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.turnosToolStripMenuItem.Text = "Turnos";
            // 
            // colaboradoresToolStripMenuItem
            // 
            this.colaboradoresToolStripMenuItem.Name = "colaboradoresToolStripMenuItem";
            this.colaboradoresToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colaboradoresToolStripMenuItem.Text = "Colaboradores";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1025, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "PLANIFICADOR DE TRABAJO ANUAL";
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConexion.Location = new System.Drawing.Point(2015, 1087);
            this.btnConexion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(191, 46);
            this.btnConexion.TabIndex = 2;
            this.btnConexion.Text = "Conectar a Base de Datos";
            this.btnConexion.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(2440, 1061);
            this.Controls.Add(btnSalir);
            this.Controls.Add(this.btnConexion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Planificador de trabajo anual - FC SOFTWARE ©";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pLANEAMIENTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planificadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuantificadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSTADISTICASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logueoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlHorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reciboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoEficienciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eDICIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feriadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaboradoresToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConexion;
    }
}

