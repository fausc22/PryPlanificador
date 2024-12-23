using pryPlanificador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.tool.xml.html.HTML;


namespace Planificador
{
    public partial class frmAuxRecibo : Form
    {
        private string categoria2;
        private int monto2;
        private string descripcion2;
        public frmAuxRecibo(string categoria, string monto, string descripcion)
        {

            InitializeComponent();
            this.categoria2 = categoria;
            this.monto2 = Convert.ToInt32(monto);
            this.descripcion2 = descripcion;
            txtCategoria.Text = categoria;
            txtMonto.Text = monto;
            txtDescripcion.Text = descripcion;

            

        }

        private void frmAuxRecibo_Load(object sender, EventArgs e)
        {
            clsConexion objC = new clsConexion();
            
            
        }

        
        public void btnSelec_Click(object sender, EventArgs e)
        {
            string categoria = txtCategoria.Text;
            int monto = Convert.ToInt32(txtMonto.Text.ToString());
            string descripcion = txtDescripcion.Text;
            clsConexion objC = new clsConexion();
            objC.ModificarPagoExtra(categoria, monto, descripcion, categoria2, monto2, descripcion2);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsConexion cls = new clsConexion();
            cls.EliminarPagoExtra(categoria2, monto2, descripcion2);
            this.Close();
        }
    }
}
