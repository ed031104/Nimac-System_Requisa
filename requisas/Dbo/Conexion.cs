using Configuraciones;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public static class Conexion
    {

        private static readonly string _strConexion; 

        static Conexion() {
            _strConexion = Configuracion.Get("ConnectionString") 
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión en la configuración.");
        }

        public static SqlConnection conexion() 
        { 
           return new SqlConnection(_strConexion);
        }
    }
}
