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
    public partial class frmPagoExtra : Form
    {
        public frmPagoExtra()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE TODAS LAS OPCIONES DISPONIBLE PARA CREAR UN PAGO EXTRA. NO 0LVIDE COMPLETAR TANTO EL MONTO COMO LA DESCRIPCION. EL BOTON LIMPIAR BORRA TODA LA INFORMACION DENTRO DE LOS FORMULARIOS");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex != -1)
            {
                cmbMes.Enabled = true;
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMes.SelectedIndex != -1)
            {
                cmbAnio.Enabled = true;
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1)
            {
                cmbCategoria.Enabled = true;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1)
            {
                txtMonto.Enabled = true;
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                btnSelec.Enabled = true;
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.Text != "")
            {
                txtDescripcion.Enabled = true;
            }

        }

        private void frmPagoExtra_Load(object sender, EventArgs e)
        {
            objC.CargarCmbEmpleado(cmbEmpleado);
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string anio = cmbAnio.Text;
            string mes = cmbMes.Text;
            string categoria = cmbCategoria.Text;
            int monto = Convert.ToInt32(txtMonto.Text);
            string descripcion = txtDescripcion.Text;

            objC.NuevoPagoExtra(empleado, anio, mes, categoria, monto, descripcion);
            Limpiar();
        }

        private void Limpiar()
        {
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = false;
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Enabled = false;
            cmbMes.SelectedIndex = -1;
            cmbMes.Enabled = false;
            cmbEmpleado.SelectedIndex = -1;
            cmbEmpleado.Enabled = false;
            txtDescripcion.Clear();
            txtDescripcion.Enabled = false;
            txtMonto.Clear();
            txtMonto.Enabled = false;
            btnSelec.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
