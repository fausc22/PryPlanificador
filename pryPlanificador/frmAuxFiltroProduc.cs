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
    public partial class frmAuxFiltroProduc : Form
    {
        public string ProductoSeleccionado { get; private set; }
        clsGraficos graficos;
        public frmAuxFiltroProduc()
        {
            graficos = new clsGraficos();
            InitializeComponent();
        }

        private void frmAuxFiltroProduc_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            graficos.BuscarProductosPorNombre(txtProducto, lbProductos);
            lbProductos.Visible = true;
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void lbProductos_DoubleClick(object sender, EventArgs e)
        {
            if (lbProductos.SelectedItem == null) return; // Verificar si hay un elemento seleccionado

            string producto = lbProductos.SelectedItem.ToString();

            DialogResult result = MessageBox.Show($"Has seleccionado '{producto}', ¿estás seguro que deseas continuar?",
                                                  "Confirmación",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProductoSeleccionado = producto; // Almacenar el producto seleccionado
                this.DialogResult = DialogResult.OK; // Indicar que se ha seleccionado un producto
                this.Close(); // Cerrar el formulario auxiliar
            }
        }
    }
}
