using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PalcoNet.Abm_Cliente
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
            if (txtDni.Text == "")
            {
                string CMD = string.Format("select * from LOS_SIMULADORES.cliente where Nombre like ('%" + txtNombre.Text + "%') and Apellido like ('%" + txtApe.Text + "%') and Mail like ('%" + txtMail.Text + "%')");
                DataSet ds = Utilidades.Ejecutar(CMD);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else 
            {
                string CMD = string.Format("select * from LOS_SIMULADORES.cliente where Dni like ('" + txtDni.Text + "')");
                DataSet ds = Utilidades.Ejecutar(CMD);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filtrar();
        }

        public override bool Guardar()
        {
            return base.Guardar();
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtApe_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.RegCli regC = new Registro_de_Usuario.RegCli();
            regC.setOrigen(2);
            regC.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("LOS_SIMULADORES.eliminarCliente '{0}'", selectedRow.Cells[0].Value.ToString());
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
            catch{}
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Registro_de_Usuario.RegCli regC = new Registro_de_Usuario.RegCli();
                regC.setOrigen(3);
                regC.llenarRegCli(selectedRow.Cells[0].Value.ToString());
                regC.Show();
            }
            catch {  }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("update LOS_SIMULADORES.Cliente set estado = 1 where dni = '{0}'", selectedRow.Cells[0].Value.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);
                Filtrar();
            }
            catch { }
        }

    }
}
