using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegEmp : Form
    {
        public int origen = 1;  // 1=registro, 2=nuevo, 3=editar

        public void setOrigen(int i) { origen = i; }

        private bool camposVacios() 
        {
            bool a = txtCuit.TextLength > 0 &&
            txtRazonS.TextLength > 0 &&
            txtMail.TextLength > 0 &&
            txtCalle.TextLength > 0 &&
            txtNumero.TextLength > 0 &&
            txtCodPost.TextLength > 0 &&
            txtTel.TextLength > 0;

            if (!a) { MessageBox.Show("Complete campos obligatorios"); }
            return a;
        }

        private bool cuitExistente() 
        {
            bool a;
            string CMD = string.Format("select 1 from LOS_SIMULADORES.usuario where empresa ='{0}'", txtCuit.Text);
            a = Utilidades.Ejecutar(CMD).Tables[0].Rows.Count == 0;
            if (!a) { MessageBox.Show("Cuit existente"); }
            
            return a;
        }

        private bool cuitValido() 
        {
            bool a;
            int i = 0;
            foreach (char letra in txtCuit.Text)
            {
                if (char.IsNumber(letra))
                {
                    i++;
                }

            }
            a = i > 10 && txtCuit.Text.Substring(2, 1) == txtCuit.Text.Substring(txtCuit.TextLength-3, 1);
            if (!a) { MessageBox.Show("Formato de cuit incorrecto (xx-xxxxxxxx-xx)"); }

            return a;
        }

        public void llenarRegEmp(string doc) 
        {
            string CMD = string.Format("select * from LOS_SIMULADORES.Empresa where Cuit ='{0}'", doc);

            DataSet ds = Utilidades.Ejecutar(CMD);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtCuit.Text = ds.Tables[0].Rows[0]["Cuit"].ToString().Trim();
                txtRazonS.Text = ds.Tables[0].Rows[0]["Razon_Social"].ToString().Trim();
                txtMail.Text = ds.Tables[0].Rows[0]["Mail"].ToString().Trim();
                txtCalle.Text = ds.Tables[0].Rows[0]["Calle"].ToString().Trim();
                txtNumero.Text = ds.Tables[0].Rows[0]["Numero"].ToString().Trim();
                txtDepto.Text = ds.Tables[0].Rows[0]["Departamento"].ToString().Trim();
                txtCodPost.Text = ds.Tables[0].Rows[0]["Codigo_postal"].ToString().Trim();
                txtPiso.Text = ds.Tables[0].Rows[0]["Piso"].ToString().Trim();
                txtTel.Text = ds.Tables[0].Rows[0]["Telefono"].ToString().Trim();
                fechaCrea.Value = DateTime.Parse(ds.Tables[0].Rows[0]["Fecha_Creacion"].ToString());

            }
            else { txtCuit.Text = doc; fechaCrea.MaxDate = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).AddDays(-1); }
        }

        public RegEmp()
        {
            InitializeComponent();
            cbCiudad.SelectedIndex = 0;
        }


        private void RegEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (origen == 1) { Application.Exit(); }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (origen == 1)
            {
                Login vent = new Login();
                vent.Show();
            }

            this.Hide();
        }


        private void btnacept_Click(object sender, EventArgs e)
        {
            if (camposVacios() && cuitExistente() && cuitValido())
            {
                string CMD = string.Format("exec LOS_SIMULADORES.actualizarEmpresa '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'",
                                            txtCuit.Text.Trim(), txtRazonS.Text.Trim(), fechaCrea.Value.ToString(), txtMail.Text.Trim(), txtCalle.Text.Trim(), txtNumero.Text.Trim(), txtPiso.Text.Trim(), txtDepto.Text.Trim(), txtCodPost.Text.Trim(), txtTel.Text.Trim(), cbCiudad.SelectedItem.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);


                if (origen == 1)
                {
                    CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),null,'{2}')", Registro_de_Usuario.Form1.usuario, Registro_de_Usuario.Form1.contra, txtCuit.Text.Trim());
                    ds = Utilidades.Ejecutar(CMD);

                    CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',2)", Registro_de_Usuario.Form1.usuario);
                    ds = Utilidades.Ejecutar(CMD);

                }
                if (origen == 2)
                {
                    CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),null,'{2}')", txtCuit.Text.Trim(), txtCuit.Text.Trim(), txtCuit.Text.Trim());
                    ds = Utilidades.Ejecutar(CMD);

                    CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',2)", txtCuit.Text.Trim());
                    ds = Utilidades.Ejecutar(CMD);
                }


                MessageBox.Show("Se ha registrado correctamente");

                if (origen == 1)
                {
                    string cmd = string.Format("insert into LOS_SIMULADORES.intentos values('{0}',0)", Registro_de_Usuario.Form1.usuario);
                    Utilidades.Ejecutar(cmd);
                    Login vent = new Login();
                    vent.Show();
                }
                if (origen == 2)
                {
                    string cmd = string.Format("insert into LOS_SIMULADORES.intentos values('{0}',4)", txtCuit.Text);
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("usuario y contraseña =" + txtCuit.Text.Trim());
                }

                this.Hide();
            }
            
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            
        }



    }
}
