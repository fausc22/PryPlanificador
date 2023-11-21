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
    public partial class frmTurnos : Form
    {
        public frmTurnos()
        {
            InitializeComponent();
        }
        clsEmpleado objE = new clsEmpleado();
        private void frmTurnos_Load(object sender, EventArgs e)
        {
            objE.CargarGrillaTurnos(dgvTurnos);
        }

        private void dgvTurnos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTurnos.Rows[e.RowIndex];

                string id = selectedRow.Cells[0].Value.ToString();
                string turno = selectedRow.Cells[1].Value.ToString();
                string hsInicio = selectedRow.Cells[2].Value.ToString();
                string hsFin = selectedRow.Cells[3].Value.ToString();
                string hsTotal = selectedRow.Cells[4].Value.ToString();
                
                txtTurno.Text = turno;
                lblid.Text = id;
                txtInicio.Enabled = true;
                txtInicio.Text = hsInicio;
                txtFin.Enabled = true;
                txtFin.Text = hsFin;
                txtTotal.Enabled = true;
                txtTotal.Text = hsTotal;
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblid.Text);
            string horaInicio = txtInicio.Text;
            string horaFin = txtFin.Text;
            int horaTotal = Convert.ToInt32(txtTotal.Text);
            string turno = horaInicio + " a " + horaFin;

            objE.ActualizarTurnos(id, turno, horaInicio, horaFin, horaTotal);
            objE.CargarGrillaTurnos(dgvTurnos);
        
        }
    }
}
