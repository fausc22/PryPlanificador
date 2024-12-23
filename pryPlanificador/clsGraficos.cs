using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using pryPlanificador;

namespace Planificador
{
    public class clsGraficos
    {
        private clsPlaneamiento plan = new clsPlaneamiento();
        // Datos de conexión
        private static string servidor = "26.83.72.84";
        private static string bd = "gootpv";
        private static string user = "sistema";
        private static string pw = "sistema";
        private static string port = "3306";

        // Cadena de conexión
        private string cadenaConexionRemota = $"server={servidor};port={port};user={user};password={pw};database={bd};";

        static string servidor2 = "localhost";
        static string bd2 = "planificador";
        static string user2 = "root";
        static string pw2 = "251199";
        static string port2 = "3306";

        string cadenaConexionLocal = "server=" + servidor2 + ";port=" + port2 + ";user=" + user2 + ";password=" + pw2 + ";database=" + bd2 + ";";

        private static string servidor3 = "26.83.72.84";
        private static string bd3 = "planificador";
        private static string user3 = "planificador";
        private static string pw3 = "251199";
        private static string port3 = "3306";

        // Cadena de conexión
        private string cadenaConexionKiosco = $"server={servidor3};port={port3};user={user3};password={pw3};database={bd3};";

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

        public void MigrarDatosMesAnio(string mes, int anio)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {

                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Verificar si ya existen datos para el mes y año seleccionados
                    string verificarDatos = @"
                SELECT COUNT(*) 
                FROM ingresos_ganancias_temp 
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio;";

                    using (MySqlCommand cmdVerificar = new MySqlCommand(verificarDatos, connLocal))
                    {
                        cmdVerificar.Parameters.AddWithValue("@mes", NroMes);
                        cmdVerificar.Parameters.AddWithValue("@anio", anio);

                        int cantidadRegistros = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        // Si ya existen datos, salir de la función
                        if (cantidadRegistros > 0)
                        {
                            
                            return;
                        }
                    }
                }


                // Conexión al servidor remoto
                using (MySqlConnection connRemoto = new MySqlConnection(cadenaConexionRemota))
                {
                    connRemoto.Open();

                    // Consulta para obtener los ingresos
                    string queryIngresos = @"
                SELECT 
                    DATE(FECHA) AS Fecha,
                    COALESCE(SUM(IMPORTE_SIN_IVA + IVA1), 0) AS Ingresos
                FROM 
                    eventos_hist 
                WHERE 
                    MONTH(FECHA) = @mes AND YEAR(FECHA) = @anio
                GROUP BY DATE(FECHA)
                ORDER BY Fecha ASC;";

                    // Consulta para obtener las ganancias
                    string queryGanancias = @"
                SELECT 
                    DATE(FECHA_TICKET) AS Fecha,
                    COALESCE(SUM(GANANCIA), 0) AS Ganancias
                FROM 
                    ev_cont_hist
                WHERE 
                    MONTH(FECHA_TICKET) = @mes AND YEAR(FECHA_TICKET) = @anio
                GROUP BY DATE(FECHA_TICKET)
                ORDER BY Fecha ASC;";

                    // Conexión al servidor local
                    using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                    {
                        connLocal.Open();

                        // Crear tabla temporal si no existe
                        string crearTabla = @"
                    CREATE TABLE IF NOT EXISTS ingresos_ganancias_temp (
                        Fecha DATE PRIMARY KEY,
                        Ingresos DECIMAL(10, 2) DEFAULT 0,
                        Ganancias DECIMAL(10, 2) DEFAULT 0
                    );";
                        using (MySqlCommand cmdCrear = new MySqlCommand(crearTabla, connLocal))
                        {
                            cmdCrear.ExecuteNonQuery();
                        }

                        

                        // Insertar ingresos
                        using (MySqlCommand cmdIngresos = new MySqlCommand(queryIngresos, connRemoto))
                        {
                            cmdIngresos.Parameters.AddWithValue("@mes", NroMes);
                            cmdIngresos.Parameters.AddWithValue("@anio", anio);

                            using (MySqlDataReader readerIngresos = cmdIngresos.ExecuteReader())
                            {
                                while (readerIngresos.Read())
                                {
                                    string fecha = readerIngresos.GetDateTime("Fecha").ToString("yyyy-MM-dd");
                                    decimal ingresos = readerIngresos.GetDecimal("Ingresos");

                                    string insertarIngresos = @"
                                INSERT INTO ingresos_ganancias_temp (Fecha, Ingresos)
                                VALUES (@Fecha, @Ingresos)
                                ON DUPLICATE KEY UPDATE Ingresos = @Ingresos;";
                                    using (MySqlCommand cmdInsertar = new MySqlCommand(insertarIngresos, connLocal))
                                    {
                                        cmdInsertar.Parameters.AddWithValue("@Fecha", fecha);
                                        cmdInsertar.Parameters.AddWithValue("@Ingresos", ingresos);
                                        cmdInsertar.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // Insertar ganancias
                        using (MySqlCommand cmdGanancias = new MySqlCommand(queryGanancias, connRemoto))
                        {
                            cmdGanancias.Parameters.AddWithValue("@mes", NroMes);
                            cmdGanancias.Parameters.AddWithValue("@anio", anio);

                            using (MySqlDataReader readerGanancias = cmdGanancias.ExecuteReader())
                            {
                                while (readerGanancias.Read())
                                {
                                    string fecha = readerGanancias.GetDateTime("Fecha").ToString("yyyy-MM-dd");
                                    decimal ganancias = readerGanancias.GetDecimal("Ganancias");

                                    string insertarGanancias = @"
                                INSERT INTO ingresos_ganancias_temp (Fecha, Ganancias)
                                VALUES (@Fecha, @Ganancias)
                                ON DUPLICATE KEY UPDATE Ganancias = @Ganancias;";
                                    using (MySqlCommand cmdInsertar = new MySqlCommand(insertarGanancias, connLocal))
                                    {
                                        cmdInsertar.Parameters.AddWithValue("@Fecha", fecha);
                                        cmdInsertar.Parameters.AddWithValue("@Ganancias", ganancias);
                                        cmdInsertar.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al migrar datos: " + ex.Message);
            }
        }



        public void CargarGrillaIngresosGanancias(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                ReadOnly = true,
                Width = 150
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ingresos",
                ReadOnly = true,
                Width = 120
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ganancias",
                ReadOnly = true,
                Width = 120
            });

            int NroMes = ObtenerNumeroMes(mes); // Convierte el nombre del mes en un número

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL con filtro por mes y año
                    string query = @"
                SELECT Fecha, Ingresos, Ganancias 
                FROM ingresos_ganancias_temp 
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio
                ORDER BY Fecha ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fecha = reader.GetDateTime("Fecha").ToString("dd/MM/yyyy");
                                decimal ingresos = reader.GetDecimal("Ingresos");
                                decimal ganancias = reader.GetDecimal("Ganancias");

                                grilla.Rows.Add(fecha, ingresos.ToString("C"), ganancias.ToString("C"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde localhost: " + ex.Message);
            }
        }

        public void CargarTotalesMes(Label lblTotalIngresos, Label lblTotalGanancias, string mes, int anio)
        {
            

            int NroMes = ObtenerNumeroMes(mes);
            decimal totalIngresos = 0;
            decimal totalGanancias = 0;

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta para sumar ingresos y ganancias del mes
                    string queryTotales = @"
                SELECT 
                    COALESCE(SUM(Ingresos), 0) AS TotalIngresos,
                    COALESCE(SUM(Ganancias), 0) AS TotalGanancias
                FROM ingresos_ganancias_temp
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio;";

                    using (MySqlCommand cmd = new MySqlCommand(queryTotales, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalIngresos = reader.GetDecimal("TotalIngresos");
                                totalGanancias = reader.GetDecimal("TotalGanancias");
                            }
                        }
                    }
                }

                lblTotalIngresos.Text = "TOTAL INGRESOS: $ " + totalIngresos.ToString();
                lblTotalGanancias.Text = "TOTAL GANANCIAS: $ " + totalGanancias.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular totales: " + ex.Message);
            }
        }



        public void ObtenerDiasProductivos(string mes, int anio,
                                   Label lblDiaMasProductivo,
                                   Label lblTotalDiaMasProductivo,
                                   Label lblGananciaDiaMasProductivo,
                                   Label lblDiaMenosProductivo,
                                   Label lblTotalDiaMenosProductivo,
                                   Label lblGananciaDiaMenosProductivo)
        {
            int NroMes = ObtenerNumeroMes(mes);

            string diaMasProductivo = "";
            decimal ingresosMasProductivo = 0;
            decimal gananciasMasProductivo = 0;

            string diaMenosProductivo = "";
            decimal ingresosMenosProductivo = decimal.MaxValue; // Valor alto para iniciar comparación
            decimal gananciasMenosProductivo = 0;

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta para obtener el día más productivo
                    string queryMasProductivo = @"
                SELECT Fecha, Ingresos, Ganancias
                FROM ingresos_ganancias_temp
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio
                ORDER BY Ingresos DESC
                LIMIT 1;";

                    using (MySqlCommand cmdMasProductivo = new MySqlCommand(queryMasProductivo, connLocal))
                    {
                        cmdMasProductivo.Parameters.AddWithValue("@mes", NroMes);
                        cmdMasProductivo.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmdMasProductivo.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime fecha = reader.GetDateTime("Fecha");
                                diaMasProductivo = $"{ObtenerNombreDiaEnEspanol(fecha.DayOfWeek)} {fecha.ToString("dd/MM/yyyy")}";
                                ingresosMasProductivo = reader.GetDecimal("Ingresos");
                                gananciasMasProductivo = reader.GetDecimal("Ganancias");
                            }
                        }
                    }

                    // Consulta para obtener el día menos productivo
                    string queryMenosProductivo = @"
                SELECT Fecha, Ingresos, Ganancias
                FROM ingresos_ganancias_temp
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio
                ORDER BY Ingresos ASC
                LIMIT 1;";

                    using (MySqlCommand cmdMenosProductivo = new MySqlCommand(queryMenosProductivo, connLocal))
                    {
                        cmdMenosProductivo.Parameters.AddWithValue("@mes", NroMes);
                        cmdMenosProductivo.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmdMenosProductivo.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime fecha = reader.GetDateTime("Fecha");
                                diaMenosProductivo = $"{ObtenerNombreDiaEnEspanol(fecha.DayOfWeek)} {fecha.ToString("dd/MM/yyyy")}";
                                ingresosMenosProductivo = reader.GetDecimal("Ingresos");
                                gananciasMenosProductivo = reader.GetDecimal("Ganancias");
                            }
                        }
                    }
                }

