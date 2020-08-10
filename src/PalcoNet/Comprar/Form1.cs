using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PalcoNet.Comprar
{
    public partial class Form1 : Form
    {
        int pos;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void llenar()
        {
            string cmd = string.Format("select Cod, Descripcion, Fecha_Venc from LOS_SIMULADORES.Espectaculo where Estado = 'Publicada' and Fecha_Venc > '{0}'", DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));
            DataSet ds = Utilidades.Ejecutar(cmd);

            txtTotal.Text = ((ds.Tables[0].Rows.Count / 10)+1).ToString();

            cmd = string.Format("select Cod, Descripcion, Fecha_Venc from LOS_SIMULADORES.Espectaculo where Estado = 'Publicada' and Fecha_Venc > '{1}' order by Grado desc offset {0} rows fetch next 10 rows only", (Int32.Parse(txtActual.Text)-1) * 10, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));
            ds = Utilidades.Ejecutar(cmd);

            dataGridView1.DataSource = ds.Tables[0];


        }

        public bool filtro = false;
        
        public void filtrar() 
        {
            string cmd = string.Format("select Cod, Descripcion, Fecha_Venc from LOS_SIMULADORES.Espectaculo where Estado = 'Publicada' and Descripcion like ('%" + txtDesc.Text + "%') and Fecha_Venc BETWEEN '{0}' and '{1}' ", fechaInicial.Value.ToString(), fechaFinal.Value.ToString());
            DataSet ds = Utilidades.Ejecutar(cmd);

            txtTotal.Text = ((ds.Tables[0].Rows.Count / 10)+1).ToString();

            cmd = string.Format("select Cod, Descripcion, Fecha_Venc from LOS_SIMULADORES.Espectaculo where Estado = 'Publicada' and Descripcion like ('%" + txtDesc.Text + "%') and Fecha_Venc BETWEEN '{0}' and '{1}' order by Grado desc,cod offset {2} rows fetch next 10 rows only", fechaInicial.Value.ToString(), fechaFinal.Value.ToString(), (Int32.Parse(txtActual.Text)-1) * 10);
            ds = Utilidades.Ejecutar(cmd);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenar();
            fechaInicial.Value = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]);
        }


        private void btnConfi_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 ubi = new Form2();
                ubi.llenar(dataGridView1.Rows[pos].Cells[0].Value.ToString());
                ubi.Show();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = e.RowIndex;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            txtActual.Text = "1";
            filtrar();
            filtro = true;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            txtActual.Text = "1";
            llenar();
            if (filtro) { filtrar(); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtActual.Text) < Int32.Parse(txtTotal.Text))
            {
                txtActual.Text = (Int32.Parse(txtActual.Text) + 1).ToString();
                llenar();
                if (filtro) { filtrar(); }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtActual.Text) > 1)
            {
                txtActual.Text = (Int32.Parse(txtActual.Text) - 1).ToString();
                llenar();
                if (filtro) { filtrar(); }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            txtActual.Text = txtTotal.Text;
            llenar();
            if (filtro) { filtrar(); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            filtro = false;
            txtActual.Text = "1";
            txtDesc.Text = "";
            fechaInicial.Value = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]);
            fechaFinal.Value = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddYears(1);
            llenar();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            llenar();
            if (filtro) { filtrar(); }
        }

    }
}
