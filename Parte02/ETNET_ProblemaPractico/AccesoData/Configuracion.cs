using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData
{
    public static class Configuracion
    {
        public static string CadenaConexion(string NombreCadena) {

            return ConfigurationManager.ConnectionStrings[NombreCadena].ConnectionString;
        }
    }
}
