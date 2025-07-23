using Dbo.utils;
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

            string query = @"
            Insert into Parte_Sucursal(Numero_Parte, CostoUnitario, Stock, FechaRegistro, FechaModificacion, IdSucursal, idCasa, DescripcionParte) 
            VALUES(@NumeroParte, @CostoUnitario, @Stock, @FechaRegistro, @FechaModificacion, @IdSucursal, @idCasa, @descripcion);
            SELECT SCOPE_IDENTITY();";

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NumeroParte", parteSucursal.Parte);
            cmd.Parameters.AddWithValue("@CostoUnitario", parteSucursal.CostoUnitario);
            cmd.Parameters.AddWithValue("@Stock", parteSucursal.Stock);
            cmd.Parameters.AddWithValue("@FechaRegistro", parteSucursal.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", parteSucursal.FechaModificacion);
            cmd.Parameters.AddWithValue("@IdSucursal", parteSucursal.Sucursal);
            cmd.Parameters.AddWithValue("@idCasa", parteSucursal.Casa);
            cmd.Parameters.AddWithValue("@descripcion", parteSucursal.Descripcion);

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
                string query = @"
                    Insert into Parte_Sucursal(Numero_Parte, CostoUnitario, Stock, FechaRegistro, FechaModificacion, IdSucursal, idCasa, DescripcionParte) 
                    VALUES(@NumeroParte, @CostoUnitario, @Stock, @FechaRegistro, @FechaModificacion, @IdSucursal, @idCasa, @descripcion);
                    SELECT SCOPE_IDENTITY();
                ";

                foreach (var ps in parteSucursal)
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@NumeroParte", ps.Parte);
                    cmd.Parameters.AddWithValue("@CostoUnitario", ps.CostoUnitario);
                    cmd.Parameters.AddWithValue("@Stock", ps.Stock);
                    cmd.Parameters.AddWithValue("@FechaRegistro", ps.FechaRegistro);
                    cmd.Parameters.AddWithValue("@FechaModificacion", ps.FechaModificacion);
                    cmd.Parameters.AddWithValue("@IdSucursal", ps.Sucursal);
                    cmd.Parameters.AddWithValue("@idCasa", ps.Casa);
                    cmd.Parameters.AddWithValue("@descripcion", ps.Descripcion);

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
	                ps.FechaRegistro,
	                ps.FechaModificacion,
	                ps.Numero_Parte,
	                ps.IdSucursal,
	                ps.idCasa,
	                ps.DescripcionParte
                from 
	                Parte_Sucursal ps
                where  
                    ps.Numero_Parte = @NumeroParte
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NumeroParte", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                var listParteSucursal = new List<ParteSucursal>();

                while (await reader.ReadAsync())
                {
                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.validateTypeData<int>("id_ParteCasa"))
                        .SetParte(reader.validateTypeData<string>("Numero_Parte"))
                        .SetSucursal(reader.validateTypeData<string>("IdSucursal"))
                        .SetCostoUnitario(reader.validateTypeData<decimal>("CostoUnitario"))
                        .SetCantidad(reader.validateTypeData<int>("Stock"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("FechaRegistro"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("FechaModificacion"))
                        .SetCasa(reader.validateTypeData<string>("idCasa"))
                        .SetDescripcion(reader.validateTypeData<string>("DescripcionParte"))
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
                    fechaModificacion = @FechaModificacion
                where id_ParteCasa = @IdParteCasa; ";

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@CostoUnitario", parteSucursal.CostoUnitario);
            cmd.Parameters.AddWithValue("@Stock", parteSucursal.Stock);
            cmd.Parameters.AddWithValue("@FechaModificacion", parteSucursal.FechaModificacion);
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
	                ps.FechaRegistro,
	                ps.FechaModificacion,
	                ps.Numero_Parte,
	                ps.IdSucursal,
	                ps.idCasa,
	                ps.DescripcionParte
                from 
	                Parte_Sucursal ps
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                await using var reader = await cmd.ExecuteReaderAsync();

                var partesSucursal = new List<ParteSucursal>();
                while (await reader.ReadAsync())
                {
                    var parteSucursal = new ParteSucursal.Builder()
                         .SetIdParteSucursal(reader.validateTypeData<int>("id_ParteCasa"))
                         .SetParte(reader.validateTypeData<string>("Numero_Parte"))
                         .SetSucursal(reader.validateTypeData<string>("IdSucursal"))
                         .SetCostoUnitario(reader.validateTypeData<decimal>("CostoUnitario"))
                         .SetCantidad(reader.validateTypeData<int>("Stock"))
                         .SetFechaRegistro(reader.validateTypeData<DateTime>("FechaRegistro"))
                         .SetFechaModificacion(reader.validateTypeData<DateTime>("FechaModificacion"))
                         .SetCasa(reader.validateTypeData<string>("idCasa"))
                         .SetDescripcion(reader.validateTypeData<string>("DescripcionParte"))
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
