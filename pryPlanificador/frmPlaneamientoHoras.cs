using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlanificador
{
    public partial class frmPlaneamientoHoras : Form
    {
        public frmPlaneamientoHoras()
        {
            InitializeComponent();
        }
        clsPlaneamiento plan = new clsPlaneamiento();
        clsConexion objC = new clsConexion();
        string nombreC;
        string nombreF;
        string form = "horas";

        private void frmPlaneamientoHoras_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);

            plan.CargarGrillaPlanificador(dgvHora, mes, anio, form);
            plan.CargarGrillaTotales(dgvTotales, mes, anio, form);
        }
    }
}
