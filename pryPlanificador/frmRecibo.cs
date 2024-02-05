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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;


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
            objC.CargarEmpleadoRecibo(empleado, lblId, txtNombre, txtApellido, txtMail, txtFecha, txtAntiguedad, txtHoraNormal, txtDiaVaca, txtJornada, pbFoto);

            objC.CargarDatosRecibo(empleado, anio, mes, txtHsPlanificadas, lblHsPlanificadas, txtHsTrabajadas, lblHsTrabajadas, txtPremios, txtAdelantos, txtConsumos);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            string empleado = cmbEmpleado.Text;
            string mes = cmbMes.Text;
            int subtotal1 = Convert.ToInt32(txtHsTrabajadas.Text) + Convert.ToInt32(txtPremios.Text);
            int subtotal2 = Convert.ToInt32(txtADescontar.Text) + Convert.ToInt32(txtAdelantos.Text);
            int totalll = subtotal1 - subtotal2;

            SaveFileDialog guardar = new SaveFileDialog();
            string titulo = "RECIBO - " + empleado + " - " + mes + ".pdf";
            guardar.FileName = titulo;




            string paginahtml_texto = Resources.Plantilla.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@nombreEmpleado", empleado);
            paginahtml_texto = paginahtml_texto.Replace("@mes", mes);


            string descripcionPremio = objC.DescripcionPremios(txtNombre.Text, cmbAnio.Text, cmbMes.Text);
            string descripcionAdelanto = objC.DescripcionAdelanto(txtNombre.Text, cmbAnio.Text, cmbMes.Text);

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
            filas1 += "<td>" + descripcionPremio + "</td>";
            filas1 += "<td>-</td>";
            filas1 += "<td> $ " + txtPremios.Text + "</td>";
            filas1 += "</tr>";

            paginahtml_texto = paginahtml_texto.Replace("@FILAS1", filas1);
            string subtotal1Text = "$ " + subtotal1.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@subTotal1", subtotal1Text);



            string filas2 = string.Empty;
            filas2 += "<tr>";
            filas2 += "<td>CONSUMOS</td>";
            filas2 += "<td>CONSUMOS EN EL LOCAL (20% DESCUENTO)</td>";
            filas2 += "<td> $ " + txtADescontar.Text + "</td>";
            filas2 += "</tr>";

            

            filas2 += "<tr>";
            filas2 += "<td >ADELANTOS DE SUELDO</td>";
            filas2 += "<td>"+ descripcionAdelanto +"</td>";
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

                    pdfDoc.AddHeader("PUNTO SUR", titulo);
                    pdfDoc.Add(new Phrase(""));

                    // Agregar logo al costado derecho del título (ajusta la ruta de la imagen según tu proyecto)
                    string logoPath = "../../LOGOINICIO.jpg";

                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(90f, 90f); // Ajusta el tamaño del logo según tus necesidades
                    logo.Alignment = Element.ALIGN_RIGHT;
                    pdfDoc.Add(logo);

                    //// Salto de línea
                    //pdfDoc.Add(Chunk.NEWLINE);

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }


                    // Agregar logo al final del PDF
                    
                    iTextSharp.text.Image logoFooter = iTextSharp.text.Image.GetInstance(logoPath);
                    logoFooter.ScaleAbsolute(90f, 90f); // Ajusta el tamaño del logo según tus necesidades
                    logoFooter.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(logoFooter);

                    // Agregar hora y fecha al final del PDF
                    string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
                    Paragraph dateTimeParagraph = new Paragraph(formattedDateTime, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    dateTimeParagraph.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(dateTimeParagraph);


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
            
            int descuento = ObtenerValor(txtADescontar);
            int adelantos = ObtenerValor(txtAdelantos);

            int total = (horasTrabajadas + premios) - (descuento + adelantos);

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
            int totalEscrito = 0;
            if (!string.IsNullOrEmpty(txtConsumos.Text))
            {
                totalEscrito = Convert.ToInt32(txtConsumos.Text);
            }
                
            int descuento20 = totalEscrito * 20 / 100;
            int totalConDescuento = totalEscrito - descuento20;
            txtADescontar.Text = totalConDescuento.ToString();
              
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

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtTotal.Text);

            if (numero < 0)
            {
                txtTotal.BackColor = Color.Red;
            }
            else
            {
                txtTotal.BackColor = Color.Green;
            }
        }

        private void txtAdelantos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtAdelantos.Text != "0")
            {
                string descripcion = objC.DescripcionAdelanto(txtNombre.Text, cmbAnio.Text, cmbMes.Text);
                MessageBox.Show(descripcion);
            }
        }
    }
}
