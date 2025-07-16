using Modelos;
using Modelos.data;
using Modelos.requisas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class RequisaEstadoDBO
    {

        public async Task<DBOResponse<bool>> crearEstadoRequisa(RequisaEstado requisaEstado)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();
            try
            {
                using var cmd = conn.CreateCommand();
                string query = @"
                INSERT INTO Requisa_Historial(N_DocumentoRequisa, id_estado, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                Values(@IdRequisa, @IdEstado, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@IdRequisa", requisaEstado.Requisa.NDocumentoRequisa);
                cmd.Parameters.AddWithValue("@IdEstado", requisaEstado.Estado.IdEstado);
                cmd.Parameters.AddWithValue("@CreadoPor", requisaEstado.CreadoPor ?? string.Empty);
                cmd.Parameters.AddWithValue("@ModificadoPor", requisaEstado.ModificadoPor ?? string.Empty);
                cmd.Parameters.AddWithValue("@FechaCreacion", requisaEstado.FechaCreacion == DateTime.MinValue ? DateTime.Now : requisaEstado.FechaCreacion);
                cmd.Parameters.AddWithValue("@FechaModificacion", requisaEstado.FechaModificacion == DateTime.MinValue ? DateTime.Now : requisaEstado.FechaModificacion);

                var result = await cmd.ExecuteNonQueryAsync();

                if (result <= 0)
                {
                    return DBOResponse<bool>.Error("No se pudo crear el estado de la requisa.");
                }

                return DBOResponse<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return DBOResponse<bool>.Error(ex.Message);
            }
        }

        public async Task<DBOResponse<List<RequisaEstado>>> obtenerEstadosRequisaPorIdRequisa(string nDocumentoRequisa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();
            try
            {
                using var cmd = conn.CreateCommand();
                string query = @"
                    SELECT 
	                    rh.id_Requisa_Historial [IdRequisaHistorial], rh.CreadoPor [RequisaHistorialCreadaPor], rh.ModificadoPor [RequisaHistorialModificadaPor], rh.FechaCreacion [FechaCreacionRequisaHistorial], rh.FechaModificacion [FechaModificacionRequisaHistorial],
	                    r.N_DocumentoRequisa [IdRequisa], r.FechaRegistro [FechaRegistroRequisa], r.Estado [EstadoRequisa], r.Descripcion [DescripcionRequisa] ,
	                    er.id [IdEstadoRequisa], er.descripcion [DescripcionEstadoRequisa], er.fechaCreacion [FechaCreacionEstadoRequisa], er.fechaModificacion [FechaModificacionEstadoRequisa], er.creadoPor [CreadaPorEstadoRequisa] 
                    FROM Requisa_Historial rh
                    JOIN requisa r on r.N_DocumentoRequisa = rh.N_DocumentoRequisa
                    JOIN EstadoRequisa er on er.id = rh.id_estado
                    WHERE rh.N_DocumentoRequisa = @NDocumentoRequisa         
                ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@NDocumentoRequisa", nDocumentoRequisa);
                using var reader = await cmd.ExecuteReaderAsync();

                var estados = new List<RequisaEstado>();

                while (await reader.ReadAsync())
                {
                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(reader.GetOrdinal("IdRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistroRequisa")))
                        .SetEstado(reader.GetBoolean(reader.GetOrdinal("EstadoRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("DescripcionRequisa")))
                        .Build();
                    var estado = new Estado.Builder()
                        .SetIdEstado(reader.GetInt32(reader.GetOrdinal("IdEstadoRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("DescripcionEstadoRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaCreacionEstadoRequisa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacionEstadoRequisa")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("CreadaPorEstadoRequisa")))
                        .Build();

                    estados.Add(new RequisaEstado.Builder()
                        .SetIdEstadoRequisa(reader.GetInt32(reader.GetOrdinal("IdRequisaHistorial")))
                        .SetRequisa(requisa)
                        .SetEstado(estado)
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("RequisaHistorialCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("RequisaHistorialModificadaPor")))
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("FechaCreacionRequisaHistorial")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacionRequisaHistorial")))
                        .Build());
                }
                return DBOResponse<List<RequisaEstado>>.Ok(estados);
            }
            catch (Exception ex)
            {
                return DBOResponse<List<RequisaEstado>>.Error(ex.Message);
            }
        }

        public async Task<DBOResponse<List<RequisaEstado>>> obtenerEstadosRequisa()
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();
            try
            {
                using var cmd = conn.CreateCommand();
                string query = @"
                    SELECT 
	                    rh.id_Requisa_Historial [IdRequisaHistorial], rh.CreadoPor [RequisaHistorialCreadaPor], rh.ModificadoPor [RequisaHistorialModificadaPor], rh.FechaCreacion [FechaCreacionRequisaHistorial], rh.FechaModificacion [FechaModificacionRequisaHistorial],
	                    r.N_DocumentoRequisa [IdRequisa], r.FechaRegistro [FechaRegistroRequisa], r.Estado [EstadoRequisa], r.Descripcion [DescripcionRequisa] ,
	                    er.id [IdEstadoRequisa], er.descripcion [DescripcionEstadoRequisa], er.fechaCreacion [FechaCreacionEstadoRequisa], er.fechaModificacion [FechaModificacionEstadoRequisa], er.creadoPor [CreadaPorEstadoRequisa] 
                    FROM Requisa_Historial rh
                    JOIN requisa r on r.N_DocumentoRequisa = rh.N_DocumentoRequisa
                    JOIN EstadoRequisa er on er.id = rh.id_estado   
                    ORDER BY rh.N_DocumentoRequisa desc
                ";
                cmd.CommandText = query;
                using var reader = await cmd.ExecuteReaderAsync();

                var estados = new List<RequisaEstado>();

                while (await reader.ReadAsync())
                {
                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(reader.GetOrdinal("IdRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaRegistroRequisa")))
                        .SetEstado(reader.GetBoolean(reader.GetOrdinal("EstadoRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("DescripcionRequisa")))
                        .Build();
                    var estado = new Estado.Builder()
                        .SetIdEstado(reader.GetInt32(reader.GetOrdinal("IdEstadoRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("DescripcionEstadoRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("FechaCreacionEstadoRequisa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacionEstadoRequisa")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("CreadaPorEstadoRequisa")))
                        .Build();

                    estados.Add(new RequisaEstado.Builder()
                        .SetIdEstadoRequisa(reader.GetInt32(reader.GetOrdinal("IdRequisaHistorial")))
                        .SetRequisa(requisa)
                        .SetEstado(estado)
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("RequisaHistorialCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("RequisaHistorialModificadaPor")))
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("FechaCreacionRequisaHistorial")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("FechaModificacionRequisaHistorial")))
                        .Build());
                }
                return DBOResponse<List<RequisaEstado>>.Ok(estados);
            }
            catch (Exception ex)
            {
                return DBOResponse<List<RequisaEstado>>.Error(ex.Message);
            }
        }


    }
}
