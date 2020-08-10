using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        public static String Codigo = "";

        public static void setCodigo(string c) { Codigo = c; }

        private bool comprobarUsuario() 
        {
            bool a,b;
            string cmd = string.Format("select 1 from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on u.cliente = c.dni where estado = 0 and idUsuario = '{0}'",txtUsr.Text);
            a=Utilidades.Ejecutar(cmd).Tables[0].Rows.Count != 0;
            if (a) { MessageBox.Show("Cliente inhabilitado"); }

            cmd = string.Format("select 1 from LOS_SIMULADORES.Empresa e join LOS_SIMULADORES.Usuario u on u.empresa = e.cuit where estado = 0 and idUsuario = '{0}'", txtUsr.Text);
            b = Utilidades.Ejecutar(cmd).Tables[0].Rows.Count != 0;
            if (b) { MessageBox.Show("Empresa inhabilitada"); }

            return !a && !b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Codigo = txtUsr.Text;
            if (comprobarUsuario())
            {
                try
                {
                    string cmd = string.Format("select intentos from LOS_SIMULADORES.intentos where usuario = '{0}'", txtUsr.Text.Trim());
                    int i = 0;
                    if (Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString() == "3")
                    {
                        MessageBox.Show("Usuario inhabilitado");
                    }
                    else
                    {
                        if (Int32.Parse(Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString()) >= 4)
                        {
                            i = 1;
                        }
                        cmd = string.Format("LOS_SIMULADORES.comprobar '{0}','{1}'", txtUsr.Text, txtPass.Text);
                        DataSet ds = Utilidades.Ejecutar(cmd);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (i == 1)
                            {
                                Cambiar_Contraseña cambiarContra = new Cambiar_Contraseña();
                                cambiarContra.Nuevo();
                                cambiarContra.Show();
                            }
                            else
                            {
                                cmd = string.Format("LOS_SIMULADORES.insertarIntento '{0}',1", txtUsr.Text);
                                Utilidades.Ejecutar(cmd);

                                cmd = string.Format("select rol from LOS_SIMULADORES.usuarioxrol where usuario = '{0}'", txtUsr.Text);
                                if (Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString() == "3")
                                {
                                    new Admin().Show();
                                    this.Hide();
                                }
                                else
                                {
                                    principal princ = new principal();
                                    this.Hide();
                                    princ.Show();
                                }
                            }
                        }
                        else
                        {
                            cmd = string.Format("LOS_SIMULADORES.insertarIntento '{0}',0", txtUsr.Text);
                            Utilidades.Ejecutar(cmd);
                            MessageBox.Show("Error de autentificacion");
                        }
                    }

                }
                catch
                {
                    string cmd = string.Format("select 1 from LOS_SIMULADORES.usuario where idUsuario = '{0}'", txtUsr.Text);

                    if (Utilidades.Ejecutar(cmd).Tables[0].Rows.Count == 1)
                    {
                        cmd = string.Format("LOS_SIMULADORES.insertarIntento '{0}',0", txtUsr.Text);
                        Utilidades.Ejecutar(cmd);
                    }

                    MessageBox.Show("Error de autentificacion" );
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.Form1 reg = new Registro_de_Usuario.Form1();
            this.Hide();
            reg.Show();
        }

    }
}
