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

namespace PalcoNet.Generar_Publicacion
{
    public partial class Form1 : Form
    {
        int i = 1;
        int pos;
        string empresa;
        int grado;
        int indice = 0;
        int posicionEspectaculo;

        public string error = "";

        public bool validar() 
        {
            bool a;
            a = txtDescripcion.Text != "";
            a = a && txtDireccion.Text != "";
            a = a && dataGridView1.RowCount > 0;
            return a;
        }
        
        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.MinDate = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddHours(2) ;

            string cmd = string.Format("select empresa from LOS_SIMULADORES.Usuario where idUsuario = '{0}'", Login.Codigo);
            empresa = Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString();

            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddDays(1);

            DataSet ds = Utilidades.Ejecutar("select descripcion from LOS_SIMULADORES.grado where estado = 1");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbGrado.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            cbGrado.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            cbAsiento.SelectedIndex = 0;
            cbFila.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool a = false;

            string fila, asiento, precio, tipo;
            fila = cbFila.Text;
            asiento = cbAsiento.Text;
            precio = nudPrecio.Value.ToString();
            tipo = cbTipo.Text;

            for(i=0; i < dataGridView1.RowCount; i++)
            {
                a = a || (dataGridView1.Rows[i].Cells[0].Value.ToString() == fila && dataGridView1.Rows[i].Cells[1].Value.ToString() == asiento);
            }

            if (!a)
            {
                dataGridView1.Rows.Add(fila, asiento, precio, tipo);
                i = i++;
            }
            else { MessageBox.Show("Ubicacion repetida"); }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = dataGridView1.CurrentRow.Index;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try { dataGridView1.Rows.RemoveAt(pos); }
            catch { }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount ; i++)
            {
                string cmd = string.Format("select peso from LOS_SIMULADORES.Grado where Descripcion = '{0}'", dataGridView2.Rows[i].Cells["Grado_"].Value);
                grado = Int32.Parse(Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString());

                cmd = string.Format("LOS_SIMULADORES.actualizarEspectaculo '{0}', '{1}' , '{2}' , '{3}', '{4}', '{5}', '{6}', '{7}'", -1, dataGridView2.Rows[i].Cells["Descripcion"].Value, dataGridView2.Rows[i].Cells["Fecha_Vencimiento"].Value, empresa, dataGridView2.Rows[i].Cells["Estado"].Value, dataGridView2.Rows[i].Cells["Direccion"].Value, grado, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));
                Utilidades.Ejecutar(cmd);

                for (int j = 0; j < dataGridView3.RowCount ; j++) 
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == dataGridView3.Rows[j].Cells[0].Value.ToString()) 
                    {
                        cmd = string.Format("insert into LOS_SIMULADORES.Ubicacion values((select top 1 Cod from LOS_SIMULADORES.Espectaculo es join LOS_SIMULADORES.Empresa em on em.Cuit = es.Empresa where em.Cuit = '{4}' order by Cod desc), '{0}','{1}',0,'{2}','{3}')", dataGridView3.Rows[j].Cells["Fila2"].Value, dataGridView3.Rows[j].Cells["Asiento2"].Value, dataGridView3.Rows[j].Cells["Precio2"].Value, dataGridView3.Rows[j].Cells["Tipo2"].Value, empresa);
                        Utilidades.Ejecutar(cmd);
                    }
                }
            }

            MessageBox.Show("Publicada Correctamente");
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAñadirFecha_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                dataGridView2.Rows.Add(indice, txtDescripcion.Text, dateTimePicker1.Value, empresa, cbEstado.Text, txtDireccion.Text, cbGrado.Text);

                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    dataGridView3.Rows.Add(indice, dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value);
                }

                for (int i = 0; i < dataGridView3.Rows.Count ; i++)
                {
                    dataGridView3.Rows[i].Visible = false;
                }

                dateTimePicker1.MinDate = dateTimePicker1.Value.AddMinutes(30);

                indice += 1;
            }
            else { MessageBox.Show("No se permite texto vacio ni ubicaciones vacias"); }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                dataGridView2.Rows.Add(indice, txtDescripcion.Text, dateTimePicker1.Value, empresa, cbEstado.Text, txtDireccion.Text, cbGrado.Text);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add(indice, dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value);
                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    dataGridView3.Rows[i].Visible = false;
                }

                indice += 1;

                dateTimePicker1.MinDate = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddHours(2);

                txtDescripcion.Text = "";
                txtDireccion.Text = "";
                cbEstado.SelectedIndex = 0;
                cbGrado.SelectedIndex = 0;
                dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddDays(1);
                dataGridView1.Rows.Clear();

                dataGridView2.Rows[0].Selected = true;
            }
            else { MessageBox.Show("No se permite texto vacio ni ubicaciones vacias"); }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicionEspectaculo = e.RowIndex;

            for (int i = 0; i < dataGridView3.Rows.Count ; i++)
            {
                dataGridView3.Rows[i].Visible = false;
            }
            
            for (int i = 0; i < dataGridView3.Rows.Count ; i++)
            {
                try
                {
                    if (dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() == dataGridView3.Rows[i].Cells[0].Value.ToString()) { dataGridView3.Rows[i].Visible = true; }
                }
                catch { }
            }
        }

        private void btnQuitarEsp_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dataGridView3.Rows.Count - 1; i > -1; i--)
                {
                    if (dataGridView2.Rows[posicionEspectaculo].Cells[0].Value.ToString() == dataGridView3.Rows[i].Cells[0].Value.ToString()) { dataGridView3.Rows.RemoveAt(i); }

                }
                dataGridView2.Rows.RemoveAt(posicionEspectaculo);
            }
            catch { }
        }




    }
}
