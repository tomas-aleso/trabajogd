using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class Form1 : Mantenimiento
    {
        DataGridViewRow selectedRow;

        public Form1()
        {
            InitializeComponent();
        }

        public void Filtrar()
        {
            if (txtCuit.Text == "")
            {
                string CMD = string.Format("select * from LOS_SIMULADORES.Empresa where Razon_Social like ('%" + txtRazon.Text + "%') and Mail like ('%" + txtMail.Text + "%')");
                DataSet ds = Utilidades.Ejecutar(CMD);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                string CMD = string.Format("select * from LOS_SIMULADORES.Empresa where Cuit like ('" + txtCuit.Text + "')");
                DataSet ds = Utilidades.Ejecutar(CMD);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selectedRow = dataGridView1.Rows[index];
        }

        private void txtRazon_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.RegEmp regE = new Registro_de_Usuario.RegEmp();
            regE.setOrigen(2);
            regE.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("LOS_SIMULADORES.eliminarEmpresa '{0}'", selectedRow.Cells[0].Value.ToString());

                DataSet ds = Utilidades.Ejecutar(CMD);

                Filtrar();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                selectedRow = dataGridView1.Rows[index];
            }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Registro_de_Usuario.RegEmp regE = new Registro_de_Usuario.RegEmp();
                regE.setOrigen(3);
                regE.llenarRegEmp(selectedRow.Cells[0].Value.ToString());
                regE.Show();
            }
            catch { }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("update LOS_SIMULADORES.Empresa set estado = 1 where cuit = '{0}'", selectedRow.Cells[0].Value.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);
                Filtrar();
            }
            catch { }
        }
    }
}
