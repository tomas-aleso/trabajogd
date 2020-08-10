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

namespace PalcoNet.Canje_Puntos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarpuntos();
        }

        public void actualizarpuntos()
        {
            string cmd = string.Format("exec LOS_SIMULADORES.puntos '{0}','{1}'", Login.Codigo, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]));

            txtPuntos.Text = Utilidades.Ejecutar(cmd).Tables[0].Rows[0][0].ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string check = "Error";
            float puntos = 0;
            if (rbCompra.Checked && float.Parse(txtPuntos.Text) > 500) { check = "compra"; puntos = 500; }
            if (rbAuri.Checked && float.Parse(txtPuntos.Text) > 1000) { check = "auriculares"; puntos = 1000; }
            if (rbViaje.Checked && float.Parse(txtPuntos.Text) > 1500) { check = "viaje"; puntos = 1500; }

            if (check != "Error")
            {
                string cmd = string.Format("insert into LOS_SIMULADORES.premio values((select Dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on c.Dni = u.Cliente where u.idUsuario = '{0}'),'{1}','{2}','{3}')", Login.Codigo, check, DateTime.Parse(ConfigurationSettings.AppSettings["DateKey"]),puntos);

                Utilidades.Ejecutar(cmd);

                MessageBox.Show("Puntos canjeados");

                actualizarpuntos();
                check = "Error";
            }
            else { MessageBox.Show("Puntos insuficientes"); }
            

        }

    }
}
