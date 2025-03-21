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
using Org.BouncyCastle.Math;
using com.itextpdf.text.pdf;
using static iTextSharp.tool.xml.html.HTML;
using System.Threading;


namespace pryPlanificador
{

    class clsConexion
    {
        //MySqlConnection conn = new MySqlConnection();

        //static string servidor = "www.rsoftware.com.ar";
        //static string bd = "planificadordatabase";
        //static string user = "planificador";
        //static string pw = "251199";
        //static string port = "3306";

        static string servidor2 = "localhost";
        static string bd2 = "planificador";
        static string user2 = "root";
        static string pw2 = "251199";
        static string port2 = "3306";


        //static string servidor = "localhost";
        //static string bd = "planisv";
        //static string user = "root";
        //static string pw = "251199";
        //static string port = "3306";




        //KIOSCO
        static string servidor = "26.83.72.84";
        static string bd = "planificador";
        static string user = "planificador";
        static string pw = "251199";
        static string port = "3306";



        string cadenaConexion = "server=" + servidor + ";port=" + port + ";user=" + user + ";password=" + pw + ";database=" + bd + ";";
        string cadenaConexion2 = "server=" + servidor2 + ";port=" + port2 + ";user=" + user2 + ";password=" + pw2 + ";database=" + bd2 + ";";


        //public MySqlConnection Conectar()
        //{
        //    conn.ConnectionString = cadenaConexion;
        //    conn.Open();
        //    return conn;
        //}





