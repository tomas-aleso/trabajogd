using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        public DateTime fechaIni;
        public DateTime fechaFin;
        int i;

        
        public Form1()
        {
            InitializeComponent();

            DataSet ds = Utilidades.Ejecutar("select descripcion from LOS_SIMULADORES.Grado");

            for (int j = 0; j < ds.Tables[0].Rows.Count; j++){ cbEmpresas.Items.Add(ds.Tables[0].Rows[j][0].ToString()); }

            cbTrimestre.SelectedIndex = 0;
            cbEmpresas.SelectedIndex = 0;
        }

        private void generar() 
        {
            i = Int32.Parse(cbTrimestre.Text);
            fechaIni = DateTime.Parse(nudAnio.Value.ToString()+"-"+(3*i-2).ToString()+"-1");
            if (i == 4) { fechaFin = DateTime.Parse((nudAnio.Value+1).ToString() + "-1" + "-1"); }
            else{ fechaFin = DateTime.Parse(nudAnio.Value.ToString() + "-" + (3 * i + 1).ToString() + "-1"); }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            generar();

            if (rbEmpresa.Checked)
            {
                string cmd = string.Format("LOS_SIMULADORES.topEmpresa '{0}','{1}','{2}'", fechaIni, fechaFin, cbEmpresas.Text);
                dataGridView1.DataSource = Utilidades.Ejecutar(cmd).Tables[0];
            }
            if (rbCompras.Checked)
            {
                string cmd = string.Format("LOS_SIMULADORES.topCompradores '{0}','{1}'", fechaIni, fechaFin);
                dataGridView1.DataSource = Utilidades.Ejecutar(cmd).Tables[0];
            }
            if (rbPuntos.Checked)
            {
                string cmd = string.Format("LOS_SIMULADORES.topVencidos '{0}','{1}'", fechaIni, fechaFin);
                dataGridView1.DataSource = Utilidades.Ejecutar(cmd).Tables[0];
            }
        }


    }
}
