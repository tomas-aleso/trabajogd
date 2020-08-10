using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PalcoNet
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            //SqlConnection Con = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2018;User ID=gdEspectaculos2018;Password=gd2018");

            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
            Con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, Con);

            DP.Fill(DS);

            Con.Close();

            return DS;
        }
    }
}
