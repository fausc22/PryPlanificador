﻿using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlanificador
{
    public partial class frmVacaciones : Form
    {
        public frmVacaciones()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        private void frmVacaciones_Load(object sender, EventArgs e)
        {
            objC.CargarGrillaEmpleado(dgvEmpleados);
            objC.CargarGrillaVacaciones(dgvCalendario);
            objC.CargarCmbEmpleadoVacaciones(cmbEmpleado);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevoFeriado_Click(object sender, EventArgs e)
        {
            gpEmpleado.Visible = true;
            btnSelec.Text = "CARGAR VACACIONES";
            btnNuevoFeriado.Enabled = false;
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            
            
            int id = Convert.ToInt32(lblId.Text);
            string empleado = cmbEmpleado.Text;
            string fechaS = txtSalida.Text;
            DateTime fecha = DateTime.ParseExact(fechaS, "d/M/yyyy", CultureInfo.InvariantCulture);
            int anio = fecha.Year;
            int mes = fecha.Month;
            string fechaR = txtRegreso.Text;
            int dias = Convert.ToInt32(txtCantDia.Text);
            

            if (btnSelec.Text == "CARGAR VACACIONES")
            {
                objC.NuevoVacaciones(empleado, dias, fechaS, fechaR, dias, mes, anio);
            }
            else
            {
                objC.ActualizarVacaciones(id, empleado, dias, fechaS, fechaR, dias, mes, anio);
            }


            objC.CargarGrillaEmpleado(dgvEmpleados);
            objC.CargarGrillaVacaciones(dgvCalendario);
            objC.CargarCmbEmpleadoVacaciones(cmbEmpleado);
            Limpiar();
        }

        private void Limpiar()
        {
            gpEmpleado.Visible = false;
            txtCantDia.Clear();
            txtRegreso.Clear();
            txtSalida.Clear();
            cmbEmpleado.SelectedIndex = -1;
            btnNuevoFeriado.Enabled = true;
        }

        private void dgvCalendario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnNuevoFeriado.Enabled = false;
            gpEmpleado.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCalendario.Rows[e.RowIndex];

                string id = selectedRow.Cells[0].Value.ToString();
                string empleado = selectedRow.Cells[1].Value.ToString();
                string dias = selectedRow.Cells[2].Value.ToString();
                string fechaS = selectedRow.Cells[3].Value.ToString();
                string fechaR = selectedRow.Cells[4].Value.ToString();

                lblId.Text = id;
                cmbEmpleado.Text = empleado;
                txtSalida.Text = fechaS;
                txtRegreso.Text = fechaR;
                txtCantDia.Text = dias;
                btnSelec.Text = "MODIFICAR VACACIONES";
                btnEliminar.Visible = true;



            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UTILICE EL BOTON VERDE PARA AGREGAR UN NUEVO PERIODO DE VACACIONES. PARA MODIFICAR UNO EXISTENTE DEBE HACER DOBLE CLICK SOBRE EL MISMO EN LA GRILLA");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);

            // Muestra el cuadro de diálogo con los botones "Sí" y "No"
            DialogResult resultado = MessageBox.Show("¿ESTÁS SEGURO DE QUE DESEAS ELIMINAR LAS VACAIONES?", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Si hace clic en "Sí", ejecuta los procedimientos siguientes
                objC.EliminarVacaciones(id);
                objC.CargarGrillaVacaciones(dgvCalendario);
                objC.CargarGrillaEmpleado(dgvEmpleados);
                btnEliminar.Visible = false;
                Limpiar();

            }
        }
    }
}
