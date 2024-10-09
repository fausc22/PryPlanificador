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
                cmbDetalle.Enabled = true;
                
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
            string categoria = txtCategoria.Text;
            int monto = Convert.ToInt32(txtMonto.Text);
            string descripcion = txtDescripcion.Text;
            int detalle = 0;
            if (cmbDetalle.Text == "SUMAR")
            {
                detalle = 1;
            }
            else
            {
                if(cmbDetalle.Text == "RESTAR")
                {
                    detalle = 0;
                }
            }

            objC.NuevoPagoExtra(empleado, anio, mes, detalle, categoria, monto, descripcion);
            Limpiar();
        }

        private void Limpiar()
        {
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = false;
            txtCategoria.Text = "";
            txtCategoria.Enabled = false;
            cmbMes.SelectedIndex = -1;
            cmbMes.Enabled = false;
            cmbEmpleado.SelectedIndex = -1;
            cmbDetalle.SelectedIndex = -1;
            cmbDetalle.Enabled = false;
            gpFinal.Visible = false;
            
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoria.Text != null)
            {
                txtMonto.Enabled = true;
            }
        }

        private void cmbDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDetalle.SelectedIndex != -1)
            {
                txtMonto.Enabled = true;
                txtCategoria.Enabled = true;
                gpFinal.Visible = true;
            }
            
        }
    }
}
