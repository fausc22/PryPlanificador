using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using MySqlX.XDevAPI.Relational;
using Planificador.Properties;
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
    public partial class frmPlaneamientoPlanificador : Form
    {
        public frmPlaneamientoPlanificador()
        {
            InitializeComponent();
        }
        clsPlaneamiento plan = new clsPlaneamiento();
        clsConexion objC = new clsConexion();
        string nombreC;
        string nombreF;
        string form = "turno1, turno2";
        int EsTurno = 0;
        int HorasAnteriores = 0;
        int AcumuladoAnterior = 0;
        


        private void gpEmpleado_Enter(object sender, EventArgs e)
        {

        }

        private void frmPlaneamientoPlanificador_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMes.SelectedIndex = -1;
            cmbAnio.SelectedIndex = -1;
            cmbAnio.Enabled = true;
            cmbMes.Enabled = true;
            btnLimpiar.Enabled = false;
            dgvHora.Visible = false;
            gpCmb.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            
            plan.CargarGrillaPlanificador(dgvHora, mes, anio, form);

            dgvHora.Visible = true;
            cmbMes.Enabled = false;
            cmbAnio.Enabled = false;
            btnLimpiar.Enabled = true;
            button1.Enabled = false;
            btnPdf.Visible = true;
        }

        private void dgvHora_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            plan.CargarTurnos(cmbTurno);
            plan.CargarTurnos(cmbSegundoTurno);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el valor de la celda seleccionada
                object cellValue = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                object fechaFila = dgvHora.Rows[e.RowIndex].Cells[0].Value;
                string fecharda = fechaFila.ToString();
                // Dividir la cadena utilizando el paréntesis como separador

                string[] partesS = fecharda.Split('(');


                string fechaParaAcumuladoAnterior = partesS[0].Trim();




                if (cellValue != null)
                {
                    string valor = cellValue.ToString().ToLower(); // Convertir a minúsculas para ser insensible a mayúsculas y minúsculas

                    if (valor == "libre")
                    {
                        cmbTurno.Text = "Libre";
                        cmbSegundoTurno.Text = "Libre";
                        HorasAnteriores = plan.ObtenerValorAnterior(valor);
                    }
                    else
                    {
                        string[] turnos = valor.Split('/');

                        cmbTurno.Text = turnos[0].Trim();

                        if (turnos.Length == 1)
                        {
                            cmbSegundoTurno.Text = "Libre";
                            HorasAnteriores = plan.ObtenerValorAnterior(turnos[0]);
                        }
                        else if (turnos.Length == 2)
                        {
                            cmbSegundoTurno.Text = turnos[1].Trim();

                            // Asegúrate de llamar a ObtenerValorAnterior para ambos turnos y sumar los resultados
                            int primerTurno = plan.ObtenerValorAnterior(turnos[0]);
                            int segundoTurno = plan.ObtenerValorAnterior(turnos[1].Trim());
                            HorasAnteriores = primerTurno + segundoTurno;
                        }
                        // Puedes agregar lógica adicional para manejar casos con más de dos turnos si es necesario en el futuro
                    }
                }











                DataGridViewColumn colum = dgvHora.Columns[e.ColumnIndex];
                nombreC = colum.HeaderText;
                txtEmpleado.Text = nombreC; 
                AcumuladoAnterior = plan.ObtenerAcumuladoAnterior(nombreC, HorasAnteriores, fechaParaAcumuladoAnterior);
                string fechaA = fechaFila.ToString();
                // Dividir la cadena utilizando el paréntesis como separador
                string[] partes = fechaA.Split('(');

                
                nombreF = partes[0].Trim();
                txtFecha.Text = nombreF;
                // Muestra el ComboBox
                gpCmb.Visible = true;





                // Verificar si hay una fila arriba antes de intentar acceder a ella
                if (e.RowIndex - 1 >= 0)
                {
                    // Obtener el valor de la celda de arriba
                    object valorCeldaArribaFecha = dgvHora.Rows[e.RowIndex - 1].Cells[0].Value;
                    string fechaArriba = valorCeldaArribaFecha.ToString();

                    // Dividir la cadena utilizando el paréntesis como separador
                    string[] partesA = fechaArriba.Split('(');
                    string fecha2 = partesA[0].Trim();

                    // Comparar fechas y tomar decisiones según sea necesario
                    if (fecha2 == nombreF)
                    {
                        EsTurno = 2;
                    }
                    else
                    {
                        EsTurno = 1;
                    }
                }
                else
                {
                    // No hay una fila arriba, manejar según sea necesario
                    // Por ejemplo, puedes establecer EsTurno en un valor predeterminado
                    EsTurno = 1;
                }


            }

            // Verificar si el clic se realizó en una celda válida
            if (e.RowIndex >= 1 && e.RowIndex < dgvHora.Rows.Count - 1)
            {

                
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string mes = cmbMes.Text;
            int anio = Convert.ToInt32(cmbAnio.Text);
            string nuevoValor = string.Empty;
            int cantidadHoras = 0;
            if (cmbSegundoTurno.Text == "Libre")
            {
                nuevoValor = cmbTurno.Text;
                cantidadHoras = Convert.ToInt32(cmbTurno.SelectedValue.ToString());
            }
            else
            {
                nuevoValor = cmbTurno.Text + " / " + cmbSegundoTurno.Text;
                cantidadHoras = Convert.ToInt32(cmbTurno.SelectedValue.ToString()) + Convert.ToInt32(cmbSegundoTurno.SelectedValue.ToString());
            }

            
            //string turno = "turno" + EsTurno;

            int valorHora = objC.HoraEmpleado(nombreC);
            int totalHoras = valorHora * cantidadHoras;

            if (plan.EsFeriado(nombreF) == true)
            {
                totalHoras *= 2;
            }


            plan.ActualizarTurnos(mes, anio, nuevoValor, nombreF, nombreC, cantidadHoras, totalHoras, HorasAnteriores, AcumuladoAnterior);
            plan.CargarGrillaPlanificador(dgvHora, mes, anio, form);
            gpCmb.Visible = false;


        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnio.SelectedIndex != -1 && cmbMes.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE EL MES Y EL AÑO CORRESPONIDENTE EN EL QUE DESEA CONSULTAR LA INFORMACION. PARA MODIFICAR UN TURNO HAGA DOBLE CLICK SOBRE EL HORARIO A MODIFICAR, LUEGO SELECCIONE EL TURNO Y APRIETE MODIFICAR.", "AYUDA", MessageBoxButtons.OK);
        }

        private void dgvHora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            //{
            //    DataGridViewCell cell = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    string valor = cell.Value?.ToString();

            //    if (!string.IsNullOrEmpty(valor))
            //    {
            //        if (valor.Equals("libre", StringComparison.OrdinalIgnoreCase))
            //        {
            //            cell.Style.BackColor = Color.Green; // Cambia el color a verde para "libre"
            //        }
            //        else if (valor.Equals("vacaciones", StringComparison.OrdinalIgnoreCase))
            //        {
            //            cell.Style.BackColor = Color.Yellow; // Cambia el color a amarillo para "vacaciones"
            //        }
            //    }
            //}
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (dgvHora.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Planificador - " + cmbMes.Text + ".pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dgvHora.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;



                            // Modificar el estilo de la celda para las columnas del encabezado
                            PdfPCell headerCell = new PdfPCell();
                            headerCell.BackgroundColor = new BaseColor(0, 102, 204); // Azul
                            headerCell.Padding = 5;

                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            headerCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;

                            // Estilo de fuente para el texto en negrita y azul
                            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD);
                            font.Color = BaseColor.BLACK; // Color de texto blanco

                            // Estilo de fuente para el texto en negrita y azul
                            iTextSharp.text.Font fontt = FontFactory.GetFont(FontFactory.HELVETICA_BOLD);
                            font.Color = BaseColor.BLACK; // Color de texto blanco
                            fontt.Size = 8;


                            // Establecer color de fondo gris para la primera columna
                            PdfPCell greyCell = new PdfPCell();
                            greyCell.BackgroundColor = new BaseColor(169, 169, 169); // Gris
                            greyCell.Padding = 5;
                            greyCell.HorizontalAlignment = Element.ALIGN_LEFT;

                            // Crear documento y escritor
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                foreach (DataGridViewColumn col in dgvHora.Columns)
                                {




                                    switch (col.HeaderText.ToUpper())
                                    {
                                        case "EMANUEL":
                                            headerCell.BackgroundColor = new BaseColor(238, 130, 238); // Violeta
                                            break;
                                        case "PRISCILA":
                                            headerCell.BackgroundColor = new BaseColor(255, 0, 255); // Fucsia
                                            break;
                                        case "ALEJANDRO":
                                            headerCell.BackgroundColor = new BaseColor(64, 224, 208); // Turquesa
                                            break;
                                        case "LAUTARO":
                                            headerCell.BackgroundColor = new BaseColor(160, 82, 45); // Siena
                                            break;
                                        case "CANDELARIA":
                                            headerCell.BackgroundColor = new BaseColor(238, 130, 238); // Lila
                                            break;
                                        case "GABRIEL":
                                            headerCell.BackgroundColor = new BaseColor(255, 255, 0); // Amarillo
                                            break;
                                        case "SANTIAGO":
                                            headerCell.BackgroundColor = new BaseColor(0, 0, 255); // Azul
                                            break;
                                        case "CATALINA":
                                            headerCell.BackgroundColor = new BaseColor(173, 216, 230); // Azul claro
                                            break;
                                        default:
                                            headerCell.BackgroundColor = new BaseColor(255, 255, 255); // Blanco por defecto
                                            break;
                                    }


                                    // Asignar el nombre de la columna al encabezado
                                    headerCell.Phrase = new Phrase(col.HeaderText, fontt);


                                    pTable.AddCell(headerCell);
                                }

                                foreach (DataGridViewRow viewRow in dgvHora.Rows)
                                {
                                    // Crear nueva página si es necesario
                                    if (writer.GetVerticalPosition(false) - pTable.TotalHeight < document.BottomMargin)
                                    {
                                        document.Add(pTable);
                                        pTable.DeleteBodyRows();
                                    }

                                    // Añadir la celda gris para la primera columna
                                    greyCell.Phrase = new Phrase(viewRow.Cells[0].Value.ToString(), fontt);
                                    pTable.AddCell(greyCell);

                                    // Añadir las demás celdas
                                    for (int i = 1; i < dgvHora.Columns.Count; i++)
                                    {
                                        PdfPCell cell = new PdfPCell();
                                        cell.Phrase = new Phrase(viewRow.Cells[i].Value.ToString(), font);

                                        // Cambiar el color de fondo según el valor de la celda
                                        switch (viewRow.Cells[i].Value.ToString().ToLower())
                                        {
                                            case "libre":
                                                cell.BackgroundColor = new BaseColor(0, 128, 0); // Verde
                                                break;
                                            case "días sin goce de sueldo":
                                                cell.BackgroundColor = new BaseColor(255, 255, 0); // Amarillo
                                                break;
                                            case "vacaciones":
                                                cell.BackgroundColor = new BaseColor(64, 224, 208); // Turquesa

                                                break;
                                            default:
                                                cell.BackgroundColor = new BaseColor(255, 165, 0); // Naranja
                                                break;
                                        }

                                        cell.VerticalAlignment = Element.ALIGN_CENTER;
                                        pTable.AddCell(cell);
                                    }
                                }

                                // Agregar la última tabla a la página
                                document.Add(pTable);

                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("PDF creado con éxito!", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }

        }





        private void dgvHora_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvHora.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string valor = cell.Value?.ToString();

                if (!string.IsNullOrEmpty(valor))
                {
                    Color nuevoColor = Color.Empty;

                    if (valor.Equals("libre", StringComparison.OrdinalIgnoreCase))
                    {
                        nuevoColor = Color.Green; // Cambia el color a verde para "libre"
                    }
                    else if (valor.Equals("días sin goce de sueldo", StringComparison.OrdinalIgnoreCase))
                    {
                        nuevoColor = Color.Yellow; // Cambia el color a amarillo para "vacaciones"
                    }
                    else if (valor.Equals("vacaciones", StringComparison.OrdinalIgnoreCase))
                    {
                        nuevoColor = Color.Turquoise; // Cambia el color a amarillo para "vacaciones"
                    }

                    if (nuevoColor != Color.Empty && !e.CellStyle.BackColor.Equals(nuevoColor))
                    {
                        e.CellStyle.BackColor = nuevoColor;
                    }
                }
            }
        }

        private void dgvHora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurno.Text != "libre")
            {
                cmbSegundoTurno.Enabled = true;
            }
        }
    }
}
