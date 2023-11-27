using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlanificador
{
    public partial class frmAgregarEmpleado : Form
    {
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        public byte[] fotoperfil;
        public byte[] huella;

        private void btnActualizarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtén la ruta del archivo seleccionado
                        string rutaArchivo = openFileDialog.FileName;

                        // Carga la imagen en el PictureBox
                        pbFoto.Image = Image.FromFile(rutaArchivo);

                        // Opcional: Guarda la ruta del archivo si necesitas utilizarla posteriormente
                        fotoperfil = File.ReadAllBytes(rutaArchivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (pbFoto.Image != null && pbHuella.Image != null)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void btnActualizarHuella_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtén la ruta del archivo seleccionado
                        string rutaArchivo = openFileDialog.FileName;

                        // Carga la imagen en el PictureBox
                        pbHuella.Image = Image.FromFile(rutaArchivo);

                        // Opcional: Guarda la ruta del archivo si necesitas utilizarla posteriormente
                        huella = File.ReadAllBytes(rutaArchivo);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (pbFoto.Image != null && pbHuella.Image != null)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string mail = txtMail.Text;
            string fecha = txtFecha.Text;
            decimal horaNormal = Convert.ToDecimal(txtHoraNormal.Text);
            decimal horaFeriado = Convert.ToDecimal(txtHoraFeriado.Text);
            decimal horaVacaciones = Convert.ToDecimal(txtHoraVacaciones.Text);

            objC.NuevoEmpleado(nombre, apellido, mail, fecha, horaNormal, horaFeriado, horaVacaciones, fotoperfil, huella);

            LimpiarFormulario();

            
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNombre.Text != null)
            {
                txtApellido.Enabled = true;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtApellido.Text != null)
            {
                txtMail.Enabled = true;
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (txtMail.Text != "" && txtMail.Text != null)
            {
                txtFecha.Enabled = true;
            }

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtFecha.Text != "" && txtFecha.Text != null)
            {
                txtHoraNormal.Enabled = true;
            }
        }

        private void txtHoraNormal_TextChanged(object sender, EventArgs e)
        {
            if (txtHoraNormal.Text != "" && txtHoraNormal.Text != null)
            {
                txtFecha.Enabled = true;
                txtHoraFeriado.Enabled = true;
                txtHoraVacaciones.Enabled = true;
                if (pbFoto.Image != null && pbHuella.Image != null)
                {
                    btnAgregar.Enabled = true;
                }
                
            }
        }

        private void txtHoraFeriado_TextChanged(object sender, EventArgs e)
        {
            if (pbFoto.Image != null && pbHuella.Image != null)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void txtHoraVacaciones_TextChanged(object sender, EventArgs e)
        {
            if (pbFoto.Image != null && pbHuella.Image != null)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En el siguiente formulario es recomendable llenar las cajas de texto con la informacion, y luego cargar tanto la imagen, como la huella con su respectivo lector. Verificar que los datos esten correctos." , "AYUDA", MessageBoxButtons.OK);
        }

        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtApellido.Enabled = false;
            txtMail.Clear();
            txtMail.Enabled = false;
            txtFecha.Clear();
            txtFecha.Enabled = false;
            txtHoraNormal.Clear();
            txtHoraNormal.Enabled = false;
            txtHoraFeriado.Clear();
            txtHoraFeriado.Enabled = false;
            txtHoraVacaciones.Clear();
            txtHoraVacaciones.Enabled = false;

            pbFoto.Image = null;
            pbHuella.Image = null;

            btnAgregar.Enabled = false;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
