using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;
using System.Linq.Expressions;

namespace pryPlanificador
{
    class clsPlaneamiento
    {
        static string servidor = "localhost";
        static string bd = "planificador";
        static string user = "root";
        static string pw = "251199";
        static string port = "3306";


        //static string servidor = "localhost";
        //static string bd = "planificador";
        //static string user = "planificador";
        //static string pw = "251199";
        //static string port = "3306";







        //static string servidor = "www.rsoftware.com.ar";
        //static string bd = "planificadordatabase";
        //static string user = "planificador";
        //static string pw = "251199";
        //static string port = "3306";



        //KIOSCO

        //static string servidor = "26.206.2.45";
        //static string bd = "planificador";
        //static string user = "planificador";
        //static string pw = "251199";
        //static string port = "3306";






        string cadenaConexion = "server=" + servidor + ";port=" + port + ";user=" + user + ";password=" + pw + ";database=" + bd + ";";





        public static string ObtenerNombreDiaEnEspanol(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miércoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sábado";
                default:
                    return string.Empty; // Manejar el caso por defecto o incorrecto si es necesario
            }
        }
        public void CargarGrillaPlanificador(DataGridView grilla, string Mes, int anio, string form)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            fechaColumn.Width = 150;
            grilla.Columns.Add(fechaColumn);

            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            int diasEnMes = DateTime.DaysInMonth(NroAnio, NroMes);
            string tabla = "turnos_" + NroAnio;
            string fecha = string.Empty;
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                if (dia < 10)
                {
                    if (NroMes < 10)
                    {
                        fecha = $"0{dia}/0{NroMes}/{anio}";
                    }
                    else
                    {
                        fecha = $"0{dia}/{NroMes}/{anio}";
                    }

                }
                else
                {
                    if (NroMes < 10)
                    {
                        fecha = $"{dia}/0{NroMes}/{anio}";
                    }
                    else
                    {
                        fecha = $"{dia}/{NroMes}/{anio}";
                    }
                }


                // Convertir la cadena de fecha a un objeto DateTime
                DateTime fechaDateTime = DateTime.ParseExact(fecha, "d/MM/yyyy", CultureInfo.InvariantCulture);

                // Obtener el día de la semana
                DayOfWeek ingles = fechaDateTime.DayOfWeek;
                string diaSemana = ObtenerNombreDiaEnEspanol(ingles);

                string agregar1 = fecha + " (" + diaSemana + ") ";

                int index1 = grilla.Rows.Add(agregar1);

