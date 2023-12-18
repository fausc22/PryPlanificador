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
using libzkfpcsharp;
using Sample;
using System.Threading;
using System.Text.RegularExpressions;

namespace pryPlanificador
{
    public partial class frmAgregarEmpleado : Form
    {
        private IntPtr mDevHandle = IntPtr.Zero;
        private IntPtr FormHandle = IntPtr.Zero;
        private bool bIsTimeToDie = false;
        private byte[] FPBuffer;
        public byte[] huella;

        bool cerrar = false;

        

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        private const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);



        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        public byte[] fotoperfil;
        

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
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    lblId.Text = 0.ToString();
                    bnInit.Enabled = false;

                    byte[] paramValue = new byte[4];
                    int size = 4;
                    if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(Convert.ToInt32(lblId.Text))))
                    {
                        MessageBox.Show("OpenDevice fail");
                        zkfp2.Terminate();
                        
                        return;
                    }

                    

                    zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
                    zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                    size = 4;
                    zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
                    zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                    FPBuffer = new byte[mfpWidth * mfpHeight];

                    Thread captureThread = new Thread(new ThreadStart(DoCapture));
                    captureThread.IsBackground = true;
                    captureThread.Start();
                    bIsTimeToDie = false;
                    


                    MessageBox.Show("ATENCION: A continuacion, presione fuertemente con el pulgar sobre el lector hasta ver registrada su huella, luego realice el registro pulsando el boton.");
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("No device connected!");
                }
            }
            else
            {
                MessageBox.Show("ERROR: Verificar que el lector este conectado correctamente.");
            }

            
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                int cbCapTmp = 2048;
                byte[] imgbuf = new byte[mfpWidth * mfpHeight];
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, imgbuf, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        pbHuella.Image = bmp;
                        


                        // Convierte el Bitmap a un arreglo de bytes (por ejemplo, en formato JPEG)
                        byte[] byteArray;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byteArray = stream.ToArray();
                        }

                        // Almacena el arreglo de bytes en tu variable "huella"
                        huella = byteArray;
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string mail = txtMail.Text;
            string fecha = txtFecha.Text;
            int diavacas = Convert.ToInt32(txtDiaVacaciones.Text);
            int antiguedad = Convert.ToInt32(txtAntiguedad.Text);    
            int horaNormal = Convert.ToInt32(txtHoraNormal.Text);
            

            objC.NuevoEmpleado(nombre, apellido, mail, fecha, antiguedad, horaNormal, fotoperfil, huella, diavacas );

            LimpiarFormulario();

            
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
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
                txtAntiguedad.Enabled = true;
            }
        }

        private void txtHoraNormal_TextChanged(object sender, EventArgs e)
        {
            if (txtHoraNormal.Text != "" && txtHoraNormal.Text != null)
            {
                txtDiaVacaciones.Enabled = true;
                
            }
        }

        private void txtHoraFeriado_TextChanged(object sender, EventArgs e)
        {
            if (txtAntiguedad.Text != "")
            {
                txtHoraNormal.Enabled = true;
            }
        }

        private void txtHoraVacaciones_TextChanged(object sender, EventArgs e)
        {
            
         
                btnAgregar.Enabled = true;
            
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
            txtAntiguedad.Clear();
            txtAntiguedad.Enabled = false;
            txtDiaVacaciones.Clear();
            txtDiaVacaciones.Enabled = false;

            pbFoto.Image = null;
            pbHuella.Image = null;

            btnAgregar.Enabled = false;
            bnInit.Enabled = true;    

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void frmAgregarEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            bIsTimeToDie = true;
            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
            zkfp2.Terminate();
        }

        private void bnInit_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void pbHuella_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void pbHuella_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

        private void txtHoraNormal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtHoraFeriado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtHoraVacaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }
    }
}
