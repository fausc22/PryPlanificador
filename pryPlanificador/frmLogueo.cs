﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlanificador
{
    public partial class frmLogueo : Form
    {
        public frmLogueo()
        {
            InitializeComponent();
        }

        clsEmpleado objE = new clsEmpleado();

        private void frmLogueo_Load(object sender, EventArgs e)
        {
            objE.CargarGrillaLogueo(dgvLogueo);
        }
    }
}
