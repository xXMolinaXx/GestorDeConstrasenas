using System;
using System.Collections.Generic;
using System.Configuration;//libreria usadas para conectarme a la base de datos
using System.Data.SqlClient;//libreria usadas para conectarme a la base de datos
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeConstrasenas
{
    class conexionBD
    {
        public static String StringConexionBD = ConfigurationManager.ConnectionStrings["GestorDeConstrasenas.Properties.Settings.gestor_KM_BDConnectionString"].ConnectionString;
        public  SqlConnection miConexionSql;
        public conexionBD() 
        {
            
            miConexionSql = new SqlConnection(StringConexionBD);

        }

    }
}
