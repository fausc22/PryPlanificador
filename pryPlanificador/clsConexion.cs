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

namespace pryPlanificador
{

    class clsConexion
    {
        //MySqlConnection conn = new MySqlConnection();

        static string servidor = "www.rsoftware.com.ar";
        static string bd = "planificadordatabase";
        static string user = "planificador";
        static string pw = "251199";
        static string port = "3306";

        //static string servidor = "localhost";
        //static string bd = "planificadordatabase";
        //static string user = "root";
        //static string pw = "251199";
        //static string port = "3306";



        string cadenaConexion = "server=" + servidor + ";" + "user=" + user + ";" + "password=" + pw + ";" + "database=" + bd + ";";


        //public MySqlConnection Conectar()
        //{
        //    conn.ConnectionString = cadenaConexion;
        //    conn.Open();
        //    return conn;
        //}

        //public void NuevoEmpleado(string nombre, string apellido, string email, string fecha, int antiguedad, int hora_normal, byte[] foto, byte[] huella, int diavacas)
        //{
        //    try
        //    {             

        //        int anioo = 23;

        //        using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
        //        {
        //            conn.Open();
        //            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO empleados (nombre, apellido, mail, fecha_ingreso, antiguedad, hora_normal, foto_perfil, huella_dactilar, dia_vacaciones) " +
        //                                  "VALUES (@nombre, @apellido, @email, @fecha, @antiguedad, @hora_normal, @foto, @huella, @diavacas)", conn))
        //            {



        //                cmd.Parameters.AddWithValue("@nombre", nombre);
        //                cmd.Parameters.AddWithValue("@apellido", apellido);
        //                cmd.Parameters.AddWithValue("@email", email);
        //                cmd.Parameters.AddWithValue("@fecha", fecha);
        //                cmd.Parameters.AddWithValue("@antiguedad", antiguedad);
        //                cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
        //                cmd.Parameters.AddWithValue("@foto", foto);
        //                cmd.Parameters.AddWithValue("@huella", huella);
        //                cmd.Parameters.AddWithValue("@diavacas", diavacas);
        //                cmd.ExecuteNonQuery();

        //            }

        //            while (anioo <= 24)
        //            {
        //                int mess = 1; // Mover la inicialización al interior del bucle anidado
        //                while (mess <= 12)
        //                {
        //                    string tablaTotales = $"totales_20{anioo}";
        //                    int horasTotales = 0;
        //                    decimal totalTotales = 0;
        //                    using (MySqlCommand cmdTotales = new MySqlCommand($"INSERT INTO `{tablaTotales}` (mes, nombre_empleado, horas, acumulado) " +
        //                                                                      "VALUES (@fecha, @nombre, @horas, @acumulado)", conn))
        //                    {
        //                        cmdTotales.Parameters.AddWithValue("@nombre", nombre);
        //                        cmdTotales.Parameters.AddWithValue("@fecha", mess);
        //                        cmdTotales.Parameters.AddWithValue("@horas", horasTotales);
        //                        cmdTotales.Parameters.AddWithValue("@acumulado", totalTotales);

        //                        cmdTotales.ExecuteNonQuery();
        //                    }

        //                    int diaa = 1; // Mover la inicialización al interior del bucle más interno
        //                    while (diaa <= 31)
        //                    {
        //                        string tablaTurnos = $"turnos_20{anioo}";
        //                        string fecharda = $"{diaa}/{mess}/20{anioo}";
        //                        string estado = "libre";
        //                        int horasTurnos = 0;
        //                        decimal totalTurnos = 0;
        //                        using (MySqlCommand cmdTurnos = new MySqlCommand($"INSERT INTO `{tablaTurnos}` (fecha, nombre_empleado, valor, horas, acumulado) " +
        //                                                                          "VALUES (@fecha, @nombre, @estado, @horas, @acumulado)", conn))
        //                        {
        //                            cmdTurnos.Parameters.AddWithValue("@nombre", nombre);
        //                            cmdTurnos.Parameters.AddWithValue("@fecha", fecharda);
        //                            cmdTurnos.Parameters.AddWithValue("@estado", estado);
        //                            cmdTurnos.Parameters.AddWithValue("@horas", horasTurnos);
        //                            cmdTurnos.Parameters.AddWithValue("@acumulado", totalTurnos);

