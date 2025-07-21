using Microsoft.Data.SqlClient;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class ReclamoDbo
    {
        public async Task<DBOResponse<bool>> ActualizarReclamo(Reclamo reclamo)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            string query = @"
                UPDATE Reclamo
                SET
	                id_documento = @idDocumento,
	                ModificadoPor = @modificadoPor,
	                FechaModificacion = @fechaModificacion
                where
	                id_Reclamo = @idReclamo
            ";

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@idReclamo", reclamo.IdReclamo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@idDocumento", reclamo.DocumentoReclamo.IdDocumento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@modificadoPor", reclamo.ModificadoPor ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fechaModificacion", reclamo.FechaModificacion ?? (object)DBNull.Value);
            try
            {
                bool result = await cmd.ExecuteNonQueryAsync() > 0;
                return DBOResponse<bool>.Ok(result);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al crear el Rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Reclamo>> obtenerReclamoPorId(int id) {
            var conn = Conexion.conexion();
            await conn.OpenAsync();
            try {

                string query = @"
                    SELECT 
	                    r.id_Reclamo, r.observacion, r.id_documento, r.CreadoPor, r.ModificadoPor, r.FechaCreacion, r.FechaModificacion
                    FROM 
	                    Reclamo r
                    WHERE
                        r.id_Reclamo = @idReclamo
                ";
                var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@idReclamo", id); // Cambiar por el ID del reclamo que se desea obtener

                var reader = await cmd.ExecuteReaderAsync();
            
                if (reader.Read()) { 
                    
                        var reclamo = new Reclamo.Builder()
                            .SetIdReclamo(reader.GetInt32(0))
                            .SetObservacion(reader.IsDBNull(1) ? null : reader.GetString(1))
                            .SetDocumento(new Documento.Builder()
                                .SetIdDocumento(reader.IsDBNull(2) ? null : reader.GetInt32(2))
                                .Build())
                            .SetCreadoPor(reader.IsDBNull(3) ? null : reader.GetString(3))
                            .SetModificadoPor(reader.IsDBNull(4) ? null : reader.GetString(4))
                            .SetFechaCreacion(reader.IsDBNull(5) ? null : reader.GetDateTime(5))
                            .SetFechaModificacion(reader.IsDBNull(6) ? null : reader.GetDateTime(6))
                            .Build();
                    return DBOResponse<Reclamo>.Ok(reclamo);
                }

                return DBOResponse<Reclamo>.Error("No se encontraron reclamos.");
            
            } catch (Exception ex) {
                return DBOResponse<Reclamo>.Error("Error al obtener el reclamo: " + ex.Message);
            }
        }
    }
}
