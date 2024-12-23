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
using Planificador;

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
            // Obtener nombres de las columnas (empleados)
            List<string> nombresEmpleados = new List<string>();
            foreach (DataGridViewColumn column in dgvHora.Columns)
            {
                if (column.HeaderText != "Fecha" && column.HeaderText != "Horario")
                {
                    nombresEmpleados.Add(column.HeaderText);
                }
            }

            // Mostrar el formulario auxiliar para la selección
            using (frmAuxPlaniHorarios formSeleccionar = new frmAuxPlaniHorarios(nombresEmpleados))
            {
                if (formSeleccionar.ShowDialog() == DialogResult.OK)
                {
                    // Recuperar empleados seleccionados
                    List<string> empleadosSeleccionados = formSeleccionar.EmpleadosSeleccionados;

                    if (empleadosSeleccionados.Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar al menos un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Generar el PDF solo con los empleados seleccionados
                    GenerarPdf(empleadosSeleccionados);
                }
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

        private void GenerarPdf(List<string> empleadosSeleccionados)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (*.pdf)|*.pdf";
            save.FileName = "Planificador - " + cmbMes.Text + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfPTable pTable = new PdfPTable(empleadosSeleccionados.Count + 1); // +1 para la columna "Horario"
                    pTable.DefaultCell.Padding = 2;
                    pTable.WidthPercentage = 100;
                    pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                    // Crear documento
                    using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                        PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                        document.Open();

                        // Configuración de estilos
                        iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
                        iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                        PdfPCell headerCell = new PdfPCell
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 5
                        };

                        PdfPCell greyCell = new PdfPCell
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 5,
                            BackgroundColor = new BaseColor(169, 169, 169) // Gris
                        };

                        // Agregar encabezado "Horario" con color predeterminado
                        headerCell.BackgroundColor = new BaseColor(0, 102, 204); // Azul para "Horario"
                        headerCell.Phrase = new Phrase("Horario", headerFont);
                        pTable.AddCell(headerCell);

                        // Agregar encabezados para cada empleado con colores específicos
                        foreach (string empleado in empleadosSeleccionados)
                        {
                            switch (empleado.ToUpper())
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

                            headerCell.Phrase = new Phrase(empleado, headerFont);
                            pTable.AddCell(headerCell);
                        }

                        // Agregar filas
                        foreach (DataGridViewRow row in dgvHora.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // Columna "Horario" (primera columna en gris)
                            greyCell.Phrase = new Phrase(row.Cells[0].Value?.ToString() ?? "", cellFont);
                            pTable.AddCell(greyCell);

                            // Columnas seleccionadas
                            foreach (string empleado in empleadosSeleccionados)
                            {
                                foreach (DataGridViewColumn col in dgvHora.Columns)
                                {
                                    if (col.HeaderText == empleado)
                                    {
                                        PdfPCell cell = new PdfPCell
                                        {
                                            Phrase = new Phrase(row.Cells[col.Index].Value?.ToString() ?? "", cellFont),
                                            VerticalAlignment = Element.ALIGN_CENTER
                                        };

                                        // Cambiar color de fondo según el valor de la celda
                                        string cellValue = row.Cells[col.Index].Value?.ToString()?.ToLower();
                                        switch (cellValue)
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

                                        pTable.AddCell(cell);
                                    }
                                }
                            }
                        }

                        // Agregar tabla al documento
                        document.Add(pTable);
                        document.Close();
                    }

                    MessageBox.Show("PDF creado con éxito!", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while exporting data: " + ex.Message);
                }
            }
        }



    }
}
