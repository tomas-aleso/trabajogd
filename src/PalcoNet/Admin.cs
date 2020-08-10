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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (rbUsr.Checked)
            {
                string cmd = string.Format("select 1 from LOS_SIMULADORES.Usuario where idUsuario = '{0}'", txtUsr.Text);
                if (Utilidades.Ejecutar(cmd).Tables[0].Rows.Count != 0)
                {
                    Login.setCodigo(txtUsr.Text);
                    principal princ = new principal();
                    princ.Show();
                    this.Hide();
                }
                else { MessageBox.Show("Usuario incorrecto"); }

            }
            else
            {
                principal princ = new principal(1);
                princ.Show();
                this.Hide();
            }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
