using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.util;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Planificador.Properties;

namespace pryPlanificador
{
    public partial class frmRecibo : Form
    {
        public frmRecibo()
        {
            InitializeComponent();

            
                    
        }

        clsConexion objC = new clsConexion();

        private void frmRecibo_Load(object sender, EventArgs e)
        {
            objC.CargarCmbEmpleado(cmbEmpleado);
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string mes = cmbMes.Text;
            string anio = cmbAnio.Text;
            
            gpInfo.Visible = true;
            gpDatos.Visible = true;
            objC.CargarEmpleadoRecibo(empleado, lblId, txtNombre, txtApellido, txtMail, txtFecha, txtAntiguedad, txtHoraNormal, txtDiaVaca, pbFoto);

            objC.CargarDatosRecibo(empleado, anio, mes, txtHsPlanificadas, lblHsPlanificadas, txtHsTrabajadas, lblHsTrabajadas, txtPremios, txtAdelantos);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string mes = cmbMes.Text;
            int subtotal1 = Convert.ToInt32(txtHsTrabajadas.Text) + Convert.ToInt32(txtPremios.Text);
            int subtotal2 = Convert.ToInt32(txtConsumos.Text) + Convert.ToInt32(txtADescontar.Text) + Convert.ToInt32(txtAdelantos.Text);
            int totalll = subtotal1 - subtotal2;

            SaveFileDialog guardar = new SaveFileDialog();
            string titulo = "RECIBO - " + empleado + " - " + mes + ".pdf";
            guardar.FileName = titulo;




            string paginahtml_texto = Resources.Plantilla.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@nombreEmpleado", empleado);
            paginahtml_texto = paginahtml_texto.Replace("@mes", mes);


            string descripcion = objC.DescripcionPremios(txtNombre.Text, cmbAnio.Text, cmbMes.Text);

            string filas1 = string.Empty;
            filas1 += "<tr>";
            filas1 += "<td>HORAS PLANIFICADAS</td>";
            filas1 += "<td>NO SE UTILIZAN PARA EL CALCULO</td>";
            filas1 += "<td>" + lblHsPlanificadas.Text + "</td>";
            filas1 += "<td> $ " + txtHsPlanificadas.Text + "</td>";
            filas1 += "</tr>";

            filas1 += "<tr>";
            filas1 += "<td style=background-color: lightgreen;>HORAS TRABAJADAS</td>";
            filas1 += "<td>HORAS NETAS TRABAJADAS</td>";
            filas1 += "<td>" + lblHsTrabajadas.Text + "</td>";
            filas1 += "<td> $ " + txtHsTrabajadas.Text + "</td>";
            filas1 += "</tr>";

            filas1 += "<tr>";
            filas1 += "<td >PREMIOS</td>";
            filas1 += "<td>" + descripcion + "</td>";
            filas1 += "<td>-</td>";
            filas1 += "<td> $ " + txtPremios.Text + "</td>";
            filas1 += "</tr>";

            paginahtml_texto = paginahtml_texto.Replace("@FILAS1", filas1);
            string subtotal1Text = "$ " + subtotal1.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@subTotal1", subtotal1Text);



            string filas2 = string.Empty;
            filas2 += "<tr>";
            filas2 += "<td>CONSUMOS</td>";
            filas2 += "<td>CONSUMOS EN EL LOCAL A RESTAR</td>";
            filas2 += "<td> $ " + txtConsumos.Text + "</td>";
            filas2 += "</tr>";

            filas2 += "<tr>";
            filas2 += "<td>A DESCONTAR</td>";
            filas2 += "<td>MONTOS A DESCONTAR</td>";
            filas2 += "<td> $ " + txtADescontar.Text + "</td>";
            filas2 += "</tr>";

            filas2 += "<tr>";
            filas2 += "<td >ADELANTOS DE SUELDO</td>";
            filas2 += "<td>ADELANTO DE SUELDO A RESTAR</td>";
            filas2 += "<td> $ " + txtAdelantos.Text + "</td>";
            filas2 += "</tr>";

            paginahtml_texto = paginahtml_texto.Replace("@FILAS2", filas2);
            string subtotal2Text = "$ " + subtotal2.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@subTotal2", subtotal2Text);


            string totalText = "$ " + totalll.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@total", totalText);








            if (guardar.ShowDialog() == DialogResult.OK)
            { 
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer =  PdfWriter.GetInstance(pdfDoc, stream);
                    
                    pdfDoc.Open();
                    pdfDoc.AddHeader("Title", titulo);
                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();

                    stream.Close();

                }

                MessageBox.Show("PDF creado con éxito!");

            }



        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex != -1)
            {
                cmbMes.Enabled = true;
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMes.SelectedIndex != -1)
            {
                cmbAnio.Enabled = true;
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1)
            {
                btnSelec.Enabled = true;
            }
        }

        private void txtPremios_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtPremios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtPremios.Text != "0")
            {
                string descripcion = objC.DescripcionPremios(txtNombre.Text, cmbAnio.Text, cmbMes.Text);
                MessageBox.Show(descripcion);
            }
            
        }

        private void ActualizarTotal()
        {
            int horasTrabajadas = ObtenerValor(txtHsTrabajadas);
            int premios = ObtenerValor(txtPremios);
            int consumos = ObtenerValor(txtConsumos);
            int descuento = ObtenerValor(txtADescontar);
            int adelantos = ObtenerValor(txtAdelantos);

            int total = (horasTrabajadas + premios) - (consumos + descuento + adelantos);

            txtTotal.Text = total.ToString();
        }

        private int ObtenerValor(TextBox textBox)
        {
            // Método auxiliar para obtener el valor numérico de un TextBox
            int valor;
            if (int.TryParse(textBox.Text, out valor))
            {
                return valor;
            }
            else
            {
                return 0; // Valor predeterminado si la conversión no es exitosa
            }
        }


        private void txtHsTrabajadas_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtConsumos_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtADescontar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtAdelantos_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gpDatos.Visible = false;
            gpInfo.Visible  = false;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = false;
            cmbMes.SelectedIndex = -1;
            cmbMes.Enabled = false;
            cmbEmpleado.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EMPLEADO, MES Y AÑO PARA RECIBIR UN INFORME MENSUAL. PARA VER LA DESCRIPCION DE LOS PREMIOS HAGA DOBLE CLICK EN EL MONTO DE PREMIOS. PARA CREAR UN PDF HAGA CLICK EN EL BOTON, ASEGURO DE VERIFICAR QUE LOS DATOS SEAN CORRECTOS. LOS APARTADOS CONSUMOS Y A DESCONTAR DEBEN SER ASIGNADOS MANUALMENTE.");
        }
    }
}