                if (EsFeriado(fecha) == true)
                {
                    grilla.Rows[index1].Cells[0].Style.BackColor = Color.Red;
                    // Puedes ajustar el formato de la fecha según tus necesidades
                }
                // Agregar una fila por cada día en el mes

                


            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    List<string> empleados = new List<string>();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados ORDER BY nombre ASC", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);
                            }
                        }
                    }

                    // Ordenar la lista de empleados alfabéticamente
                    empleados.Sort();

                    // Agregar las columnas ordenadas al DataGridView
                    foreach (string empleado in empleados)
                    {
                        DataGridViewTextBoxColumn comboBoxColumn = new DataGridViewTextBoxColumn();
                        comboBoxColumn.HeaderText = empleado;
                        comboBoxColumn.Name = empleado;
                        comboBoxColumn.DefaultCellStyle.BackColor = Color.DarkSalmon;

                        // Agrega la columna ComboBox al DataGridView
                        grilla.Columns.Add(comboBoxColumn);

                        // Cambiar el color de fondo de las columnas en el encabezado
                        if (empleado.Equals("EMANUEL", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Red; // Violeta
                        }
                        else if (empleado.Equals("PRISCILA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Fuchsia;
                        }
                        else if (empleado.Equals("ALEJANDRO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Turquoise;
                        }
                        else if (empleado.Equals("LAUTARO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Sienna;
                        }
                        else if (empleado.Equals("CANDELARIA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Violet; // Lila
                        }
                        else if (empleado.Equals("GABRIEL", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Yellow;
                        }
                        else if (empleado.Equals("SANTIAGO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Blue;
                        }
                        else if (empleado.Equals("CATALINA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.OrangeRed;
                        }
                    }

                    // Bloquear los títulos de las columnas
                    foreach (DataGridViewColumn column in grilla.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.Resizable = DataGridViewTriState.False;
                    }


                    
                    // Iterar sobre las filas de la grilla
                    foreach (DataGridViewRow row in grilla.Rows)
                    {
                        // Obtener la fecha de la fila actual
                        string fechaA = row.Cells[0].Value.ToString();

                        // Asegurarse de que la fechaA no sea nula antes de procesar
                        if (!string.IsNullOrEmpty(fechaA))
                        {
                            // Dividir la cadena utilizando el paréntesis como separador
                            string[] partes = fechaA.Split('(');

                            // La primera parte debe contener la fecha
                            string fechaString = partes[0].Trim();

                            

                            // Iterar sobre los empleados
                            foreach (string empleado in empleados)
                            {
                                
                                

                                using (MySqlCommand cmd = new MySqlCommand($"SELECT turno FROM {tabla} WHERE fecha = @fecha AND nombre_empleado = @empleado", conn))
                                {
                                    cmd.Parameters.AddWithValue("@fecha", fechaString);
                                    cmd.Parameters.AddWithValue("@empleado", empleado);

                                    using (MySqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            row.Cells[empleado].Value = reader["turno"].ToString();
                                        }
                                    }
                                }

                                
                            }
                            
                        }
                    }




                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        public void CargarGrillaPlanificador2(DataGridView grilla, string Mes, int anio, string form)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            fechaColumn.Width = 150;
            grilla.Columns.Add(fechaColumn);

            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            int diasEnMes = DateTime.DaysInMonth(NroAnio, NroMes);
            string tabla = "turnos_" + NroAnio;
            string fecha = string.Empty;
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                if (dia < 10)
                {
                    if (NroMes < 10)
                    {
                        fecha = $"0{dia}/0{NroMes}/{anio}";
                    }
                    else
                    {
                        fecha = $"0{dia}/{NroMes}/{anio}";
                    }

                }
                else
                {
                    if (NroMes < 10)
                    {
                        fecha = $"{dia}/0{NroMes}/{anio}";
                    }
                    else
                    {
                        fecha = $"{dia}/{NroMes}/{anio}";
                    }
                }


                // Convertir la cadena de fecha a un objeto DateTime
                DateTime fechaDateTime = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Obtener el día de la semana
                DayOfWeek ingles = fechaDateTime.DayOfWeek;
                string diaSemana = ObtenerNombreDiaEnEspanol(ingles);

                string agregar = fecha + " (" + diaSemana + ") ";

                int index = grilla.Rows.Add(agregar);

                if (EsFeriado(fecha) == true)
                {
                    grilla.Rows[index].Cells[0].Style.BackColor = Color.Red;
                    // Puedes ajustar el formato de la fecha según tus necesidades
                }
                // Agregar una fila por cada día en el mes

            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    List<string> empleados = new List<string>();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados ORDER BY nombre ASC", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);
                            }
                        }
                    }

                    // Ordenar la lista de empleados alfabéticamente
                    empleados.Sort();

                    // Agregar las columnas ordenadas al DataGridView
                    foreach (string empleado in empleados)
                    {
                        DataGridViewTextBoxColumn comboBoxColumn = new DataGridViewTextBoxColumn();
                        comboBoxColumn.HeaderText = empleado;
                        comboBoxColumn.Name = empleado;
                        comboBoxColumn.DefaultCellStyle.BackColor = Color.DarkSalmon;

                        // Agrega la columna ComboBox al DataGridView
                        grilla.Columns.Add(comboBoxColumn);

                        // Cambiar el color de fondo de las columnas en el encabezado
                        if (empleado.Equals("TITI", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Purple; // Violeta
                        }
                        else if (empleado.Equals("PRISCILA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Fuchsia;
                        }
                        else if (empleado.Equals("ALEJANDRO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.LightBlue;
                        }
                        else if (empleado.Equals("LAUTARO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Green;
                        }
                        else if (empleado.Equals("CANDELARIA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Lavender; // Lila
                        }
                        else if (empleado.Equals("MICAELA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Turquoise;
                        }
                        else if (empleado.Equals("CATALINA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Violet;
                        }
                    }

                    // Bloquear los títulos de las columnas
                    foreach (DataGridViewColumn column in grilla.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.Resizable = DataGridViewTriState.False;
                    }

                    // Obtener los valores para cada fecha y empleado
                    foreach (DataGridViewRow row in grilla.Rows)
                    {

                        string fechaA = row.Cells[0].Value.ToString();
                        // Dividir la cadena utilizando el paréntesis como separador
                        string[] partes = fechaA.Split('(');

                        // La primera parte debe contener la fecha
                        string fechaString = partes[0].Trim();

                        foreach (string empleado in empleados)
                        {
                            string tablaAnual = "totales_" + NroAnio;
                            
                            //using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaAnual} WHERE mes = @mes AND nombre_empleado = @nombre", conn))
                            //{
                            //    cmd.Parameters.AddWithValue("@nombre", empleado);
                            //    cmd.Parameters.AddWithValue("@mes", NroMes);

                            //    using (MySqlDataReader reader = cmd.ExecuteReader())
                            //    {
                            //        if (reader.Read())
                            //        {
                            //            horasTotales = Convert.ToInt32(reader["horas"]);
                            //            acumuladoTotal = Convert.ToInt32(reader["acumulado"]);
                            //        }

                            //    }
                            //}












                            using (MySqlCommand cmd = new MySqlCommand($"SELECT {form} FROM {tabla} WHERE fecha = @fecha AND nombre_empleado = @empleado", conn))
                            {
                                cmd.Parameters.AddWithValue("@fecha", fechaString);
                                cmd.Parameters.AddWithValue("@empleado", empleado);

                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        row.Cells[empleado].Value = reader[form].ToString();
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }





        public void CargarGrillaTotales(DataGridView grilla, string Mes, int anio, string form)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "MES";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            fechaColumn.Width = 150;
            grilla.Columns.Add(fechaColumn);
            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            string tabla = "totales_" + NroAnio;
            grilla.Rows.Add(Mes);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    List<string> empleados = new List<string>();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados ORDER BY nombre ASC", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);
                            }
                        }
                    }

                    // Ordenar la lista de empleados alfabéticamente
                    empleados.Sort();

                    // Agregar las columnas ordenadas al DataGridView
                    foreach (string empleado in empleados)
                    {
                        DataGridViewTextBoxColumn comboBoxColumn = new DataGridViewTextBoxColumn();
                        comboBoxColumn.HeaderText = empleado;
                        comboBoxColumn.Name = empleado;
                        comboBoxColumn.DefaultCellStyle.BackColor = Color.DarkSalmon;

                        // Agrega la columna ComboBox al DataGridView
                        grilla.Columns.Add(comboBoxColumn);

                        // Cambiar el color de fondo de las columnas en el encabezado
                        if (empleado.Equals("TITI", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Purple; // Violeta
                        }
                        else if (empleado.Equals("PRISCILA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Fuchsia;
                        }
                        else if (empleado.Equals("ALEJANDRO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.LightBlue;
                        }
                        else if (empleado.Equals("LAUTARO", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Green;
                        }
                        else if (empleado.Equals("Fecha", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Beige; // Lila
                        }
                        else if (empleado.Equals("MICAELA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Turquoise;
                        }
                        else if (empleado.Equals("CATALINA", StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Violet;
                        }
                        else
                        {
                            comboBoxColumn.HeaderCell.Style.BackColor = Color.Lavender;
                        }
                    }

                    // Bloquear los títulos de las columnas
                    foreach (DataGridViewColumn column in grilla.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.Resizable = DataGridViewTriState.False;
                    }

                    foreach (string empleado in empleados)
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"SELECT {form} FROM {tabla} WHERE mes = @fecha AND nombre_empleado = @empleado", conn))
                        {
                            cmd.Parameters.AddWithValue("@fecha", NroMes);
                            cmd.Parameters.AddWithValue("@empleado", empleado);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    grilla.Rows[0].Cells[empleado].Value = reader[form].ToString();
                                }
                            }
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        public int ObtenerNumeroMes(string mesTexto)
        {
            switch (mesTexto.ToUpper())
            {
                case "ENERO":
                    return 1;
                case "FEBRERO":
                    return 2;
                case "MARZO":
                    return 3;
                case "ABRIL":
                    return 4;
                case "MAYO":
                    return 5;
                case "JUNIO":
                    return 6;
                case "JULIO":
                    return 7;
                case "AGOSTO":
                    return 8;
                case "SEPTIEMBRE":
                    return 9;
                case "OCTUBRE":
                    return 10;
                case "NOVIEMBRE":
                    return 11;
                case "DICIEMBRE":
                    return 12;
                default:
                    return 0;
            }
        }

        public void CargarGrillaTurnos(DataGridView grilla)
        {
            // Limpiar la grilla
            grilla.Rows.Clear();



            foreach (DataGridViewColumn column in grilla.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Desactiva la capacidad de ordenar las columnas
                column.Resizable = DataGridViewTriState.False; // Evita que se pueda cambiar el tamaño de las columnas
            }

            try
            {

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM horarios ORDER BY horaInicio ASC", conn))
                    {


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                grilla.Rows.Add(reader["Id"], reader["turnos"], reader["horaInicio"], reader["horaFin"], reader["horas"]);




                            }
                        }
                    }
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        public void CargarTurnos(ComboBox cmb)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM horarios ORDER BY horaInicio ASC", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dtHora = new DataTable();

                            if (reader.HasRows)
                            {
                                dtHora.Load(reader);
                                cmb.DataSource = dtHora;
                                cmb.ValueMember = "horas";
                                cmb.DisplayMember = "turnos"; // Corregido: Usar "turno" en lugar de "turnos"
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public bool EsFeriado(string fecha)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM feriados WHERE fecha = @fecha", conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        object result = cmd.ExecuteScalar();
                        int count = result != null ? Convert.ToInt32(result) : 0;

                        if (count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        public void ActualizarTurnos(string Mes, int anio, string valor, string fecha, string nombre, int horas, int acumulado, int horasAnteriores, int acumuladoAnterior)
        {
            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            string tablaAnual = "totales_" + NroAnio;
            string tabla = "turnos_" + NroAnio;
            int horasRegistradas = 0;
            int acumuladoRegistrado = 0;
            int horasMensual = 0;
            int acumuladoMensual = 0;
            try
            {

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaAnual} WHERE mes = @mes AND nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", NroMes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                horasMensual = Convert.ToInt32(reader["horas"]);
                                acumuladoMensual = Convert.ToInt32(reader["acumulado"]);
                            }

                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tabla} WHERE fecha = @fecha AND nombre_empleado = @nombre", conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                horasRegistradas = Convert.ToInt32(reader["horas"]);
                                acumuladoRegistrado = Convert.ToInt32(reader["acumulado"]);
                            }
                        }
                    }

                    


                    //horasMensual = (horasMensual - horasAnteriores) + horas;
                    //acumuladoMensual = (acumuladoMensual - acumuladoAnterior) + acumulado;
                    //horasTotales = (horasTotales - horasAnteriores) + horas;
                    //acumuladoTotal = (acumuladoTotal - acumuladoAnterior) + acumulado;


                    horasMensual = Math.Max((horasMensual - horasAnteriores) + horas, 0);
                    acumuladoMensual = Math.Max((acumuladoMensual - acumuladoAnterior) + acumulado, 0);
                    horasRegistradas = Math.Max((horasRegistradas - horasAnteriores) + horas, 0);
                    acumuladoRegistrado = Math.Max((acumuladoRegistrado - acumuladoAnterior) + acumulado, 0);


                    

                    string consulta = $"UPDATE {tabla} SET turno = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre";
                    
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horas", horasRegistradas);
                        cmd.Parameters.AddWithValue("@acumulado", acumuladoRegistrado);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("TURNO ACTUALIZADO CON ÉXITO.");
                    }

                    string consulta2 = $"UPDATE {tablaAnual} SET horas = @horas, acumulado = @acumulado WHERE mes = @fecha AND nombre_empleado = @nombre";
                    


                    using (MySqlCommand cmd = new MySqlCommand(consulta2, conn))
                    {

                        cmd.Parameters.AddWithValue("@fecha", NroMes);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horas", horasMensual);
                        cmd.Parameters.AddWithValue("@acumulado", acumuladoMensual);


                        cmd.ExecuteNonQuery();
                    }
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }


        public int ObtenerValorAnterior(string turno)
        {
            try 
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    int horas = 0;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT horas FROM horarios WHERE turnos = @turnos", conn))
                    {
                        cmd.Parameters.AddWithValue("@turnos", turno);

                        using (MySqlDataReader rdr = cmd.ExecuteReader()) 
                        {
                            if (rdr.Read())
                            {
                                horas = rdr.GetInt32(0);
                            }
                        }
                    }
                    return horas;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return 0;

            }

        }

        public int ObtenerAcumuladoAnterior(string nombre, int horas, string fecha)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    int sueldo = 0;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                sueldo = rdr.GetInt32(0);
                            }
                        }

                    }

                    int TotalEnviar = sueldo * horas;
                    if (EsFeriado(fecha) == true)
                    {
                        TotalEnviar *= 2;
                    }
                    return TotalEnviar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return 0;

            }

        }


        public void ActualizarMesTrabajadoPlanificador(string nombre, int diferencia)
        {
            int AcumuladoFaltante = 0;
            int AcumuladoAnterior = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(cadenaConexion))
                {
                    con.Open();

                    using (MySqlTransaction trans = con.BeginTransaction())
                    {
                        try
                        {
                            DateTime fechaActual = DateTime.Now;

                            DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                            string fechaInicioMes = primerDiaDelMes.ToString("dd/MM/yyyy");


                            List<DateTime> fechas = new List<DateTime>();

                            for (DateTime fecha = primerDiaDelMes; fecha <= fechaActual; fecha = fecha.AddDays(1))
                            {
                                fechas.Add(fecha);
                            }




                            foreach (DateTime fecha in fechas)
                                {

                                    using (MySqlCommand cmd2 = new MySqlCommand("SELECT horas, acumulado FROM turnos_2024 WHERE nombre_empleado = @nombre AND fecha = @fecha", con))
                                    {
                                        cmd2.Parameters.AddWithValue("@nombre", nombre);
                                        cmd2.Parameters.AddWithValue("@fecha", fecha.ToString("dd/MM/yyyy"));

                                        using (MySqlDataReader rdr = cmd2.ExecuteReader())
                                        {
                                            if (rdr.Read())
                                            {
                                                int horasTrabajadas = (int)rdr["horas"];
                                                
                                                
                                                AcumuladoAnterior = Convert.ToInt32(rdr["acumulado"]);
                                            AcumuladoFaltante = diferencia * horasTrabajadas;
                                            }
                                        }
                                    }

                                
                                int AcumuladoBD = AcumuladoAnterior + AcumuladoFaltante;
                                


                                using (MySqlCommand updateCmd = new MySqlCommand("UPDATE turnos_2024 SET acumulado = @acumulado WHERE nombre_empleado = @nombre AND fecha = @fecha", con, trans))
                                {
                                        updateCmd.Parameters.AddWithValue("@nombre", nombre);
                                        updateCmd.Parameters.AddWithValue("@acumulado", AcumuladoBD);
                                        updateCmd.Parameters.AddWithValue("@fecha", fecha.ToString("dd/MM/yyyy"));

                                        updateCmd.ExecuteNonQuery();
                                }

                                AcumuladoFaltante = 0;
                                AcumuladoAnterior = 0;


                                using (MySqlCommand cmd3 = new MySqlCommand("SELECT horas, acumulado FROM totales_2024 WHERE nombre_empleado = @nombre AND mes = @fecha", con))
                                {
                                    int fechaMesNumero = ObtenerNumeroMes(fecha.ToString("MMMM"));
                                    cmd3.Parameters.AddWithValue("@nombre", nombre);
                                    cmd3.Parameters.AddWithValue("@fecha", fechaMesNumero);

                                    using (MySqlDataReader rdr = cmd3.ExecuteReader())
                                    {
                                        if (rdr.Read())
                                        {
                                            int horasTrabajadas = (int)rdr["horas"];


                                            AcumuladoAnterior = Convert.ToInt32(rdr["acumulado"]);
                                            AcumuladoFaltante = diferencia * horasTrabajadas;
                                        }
                                    }
                                }

                                int AcumuladoBD2 = AcumuladoAnterior + AcumuladoFaltante;


                                using (MySqlCommand updateCmd2 = new MySqlCommand("UPDATE totales_2024 SET acumulado = @acumulado WHERE nombre_empleado = @nombre AND mes = @fecha", con, trans))
                                {
                                    int fechaMesNumero = ObtenerNumeroMes(fecha.ToString("MMMM"));
                                    updateCmd2.Parameters.AddWithValue("@nombre", nombre);
                                    updateCmd2.Parameters.AddWithValue("@acumulado", AcumuladoBD2);
                                    updateCmd2.Parameters.AddWithValue("@fecha", fechaMesNumero);

                                    updateCmd2.ExecuteNonQuery();
                                }
                                AcumuladoFaltante = 0;
                                AcumuladoAnterior = 0;
                            }
                            

                            trans.Commit();
                            MessageBox.Show("SE ACTUALIZARON LOS ACUMULADOS DEL EMPLEADO.");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            // Loguea el error o maneja de otra manera apropiada
                            MessageBox.Show("Error al actualizar el mes trabajado: " + ex.Message);
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Loguea el error o maneja de otra manera apropiada
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public void GenerarTurnosYTotales(int year)
        {
            try
            {
                // Conexión a la base de datos
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    // Obtener todos los empleados
                    List<string> empleados = new List<string>();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empleados.Add(reader.GetString("nombre"));
                        }
                    }

                    // Insertar registros en turnos y totales para cada empleado
                    foreach (var empleado in empleados)
                    {
                        for (int mes = 1; mes <= 12; mes++)
                        {
                            // Insertar totales para cada mes
                            using (MySqlCommand cmdTotales = new MySqlCommand(
                                $"INSERT INTO totales_2025 (mes, nombre_empleado, horas, acumulado) VALUES (@mes, @nombre, @horas, @acumulado)", conn))
                            {
                                cmdTotales.Parameters.AddWithValue("@mes", mes);
                                cmdTotales.Parameters.AddWithValue("@nombre", empleado);
                                cmdTotales.Parameters.AddWithValue("@horas", 0);
                                cmdTotales.Parameters.AddWithValue("@acumulado", 0);
                                cmdTotales.ExecuteNonQuery();
                            }

                            // Insertar turnos para cada día del mes
                            int diasEnMes = DateTime.DaysInMonth(year, mes);
                            for (int dia = 1; dia <= diasEnMes; dia++)
                            {
                                string fecha = new DateTime(year, mes, dia).ToString("dd/MM/yyyy");
                                using (MySqlCommand cmdTurnos = new MySqlCommand(
                                    $"INSERT INTO turnos_2025 (fecha, nombre_empleado, turno, horas, acumulado) VALUES (@fecha, @nombre, @turno, @horas, @acumulado)", conn))
                                {
                                    cmdTurnos.Parameters.AddWithValue("@fecha", fecha);
                                    cmdTurnos.Parameters.AddWithValue("@nombre", empleado);
                                    cmdTurnos.Parameters.AddWithValue("@turno", "Libre");
                                    cmdTurnos.Parameters.AddWithValue("@horas", 0);
                                    cmdTurnos.Parameters.AddWithValue("@acumulado", 0);
                                    cmdTurnos.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    conn.Close();
                }

                MessageBox.Show("Turnos y totales generados con éxito para el año " + year, "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar turnos y totales: " + ex.Message, "Error");
            }
        }



    }
}
