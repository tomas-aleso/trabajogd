using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Historial_Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            llenar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void llenar()
        {
            string CMD = string.Format("select Codigo, Fecha, Medio, Espectaculo, Fila, Asiento from LOS_SIMULADORES.compra where cliente = (select cliente from LOS_SIMULADORES.Usuario where idUsuario = '{0}')", Login.Codigo);
            DataSet ds = Utilidades.Ejecutar(CMD);

            txtTotal.Text = ((ds.Tables[0].Rows.Count / 10) + 1).ToString();

            CMD = string.Format("select Codigo, Fecha, Medio, Espectaculo, Fila, Asiento from LOS_SIMULADORES.compra where cliente = (select cliente from LOS_SIMULADORES.Usuario where idUsuario = '{1}') order by Fecha desc offset {0} rows fetch next 10 rows only", (Int32.Parse(txtActual.Text) - 1) * 10, Login.Codigo);
            ds = Utilidades.Ejecutar(CMD);

            dataGridView1.DataSource = ds.Tables[0];


            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            txtActual.Text = "1";
            llenar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (txtActual.Text != "1") { txtActual.Text = (Int32.Parse(txtActual.Text) - 1).ToString(); llenar(); }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            txtActual.Text = txtTotal.Text;
            llenar();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtActual.Text) < Int32.Parse(txtTotal.Text))
            {
                txtActual.Text = (Int32.Parse(txtActual.Text) + 1).ToString();
                llenar();
            }
        }
    }
}
