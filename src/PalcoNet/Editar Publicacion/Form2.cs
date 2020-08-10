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

namespace PalcoNet.Editar_Publicacion
{
    public partial class Form2 : Form
    {
        int i = 1;
        int pos;
        string empresa;
        string codigo;
        int grado;

        public bool comprobarFecha() 
        {
            string cmd = string.Format("select 1 from LOS_SIMULADORES.Espectaculo where Descripcion = '{0}' and Fecha_Venc = '{1}' and Estado = 'Publicada' ", txtDescripcion.Text, dateTimePicker1.Value);
            return Utilidades.Ejecutar(cmd).Tables[0].Rows.Count == 0 && dateTimePicker1.Value >= DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]);
        }

        public void llenar(string cod)
        {
            codigo = cod;

            string cmd = string.Format("select * from LOS_SIMULADORES.espectaculo where Cod = '{0}'", cod);
            DataSet ds = Utilidades.Ejecutar(cmd);

            txtDescripcion.Text = ds.Tables[0].Rows[0]["Descripcion"].ToString();
            txtDireccion.Text = ds.Tables[0].Rows[0]["Direccion"].ToString();
            dateTimePicker1.Value = DateTime.Parse(ds.Tables[0].Rows[0]["Fecha_Venc"].ToString());

            cmd = string.Format("select count(1) from LOS_SIMULADORES.ubicacion where espectaculo = '{0}'", cod);
            int x = Int32.Parse(Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString());

            cmd = string.Format("select * from LOS_SIMULADORES.ubicacion where Espectaculo = '{0}'", cod);
            ds = Utilidades.Ejecutar(cmd);

            for (int i = 0; i < x; i++)
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i]["Fila"].ToString(), ds.Tables[0].Rows[i]["Asiento"].ToString(), ds.Tables[0].Rows[i]["Precio"].ToString(), ds.Tables[0].Rows[i]["Tipo"].ToString());
            }

            ds = Utilidades.Ejecutar("select descripcion from LOS_SIMULADORES.grado where estado = 1");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbGrado.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            cbAsiento.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            cbFila.SelectedIndex = 0;
            cbGrado.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
            
        }
        
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool a = false;
            
            string fila, asiento, precio, tipo;
            fila = cbFila.Text;
            asiento = cbAsiento.Text;
            precio = nudPrecio.Value.ToString();
            tipo = cbTipo.Text;

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                a = a || (dataGridView1.Rows[i].Cells[0].Value.ToString() == fila && dataGridView1.Rows[i].Cells[1].Value.ToString() == asiento);
            }

            if (!a)
            {
                dataGridView1.Rows.Add(fila, asiento, precio, tipo);
                i = i++;
            }
            else { MessageBox.Show("Ubicacion existente"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = dataGridView1.CurrentRow.Index;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(pos);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (comprobarFecha())
            {
                if (txtDescripcion.Text != "" && txtDireccion.Text != "")
                {
                    string cmd = string.Format("select peso from LOS_SIMULADORES.Grado where descripcion = '{0}'", cbGrado.Text);
                    grado = Int32.Parse(Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString());

                    cmd = string.Format("delete from LOS_SIMULADORES.ubicacion where espectaculo = '{0}'", codigo);
                    Utilidades.Ejecutar(cmd);

                    try
                    {
                        cmd = string.Format("select empresa from LOS_SIMULADORES.Usuario where idUsuario = '{0}'", Login.Codigo);
                        empresa = Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString();

                        cmd = string.Format("LOS_SIMULADORES.actualizarEspectaculo '{0}', '{1}' , '{2}' , '{3}', '{4}', '{5}', '{6}', '{7}'", codigo, txtDescripcion.Text, dateTimePicker1.Value, empresa, cbEstado.Text, txtDireccion.Text, grado, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));
                        Utilidades.Ejecutar(cmd);

                        for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                        {
                            try
                            {
                                cmd = string.Format("insert into LOS_SIMULADORES.Ubicacion values((select top 1 Cod from LOS_SIMULADORES.Espectaculo es join LOS_SIMULADORES.Empresa em on em.Cuit = es.Empresa where em.Cuit = '{4}' and es.cod='{5}' order by Cod desc), '{0}','{1}',0,'{2}','{3}')", dataGridView1.Rows[i].Cells["Fila"].Value, dataGridView1.Rows[i].Cells["Asiento"].Value, dataGridView1.Rows[i].Cells["Precio"].Value, dataGridView1.Rows[i].Cells["Tipo"].Value, empresa,codigo);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception error) { MessageBox.Show("" + error); }
                        }

                        MessageBox.Show("Publicada Correctamente");
                    }
                    catch (Exception error) { MessageBox.Show("" + error); }

                    this.Hide();
                }
                else { MessageBox.Show("Campos vacios"); }
            }
            else 
            {
                if (txtDescripcion.Text == "" && txtDireccion.Text == "") { MessageBox.Show("Campos vacios"); }
                MessageBox.Show("Error en la fecha"); 
            }
        }
    }
}
