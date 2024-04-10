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
        clsConexion objE = new clsConexion();
        clsPlaneamiento objC = new clsPlaneamiento();
        private void frmTurnos_Load(object sender, EventArgs e)
        {
            //objE.CargarGrillaTurnos(dgvTurnos);
            objC.CargarGrillaTurnos(dgvTurnos);
        }

        private void dgvTurnos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gpDatos.Visible = true;
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

            if (btnModificar.Text == "MODIFICAR")
            {
                objE.ActualizarHorarios(id, turno, horaInicio, horaFin, horaTotal);
            }
            else
            {
                objE.NuevoHorarios(turno, horaInicio, horaFin, horaTotal);
            }

            
            
            objC.CargarGrillaTurnos(dgvTurnos);
            gpDatos.Visible = false; 

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HAGA DOBLE CLICK EN LA GRILLA SOBRE EL TURNO QUE DESEA MODFIICAR, INTRODUZCA LOS DATOS Y HAGA CLICK EN EL BOTON. POR FAVOR ASIGNAR EL CALCULO DE CANTIDAD DE HORAS MANUALMENTE.", "", MessageBoxButtons.OK);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            btnModificar.Text = "NUEVO TURNO";
            gpDatos.Visible=true;
        }
    }
}
