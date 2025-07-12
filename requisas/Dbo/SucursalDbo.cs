using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.data;
using System.Text;

namespace Dbo
{
    public class SucursalDbo
    {
        public SucursalDbo() { }


        public async Task<DBOResponse<string>> CrearSucursal(Sucursal sucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("insert into Sucursal (Numero_Sucursal, Nombre_Sucursal, FechaRegistro, FechaModificacion, Codigo_casa) ");
            query.Append("values(@Numero_Sucursal, @Nombre_Sucursal, @FechaRegistro, @FechaModificacion, @CodigoCasa); ");
            query.Append("SELECT @Numero_Sucursal;");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Numero_Sucursal", sucursal.NumeroSucursal);
            cmd.Parameters.AddWithValue("@Nombre_Sucursal", sucursal.NombreSucursal);
            cmd.Parameters.AddWithValue("@FechaRegistro", sucursal.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", sucursal.FechaModificacion);
            cmd.Parameters.AddWithValue("@CodigoCasa", sucursal.Casa.CodigoCasa);
            try
            {
                var result = await cmd.ExecuteScalarAsync();
                var numeroSucursal = result.ToString();
                if (string.IsNullOrEmpty(numeroSucursal))
                
                {
                    return DBOResponse<string>.Error("No se pudo crear la sucursal. Verifique los datos.");
                }

                return DBOResponse<string>.Ok(numeroSucursal);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<string>.Error("Error al crear el Rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Sucursal>> ObtenerSucursalPorCodigoCasa(string codigoCasa)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select *  ");
                query.Append("from Sucursal ");
                query.Append("INNER JOIN Sucursal ON Casa.Codigo_Casa = Sucursal.Codigo_casa ");
                query.Append("WHERE Casa.Codigo_Casa = @CodigoCasa");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@CodigoCasa", codigoCasa);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(5))
                        .SetNombreCasa(reader.GetString(6))
                        .SetFechaRegistro(reader.GetDateTime(7))
                        .SetFechaModificacion(reader.GetDateTime(8))
                        .Build();

                    Sucursal sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(0))
                        .SetNombreSucursal(reader.GetString(1))
                        .SetFechaRegistro(reader.GetDateTime(2))
                        .SetFechaModificacion(reader.GetDateTime(3))
                        .SetCasa(casa)
                        .Build();

                    return DBOResponse<Sucursal>.Ok(sucursal);
                }
                else
                {
                    return DBOResponse<Sucursal>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Sucursal>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Sucursal>>> ObtenerSucursalPorNombre(string nombre)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select * from Sucursal ");
                query.Append("WHERE Nombre_Sucursal = @Nombre");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                await using var reader = await cmd.ExecuteReaderAsync();

                var sucursales = new List<Sucursal>();
                while (await reader.ReadAsync())
                {
                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(5))
                        .SetNombreCasa(reader.GetString(6))
                        .SetFechaRegistro(reader.GetDateTime(7))
                        .SetFechaModificacion(reader.GetDateTime(8))
                        .Build();

                    Sucursal sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(0))
                        .SetNombreSucursal(reader.GetString(1))
                        .SetFechaRegistro(reader.GetDateTime(2))
                        .SetFechaModificacion(reader.GetDateTime(3))
                        .SetCasa(casa)
                        .Build();
                    sucursales.Add(sucursal);
                }
                    return DBOResponse<IEnumerable<Sucursal>>.Ok(sucursales);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Sucursal>>.Error("Error al obtener las sucursales: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarSucursal(Sucursal sucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("update Sucursal ");
            query.Append("SET ");
            query.Append("Nombre_Sucursal = @Nombre_Sucursal, ");
            query.Append("FechaModificacion = @FechaModificacion, ");
            query.Append("Codigo_casa = @CodigoCasa ");
            query.Append("WHERE ");
            query.Append("Numero_Sucursal = @Numero_Sucursal");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Nombre_Sucursal", sucursal.NombreSucursal);
            cmd.Parameters.AddWithValue("@FechaModificacion", sucursal.FechaModificacion);
            cmd.Parameters.AddWithValue("@Numero_Sucursal", sucursal.NumeroSucursal);
            cmd.Parameters.AddWithValue("@CodigoCasa", sucursal.Casa.CodigoCasa);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna sucursal. Verifique el Número de sucursal.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la Sucursal: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarSucursal(string numeroSucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Sucursal ");
            query.Append("WHERE ");
            query.Append("Numero_Sucursal = @Numero_Sucursal");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Numero_Sucursal", numeroSucursal);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó la sucursal. Verifique el Número de sucursal.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la sucursal: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Sucursal>>> ObtenerTodasLasSucursales()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT * ");
                query.Append("FROM Sucursal ");
                query.Append("INNER JOIN Casa ON Casa.Codigo_Casa = Sucursal.Codigo_casa ");


                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var sucursales = new List<Sucursal>();

                while (await reader.ReadAsync())
                {
                    var casa = new Casa.Builder()
                         .SetCodigoCasa(reader.GetString(5))
                         .SetNombreCasa(reader.GetString(6))
                         .SetFechaRegistro(reader.GetDateTime(7))
                         .SetFechaModificacion(reader.GetDateTime(8))
                         .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(0))
                        .SetNombreSucursal(reader.GetString(1))
                        .SetFechaRegistro(reader.GetDateTime(2))
                        .SetFechaModificacion(reader.GetDateTime(3))
                        .SetCasa(casa)
                        .Build();
                    sucursales.Add(sucursal);
                }

                return DBOResponse<IEnumerable<Sucursal>>.Ok(sucursales);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Sucursal>>.Error("Error al obtener las sucursales: " + ex.Message);
            }
        }
    }
}
