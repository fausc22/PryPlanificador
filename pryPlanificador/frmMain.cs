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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void graficoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void planificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoPlanificador frm = new frmPlaneamientoPlanificador();
            frm.Show();
        }

        private void horasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoHoras f = new frmPlaneamientoHoras();
            f.Show();
        }

        private void cuantificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoCuantificador frm = new frmPlaneamientoCuantificador();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logueoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLogueo f = new frmLogueo();
            f.ShowDialog();
        }

        private void reciboToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecibo F = new frmRecibo();
            F.ShowDialog();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurnos f = new frmTurnos();
            f.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado f = new frmAgregarEmpleado();
            f.ShowDialog();
        }

        private void editarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado f = new frmEmpleado();
            f.ShowDialog();
        }
    }
}
