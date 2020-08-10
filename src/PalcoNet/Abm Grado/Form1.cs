using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class Form1 : Form
    {
        int pos;
      
        public Form1()
        {
            InitializeComponent();
            llenar();
        }

        private void llenar()
        {
            dataGridView1.DataSource = Utilidades.Ejecutar("select * from LOS_SIMULADORES.Grado").Tables[0];
            pos = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { pos = e.RowIndex; }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("LOS_SIMULADORES.eliminarGrado '{0}'", dataGridView1.Rows[pos].Cells["Peso"].Value.ToString());
                Utilidades.Ejecutar(cmd);
            }
            catch { }
            llenar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                txtDescripcion.Text = dataGridView1.Rows[pos].Cells["Descripcion"].Value.ToString();
                nudPeso.Value = Int32.Parse(dataGridView1.Rows[pos].Cells["Peso"].Value.ToString());
            }
            catch { }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string cmd = string.Format("select 1 from LOS_SIMULADORES.Grado where peso = '{0}'", nudPeso.Value);

            if (Utilidades.Ejecutar(cmd).Tables[0].Rows.Count > 0) 
            {
                cmd = string.Format("update LOS_SIMULADORES.Grado set  descripcion = '{0}' where peso = '{1}'",  txtDescripcion.Text, nudPeso.Value);
                Utilidades.Ejecutar(cmd);
                llenar(); 
            }
            else
            {
                cmd = string.Format("insert into LOS_SIMULADORES.Grado values('{0}','{1}')", nudPeso.Value, txtDescripcion.Text);
                Utilidades.Ejecutar(cmd);
                llenar();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("update LOS_SIMULADORES.Grado set estado = 1 where peso = '{0}'", dataGridView1.Rows[pos].Cells["Peso"].Value.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);
                llenar();
            }
            catch { }
        }

    }
}
