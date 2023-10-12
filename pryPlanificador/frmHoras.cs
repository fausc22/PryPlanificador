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
    public partial class frmHoras : Form
    {
        public frmHoras()
        {
            InitializeComponent();
        }

        clsPlanificar ObjH = new clsPlanificar();
        string nombreC;

        private void frmHoras_Load(object sender, EventArgs e)
        {
            ObjH.CargarGrilla(dgvHora);
            
        }

        private void dgvHora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        

        private void cmbHoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
