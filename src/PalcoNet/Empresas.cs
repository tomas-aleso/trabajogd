using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Empresas : Form
    {
        public Empresas()
        {
            InitializeComponent();
            llenar();
        }

        private void llenar() { dataGridView1.DataSource = Utilidades.Ejecutar("Select cuit from LOS_SIMULADORES.Empresa").Tables[0]; }
    }
}
