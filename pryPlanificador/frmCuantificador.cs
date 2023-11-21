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
    public partial class frmCuantificador : Form
    {
        public frmCuantificador()
        {
            InitializeComponent();
        }

        clsPlanificar objC = new clsPlanificar();


        private void frmCuantificador_Load(object sender, EventArgs e)
        {
            objC.CargarGrillaCuantificador(dgvHora);
            objC.PintarValores(dgvHora);
            objC.CargarGrillaTotales(dgvTotales);
                
        }
    }
}
