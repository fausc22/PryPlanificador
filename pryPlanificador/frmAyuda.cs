﻿using pryPlanificador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador
{
    public partial class frmAyuda : Form
    {
        public frmAyuda()
        {
            InitializeComponent();
        }

        clsConexion objC = new clsConexion();
        private void frmAyuda_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objC.AcomodarMinutos();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objC.AcomodarAcumulado();
        }
    }
}
