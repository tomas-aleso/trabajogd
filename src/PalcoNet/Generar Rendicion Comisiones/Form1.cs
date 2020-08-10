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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void llenar()
        {
            string cmd = string.Format("select * from LOS_SIMULADORES.Compra c where not exists(select 1 from LOS_SIMULADORES.Item_factura i where c.Asiento = i.Asiento and c.Fila = i.Fila and c.Espectaculo = i.Espectaculo) and exists(select 1 from LOS_SIMULADORES.Espectaculo where Empresa = '{0}') order by Fecha", txtEmpresa.Text);
            DataSet ds = Utilidades.Ejecutar(cmd);

            dataGridView1.DataSource = ds.Tables[0];

            nudCant.Maximum = dataGridView1.Rows.Count ;

            txtTotal.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenar();
        }


        private void nudCant_ValueChanged(object sender, EventArgs e)
        {
            double sum = 0;

            for (int i = 0; i < nudCant.Value; i++)
            {

                string cmd = string.Format("select grado from LOS_SIMULADORES.Espectaculo e join LOS_SIMULADORES.Compra c on c.Espectaculo = e.Cod where c.Codigo = '{0}'", dataGridView1.Rows[i].Cells["Codigo"].Value.ToString());
                DataSet ds = Utilidades.Ejecutar(cmd);

                sum = sum + (double.Parse(dataGridView1.Rows[i].Cells["Precio"].Value.ToString()) * 0.001 * double.Parse(ds.Tables[0].Rows[0][0].ToString()));
            }

            txtTotal.Text = sum.ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (nudCant.Value > 0)
            {
                int id;

                string cmd = string.Format("insert into LOS_SIMULADORES.Factura values('{0}', 0, '{1}')  select @@IDENTITY AS '1'", DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]), txtEmpresa.Text);

                id = Int32.Parse(Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString());

                for (int i = 0; i < nudCant.Value; i++)
                {
                    cmd = string.Format("select grado from LOS_SIMULADORES.Espectaculo e join LOS_SIMULADORES.Compra c on c.Espectaculo = e.Cod where c.Codigo = '{0}'", dataGridView1.Rows[i].Cells["Codigo"].Value.ToString());
                    DataSet ds = Utilidades.Ejecutar(cmd);

                    cmd = string.Format("LOS_SIMULADORES.itemFactura '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'", id, dataGridView1.Rows[i].Cells["Precio"].Value.ToString().Replace(',', '.'), ds.Tables[0].Rows[0][0], dataGridView1.Rows[i].Cells["Cantidad"].Value, dataGridView1.Rows[i].Cells["Espectaculo"].Value, dataGridView1.Rows[i].Cells["Fila"].Value, dataGridView1.Rows[i].Cells["Asiento"].Value);
                    Utilidades.Ejecutar(cmd);

                }

                cmd = string.Format("update LOS_SIMULADORES.Factura set Total = (select sum(Precio) from LOS_SIMULADORES.Item_factura where Factura = '{0}') where Nro = '{0}'", id);
                Utilidades.Ejecutar(cmd);

                MessageBox.Show("Generada");
                llenar();
            }
            else { MessageBox.Show("Seleccione una cantidad > 0"); }
            
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            new Empresas().Show();
        }
    }
}
