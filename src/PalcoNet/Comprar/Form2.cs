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
    public partial class Form2 : Form
    {
        int pos;
        int posCarrito;
        string espectaculo;

        public Form2()
        {
            InitializeComponent();
        }

        public void llenar(string esp)
        {
            espectaculo = esp;
            string cmd = string.Format("select Fila, Asiento, Precio, Tipo from LOS_SIMULADORES.ubicacion u where not exists (select 1 from LOS_SIMULADORES.Compra c where c.Fila = u.Fila and c.Asiento = u.Asiento and c.Espectaculo = u.Espectaculo ) and Espectaculo = '{0}'", esp);

            DataSet ds = Utilidades.Ejecutar(cmd);

            dataGridView1.DataSource = ds.Tables[0];

            for (int i = 0; i < dataGridView1.Rows.Count ; i++) 
            {
                for (int j = 0; j < dataGridView2.Rows.Count ; j++)
                {
                    if (dataGridView1.Rows[i].Cells["Fila"].Value.ToString() == dataGridView2.Rows[j].Cells["Fila"].Value.ToString() && dataGridView1.Rows[i].Cells["Asiento"].Value.ToString() == dataGridView2.Rows[j].Cells["Asiento"].Value.ToString()) { dataGridView1.Rows.RemoveAt(i); }
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[pos].Cells["Fila"].Value, dataGridView1.Rows[pos].Cells["Asiento"].Value, dataGridView1.Rows[pos].Cells["Precio"].Value, dataGridView1.Rows[pos].Cells["Tipo"].Value);
                llenar(espectaculo);
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = e.RowIndex;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.RemoveAt(posCarrito);
                llenar(espectaculo);
            }
            catch { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posCarrito = e.RowIndex;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                string x;
                string cmd = string.Format("select isnull(tarjeta,0) from LOS_SIMULADORES.cliente c join LOS_SIMULADORES.usuario u on u.cliente = c.dni where u.idUsuario = '{0}'", Login.Codigo);
                x = Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString();
                if (x == "0") { new IngresarTarjeta().Show(); }
                else
                {
                    for (int i = 0; i < dataGridView2.Rows.Count ; i++)
                    {
                        try
                        {
                            if (float.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString()) < 0) { MessageBox.Show("No se permiten valores negativos"); }
                            else
                            {
                                cmd = string.Format("insert into LOS_SIMULADORES.Compra values('{5}', 1, (select Dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on c.Dni = u.Cliente where u.idUsuario = '{0}'), 'Electronico', '{1}','{2}', '{3}','{4}')", Login.Codigo, espectaculo, dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[2].Value.ToString(), DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));
                                Utilidades.Ejecutar(cmd);

                                cmd = string.Format("insert into LOS_SIMULADORES.Punto values((select Dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on c.Dni = u.Cliente where u.idUsuario = '{0}'), {1}*.1,'{2}')", Login.Codigo, dataGridView2.Rows[i].Cells[2].Value, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddMonths(6));
                                Utilidades.Ejecutar(cmd);
                            }
                        }
                        catch (Exception error) { MessageBox.Show("" + error); }
                    }
                    cmd = string.Format("LOS_SIMULADORES.comprobarUbicaciones '{0}'", espectaculo);
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Se ha realizado la compra");
                    this.Hide();
                }
            }
        }
    }
}