                // Asignar valores a los Labels
                lblDiaMasProductivo.Text = $"Día Más Productivo: {diaMasProductivo}";
                lblTotalDiaMasProductivo.Text = $"Ingresos: {ingresosMasProductivo:C}";
                lblGananciaDiaMasProductivo.Text = $"Ganancias: {gananciasMasProductivo:C}";

                lblDiaMenosProductivo.Text = $"Día Menos Productivo: {diaMenosProductivo}";
                lblTotalDiaMenosProductivo.Text = $"Ingresos: {ingresosMenosProductivo:C}";
                lblGananciaDiaMenosProductivo.Text = $"Ganancias: {gananciasMenosProductivo:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener días productivos: " + ex.Message);
            }
        }


        public void MostrarPromedioIngresosPorDia(string mes, int anio, Chart chartPromediosIngresos, Chart chartPromediosGanancias)
        {
            int NroMes = ObtenerNumeroMes(mes);

            // Diccionario para convertir el número del día al nombre del día en español
            Dictionary<int, string> diasSemana = new Dictionary<int, string>
    {
        { 1, "Domingo" },
        { 2, "Lunes" },
        { 3, "Martes" },
        { 4, "Miércoles" },
        { 5, "Jueves" },
        { 6, "Viernes" },
        { 7, "Sábado" }
    };

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta para obtener los promedios
                    string queryPromedios = @"
                SELECT 
                    DAYOFWEEK(Fecha) AS DiaSemana,
                    AVG(Ingresos) AS PromedioIngresos
                FROM ingresos_ganancias_temp
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio
                GROUP BY DAYOFWEEK(Fecha)
                ORDER BY DiaSemana;";

                    string queryPromedios2 = @"
                SELECT 
                    DAYOFWEEK(Fecha) AS DiaSemana,
                    AVG(Ganancias) AS PromedioGanancias
                FROM ingresos_ganancias_temp
                WHERE MONTH(Fecha) = @mes AND YEAR(Fecha) = @anio
                GROUP BY DAYOFWEEK(Fecha)
                ORDER BY DiaSemana;";

                    // Configurar el gráfico de ingresos
                    using (MySqlCommand cmd = new MySqlCommand(queryPromedios, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartPromediosIngresos.Series.Clear();
                            chartPromediosIngresos.Titles.Clear();
                            chartPromediosIngresos.Titles.Add("Promedio de Ingresos por Día de la Semana");

                            chartPromediosIngresos.Legends.Clear();
                            var legend = chartPromediosIngresos.Legends.Add("Ingresos");
                            legend.Title = "Promedio Ingresos por Día";
                            
                            legend.ForeColor = System.Drawing.Color.Blue;     // Color de los textos de la leyenda

                            var series = chartPromediosIngresos.Series.Add("Promedio Ingresos");
                            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                            while (reader.Read())
                            {
                                int diaSemana = reader.GetInt32("DiaSemana");
                                decimal promedioIngresos = reader.GetDecimal("PromedioIngresos");

                                string nombreDia = diasSemana[diaSemana];
                                var point = series.Points.AddXY(nombreDia, promedioIngresos);

                                // Añadir el valor promedio a la leyenda
                                series.LegendText = $"{series.LegendText}\n{nombreDia}: {promedioIngresos:C}";
                            }
                        }
                    }

                    // Configurar el gráfico de ganancias
                    using (MySqlCommand cmd = new MySqlCommand(queryPromedios2, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartPromediosGanancias.Series.Clear();
                            chartPromediosGanancias.Titles.Clear();
                            chartPromediosGanancias.Titles.Add("Promedio de Ganancias por Día de la Semana");

                            chartPromediosGanancias.Legends.Clear();
                            var legend = chartPromediosGanancias.Legends.Add("Ganancias");
                            legend.Title = "Promedio Ganancias por Día";
                            
                            legend.ForeColor = System.Drawing.Color.Green;     // Color de los textos de la leyenda

                            var series = chartPromediosGanancias.Series.Add("Promedio Ganancias");
                            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                            while (reader.Read())
                            {
                                int diaSemana = reader.GetInt32("DiaSemana");
                                decimal promedioGanancias = reader.GetDecimal("PromedioGanancias");

                                string nombreDia = diasSemana[diaSemana];
                                var point = series.Points.AddXY(nombreDia, promedioGanancias);

                                // Añadir el valor promedio a la leyenda
                                series.LegendText = $"{series.LegendText}\n{nombreDia}: {promedioGanancias:C}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular promedios: " + ex.Message);
            }
        }


        public void CargarGraficoMediosDePago(string mes, int anio, Chart chartMediosPago)
        {
            int NroMes = ObtenerNumeroMes(mes);
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexionRemota))
                {
                    conn.Open();

                    // Consulta para obtener la cantidad de tickets por medio de pago
                    string query = @"
                SELECT 
                    MODO_PAGO,
                    COUNT(NRO_TICKET) AS CantidadTickets
                FROM EV_MEDIOS_HIST
                WHERE
	                MONTH(FECHA_TICKET) = @mes AND YEAR(FECHA_TICKET) = @anio
                GROUP BY MODO_PAGO
                ORDER BY CantidadTickets DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Configurar el Chart
                            chartMediosPago.Series.Clear();
                            chartMediosPago.Titles.Clear();
                            chartMediosPago.Titles.Add("Distribución de Medios de Pago");

                            chartMediosPago.Legends.Clear();
                            var legend = chartMediosPago.Legends.Add("MediosDePagoLegend");
                            legend.Title = "Medios de Pago";
                            legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;

                            var series = chartMediosPago.Series.Add("Medios de Pago");
                            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                            series.Legend = legend.Name; // Asociar la serie a la leyenda creada

                            // Variables para calcular totales y porcentajes
                            int totalTickets = 0;
                            List<(string ModoPago, int CantidadTickets)> datosMediosPago = new List<(string, int)>();

                            // Leer datos y calcular total
                            while (reader.Read())
                            {
                                string modoPago = reader.GetString("MODO_PAGO");
                                int cantidadTickets = reader.GetInt32("CantidadTickets");
                                totalTickets += cantidadTickets;
                                datosMediosPago.Add((modoPago, cantidadTickets));
                            }

                            // Añadir datos al gráfico
                            foreach (var dato in datosMediosPago)
                            {
                                string modoPago = dato.ModoPago;
                                int cantidadTickets = dato.CantidadTickets;
                                double porcentaje = (double)cantidadTickets / totalTickets * 100;

                                // Agregar datos al Chart
                                var pointIndex = series.Points.AddY(cantidadTickets);
                                series.Points[pointIndex].LegendText = $"{modoPago}: {cantidadTickets} ({porcentaje:F2}%)";
                                series.Points[pointIndex].Label = $"{porcentaje:F2}%";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico: " + ex.Message);
            }
        }


        public void CargarGraficoVariacionHoraria(string mesForm, int anio, Chart chartVariacionHoraria)
        {
            int mes = ObtenerNumeroMes(mesForm);
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexionRemota))
                {
                    conn.Open();

                    // Consulta SQL para obtener ingresos y cantidad de tickets por rangos horarios
                    string query = @"
                SELECT 
                    CASE
                        WHEN HOUR(HORA) >= 8 AND HOUR(HORA) < 12 THEN '08:00-12:00'
                        WHEN HOUR(HORA) >= 12 AND HOUR(HORA) < 16 THEN '12:00-16:00'
                        WHEN HOUR(HORA) >= 16 AND HOUR(HORA) < 20 THEN '16:00-20:00'
                        WHEN HOUR(HORA) >= 20 AND HOUR(HORA) < 24 THEN '20:00-00:00'
                        WHEN HOUR(HORA) >= 0 AND HOUR(HORA) < 3 THEN '00:00-03:00'
                        ELSE '03:00-08:00'
                    END AS RangoHorario,
                    SUM(IMPORTE_SIN_IVA + IVA1) AS TotalIngresos,
                    COUNT(NRO_TICKET) AS CantidadTickets
                FROM EVENTOS_HIST
                WHERE MONTH(FECHA) = @mes AND YEAR(FECHA) = @anio
                GROUP BY RangoHorario
                ORDER BY FIELD(RangoHorario, '08:00-12:00', '12:00-16:00', '16:00-20:00', '20:00-00:00', '00:00-03:00', '03:00-08:00');";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Configurar el Chart
                            chartVariacionHoraria.Series.Clear();
                            chartVariacionHoraria.Titles.Clear();
                            chartVariacionHoraria.Titles.Add($"Variación Horaria - Picos y Caídas ({mes}/{anio})");

                            chartVariacionHoraria.Legends.Clear();
                            var legend = chartVariacionHoraria.Legends.Add("Horarios");
                            legend.Title = "Resultados por Horarios";
                            legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;

                            // Serie para las barras
                            var seriesBarras = chartVariacionHoraria.Series.Add("Ingresos");
                            seriesBarras.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                            // Serie para la línea
                            var seriesLinea = chartVariacionHoraria.Series.Add("Tendencia");
                            seriesLinea.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            seriesLinea.BorderWidth = 2;
                            seriesLinea.Color = System.Drawing.Color.Red;
                            seriesLinea.IsValueShownAsLabel = false;

                            while (reader.Read())
                            {
                                string rangoHorario = reader.GetString("RangoHorario");
                                decimal totalIngresos = reader.GetDecimal("TotalIngresos");
                                int cantidadTickets = reader.GetInt32("CantidadTickets");

                                // Agregar datos a las barras
                                var pointIndex = seriesBarras.Points.AddY(totalIngresos);
                                seriesBarras.Points[pointIndex].AxisLabel = rangoHorario;

                                // Agregar datos a la línea
                                seriesLinea.Points.AddY(totalIngresos);

                                // Configurar la leyenda con monto total y cantidad de tickets
                                chartVariacionHoraria.Legends[0].CustomItems.Add(
                                    new System.Windows.Forms.DataVisualization.Charting.LegendItem
                                    {
                                        Name = rangoHorario,
                                        Color = seriesBarras.Color,
                                        Cells = {
                                    new System.Windows.Forms.DataVisualization.Charting.LegendCell
                                    {
                                        Text = $"{rangoHorario}",
                                        Alignment = System.Drawing.ContentAlignment.MiddleLeft
                                    },
                                    new System.Windows.Forms.DataVisualization.Charting.LegendCell
                                    {
                                        Text = $"{totalIngresos:C}",
                                        Alignment = System.Drawing.ContentAlignment.MiddleCenter
                                    },
                                    new System.Windows.Forms.DataVisualization.Charting.LegendCell
                                    {
                                        Text = $"{cantidadTickets} tickets",
                                        Alignment = System.Drawing.ContentAlignment.MiddleRight
                                    }
                                        }
                                    }
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico: " + ex.Message);
            }
        }




        //-----------------------------------------------------                       MODULO PRODUCTOS      -------------------------------------------------------------------

        public void MigrarTablasMesAnio(string mes, int anio)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Verificar si ya existen datos para el mes y año seleccionados en la base local
                    string verificarDatos = @"
                SELECT COUNT(*) 
                FROM EV_CONT_HIST_LOCAL 
                WHERE MONTH(FECHA_TICKET) = @mes AND YEAR(FECHA_TICKET) = @anio;";

                    using (MySqlCommand cmdVerificar = new MySqlCommand(verificarDatos, connLocal))
                    {
                        cmdVerificar.Parameters.AddWithValue("@mes", NroMes);
                        cmdVerificar.Parameters.AddWithValue("@anio", anio);

                        int cantidadRegistros = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        // Si los datos ya existen en la base local, salir de la función
                        if (cantidadRegistros > 0)
                        {
                            
                            return;
                        }
                    }

                    // Crear tablas locales si no existen
                    string crearTablas = @"
                CREATE TABLE IF NOT EXISTS ARTICULO_LOCAL (
                    CODIGO_BARRA VARCHAR(50),
                    COD_INTERNO INT PRIMARY KEY,
                    PRECIO_SIN_IVA DECIMAL(10, 2),
                    COSTO DECIMAL(10, 2),
                    GANANCIA DECIMAL(10, 2),
                    PRECIO DECIMAL(10, 2),
                    ART_DESC_VTA VARCHAR(255),
                    COD_DPTO INT,
                    COD_RUBRO INT,
                    COD_SUBRUBRO INT
                );
                CREATE TABLE IF NOT EXISTS CLASIF_LOCAL (
                    NOM_CLASIF VARCHAR(255),
                    ID_CLASIF INT PRIMARY KEY,
                    DAT_CLASIF INT
                );
                CREATE TABLE IF NOT EXISTS EV_CONT_HIST_LOCAL (
                    COD_INTERNO INT,
                    COD_BARRA VARCHAR(50),
                    COD_DEPTO INT,
                    COD_RUBRO INT,
                    COD_SUBRUBRO INT,
                    CANTIDAD INT,
                    TOTAL DECIMAL(10, 2),
                    IMPORTE_SIN_IVA DECIMAL(10, 2),
                    IVA1 DECIMAL(10, 2),
                    COSTO DECIMAL(10, 2),
                    GANANCIA DECIMAL(10, 2),
                    FECHA_TICKET DATE,
                    NRO_TICKET INT,
                    HORAS_REG TIME
                );";

                    using (MySqlCommand cmdCrear = new MySqlCommand(crearTablas, connLocal))
                    {
                        cmdCrear.ExecuteNonQuery();
                    }

                    // Conexión al servidor remoto para migrar los datos
                    using (MySqlConnection connRemoto = new MySqlConnection(cadenaConexionRemota))
                    {
                        connRemoto.Open();

                        // Migrar datos de ARTICULO con columnas específicas
                        string queryArticulo = @"
                SELECT 
                    CODIGO_BARRA, 
                    COD_INTERNO, 
                    PRECIO_SIN_IVA, 
                    COSTO, 
                    GANANCIA, 
                    PRECIO, 
                    ART_DESC_VTA, 
                    COD_DPTO, 
                    COD_RUBRO, 
                    COD_SUBRUBRO 
                FROM ARTICULO;";
                        MigrarTabla(queryArticulo, "ARTICULO_LOCAL", connRemoto, connLocal);

                        // Migrar datos de CLASIF con columnas específicas
                        string queryClasif = @"
                SELECT 
                    NOM_CLASIF, 
                    ID_CLASIF, 
                    DAT_CLASIF 
                FROM CLASIF;";
                        MigrarTabla(queryClasif, "CLASIF_LOCAL", connRemoto, connLocal);

                        // Migrar datos de EV_CONT_HIST para el mes y año seleccionados con columnas específicas
                        string queryEvContHist = @"
                SELECT 
                    COD_INTERNO, 
                    COD_BARRA, 
                    COD_DEPTO, 
                    COD_RUBRO, 
                    COD_SUBRUBRO, 
                    CANTIDAD, 
                    TOTAL, 
                    IMPORTE_SIN_IVA, 
                    IVA1, 
                    COSTO, 
                    GANANCIA, 
                    FECHA_TICKET, 
                    NRO_TICKET, 
                    HORAS_REG 
                FROM EV_CONT_HIST 
                WHERE MONTH(FECHA_TICKET) = @mes AND YEAR(FECHA_TICKET) = @anio;";
                        MigrarTabla(queryEvContHist, "EV_CONT_HIST_LOCAL", connRemoto, connLocal, NroMes, anio);
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al migrar datos: " + ex.Message);
            }
        }




        private void MigrarTabla(string query, string tablaDestino, MySqlConnection connRemoto, MySqlConnection connLocal, int mes = 0, int anio = 0)
        {
            using (MySqlCommand cmdRemoto = new MySqlCommand(query, connRemoto))
            {
                if (mes > 0 && anio > 0)
                {
                    cmdRemoto.Parameters.AddWithValue("@mes", mes);
                    cmdRemoto.Parameters.AddWithValue("@anio", anio);
                }

                using (MySqlDataReader reader = cmdRemoto.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construir el INSERT dinámico
                        string columns = string.Join(", ", Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)));
                        string values = string.Join(", ", Enumerable.Range(0, reader.FieldCount).Select(i => $"@{reader.GetName(i)}"));

                        string insertQuery = $@"
                    INSERT INTO {tablaDestino} ({columns})
                    VALUES ({values})
                    ON DUPLICATE KEY UPDATE {string.Join(", ", Enumerable.Range(0, reader.FieldCount).Select(i => $"{reader.GetName(i)} = VALUES({reader.GetName(i)})"))};";

                        using (MySqlCommand cmdLocal = new MySqlCommand(insertQuery, connLocal))
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                cmdLocal.Parameters.AddWithValue($"@{reader.GetName(i)}", reader.IsDBNull(i) ? DBNull.Value : reader.GetValue(i));
                            }

                            cmdLocal.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void CargarGrillaProductosMasVendidos(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Producto",
                ReadOnly = true,
                Width = 250
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio",
                ReadOnly = true,
                Width = 120
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad Vendida",
                ReadOnly = true,
                Width = 70
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Ventas",
                ReadOnly = true,
                Width = 120
            });

            int NroMes = ObtenerNumeroMes(mes); // Convierte el nombre del mes en un número

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL con filtro por mes y año
                    string query = @"
        SELECT 
            a.ART_DESC_VTA AS NombreProducto,
            a.PRECIO AS PrecioProducto,
            SUM(c.CANTIDAD) AS CantidadVendida,
            SUM(c.TOTAL) AS TotalVentas
        FROM EV_CONT_HIST_LOCAL c
        INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
        WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
        GROUP BY c.COD_INTERNO
        ORDER BY CantidadVendida DESC LIMIT 50;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string producto = reader.GetString("NombreProducto");
                                decimal precio = reader.GetDecimal("PrecioProducto");
                                int cantidad = reader.GetInt32("CantidadVendida");
                                decimal total = reader.GetDecimal("TotalVentas");

                                grilla.Rows.Add(producto, precio.ToString("C"), cantidad.ToString(), total.ToString("C"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde localhost: " + ex.Message);
            }
        }

        public void MostrarTopProductosMasVendidos(string mes, int anio, Chart chartTopProductos)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta para obtener el Top 10 de productos más vendidos
                    string query = @"
            SELECT 
                a.ART_DESC_VTA AS NombreProducto,
                SUM(c.CANTIDAD) AS CantidadVendida
            FROM EV_CONT_HIST_LOCAL c
            INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
            WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
            GROUP BY c.COD_INTERNO
            ORDER BY CantidadVendida DESC
            LIMIT 10;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Configurar el gráfico
                            chartTopProductos.Series.Clear();
                            chartTopProductos.Titles.Clear();
                            chartTopProductos.Legends.Clear();
                            chartTopProductos.ChartAreas.Clear();

                            chartTopProductos.Titles.Add("Top 10 Productos Más Vendidos");

                            // Crear área de gráfico y deshabilitar etiquetas en el eje X
                            var chartArea = new ChartArea();
                            chartArea.AxisX.LabelStyle.Enabled = false; // Ocultar etiquetas debajo de las barras
                            chartTopProductos.ChartAreas.Add(chartArea);

                            // Configurar la leyenda
                            var legend = chartTopProductos.Legends.Add("Productos");
                            legend.Docking = Docking.Right; // Leyenda a la derecha
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular); // Fuente más pequeña
                            legend.Title = ""; // Eliminar título de la leyenda

                            // Crear serie
                            var series = chartTopProductos.Series.Add("");
                            series.ChartType = SeriesChartType.Column; // Barras verticales
                            series.IsValueShownAsLabel = true; // Mostrar valores sobre las barras
                            series.IsVisibleInLegend = false; // No mostrar la serie en la leyenda

                            int colorIndex = 0; // Índice para asignar colores únicos
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple,
                        System.Drawing.Color.DarkOrange,
                        System.Drawing.Color.Teal,
                        System.Drawing.Color.CornflowerBlue,
                        System.Drawing.Color.Crimson,
                        System.Drawing.Color.OliveDrab
                            };

                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                int cantidadVendida = reader.GetInt32("CantidadVendida");

                                // Agregar datos al gráfico (sin nombres en el eje X)
                                var pointIndex = series.Points.AddY(cantidadVendida);

                                // Configurar color único para cada barra
                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                // Configurar texto de la leyenda (solo nombre del producto)
                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = nombreProducto
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico: " + ex.Message);
            }
        }




        public void CargarGrillaCategoriaMasVendida(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Categoría",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Cantidad Vendida",
                ReadOnly = true,
                Width = 50
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Ventas",
                ReadOnly = true,
                Width = 85
            });

            int NroMes = ObtenerNumeroMes(mes); // Convierte el nombre del mes en un número

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL con filtro por mes y año
                    string query = @"
            SELECT 
                c.NOM_CLASIF AS NombreCategoria,
                SUM(e.CANTIDAD) AS TotalCantidadVendida,
                SUM(e.TOTAL) AS TotalVentas
            FROM EV_CONT_HIST_LOCAL e
            LEFT JOIN CLASIF_LOCAL c ON c.ID_CLASIF = e.COD_DEPTO
            WHERE YEAR(e.FECHA_TICKET) = @anio 
              AND MONTH(e.FECHA_TICKET) = @mes
              AND c.NOM_CLASIF IS NOT NULL
            GROUP BY c.NOM_CLASIF
            ORDER BY TotalCantidadVendida DESC
            LIMIT 50;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreCategoria = reader.GetString("NombreCategoria");
                                int cantidadVendida = reader.GetInt32("TotalCantidadVendida");
                                decimal totalVentas = reader.GetDecimal("TotalVentas");

                                grilla.Rows.Add(nombreCategoria, cantidadVendida.ToString(), totalVentas.ToString("C"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde localhost: " + ex.Message);
            }
        }

        public void CargarGrillaRubroMasVendido(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Rubro",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Cantidad Vendida",
                ReadOnly = true,
                Width = 50
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Ventas",
                ReadOnly = true,
                Width = 85
            });

            int NroMes = ObtenerNumeroMes(mes); // Convierte el nombre del mes en un número

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL con filtro por mes y año
                    string query = @"
            SELECT 
                c.NOM_CLASIF AS NombreCategoria,
                SUM(e.CANTIDAD) AS TotalCantidadVendida,
                SUM(e.TOTAL) AS TotalVentas
            FROM EV_CONT_HIST_LOCAL e
            LEFT JOIN CLASIF_LOCAL c ON c.DAT_CLASIF = e.COD_RUBRO
            WHERE YEAR(e.FECHA_TICKET) = @anio 
              AND MONTH(e.FECHA_TICKET) = @mes
              AND c.NOM_CLASIF IS NOT NULL
            GROUP BY c.NOM_CLASIF
            ORDER BY TotalCantidadVendida DESC
            LIMIT 50;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreCategoria = reader.GetString("NombreCategoria");
                                int cantidadVendida = reader.GetInt32("TotalCantidadVendida");
                                decimal totalVentas = reader.GetDecimal("TotalVentas");

                                grilla.Rows.Add(nombreCategoria, cantidadVendida.ToString(), totalVentas.ToString("C"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde localhost: " + ex.Message);
            }
        }

        public void CargarGrillaSubRubroMasVendido(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre SubRubro",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Cantidad Vendida",
                ReadOnly = true,
                Width = 50
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Ventas",
                ReadOnly = true,
                Width = 85
            });

            int NroMes = ObtenerNumeroMes(mes); // Convierte el nombre del mes en un número

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL con filtro por mes y año
                    string query = @"
            SELECT 
                c.NOM_CLASIF AS NombreCategoria,
                SUM(e.CANTIDAD) AS TotalCantidadVendida,
                SUM(e.TOTAL) AS TotalVentas
            FROM EV_CONT_HIST_LOCAL e
            LEFT JOIN CLASIF_LOCAL c ON c.DAT_CLASIF = e.COD_SUBRUBRO
            WHERE YEAR(e.FECHA_TICKET) = @anio 
              AND MONTH(e.FECHA_TICKET) = @mes
              AND c.NOM_CLASIF IS NOT NULL
            GROUP BY c.NOM_CLASIF
            ORDER BY TotalCantidadVendida DESC
            LIMIT 50;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreCategoria = reader.GetString("NombreCategoria");
                                int cantidadVendida = reader.GetInt32("TotalCantidadVendida");
                                decimal totalVentas = reader.GetDecimal("TotalVentas");

                                grilla.Rows.Add(nombreCategoria, cantidadVendida.ToString(), totalVentas.ToString("C"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde localhost: " + ex.Message);
            }
        }



        public void CargarProductosMasBeneficiosos(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Producto",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ganancia Unidad",
                ReadOnly = true,
                Width = 80
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Costo Unidad",
                ReadOnly = true,
                Width = 80
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Vendido",
                ReadOnly = true,
                Width = 90
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Ganancia",
                ReadOnly = true,
                Width = 90
            });

            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
                SELECT 
                    a.ART_DESC_VTA AS NombreProducto,
                    a.GANANCIA AS Ganancia_Unidad,
                    a.COSTO AS Costo_Unidad,
                    SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido,
                    SUM(c.CANTIDAD * a.GANANCIA) AS TotalGanancia
                FROM EV_CONT_HIST_LOCAL c
                INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                GROUP BY c.COD_INTERNO, a.GANANCIA, a.COSTO
                ORDER BY TotalGanancia DESC
                LIMIT 20;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal gananciaUnidad = reader.GetDecimal("Ganancia_Unidad");
                                decimal costoUnidad = reader.GetDecimal("Costo_Unidad");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");
                                decimal totalGanancia = reader.GetDecimal("TotalGanancia");

                                grilla.Rows.Add(
                                    nombreProducto,
                                    gananciaUnidad.ToString("C"),
                                    costoUnidad.ToString("C"),
                                    totalVendido.ToString("C"),
                                    totalGanancia.ToString("C")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos más beneficiosos: " + ex.Message);
            }
        }

        

        public void MostrarTopProductosMasBeneficiosos(string mes, int anio, Chart chartTopBeneficios)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
                SELECT 
                    a.ART_DESC_VTA AS NombreProducto,
                    SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido,
                    SUM(c.CANTIDAD * a.GANANCIA) AS TotalGanancia
                FROM EV_CONT_HIST_LOCAL c
                INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                GROUP BY c.COD_INTERNO
                ORDER BY TotalGanancia DESC
                LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartTopBeneficios.Series.Clear();
                            chartTopBeneficios.Titles.Clear();
                            chartTopBeneficios.Legends.Clear();

                            chartTopBeneficios.Titles.Add("Top 5 Productos Más Beneficiosos");

                            var legend = chartTopBeneficios.Legends.Add("Beneficios");
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Regular); // Fuente más pequeña
                            legend.Title = ""; // Sin título en la leyenda

                            var series = chartTopBeneficios.Series.Add("Ganancia Total");
                            series.ChartType = SeriesChartType.Column;
                            series.IsValueShownAsLabel = false; // Sin texto en las barras

                            int colorIndex = 0;
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple
                            };

                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");
                                decimal totalGanancia = reader.GetDecimal("TotalGanancia");
                                var pointIndex = series.Points.AddY(totalGanancia);

                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = $"{nombreProducto} - Ganancia: {totalGanancia:C}"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de productos más beneficiosos: " + ex.Message);
            }
        }


        public void CargarProductosMasCostosos(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Producto",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Costo Unidad",
                ReadOnly = true,
                Width = 80
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ganancia Unidad",
                ReadOnly = true,
                Width = 80
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Vendido",
                ReadOnly = true,
                Width = 90
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Costo",
                ReadOnly = true,
                Width = 90
            });

            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
                SELECT 
                    a.ART_DESC_VTA AS NombreProducto,
                    a.COSTO AS Costo_Unidad,
                    a.GANANCIA AS Ganancia_Unidad,
                    SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido,
                    SUM(c.CANTIDAD * a.COSTO) AS TotalCosto
                FROM EV_CONT_HIST_LOCAL c
                INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                GROUP BY c.COD_INTERNO, a.COSTO, a.GANANCIA
                ORDER BY TotalCosto DESC
                LIMIT 20;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal costoUnidad = reader.GetDecimal("Costo_Unidad");
                                decimal gananciaUnidad = reader.GetDecimal("Ganancia_Unidad");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");
                                decimal totalCosto = reader.GetDecimal("TotalCosto");

                                grilla.Rows.Add(
                                    nombreProducto,
                                    costoUnidad.ToString("C"),
                                    gananciaUnidad.ToString("C"),
                                    totalVendido.ToString("C"),
                                    totalCosto.ToString("C")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos más costosos: " + ex.Message);
            }
        }

        public void MostrarTopProductosMasCostosos(string mes, int anio, Chart chartTopCostos)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
                SELECT 
                    a.ART_DESC_VTA AS NombreProducto,
                    SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido,
                    SUM(c.CANTIDAD * a.COSTO) AS TotalCosto
                FROM EV_CONT_HIST_LOCAL c
                INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                GROUP BY c.COD_INTERNO
                ORDER BY TotalCosto DESC
                LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartTopCostos.Series.Clear();
                            chartTopCostos.Titles.Clear();
                            chartTopCostos.Legends.Clear();

                            chartTopCostos.Titles.Add("Top 5 Productos Más Costosos");

                            var legend = chartTopCostos.Legends.Add("Costos");
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Regular); // Fuente más pequeña
                            legend.Title = ""; // Sin título en la leyenda

                            var series = chartTopCostos.Series.Add("Costo Total");
                            series.ChartType = SeriesChartType.Column;
                            series.IsValueShownAsLabel = false; // Sin texto en las barras

                            int colorIndex = 0;
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple
                            };

                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");
                                decimal totalCosto = reader.GetDecimal("TotalCosto");
                                var pointIndex = series.Points.AddY(totalCosto);

                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = $"{nombreProducto}  - Costo: {totalCosto:C}"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de productos más costosos: " + ex.Message);
            }
        }

        public void CargarProductosMasVendidosPorHorario(DataGridView grilla, string mes, int anio, string horario)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Producto",
                ReadOnly = true,
                Width = 140
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Unidad",
                ReadOnly = true,
                Width = 80
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad Vendida",
                ReadOnly = true,
                Width = 90
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Vendido",
                ReadOnly = true,
                Width = 90
            });

            int NroMes = ObtenerNumeroMes(mes);

            string query = @"SELECT 
                        a.ART_DESC_VTA AS NombreProducto,
                        a.PRECIO AS Precio_Unidad,
                        SUM(c.CANTIDAD) AS CantidadVendida,
                        SUM(c.TOTAL) AS TotalVendido
                    FROM EV_CONT_HIST_LOCAL c
                    INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                    WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                      AND TIME(c.HORAS_REG) BETWEEN @horaInicio AND @horaFin
                    GROUP BY c.COD_INTERNO, a.PRECIO
                    ORDER BY CantidadVendida DESC
                    LIMIT 20;";

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        if (horario == "Mañana")
                        {
                            cmd.Parameters.AddWithValue("@horaInicio", "08:00:00");
                            cmd.Parameters.AddWithValue("@horaFin", "13:00:00");
                        }
                        else if (horario == "Tarde")
                        {
                            cmd.Parameters.AddWithValue("@horaInicio", "14:00:00");
                            cmd.Parameters.AddWithValue("@horaFin", "19:00:00");
                        }
                        

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal precioUnidad = reader.GetDecimal("Precio_Unidad");
                                int cantidadVendida = reader.GetInt32("CantidadVendida");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");

                                grilla.Rows.Add(
                                    nombreProducto,
                                    precioUnidad.ToString("C"),
                                    cantidadVendida,
                                    totalVendido.ToString("C")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos más vendidos en horario {horario}: {ex.Message}");
            }
        }
        public void CargarProductosMasVendidosNoche(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre Producto",
                ReadOnly = true,
                Width = 200
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Unidad",
                ReadOnly = true,
                Width = 90
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad Vendida",
                ReadOnly = true,
                Width = 70
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Vendido",
                ReadOnly = true,
                Width = 120
            });

            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
            SELECT 
                a.ART_DESC_VTA AS NombreProducto,
                a.PRECIO AS PrecioUnidad,
                SUM(c.CANTIDAD) AS CantidadVendida,
                SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido
            FROM EV_CONT_HIST_LOCAL c
            INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
            WHERE MONTH(c.FECHA_TICKET) = @mes 
              AND YEAR(c.FECHA_TICKET) = @anio
              AND (
                  (TIME(c.HORAS_REG) BETWEEN '20:00:00' AND '23:59:59')
                  OR (TIME(c.HORAS_REG) BETWEEN '00:00:00' AND '03:00:00')
              )
            GROUP BY c.COD_INTERNO, a.PRECIO
            ORDER BY CantidadVendida DESC
            LIMIT 20;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                decimal precioUnidad = reader.GetDecimal("PrecioUnidad");
                                int cantidadVendida = reader.GetInt32("CantidadVendida");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");

                                grilla.Rows.Add(
                                    nombreProducto,
                                    precioUnidad.ToString("C"),
                                    cantidadVendida.ToString(),
                                    totalVendido.ToString("C")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos más vendidos en horario noche: " + ex.Message);
            }
        }


        public void MostrarTopProductosMasVendidosPorHorario(string mes, int anio, Chart chartTopProductos, string horario)
        {
            int NroMes = ObtenerNumeroMes(mes);

            string query = @"SELECT 
                        a.ART_DESC_VTA AS NombreProducto,
                        SUM(c.CANTIDAD) AS CantidadVendida,
                        SUM(c.TOTAL) AS TotalVendido
                    FROM EV_CONT_HIST_LOCAL c
                    INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
                    WHERE MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
                      AND TIME(c.HORAS_REG) BETWEEN @horaInicio AND @horaFin
                    GROUP BY c.COD_INTERNO
                    ORDER BY CantidadVendida DESC
                    LIMIT 5;";

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        if (horario == "Mañana")
                        {
                            cmd.Parameters.AddWithValue("@horaInicio", "08:00:00");
                            cmd.Parameters.AddWithValue("@horaFin", "13:00:00");
                        }
                        else if (horario == "Tarde")
                        {
                            cmd.Parameters.AddWithValue("@horaInicio", "14:00:00");
                            cmd.Parameters.AddWithValue("@horaFin", "19:00:00");
                        }
                        

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartTopProductos.Series.Clear();
                            chartTopProductos.Titles.Clear();
                            chartTopProductos.Legends.Clear();

                            chartTopProductos.Titles.Add($"Top 5 Productos Más Vendidos - {horario}");

                            var legend = chartTopProductos.Legends.Add("Productos");
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);

                            var series = chartTopProductos.Series.Add("Cantidad Vendida");
                            series.ChartType = SeriesChartType.Column;
                            series.IsValueShownAsLabel = false;

                            int colorIndex = 0;
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple
                            };

                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                int cantidadVendida = reader.GetInt32("CantidadVendida");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");

                                var pointIndex = series.Points.AddY(cantidadVendida);
                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = $"{nombreProducto} - Total: {totalVendido:C}"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico para horario {horario}: {ex.Message}");
            }
        }

        public void MostrarTopProductosMasVendidosNoche(string mes, int anio, Chart chartTopNoche)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    string query = @"
            SELECT 
                a.ART_DESC_VTA AS NombreProducto,
                SUM(c.CANTIDAD) AS CantidadVendida,
                SUM(c.CANTIDAD * a.PRECIO) AS TotalVendido
            FROM EV_CONT_HIST_LOCAL c
            INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
            WHERE MONTH(c.FECHA_TICKET) = @mes 
              AND YEAR(c.FECHA_TICKET) = @anio
              AND (
                  (TIME(c.HORAS_REG) BETWEEN '20:00:00' AND '23:59:59')
                  OR (TIME(c.HORAS_REG) BETWEEN '00:00:00' AND '03:00:00')
              )
            GROUP BY c.COD_INTERNO
            ORDER BY CantidadVendida DESC
            LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@mes", NroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartTopNoche.Series.Clear();
                            chartTopNoche.Titles.Clear();
                            chartTopNoche.Legends.Clear();

                            chartTopNoche.Titles.Add("Top 5 Productos Más Vendidos - Noche");

                            var legend = chartTopNoche.Legends.Add("Productos");
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
                            legend.Title = "";

                            var series = chartTopNoche.Series.Add("Cantidad Vendida");
                            series.ChartType = SeriesChartType.Column;
                            series.IsValueShownAsLabel = false;

                            int colorIndex = 0;
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple
                            };

                            while (reader.Read())
                            {
                                string nombreProducto = reader.GetString("NombreProducto");
                                int cantidadVendida = reader.GetInt32("CantidadVendida");
                                decimal totalVendido = reader.GetDecimal("TotalVendido");

                                var pointIndex = series.Points.AddY(cantidadVendida);

                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = $"{nombreProducto} - Total: {totalVendido:C}"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de productos más vendidos en horario noche: " + ex.Message);
            }
        }


        public void BuscarProductosPorNombre(TextBox txtBusqueda, ListBox lstResultados)
        {
            lstResultados.Items.Clear(); // Limpiar la lista de resultados

            string busqueda = txtBusqueda.Text.Trim(); // Obtener y limpiar el texto ingresado

            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Por favor, ingrese un nombre o parte del nombre del producto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                    // Consulta SQL para buscar productos
                    string query = @"
            SELECT ART_DESC_VTA 
            FROM ARTICULO_LOCAL
            WHERE ART_DESC_VTA LIKE @busqueda
            ORDER BY ART_DESC_VTA ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@busqueda", $"%{busqueda}%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string nombreProducto = reader.GetString("ART_DESC_VTA");
                                    lstResultados.Items.Add(nombreProducto); // Agregar resultados al ListBox
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron productos que coincidan con la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public bool ObtenerDatosProducto(string producto, string mes, int anio, Label lblNombre, Label lblPrecio, Label lblCosto, Label lblGanancia, Label lblTotalVentas, Label lblCantidadVendida)
        {
            int nroMes = ObtenerNumeroMes(mes);
            string query = @"
    SELECT 
        a.ART_DESC_VTA AS NombreProducto,
        a.PRECIO AS PrecioProducto,
        a.COSTO AS CostoProducto,
        a.GANANCIA AS GananciaProducto,
        SUM(c.CANTIDAD) AS CantidadVendida,
        SUM(c.CANTIDAD * a.PRECIO) AS TotalVentas
    FROM EV_CONT_HIST_LOCAL c
    INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
    WHERE a.ART_DESC_VTA = @producto
        AND MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
    GROUP BY a.ART_DESC_VTA, a.PRECIO, a.COSTO, a.GANANCIA;";

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@producto", producto);
                        cmd.Parameters.AddWithValue("@mes", nroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNombre.Text = reader.GetString("NombreProducto");
                                lblPrecio.Text = reader.GetDecimal("PrecioProducto").ToString("C");
                                lblCosto.Text = reader.GetDecimal("CostoProducto").ToString("C");
                                lblGanancia.Text = reader.GetDecimal("GananciaProducto").ToString("C");
                                lblTotalVentas.Text = reader.GetDecimal("TotalVentas").ToString("C");
                                lblCantidadVendida.Text = reader.GetInt32("CantidadVendida").ToString();
                                return true; // Datos encontrados
                            }
                            else
                            {
                                return false; // No se encontraron datos
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del producto: {ex.Message}");
                return false; // Error al intentar obtener datos
            }
        }



        public void MostrarGraficoHorarios(string producto, string mes, int anio, Chart chartHorarios)
        {
            int nroMes = ObtenerNumeroMes(mes);
            string query = @"
    SELECT 
        CASE 
            WHEN TIME(HORAS_REG) BETWEEN '08:00:00' AND '12:59:59' THEN '08-12'
            WHEN TIME(HORAS_REG) BETWEEN '13:00:00' AND '15:59:59' THEN '13-16'
            WHEN TIME(HORAS_REG) BETWEEN '16:00:00' AND '19:59:59' THEN '16-20'
            WHEN TIME(HORAS_REG) BETWEEN '20:00:00' AND '23:59:59' THEN '20-24'
            WHEN TIME(HORAS_REG) BETWEEN '00:00:00' AND '03:59:59' THEN '00-03'
            ELSE 'Otras Horas'
        END AS RangoHorario,
        SUM(c.CANTIDAD) AS CantidadVendida
    FROM EV_CONT_HIST_LOCAL c
    INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
    WHERE a.ART_DESC_VTA = @producto
      AND MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
    GROUP BY RangoHorario
    ORDER BY FIELD(RangoHorario, '08-12', '13-16', '16-20', '20-24', '00-03');";

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@producto", producto);
                        cmd.Parameters.AddWithValue("@mes", nroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartHorarios.Series.Clear();
                            chartHorarios.Titles.Clear();
                            chartHorarios.Legends.Clear();

                            chartHorarios.Titles.Add("Participación según Horarios");

                            // Configuración de leyenda
                            var legend = chartHorarios.Legends.Add("Horarios");
                            legend.Title = "Horarios";
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;

                            var series = chartHorarios.Series.Add("Horarios");
                            series.ChartType = SeriesChartType.Pie;
                            series.IsValueShownAsLabel = false;

                            // Variables para calcular porcentajes
                            int totalVendida = 0;
                            List<(string Rango, int Cantidad)> horarios = new List<(string, int)>();

                            // Leer datos
                            while (reader.Read())
                            {
                                string rango = reader.GetString("RangoHorario");
                                int cantidad = reader.GetInt32("CantidadVendida");
                                horarios.Add((rango, cantidad));
                                totalVendida += cantidad;
                            }

                            // Añadir datos al gráfico
                            foreach (var horario in horarios)
                            {
                                string rango = horario.Rango;
                                int cantidad = horario.Cantidad;
                                double porcentaje = (double)cantidad / totalVendida * 100;

                                var pointIndex = series.Points.AddY(cantidad);
                                series.Points[pointIndex].Label = $"{porcentaje:F2}%";
                                series.Points[pointIndex].LegendText = $"{rango}: {cantidad} ({porcentaje:F2}%)";
                            }

                            // Mover "00-03" al final de la leyenda
                            var rango00_03 = series.Points.FirstOrDefault(p => p.LegendText.StartsWith("00-03"));
                            if (rango00_03 != null)
                            {
                                series.Points.Remove(rango00_03);
                                series.Points.Add(rango00_03);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de horarios: {ex.Message}");
            }
        }



        public void MostrarGraficoDiasSemana(string producto, string mes, int anio, Chart chartDiasSemana)
        {
            int nroMes = ObtenerNumeroMes(mes);
            string query = @"
    SELECT 
        CASE DAYOFWEEK(FECHA_TICKET)
            WHEN 1 THEN 'Domingo'
            WHEN 2 THEN 'Lunes'
            WHEN 3 THEN 'Martes'
            WHEN 4 THEN 'Miércoles'
            WHEN 5 THEN 'Jueves'
            WHEN 6 THEN 'Viernes'
            WHEN 7 THEN 'Sábado'
        END AS DiaSemana,
        SUM(c.CANTIDAD) AS CantidadVendida
    FROM EV_CONT_HIST_LOCAL c
    INNER JOIN ARTICULO_LOCAL a ON c.COD_INTERNO = a.COD_INTERNO
    WHERE a.ART_DESC_VTA = @producto
      AND MONTH(c.FECHA_TICKET) = @mes AND YEAR(c.FECHA_TICKET) = @anio
    GROUP BY DiaSemana
    ORDER BY FIELD(DiaSemana, 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado', 'Domingo');";

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connLocal))
                    {
                        cmd.Parameters.AddWithValue("@producto", producto);
                        cmd.Parameters.AddWithValue("@mes", nroMes);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            chartDiasSemana.Series.Clear();
                            chartDiasSemana.Titles.Clear();
                            chartDiasSemana.Legends.Clear();

                            chartDiasSemana.Titles.Add("Participación según Día de la Semana");
                            var legend = chartDiasSemana.Legends.Add("Días");
                            legend.Docking = Docking.Right;
                            legend.Alignment = StringAlignment.Center;
                            legend.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);

                            var series = chartDiasSemana.Series.Add("Días de la Semana");
                            series.ChartType = SeriesChartType.Column;

                            int colorIndex = 0;
                            var colores = new System.Drawing.Color[]
                            {
                        System.Drawing.Color.SkyBlue,
                        System.Drawing.Color.LightCoral,
                        System.Drawing.Color.MediumSeaGreen,
                        System.Drawing.Color.Goldenrod,
                        System.Drawing.Color.MediumPurple,
                        System.Drawing.Color.DarkOrange,
                        System.Drawing.Color.Teal
                            };

                            while (reader.Read())
                            {
                                string dia = reader.GetString("DiaSemana");
                                int cantidad = reader.GetInt32("CantidadVendida");
                                var pointIndex = series.Points.AddXY(dia, cantidad);

                                // Asignar colores a cada barra
                                series.Points[pointIndex].Color = colores[colorIndex % colores.Length];
                                colorIndex++;

                                // Configurar leyenda
                                legend.CustomItems.Add(new LegendItem
                                {
                                    Color = series.Points[pointIndex].Color,
                                    Name = $"{dia} - {cantidad} unidades"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de días de la semana: {ex.Message}");
            }
        }









        //-----------------------------------------------------                       MODULO EMPLEADOS      -------------------------------------------------------------------


        public void MigrarControlHoras(string mes, int anio)
        {
            int NroMes = ObtenerNumeroMes(mes);

            try
            {
                using (MySqlConnection connLocal = new MySqlConnection(cadenaConexionLocal))
                {
                    connLocal.Open();

                //    // Verificar si ya existen datos para el mes y año seleccionados en la base local
                //    string verificarDatos = @"
                //SELECT COUNT(*) 
                //FROM controlhs_local 
                //WHERE MONTH(STR_TO_DATE(fecha, '%d/%m/%Y')) = @mes AND YEAR(STR_TO_DATE(fecha, '%d/%m/%Y')) = @anio;";

                //    using (MySqlCommand cmdVerificar = new MySqlCommand(verificarDatos, connLocal))
                //    {
                //        cmdVerificar.Parameters.AddWithValue("@mes", mes);
                //        cmdVerificar.Parameters.AddWithValue("@anio", anio);

                //        int cantidadRegistros = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                //        if (cantidadRegistros > 0)
                //        {
                //            MessageBox.Show("Los datos de control de horas para este mes y año ya están disponibles en la base local.");
                //            return;
                //        }
                //    }

                    // Crear tabla local si no existe
                    string crearTabla = @"
                CREATE TABLE IF NOT EXISTS controlhs_local (
                    fecha VARCHAR(10),
                    nombre_empleado VARCHAR(255),
                    hora_ingreso TIME,
                    hora_egreso TIME,
                    acumulado INT,
                    mes VARCHAR(20),
                    PRIMARY KEY (fecha, nombre_empleado)
                );";

                    using (MySqlCommand cmdCrear = new MySqlCommand(crearTabla, connLocal))
                    {
                        cmdCrear.ExecuteNonQuery();
                    }

                    // Conexión a la base remota (cadenaConexionKiosco)
                    using (MySqlConnection connKiosco = new MySqlConnection(cadenaConexionKiosco))
                    {
                        connKiosco.Open();

                        // Consulta para obtener datos desde `controlhs_2024`
                        string queryControlHoras = @"
                    SELECT 
                        fecha, 
                        nombre_empleado, 
                        hora_ingreso, 
                        hora_egreso, 
                        acumulado, 
                        mes
                    FROM controlhs_2024
                    WHERE MONTH(STR_TO_DATE(fecha, '%d/%m/%Y')) = @mes AND YEAR(STR_TO_DATE(fecha, '%d/%m/%Y')) = @anio;";

                        using (MySqlCommand cmdKiosco = new MySqlCommand(queryControlHoras, connKiosco))
                        {
                            cmdKiosco.Parameters.AddWithValue("@mes", NroMes);
                            cmdKiosco.Parameters.AddWithValue("@anio", anio);

                            using (MySqlDataReader reader = cmdKiosco.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string fecha = reader.GetString("fecha");
                                    string nombreEmpleado = reader.GetString("nombre_empleado");
                                    TimeSpan horaIngreso = reader.GetTimeSpan("hora_ingreso");
                                    TimeSpan horaEgreso = reader.GetTimeSpan("hora_egreso");
                                    int acumulado = reader.GetInt32("acumulado");
                                    string mesRegistro = reader.GetString("mes");

                                    string insertarDatos = @"
                                INSERT INTO controlhs_local (fecha, nombre_empleado, hora_ingreso, hora_egreso, acumulado, mes)
                                VALUES (@fecha, @nombre_empleado, @hora_ingreso, @hora_egreso, @acumulado, @mes)
                                ON DUPLICATE KEY UPDATE 
                                    hora_ingreso = VALUES(hora_ingreso),
                                    hora_egreso = VALUES(hora_egreso),
                                    acumulado = VALUES(acumulado),
                                    mes = VALUES(mes);";

                                    using (MySqlCommand cmdLocal = new MySqlCommand(insertarDatos, connLocal))
                                    {
                                        cmdLocal.Parameters.AddWithValue("@fecha", fecha);
                                        cmdLocal.Parameters.AddWithValue("@nombre_empleado", nombreEmpleado);
                                        cmdLocal.Parameters.AddWithValue("@hora_ingreso", horaIngreso);
                                        cmdLocal.Parameters.AddWithValue("@hora_egreso", horaEgreso);
                                        cmdLocal.Parameters.AddWithValue("@acumulado", acumulado);
                                        cmdLocal.Parameters.AddWithValue("@mes", mesRegistro);

                                        cmdLocal.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Migración de datos completada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al migrar datos: " + ex.Message);
            }
        }


        public void CargarEstadisticasEmpleados(DataGridView grilla, string mes, int anio)
        {
            grilla.Columns.Clear();
            grilla.Rows.Clear();

            // Configurar columnas
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Empleado",
                ReadOnly = true,
                Width = 200
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                ReadOnly = true,
                Width = 100
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ventas Día ($)",
                ReadOnly = true,
                Width = 150
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Sueldo Día ($)",
                ReadOnly = true,
                Width = 150
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Turno",
                ReadOnly = true,
                Width = 100
            });

            int NroMes = ObtenerNumeroMes(mes);

            // Diccionario para almacenar las ventas
            var ventasPorFechaEmpleado = new Dictionary<Tuple<string, DateTime, TimeSpan>, decimal>();

            try
            {
                // Conexión a la base de datos `gootpv` para obtener las ventas
                using (MySqlConnection connGootpv = new MySqlConnection(cadenaConexionRemota))
                {
                    connGootpv.Open();

                    string queryVentas = @"
                SELECT 
                    FECHA_TICKET AS FECHA,
                    TIME(HORAS_REG) AS HORA,
                    TOTAL AS VENTAS_DIA
                FROM ev_cont_hist
                WHERE MONTH(FECHA_TICKET) = @mes AND YEAR(FECHA_TICKET) = @anio;";

                    using (MySqlCommand cmdVentas = new MySqlCommand(queryVentas, connGootpv))
                    {
                        cmdVentas.Parameters.AddWithValue("@mes", NroMes);
                        cmdVentas.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader readerVentas = cmdVentas.ExecuteReader())
                        {
                            while (readerVentas.Read())
                            {
                                DateTime fecha = readerVentas.GetDateTime("FECHA");
                                TimeSpan hora = readerVentas.GetTimeSpan("HORA");
                                decimal ventasDia = readerVentas.GetDecimal("VENTAS_DIA");

                                // Clave: Empleado, Fecha y Hora
                                var clave = Tuple.Create("", fecha, hora);
                                if (ventasPorFechaEmpleado.ContainsKey(clave))
                                {
                                    ventasPorFechaEmpleado[clave] += ventasDia;
                                }
                                else
                                {
                                    ventasPorFechaEmpleado[clave] = ventasDia;
                                }
                            }
                        }
                    }
                }

                // Conexión a la base de datos `planificador` para obtener los datos de control de horas
                using (MySqlConnection connPlanificador = new MySqlConnection(cadenaConexionKiosco))
                {
                    connPlanificador.Open();

                    string queryControl = @"
                SELECT 
                    nombre_empleado,
                    STR_TO_DATE(fecha, '%d/%m/%Y') AS FECHA,
                    hora_ingreso,
                    hora_egreso,
                    acumulado
                FROM controlhs_2024
                WHERE MONTH(STR_TO_DATE(fecha, '%d/%m/%Y')) = @mes 
                  AND YEAR(STR_TO_DATE(fecha, '%d/%m/%Y')) = @anio;";

                    using (MySqlCommand cmdControl = new MySqlCommand(queryControl, connPlanificador))
                    {
                        cmdControl.Parameters.AddWithValue("@mes", NroMes);
                        cmdControl.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader readerControl = cmdControl.ExecuteReader())
                        {
                            while (readerControl.Read())
                            {
                                string empleado = readerControl.GetString("nombre_empleado");
                                DateTime fecha = readerControl.GetDateTime("FECHA");
                                TimeSpan horaIngreso = readerControl.GetTimeSpan("hora_ingreso");
                                TimeSpan horaEgreso = readerControl.GetTimeSpan("hora_egreso");
                                decimal sueldoDia = readerControl.GetDecimal("acumulado");

                                // Determinar turno
                                string turno = "NOCHE";
                                if (horaIngreso.Hours >= 8 && horaIngreso.Hours < 14)
                                {
                                    turno = "MAÑANA";
                                }
                                else if (horaIngreso.Hours >= 14 && horaIngreso.Hours < 20)
                                {
                                    turno = "TARDE";
                                }

                                // Calcular ventas en el rango horario
                                decimal ventasDia = ventasPorFechaEmpleado
                                    .Where(kv => kv.Key.Item2 == fecha &&
                                                 kv.Key.Item3 >= horaIngreso &&
                                                 kv.Key.Item3 <= horaEgreso)
                                    .Sum(kv => kv.Value);

                                // Agregar datos a la grilla
                                grilla.Rows.Add(empleado, fecha.ToString("dd/MM/yyyy"), ventasDia.ToString("C"), sueldoDia.ToString("C"), turno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas: " + ex.Message);
            }
        }












        























    }
}