        //                            cmdTurnos.ExecuteNonQuery();
        //                        }
        //                        diaa = diaa + 1;
        //                    }
        //                    mess = mess + 1;
        //                }
        //                anioo = anioo + 1;
        //            }
        //        }
        //        //for (int anio = 23; anio < 25; anio++)
        //        //{
        //        //    for (int mes = 1; mes < 13; mes++)
        //        //    {
        //        //    using (MySqlCommand cmd = new MySqlCommand())
        //        //    {
        //        //        MySqlConnection conn = new MySqlConnection(cadenaConexion);
        //        //        cmd.Connection = conn;
        //        //        string tabla = "totales_20" + anio;
        //        //        string tablaEscapada = $"`{tabla}`";
        //        //        int horas = 0;
        //        //        decimal total = 0;
        //        //        cmd.CommandText = $"INSERT INTO {tablaEscapada}  (id, mes, nombre_empleado, horas, acumulado) " +
        //        //                                  "VALUES (NULL, @fecha, @nombre, @horas, @acumulado)";

        //        //        cmd.Parameters.AddWithValue("@nombre", nombre);
        //        //        cmd.Parameters.AddWithValue("@fecha", mes);                       
        //        //        cmd.Parameters.AddWithValue("@horas", horas);
        //        //        cmd.Parameters.AddWithValue("@acumulado", total);

        //        //        conn.Open();
        //        //        cmd.ExecuteNonQuery();
        //        //    }
        //        //    for (int dia = 1; dia < 32; dia++)
        //        //        {
        //        //            using (MySqlCommand cmd = new MySqlCommand())
        //        //            {
        //        //                MySqlConnection conn = new MySqlConnection(cadenaConexion);
        //        //                cmd.Connection = conn;
        //        //                string tabla = "turnos_20" + anio;
        //        //                string tablaEscapada = $"`{tabla}`";
        //        //                string fecharda = dia + "/" + mes + "/20" + anio;
        //        //                string estado = "libre";
        //        //                int horas = 0;
        //        //                decimal total = 0;

        //        //                cmd.CommandText = $"INSERT INTO {tablaEscapada}  (turno_id, fecha, nombre_empleado, valor, horas, acumulado) " +
        //        //                                  "VALUES (NULL, @fecha, @nombre, @estado, @horas, @acumulado)";


        //        //                cmd.Parameters.AddWithValue("@nombre", nombre);
        //        //                cmd.Parameters.AddWithValue("@fecha", fecharda);
        //        //                cmd.Parameters.AddWithValue("@estado", estado);
        //        //                cmd.Parameters.AddWithValue("@horas", horas);
        //        //                cmd.Parameters.AddWithValue("@acumulado", total);


        //        //                conn.Open();
        //        //                cmd.ExecuteNonQuery();

        //        //            }
        //        //        }
        //        //    }
        //        //}
        //        MessageBox.Show("EMPLEADO CREADO CON ÉXITO!", "EXITO", MessageBoxButtons.OK);

        //    }
        //    catch (Exception ex)
        //    {
        //        // Maneja la excepción según tus necesidades
        //        MessageBox.Show("Error al insertar nuevo empleado: " + ex.Message);
        //    }


        //}


