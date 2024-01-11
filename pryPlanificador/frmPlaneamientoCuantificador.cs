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
    public partial class frmPlaneamientoCuantificador : Form
    {
        public frmPlaneamientoCuantificador()
        {
            InitializeComponent();
        }
        clsPlaneamiento plan = new clsPlaneamiento();
        clsConexion objC = new clsConexion();
        string nombreC;
        string nombreF;
        string form = "acumulado";

        private void frmPlaneamientoCuantificador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);

            plan.CargarGrillaPlanificador2(dgvHora, mes, anio, form);
            plan.CargarGrillaTotales(dgvTotales, mes, anio, form);

            cmbMes.Enabled = false;
            cmbAnio.Enabled = false;
            btnLimpiar.Enabled = true;
            button1.Enabled = false;
            dgvHora.Visible = true;
            dgvTotales.Visible = true;
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1 && cmbMes.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMes.SelectedIndex = -1;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = true;
            cmbMes.Enabled = true;
            btnLimpiar.Enabled = false;
            dgvHora.Visible = false;
            dgvTotales.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL MES Y EL AÑO CORRESPONIDENTE EN EL QUE DESEA CONSULTAR LA INFORMACION.", "AYUDA", MessageBoxButtons.OK);
        }

        private void dgvHora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgvHora_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string valor = cell.Value?.ToString();

                if (!string.IsNullOrEmpty(valor))
                {
                    if (!valor.Equals("0"))
                    {
                        cell.Style.BackColor = Color.Green;
                    }
                }
            }
        }

        private void dgvTotales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvTotales.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string valor = cell.Value?.ToString();

                if (!string.IsNullOrEmpty(valor))
                {
                    if (!valor.Equals("0"))
                    {
                        cell.Style.BackColor = Color.Green;
                    }
                }
            }
        }
    }
}
