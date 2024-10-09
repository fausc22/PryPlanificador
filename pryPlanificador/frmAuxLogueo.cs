using pryPlanificador;
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
    public partial class frmAuxLogueo: Form
    {
        public frmAuxLogueo(int id, string fecha, string nombre, string accion, TimeSpan hora)
        {
            InitializeComponent();

            lblId.Text = id.ToString();
            txtNombre.Text = nombre;
            dateTimePicker1.Value = DateTime.Parse(fecha);
            cmbAccion.Text = accion;
            txtHora.Text = hora.ToString();

           


        }

        private void frmAuxLogueo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clsConexion objC = new clsConexion();
            bool cerrar = false;
            int id = Convert.ToInt32(lblId.Text);
            string fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string nombre = txtNombre.Text;
            string anio = dateTimePicker1.Value.ToString("yyyy");
            string mes = dateTimePicker1.Value.ToString("MMMM");
            string accion = cmbAccion.Text;
            TimeSpan hora = TimeSpan.Parse(txtHora.Text);

            if (accion == "EGRESO")
            {
                objC.ActualizarLogeo(id, fecha, hora, accion);

                TimeSpan horaIngreso = objC.ObtenerHoraIngresoUpdate(fecha, anio, nombre);

                int idErronea = objC.ObtenerIdIngresoErroneo(fecha, anio, nombre);
                
                cerrar = objC.ModificarRegistro(nombre, fecha, horaIngreso, hora, mes, anio, idErronea);

                if (cerrar == true)
                {
                    
                    this.Close();
                }

            }
            else
            {
                objC.ActualizarLogeo(id, fecha, hora, accion);
                this.Close();
            }

            
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsConexion objC = new clsConexion();
            int id = Convert.ToInt32(lblId.Text);
            objC.EliminarLogeo(id);
            this.Close();
        }
    }
}