        public void NuevoEmpleado(string nombre, string apellido, string email, string fecha, int antiguedad, int hora_normal, byte[] foto, byte[] huella, int diavacas)
        {


            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    int anioo = 23;
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO empleados (nombre, apellido, mail, fecha_ingreso, antiguedad, hora_normal, foto_perfil, huella_dactilar, dia_vacaciones) " +
                                                      "VALUES (@nombre, @apellido, @email, @fecha, @antiguedad, @hora_normal, @foto, @huella, @diavacas)", conn))
                    {



                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@antiguedad", antiguedad);
                        cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
                        cmd.Parameters.AddWithValue("@foto", foto);
                        cmd.Parameters.AddWithValue("@huella", huella);
                        cmd.Parameters.AddWithValue("@diavacas", diavacas);
                        cmd.ExecuteNonQuery();

                    }

                    while (anioo <= 24)
                    {
                        int mess = 1; // Mover la inicialización al interior del bucle anidado
                        while (mess <= 12)
                        {
                            string tablaTotales = $"totales_20{anioo}";
                            int horasTotales = 0;
                            decimal totalTotales = 0;
                            using (MySqlCommand cmdTotales = new MySqlCommand($"INSERT INTO `{tablaTotales}` (mes, nombre_empleado, horas, acumulado) " +
                                                                              "VALUES (@fecha, @nombre, @horas, @acumulado)", conn))
                            {
                                cmdTotales.Parameters.AddWithValue("@nombre", nombre);
                                cmdTotales.Parameters.AddWithValue("@fecha", mess);
                                cmdTotales.Parameters.AddWithValue("@horas", horasTotales);
                                cmdTotales.Parameters.AddWithValue("@acumulado", totalTotales);

                                cmdTotales.ExecuteNonQuery();
                            }

                            int diaa = 1; // Mover la inicialización al interior del bucle más interno
                            while (diaa <= 31)
                            {
                                string tablaTurnos = $"turnos_20{anioo}";
                                string fecharda = $"{diaa}/{mess}/20{anioo}";
                                string estado = "libre";
                                int horasTurnos = 0;
                                decimal totalTurnos = 0;
                                using (MySqlCommand cmdTurnos = new MySqlCommand($"INSERT INTO `{tablaTurnos}` (fecha, nombre_empleado, valor, horas, acumulado) " +
                                                                                  "VALUES (@fecha, @nombre, @estado, @horas, @acumulado)", conn))
                                {
                                    cmdTurnos.Parameters.AddWithValue("@nombre", nombre);
                                    cmdTurnos.Parameters.AddWithValue("@fecha", fecharda);
                                    cmdTurnos.Parameters.AddWithValue("@estado", estado);
                                    cmdTurnos.Parameters.AddWithValue("@horas", horasTurnos);
                                    cmdTurnos.Parameters.AddWithValue("@acumulado", totalTurnos);

                                    cmdTurnos.ExecuteNonQuery();
                                }
                                diaa = diaa + 1;
                            }
                            mess = mess + 1;
                        }
                        anioo = anioo + 1;
                    }





