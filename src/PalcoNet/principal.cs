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
    public partial class principal : Form
    {
        bool admin = false;
        
        public principal()
        {
            InitializeComponent();
            llenar();
        }

        public principal(int a)
        {
            InitializeComponent();
            admin = true;
            llenar();
        }


        private void principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            
            
            FormCollection formulariosApp = Application.OpenForms;

            foreach (Form f in formulariosApp)
            {
                if (f != this)
                {
                    f.Hide();
                }
            }

            this.Hide();

            
            
            Login login = new Login();
            login.Show();
            
        }

        private void principal_Load(object sender, EventArgs e)
        {
            lblUsr.Text = Login.Codigo;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void llenar() 
        {
            if (admin) 
            {
                cbfunc.DataSource = Utilidades.Ejecutar("select * from LOS_SIMULADORES.funcionalidadxrol x join LOS_SIMULADORES.funcionalidad f on x.funcionalidad = f.idFunc join LOS_SIMULADORES.usuarioxrol ux on ux.rol = x.rol where ux.rol = 3 and not exists (select 1 from LOS_SIMULADORES.FuncionalidadXRol where rol != 3 and funcionalidad = x.Funcionalidad)").Tables[0];
                cbfunc.DisplayMember = "Descripcion";
            }
            else
            {
                string cmd = string.Format("select descripcion from LOS_SIMULADORES.funcionalidadxrol x join LOS_SIMULADORES.funcionalidad f on x.funcionalidad = f.idFunc join LOS_SIMULADORES.usuarioxrol ux on ux.rol = x.rol where ux.usuario = '{0}'", Login.Codigo);
                cbfunc.DataSource = Utilidades.Ejecutar(cmd).Tables[0];
                cbfunc.DisplayMember = "Descripcion";
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            switch (cbfunc.Text)
            {
                case "ABM Cliente":
                    Abm_Cliente.Form1 cli = new Abm_Cliente.Form1();
                    cli.Show();
                    break;
                case "ABM Empresa Espectaculo":
                    Abm_Empresa_Espectaculo.Form1 emp = new Abm_Empresa_Espectaculo.Form1();
                    emp.Show();
                    break;
                case "ABM Grado":
                    Abm_Grado.Form1 grado = new Abm_Grado.Form1();
                    grado.Show();
                    break;
                case "ABM Rol":
                    Abm_Rol.Form1 rol = new Abm_Rol.Form1();
                    rol.Show();
                    break;
                case "ABM Rubro":
                    Abm_Rubro.Form1 rubro = new Abm_Rubro.Form1();
                    rubro.Show();
                    break;
                case "Canje Puntos":
                    Canje_Puntos.Form1 canje = new Canje_Puntos.Form1();
                    canje.Show();
                    break;
                case "Comprar":
                    Comprar.Form1 comprar = new Comprar.Form1();
                    comprar.Show();
                    break;
                case "Editar Publicacion":
                    Editar_Publicacion.Form1 editPubli = new Editar_Publicacion.Form1();
                    editPubli.Show();
                    break;
                case "Generar Publicacion":
                    Generar_Publicacion.Form1 generarPubli = new Generar_Publicacion.Form1();
                    generarPubli.Show();
                    break;
                case "Generar Rendicion Comisiones":
                    Generar_Rendicion_Comisiones.Form1 generarRC = new Generar_Rendicion_Comisiones.Form1();
                    generarRC.Show();
                    break;
                case "Historial Cliente":
                    Historial_Cliente.Form1 histC = new Historial_Cliente.Form1();
                    histC.Show();
                    break;
                case "Listado Estadistico":
                    Listado_Estadistico.Form1 listEst = new Listado_Estadistico.Form1();
                    listEst.Show();
                    break;
                
            }
        }

        private void btnCambiarPass_Click(object sender, EventArgs e)
        {
            new Cambiar_Contraseña().Show();
        }

    }
}
