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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            llenar();
        }

        private void llenar() { dataGridView1.DataSource = Utilidades.Ejecutar("Select idUsuario from LOS_SIMULADORES.Usuario u join LOS_SIMULADORES.UsuarioXRol x on x.usuario = u.idUsuario where x.rol != 3").Tables[0]; }
    }
}
