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
    public partial class frmAuxPlaniHorarios : Form
    {

        public List<string> EmpleadosSeleccionados { get; private set; } = new List<string>();


        public frmAuxPlaniHorarios(IEnumerable<string> nombresEmpleados)
        {
            InitializeComponent();

            // Llenar el CheckedListBox con los nombres de los empleados
            foreach (var nombre in nombresEmpleados)
            {
                clbEmpleados.Items.Add(nombre);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAuxPlaniHorarios_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbTodos.Checked)
            {
                // Agregar todos los elementos si "Seleccionar Todos" está marcado
                foreach (string item in clbEmpleados.Items)
                {
                    EmpleadosSeleccionados.Add(item);
                }
            }
            else
            {
                // Agregar solo los seleccionados manualmente
                foreach (string item in clbEmpleados.CheckedItems)
                {
                    EmpleadosSeleccionados.Add(item);
                }
            }
            //EmpleadosSeleccionados = clbEmpleados.CheckedItems.Cast<string>().ToList();
            this.DialogResult = DialogResult.OK; // Cerrar el formulario con resultado positivo
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Cerrar sin cambios
            this.Close();
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked)
            {
                // Seleccionar todos los ítems en el CheckedListBox
                for (int i = 0; i < clbEmpleados.Items.Count; i++)
                {
                    clbEmpleados.SetItemChecked(i, true);
                }

                // Bloquear interacción con el CheckedListBox
                clbEmpleados.Enabled = false;
            }
            else
            {
                // Habilitar interacción con el CheckedListBox
                clbEmpleados.Enabled = true;

                // Opcional: Deseleccionar todos los ítems si no se requiere mantener selección
                for (int i = 0; i < clbEmpleados.Items.Count; i++)
                {
                    clbEmpleados.SetItemChecked(i, false);
                }
            }
        }
    }
}
