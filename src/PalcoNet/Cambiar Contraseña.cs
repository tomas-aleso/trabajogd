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
    public partial class Cambiar_Contraseña : Form
    {
        public bool i = false;
        public void Nuevo() { i = true; }
        
        public Cambiar_Contraseña()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string oldPass = txtActual.Text;

            string cmd = string.Format("select 1 from LOS_SIMULADORES.Usuario where idUsuario = '{0}' and HASHBYTES('SHA2_256','{1}') = Password", Login.Codigo, oldPass);

            if (Utilidades.Ejecutar(cmd).Tables[0].Rows.Count > 0)
            {
                if (txtNueva.Text == txtConfi.Text && txtConfi.Text != "")
                {
                    cmd = string.Format("update LOS_SIMULADORES.Usuario set Password = HASHBYTES('SHA2_256','{0}') where idUsuario = '{1}'", txtConfi.Text, Login.Codigo);
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Operacion realizada");
                    if (i) { Utilidades.Ejecutar("update LOS_SIMULADORES.intentos set intentos = 0 where usuario = '" + Login.Codigo+"'"); }
                    this.Hide();
                }
                else { MessageBox.Show("Verifique los campos"); }
            }
            else { MessageBox.Show("Contraseña incorrecta"); MessageBox.Show(oldPass); MessageBox.Show(Login.Codigo); }

        }

        private void Cambiar_Contraseña_Load(object sender, EventArgs e)
        {

        }


    }
}
