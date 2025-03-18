using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador
{
    public partial class frmBd : Form
    {

        private string servidor = "localhost";
        private string bd = "planificador";
        private string user = "root";
        private string pw = "251199";
        private string port = "3306";


        public frmBd()
        {
            InitializeComponent();
        }

        private void frmBd_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo SQL (*.sql)|*.sql",
                Title = "Guardar copia de seguridad",
                FileName = $"{bd}_backup.sql"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportarBaseDeDatos(filePath);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivo SQL (*.sql)|*.sql",
                Title = "Seleccionar copia de seguridad"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportarBaseDeDatos(filePath);
            }
        }

        private void ExportarBaseDeDatos(string filePath)
        {
            string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe"; // Ajusta la ruta según tu instalación

            if (!File.Exists(mysqldumpPath))
            {
                MessageBox.Show("No se encontró mysqldump. Verifica la instalación de MySQL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqldumpPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = $"-h {servidor} -P {port} -u {user} -p{pw} {bd}"
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.Write(process.StandardOutput.ReadToEnd());
                    }

                    process.WaitForExit();
                }

                MessageBox.Show("Base de datos exportada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportarBaseDeDatos(string filePath)
        {
            string mysqlPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe"; // Ajusta la ruta según tu instalación

            if (!File.Exists(mysqlPath))
            {
                MessageBox.Show("No se encontró mysql.exe. Verifica la instalación de MySQL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqlPath,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = $"-h {servidor} -P {port} -u {user} -p{pw} {bd}"
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    using (StreamWriter sw = process.StandardInput)
                    {
                        sw.Write(sr.ReadToEnd());
                    }

                    process.WaitForExit();
                }

                MessageBox.Show("Base de datos importada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
