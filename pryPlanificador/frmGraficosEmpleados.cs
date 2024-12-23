using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador
{
    public partial class frmGraficosEmpleados : Form
    {
        private clsGraficos graficos;
        public frmGraficosEmpleados()
        {
            graficos = new clsGraficos();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            graficos.CargarEstadisticasEmpleados(dgvEmpleados, mes, anio);
            
        }

        private void frmGraficosEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}
