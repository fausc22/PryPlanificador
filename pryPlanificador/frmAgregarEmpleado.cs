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
            
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}
