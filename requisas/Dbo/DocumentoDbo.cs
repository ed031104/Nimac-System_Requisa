using Dbo.utils;
using Microsoft.Data.SqlClient;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class DocumentoDbo
    {

        public async Task<DBOResponse<int>> CrearDocumento(Documento doc)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();
                string query = @"
                    INSERT INTO Documento (Nombre, documento, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                    VALUES (@Nombre, @documento, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion);
                    SELECT SCOPE_IDENTITY(); 
                ";
                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Nombre", doc.Nombre);
                cmd.Parameters.AddWithValue("@documento", doc.DocumentoBytes);
                cmd.Parameters.AddWithValue("@CreadoPor", doc.CreadoPor);
                cmd.Parameters.AddWithValue("@ModificadoPor", doc.ModificadoPor);
                cmd.Parameters.AddWithValue("@FechaCreacion", doc.FechaCreacion);
                cmd.Parameters.AddWithValue("@FechaModificacion", doc.FechaModificacion);
                var id = await cmd.ExecuteScalarAsync();
                if (id != null)
                {
                    int IdDocumento = Convert.ToInt32(id);
                    return DBOResponse<int>.Ok(IdDocumento);
                }

                return DBOResponse<int>.Error("No se pudo crear el documento.");
            }
            catch (SqlException ex)
            {
                return DBOResponse<int>.Error("Error al crear el documento: " + ex.Message);
            }
        }


        public async Task<DBOResponse<Documento>> ObtenerRolPorId(int id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                string query = @"
                    SELECT d.id_Documento, d.Nombre, d.documento, d.CreadoPor, d.ModificadoPor, d.FechaCreacion, d.FechaModificacion
                    FROM
	                    Documento d
                    WHERE
	                    d.id_Documento = @id
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@id", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    Documento doc = new Documento.Builder()
                        .SetIdDocumento(reader.validateTypeData<int>("id_Documento"))
                        .SetNombre(reader.validateTypeData<string>("Nombre"))
                        .SetDocumento(reader.validateTypeData<byte[]>("documento"))
                        .SetCreadoPor(reader.validateTypeData<string>("CreadoPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("ModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("FechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("FechaModificacion"))
                        .Build();

                    return DBOResponse<Documento>.Ok(doc);
                }
                else
                {
                    return DBOResponse<Documento>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Documento>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }
    }
}
