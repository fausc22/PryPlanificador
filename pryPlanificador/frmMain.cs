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
            frmPlanificar frm = new frmPlanificar();
            frm.Show();
        }

        private void horasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoras f = new frmHoras();
            f.Show();
        }

        private void cuantificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuantificador frm = new frmCuantificador();
            frm.Show();
        }
    }
}
