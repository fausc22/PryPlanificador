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
    public partial class frmControlHoras : Form
    {
        public frmControlHoras()
        {
            InitializeComponent();
        }
        clsConexion objC = new clsConexion();


        private void btnSelec_Click(object sender, EventArgs e)
        {
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            string nombre = cmbEmpleado.Text;
            objC.CargarGrillaControlHs(dgvHora, anio, mes, nombre);
            dgvHora.Visible = true;
            cmbEmpleado.Enabled = false;
            cmbMes.Enabled = false;
            cmbAnio.Enabled = false;
            btnSelec.Enabled = false;
            btnLimpiar.Enabled = true;

        }

        private void frmControlHoras_Load(object sender, EventArgs e)
        {
            objC.CargarCmbEmpleado(cmbEmpleado);
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            BotonHabilitar();   
        }

        private void BotonHabilitar()
        {
            if (cmbAnio.SelectedIndex != -1 && cmbEmpleado.SelectedIndex != -1 && cmbMes.SelectedIndex != -1)
            {
                btnSelec.Enabled = true;
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BotonHabilitar();
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BotonHabilitar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvHora.Visible = false;
            cmbEmpleado.Enabled = true;
            cmbMes.Enabled = true;
            cmbAnio.Enabled = true;
            btnLimpiar.Enabled = false;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL EMPLEADO, MES Y AÑO A REVISAR Y LUEGO HAGA CLICK EN EL BOTON SELECCIONAR. PARA CAMBIAR DE OPCIONES DEBE LIMPIAR LA GRILLA.", "", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
