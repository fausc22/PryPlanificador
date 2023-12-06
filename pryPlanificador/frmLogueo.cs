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
    public partial class frmLogueo : Form
    {
        public frmLogueo()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();

        private void frmLogueo_Load(object sender, EventArgs e)
        {
            objC.CargarCmbEmpleado(cmbEmpleado);
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            objC.CargarGrillaLogueo(dgvLogueo, anio, mes);
            dgvLogueo.Visible = true;
            gpFiltro.Visible = true;
            btnLimpiar.Enabled = true;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            objC.CargarGrillaLogueoFiltrada(dgvLogueo, anio, mes, empleado);
            
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex != -1)
            {
                btnFiltrar.Enabled = true;
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1 && cmbMes.SelectedIndex != -1)
            {
                btnSelec.Enabled = true;
                btnLimpiar.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnSelec.Enabled = false;
            btnLimpiar.Enabled = false;
            cmbMes.SelectedIndex = -1;
            cmbAnio.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            gpFiltro.Visible = false;
            dgvLogueo.Visible = false;
            
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL MES Y EL AÑO PARA VISUALIZAR LOS LOGUEOS. PUEDE FILTRAR POR EMPLEADO Y LIMIPAR EL FORMULARIO APRETANDO LOS BOTONES CORRESPONDIENTES", "", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
