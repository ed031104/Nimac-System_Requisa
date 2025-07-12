using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Modelos;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class CasaDbo
    {
        public async Task<DBOResponse<string>> CrearCasa(Casa casa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DECLARE @NuevoID NVARCHAR(50);");
            query.Append("SET @NuevoID =  FORMAT(NEXT VALUE FOR Seq_Casa, '0000');");
            query.Append("insert into Casa(Codigo_Casa, Nombre_Casa, FechaRegistro, FechaModificacion) ");
            query.Append("values(@NuevoID, @NombreCasa, @FechaRegistro, @FechaModificacion); ");
            query.Append("SELECT @NuevoID;");

            using var cmd = conn.CreateCommand();
            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NombreCasa", casa.NombreCasa);
            cmd.Parameters.AddWithValue("@FechaRegistro", casa.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", casa.FechaModificacion);
            try
            {
                var result = await cmd.ExecuteScalarAsync();
                return DBOResponse<string>.Ok(result.ToString());
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<string>.Error("Error al crear la casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Casa>>> ObtenerCasaPorCodigo(string codigo)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT Codigo_Casa, Nombre_Casa, FechaRegistro, FechaModificacion ");
                query.Append("FROM Casa");
                query.Append(" WHERE Codigo_Casa = @CodigoCasa; ");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@CodigoCasa", codigo);

                using var reader = await cmd.ExecuteReaderAsync();
                List<Casa> casas = new List<Casa>();
                if (await reader.ReadAsync())
                {
                    var casa = new Casa.Builder()
                         .SetCodigoCasa(reader.GetString(reader.GetOrdinal("Codigo_Casa")))
                         .SetNombreCasa(reader.GetString(reader.GetOrdinal("Nombre_Casa")))
                         .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                         .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                         .Build();
                    casas.Add(casa);
                }
                return DBOResponse<IEnumerable<Casa>>.Ok(casas);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Casa>>.Error("Error al obtener la casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Casa>> ObtenerCasaPorNombre(string nombre)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT Codigo_Casa, Nombre_Casa, FechaRegistro, FechaModificacion FROM Casa ");
                query.Append("WHERE Nombre_Casa = @Nombre");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    Casa casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("Codigo_Casa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("Nombre_Casa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    return DBOResponse<Casa>.Ok(casa);
                }
                else
                {
                    return DBOResponse<Casa>.Error("Casa no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Casa>.Error("Error al obtener la casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarCasa(Casa casa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Casa ");
            query.Append("SET ");
            query.Append("Nombre_Casa = @NombreCasa, ");
            query.Append("FechaModificacion = @FechaModificacion ");
            query.Append("WHERE ");
            query.Append("Codigo_Casa = @CodigoCasa");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NombreCasa", casa.NombreCasa);
            cmd.Parameters.AddWithValue("@FechaModificacion", casa.FechaModificacion);
            cmd.Parameters.AddWithValue("@CodigoCasa", casa.CodigoCasa);

            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna casa. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarCasa(string codigo)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Casa ");
            query.Append("WHERE ");
            query.Append("Codigo_Casa = @CodigoCasa");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@CodigoCasa", codigo);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ninguna casa. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Casa>>> ObtenerTodasLasCasas()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT Codigo_Casa, Nombre_Casa, FechaRegistro, FechaModificacion ");
                query.Append("FROM Casa");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var casas = new List<Casa>();
                while (await reader.ReadAsync())
                {
                    Casa casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("Codigo_Casa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("Nombre_Casa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    casas.Add(casa);
                }
                return DBOResponse<IEnumerable<Casa>>.Ok(casas);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Casa>>.Error("Error al obtener las casas: " + ex.Message);
            }
        }
    }
}
