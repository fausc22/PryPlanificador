using pryPlanificador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        string accion = "";
        bool cerrar = false;


        private void frmRegistro_Load(object sender, EventArgs e)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtener el número del día actual
            int numeroDia = fechaActual.Day;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtContrasenia.Enabled = true;
            }
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            if (txtContrasenia.Text != "") 
            {
                txtFecha.Enabled = true;
            }
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtFecha.Text != "")
            {
                txtHora.Enabled = true;
            }
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {
            if (txtHora.Text != "")
            {
                optIngreso.Enabled = true;
                optEgreso.Enabled = true;
            }
        }

        private void optIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (optIngreso.Checked || optEgreso.Checked)
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void optEgreso_CheckedChanged(object sender, EventArgs e)
        {
            if (optIngreso.Checked || optEgreso.Checked)
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            int dia = 1302;
            if (txtContrasenia.Text == dia.ToString())
            {
                string nombre = txtNombre.Text;
                string fecha = txtFecha.Text;
                string hora = txtHora.Text;
                TimeSpan horaCargar = TimeSpan.Parse(hora);
                // Obtener el nombre del mes actual en formato de cadena
                DateTime fechaB = DateTime.ParseExact(fecha, "d/M/yyyy", CultureInfo.InvariantCulture);
                string anio = fechaB.Year.ToString();
                string mes = fechaB.ToString("MMMM", new CultureInfo("es-ES"));
                if (optIngreso.Checked == true)
                {
                    accion = "INGRESO";
                }
                else
                {
                    if (optEgreso.Checked == true)
                    {
                        accion = "EGRESO";
                    }
                }


                cerrar = objC.NuevoLogeo(nombre, fecha, accion, horaCargar, anio, mes);

                if (accion == "EGRESO")
                {
                    TimeSpan horaIngreso = objC.HoraIngreso(nombre, anio);
                    TimeSpan horaEgreso = TimeSpan.Parse(hora);
                    cerrar = objC.NuevoIngresoEgreso(nombre, fecha, horaIngreso, horaEgreso, mes, anio);

                }

                if (cerrar == true)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA. Intente nuevamente");
            }

        }
    }
}
