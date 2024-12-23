using MySql.Data.MySqlClient;
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

namespace Planificador
{
    public partial class frmGraficos : Form
    {

        private clsGraficos graficos;
        public frmGraficos()
        {
            InitializeComponent();
            graficos = new clsGraficos();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void frmGraficos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            

            
            
        }

        private void dgVentasDia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        

        

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            MostrarCargando(true);
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            await EjecutarConsultaRemotaAsync(mes, anio);
            MostrarTodo(true);
            
        }

        private void lblDiaMenosProductivo_Click(object sender, EventArgs e)
        {

        }

        private void MostrarCargando(bool mostrar)
        {
            if (mostrar)
            {
                string rutaGif = Path.Combine(Application.StartupPath, "Resources", "carga.gif");
                if (File.Exists(rutaGif))
                {
                    pbCargando.Load(rutaGif);
                    panelCargando.BringToFront();
                    panelCargando.Visible = true;
                    this.UseWaitCursor = true; // Cambia el cursor al estilo de espera
                }
                else
                {
                    MessageBox.Show("El archivo carga.gif no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                panelCargando.Visible = false;
                this.UseWaitCursor = false; // Restaura el cursor normal
            }

        }

        private void MostrarTodo(bool mostrar)
        {
            if (mostrar)
            {
                
                dgVentasDia.Visible = true;
                lblTotalIngresos.Visible = true;
                lblTotalGanancias.Visible = true;
                gpDatos.Visible = true;
                chartPromedioIngresos.Visible = true;
                chartPromediosGanancias.Visible = true;
                chartMediosPago.Visible = true;
                chartVariacionHoras.Visible = true;
                tcContenido.Visible = true;
                cmbMes.Enabled = false;
                cmbAnio.Enabled = false;
                button1.Enabled = false;
            }
            
        }

        private async Task EjecutarConsultaRemotaAsync(string mes, int anio)
        {
            try
            {
                // Mostrar el indicador de carga
                MostrarCargando(true);

                await Task.Run(() =>
                {
                    graficos.MigrarDatosMesAnio(mes, anio);
                    graficos.CargarGrillaIngresosGanancias(dgVentasDia, mes, anio);
                    graficos.CargarTotalesMes(lblTotalIngresos, lblTotalGanancias, mes, anio);
                    graficos.ObtenerDiasProductivos(mes, anio, lblDiaMasProductivo, lblTotalDiaMasProductivo, lblGananciaDiaMasProductivo, lblDiaMenosProductivo, lblTotalDiaMenosProductivo, lblGananciaDiaMenosProductivo);
                    graficos.MostrarPromedioIngresosPorDia(mes, anio, chartPromedioIngresos, chartPromediosGanancias);
                    graficos.CargarGraficoMediosDePago(mes, anio, chartMediosPago);
                    graficos.CargarGraficoVariacionHoraria(mes, anio, chartVariacionHoras);
                });

                // Ocultar el indicador de carga
                MostrarCargando(false);
            }
            catch (Exception ex)
            {
                // Ocultar el indicador de carga en caso de error
                MostrarCargando(false);
                MessageBox.Show("Error al realizar la consulta: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tcContenido.Visible = false;
            cmbAnio.Enabled = true;
            cmbMes.Enabled = true;
            
        }
    }
}
