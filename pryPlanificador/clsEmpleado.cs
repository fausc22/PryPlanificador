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
using System.Reflection;

namespace pryPlanificador
{
    public class  clsEmpleado
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


        public void CargarGrillaLogueo(DataGridView grilla)
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


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM Logueo";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH["IdRegistro"], rdrH["Fecha"], rdrH["Nombre"], rdrH["Entrada"], rdrH["Salida"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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


                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";


                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmdH = new OleDbCommand();
                cmdH.Connection = cnn;
                cmdH.CommandType = CommandType.Text;
                cmdH.CommandText = "SELECT * FROM horarios";
                rdrH = cmdH.ExecuteReader();

                while (rdrH.Read())
                {
                    grilla.Rows.Add(rdrH["Id"], rdrH["turnos"], rdrH["horaInicio"], rdrH["horaFin"], rdrH["horas"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }


        public void ActualizarTurnos(int id, string turnos, string horaInicio, string horaFin, int horas)
        {
            try
            {
                string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlanificadorDB.accdb";
                cnn = new OleDbConnection(conexion);
                cnn.Open();

                // Prepara una consulta SQL para actualizar el valor en la base de datos
                string consulta = $"UPDATE horarios SET turnos = @turnos, horaInicio = @horaInicio, horaFin = @horaFin, horas = @horas WHERE ID = @ID";

                OleDbCommand cmd = new OleDbCommand(consulta, cnn);

                cmd.Parameters.AddWithValue("@turnos", turnos);
                cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", horaFin);
                cmd.Parameters.AddWithValue("@horas", horas);
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
    }
}
