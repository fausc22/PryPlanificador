using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador
{
    public partial class frmAuxReciboHoras : Form
    {

        public string NuevaCantidadHoras { get; private set; }
        public string NuevoMonto { get; private set; }
        public frmAuxReciboHoras(string valorActualMonto, string valorActualHoras)
        {
            InitializeComponent();
            txtMonto.Text = valorActualMonto;
            txtCantidad.Text = valorActualHoras;
        }

        private void frmAuxReciboHoras_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NuevoMonto = txtMonto.Text;
            NuevaCantidadHoras = txtCantidad.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
