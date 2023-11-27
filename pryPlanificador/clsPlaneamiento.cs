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

namespace pryPlanificador
{
    class clsPlaneamiento
    {
        static string servidor = "localhost";
        static string bd = "planificadordatabase";
        static string user = "root";
        static string pw = "251199";
        static string port = "3306";




        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user=" + user + ";" + "password=" + pw + ";" + "database=" + bd + ";";

        public void CargarGrillaPlanificador(DataGridView grilla, string Mes, int anio)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            int NroMes = ObtenerNumeroMes(Mes);
            int NroAnio = anio;
            int diasEnMes = DateTime.DaysInMonth(NroAnio, NroMes);
            string tabla = "turnos_" + NroMes + "_" + NroAnio;
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                // Agregar una fila por cada día en el mes
                grilla.Rows.Add($"{dia}/{NroMes}/{NroAnio}"); // Puedes ajustar el formato de la fecha según tus necesidades
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
                        string fecha = row.Cells[0].Value.ToString();

                        foreach (string empleado in empleados)
                        {
                            using (MySqlCommand cmd = new MySqlCommand($"SELECT valor FROM {tabla} WHERE fecha = @fecha AND nombre_empleado = @empleado", conn))
                            {
                                cmd.Parameters.AddWithValue("@fecha", fecha);
                                cmd.Parameters.AddWithValue("@empleado", empleado);

                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        row.Cells[empleado].Value = reader["valor"].ToString();
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

        public void ActualizarTurnos(string Mes, int anio, string valor, string fecha, string nombre)
        {


            try
            {

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    int NroMes = ObtenerNumeroMes(Mes);
                    int NroAnio = anio;
                    
                    string tabla = "turnos_" + NroMes + "_" + NroAnio;
                    string consulta = $"UPDATE {tabla} SET valor = @valor WHERE fecha = @fecha AND nombre_empleado = @nombre";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        

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
