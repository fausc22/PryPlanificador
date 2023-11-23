using System;
using System.Collections.Generic;
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

    class clsConexion
    {
        //MySqlConnection conn = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "planificadordatabase";
        static string user = "root";
        static string pw = "251199";
        static string port = "3306";


        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user=" + user + ";" + "password=" + pw + ";" + "database=" + bd + ";";


        //public MySqlConnection Conectar()
        //{
        //    conn.ConnectionString = cadenaConexion;
        //    conn.Open();
        //    return conn;
        //}

        public void NuevoEmpleado(string nombre, string apellido, string email, string fecha, decimal hora_normal, decimal hora_feriado, decimal hora_vacaciones, byte[] foto, byte[] huella)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    MySqlConnection conn = new MySqlConnection(cadenaConexion);
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Empleados (nombre, apellido, mail, fecha_ingreso, hora_normal, hora_feriado, hora_vacaciones, foto_perfil, huella_dactilar) " +
                                      "VALUES (@nombre, @apellido, @email, @fecha, @hora_normal, @hora_feriado, @hora_vacaciones, @foto, @huella)";

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
                    cmd.Parameters.AddWithValue("@hora_feriado", hora_feriado);
                    cmd.Parameters.AddWithValue("@hora_vacaciones", hora_vacaciones);
                    cmd.Parameters.AddWithValue("@foto", foto);
                    cmd.Parameters.AddWithValue("@huella", huella);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("EMPLEADO CREADO CON ÉXITO!", "EXITO", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al insertar nuevo empleado: " + ex.Message);
            }

        }

        public void CargarCmbEmpleado(ComboBox cmbEmpleado)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEmpleado.Items.Add(reader["nombre"].ToString());
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

        public void CargarEmpleado(string empleado, Label id, TextBox nombre, TextBox apellido, TextBox email, TextBox fecha, TextBox hora_normal, TextBox hora_feriado, TextBox hora_vacaciones, PictureBox foto, PictureBox huella, byte[] foto2, byte[] huella2)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleados WHERE nombre = @nombre", conn))
                    {
                        // Suponiendo que tienes un parámetro llamado "@nombre" en tu consulta SQL
                        cmd.Parameters.AddWithValue("@nombre", empleado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                // Asigna los valores de cada columna a los controles correspondientes
                                id.Text = reader["id"].ToString();
                                nombre.Text = reader["nombre"].ToString();
                                apellido.Text = reader["apellido"].ToString();
                                email.Text = reader["mail"].ToString();
                                fecha.Text = reader["fecha_ingreso"].ToString();
                                hora_normal.Text = reader["hora_normal"].ToString();
                                hora_feriado.Text = reader["hora_feriado"].ToString();
                                hora_vacaciones.Text = reader["hora_vacaciones"].ToString();

                                // La columna de la imagen puede ser de tipo BLOB en la base de datos
                                // Aquí asumimos que la columna se llama "foto" y es de tipo BLOB
                                if (reader["foto_perfil"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["foto_perfil"];
                                    MemoryStream ms = new MemoryStream(imageData);
                                    foto.Image = Image.FromStream(ms);
                                    foto2 = imageData;
                                }

                                // La columna de la huella también puede ser de tipo BLOB
                                // Aquí asumimos que la columna se llama "huella" y es de tipo BLOB
                                if (reader["huella_dactilar"] != DBNull.Value)
                                {
                                    byte[] huellaData = (byte[])reader["huella_dactilar"];
                                    MemoryStream msHuella = new MemoryStream(huellaData);
                                    // Asigna la imagen de la huella al PictureBox
                                    // (Asegúrate de que el PictureBox esté configurado para mostrar imágenes)
                                    huella.Image = Image.FromStream(msHuella);
                                    huella2 = huellaData;
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

        public void EditarEmpleado(int id, string nombre, string apellido, string email, string fecha, decimal hora_normal, decimal hora_feriado, decimal hora_vacaciones, byte[] foto, byte[] huella)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    MySqlConnection conn = new MySqlConnection(cadenaConexion);
                    cmd.Connection = conn;

                    // Cambia la consulta SQL a una actualización
                    cmd.CommandText = "UPDATE Empleados " +
                                      "SET nombre = @nombre, apellido = @apellido, mail = @email, " +
                                      "fecha_ingreso = @fecha, hora_normal = @hora_normal, " +
                                      "hora_feriado = @hora_feriado, hora_vacaciones = @hora_vacaciones, " +
                                      "foto_perfil = @foto, huella_dactilar = @huella " +
                                      "WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
                    cmd.Parameters.AddWithValue("@hora_feriado", hora_feriado);
                    cmd.Parameters.AddWithValue("@hora_vacaciones", hora_vacaciones);
                    cmd.Parameters.AddWithValue("@foto", foto);
                    cmd.Parameters.AddWithValue("@huella", huella);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("EMPLEADO ACTUALIZADO CON ÉXITO!", "ÉXITO", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al actualizar empleado: " + ex.Message);
            }
        }


    }
}
