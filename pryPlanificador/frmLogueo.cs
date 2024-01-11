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
            cmbMes.Enabled = false;
            cmbAnio.Enabled = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            objC.CargarGrillaLogueoFiltradaNombre(dgvLogueo, anio, mes, empleado);
            btnFiltrar.Enabled = false;
            cmbEmpleado.SelectedIndex = -1;
            
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
            cmbMes.Enabled = true;
            cmbMes.SelectedIndex = -1;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = true;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btnFiltrarFecha.Enabled = true;
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            string Fecharda = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            objC.CargarGrillaLogueoFiltradaFecha(dgvLogueo, anio, mes, Fecharda);
            btnFiltrarFecha.Enabled = false;
            dateTimePicker1.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            objC.CargarGrillaLogueo(dgvLogueo, anio, mes);
            dateTimePicker1.ResetText();
            btnFiltrar.Enabled = false;
            cmbEmpleado.SelectedIndex = -1;
            btnFiltrarFecha.Enabled = false;
        }
    }
}
