using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class Form1 : Form
    {
        int posRol;
        int posFunc;
        
        public void llenarRol()
        {
            DataSet ds = Utilidades.Ejecutar("select * from LOS_SIMULADORES.rol");

            dgvRol.DataSource = ds.Tables[0];
            
        }

        public void llenarFuncionalidad()
        {
            try
            {
                string cmd = string.Format("select idFunc, Descripcion from LOS_SIMULADORES.funcionalidadxrol x join LOS_SIMULADORES.Funcionalidad f on x.Funcionalidad = f.idFunc join LOS_SIMULADORES.Rol r on r.idRol = x.Rol where r.Nombre = '{0}' order by idFunc", dgvRol.Rows[posRol].Cells[1].Value.ToString());

                DataSet ds = Utilidades.Ejecutar(cmd);

                dgvFuncionalidad.DataSource = ds.Tables[0];
            }
            catch { }

        }

        public Form1()
        {
            InitializeComponent();
            llenarRol();
            llenarFuncionalidad();
            txtEdicion.Text = dgvRol.Rows[posRol].Cells[1].Value.ToString();
        }


        private void dgvRol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                posRol = e.RowIndex;
                llenarCombo();
                llenarFuncionalidad();
                txtEdicion.Text = dgvRol.Rows[posRol].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string cmd = string.Format("update LOS_SIMULADORES.rol set Nombre = '{1}' where idRol = '{0}'", dgvRol.Rows[posRol].Cells[0].Value.ToString(), txtEdicion.Text);

            DataSet ds = Utilidades.Ejecutar(cmd);

            llenarRol();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("insert into LOS_SIMULADORES.rol values('{0}')", txtAgregar.Text);

                DataSet ds = Utilidades.Ejecutar(cmd);

                llenarRol();
            }
            catch (Exception error) { MessageBox.Show(""+error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRol.Rows[posRol].Cells[0].Value.ToString() != "4")
                {
                    string cmd = string.Format("LOS_SIMULADORES.eliminarRol '{0}'", dgvRol.Rows[posRol].Cells[0].Value.ToString());
                    DataSet ds = Utilidades.Ejecutar(cmd);

                    llenarRol();
                }
                else { MessageBox.Show("No se puede eliminar el rol vacio"); }
            }
            catch {  }
        }


        private void btnEliFunc_Click(object sender, EventArgs e)
        {
           try
            {
                string cmd = string.Format("DELETE FROM LOS_SIMULADORES.FuncionalidadXRol where funcionalidad = '{1}' and rol = '{0}'", dgvRol.Rows[posRol].Cells[0].Value.ToString(), dgvFuncionalidad.Rows[posFunc].Cells[0].Value.ToString());

                DataSet ds = Utilidades.Ejecutar(cmd);

                llenarFuncionalidad();
            }
            catch{  }
        }

        private void dgvFuncionalidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posFunc = e.RowIndex;
        }

        private void llenarCombo()
        {
            cbFunc.DataSource = Utilidades.Ejecutar("select descripcion from LOS_SIMULADORES.funcionalidad").Tables[0];
            cbFunc.DisplayMember = "Descripcion";
        }

        private void btnAgrFunc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRol.Rows[posRol].Cells[0].Value.ToString() != "4")
                {
                    string cmd = string.Format("LOS_SIMULADORES.insertarFuncXRol '{0}','{1}'", cbFunc.Text, dgvRol.Rows[posRol].Cells[0].Value.ToString());
                    DataSet ds = Utilidades.Ejecutar(cmd);

                    llenarFuncionalidad();
                }
                else { MessageBox.Show("No se puede agregar funcionalidad a Vacio"); }
            }
            catch (Exception error) { MessageBox.Show("" + error); }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("update LOS_SIMULADORES.rol set estado = 1 where idRol = '{0}'", dgvRol.Rows[posRol].Cells[0].Value.ToString());
                DataSet ds = Utilidades.Ejecutar(CMD);
                llenarRol();
            }
            catch { }
        }
    }
}
