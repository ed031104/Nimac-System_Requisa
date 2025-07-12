using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class RequisaAjusteDbo
    {
        public RequisaAjusteDbo()
        {
        }

        //public async Task<DBOResponse<int>> CrearRequisaAjuste(RequisaAjuste requisaAjuste)
        //{
        //    await using var conn = Conexion.conexion();
        //    await conn.OpenAsync();
        //    try
        //    {
        //        string query = @"
        //        INSERT INTO Requisa_Ajuste(id_Tipo_Ajuste, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion, Monto, Descripcion, Id_parte_Sucursal, costoPromedio, costoPromedioExtendido, id_Requisa)
        //        values(@idTipoAjuste, @creadoPor, @modificadoPor, @fechaCreacion, @fechaModificacion, @monto, @descripcion, @idParteSucursal, @costoPromedio, @costoPromedioExtendido, @idRequisa)";

        //        using var cmd = conn.CreateCommand();
        //        cmd.CommandText = query;

        //        var result = await cmd.ExecuteScalarAsync();
                
        //    }
        //    catch (SqlException ex)
        //    {
        //        return DBOResponse<int>.Error("Error al crear la Requisa con Ajustes: " + ex.Message);
        //    }
        //}

        public async Task<DBOResponse<IEnumerable<RequisaAjuste>>> ObtenerRequisaAjustePor(string numeroDocumetoRequisa)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                    select 
	                    ra.id_Requisa_Ajuste [idRequisaAjuste],
	                    ra.CreadoPor [requisaAjusteCreadaPor],
	                    ra.ModificadoPor [requisaAjusteModificadaPor],
	                    ra.FechaCreacion [fechaCreacionRequisaAjuste],
	                    ra.FechaModificacion [fechaModificacionRequisaAjuste],
                        ra.Monto [montoAjuste],
	                    r.N_DocumentoRequisa [idRequisa],
	                    r.Descripcion [descripcionRequisa],
	                    r.Estado [estadoRequisa],
	                    r.FechaRegistro [fechaRegistroRequisa],
	                    s.Numero_Sucursal [idSucursal],
	                    s.Nombre_Sucursal [nombreSucursal],
	                    s.FechaRegistro [fechaRegistroSucursal],
	                    s.FechaModificacion [fechaModificacionSucursal],
	                    c.Codigo_Casa [idCasa],
	                    c.Nombre_Casa [nombreCasa],
	                    c.FechaRegistro [fechaRegistroCasa],
	                    c.FechaModificacion [fechaModificacionCasa],
	                    ta.id_TipoAjuste [idTipoAjuste],
	                    ta.Descripcion_TipoAjuste [descripcionTipoAjuste],
	                    ta.Simbolo_TipoAjuste [simboloTipoAjuste],
	                    ta.FechaRegistro [fechaRegistroTipoAjuste],
	                    ta.FechaModificacion [fechaModificacionTipoAjuste]
                    from Requisa_Ajuste ra
                    inner join Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                    inner join Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                    inner join Sucursal s on s.Numero_Sucursal = r.IdSucursal
                    inner join Casa c on c.Codigo_casa = s.Codigo_Casa
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NDocumentoRequisa", numeroDocumetoRequisa);

                await using var reader = await cmd.ExecuteReaderAsync();

                var requisaAjustes = new List<RequisaAjuste>();

                while (await reader.ReadAsync())
                {
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("idTipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionTipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("simboloTipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroTipoAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionTipoAjuste")))
                        .Build();

                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("idSucursal")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("idSucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("nombreSucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(casa)
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(Convert.ToInt32(reader.GetOrdinal("idRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionRequisa")))
                        .SetEstado(Convert.ToBoolean(reader.GetOrdinal("estadoRequisa")))
                        .SetSucursal(sucursal)
                        .Build();

                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(Convert.ToInt32(reader.GetString(reader.GetOrdinal("idRequisaAjuste"))))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteModificadaPor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacionRequisaAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionRequisaAjuste")))
                        .SetMontoAjuste(reader.GetDecimal(reader.GetOrdinal("montoAjuste")))
                        .Build();

                    requisaAjustes.Add(requisaAjuste);
                }
                return DBOResponse<IEnumerable<RequisaAjuste>>.Ok(requisaAjustes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<RequisaAjuste>>.Error("Error al obtener la Parte Casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarRequisaAjuste(RequisaAjuste requisaAjuste)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = @"
                UPDATE Requisa_Ajuste
                set
                    id_Requisa = @IdRequisa,
                    id_Tipo_Ajuste = @IdTipoAjuste,
                    CreadoPor = @CreadoPor,
                    ModificadoPor = @ModificadoPor,
                    FechaCreacion = @FechaCreacion,
                    FechaModificacion = @FechaModificacion,
                    Monto = @Monto
                WHERE
                    id_Requisa_Ajuste = @IdRequisaAjuste
                AND
                    id_Requisa = @IdRequisa
                AND
                    id_Tipo_Ajuste = @IdTipoAjuste";
            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdRequisa", requisaAjuste.Requisa.NDocumentoRequisa);
            cmd.Parameters.AddWithValue("@IdTipoAjuste", requisaAjuste.TipoAjuste.TipoAjusteId);
            cmd.Parameters.AddWithValue("@CreadoPor", requisaAjuste.CreadoPor);
            cmd.Parameters.AddWithValue("@ModificadoPor", requisaAjuste.ModificadoPor);
            cmd.Parameters.AddWithValue("@FechaCreacion", requisaAjuste.FechaRegistro);
            cmd.Parameters.AddWithValue("@FechaModificacion", requisaAjuste.FechaModificacion);
            cmd.Parameters.AddWithValue("@IdRequisaAjuste", requisaAjuste.IdRequisaAjuste);
            cmd.Parameters.AddWithValue("@Monto", requisaAjuste.MontoAjuste);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ninguna Requisa con ajuste. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar la Requisa con Ajuste: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarRequisaAjuste(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("delete from Requisa_Ajuste ");
            query.Append("where id_Requisa_Ajuste = @IdRequisaAjuste; ");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdRequisaAjuste", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ninguna Requisa con Ajuste. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar la Requisa con Ajuste: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<RequisaAjuste>>> ObtenerTodasLasRequisasAjuste()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                    select 
	                    ra.id_Requisa_Ajuste [idRequisaAjuste],
	                    ra.CreadoPor [requisaAjusteCreadaPor],
	                    ra.ModificadoPor [requisaAjusteModificadaPor],
	                    ra.FechaCreacion [fechaCreacionRequisaAjuste],
	                    ra.FechaModificacion [fechaModificacionRequisaAjuste],
                        ra.Monto [montoAjuste],
	                    r.N_DocumentoRequisa [idRequisa],
	                    r.Descripcion [descripcionRequisa],
	                    r.Estado [estadoRequisa],
	                    r.FechaRegistro [fechaRegistroRequisa],
	                    s.Numero_Sucursal [idSucursal],
	                    s.Nombre_Sucursal [nombreSucursal],
	                    s.FechaRegistro [fechaRegistroSucursal],
	                    s.FechaModificacion [fechaModificacionSucursal],
	                    c.Codigo_Casa [idCasa],
	                    c.Nombre_Casa [nombreCasa],
	                    c.FechaRegistro [fechaRegistroCasa],
	                    c.FechaModificacion [fechaModificacionCasa],
	                    ta.id_TipoAjuste [idTipoAjuste],
	                    ta.Descripcion_TipoAjuste [descripcionTipoAjuste],
	                    ta.Simbolo_TipoAjuste [simboloTipoAjuste],
	                    ta.FechaRegistro [fechaRegistroTipoAjuste],
	                    ta.FechaModificacion [fechaModificacionTipoAjuste]
                    from Requisa_Ajuste ra
                    inner join Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                    inner join Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                    inner join Sucursal s on s.Numero_Sucursal = r.IdSucursal
                    inner join Casa c on c.Codigo_casa = s.Codigo_Casa
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var requisaAjustes = new List<RequisaAjuste>();

                while (await reader.ReadAsync())
                {
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("idTipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionTipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("simboloTipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroTipoAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionTipoAjuste")))
                        .Build();

                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("idSucursal")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("idSucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("nombreSucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(casa)
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(Convert.ToInt32(reader.GetOrdinal("idRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionRequisa")))
                        .SetEstado(Convert.ToBoolean(reader.GetOrdinal("estadoRequisa")))
                        .SetSucursal(sucursal)
                        .Build();

                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(Convert.ToInt32(reader.GetString(reader.GetOrdinal("idRequisaAjuste"))))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteModificadaPor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacionRequisaAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionRequisaAjuste")))
                        .SetMontoAjuste(reader.GetDecimal(reader.GetOrdinal("montoAjuste")))
                        .Build();

                    requisaAjustes.Add(requisaAjuste);
                }
                return DBOResponse<IEnumerable<RequisaAjuste>>.Ok(requisaAjustes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<RequisaAjuste>>.Error("Error al obtener la Parte Casa: " + ex.Message);
            }
        }
    }
}
