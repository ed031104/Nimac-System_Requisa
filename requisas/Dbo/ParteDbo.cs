using Microsoft.Data.SqlClient;
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
    public class ParteDbo
    {
        public ParteDbo() {}

        public async Task<DBOResponse<string>> CrearParte(Parte parte)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("insert into Parte (Numero_Parte, Descripcion_Parte, FechaRegistro, FechaModificacion) ");
            query.Append("VALUES(@Numero_Parte, @Descripcion_Parte, @FechaRegistro, @FechaModificacion); ");
            query.Append("SELECT @Numero_Parte;");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Numero_Parte", parte.NumeroParte);
            cmd.Parameters.AddWithValue("@Descripcion_Parte", parte.DescripcionParte);
            cmd.Parameters.AddWithValue("@FechaRegistro", parte.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", parte.FechaModificacion);
            try
            {
                var response = await cmd.ExecuteScalarAsync();
                var codigoParte = Convert.ToString(response);
                return DBOResponse<string>.Ok(codigoParte);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<string>.Error("Error al crear la Parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Parte>> ObtenerPartePorId(string id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select Numero_Parte, Descripcion_Parte, FechaRegistro, FechaModificacion from Parte ");
                query.Append("WHERE Numero_Parte = @NumeroParte");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NumeroParte", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var Parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("Numero_Parte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("Descripcion_Parte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    return DBOResponse<Parte>.Ok(Parte);
                }
                else
                {
                    return DBOResponse<Parte>.Error("Parte no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Parte>.Error("Error al obtener la Parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Parte>>> ObtenerPartesPorNombre(string nombre)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select Numero_Parte, Descripcion_Parte, FechaRegistro, FechaModificacion ");
                query.Append("from Parte ");
                query.Append("where Descripcion_Parte = @Decripcion");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Decripcion", nombre);

                await using var reader = await cmd.ExecuteReaderAsync();

                var partes = new List<Parte>();
                while (await reader.ReadAsync())
                {
                    var parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("Numero_Parte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("Descripcion_Parte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    partes.Add(parte);
                }
                return DBOResponse<IEnumerable<Parte>>.Ok(partes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Parte>>.Error("Error al obtener las Partes: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarParte(Parte parte)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Parte ");
            query.Append("SET ");
            query.Append("Descripcion_Parte = @Descripcion_Parte, ");
            query.Append("FechaModificacion = @FechaModificacion ");
            query.Append("WHERE ");
            query.Append("Numero_Parte = @Numero_Parte");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Descripcion_Parte", parte.DescripcionParte);
            cmd.Parameters.AddWithValue("@FechaModificacion", parte.FechaModificacion);
            cmd.Parameters.AddWithValue("@Numero_Parte", parte.NumeroParte);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna parte. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarParte(string id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Parte ");
            query.Append("WHERE ");
            query.Append("Numero_Parte = @NumeroParte");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NumeroParte", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ninguna parte. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Parte>>> ObtenerTodasLasPartes()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select Numero_Parte, Descripcion_Parte, FechaRegistro, FechaModificacion ");
                query.Append("from Parte");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var partes = new List<Parte>();
                while (await reader.ReadAsync())
                {
                    var parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("Numero_Parte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("Descripcion_Parte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacion")))
                        .Build();

                    partes.Add(parte);
                }
                return DBOResponse<IEnumerable<Parte>>.Ok(partes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Parte>>.Error("Error al obtener las Partes: " + ex.Message);
            }
        }
    }
}
