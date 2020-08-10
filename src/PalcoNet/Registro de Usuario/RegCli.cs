using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegCli : Form
    {
        public static String fechaCreacion;

        public String usr, pass;

        public int origen = 1;  // 1=registro, 2=nuevo, 3=editar

        public void setOrigen(int i) { origen = i ;}

        private bool validarCampos() 
        {
            bool a;

            a = txtnombre.TextLength > 0 &&
                txtapellido.TextLength > 0 &&
                txtMail.TextLength > 0 &&
                txtTel.TextLength > 0 &&
                txtCuil.TextLength > 0 &&
                txtCalle.TextLength > 0 &&
                txtNum.TextLength > 0 &&
                txtCodpos.TextLength > 0;

            if (txtNumero.Text != "") 
            {
                a = a && txtNombreTarj.Text != "" &&
                        txtMes.TextLength == 2 &&
                        txtAnio.TextLength == 2 && 
                        txtCodigo.TextLength >2;
            }
            if (!a) { MessageBox.Show("Complete campos obligatorios (campo vencimiento => xx/xx)"); }
            return a;
        }

        public bool comprobarCuil() 
        {
            bool a = txtCuil.TextLength > 10;
            
            int i = 0;
            foreach (char letra in txtCuil.Text)
            {
                if (char.IsNumber(letra))
                {
                    i++;
                }

            }
            a = a && (i > 8) && txtCuil.Text.Substring(2, 1) == txtCuil.Text.Substring(txtCuil.TextLength-2, 1);

            if (!a) { MessageBox.Show("Error formato cuil (xx-xxxxxxxx-x)"); }
            return a;
        }

        public void llenarRegCli(string doc)
        {
            string CMD = string.Format("select * from LOS_SIMULADORES.cliente where Dni ='{0}'", doc);
            DataSet ds = Utilidades.Ejecutar(CMD);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtDoc.Text = doc;
                txtapellido.Text = ds.Tables[0].Rows[0]["Apellido"].ToString().Trim();
                txtnombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                txtMail.Text = ds.Tables[0].Rows[0]["Mail"].ToString().Trim();
                txtTel.Text = ds.Tables[0].Rows[0]["Telefono"].ToString().Trim();
                txtCalle.Text = ds.Tables[0].Rows[0]["Calle"].ToString().Trim();
                txtNum.Text = ds.Tables[0].Rows[0]["Numero"].ToString().Trim();
                txtDepto.Text = ds.Tables[0].Rows[0]["Departamento"].ToString().Trim();
                txtCodpos.Text = ds.Tables[0].Rows[0]["Codigo_postal"].ToString().Trim();
                txtPiso.Text = ds.Tables[0].Rows[0]["Piso"].ToString().Trim();
                fechaCreacion = ds.Tables[0].Rows[0]["Fecha_creacion"].ToString().Trim();
                fechnac.Value = DateTime.Parse(ds.Tables[0].Rows[0]["Fecha_Nacimiento"].ToString());
                txtNumero.Text = ds.Tables[0].Rows[0]["Tarjeta"].ToString().Trim();
                txtCuil.Text = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim();
                
                CMD = string.Format("select * from LOS_SIMULADORES.Tarjeta where numero ='{0}'", txtNumero.Text);
                ds = Utilidades.Ejecutar(CMD);
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtNombreTarj.Text = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                    txtMes.Text = ds.Tables[0].Rows[0]["Vencimiento"].ToString().Substring(0, 2);
                    txtAnio.Text = ds.Tables[0].Rows[0]["Vencimiento"].ToString().Substring(3, 2);
                    txtCodigo.Text = ds.Tables[0].Rows[0]["Codigo"].ToString().Trim();
                }

            }
            else 
            {
                fechaCreacion = DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]).ToString();
                txtDoc.Text = doc;
            }
        }

        public RegCli()
        {
            InitializeComponent();
            cbdoc.SelectedIndex = 0;
            cbLocalidad.SelectedIndex = 0;
        }

        private bool comprobarDniCuil(string dni, string cuil)
        {
            string CMD = string.Format("select 1 from LOS_SIMULADORES.usuario where cliente ='{0}' or empresa = '{1}'", dni, cuil);
            return Utilidades.Ejecutar(CMD).Tables[0].Rows.Count == 0;
        }

        public int insertarUsr(int i)
        {
            try
            {
                string CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),{2},null)", i.ToString(), i.ToString(), i.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);
                return i;
            }
            catch { return (insertarUsr(i + 1)); }
        }

        private void RegCli_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (origen == 1) { Application.Exit(); }
        }


        private void btnSig_Click(object sender, EventArgs e)
        {
            if(validarCampos() && comprobarCuil()){
            if (comprobarDniCuil(txtDoc.Text, txtCuil.Text))
            {

                if (!string.IsNullOrEmpty(txtNumero.Text))
                {
                    try
                    {
                        string cmd = string.Format("insert into LOS_SIMULADORES.tarjeta values('{0}','{1}','{2}','{3}')", txtNumero.Text, txtNombreTarj.Text, txtMes.Text + "/" + txtAnio.Text, txtCodigo.Text);
                        Utilidades.Ejecutar(cmd);
                    }
                    catch
                    {
                        string cmd = string.Format("update LOS_SIMULADORES.tarjeta set nombre = '{1}', vencimiento = '{2}', codigo = '{3}' where numero = '{0}'", txtNumero.Text, txtNombreTarj.Text, txtMes.Text + "/" + txtAnio.Text, txtCodigo.Text);
                        Utilidades.Ejecutar(cmd);
                    }

                    string CMD = string.Format("exec LOS_SIMULADORES.actualizarCliente '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}','{13}','{14}'",
                                                txtDoc.Text.Trim(), txtapellido.Text.Trim(), txtnombre.Text.Trim(), cbdoc.SelectedItem.ToString(), txtCuil.Text, fechnac.Value.ToString(), txtMail.Text.Trim(), txtTel.Text.Trim(), txtCalle.Text.Trim(), txtNum.Text.Trim(), txtPiso.Text.Trim(), txtDepto.Text.Trim(), txtCodpos.Text.Trim(), fechaCreacion, txtNumero.Text.Trim());

                    DataSet ds = Utilidades.Ejecutar(CMD);
                }
                else
                {
                    string cmd = string.Format("exec LOS_SIMULADORES.actualizarCliente '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}','{13}',{14}",
                                                txtDoc.Text.Trim(), txtapellido.Text.Trim(), txtnombre.Text.Trim(), cbdoc.SelectedItem.ToString(), txtCuil.Text, fechnac.Value.ToString(), txtMail.Text.Trim(), txtTel.Text.Trim(), txtCalle.Text.Trim(), txtNum.Text.Trim(), txtPiso.Text.Trim(), txtDepto.Text.Trim(), txtCodpos.Text.Trim(), fechaCreacion, "null");

                    DataSet ds = Utilidades.Ejecutar(cmd);

                }


                if (origen == 1)
                {
                    string CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),{2},null)", Registro_de_Usuario.Form1.usuario, Registro_de_Usuario.Form1.contra, txtDoc.Text.Trim());
                    DataSet ds = Utilidades.Ejecutar(CMD);

                    CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',1)", Registro_de_Usuario.Form1.usuario);
                    ds = Utilidades.Ejecutar(CMD);

                    MessageBox.Show("Se ha registrado correctamente");

                    string cmd = string.Format("insert into LOS_SIMULADORES.intentos values('{0}',0)", Registro_de_Usuario.Form1.usuario);
                    Utilidades.Ejecutar(cmd);
                    Login vent = new Login();
                    vent.Show();

                }
                if (origen == 2)
                {
                    int n = Int32.Parse(txtDoc.Text);

                    n = insertarUsr(n);

                    string CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',1)", n.ToString());
                    DataSet ds = Utilidades.Ejecutar(CMD);

                    MessageBox.Show("Se ha registrado correctamente");

                    string cmd = string.Format("insert into LOS_SIMULADORES.intentos values('{0}',4)", n.ToString());
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("usuario y contraseña =" + n.ToString());

                }

                this.Hide();
            }
            else { MessageBox.Show("Dni y/o cuil en uso"); }
            
            }
            
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

        private void txtCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
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

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
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

        private void txtNombreTarj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }



    }
}
