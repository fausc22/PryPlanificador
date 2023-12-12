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
    public partial class frmFeriados : Form
    {
        public frmFeriados()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        bool agregar = true;
        private void button1_Click(object sender, EventArgs e)
        {
            string year = cmbAnio.Text;
            objC.CargarGrillaFeriado(dgvFeriado, year);
            dgvFeriado.Visible = true;
            btnNuevoFeriado.Visible=true;
            btnNuevoFeriado.Enabled=true;
            cmbAnio.Enabled=false;
            btnLimpiar.Enabled = true;
            button1.Enabled = false;

        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void btnNuevoFeriado_Click(object sender, EventArgs e)
        {
            gpNuevoFeriado.Visible = true;
            gpNuevoFeriado.Text = "NUEVO FERIADO";
            btnAgregar.Text = "AGREGAR";
            btnEliminar.Visible = false;
            agregar = true;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbDia.SelectedIndex = -1;
            txtFecha.Clear();
            txtFestejo.Clear();
            cmbAnioGp.SelectedIndex = -1;
            gpNuevoFeriado.Visible = false;
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtFecha.Text != "") 
            {
                txtFestejo.Enabled = true;
            }
        }

        private void txtFestejo_TextChanged(object sender, EventArgs e)
        {
            if (txtFestejo.Text != "")
            {
                cmbDia.Enabled = true;
            }
        }

        private void txtDia_TextChanged(object sender, EventArgs e)
        {
            if (cmbDia.SelectedIndex != -1)
            {
                cmbAnioGp.Enabled = true;
            }
        }

        private void cmbAnioGp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnioGp.SelectedIndex != -1 && txtFecha.Text != "" && cmbDia.SelectedIndex != -1 && txtFestejo.Text != "")
            {
                btnAgregar.Enabled = true;
            }
        }

        private void dgvFeriado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gpNuevoFeriado.Visible = true;
            gpNuevoFeriado.Text = "MODIFICAR FERIADO";
            btnAgregar.Text = "MODIFICAR";
            btnEliminar.Visible = true;
            agregar = false;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvFeriado.Rows[e.RowIndex];

                string id = selectedRow.Cells[0].Value.ToString();
                string Fecha = selectedRow.Cells[1].Value.ToString();
                string festejo = selectedRow.Cells[2].Value.ToString();
                string dia = selectedRow.Cells[3].Value.ToString();
                

                lblId.Text = id;
                txtFecha.Text = Fecha;
                txtFestejo.Text = festejo;
                cmbDia.Text = dia;
                cmbAnioGp.Text = cmbAnio.Text;

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            string fecha = txtFecha.Text;
            string festejo = txtFestejo.Text;
            string dia = cmbDia.Text;
            string anio = cmbAnioGp.Text;

            if (agregar == true)
            {
                objC.NuevoFeriado(fecha, festejo, dia, anio);
                cmbDia.SelectedIndex = -1;
                txtFecha.Clear();
                txtFestejo.Clear();
                btnEliminar.Visible = false;
                cmbAnioGp.SelectedIndex = -1;
                gpNuevoFeriado.Visible = false;
                objC.CargarGrillaFeriado(dgvFeriado, anio);
            }
            else
            {
                int id = Convert.ToInt32(lblId.Text);
                objC.EditarFeriado(id, fecha, festejo, dia, anio);
                cmbDia.SelectedIndex = -1;
                txtFecha.Clear();
                txtFestejo.Clear();
                btnEliminar.Visible = false;
                cmbAnioGp.SelectedIndex = -1;
                gpNuevoFeriado.Visible = false;
                objC.CargarGrillaFeriado(dgvFeriado, anio);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);

            // Muestra el cuadro de diálogo con los botones "Sí" y "No"
            DialogResult resultado = MessageBox.Show("¿ESTÁS SEGURO DE QUE DESEAS ELIMINAR EL FERIADO?", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Si hace clic en "Sí", ejecuta los procedimientos siguientes
                objC.EliminarFeriado(id);
                objC.CargarGrillaFeriado(dgvFeriado, cmbAnio.Text);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL AÑO EN EL QUE DESEA VER LOS FERIADOS. UTILICE EL BOTON VERDE PARA AGREGAR UN NUEVO FERIADO, Y HAGA DOBLE CLICK SOBRE LA GRILLA PARA MODIFICAR UNO EXISTENTE, O PARA ELIMINAR.", "", MessageBoxButtons.OK);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = false;
            cmbAnio.SelectedIndex = -1;
            cmbAnioGp.SelectedIndex = -1;
            cmbDia.SelectedIndex = -1;
            txtFecha.Clear();
            txtFestejo.Clear();
            dgvFeriado.Visible = false;
            gpNuevoFeriado.Visible = false;
            btnNuevoFeriado.Visible = false;
            cmbAnio.Enabled = true;
            button1.Enabled = true;
            
        }

        private void frmFeriados_Load(object sender, EventArgs e)
        {

        }
    }
}
