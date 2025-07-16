using Modelos;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class EstadoDbo
    {

        public async Task<DBOResponse<IEnumerable<Estado>>> ObtenerEstados()
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            try
            {

                using var cmd = conn.CreateCommand();
                string query = @"                
                    SELECT 
	                    er.id, er.descripcion, er.fechaCreacion, er.fechaModificacion, er.creadoPor
                    FROM EstadoRequisa er
                ";
                cmd.CommandText = query;
                using var reader = await cmd.ExecuteReaderAsync();

                var estados = new List<Estado>();

                while (await reader.ReadAsync())
                {
                    var estado = new Estado.Builder()
                        .SetIdEstado(reader.GetInt32(reader.GetOrdinal("id")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcion")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacion")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("creadoPor")))
                        .Build();

                    estados.Add(estado);
                }

                return DBOResponse<IEnumerable<Estado>>.Ok(estados);
            }
            catch (Exception ex)
            {
                return DBOResponse<IEnumerable<Estado>>.Error(ex.Message);
            }
        }

        public async Task<DBOResponse<Estado>> ObtenerEstadoPorNombre(string nombre)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            try
            {

                using var cmd = conn.CreateCommand();
                string query = @"                
                    SELECT 
	                    er.id, er.descripcion, er.fechaCreacion, er.fechaModificacion, er.creadoPor
                    FROM EstadoRequisa er
                    WHERE er.descripcion = @descripcion
                ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@descripcion", nombre);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var estado = new Estado.Builder()
                        .SetIdEstado(reader.GetInt32(reader.GetOrdinal("id")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcion")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacion")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("creadoPor")))
                        .Build();

                    return DBOResponse<Estado>.Ok(estado);
                }
                else
                {
                    return DBOResponse<Estado>.Error("Estado no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return DBOResponse<Estado>.Error(ex.Message);
            }
        }

        public async Task<DBOResponse<Estado>> ObtenerEstadoPorId(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            try
            {

                using var cmd = conn.CreateCommand();
                string query = @"                
                    SELECT 
	                    er.id, er.descripcion, er.fechaCreacion, er.fechaModificacion, er.creadoPor
                    FROM EstadoRequisa er
                    WHERE er.id = @id
                ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var estado = new Estado.Builder()
                        .SetIdEstado(reader.GetInt32(reader.GetOrdinal("id")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcion")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacion")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("creadoPor")))
                        .Build();

                    return DBOResponse<Estado>.Ok(estado);
                }
                else
                {
                    return DBOResponse<Estado>.Error("Estado no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return DBOResponse<Estado>.Error(ex.Message);
            }
        }
    }
}
