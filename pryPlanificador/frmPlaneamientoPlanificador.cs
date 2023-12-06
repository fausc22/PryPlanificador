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
    public partial class frmPlaneamientoPlanificador : Form
    {
        public frmPlaneamientoPlanificador()
        {
            InitializeComponent();
        }
        clsPlaneamiento plan = new clsPlaneamiento();
        clsConexion objC = new clsConexion();
        string nombreC;
        string nombreF;
        string form = "valor";


        private void gpEmpleado_Enter(object sender, EventArgs e)
        {

        }

        private void frmPlaneamientoPlanificador_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMes.SelectedIndex = -1;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = true;
            cmbMes.Enabled = true;
            btnLimpiar.Enabled = false;
            dgvHora.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            
            plan.CargarGrillaPlanificador(dgvHora, mes, anio, form);

            dgvHora.Visible = true;
            cmbMes.Enabled = false;
            cmbAnio.Enabled = false;
            btnLimpiar.Enabled = true;
            button1.Enabled = false;
        }

        private void dgvHora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            plan.CargarTurnos(cmbTurno);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el valor de la celda seleccionada
                object cellValue = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                object fechaFila = dgvHora.Rows[e.RowIndex].Cells[0].Value;
                

                DataGridViewColumn colum = dgvHora.Columns[e.ColumnIndex];
                nombreC = colum.HeaderText;
                nombreF = fechaFila.ToString();


                // Verifica si el valor no es nulo
                if (cellValue != null)
                {
                    // Carga el valor de la celda en el ComboBox
                    cmbTurno.Text = cellValue.ToString();

                    // Muestra el ComboBox
                    gpCmb.Visible = true;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            string nuevoValor = cmbTurno.Text;
            int cantidadHoras = Convert.ToInt32(cmbTurno.SelectedValue.ToString());
            int valorHora = objC.HoraEmpleado(nombreC);
            int totalHoras = valorHora * cantidadHoras;
            
            
            plan.ActualizarTurnos(mes, anio, nuevoValor, nombreF, nombreC, cantidadHoras, totalHoras);
            plan.CargarGrillaPlanificador(dgvHora, mes, anio, form);
            gpCmb.Visible = false;

        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1 && cmbMes.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL MES Y EL AÑO CORRESPONIDENTE EN EL QUE DESEA CONSULTAR LA INFORMACION. PARA MODIFICAR UN TURNO HAGA DOBLE CLICK SOBRE EL HORARIO A MODIFICAR, LUEGO SELECCIONE EL TURNO Y APRIETE MODIFICAR.", "AYUDA", MessageBoxButtons.OK);
        }
    }
}