                    MessageBox.Show("EMPLEADO CREADO CON ÉXITO!", "EXITO", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al insertar nuevo empleado: " + ex.Message);
            }



        }


        public void CargarCmbEmpleado(ComboBox cmbEmpleado)
        {
            cmbEmpleado.Items.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleados", conn))
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

        public void CargarEmpleado(string empleado, Label id, TextBox nombre, TextBox apellido, TextBox email, TextBox fecha, TextBox antiguedad, TextBox hora_normal, TextBox diavacas, PictureBox foto, PictureBox huella, byte[] foto2, byte[] huella2)
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
                                antiguedad.Text = reader["antiguedad"].ToString();
                                hora_normal.Text = reader["hora_normal"].ToString();
                                diavacas.Text = reader["dia_vacaciones"].ToString();

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

        public void EditarEmpleado(int id, string nombre, string apellido, string email, string fecha, int antiguedad, int hora_normal, int diavacas, byte[] foto, byte[] huella)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados " +
                                      "SET nombre = @nombre, apellido = @apellido, mail = @email, " +
                                      "fecha_ingreso = @fecha, antiguedad = @antiguedad, hora_normal = @hora_normal, " +
                                      "foto_perfil = @foto, huella_dactilar = @huella, dia_vacaciones = @diavacas " +  // Added space before WHERE
                                      "WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@antiguedad", antiguedad);
                        cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
                        cmd.Parameters.AddWithValue("@foto", foto);
                        cmd.Parameters.AddWithValue("@huella", huella);
                        cmd.Parameters.AddWithValue("@diavacas", diavacas);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ACTUALIZADO CON ÉXITO!", "ÉXITO", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                MessageBox.Show("Error al actualizar empleado: " + ex.Message);
            }
        }

        public void EliminarEmpleado(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM empleados WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ActualizarHorarios(int id, string turnos, string horaInicio, string horaFin, int horas)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    MySqlConnection conn = new MySqlConnection(cadenaConexion);
                    cmd.Connection = conn;
                    // Prepara una consulta SQL para actualizar el valor en la base de datos
                    string consulta = $"UPDATE horarios SET turnos = @turnos, horaInicio = @horaInicio, horaFin = @horaFin, horas = @horas WHERE id = @ID";
                    cmd.CommandText = consulta;
                    cmd.Parameters.AddWithValue("@turnos", turnos);
                    cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@horaFin", horaFin);
                    cmd.Parameters.AddWithValue("@horas", horas);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El valor se ha actualizado con éxito");
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void NuevoHorarios(string turnos, string horaInicio, string horaFin, int horas)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO horarios (turnos, horaInicio, horaFin, horas) VALUES (@turnos, @horaInicio, @horaFin, @horas)", conn)) 
                    {
                        cmd.Parameters.AddWithValue("@turnos", turnos);
                        cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@horaFin", horaFin);
                        cmd.Parameters.AddWithValue("@horas", horas);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("HORARIO CREADO CON ÉXITO.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int HoraEmpleado(string empleado)
        {
            int valorHora = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados WHERE nombre = @nombre", conn))
                    {
                        // Suponiendo que tienes un parámetro llamado "@nombre" en tu consulta SQL
                        cmd.Parameters.AddWithValue("@nombre", empleado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                valorHora = Convert.ToInt32(reader["hora_normal"]);
                            }
                        }
                    }
                    return valorHora;
                }
            } catch (Exception ex)
            {
                return valorHora;
            }
        }







        public void CargarGrillaFeriado(DataGridView grilla, string anio)
        {
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.ReadOnly = true;
            fechaColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            grilla.Columns.Add(fechaColumn);

            DataGridViewTextBoxColumn fechColumn = new DataGridViewTextBoxColumn();
            fechColumn.HeaderText = "Festejo";
            fechColumn.ReadOnly = true;
            fechColumn.Width = 200;
            grilla.Columns.Add(fechColumn);

            DataGridViewTextBoxColumn fecColumn = new DataGridViewTextBoxColumn();
            fecColumn.HeaderText = "Día";
            fecColumn.ReadOnly = true;
            fecColumn.DefaultCellStyle.BackColor = Color.DarkGray;
            grilla.Columns.Add(fecColumn);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM feriados WHERE periodo = @anio", conn))
                    {
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["fecha"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["festejo"];
                                grilla.Rows[rowIndex].Cells[3].Value = reader["dia"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar feriados: " + ex.Message);
            }
        }

        public void NuevoFeriado(string fecha, string festejo, string dia, string periodo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO feriados (fecha, festejo, dia, periodo) VALUES (@fecha, @festejo, @dia, @periodo)", conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@festejo", festejo);
                        cmd.Parameters.AddWithValue("@dia", dia);
                        cmd.Parameters.AddWithValue("@periodo", periodo);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("FERIADO CREADO CON EXITO!");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void EditarFeriado(int id, string fecha, string festejo, string dia, string periodo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE feriados SET fecha = @fecha, festejo = @festejo, dia = @dia, periodo = @periodo WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@festejo", festejo);
                        cmd.Parameters.AddWithValue("@dia", dia);
                        cmd.Parameters.AddWithValue("@periodo", periodo);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("FERIADO MODIFICADO CON EXITO!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void EliminarFeriado(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();


                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM feriados WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("FERIADO ELIMINADO CON ÉXITO!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void CargarGrillaLogueo(DataGridView grilla, string anio, string mes)
        {
            grilla.Rows.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string tabla = "logueo_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE mes = @mes", conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["fecha"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["nombre_empleado"];
                                grilla.Rows[rowIndex].Cells[3].Value = reader["accion"];
                                grilla.Rows[rowIndex].Cells[4].Value = reader["hora"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar feriados: " + ex.Message);
            }
        }


        public void CargarGrillaLogueoFiltrada(DataGridView grilla, string anio, string mes, string nombre)
        {
            grilla.Rows.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string tabla = "logueo_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE mes = @mes AND nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["fecha"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["nombre_empleado"];
                                grilla.Rows[rowIndex].Cells[3].Value = reader["accion"];
                                grilla.Rows[rowIndex].Cells[4].Value = reader["hora"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar feriados: " + ex.Message);
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



        public void CargarGrillaControlHs(DataGridView grilla, string anio, string mes, string nombre)
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




            DataGridViewTextBoxColumn fechColumn = new DataGridViewTextBoxColumn();
            fechColumn.HeaderText = "Entrada";
            fechColumn.ReadOnly = true;
            grilla.Columns.Add(fechColumn);

            DataGridViewTextBoxColumn fecColumn = new DataGridViewTextBoxColumn();
            fecColumn.HeaderText = "Salida";
            fecColumn.ReadOnly = true;
            grilla.Columns.Add(fecColumn);

            DataGridViewTextBoxColumn feColumn = new DataGridViewTextBoxColumn();
            feColumn.HeaderText = "HS trabajadas";
            feColumn.ReadOnly = true;
            grilla.Columns.Add(feColumn);

            DataGridViewTextBoxColumn fColumn = new DataGridViewTextBoxColumn();
            fColumn.HeaderText = "Acumulado ($)";
            fColumn.ReadOnly = true;
            grilla.Columns.Add(fColumn);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();





                    string tabla = "controlhs_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE nombre_empleado = @nombre AND mes = @mes ORDER BY fecha", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["fecha"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["hora_ingreso"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["hora_egreso"];
                                grilla.Rows[rowIndex].Cells[3].Value = reader["horas_trabajadas"];
                                grilla.Rows[rowIndex].Cells[4].Value = reader["acumulado"];

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


        public void NuevoPagoExtra(string nombre, string anio, string mes, string categoria, int monto, string descripcion)
        {
            string tablaAnual = "extras_" + anio;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tablaAnual} (nombre_empleado, mes, categoria, monto, descripcion) VALUES (@nombre, @mes, @categoria, @monto, @descripcion)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("PAGO EXTRA REGISTRADO CON EXITO!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        static int CalcularAntiguedad(DateTime fechaIngreso)
        {
            // Obtiene la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Calcula la diferencia en años
            int antiguedad = fechaActual.Year - fechaIngreso.Year;

            // Ajusta la antigüedad si el aniversario de ingreso aún no ha ocurrido este año
            if (fechaIngreso.Date > fechaActual.AddYears(-antiguedad))
            {
                antiguedad--;
            }

            return antiguedad;
        }


        public void CargarGrillaEmpleado(DataGridView grilla)
        {
            int antiguedad = 0;
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Empleado";
            fechaColumn.ReadOnly = true;
            grilla.Columns.Add(fechaColumn);

            DataGridViewTextBoxColumn fechColumn = new DataGridViewTextBoxColumn();
            fechColumn.HeaderText = "Fecha Ingreso";
            fechColumn.ReadOnly = true;
            grilla.Columns.Add(fechColumn);

            DataGridViewTextBoxColumn fecColumn = new DataGridViewTextBoxColumn();
            fecColumn.HeaderText = "Años de Antiguedad";
            fecColumn.ReadOnly = true;
            grilla.Columns.Add(fecColumn);


            DataGridViewTextBoxColumn feColumn = new DataGridViewTextBoxColumn();
            feColumn.HeaderText = "Días de Vacaciones";
            feColumn.ReadOnly = true;
            grilla.Columns.Add(feColumn);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleados", conn))
                    {


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                string fechaIngreso = reader["fecha_ingreso"].ToString();
                                // Llamada a la función para obtener la antigüedad en años
                                if (DateTime.TryParseExact(fechaIngreso, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
                                {
                                    antiguedad = CalcularAntiguedad(fecha);
                                }

                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["nombre"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["fecha_ingreso"];
                                grilla.Rows[rowIndex].Cells[3].Value = antiguedad;
                                grilla.Rows[rowIndex].Cells[4].Value = reader["dia_vacaciones"];
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

        public void CargarGrillaVacaciones(DataGridView grilla)
        {
            int antiguedad = 0;
            // Limpiar la grilla
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID"; // Asigna un nombre a la columna (puedes usar el mismo nombre que tienes en tu base de datos)
            idColumn.Visible = false; // Hacer que la columna no sea visible
            grilla.Columns.Add(idColumn);

            DataGridViewTextBoxColumn fColumn = new DataGridViewTextBoxColumn();
            fColumn.HeaderText = "Empleado";
            fColumn.ReadOnly = true;
            grilla.Columns.Add(fColumn);

            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Días";
            fechaColumn.ReadOnly = true;
            grilla.Columns.Add(fechaColumn);

            DataGridViewTextBoxColumn fechColumn = new DataGridViewTextBoxColumn();
            fechColumn.HeaderText = "Salida";
            fechColumn.ReadOnly = true;
            grilla.Columns.Add(fechColumn);

            DataGridViewTextBoxColumn fecColumn = new DataGridViewTextBoxColumn();
            fecColumn.HeaderText = "Regreso";
            fecColumn.ReadOnly = true;
            grilla.Columns.Add(fecColumn);



            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();


                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM vacaciones", conn))
                    {


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {


                            while (reader.Read())
                            {

                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                grilla.Rows[rowIndex].Cells[1].Value = reader["nombre_empleado"];
                                grilla.Rows[rowIndex].Cells[2].Value = reader["dias"];
                                grilla.Rows[rowIndex].Cells[3].Value = reader["salida"];
                                grilla.Rows[rowIndex].Cells[4].Value = reader["regreso"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar vacaciones: " + ex.Message);
            }
        }

        public void NuevoVacaciones(string nombre, int dias, string salida, string regreso, int DiasTotales)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO vacaciones (nombre_empleado, dias, salida, regreso) VALUES (@nombre, @dias, @salida, @regreso)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dias", dias);
                        cmd.Parameters.AddWithValue("@salida", salida);
                        cmd.Parameters.AddWithValue("@regreso", regreso);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("VACACIONES CREADAS CON EXITO!");
                    }

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados SET dia_vacaciones = @dia WHERE nombre = @nombre", conn))
                    {
                        int DiasAgregar = DiasTotales - dias;
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dia", DiasAgregar);


                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ActualizarVacaciones(int id, string nombre, int dias, string salida, string regreso, int DiasTotales)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE vacaciones SET nombre_empleado = @nombre, dias = @dias, salida = @salida, regreso = @regreso WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dias", dias);
                        cmd.Parameters.AddWithValue("@salida", salida);
                        cmd.Parameters.AddWithValue("@regreso", regreso);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("VACACIONES EDITADAS CON EXITO!");
                    }

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados SET dia_vacaciones = @dia WHERE nombre = @nombre", conn))
                    {
                        int DiasAgregar = DiasTotales - dias;
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dia", DiasAgregar);


                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CargarCmbEmpleadoVacaciones(ComboBox cmb)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleados", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dtHora = new DataTable();

                            if (reader.HasRows)
                            {
                                dtHora.Load(reader);
                                cmb.DataSource = dtHora;
                                cmb.ValueMember = "dia_vacaciones";
                                cmb.DisplayMember = "nombre"; // Corregido: Usar "turno" en lugar de "turnos"
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


        public void CargarDatosRecibo(string nombre, string anio, string mes, TextBox txtHorasPlanificadas, Label lblHorasPlanificadas, TextBox txtHorasTrabajadas, Label lblHorasTrabajadas, TextBox txtPremios, TextBox txtAdelantos)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string tablaPlanificar = "totales_" + anio;
                    string tablaTotal = "controlhs_" + anio;
                    string tablaExtras = "extras_" + anio;
                    int totalAdelantos = 0;
                    int totalPremios = 0;
                    int totalAcumulado = 0;
                    int totalHorasTrabajadas = 0;
                    int subTotal = 0;

                    int NroMes = ObtenerNumeroMes(mes);


                    //PLANIFICADO
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tablaPlanificar} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", NroMes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtHorasPlanificadas.Text = reader["acumulado"].ToString();
                                lblHorasPlanificadas.Text = "(" + reader["horas"] + ")";
                            }
                        }


                    }


                    //CONTROL HS
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tablaTotal} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalAcumulado = totalAcumulado + Convert.ToInt32(reader["acumulado"]);
                                totalHorasTrabajadas = totalHorasTrabajadas + Convert.ToInt32(reader["horas_trabajadas"]);
                            }
                        }
                        txtHorasTrabajadas.Text = totalAcumulado.ToString();
                        lblHorasTrabajadas.Text = "(" + totalHorasTrabajadas.ToString() + ")";

                    }


                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tablaExtras} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string categoria = reader["categoria"].ToString().Trim();
                                if (categoria == "ADELANTO DE SUELDO")
                                {
                                    totalAdelantos += Convert.ToInt32(reader["monto"]);
                                }
                                else if (categoria == "PREMIO")
                                {
                                    totalPremios += Convert.ToInt32(reader["monto"]);
                                }
                            }
                        }
                        txtPremios.Text = totalPremios.ToString();
                        txtAdelantos.Text = totalAdelantos.ToString();

                    }


                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void CargarEmpleadoRecibo(string empleado, Label id, TextBox nombre, TextBox apellido, TextBox email, TextBox fecha, TextBox antiguedad, TextBox hora_normal, TextBox diavacas, PictureBox foto)
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
                                antiguedad.Text = reader["antiguedad"].ToString();
                                hora_normal.Text = reader["hora_normal"].ToString();
                                diavacas.Text = reader["dia_vacaciones"].ToString();


                                // La columna de la imagen puede ser de tipo BLOB en la base de datos
                                // Aquí asumimos que la columna se llama "foto" y es de tipo BLOB
                                if (reader["foto_perfil"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["foto_perfil"];
                                    MemoryStream ms = new MemoryStream(imageData);
                                    foto.Image = Image.FromStream(ms);

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


        public string DescripcionPremios(string empleado, string anio, string mes)
        {
            StringBuilder descripcionBuilder = new StringBuilder();
            string tabla = "extras_" + anio;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion)) // Reemplaza "cadenaDeConexion" con tu cadena de conexión real
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", empleado);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string monto = reader["monto"].ToString();
                                string descripcionBD = reader["descripcion"].ToString();

                                // Concatenar cada descripción con un salto de línea
                                descripcionBuilder.AppendLine($"MONTO: $ {monto} - DESCRIPCION: {descripcionBD}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Devolver el resultado final como una cadena
            return descripcionBuilder.ToString();
        }

        public void  EliminarVacaciones(int id) 
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM vacaciones WHERE id = @id", conn)) 
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("VACACIONES ELIMINADAS CON EXITO.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
