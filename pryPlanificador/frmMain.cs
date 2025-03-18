using MySql.Data.MySqlClient;
using Planificador;
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

namespace pryPlanificador
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void graficoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void planificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoPlanificador frm = new frmPlaneamientoPlanificador();
            frm.Show();
        }

        private void horasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoHoras f = new frmPlaneamientoHoras();
            f.Show();
        }

        private void cuantificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlaneamientoCuantificador frm = new frmPlaneamientoCuantificador();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logueoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLogueo f = new frmLogueo();
            f.ShowDialog();
        }

        private void reciboToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecibo F = new frmRecibo();
            F.ShowDialog();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurnos f = new frmTurnos();
            f.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado f = new frmAgregarEmpleado();
            f.ShowDialog();
        }

        private void editarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado f = new frmEmpleado();
            f.ShowDialog();
        }

        private void feriadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeriados f = new frmFeriados();
            f.ShowDialog();
        }

        private void controlHorasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmControlHoras f = new frmControlHoras();
            f.ShowDialog();
        }

        private void pagosExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagoExtra f = new frmPagoExtra();
            f.ShowDialog();
        }

        private void vacacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVacaciones f = new frmVacaciones();
            f.ShowDialog();
        }

        private void registroManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistro frm = new frmRegistro();
            frm.ShowDialog();
        }

        private void bACKUPBASEDEDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Files (*.sql)|*.sql";
            saveFileDialog.Title = "Save SQL Backup";
            saveFileDialog.FileName = "backup.sql";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                BackupDatabase(filePath);
            }
        }

        private void BackupDatabase(string filePath)
        {
            try
            {
                // Ajusta los siguientes valores según tu configuración
                string server = "localhost";
                string database = "plani";
                string user = "root";
                string password = "2511";

                // Usa la ruta completa a mysqldump.exe si no está en el PATH del sistema
                string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";

                // Comando para realizar el backup
                string arguments = $"--user={user} --password={password} --host={server} {database} --result-file=\"{filePath}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqldumpPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Backup completed successfully!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Backup failed with error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while backing up the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iMPORTARBASEDEDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQL Files (*.sql)|*.sql";
            openFileDialog.Title = "Select SQL Backup File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                RestoreDatabase(filePath);
            }
        }

        private void RestoreDatabase(string filePath)
        {
            try
            {
                // Ajusta los siguientes valores según tu configuración
                string server = "localhost";
                string database = "plani";
                string user = "root";
                string password = "2511";

                // Usa la ruta completa a mysql.exe si no está en el PATH del sistema
                string mysqlPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe";

                string connectionString = $"server={server};user={user};password={password};";

                // Drop the existing database and create a new one
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand($"DROP DATABASE IF EXISTS {database}; CREATE DATABASE {database};", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Comando para restaurar la base de datos
                string arguments = $"--user={user} --password={password} --host={server} {database}";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqlPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        using (StreamWriter writer = process.StandardInput)
                        {
                            writer.Write(reader.ReadToEnd());
                        }
                    }

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Database restored successfully!", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Restore failed with error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while restoring the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        clsPlaneamiento objP = new clsPlaneamiento();
        private void btnAyuda_Click(object sender, EventArgs e)
        {
            objP.GenerarTurnosYTotales(2025);
        }

        private void vacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVacaciones frmVacas = new frmVacaciones();
            frmVacas.ShowDialog();
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGraficos frm = new frmGraficos();
            frm.ShowDialog();
        }

        private void mENSUALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mENSUALToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGraficosProductos frm = new frmGraficosProductos();
            frm.ShowDialog();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBd frm = new frmBd();
            frm.ShowDialog();
        }
    }
}
