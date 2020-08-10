using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class Form1 : Form
    {
        int pos;


        public void actualizarTabla()
        {
            string cmd = string.Format("select empresa from LOS_SIMULADORES.Usuario where idUsuario = '{0}'", Login.Codigo);

            string empresa = Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString();

            string CMD = string.Format("select * from LOS_SIMULADORES.Espectaculo where Empresa = '{0}' and Estado = 'Borrador'", empresa);
            DataSet ds = Utilidades.Ejecutar(CMD);

            dataGridView1.DataSource = ds.Tables[0];
        }

        public Form1()
        {
            InitializeComponent();
            actualizarTabla();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { pos = dataGridView1.CurrentRow.Index; }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar_Publicacion.Form2 editPubli = new Editar_Publicacion.Form2();
            editPubli.llenar(dataGridView1.Rows[pos].Cells[0].Value.ToString());
            editPubli.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            actualizarTabla();
        }
    }
}
