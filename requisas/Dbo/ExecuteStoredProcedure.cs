using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class ExecuteStoredProcedure
    {
        public async Task<DBOResponse<DataTable>> ExecuteSP(Dictionary<string, object> parametros, string nombreSP)
        {
            await using var conection = Conexion.conexion();
            await conection.OpenAsync();
            var dt = new DataTable();
            try
            {
                using var command = new SqlCommand(nombreSP, conection);
                command.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                using var da = new SqlDataAdapter(command);
                da.Fill(dt);
                return DBOResponse<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return DBOResponse<DataTable>.Error("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
        }
    }
}
