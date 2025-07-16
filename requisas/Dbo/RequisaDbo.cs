using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.data;
using Modelos.Dto;
using Modelos.requisas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class RequisaDbo
    {
        public RequisaDbo() { }

        public async Task<DBOResponse<int>> CrearRequisa(Requisa requisa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("INSERT INTO Requisa (FechaRegistro, Descripcion, idSucursal , Estado) ");
            query.Append("VALUES (@FechaRegistro, @Descripcion, @IdSucursal, @Estado); ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@FechaRegistro", requisa.FechaRegistro);
            cmd.Parameters.AddWithValue("@Descripcion", requisa.Descripcion);
            cmd.Parameters.AddWithValue("@IdSucursal", requisa.Sucursal.NumeroSucursal);
            cmd.Parameters.AddWithValue("@Estado", requisa.Estado);

            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear la Requisa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Requisa>> ObtenerRequisaPorId(string id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT r.N_DocumentoRequisa, r.FechaRegistro, r.Descripcion, r.Estado, r.IdSucursal, s.Numero_Sucursal, s.Nombre_Sucursal, s.FechaRegistro, s.FechaModificacion, c.Codigo_Casa, c.FechaModificacion, c.FechaRegistro, c.Nombre_Casa from Requisa r  ");
                query.Append("LEFT join Sucursal s on r.IdSucursal = s.Numero_Sucursal ");
                query.Append("LEFT join Casa c on c.Codigo_Casa = s.Codigo_Casa ");
                query.Append("where  r.N_DocumentoRequisa = @NDocumentoRequisa ");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NDocumentoRequisa", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(0))
                        .SetFechaRegistro(reader.GetDateTime(1))
                        .SetDescripcion(reader.GetString(2))
                        .SetEstado(Convert.ToBoolean(reader.GetBoolean(3)))
                        .Build();

                    return DBOResponse<Requisa>.Ok(requisa);
                }
                else
                {
                    return DBOResponse<Requisa>.Error("Requisa no encontrada.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Requisa>.Error("Error al obtener la Requisa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarRequisa(Requisa requisa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Requisa ");
            query.Append("SET ");
            query.Append("Descripcion = @Descripcion, ");
            query.Append("Estado = @Estado ");
            query.Append("WHERE N_DocumentoRequisa = @NumeroRequisa; ");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();
            cmd.Parameters.AddWithValue("@Descripcion", requisa.Descripcion);
            cmd.Parameters.AddWithValue("@Estado", requisa.Estado);
            cmd.Parameters.AddWithValue("@idSucursal", requisa.Sucursal.NumeroSucursal);
            cmd.Parameters.AddWithValue("@NumeroRequisa", requisa.NDocumentoRequisa);

            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna Requisa. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la Requisa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarRequisa(string id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("delete from Requisa ");
            query.Append("where N_DocumentoRequisa = @NumeroRequisa;");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@NumeroRequisa", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ninguna Requisa. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la Requisa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Requisa>>> ObtenerTodasLasRequisas()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select r.N_DocumentoRequisa, r.FechaRegistro, r.Descripcion, r.Estado, r.IdSucursal, s.Numero_Sucursal, s.Nombre_Sucursal, s.FechaRegistro, s.FechaModificacion, c.Codigo_Casa, c.FechaModificacion, c.FechaRegistro, c.Nombre_Casa from Requisa r  ");
                query.Append("inner join Sucursal s on r.IdSucursal = s.Numero_Sucursal ");
                query.Append("inner join Casa c on c.Codigo_Casa = s.Codigo_Casa ");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var requisas = new List<Requisa>();
                while (await reader.ReadAsync())
                {
                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(9))
                        .SetFechaModificacion(reader.GetDateTime(10))
                        .SetFechaRegistro(reader.GetDateTime(11))
                        .SetNombreCasa(reader.GetString(12))
                        .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(5))
                        .SetNombreSucursal(reader.GetString(6))
                        .SetFechaRegistro(reader.GetDateTime(7))
                        .SetFechaModificacion(reader.GetDateTime(8))
                        .SetCasa(casa)
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(0))
                        .SetFechaRegistro(reader.GetDateTime(1))
                        .SetDescripcion(reader.GetString(2))
                        .SetEstado(Convert.ToBoolean(reader.GetString(3)))
                        .SetSucursal(sucursal)
                        .Build();
                    requisas.Add(requisa);
                }
                return DBOResponse<IEnumerable<Requisa>>.Ok(requisas);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Requisa>>.Error("Error al obtener la Requisa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<RequisaJoinEstado>>> ObtenerRequisasagrupadaPorEstado()
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();
            try
            {

                string query = @"
                    SELECT 
                        r.N_DocumentoRequisa as [NumeroRequisa],
                        r.Descripcion as [DescripcionRequisa],
	                    rh.CreadoPor [RequisaCreadaPor],
	                    (
		                    select 
			                    COUNT(*) 
		                    from 
			                    Requisa_Ajuste ra
		                    where 
			                    ra.id_Requisa = r.N_DocumentoRequisa
	                    ) AS [CantidadAjustes],
	                    (
		                    select 
			                    SUM(ra.costoPromedioExtendido)
		                    from 
			                    Requisa_Ajuste ra
		                    where 
			                    ra.id_Requisa = r.N_DocumentoRequisa
	                    ) as [Costototal],
                        r.FechaRegistro as [FechaRegistroRequisa],
                        r.Estado as [EstadoRequisa],
                        er.id AS [IdEstado],
                        er.descripcion AS [DescripcionEstado],
                        er.fechaCreacion AS [FechaCreacionEstado],
	                    er.fechaModificacion AS [FechaModificacionEstado],
	                    er.creadoPor AS [EstadoCreadoPor]
                    FROM Requisa r
                    JOIN Requisa_Historial rh 
                        ON r.N_DocumentoRequisa = rh.N_DocumentoRequisa
                    JOIN EstadoRequisa er 
                        ON rh.id_estado = er.id
                    WHERE rh.FechaCreacion = (
                        SELECT MAX(rh2.FechaCreacion)
                        FROM Requisa_Historial rh2
                        WHERE rh2.N_DocumentoRequisa = rh.N_DocumentoRequisa
                    )
                    ";
                using var cmd = conn.CreateCommand();
                cmd.CommandText = query;

                using var reader = await cmd.ExecuteReaderAsync();
                var requisasConEstado = new List<RequisaJoinEstado>();

                while (await reader.ReadAsync())
                {
                    var requisa = new RequisaJoinEstado.Builder()
                        .SetCodigoRequisa(reader.GetString(reader.GetOrdinal("NumeroRequisa")))
                        .SetDescripcionRequisa(reader.GetString(reader.GetOrdinal("DescripcionRequisa")))
                        .SetUsuario(reader.GetString(reader.GetOrdinal("RequisaCreadaPor")))
                        .SetCantidadAjuste(reader.GetInt32(reader.GetOrdinal("CantidadAjustes")))
                        .SetCostoTotal(reader.GetDecimal(reader.GetOrdinal("Costototal")))
                        .SetEstadoRequisa(
                            new Estado.Builder()
                                .SetIdEstado(reader.GetInt32(reader.GetOrdinal("IdEstado")))
                                .SetDescripcion(reader.GetString(reader.GetOrdinal("DescripcionEstado")))
                                .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaCreacionEstado")))
                                .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacionEstado")))
                                .SetCreadoPor(reader.GetString(reader.GetOrdinal("EstadoCreadoPor")))
                                .Build()
                        )
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("FechaRegistroRequisa")))
                        .Build();
                    requisasConEstado.Add(requisa);
                }
                return DBOResponse<IEnumerable<RequisaJoinEstado>>.Ok(requisasConEstado);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<RequisaJoinEstado>>.Error("Error al obtener las Requisas con estado: " + ex.Message);
            }
        }
    }
}
