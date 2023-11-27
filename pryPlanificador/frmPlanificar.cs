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
    public partial class frmPlanificar : Form
    {
        public frmPlanificar()
        {
            InitializeComponent();
        }

        clsPlanificar objP = new clsPlanificar();
        string nombreC;
        private void fmPlanificar_Load(object sender, EventArgs e)
        {
            objP.CargarGrillaPlanificador(dgvHora);
            objP.CargarTurnos(cmbTurno);
            
        }

        private void dgvHora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el valor de la celda seleccionada
                object cellValue = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                DataGridViewColumn colum = dgvHora.Columns[e.ColumnIndex];
                nombreC = colum.HeaderText;
                

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

                string sumaHoras = cmbTurno.SelectedValue.ToString();
                string nuevoValor = cmbTurno.Text;
                DataGridViewCell cell = dgvHora.SelectedCells[0];

                if (cell is DataGridViewTextBoxCell)
                {
                    
                    int id = Convert.ToInt32(dgvHora.Rows[cell.RowIndex].Cells["ID"].Value);

                    // Actualiza la base de datos con el nuevo valor
                    objP.ActualizarPlanifcador(id, nombreC, nuevoValor);
                    objP.ActualizarHoras(id, nombreC, sumaHoras);
                    objP.ActualizarCuantificador(id, nombreC, Convert.ToInt32(sumaHoras));

                

                    gpCmb.Visible = false;
                }

            gpCmb.Visible = false;
            btnModificar.Enabled = false;
            objP.CargarGrillaPlanificador(dgvHora);
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurno.SelectedIndex != -1)
            {
                btnModificar.Enabled = true;
            }
        }

        private void dgvHora_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
