using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace pryPlanificador
{
    public class clsPlanificar
    {
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbCommand cmdC;
        OleDbCommand cmdA;
        OleDbCommand cmdD;
        OleDbDataReader rdrC;
        OleDbDataReader rdr;
        OleDbCommand cmdH;
        OleDbDataReader rdrH;

        //PROCEDIMIENTOS PLANIFICADOR

        public void PintarCeldasLibresVerde(DataGridView grilla)
        {
            foreach (DataGridViewRow row in grilla.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals("Libre", StringComparison.OrdinalIgnoreCase))
                    {
                        cell.Style.BackColor = Color.Green;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
        }
        public void CargarGrillaPlanificador(DataGridView grilla)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            //AGREGA LAS COLUMNAS DE LOS EMPLEADOS
            try
            {
                

                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM empleados";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string empleado = rdr["nombre"].ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM OctPlanificador";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH[0], rdrH[1], rdrH[2], rdrH[3], rdrH[4], rdrH[5], rdrH[6], rdrH[7], rdrH[8], rdrH[9], rdrH[10]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            PintarCeldasLibresVerde(grilla);
        }
        public void CargarTurnos(ComboBox cmb)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";

            try
            {
                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM horarios";
                rdrH = cmdH.ExecuteReader();

                cmb.Items.Clear();

                DataTable dtHora = new DataTable();

                if (rdrH.HasRows) 
                {
                    dtHora.Load(rdrH);
                    cmb.DataSource = dtHora;
                    cmb.ValueMember = "horas";
                    cmb.DisplayMember = "turnos";
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //PROCEDIMIENTO PARA ACTUALIZAR LAS HORAS PARA QUE SEA LIBRE O 8 A 15 X EJ
        public void ActualizarPlanifcador(int id, string Empleado, string nuevoValor)
        {
            try
            {
                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";
                cnn = new OleDbConnection(conexion);
                cnn.Open();

                // Prepara una consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE OctPlanificador SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(consulta, cnn);
                
                cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                cmd.Parameters.AddWithValue("@ID", id);

                // Ejecuta la consulta
                cmd.ExecuteNonQuery();

                // Cierra la conexión
                cnn.Close();

                MessageBox.Show("El valor se ha actualizado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        //PROCEDIMIENTOS HORAS TRABAJADAS


        //PROCEDIMIENTO PARA SUMAR EN LA TABLA HORAS LA CANTIDAD DE HORAS SEGUN EL HORARIO ELGIDO

        public void CargarGrilla(DataGridView grilla)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            //AGREGA LAS COLUMNAS DE LOS EMPLEADOS
            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM empleados";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string empleado = rdr["nombre"].ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM OctHoras";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH[0], rdrH[1], rdrH[2], rdrH[3], rdrH[4], rdrH[5], rdrH[6], rdrH[7], rdrH[8], rdrH[9], rdrH[10]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            PintarHorarios(grilla);
        }

        public void PintarHorarios(DataGridView grilla)
        {
            foreach (DataGridViewRow row in grilla.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !cell.Value.ToString().Equals("0"))
                    {
                        cell.Style.BackColor = Color.Green;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        public void CargarHorarios(ComboBox cmb)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";

            try
            {
                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM horarios";
                rdrH = cmdH.ExecuteReader();

                HashSet<string> horasUnicas = new HashSet<string>(); // HashSet para almacenar valores únicos

                while (rdrH.Read())
                {
                    string horas = rdrH["horas"].ToString();

                    // Verifica si el valor ya está en el HashSet antes de agregarlo
                    if (!horasUnicas.Contains(horas))
                    {
                        horasUnicas.Add(horas); // Agrega el valor al HashSet
                    }
                }

                // Convierte y ordena los valores numéricos
                List<int> horasOrdenadas = horasUnicas.Select(int.Parse).ToList();
                horasOrdenadas.Sort();

                // Agrega los valores ordenados al ComboBox
                foreach (int hora in horasOrdenadas)
                {
                    cmb.Items.Add(hora.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ActualizarValorEnBaseDeDatos(int id, string Empleado, int nuevoValor)
        {
            try
            {
                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";
                cnn = new OleDbConnection(conexion);
                cnn.Open();

                // Prepara una consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE OctHoras SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(consulta, cnn);

                cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                cmd.Parameters.AddWithValue("@ID", id);

                // Ejecuta la consulta
                cmd.ExecuteNonQuery();

                // Cierra la conexión
                cnn.Close();

                MessageBox.Show("El valor se ha actualizado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        public void ActualizarHoras(Int32 id, String Empleado, String nuevoValor)
        {
            try
            {
                Int32 Acumulador = 0;
                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";
                cnn = new OleDbConnection(conexion);
                cnn.Open();

                // Prepara una consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE OctHoras SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(consulta, cnn);

                cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                cmd.Parameters.AddWithValue("@ID", id);

                // Ejecuta la consulta
                cmd.ExecuteNonQuery();

                //TOMAR EL VALORES DE LAS HORAS TOTALES
                cmdA = new OleDbCommand();
                cmdA.Connection = cnn;
                cmdA.CommandType = CommandType.Text;
                cmdA.CommandText = $"SELECT [{Empleado}] FROM OctHoras WHERE id <> 31";
                rdr = cmdA.ExecuteReader();

                while (rdr.Read())
                {
                    int numero = rdr.GetInt32(0); 
                    Acumulador += numero;
                }

                string consultaA = $"UPDATE OctHoras SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmdE = new OleDbCommand(consultaA, cnn);

                cmdE.Parameters.AddWithValue("@NuevoValor", Acumulador);
                cmdE.Parameters.AddWithValue("@ID", 31);

                cmdE.ExecuteNonQuery();



                // Cierra la conexión
                cnn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        //PROCEDIMIENTOS CUANTIFICADOR

        public void CargarGrillaCuantificador(DataGridView grilla)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            //AGREGA LAS COLUMNAS DE LOS EMPLEADOS
            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM empleados";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string empleado = rdr["nombre"].ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM OctCuantificador";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH[0], rdrH[1], rdrH[2], rdrH[3], rdrH[4], rdrH[5], rdrH[6], rdrH[7], rdrH[8], rdrH[9], rdrH[10]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            PintarValores(grilla);
        }

        public void CargarGrillaTotales(DataGridView grilla)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            // Agregar la columna "Fecha"
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "TOTAL MES";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            //AGREGA LAS COLUMNAS DE LOS EMPLEADOS
            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM empleados";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string empleado = rdr["nombre"].ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM OctCuantificador WHERE ID = 31";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH[0], rdrH[1], rdrH[2], rdrH[3], rdrH[4], rdrH[5], rdrH[6], rdrH[7], rdrH[8], rdrH[9], rdrH[10]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            PintarValores(grilla);
        }
        public void ActualizarCuantificador(Int32 id, string Empleado, Int32 Horas)
        {
            try
            {

                Int32 precioHora = 0;
                Int32 acumulado = 0;

                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";
                cnn = new OleDbConnection(conexion);
                cnn.Open();

                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = $"SELECT horaNormal FROM empleados WHERE nombre = @Empleado";

                // Asegúrate de definir y asignar el valor de @Empleado antes de ejecutar la consulta
                cmdH.Parameters.AddWithValue("@Empleado", Empleado);

                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    if (!rdrH.IsDBNull(0)) // Verifica si el valor no es nulo
                    {
                        precioHora = rdrH.GetInt32(0);
                    }
                }



                Int32 precioFinal = precioHora * Horas;
                

                // Prepara una consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE OctCuantificador SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(consulta, cnn);

                cmd.Parameters.AddWithValue("@NuevoValor", precioFinal);
                cmd.Parameters.AddWithValue("@ID", id);

                // Ejecuta la consulta
                cmd.ExecuteNonQuery();


                //CONSULTAS PARA ACUMULAR LOS TOTALES DE CADA EMPLEADO
                Int32 horasTotales = 0;
                cmdC = new OleDbCommand();
                cmdC.Connection = cnn;
                cmdC.CommandType = CommandType.Text;
                cmdC.CommandText = $"SELECT [{Empleado}] FROM OctHoras WHERE ID = 31";
                rdrC = cmdC.ExecuteReader();

                while(rdrC.Read())
                {
                    horasTotales = rdrC.GetInt32(0);
                }

                Int32 TotalPago = precioHora * horasTotales;

                string consultaE = $"UPDATE OctCuantificador SET [{Empleado}] = @NuevoValor WHERE ID = @ID";

                OleDbCommand cmdE = new OleDbCommand(consulta, cnn);

                cmdE.Parameters.AddWithValue("@NuevoValor", TotalPago);
                cmdE.Parameters.AddWithValue("@ID", 31);

                // Ejecuta la consulta
                cmdE.ExecuteNonQuery();








                // Cierra la conexión
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void PintarValores(DataGridView grilla)
        {
            foreach (DataGridViewRow row in grilla.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !cell.Value.ToString().Equals("0"))
                    {
                        cell.Style.BackColor = Color.Green;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        


    }
}
