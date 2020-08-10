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
    public partial class IngresarTarjeta : Form
    {
        public IngresarTarjeta()
        {
            InitializeComponent();
        }

        private bool validarCampos() 
        {
            bool a = txtNumero.TextLength > 10 &&
                txtNombre.Text != "" &&
                txtMes.TextLength == 2 &&
                txtAnio.TextLength == 2 &&
                txtCodigo.TextLength > 2;
            return a;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string cmd = string.Format("insert into LOS_SIMULADORES.tarjeta values('{0}','{1}', '{2}', '{3}')", txtNumero.Text, txtNombre.Text, txtMes.Text + "/" + txtAnio.Text, txtCodigo.Text);
                Utilidades.Ejecutar(cmd);
                cmd = string.Format("update LOS_SIMULADORES.Cliente set tarjeta = '{0}' where dni = (select dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.usuario u on u.cliente = c.dni where u.idUsuario = '{1}')", txtNumero.Text, Login.Codigo);
                Utilidades.Ejecutar(cmd);
                this.Hide();
            }
            else { MessageBox.Show("Verifique los campos"); }
        }
    }
}
