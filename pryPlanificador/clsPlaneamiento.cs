﻿using System;
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

namespace pryPlanificador
{
    class clsPlaneamiento
    {
        //static string servidor = "localhost";
        //static string bd = "planificadordatabase";
        //static string user = "root";
        //static string pw = "251199";
        //static string port = "3306";




        static string servidor = "www.rsoftware.com.ar";
        static string bd = "planificadordatabase";
        static string user = "planificador";
        static string pw = "251199";
        static string port = "3306";



        string cadenaConexion = "server=" + servidor + ";" + "user=" + user + ";" + "password=" + pw + ";" + "database=" + bd + ";";




        private static string ObtenerNombreDiaEnEspanol(DayOfWeek dia)
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
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    {
                        

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);

                                // Crea una nueva columna de ComboBox para cada empleado
                                DataGridViewTextBoxColumn comboBoxColumn = new DataGridViewTextBoxColumn();
                                comboBoxColumn.HeaderText = empleado;
                                comboBoxColumn.Name = empleado; // Nombre de la columna para referencia futura
                                                                // Cambia el color de fondo de la columna a azul
                                comboBoxColumn.DefaultCellStyle.BackColor = Color.DarkSalmon;


                                // Agrega la columna ComboBox al DataGridView
                                grilla.Columns.Add(comboBoxColumn);

                            }
                            // Bloquear los títulos de las columnas
                            foreach (DataGridViewColumn column in grilla.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Desactiva la capacidad de ordenar las columnas
                                column.Resizable = DataGridViewTriState.False; // Evita que se pueda cambiar el tamaño de las columnas
                            }
                        }
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
                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    {


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);

                                // Crea una nueva columna de ComboBox para cada empleado
                                DataGridViewTextBoxColumn comboBoxColumn = new DataGridViewTextBoxColumn();
                                comboBoxColumn.HeaderText = empleado;
                                comboBoxColumn.Name = empleado; // Nombre de la columna para referencia futura
                                                                // Cambia el color de fondo de la columna a azul
                                comboBoxColumn.DefaultCellStyle.BackColor = Color.DarkSalmon;


                                // Agrega la columna ComboBox al DataGridView
                                grilla.Columns.Add(comboBoxColumn);

                            }
                            // Bloquear los títulos de las columnas
                            foreach (DataGridViewColumn column in grilla.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Desactiva la capacidad de ordenar las columnas
                                column.Resizable = DataGridViewTriState.False; // Evita que se pueda cambiar el tamaño de las columnas
                            }
                        }
                    }

                    // Obtener los valores para cada fecha y empleado
                    foreach (DataGridViewRow row in grilla.Rows)
                    {


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

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM horarios", conn))
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

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM horarios", conn))
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


        public void ActualizarTurnos(string Mes, int anio, string valor, string fecha, string nombre, int horas, int acumulado)
        {
            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            string tablaAnual = "totales_" + NroAnio;
            string tabla = "turnos_" + NroAnio;
            int horasTotales = 0;
            int acumuladoTotal = 0;
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
                                horasTotales = Convert.ToInt32(reader["horas"]);
                                acumuladoTotal = Convert.ToInt32(reader["acumulado"]);
                            }
                            
                        }
                    }
                        
                    string consulta = $"UPDATE {tabla} SET valor = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre";
                    
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horas", horas);
                        cmd.Parameters.AddWithValue("@acumulado", acumulado);


                        cmd.ExecuteNonQuery();
                    }

                    string consulta2 = $"UPDATE {tablaAnual} SET horas = @horas, acumulado = @acumulado WHERE mes = @fecha AND nombre_empleado = @nombre";
                    int horasAgregar = horasTotales + horas;
                    int acumuladoAgregar = acumuladoTotal + acumulado;
                    

                    using (MySqlCommand cmd = new MySqlCommand(consulta2, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@fecha", NroMes);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horas", horasAgregar);
                        cmd.Parameters.AddWithValue("@acumulado", acumuladoAgregar);


                        cmd.ExecuteNonQuery();
                    }
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
    }
}
