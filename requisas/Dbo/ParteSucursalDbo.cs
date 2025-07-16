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
    public class ParteSucursalDbo
    {
        public ParteSucursalDbo() { }

        public async Task<DBOResponse<int>> CrearParteSucursal(ParteSucursal parteSucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("Insert into Parte_Sucursal(Numero_Parte, CostoUnitario, Stock, FechaRegistro, FechaModificacion, IdSucursal) ");
            query.Append("VALUES(@NumeroParte, @CostoUnitario, @Stock, @FechaRegistro, @FechaModificacion, @IdSucursal); ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NumeroParte", parteSucursal.Parte.NumeroParte);
            cmd.Parameters.AddWithValue("@CostoUnitario", parteSucursal.CostoUnitario);
            cmd.Parameters.AddWithValue("@Stock", parteSucursal.Stock);
            cmd.Parameters.AddWithValue("@FechaRegistro", parteSucursal.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", parteSucursal.FechaModificacion);
            cmd.Parameters.AddWithValue("@IdSucursal", parteSucursal.Sucursal.NumeroSucursal);

            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear la Parte-casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> CrearParteSucursalesTransaction(List<ParteSucursal> parteSucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            using SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                var query = @"
                    Insert into Parte_Sucursal(Numero_Parte, CostoUnitario, Stock, FechaRegistro, FechaModificacion, IdSucursal) 
                    VALUES(@NumeroParte, @CostoUnitario, @Stock, @FechaRegistro, @FechaModificacion, @IdSucursal)
                ";

                foreach (var ps in parteSucursal)
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@NumeroParte", ps.Parte.NumeroParte);
                    cmd.Parameters.AddWithValue("@CostoUnitario", ps.CostoUnitario);
                    cmd.Parameters.AddWithValue("@Stock", ps.Stock);
                    cmd.Parameters.AddWithValue("@FechaRegistro", ps.FechaRegistro);
                    cmd.Parameters.AddWithValue("@FechaModificacion", ps.FechaModificacion);
                    cmd.Parameters.AddWithValue("@IdSucursal", ps.Sucursal.NumeroSucursal);
                    
                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                transaction.Rollback();
                return DBOResponse<bool>.Error("Error al crear la Parte-casa: " + ex.Message);
            }
        }


        public async Task<DBOResponse<IEnumerable<ParteSucursal>>> ObtenerParteSucursalPorIdParte(string id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                select 
                    ps.id_ParteCasa, 
                    ps.CostoUnitario, 
                    ps.Stock, 
                    ps.fechaRegistro, 
                    ps.fechaModificacion, 
                    s.Numero_Sucursal , 
                    s.Nombre_Sucursal, 
                    s.FechaRegistro as 'fechaRegistroSucursal', 
                    s.FechaModificacion as 'fechaModificacionSucursal', 
                    c.Codigo_Casa, 
                    c.Nombre_Casa, 
                    c.FechaRegistro as 'fechaRegistroCasa', 
                    c.FechaModificacion as 'fechaModificacionCasa', 
                    p.Numero_Parte, 
                    p.Descripcion_Parte, 
                    p.FechaRegistro as 'fechaRegistroParte', 
                    p.FechaModificacion as 'fechaModificacionParte' 
                from 
                    Parte_Sucursal as ps
                inner JOIN 
                    Sucursal as s on s.Numero_Sucursal = ps.IdSucursal
                INNER join 
                    Casa as c on c.Codigo_Casa = s.Codigo_Casa 
                inner JOIN 
                    Parte as p on p.Numero_Parte = ps.Numero_Parte 
                where 
                    p.Numero_Parte = @NumeroParte
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NumeroParte", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                var listParteSucursal = new List<ParteSucursal>();

                while (await reader.ReadAsync())
                {
                    var Parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("Numero_Parte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("Descripcion_Parte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParte")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionParte")))
                        .Build();
                    var Casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("Codigo_Casa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("Nombre_Casa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();
                    var Sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("Numero_Sucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("Nombre_Sucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(Casa)
                        .Build();
                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.GetInt32(reader.GetOrdinal("id_ParteCasa")))
                        .SetParte(Parte)
                        .SetSucursal(Sucursal)
                        .SetCostoUnitario(reader.GetDecimal(reader.GetOrdinal("CostoUnitario")))
                        .SetCantidad(reader.GetInt32(reader.GetOrdinal("Stock")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacion")))
                        .Build();
                    listParteSucursal.Add(parteSucursal);
                }
                return DBOResponse<IEnumerable<ParteSucursal>>.Ok(listParteSucursal);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<ParteSucursal>>.Error("Error al obtener la Parte Casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarParteSucursal(ParteSucursal parteSucursal)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = @"
                UPDATE Parte_Sucursal
                set
                    CostoUnitario = @CostoUnitario, 
                    Stock = @Stock,  
                    fechaModificacion = @FechaModificacion, 
                    IdSucursal = @IdSucursal
                where id_ParteCasa = @IdParteCasa; ";

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@CostoUnitario", parteSucursal.CostoUnitario);
            cmd.Parameters.AddWithValue("@Stock", parteSucursal.Stock);
            cmd.Parameters.AddWithValue("@FechaModificacion", parteSucursal.FechaModificacion);
            cmd.Parameters.AddWithValue("@IdSucursal", parteSucursal.Sucursal.NumeroSucursal);
            cmd.Parameters.AddWithValue("@IdParteCasa", parteSucursal.IdParteSucursal);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna Parte Sucursal. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la Parte Sucursal: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarParteSucursal(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("delete from Parte_Sucursal ");
            query.Append("where id_ParteCasa = @idParteCasa;");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@idParteCasa", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ninguna Parte Sucursal. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la Parte Sucursal: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<ParteSucursal>>> ObtenerTodasLasPartesSucursal()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                select 
                    ps.id_ParteCasa, 
                    ps.CostoUnitario, 
                    ps.Stock, 
                    ps.fechaRegistro, 
                    ps.fechaModificacion, 
                    s.Numero_Sucursal , 
                    s.Nombre_Sucursal, 
                    s.FechaRegistro as 'fechaRegistroSucursal', 
                    s.FechaModificacion as 'fechaModificacionSucursal', 
                    c.Codigo_Casa, 
                    c.Nombre_Casa, 
                    c.FechaRegistro as 'fechaRegistroCasa', 
                    c.FechaModificacion as 'fechaModificacionCasa', 
                    p.Numero_Parte, 
                    p.Descripcion_Parte, 
                    p.FechaRegistro as 'fechaRegistroParte', 
                    p.FechaModificacion as 'fechaModificacionParte' 
                from 
                    Parte_Sucursal as ps
                inner JOIN 
                    Sucursal as s on s.Numero_Sucursal = ps.IdSucursal
                INNER join 
                    Casa as c on c.Codigo_Casa = s.Codigo_Casa 
                inner JOIN 
                    Parte as p on p.Numero_Parte = ps.Numero_Parte ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                await using var reader = await cmd.ExecuteReaderAsync();

                var partesSucursal = new List<ParteSucursal>();
                while (await reader.ReadAsync())
                {
                    var Parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("Numero_Parte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("Descripcion_Parte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParte")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionParte")))
                        .Build();
                    var Casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("Codigo_Casa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("Nombre_Casa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();
                    var Sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("Numero_Sucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("Nombre_Sucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(Casa)
                        .Build();
                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.GetInt32(reader.GetOrdinal("id_ParteCasa")))
                        .SetParte(Parte)
                        .SetSucursal(Sucursal)
                        .SetCostoUnitario(reader.GetDecimal(reader.GetOrdinal("CostoUnitario")))
                        .SetCantidad(reader.GetInt32(reader.GetOrdinal("Stock")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacion")))
                        .Build();
                    partesSucursal.Add(parteSucursal);
                }
                return DBOResponse<IEnumerable<ParteSucursal>>.Ok(partesSucursal);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<ParteSucursal>>.Error("Error al obtener la Parte Casa: " + ex.Message);
            }
        }
    }
}
