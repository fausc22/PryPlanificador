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
    public partial class frmGraficosProductos : Form
    {
        clsGraficos graficos;
        public frmGraficosProductos()
        {
            InitializeComponent();
            graficos = new clsGraficos();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MostrarCargando(true);
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            await EjecutarConsultaRemotaAsync(mes, anio);
            MostrarTodo(true);

            

        }

        private void frmGraficosProductos_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBeneficio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_DoubleClick(object sender, EventArgs e)
        {
            

            
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "FILTROS") // Verifica si la pestaña seleccionada es "FILTROS"
            {
                using (frmAuxFiltroProduc formBusqueda = new frmAuxFiltroProduc())
                {
                    if (formBusqueda.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(formBusqueda.ProductoSeleccionado))
                    {
                        string mes = cmbMes.Text;
                        int anio = Convert.ToInt32(cmbAnio.Text);
                        // Asignar el producto seleccionado al campo en el formulario principal
                        
                        bool datosEncontrados = graficos.ObtenerDatosProducto(formBusqueda.ProductoSeleccionado, mes, anio, label11, lblPrecio, lblCosto, lblGanancia, lblTotalVentas, lblCantidadVendida);

                        if (datosEncontrados)
                        {
                            // Permitir el cambio de pestaña si se encontraron datos
                            e.Cancel = false;
                            graficos.MostrarGraficoHorarios(formBusqueda.ProductoSeleccionado, mes, anio, chartHorasProducto);
                            graficos.MostrarGraficoDiasSemana(formBusqueda.ProductoSeleccionado, mes, anio, chartDiasProducto);
                        }
                        else
                        {
                            // Cancelar la selección porque no se encontraron datos
                            MessageBox.Show("No se encontraron datos para el producto seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                        
                        
                    }
                    else
                    {
                        // Cancelar la selección porque no se eligió un producto
                        e.Cancel = true;
                    }
                }
            }
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
                tabControl1.Visible = true;
                cmbAnio.Enabled = false;
                cmbMes.Enabled = false;
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
                    //funcion para migrar datos
                    graficos.MigrarTablasMesAnio(mes, anio);

                    //funcion para solapa productos
                    graficos.CargarGrillaProductosMasVendidos(dgProductos, mes, anio);
                    graficos.MostrarTopProductosMasVendidos(mes, anio, chartTop10);

                    //funcion para solapa categorias
                    graficos.CargarGrillaCategoriaMasVendida(dgRubros, mes, anio);
                    graficos.CargarGrillaRubroMasVendido(dgRubros2, mes, anio);
                    graficos.CargarGrillaSubRubroMasVendido(dgRubro3, mes, anio);


                    //FUNCION PARA SOLAPA BENEFICIOS
                    graficos.CargarProductosMasBeneficiosos(dgvBeneficio, mes, anio);
                    graficos.CargarProductosMasCostosos(dgvCostos, mes, anio);
                    graficos.MostrarTopProductosMasBeneficiosos(mes, anio, chartGanancias);
                    graficos.MostrarTopProductosMasCostosos(mes, anio, chartCostos);

                    //funcion para solapa turnos
                    graficos.CargarProductosMasVendidosPorHorario(dgvMan, mes, anio, "Mañana");
                    graficos.CargarProductosMasVendidosPorHorario(dgvTarde, mes, anio, "Tarde");
                    graficos.CargarProductosMasVendidosNoche(dgvNoche, mes, anio);
                    graficos.MostrarTopProductosMasVendidosPorHorario(mes, anio, chartMan, "Mañana");
                    graficos.MostrarTopProductosMasVendidosPorHorario(mes, anio, chartTarde, "Tarde");
                    graficos.MostrarTopProductosMasVendidosNoche(mes, anio, chartNoche);
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

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            cmbAnio.SelectedIndex = -1;
            cmbMes.SelectedIndex = -1;
            cmbMes.Enabled = true;
            cmbAnio.Enabled = true;
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }
    }
}
