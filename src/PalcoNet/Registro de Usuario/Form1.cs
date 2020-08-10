using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PalcoNet.Registro_de_Usuario
{
    public partial class Form1 : Form
    {
        public static String usuario = "";
        public static String contra = "";
        public static String doc = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Login vent = new Login();
            this.Hide();
            vent.Show();
        }

        private bool comprobarUsrDni(string usr, string dni) 
        {
            string cmd = string.Format("select 1 where exists (select 1 from LOS_SIMULADORES.Usuario where idUsuario = '{0}') or exists (select 1 from LOS_SIMULADORES.usuario where cliente = '{1}')", usr, dni );
            return Utilidades.Ejecutar(cmd).Tables[0].Rows.Count == 0;
        }

        private bool comprobarUsrCuit(string usr, string cuit)
        {
            string cmd = string.Format("select 1 where exists (select 1 from LOS_SIMULADORES.Usuario where idUsuario = '{0}') or exists (select 1 from LOS_SIMULADORES.usuario where empresa = '{1}')", usr, cuit);
            return Utilidades.Ejecutar(cmd).Tables[0].Rows.Count == 0;
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            if (txtdniCuil.Text == "" || txtusr.Text == "" || txtpass.Text == "") { MessageBox.Show("Ingrese todos los datos"); }
            else
            {
                usuario = txtusr.Text.Trim();
                contra = txtpass.Text.Trim();
                doc = txtdniCuil.Text.Trim();

                if (rbtnClie.Checked)
                {
                    int i = 0;
                    foreach (char letra in doc)
                    {
                        if (char.IsNumber(letra))
                        {
                            i++;
                        }

                    }

                    if (i == doc.Length)
                    {
                        if (comprobarUsrDni(usuario, doc))
                        {
                            RegCli regC = new RegCli();
                            this.Hide();
                            regC.llenarRegCli(doc);
                            regC.Show();
                        }
                        else { MessageBox.Show("Usuario en uso o dni registrado"); }
                    }
                    else { MessageBox.Show("Dni solo puede contener numeros"); }
                }

                if (rbtnEmp.Checked)
                {
                    if (comprobarUsrCuit(usuario, doc))
                    {
                        RegEmp regE = new RegEmp();
                        this.Hide();
                        regE.llenarRegEmp(doc);
                        regE.Show();
                    }
                    else { MessageBox.Show("Usuario en uso o cuit registrado"); }
                }
                
            }
        }

        private void txtdniCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
