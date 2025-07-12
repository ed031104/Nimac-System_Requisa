using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class TipoAjusteDbo
    {
        public TipoAjusteDbo() { }

        public async Task<DBOResponse<int>> CrearTipoAjuste(TipoAjuste tipoAjuste)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("insert into Tipo_Ajuste(id_TipoAjuste, Descripcion_TipoAjuste, Simbolo_TipoAjuste, FechaRegistro, FechaModificacion) ");
            query.Append("VALUES (@Id_TipoAjuste, @Descripcion_TipoAjuste, @Simbolo_TipoAjuste, @FechaRegistro, @FechaModificacion); ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Numero_Parte", tipoAjuste.TipoAjusteId);
            cmd.Parameters.AddWithValue("@Descripcion_Parte", tipoAjuste.Descripcion);
            cmd.Parameters.AddWithValue("@Descripcion_Parte", tipoAjuste.SimboloTipoAjuste);
            cmd.Parameters.AddWithValue("@Descripcion_Parte", tipoAjuste.FechaRegistro);
            cmd.Parameters.AddWithValue("@Descripcion_Parte", tipoAjuste.FechaModificacion);

            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear la Parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<TipoAjuste>> ObtenerTipoAjustePorId(int id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select id_TipoAjuste, Descripcion_TipoAjuste, Simbolo_TipoAjuste, FechaRegistro, FechaModificacion from Tipo_Ajuste\r\n ");
                query.Append("WHERE id_TipoAjuste = @IdTipoAjuste");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@IdTipoAjuste", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("id_TipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion_TipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("Simbolo_TipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    return DBOResponse<TipoAjuste>.Ok(tipoAjuste);
                }
                else
                {
                    return DBOResponse<TipoAjuste>.Error("Tipo de Ajuste no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<TipoAjuste>.Error("Error al obtener el Tipo de Ajuste: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarTipoAjuste(TipoAjuste tipoAjuste)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("update Tipo_Ajuste");
            query.Append("SET ");
            query.Append("Descripcion_TipoAjuste = @Descripcion_TipoAjuste, ");
            query.Append("Simbolo_TipoAjuste = @Simbolo_TipoAjuste, ");
            query.Append("FechaRegistro = @FechaRegistro, ");
            query.Append("FechaModificacion = @FechaModificacion ");
            query.Append("WHERE ");
            query.Append("id_TipoAjuste = @id_TipoAjuste");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Descripcion_TipoAjuste", tipoAjuste.Descripcion);
            cmd.Parameters.AddWithValue("@Simbolo_TipoAjuste", tipoAjuste.SimboloTipoAjuste);
            cmd.Parameters.AddWithValue("@FechaRegistro", tipoAjuste.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", tipoAjuste.FechaModificacion);
            cmd.Parameters.AddWithValue("@id_TipoAjuste", tipoAjuste.TipoAjusteId);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ningún tipo de ajuste. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar el tipo de ajuste: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarTipoAjuste(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Tipo_Ajuste ");
            query.Append("where id_TipoAjuste = @id_TipoAjuste");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@id_TipoAjuste", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ningún tipo de ajuste. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar el tipo de ajuste: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<TipoAjuste>>> ObtenerTodasLosTiposAjuste()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select id_TipoAjuste, Descripcion_TipoAjuste, Simbolo_TipoAjuste, FechaRegistro, FechaModificacion ");
                query.Append("from Tipo_Ajuste");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var tipoAjustes = new List<TipoAjuste>();
                while (await reader.ReadAsync())
                {
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("id_TipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion_TipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("Simbolo_TipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();
                    tipoAjustes.Add(tipoAjuste);
                }
                return DBOResponse<IEnumerable<TipoAjuste>>.Ok(tipoAjustes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<TipoAjuste>>.Error("Error al obtener los Tipos de Ajustes: " + ex.Message);
            }
        }
    }
}
