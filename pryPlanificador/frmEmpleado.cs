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
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        public byte[] fotoperfil;
        public byte[] huella;


        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            objC.CargarCmbEmpleado(cmbEmpleado);
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            objC.CargarEmpleado(empleado, lblId, txtNombre, txtApellido, txtMail, txtFecha, txtHoraNormal, txtHoraFeriado, txtHoraVacaciones, pbFoto, pbHuella, fotoperfil, huella);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string mail = txtMail.Text;
            string fecha = txtFecha.Text;
            int horaNormal = Convert.ToInt32(txtHoraNormal.Text);
            int horaFeriado = Convert.ToInt32(txtHoraFeriado.Text);
            int horaVacaciones = Convert.ToInt32(txtHoraVacaciones.Text);
            objC.EditarEmpleado(id, nombre, apellido, mail, fecha, horaNormal, horaFeriado, horaVacaciones, fotoperfil, huella);
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
    }
}
