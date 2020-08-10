using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria
{
    public class Utilidades
    {
        /*public static DataSet Ejecutar(string cmd) 
        {
            SqlConnection Con = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2018;User ID=gdEspectaculos2018;Password=gd2018");
            Con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, Con);

            DP.Fill(DS);

            Con.Close();

            return DS;
        }*/

        /*
        public static Boolean ingresarCliente(string doc, string appellido, string nombre, string tipoDni, string fechaNac, string mail,
                                              string tel, string calle, string numero, string piso, string depto, string codPost,
                                              string fechaCrea, string tarjeta)
        {
            try
            {
                string CMD = string.Format("exec LOS_SIMULADORES.actualizarCliente '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}','{13}'",
                                                                    doc, appellido, nombre, tipoDni, fechaNac, mail, tel, calle, numero, piso, depto, codPost, fechaCrea,tarjeta);

                DataSet ds = Utilidades.Ejecutar(CMD);



                return true;

            }
            catch{ return false; }
        }
        */

        /*
        public static Boolean ingresarEmpresa(string cuit, string razon, string fechaCrea, string mail, string calle, string numero,
                                              string piso, string depto, string codPost, string tel, string ciudad)
        {
            try
            {
                string CMD = string.Format("exec LOS_SIMULADORES.actualizarEmpresa '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'",
                                                                    cuit, razon, fechaCrea, mail, calle, numero, piso, depto, codPost, tel, ciudad);

                DataSet ds = Utilidades.Ejecutar(CMD);



                return true;

            }
            catch { return false; }
        }*/

        /*
        public static Boolean ingresarUsuarioC(string usr, string pass, string doc) 
        {
            try
            {
                string CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),{2},null)", usr, pass, doc);

                DataSet ds = Utilidades.Ejecutar(CMD);

                CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',1)", usr);

                ds = Utilidades.Ejecutar(CMD);

                return true;
            }
            catch { return false; }

        }*/
        /*
        public static Boolean ingresarUsuarioE(string usr, string pass, string doc)
        {
            try
            {
                string CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuario VALUES('{0}',HASHBYTES('SHA2_256','{1}'),null,'{2}')", usr, pass, doc);

                DataSet ds = Utilidades.Ejecutar(CMD);

                CMD = string.Format("INSERT INTO LOS_SIMULADORES.Usuarioxrol VALUES('{0}',2)", usr);

                ds = Utilidades.Ejecutar(CMD);

                return true;
            }
            catch { return false; }

        }*/
        /*
        public static void llenarRegistro(string dni) 
        { 
            
        }*/
    }
}