        public void NuevoEmpleado(string nombre, string apellido, string email, string fecha, int antiguedad, int hora_normal, byte[] foto, byte[] huella, int diavacas, int horas)
        {


            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO empleados (nombre, apellido, mail, fecha_ingreso, antiguedad, hora_normal, foto_perfil, huella_dactilar, dia_vacaciones, horas_vacaciones) " +
                                                      "VALUES (@nombre, @apellido, @email, @fecha, @antiguedad, @hora_normal, @foto, @huella, @diavacas, @horas)", conn))
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
                        cmd.Parameters.AddWithValue("@horas", horas);
                        cmd.ExecuteNonQuery();

                    }




                    conn.Close();
                }

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO empleados (nombre, apellido, mail, fecha_ingreso, antiguedad, hora_normal, foto_perfil, huella_dactilar, dia_vacaciones, horas_vacaciones) " +
                                                      "VALUES (@nombre, @apellido, @email, @fecha, @antiguedad, @hora_normal, @foto, @huella, @diavacas, @horas)", conn))
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
                        cmd.Parameters.AddWithValue("@horas", horas);
                        cmd.ExecuteNonQuery();

                    }

                    int anioo = 24;
                    while (anioo <= 26)
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
                                string fecharda = string.Empty;
                                if (diaa < 10)
                                {
                                    if (mess < 10)
                                    {
                                        fecharda = $"0{diaa}/0{mess}/20{anioo}";
                                    }
                                    else
                                    {
                                        fecharda = $"0{diaa}/{mess}/20{anioo}";
                                    }

                                }
                                else
                                {
                                    if (mess < 10)
                                    {
                                        fecharda = $"{diaa}/0{mess}/20{anioo}";
                                    }
                                    else
                                    {
                                        fecharda = $"{diaa}/{mess}/20{anioo}";
                                    }
                                }

                                string estado = "Libre";
                                int horasTurnos = 0;
                                int totalTurnos = 0;
                                using (MySqlCommand cmdTurnos = new MySqlCommand($"INSERT INTO `{tablaTurnos}` (fecha, nombre_empleado, turno, horas, acumulado) " +
                                                                                  "VALUES (@fecha, @nombre, @estado1, @horas, @acumulado)", conn))
                                {
                                    cmdTurnos.Parameters.AddWithValue("@nombre", nombre);
                                    cmdTurnos.Parameters.AddWithValue("@fecha", fecharda);
                                    cmdTurnos.Parameters.AddWithValue("@estado1", estado);

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
                }

                //using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                //{
                //    conn.Open();
                //    int anioo = 23;
                //    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO empleados (nombre, apellido, mail, fecha_ingreso, antiguedad, hora_normal, foto_perfil, huella_dactilar, dia_vacaciones, horas_vacaciones) " +
                //                                      "VALUES (@nombre, @apellido, @email, @fecha, @antiguedad, @hora_normal, @foto, @huella, @diavacas, @horas)", conn))
                //    {



                //        cmd.Parameters.AddWithValue("@nombre", nombre);
                //        cmd.Parameters.AddWithValue("@apellido", apellido);
                //        cmd.Parameters.AddWithValue("@email", email);
                //        cmd.Parameters.AddWithValue("@fecha", fecha);
                //        cmd.Parameters.AddWithValue("@antiguedad", antiguedad);
                //        cmd.Parameters.AddWithValue("@hora_normal", hora_normal);
                //        cmd.Parameters.AddWithValue("@foto", foto);
                //        cmd.Parameters.AddWithValue("@huella", huella);
                //        cmd.Parameters.AddWithValue("@diavacas", diavacas);
                //        cmd.Parameters.AddWithValue("@horas", horas);
                //        cmd.ExecuteNonQuery();

                //    }

                //    while (anioo <= 24)
                //    {
                //        int mess = 1; // Mover la inicialización al interior del bucle anidado
                //        while (mess <= 12)
                //        {
                //            string tablaTotales = $"totales_20{anioo}";
                //            int horasTotales = 0;
                //            decimal totalTotales = 0;
                //            using (MySqlCommand cmdTotales = new MySqlCommand($"INSERT INTO `{tablaTotales}` (mes, nombre_empleado, horas, acumulado) " +
                //                                                              "VALUES (@fecha, @nombre, @horas, @acumulado)", conn))
                //            {
                //                cmdTotales.Parameters.AddWithValue("@nombre", nombre);
                //                cmdTotales.Parameters.AddWithValue("@fecha", mess);
                //                cmdTotales.Parameters.AddWithValue("@horas", horasTotales);
                //                cmdTotales.Parameters.AddWithValue("@acumulado", totalTotales);

                //                cmdTotales.ExecuteNonQuery();
                //            }

                //            int diaa = 1; // Mover la inicialización al interior del bucle más interno
                //            while (diaa <= 31)
                //            {
                //                string tablaTurnos = $"turnos_20{anioo}";
                //                string fecharda = string.Empty;
                //                if (diaa < 10)
                //                {
                //                    if (mess < 10)
                //                    {
                //                        fecharda = $"0{diaa}/0{mess}/20{anioo}";
                //                    }
                //                    else
                //                    {
                //                        fecharda = $"0{diaa}/{mess}/20{anioo}";
                //                    }

                //                }
                //                else
                //                {
                //                    if (mess < 10)
                //                    {
                //                        fecharda = $"{diaa}/0{mess}/20{anioo}";
                //                    }
                //                    else
                //                    {
                //                        fecharda = $"{diaa}/{mess}/20{anioo}";
                //                    }
                //                }

                //                string estado = "libre";
                //                int horasTurnos = 0;
                //                int totalTurnos = 0;
                //                using (MySqlCommand cmdTurnos = new MySqlCommand($"INSERT INTO `{tablaTurnos}` (fecha, nombre_empleado, turno, horas, acumulado) " +
                //                                                                  "VALUES (@fecha, @nombre, @estado1, @horas, @acumulado)", conn))
                //                {
                //                    cmdTurnos.Parameters.AddWithValue("@nombre", nombre);
                //                    cmdTurnos.Parameters.AddWithValue("@fecha", fecharda);
                //                    cmdTurnos.Parameters.AddWithValue("@estado1", estado);

                //                    cmdTurnos.Parameters.AddWithValue("@horas", horasTurnos);
                //                    cmdTurnos.Parameters.AddWithValue("@acumulado", totalTurnos);

                //                    cmdTurnos.ExecuteNonQuery();
                //                }
                //                diaa = diaa + 1;
                //            }
                //            mess = mess + 1;
                //        }
                //        anioo = anioo + 1;
                //    }





                //    MessageBox.Show("EMPLEADO CREADO CON ÉXITO!", "EXITO", MessageBoxButtons.OK);

                //    conn.Close();
                //}
                MessageBox.Show("EMPLEADO CREADO CON EXITO");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al insertar nuevo empleado: " + ex.Message);

            }



        }










        public void CargarCmbEmpleado(ComboBox cmbEmpleado)
        {
            cmbEmpleado.Items.Clear();
            List<string> empleados = new List<string>();
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
                                string empleado = reader["nombre"].ToString();
                                empleados.Add(empleado);
                            }
                        }
                    }




                }
                empleados.Sort();
                foreach (string empleado in empleados)
                {
                    if (!cmbEmpleado.Items.Contains(empleado))
                    {
                        cmbEmpleado.Items.Add(empleado);
                    }
                }

            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        public void CargarEmpleado(string empleado, Label id, TextBox nombre, TextBox apellido, TextBox email, TextBox fecha, TextBox antiguedad, TextBox hora_normal, TextBox diavacas, TextBox jornada, PictureBox foto, PictureBox huella)
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
                            if (reader.Read())
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
                                jornada.Text = reader["horas_vacaciones"].ToString();





                                // La columna de la imagen puede ser de tipo BLOB en la base de datos
                                // Aquí asumimos que la columna se llama "foto" y es de tipo BLOB
                                if (reader["foto_perfil"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["foto_perfil"];
                                    MemoryStream ms = new MemoryStream(imageData);
                                    foto.Image = Image.FromStream(ms);

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

        public void EditarEmpleado(int id, string nombre, string apellido, string email, string fecha, int antiguedad, int hora_normal, int diavacas, int horasVacas, byte[] foto, byte[] huella)
        {
            try
            {
                string consultaOriginal = "UPDATE empleados " +
                                      "SET apellido = @apellido, mail = @email, " +
                                      "fecha_ingreso = @fecha, antiguedad = @antiguedad, hora_normal = @hora_normal, " +
                                      "foto_perfil = @foto, huella_dactilar = @huella, dia_vacaciones = @diavacas, horas_vacaciones = @horas " +  // Added space before WHERE
                                      "WHERE nombre = @nombre";
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consultaOriginal, conn))
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
                        cmd.Parameters.AddWithValue("@horas", horasVacas);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ACTUALIZADO CON ÉXITO!", "ÉXITO", MessageBoxButtons.OK);
                    }

                }

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consultaOriginal, conn))
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
                        cmd.Parameters.AddWithValue("@horas", horasVacas);
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                MessageBox.Show("Error al actualizar empleado: " + ex.Message);
            }
        }

        public void EliminarEmpleado(int id, string nombre)
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

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2023 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2024 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2023 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2024 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2025 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2025 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");

                    }
                }

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2023 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2024 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2023 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2024 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM turnos_2025 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM totales_2025 WHERE nombre_empleado = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMPLEADO ELIMINADO CON ÉXITO.");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ActualizarHorarios(int id, string turnos, string horaInicio, string horaFin, int horas)
        {
            try
            {




                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();
                    string consulta = $"UPDATE horarios SET turnos = @turnos, horaInicio = @horaInicio, horaFin = @horaFin, horas = @horas WHERE id = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {

                        // Prepara una consulta SQL para actualizar el valor en la base de datos


                        cmd.Parameters.AddWithValue("@turnos", turnos);
                        cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@horaFin", horaFin);
                        cmd.Parameters.AddWithValue("@horas", horas);
                        cmd.Parameters.AddWithValue("@id", id);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El valor se ha actualizado con éxito");
                    }
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




                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return valorHora;
            }
        }






        public void ActualizarMesTrabajado(string nombre, int diferencia)
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

                            using (MySqlCommand cmd = new MySqlCommand("SELECT fecha FROM planificador.controlhs_2025 WHERE nombre_empleado = @nombre AND fecha >= @fechaInicio AND fecha < @fechaActual", con))
                            {
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicioMes);
                                cmd.Parameters.AddWithValue("@fechaActual", fechaActual.ToString("dd/MM/yyyy"));

                                List<DateTime> fechas = new List<DateTime>();

                                using (MySqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                        fechas.Add(Convert.ToDateTime(rdr["fecha"]));
                                    }
                                }

                                foreach (DateTime fecha in fechas)
                                {

                                    using (MySqlCommand cmd2 = new MySqlCommand("SELECT horas_trabajadas, acumulado FROM planificador.controlhs_2025 WHERE nombre_empleado = @nombre AND fecha = @fecha", con))
                                    {
                                        cmd2.Parameters.AddWithValue("@nombre", nombre);
                                        cmd2.Parameters.AddWithValue("@fecha", fecha.ToString("dd/MM/yyyy"));

                                        using (MySqlDataReader rdr = cmd2.ExecuteReader())
                                        {
                                            if (rdr.Read())
                                            {
                                                int minutosTrabajados = (int)rdr["horas_trabajadas"];
                                                double horasTrabajadas = minutosTrabajados / 60.0;

                                                AcumuladoAnterior = Convert.ToInt32(rdr["acumulado"]);
                                                AcumuladoFaltante = (int)Math.Round(diferencia * horasTrabajadas);
                                            }
                                        }
                                    }

                                    int AcumuladoBD = AcumuladoAnterior + AcumuladoFaltante;


                                    using (MySqlCommand updateCmd = new MySqlCommand("UPDATE planificador.controlhs_2025 SET acumulado = @acumulado WHERE nombre_empleado = @nombre AND fecha = @fecha", con, trans))
                                    {
                                        updateCmd.Parameters.AddWithValue("@nombre", nombre);
                                        updateCmd.Parameters.AddWithValue("@acumulado", AcumuladoBD);
                                        updateCmd.Parameters.AddWithValue("@fecha", fecha.ToString("dd/MM/yyyy"));

                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
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
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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
            }
            catch (Exception ex)
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


                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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


                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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
                                // Formatear la fecha con el día entre paréntesis
                                DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                                grilla.Rows[rowIndex].Cells[1].Value = fecha.ToString("dd/MM/yyyy (dddd)");
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
                MessageBox.Show("Error al cargar logueos: " + ex.Message);
            }
        }


        public void CargarGrillaLogueoFiltradaNombre(DataGridView grilla, string anio, string mes, string nombre)
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
                                // Formatear la fecha con el día entre paréntesis
                                DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                                grilla.Rows[rowIndex].Cells[1].Value = fecha.ToString("dd/MM/yyyy (dddd)");
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

        public void CargarGrillaLogueoFiltradaFecha(DataGridView grilla, string anio, string mes, string fecha)
        {
            grilla.Rows.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string tabla = "logueo_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE mes = @mes AND fecha = @fecha", conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@fecha", fecha);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar una nueva fila a la grilla
                                int rowIndex = grilla.Rows.Add();

                                // Acceder a las celdas de la fila recién creada y asignar los valores desde el reader
                                grilla.Rows[rowIndex].Cells[0].Value = reader["id"];
                                // Formatear la fecha con el día entre paréntesis
                                DateTime fecharda = Convert.ToDateTime(reader["fecha"]);
                                grilla.Rows[rowIndex].Cells[1].Value = fecharda.ToString("dd/MM/yyyy (dddd)");
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

        public string ObtenerNombreMes(int numeroDeMes)
        {
            switch (numeroDeMes)
            {
                case 1:
                    return "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
                default:
                    return "Mes no válido";
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
            feColumn.HeaderText = "HS trabajadas (MINUTOS)";
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
                                int horas = Convert.ToInt32(reader["horas_trabajadas"]);
                                int horas2 = (horas / 60);
                                grilla.Rows[rowIndex].Cells[3].Value = horas2 + " (" + reader["horas_trabajadas"] + ")";
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


        public void NuevoPagoExtra(string nombre, string anio, string mes, int detalle, string categoria, int monto, string descripcion)
        {
            string tablaAnual = "extras_" + anio;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tablaAnual} (nombre_empleado, mes, detalle, categoria, monto, descripcion) VALUES (@nombre, @mes, @detalle, @categoria, @monto, @descripcion)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@detalle", detalle);
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

        public void ModificarPagoExtra(string categoria, int monto, string descripcion, string categoria2, int monto2, string descripcion2)
        {
            string tablaAnual = "extras_2025";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tablaAnual} SET categoria = @categoria, monto = @monto, descripcion = @descripcion WHERE categoria = @categoria2 AND monto = @monto2 AND descripcion = @descripcion2", conn))
                    {

                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@categoria2", categoria2);
                        cmd.Parameters.AddWithValue("@monto2", monto2);
                        cmd.Parameters.AddWithValue("@descripcion2", descripcion2);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("PAGO EXTRA MODIFICADO CON EXITO!");
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


        public void AcomodarMinutos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    List<string> empleados = new List<string>();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    {


                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                empleados.Add(rdr["nombre"].ToString());
                            }
                        }
                    }
                    TimeSpan horaIngreso = TimeSpan.Zero;
                    TimeSpan horaEgreso = TimeSpan.Zero;
                    TimeSpan horasTrabajadas = TimeSpan.Zero;
                    int id = 0;
                    int minutosTrabajados = 0;


                    foreach (string empleado in empleados)
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT id, hora_ingreso, hora_egreso FROM planificador.controlhs_2025 WHERE nombre_empleado = @nombre", conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", empleado);
                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    id = (int)rdr["id"];
                                    //DateTime horaIngreso = Convert.ToDateTime(rdr["hora_ingreso"]);
                                    //DateTime horaEgreso = Convert.ToDateTime(rdr["hora_egreso"]);
                                    horaIngreso = (TimeSpan)rdr["hora_ingreso"];
                                    horaEgreso = (TimeSpan)rdr["hora_egreso"];
                                    // Manejo de cambios de día
                                    if (horaEgreso < horaIngreso)
                                    {
                                        horaEgreso = horaEgreso.Add(new TimeSpan(24, 0, 0)); // Sumar un día completo
                                    }
                                    horasTrabajadas = horaEgreso - horaIngreso;
                                    minutosTrabajados = (int)horasTrabajadas.TotalMinutes;
                                    using (MySqlConnection conn2 = new MySqlConnection(cadenaConexion))
                                    {
                                        conn2.Open();
                                        using (MySqlCommand cmd2 = new MySqlCommand("UPDATE planificador.controlhs_2025 SET horas_trabajadas = @minutos WHERE id = @id", conn2))
                                        {
                                            cmd2.Parameters.AddWithValue("@minutos", minutosTrabajados);
                                            cmd2.Parameters.AddWithValue("@id", id);
                                            cmd2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }






                }
                MessageBox.Show("Minutos actualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AcomodarAcumulado()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    List<string> empleados = new List<string>();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT nombre FROM empleados", conn))
                    {


                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                empleados.Add(rdr["nombre"].ToString());
                            }
                        }
                    }
                    int id = 0;
                    int minutosTrabajados = 0;
                    double horasTrabajadas = 0;
                    int valorHora = 0;


                    foreach (string empleado in empleados)
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT id, fecha, horas_trabajadas FROM planificador.controlhs_2025 WHERE nombre_empleado = @nombre AND fecha >= @fechaInicio AND fecha < @fechaActual", conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", empleado);
                            cmd.Parameters.AddWithValue("@fechaInicio", "01/06/2024");
                            cmd.Parameters.AddWithValue("@fechaActual", "30/06/2024");
                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    id = (int)rdr["id"];
                                    minutosTrabajados = (int)rdr["horas_trabajadas"];
                                    horasTrabajadas = minutosTrabajados / 60.00;
                                    string fecha = rdr["fecha"].ToString();



                                    using (MySqlConnection conn2 = new MySqlConnection(cadenaConexion))
                                    {
                                        conn2.Open();
                                        using (MySqlCommand cmd3 = new MySqlCommand("SELECT hora_normal FROM planificador.empleados WHERE nombre = @nombre", conn2))
                                        {
                                            cmd3.Parameters.AddWithValue("@nombre", empleado);
                                            using (MySqlDataReader rdr2 = cmd3.ExecuteReader())
                                            {
                                                if (rdr2.Read())
                                                {
                                                    valorHora = (int)rdr2["hora_normal"];
                                                }

                                            }

                                        }


                                        horasTrabajadas *= valorHora;

                                        if (EsFeriado(fecha) == true)
                                        {
                                            horasTrabajadas *= 2;
                                        }

                                        using (MySqlCommand cmd2 = new MySqlCommand("UPDATE planificador.controlhs_2024 SET acumulado = @acumulado WHERE id = @id", conn2))
                                        {
                                            cmd2.Parameters.AddWithValue("@acumulado", horasTrabajadas);
                                            cmd2.Parameters.AddWithValue("@id", id);
                                            cmd2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }






                }
                MessageBox.Show("Acumulado actualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void NuevoVacacionesSinGonce(string nombre, string salida, string regreso, string vacaciones)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();
                    string tabla = "planificador.turnos_2025";
                    if (DateTime.TryParseExact(salida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida) &&
                            DateTime.TryParseExact(regreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso))
                    {

                        for (DateTime fechaActual = fechaSalida; fechaActual <= fechaRegreso; fechaActual = fechaActual.AddDays(1))
                        {
                            string fechaSql = fechaActual.ToString("dd/MM/yyyy");
                            using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla} SET turno = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn))
                            {
                                cmd.Parameters.AddWithValue("@valor", vacaciones);

                                cmd.Parameters.AddWithValue("@fecha", fechaSql);
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@acumulado", 0);
                                cmd.Parameters.AddWithValue("@horas", 0);



                                cmd.ExecuteNonQuery();
                                MessageBox.Show("VACACIONES CREADAS CON ÉXITO!");
                            }
                        }





                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void NuevoVacaciones(string nombre, int dias, string salida, string regreso, int DiasTotales, int mes, int anio, string vacaciones)
        {
            int DiasAnteriores = 0;
            int DiasAgregar = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();



                    using (MySqlCommand cmd = new MySqlCommand("SELECT dia_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                DiasAnteriores = Convert.ToInt32(rdr["dia_vacaciones"]);
                            }
                        }


                    }

                    if (DiasAnteriores < DiasTotales)
                    {
                        MessageBox.Show("El empleado no cuenta con la cantidad de días vacacionales asignados. Intente de nuevo");
                        return;
                    }
                    else
                    {
                        DiasAgregar = DiasAnteriores - DiasTotales;
                    }


                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados SET dia_vacaciones = @dia WHERE nombre = @nombre", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dia", DiasAgregar);


                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO vacaciones (nombre_empleado, dias, salida, regreso) VALUES (@nombre, @dias, @salida, @regreso)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dias", dias);
                        cmd.Parameters.AddWithValue("@salida", salida);
                        cmd.Parameters.AddWithValue("@regreso", regreso);

                        cmd.ExecuteNonQuery();

                    }






                    conn.Close();

                    using (MySqlConnection conn2 = new MySqlConnection(cadenaConexion2))
                    {
                        conn2.Open();




                        string tablaAnual = "totales_" + anio;
                        string tabla = "turnos_" + anio;
                        int horasTotales = 0;
                        int acumuladoTotal = 0;
                        string valor = "vacaciones";
                        int valorHora = 0;
                        int horasManual = 0;

                        using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal, horas_vacaciones FROM empleados WHERE nombre = @nombre", conn2))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);

                            using (MySqlDataReader rdr = cmd.ExecuteReader())
                            {
                                if (rdr.Read())
                                {
                                    valorHora = Convert.ToInt32(rdr["hora_normal"]);
                                    horasManual = Convert.ToInt32(rdr["horas_vacaciones"]);
                                }
                            }
                        }

                        horasManual = horasManual / 5;

                        using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaAnual} WHERE mes = @mes AND nombre_empleado = @nombre", conn2))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@mes", mes);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    horasTotales = Convert.ToInt32(reader["horas"]);
                                    acumuladoTotal = Convert.ToInt32(reader["acumulado"]);
                                }
                            }
                        }

                        int acumuladoManual = valorHora * horasManual;



                        if (DateTime.TryParseExact(salida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida) &&
                            DateTime.TryParseExact(regreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso))
                        {

                            for (DateTime fechaActual = fechaSalida; fechaActual <= fechaRegreso; fechaActual = fechaActual.AddDays(1))
                            {
                                string fechaSql = fechaActual.ToString("dd/MM/yyyy");
                                using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla} SET turno = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn2))
                                {
                                    cmd.Parameters.AddWithValue("@valor", vacaciones);

                                    cmd.Parameters.AddWithValue("@fecha", fechaSql);
                                    cmd.Parameters.AddWithValue("@nombre", nombre);
                                    if (vacaciones == "vacaciones")
                                    {
                                        cmd.Parameters.AddWithValue("@horas", horasManual);
                                        cmd.Parameters.AddWithValue("@acumulado", acumuladoManual);
                                        horasTotales = horasTotales + horasManual;
                                        acumuladoTotal = acumuladoTotal + acumuladoManual;


                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@horas", 0);
                                        cmd.Parameters.AddWithValue("@acumulado", 0);
                                    }


                                    cmd.ExecuteNonQuery();
                                }
                            }


                            using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tablaAnual} SET horas = @horas, acumulado = @acumulado WHERE mes = @fecha AND nombre_empleado = @nombre", conn2))
                            {
                                cmd.Parameters.AddWithValue("@fecha", mes);
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@horas", horasTotales);
                                cmd.Parameters.AddWithValue("@acumulado", acumuladoTotal);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("VACACIONES CREADAS CON ÉXITO!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                        }





                    }
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void NuevoPagoHorasVacaciones(string nombre, int anio, string mes, int dias, string salida, string regreso)
        {


            int detalle = 1;
            string categoria = "VACACIONES";
            string descripcion = "VACACIONES POR " + dias + " días. " + salida + " - " + regreso;
            string tablaAnual = "extras_" + anio;
            int valorHora = 0;
            int horasManual = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal, horas_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                valorHora = Convert.ToInt32(rdr["hora_normal"]);
                                horasManual = Convert.ToInt32(rdr["horas_vacaciones"]);
                            }
                        }
                    }

                    horasManual = horasManual / 5;



                    int acumuladoManual = valorHora * horasManual;
                    int acumuladoFinal = acumuladoManual * dias;


                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tablaAnual} (nombre_empleado, mes, detalle, categoria, monto, descripcion) VALUES (@nombre, @mes, @detalle, @categoria, @monto, @descripcion)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@detalle", detalle);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@monto", acumuladoFinal);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ActualizarVacaciones(int id, string nombre, int dias, string salida, string regreso, int DiasTotales, int mes, int anio, string vacaciones)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {

                    conn.Open();


                    //TOMO LOS DATOS DE LAS VACACIONES A CAMBIAR
                    string fechaSalidaAnterior = string.Empty;
                    string fechaRegresoAnterior = string.Empty;
                    int DiasVacacionesAnterior = 0;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM vacaciones WHERE id = @id", conn))
                    {

                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                fechaSalidaAnterior = rdr["salida"].ToString();
                                fechaRegresoAnterior = rdr["regreso"].ToString();
                                DiasVacacionesAnterior = Convert.ToInt32(rdr["dias"]);
                            }
                        }


                    }




                    //REESTABLEZCO LOS DIAS DE VACACIONES
                    int DiasAnteriores = 0;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT dia_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                DiasAnteriores = Convert.ToInt32(rdr["dia_vacaciones"]);
                            }
                        }


                    }
                    int DiasAnterioresss = DiasAnteriores + DiasVacacionesAnterior;


                    int DiasFinales = 0;
                    if (DiasAnteriores < dias)
                    {
                        MessageBox.Show("El empleado no cuenta con la cantidad de días vacacionales asignados. Intente de nuevo");
                        return;
                    }
                    else
                    {
                        DiasFinales = DiasAnterioresss - dias;
                    }




                    int valorHora = 0;
                    int horasManual = 0;

                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal, horas_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                valorHora = Convert.ToInt32(rdr["hora_normal"]);
                                horasManual = Convert.ToInt32(rdr["horas_vacaciones"]);
                            }
                        }
                    }

                    horasManual = horasManual / 5;
                    int acumuladoManual = valorHora * horasManual;



                    //ACTUALIZO LAS VACACIONES
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE vacaciones SET nombre_empleado = @nombre, dias = @dias, salida = @salida, regreso = @regreso WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dias", dias);
                        cmd.Parameters.AddWithValue("@salida", salida);
                        cmd.Parameters.AddWithValue("@regreso", regreso);

                        cmd.ExecuteNonQuery();

                    }

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados SET dia_vacaciones = @dias WHERE nombre = @nombre", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dias", DiasFinales);


                        cmd.ExecuteNonQuery();

                    }

                    string tabla = "planificador.controlhs_2025";
                    if (DateTime.TryParseExact(fechaSalidaAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida) &&
                    DateTime.TryParseExact(fechaRegresoAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso))
                    {

                        for (DateTime fechaActual = fechaSalida; fechaActual <= fechaRegreso; fechaActual = fechaActual.AddDays(1))
                        {
                            string fechaSql = fechaActual.ToString("dd/MM/yyyy");
                            using (MySqlCommand cmd = new MySqlCommand($"DELETE FROM {tabla} WHERE fecha = @fecha AND nombre_empleado = @nombre", conn))
                            {

                                cmd.Parameters.AddWithValue("@fecha", fechaSql);
                                cmd.Parameters.AddWithValue("@nombre", nombre);



                                cmd.ExecuteNonQuery();
                            }
                        }





                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                    }


                    conn.Close();

                    using (MySqlConnection conn2 = new MySqlConnection(cadenaConexion2))
                    {

                        conn2.Open();
                        //LIMPIO EL PLANIFICADOR
                        string tabla2 = "turnos_" + anio;


                        string tablaAnual = "totales_" + anio;
                        int horasMensual = 0;
                        int acumuladoMensual = 0;
                        using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaAnual} WHERE mes = @mes AND nombre_empleado = @nombre", conn2))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@mes", mes);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    horasMensual = Convert.ToInt32(reader["horas"]);
                                    acumuladoMensual = Convert.ToInt32(reader["acumulado"]);
                                }
                            }
                        }



                        if (DateTime.TryParseExact(fechaSalidaAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida2) &&
                        DateTime.TryParseExact(fechaRegresoAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso2))
                        {

                            for (DateTime fechaActual = fechaSalida2; fechaActual <= fechaRegreso2; fechaActual = fechaActual.AddDays(1))
                            {
                                string fechaSql = fechaActual.ToString("dd/MM/yyyy");
                                using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla2} SET turno = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn2))
                                {
                                    cmd.Parameters.AddWithValue("@valor", "Libre");
                                    cmd.Parameters.AddWithValue("@fecha", fechaSql);
                                    cmd.Parameters.AddWithValue("@nombre", nombre);
                                    cmd.Parameters.AddWithValue("@horas", 0);
                                    cmd.Parameters.AddWithValue("@acumulado", 0);
                                    horasMensual = horasMensual - horasManual;
                                    acumuladoMensual = acumuladoMensual - acumuladoManual;


                                    cmd.ExecuteNonQuery();
                                }
                            }





                        }
                        else
                        {
                            MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                        }



                        //ACTUALIZO PLANIFICADOR Y LO PINTO
                        if (DateTime.TryParseExact(salida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida3) &&
                             DateTime.TryParseExact(regreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso3))
                        {

                            for (DateTime fechaActual3 = fechaSalida3; fechaActual3 <= fechaRegreso3; fechaActual3 = fechaActual3.AddDays(1))
                            {
                                string fechaSql2 = fechaActual3.ToString("dd/MM/yyyy");
                                using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla2} SET turno = @turno, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn2))
                                {
                                    cmd.Parameters.AddWithValue("@turno", vacaciones);
                                    cmd.Parameters.AddWithValue("@fecha", fechaSql2);
                                    cmd.Parameters.AddWithValue("@nombre", nombre);
                                    if (vacaciones == "vacaciones")
                                    {
                                        cmd.Parameters.AddWithValue("@horas", horasManual);
                                        cmd.Parameters.AddWithValue("@acumulado", acumuladoManual);
                                        horasMensual = horasMensual + horasManual;
                                        acumuladoMensual = acumuladoMensual + acumuladoManual;


                                        using (MySqlConnection connKiosco = new MySqlConnection(cadenaConexion))
                                        {
                                            connKiosco.Open();
                                            string horaInicio = "00:00:00";
                                            string horaFin = "0" + horasManual + ":00:00";

                                            DateTime horaInicioDateTime = DateTime.ParseExact(horaInicio, "HH:mm:ss", CultureInfo.InvariantCulture);
                                            DateTime horaFinDateTime = DateTime.ParseExact(horaFin, "HH:mm:ss", CultureInfo.InvariantCulture);



                                            int minutos = horasManual * 60;


                                            // Usa soloHora en tu lógica

                                            string nombreMes = ObtenerNombreMes(mes);




                                            using (MySqlCommand cmdKiosco = new MySqlCommand("INSERT INTO planificador.controlhs_2025 (fecha, nombre_empleado, hora_ingreso, hora_egreso, horas_trabajadas, acumulado, mes) VALUES (@fecha, @nombre, @hora1, @hora2, @hora3, @acumulado, @mes) ", connKiosco))
                                            {
                                                cmdKiosco.Parameters.AddWithValue("@fecha", fechaSql2);
                                                cmdKiosco.Parameters.AddWithValue("@nombre", nombre);
                                                cmdKiosco.Parameters.AddWithValue("@hora1", horaInicioDateTime);
                                                cmdKiosco.Parameters.AddWithValue("@hora2", horaFinDateTime);
                                                cmdKiosco.Parameters.AddWithValue("@hora3", minutos);
                                                cmdKiosco.Parameters.AddWithValue("@acumulado", acumuladoManual);
                                                cmdKiosco.Parameters.AddWithValue("@mes", nombreMes);

                                                cmdKiosco.ExecuteNonQuery();

                                            }
                                        }

                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@horas", 0);
                                        cmd.Parameters.AddWithValue("@acumulado", 0);
                                    }



                                    cmd.ExecuteNonQuery();

                                }
                            }




                        }
                        else
                        {
                            MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                        }

                        using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tablaAnual} SET horas = @horas, acumulado = @acumulado WHERE mes = @fecha AND nombre_empleado = @nombre", conn2))
                        {
                            cmd.Parameters.AddWithValue("@fecha", mes);
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@horas", horasMensual);
                            cmd.Parameters.AddWithValue("@acumulado", horasMensual);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("VACACIONES ACTUALIZADAS CON ÉXITO!");
                        }



                    }

                }


                //PLANIFICADOR





                //    //REESTABLEZCO LOS DIAS DE VACACIONES
                //    int DiasAnteriores = 0;
                //    using (MySqlCommand cmd = new MySqlCommand("SELECT dia_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                //    {

                //        cmd.Parameters.AddWithValue("@nombre", nombre);

                //        using (MySqlDataReader rdr = cmd.ExecuteReader())
                //        {
                //            while (rdr.Read())
                //            {
                //                DiasAnteriores = Convert.ToInt32(rdr["dia_vacaciones"]);
                //            }
                //        }


                //    }
                //    DiasAnteriores = DiasAnteriores + DiasVacacionesAnterior;


                //    int DiasFinales = 0;
                //    if (DiasAnteriores < dias)
                //    {
                //        MessageBox.Show("El empleado no cuenta con la cantidad de días vacacionales asignados. Intente de nuevo");
                //        return;
                //    }
                //    else
                //    {
                //        DiasFinales = DiasAnteriores - dias;
                //    }




                //    int valorHora = 0;
                //    int horasManual = 0;

                //    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal, horas_vacaciones FROM empleados WHERE nombre = @nombre", conn))
                //    {
                //        cmd.Parameters.AddWithValue("@nombre", nombre);

                //        using (MySqlDataReader rdr = cmd.ExecuteReader())
                //        {
                //            if (rdr.Read())
                //            {
                //                valorHora = Convert.ToInt32(rdr["hora_normal"]);
                //                horasManual = Convert.ToInt32(rdr["horas_vacaciones"]);
                //            }
                //        }
                //    }

                //    horasManual = horasManual / 5;
                //    int acumuladoManual = valorHora * horasManual;






                //    int horasMensual = 0;
                //    int acumuladoMensual = 0;
                //    using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaAnual} WHERE mes = @mes AND nombre_empleado = @nombre", conn))
                //    {
                //        cmd.Parameters.AddWithValue("@nombre", nombre);
                //        cmd.Parameters.AddWithValue("@mes", mes);

                //        using (MySqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            if (reader.Read())
                //            {
                //                horasMensual = Convert.ToInt32(reader["horas"]);
                //                acumuladoMensual = Convert.ToInt32(reader["acumulado"]);
                //            }
                //        }
                //    }




                //    //LIMPIO EL PLANIFICADOR
                //    string tabla = "turnos_" + anio;

                //    if (DateTime.TryParseExact(fechaSalidaAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida) &&
                //    DateTime.TryParseExact(fechaRegresoAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso))
                //    {

                //        for (DateTime fechaActual = fechaSalida; fechaActual <= fechaRegreso; fechaActual = fechaActual.AddDays(1))
                //        {
                //            string fechaSql = fechaActual.ToString("dd/MM/yyyy");
                //            using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla} SET turno = @valor, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn))
                //            {
                //                cmd.Parameters.AddWithValue("@valor", "Libre");
                //                cmd.Parameters.AddWithValue("@fecha", fechaSql);
                //                cmd.Parameters.AddWithValue("@nombre", nombre);
                //                cmd.Parameters.AddWithValue("@horas", 0);
                //                cmd.Parameters.AddWithValue("@acumulado", 0);
                //                horasMensual = horasMensual - horasManual;
                //                acumuladoMensual = acumuladoMensual - acumuladoManual;


                //                cmd.ExecuteNonQuery();
                //            }
                //        }





                //    }
                //    else
                //    {
                //        MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                //    }


                //    //ACTUALIZO LAS VACACIONES
                //    using (MySqlCommand cmd = new MySqlCommand("UPDATE vacaciones SET nombre_empleado = @nombre, dias = @dias, salida = @salida, regreso = @regreso WHERE id = @id", conn))
                //    {
                //        cmd.Parameters.AddWithValue("@id", id);
                //        cmd.Parameters.AddWithValue("@nombre", nombre);
                //        cmd.Parameters.AddWithValue("@dias", dias);
                //        cmd.Parameters.AddWithValue("@salida", salida);
                //        cmd.Parameters.AddWithValue("@regreso", regreso);

                //        cmd.ExecuteNonQuery();

                //    }

                //    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleados SET dia_vacaciones = @dias WHERE nombre = @nombre", conn))
                //    {

                //        cmd.Parameters.AddWithValue("@nombre", nombre);
                //        cmd.Parameters.AddWithValue("@dias", DiasFinales);


                //        cmd.ExecuteNonQuery();

                //    }










                //    //ACTUALIZO PLANIFICADOR Y LO PINTO
                //    if (DateTime.TryParseExact(salida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaSalida2) &&
                //         DateTime.TryParseExact(regreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegreso2))
                //    {

                //        for (DateTime fechaActual2 = fechaSalida2; fechaActual2 <= fechaRegreso2; fechaActual2 = fechaActual2.AddDays(1))
                //        {
                //            string fechaSql2 = fechaActual2.ToString("dd/MM/yyyy");
                //            using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tabla} SET turno = @turno, horas = @horas, acumulado = @acumulado WHERE fecha = @fecha AND nombre_empleado = @nombre", conn))
                //            {
                //                cmd.Parameters.AddWithValue("@turno", vacaciones);
                //                cmd.Parameters.AddWithValue("@fecha", fechaSql2);
                //                cmd.Parameters.AddWithValue("@nombre", nombre);
                //                if (vacaciones == "vacaciones")
                //                {
                //                    cmd.Parameters.AddWithValue("@horas", horasManual);
                //                    cmd.Parameters.AddWithValue("@acumulado", acumuladoManual);
                //                    horasMensual = horasMensual + horasManual;
                //                    acumuladoMensual = acumuladoMensual + acumuladoManual;


                //                    using (MySqlConnection connKiosco = new MySqlConnection(cadenaConexion))
                //                    {
                //                        connKiosco.Open();
                //                        string horaInicio = "00:00:00";
                //                        string horaFin = "0" + horasManual + ":00:00";

                //                        DateTime horaInicioDateTime = DateTime.ParseExact(horaInicio, "HH:mm:ss", CultureInfo.InvariantCulture);
                //                        DateTime horaFinDateTime = DateTime.ParseExact(horaFin, "HH:mm:ss", CultureInfo.InvariantCulture);



                //                        int minutos = horasManual * 60;


                //                        // Usa soloHora en tu lógica

                //                        string nombreMes = ObtenerNombreMes(mes);




                //                        using (MySqlCommand cmdKiosco = new MySqlCommand("INSERT INTO planificador.controlhs_2025 (fecha, nombre_empleado, hora_ingreso, hora_egreso, horas_trabajadas, acumulado, mes) VALUES (@fecha, @nombre, @hora1, @hora2, @hora3, @acumulado, @mes) ", connKiosco))
                //                        {
                //                            cmdKiosco.Parameters.AddWithValue("@fecha", fechaSql2);
                //                            cmdKiosco.Parameters.AddWithValue("@nombre", nombre);
                //                            cmdKiosco.Parameters.AddWithValue("@hora1", horaInicioDateTime);
                //                            cmdKiosco.Parameters.AddWithValue("@hora2", horaFinDateTime);
                //                            cmdKiosco.Parameters.AddWithValue("@hora3", minutos);
                //                            cmdKiosco.Parameters.AddWithValue("@acumulado", acumuladoManual);
                //                            cmdKiosco.Parameters.AddWithValue("@mes", nombreMes);

                //                            cmdKiosco.ExecuteNonQuery();

                //                        }
                //                    }

                //                }
                //                else
                //                {
                //                    cmd.Parameters.AddWithValue("@horas", 0);
                //                    cmd.Parameters.AddWithValue("@acumulado", 0);
                //                }



                //                cmd.ExecuteNonQuery();

                //            }
                //        }




                //    }
                //    else
                //    {
                //        MessageBox.Show("Formato de fecha no válido para la salida o regreso.");
                //    }

                //    using (MySqlCommand cmd = new MySqlCommand($"UPDATE {tablaAnual} SET horas = @horas, acumulado = @acumulado WHERE mes = @fecha AND nombre_empleado = @nombre", conn))
                //    {
                //        cmd.Parameters.AddWithValue("@fecha", mes);
                //        cmd.Parameters.AddWithValue("@fecha", mes);
                //        cmd.Parameters.AddWithValue("@nombre", nombre);
                //        cmd.Parameters.AddWithValue("@horas", horasMensual);
                //        cmd.Parameters.AddWithValue("@acumulado", horasMensual);

                //        cmd.ExecuteNonQuery();
                //        MessageBox.Show("VACACIONES ACTUALIZADAS CON ÉXITO!");
                //    }





                //}





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

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleados ORDER BY nombre ASC", conn))
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

        public void GuardarDatosRecibo(string nombre, string anio, string mes, TextBox txtHorasPlanificadas, Label lblHorasPlanificadas, TextBox txtHorasTrabajadas, Label lblHorasTrabajadas, TextBox txtConsumos)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();

                    // Verificar si ya existe un registro
                    bool existeRegistro = false;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM recibos WHERE empleado = @empleado AND mes = @mes AND anio = @anio", conn))
                    {
                        cmd.Parameters.AddWithValue("@empleado", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            existeRegistro = reader.HasRows;
                        }
                    }

                    // Ejecutar la operación de actualización o inserción según el caso
                    if (existeRegistro)
                    {
                        using (MySqlCommand cmd2 = new MySqlCommand("UPDATE recibos SET hsPlaniValor = @hsPlaniValor, hsPlaniCantidad = @hsPlaniCantidad, hsTrabajadasValor = @hsTrabajadasValor, hsTrabajadasCantidad = @hsTrabajadasCantidad, consumos = @consumos WHERE empleado = @empleado AND mes = @mes AND anio = @anio", conn))
                        {
                            cmd2.Parameters.AddWithValue("@empleado", nombre);
                            cmd2.Parameters.AddWithValue("@mes", mes);
                            cmd2.Parameters.AddWithValue("@anio", anio);
                            cmd2.Parameters.AddWithValue("@hsPlaniValor", Convert.ToInt32(txtHorasPlanificadas.Text));
                            cmd2.Parameters.AddWithValue("@hsPlaniCantidad", Convert.ToInt32(lblHorasPlanificadas.Text.Trim('(', ')')));
                            cmd2.Parameters.AddWithValue("@hsTrabajadasValor", Convert.ToInt32(txtHorasTrabajadas.Text));
                            cmd2.Parameters.AddWithValue("@hsTrabajadasCantidad", Convert.ToInt32(lblHorasTrabajadas.Text.Trim('(', ')')));
                            cmd2.Parameters.AddWithValue("@consumos", Convert.ToInt32(txtConsumos.Text));

                            cmd2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (MySqlCommand cmd3 = new MySqlCommand("INSERT INTO recibos (empleado, mes, anio, hsPlaniValor, hsPlaniCantidad, hsTrabajadasValor, hsTrabajadasCantidad, consumos) VALUES (@empleado, @mes, @anio, @hsPlaniValor, @hsPlaniCantidad, @hsTrabajadasValor, @hsTrabajadasCantidad, @consumos)", conn))
                        {
                            cmd3.Parameters.AddWithValue("@empleado", nombre);
                            cmd3.Parameters.AddWithValue("@mes", mes);
                            cmd3.Parameters.AddWithValue("@anio", anio);
                            cmd3.Parameters.AddWithValue("@hsPlaniValor", Convert.ToInt32(txtHorasPlanificadas.Text));
                            cmd3.Parameters.AddWithValue("@hsPlaniCantidad", Convert.ToInt32(lblHorasPlanificadas.Text.Trim('(', ')')));
                            cmd3.Parameters.AddWithValue("@hsTrabajadasValor", Convert.ToInt32(txtHorasTrabajadas.Text));
                            cmd3.Parameters.AddWithValue("@hsTrabajadasCantidad", Convert.ToInt32(lblHorasTrabajadas.Text.Trim('(', ')')));
                            cmd3.Parameters.AddWithValue("@consumos", Convert.ToInt32(txtConsumos.Text));

                            cmd3.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("RECIBO GUARDADO CON EXITO!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void CargarDatosRecibo(string nombreNoTrim, string anio, string mes, TextBox txtHorasPlanificadas, Label lblHorasPlanificadas, TextBox txtHorasTrabajadas, Label lblHorasTrabajadas, TextBox txtConsumos, ListBox lbDetalleSuma, ListBox lbDetalleResta, Label totalSumaDetalle, Label totalRestaDetalle)
        {
            try
            {
                string tablaPlanificar = "totales_" + anio;
                string tablaTotal = "controlhs_" + anio;
                string tablaExtras = "extras_" + anio;
                double totalAcumulado = 0;
                int sumaDetalle = 0;
                int restadetalle = 0;

                string nombre = nombreNoTrim.Trim();
                int totalHorasTrabajadas = 0;
                int subTotal = 0;
                int valorHora = 0;
                int NroMes = ObtenerNumeroMes(mes);

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
                {
                    conn.Open();

                    // Verificar si ya existen datos en la tabla "recibos"
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM recibos WHERE empleado = @empleado AND mes = @mes AND anio = @anio", conn))
                    {
                        cmd.Parameters.AddWithValue("@empleado", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Cargar datos desde la tabla "recibos"
                                txtHorasPlanificadas.Text = reader["hsPlaniValor"].ToString();
                                lblHorasPlanificadas.Text = "(" + reader["hsPlaniCantidad"] + ")";
                                txtHorasTrabajadas.Text = reader["hsTrabajadasValor"].ToString();
                                lblHorasTrabajadas.Text = "(" + reader["hsTrabajadasCantidad"] + ")";
                                txtConsumos.Text = reader["consumos"].ToString();

                                using (MySqlConnection connInterior = new MySqlConnection(cadenaConexion))
                                {
                                    connInterior.Open();
                                    using (MySqlCommand cmdInterior = new MySqlCommand($"SELECT * FROM {tablaExtras} WHERE nombre_empleado = @nombre AND mes = @mes", connInterior))
                                    {
                                        cmdInterior.Parameters.AddWithValue("@nombre", nombre);
                                        cmdInterior.Parameters.AddWithValue("@mes", mes);

                                        using (MySqlDataReader readerInterior = cmdInterior.ExecuteReader())
                                        {
                                            while (readerInterior.Read())
                                            {
                                                string categoria = readerInterior["categoria"].ToString().Trim();
                                                int monto = Convert.ToInt32(readerInterior["monto"]);
                                                string descripcion = readerInterior["descripcion"].ToString().Trim();
                                                int detalle = Convert.ToInt32(readerInterior["detalle"]);

                                                string itemText = $"{categoria} - $ {monto} - {descripcion}";
                                                if (detalle == 1)
                                                {
                                                    lbDetalleSuma.Items.Add(itemText);
                                                    sumaDetalle += monto;
                                                }
                                                else if (detalle == 0)
                                                {
                                                    lbDetalleResta.Items.Add(itemText);
                                                    restadetalle += monto;
                                                }
                                            }
                                        }

                                        totalSumaDetalle.Text = sumaDetalle.ToString();
                                        totalRestaDetalle.Text = restadetalle.ToString();
                                    }
                                }

                                return; // Salir, ya que los datos se cargaron desde "recibos"
                            }
                        }
                    }

                    //PLANIFICADO
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT horas, acumulado FROM {tablaPlanificar} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", NroMes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHorasPlanificadas.Text = reader["acumulado"].ToString();
                                lblHorasPlanificadas.Text = "(" + reader["horas"] + ")";
                            }
                        }


                    }

                    conn.Close();

                }
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();


                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                valorHora = Convert.ToInt32(reader["hora_normal"]);
                            }
                        }
                    }




                    //CONTROL HS
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT horas_trabajadas, acumulado FROM {tablaTotal} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //totalAcumulado = totalAcumulado + Convert.ToInt32(reader["acumulado"]);
                                totalHorasTrabajadas = totalHorasTrabajadas + Convert.ToInt32(reader["horas_trabajadas"]);
                                totalAcumulado = totalAcumulado + Convert.ToDouble(reader["acumulado"]);
                            }
                        }
                        double totalHorasMinutos = (double)totalHorasTrabajadas / 60.00;
                        //int TotalMostrar = (int)Math.Round(totalHorasMinutos * valorHora, 2);
                        int TotalMostrar2 = (int)Math.Round(totalHorasMinutos);
                        ////decimal TotalMostrar = totalHorasMinutos * valorHora;
                        txtHorasTrabajadas.Text = totalAcumulado.ToString();
                        lblHorasTrabajadas.Text = "(" + TotalMostrar2.ToString() + ")";

                    }







                    //EXTRAS
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tablaExtras} WHERE nombre_empleado = @nombre AND mes = @mes", conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        //using (MySqlDataReader reader = cmd.ExecuteReader())
                        //{
                        //    while (reader.Read())
                        //    {
                        //        string categoria = reader["categoria"].ToString().Trim();
                        //        if (categoria == "ADELANTO DE SUELDO")
                        //        {
                        //            totalAdelantos += Convert.ToInt32(reader["monto"]);
                        //        }
                        //        else if (categoria == "PREMIO")
                        //        {
                        //            totalPremios += Convert.ToInt32(reader["monto"]);
                        //        }
                        //        else if (categoria == "CONSUMOS")
                        //        {
                        //            totalConsumos += Convert.ToInt32(reader["monto"]);
                        //        }
                        //    }
                        //}


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string categoria = reader["categoria"].ToString().Trim();
                                int monto = Convert.ToInt32(reader["monto"]);
                                string descripcion = reader["descripcion"].ToString().Trim();
                                int detalle = Convert.ToInt32(reader["detalle"]);

                                string itemText = $"{categoria} - $ {monto} - {descripcion}";

                                if (detalle == 1)
                                {
                                    lbDetalleSuma.Items.Add(itemText);
                                    sumaDetalle = sumaDetalle + monto;
                                }
                                else
                                {
                                    if (detalle == 0)
                                    {
                                        lbDetalleResta.Items.Add(itemText);
                                        restadetalle = restadetalle + monto;
                                    }
                                }

                            }
                        }

                        totalSumaDetalle.Text = sumaDetalle.ToString();
                        totalRestaDetalle.Text = restadetalle.ToString();



                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void CargarEmpleadoRecibo(string empleado, Label id, TextBox nombre, TextBox apellido, TextBox email, TextBox fecha, TextBox antiguedad, TextBox hora_normal, TextBox diavacas, TextBox jornadaa, PictureBox foto)
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
                                jornadaa.Text = reader["horas_vacaciones"].ToString();


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

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE nombre_empleado = @nombre AND mes = @mes AND detalle = 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", empleado);
                        cmd.Parameters.AddWithValue("@mes", mes);


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string categoria = reader["categoria"].ToString();
                                string monto = reader["monto"].ToString();
                                string descripcionBD = reader["descripcion"].ToString();

                                // Concatenar cada descripción con un salto de línea
                                descripcionBuilder.AppendLine($"CATEGORIA: {categoria} - MONTO: $ {monto} - DESCRIPCION: {descripcionBD}");

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

        public string DescripcionAdelanto(string empleado, string anio, string mes)
        {
            StringBuilder descripcionBuilder = new StringBuilder();
            string tabla = "extras_" + anio;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion)) // Reemplaza "cadenaDeConexion" con tu cadena de conexión real
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tabla} WHERE nombre_empleado = @nombre AND mes = @mes AND detalle = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", empleado);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string categoria = reader["categoria"].ToString();
                                string monto = reader["monto"].ToString();
                                string descripcionBD = reader["descripcion"].ToString();

                                // Concatenar cada descripción con un salto de línea
                                descripcionBuilder.AppendLine($"CATEGORIA: {categoria} - MONTO: $ {monto} - DESCRIPCION: {descripcionBD}");




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

        public void EliminarVacaciones(int id)
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

                using (MySqlConnection conn = new MySqlConnection(cadenaConexion2))
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


        public void ActualizarLogeo(int id, string fecha, TimeSpan hora, string accion)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string tabla = "logueo_2025";
                    string query = $"UPDATE {tabla} SET fecha = @fecha, accion = @accion, hora = @hora WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@accion", accion);
                        cmd.Parameters.AddWithValue("@hora", hora);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro actualizado con éxito.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro para actualizar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }


        public void EliminarLogeo(int id)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar el logueo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si el usuario elige "Sí", proceder con la eliminación
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                    {
                        conn.Open();

                        string tabla = "logueo_2025";
                        string query = $"DELETE FROM {tabla} WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro eliminado con éxito.");
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro para eliminar.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja la excepción según tus necesidades
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
            else
            {
                // Si el usuario elige "No", no hacer nada
                MessageBox.Show("Eliminación cancelada.");
            }
        }

        public void EliminarPagoExtra(string categoria, int monto, string descripcion)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar el PAGO EXTRA?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si el usuario elige "Sí", proceder con la eliminación
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                    {
                        conn.Open();

                        string tabla = "extras_2025";
                        string query = $"DELETE FROM {tabla} WHERE categoria = @categoria2 AND monto = @monto2 AND descripcion = @descripcion2";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@categoria2", categoria);
                            cmd.Parameters.AddWithValue("@monto2", monto);
                            cmd.Parameters.AddWithValue("@descripcion2", descripcion);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro eliminado con éxito.");
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro para eliminar.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja la excepción según tus necesidades
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
            else
            {
                // Si el usuario elige "No", no hacer nada
                MessageBox.Show("Eliminación cancelada.");
            }
        }






        public bool NuevoLogeo(string nombre, string fecha, string accion, TimeSpan hora, string anio, string mes)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    // Obtener la huella dactilar desde la base de datos
                    byte[] huellaGuardada = ObtenerHuellaDesdeBD(nombre, conn);

                    // Verificar la huella dactilar si es necesario (dependiendo de tu aplicación)

                    string tabla = "logueo_2025";
                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tabla} (fecha, nombre_empleado, accion, hora, mes, huella_dactilar) VALUES (@fecha, @nombre, @accion, @hora, @mes, @huella)", conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@accion", accion);
                        cmd.Parameters.AddWithValue("@hora", hora);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@huella", huellaGuardada);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro enviado con éxito.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al registrar: " + ex.Message);
                return false;
            }
        }

        private byte[] ObtenerHuellaDesdeBD(string nombre, MySqlConnection connection)
        {
            byte[] huella = null;

            using (MySqlCommand cmd = new MySqlCommand("SELECT huella_dactilar FROM empleados WHERE nombre = @nombre", connection))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        huella = (byte[])rdr["huella_dactilar"];
                    }
                }
            }

            return huella;
        }


        //public TimeSpan HoraIngreso(string nombre, string anio)
        //{
        //    TimeSpan hora = TimeSpan.Zero;  // Inicializa la variable para evitar problemas de alcance

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
        //        {
        //            string tabla = "logueo_" + anio;
        //            //string tabla = "logueo_2023";
        //            string accion = "INGRESO";
        //            conn.Open();

        //            using (MySqlCommand cmd = new MySqlCommand($"SELECT hora FROM {tabla} WHERE nombre_empleado = @nombre AND accion = @accion ORDER BY id DESC LIMIT 1;", conn))
        //            {
        //                cmd.Parameters.AddWithValue("@nombre", nombre);
        //                cmd.Parameters.AddWithValue("@accion", accion);

        //                using (MySqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())  // Verifica si hay al menos una fila
        //                    {
        //                        // Lee la columna 'hora' y conviértela a TimeSpan
        //                        if (reader["hora"] != DBNull.Value)
        //                        {
        //                            hora = ((TimeSpan)reader["hora"]);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message, "Error");
        //    }

        //    return hora;
        //}





        public TimeSpan ObtenerHoraIngresoUpdate(string fecha, string anio, string nombre)
        {
            TimeSpan horaFinal = TimeSpan.Zero;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    string tabla = "controlhs_" + anio;

                    conn.Open();

                    DateTime fechaActual = DateTime.Parse(fecha);
                    DateTime fechaAnterior = fechaActual.AddDays(-1);
                    string fechaAnteriorStr = fechaAnterior.ToString("dd/MM/yyyy");

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT hora_ingreso FROM {tabla} WHERE nombre_empleado = @nombre AND fecha <= @fecha ORDER BY fecha DESC LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@fechaAnterior", fechaAnteriorStr);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["hora_ingreso"] != DBNull.Value)
                                {
                                    horaFinal = TimeSpan.Parse(reader["hora_ingreso"].ToString());
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró un ingreso válido para el empleado.", "Error");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un registro de ingreso previo.", "Error");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }

            return horaFinal;
        }




        public int ObtenerIdIngresoErroneo(string fecha, string anio, string nombre)
        {
            int idLogueo = -1; // Inicializa la variable con un valor que indique que no se encontró el registro

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    string tabla = "controlhs_" + anio;

                    conn.Open();

                    DateTime fechaActual = DateTime.Parse(fecha);
                    DateTime fechaAnterior = fechaActual.AddDays(-1);
                    string fechaAnteriorStr = fechaAnterior.ToString("yyyy-MM-dd");

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT id FROM {tabla} WHERE nombre_empleado = @nombre AND (fecha = @fecha OR fecha = @fechaAnterior) ORDER BY id DESC LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@fechaAnterior", fechaAnteriorStr);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Verifica si hay al menos una fila
                            {
                                // Lee la columna 'id' y la convierte a int
                                if (reader["id"] != DBNull.Value)
                                {
                                    idLogueo = Convert.ToInt32(reader["id"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }

            return idLogueo;
        }

        public string fechaIngreso(string nombre, string anio)
        {
            string fechaIngreso = string.Empty;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    string tabla = "logueo_" + anio;
                    //string tabla = "logueo_2023";
                    string accion = "INGRESO";
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT fecha FROM {tabla} WHERE nombre_empleado = @nombre AND accion = @accion ORDER BY id DESC LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@accion", accion);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())  // Verifica si hay al menos una fila
                            {
                                // Lee la columna 'hora' y conviértela a TimeSpan
                                if (reader["fecha"] != DBNull.Value)
                                {
                                    fechaIngreso = reader["fecha"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }

            return fechaIngreso;
        }

        public bool NuevoIngresoEgreso(string nombre, string fecha, TimeSpan horaIngreso, TimeSpan horaEgreso, string mes, string anio)
        {
            int valorHora = 0;
            int horaT = 0;
            int acumulado = 0;
            TimeSpan horasTrabajadas = TimeSpan.Zero;


            if (horaEgreso < horaIngreso)
            {
                horasTrabajadas = (horaEgreso - horaIngreso).Add(new TimeSpan(24, 0, 0));
            }
            else
            {
                horasTrabajadas = horaEgreso - horaIngreso;
            }

            int minutosTrabajados = (int)horasTrabajadas.TotalMinutes;
            horaT = Convert.ToInt32(minutosTrabajados / 60);



            string tabla = "controlhs_" + anio;
            //string tabla = "controlhs_2023";


            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                valorHora = Convert.ToInt32(reader["hora_normal"]);
                            }
                        }
                    }


                    acumulado = horaT * valorHora;
                    // Verificar si es feriado y ajustar el cálculo del acumulado
                    if (EsFeriado(fecha))
                    {
                        clsConexion objC = new clsConexion();
                        objC.NuevoPagoHorasExtras(nombre, anio, mes, acumulado, fecha, horaT);
                    }


                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tabla} (fecha, nombre_empleado, hora_ingreso, hora_egreso, horas_trabajadas, acumulado, mes) VALUES (@fecha, @nombre, @horaIngreso, @horaEgreso, @horaT, @acumulado, @mes)", conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horaIngreso", horaIngreso);
                        cmd.Parameters.AddWithValue("@horaEgreso", horaEgreso);
                        cmd.Parameters.AddWithValue("@horaT", minutosTrabajados);
                        cmd.Parameters.AddWithValue("@acumulado", acumulado);
                        cmd.Parameters.AddWithValue("@mes", mes);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro satisfactorio.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return false;
            }
        }



        public void NuevoPagoHorasExtras(string nombre, string anio, string mes, int monto, string fecha, int horasTrabajadas)
        {


            int detalle = 1;
            string categoria = "HORAS EXTRAS FERIADO";
            string descripcion = fecha + " - " + horasTrabajadas + " Horas trabajadas";
            string tablaAnual = "extras_" + anio;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tablaAnual} (nombre_empleado, mes, detalle, categoria, monto, descripcion) VALUES (@nombre, @mes, @detalle, @categoria, @monto, @descripcion)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@detalle", detalle);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public bool ModificarRegistro(string nombre, string fecha, TimeSpan horaIngreso, TimeSpan horaEgreso, string mes, string anio, int idLogueoErroneo)
        {
            int valorHora = 0;
            int horaT = 0;
            int acumulado = 0;
            TimeSpan horasTrabajadas = TimeSpan.Zero;

            if (horaEgreso < horaIngreso)
            {
                horasTrabajadas = (horaEgreso - horaIngreso).Add(new TimeSpan(24, 0, 0));
            }
            else
            {
                horasTrabajadas = horaEgreso - horaIngreso;
            }

            int minutosTrabajados = (int)horasTrabajadas.TotalMinutes;
            horaT = Convert.ToInt32(minutosTrabajados / 60);

            string tablaControlHoras = "controlhs_" + anio;
            string tablaLogueo = "logueo_" + anio;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    // Obtener valorHora
                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados WHERE nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                valorHora = Convert.ToInt32(reader["hora_normal"]);
                            }
                        }
                    }


                    acumulado = horaT * valorHora;
                    // Verificar si es feriado y ajustar el cálculo del acumulado
                    if (EsFeriado(fecha))
                    {
                        clsConexion objC = new clsConexion();
                        objC.NuevoPagoHorasExtras(nombre, anio, mes, acumulado, fecha, horaT);
                    }


                    // Iniciar una transacción
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                $@"UPDATE {tablaControlHoras} 
                           SET fecha = @fecha,
                               nombre_empleado = @nombre,
                               hora_ingreso = @horaIngreso,
                               hora_egreso = @horaEgreso,
                               horas_trabajadas = @horaT,
                               acumulado = @acumulado,
                               mes = @mes
                           WHERE id = @idLogueoErroneo", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fecha", fecha);
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@horaIngreso", horaIngreso);
                                cmd.Parameters.AddWithValue("@horaEgreso", horaEgreso);
                                cmd.Parameters.AddWithValue("@horaT", minutosTrabajados);
                                cmd.Parameters.AddWithValue("@acumulado", acumulado);
                                cmd.Parameters.AddWithValue("@mes", mes);
                                cmd.Parameters.AddWithValue("@idLogueoErroneo", idLogueoErroneo);

                                cmd.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaction.Commit();
                            MessageBox.Show("Registro modificado con éxito.");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción en caso de error
                            transaction.Rollback();
                            MessageBox.Show("ERROR: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return false;
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

        private bool IsValidImage(byte[] imageData)
        {
            try
            {
                using (var ms = new MemoryStream(imageData))
                {
                    Image.FromStream(ms);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public int ExisteIngreso(string nombre, string fecha, string mes, string anio)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string tabla = "logueo_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT accion FROM {tabla} WHERE nombre_empleado = @nombre AND mes = @mes ORDER BY id DESC LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@mes", mes);


                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string accion = rdr["accion"].ToString();
                                if (accion == "INGRESO")
                                {
                                    return 1;
                                }
                            }
                        }

                        // No se encontró un ingreso pendiente
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al registrar: " + ex.Message);
                return 0;
            }

        }






    }
}
