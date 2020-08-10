using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Milibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection Con = new SqlConnection("Data Source=localhost\SQLSERVER2012;Initial Catalog=GD2C2018;User ID=gdEspectaculos2018;Password=***********");
        }
    }
}
