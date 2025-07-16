using Dbo.utils;
using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.data;
using Modelos.requisas;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dbo.utils;

namespace Dbo
{
    public class RequisaAjusteDbo
    {
        public RequisaAjusteDbo()
        {
        }

        public async Task<DBOResponse<string>> CrearRequisaAjuste(Requisa requisa, List<RequisaAjuste> requisaAjuste)
        {
            string IdRequisa = string.Empty;
            int? IdDocumneto = null;
            int? IdReclamo = null;
            int? IdTransferencia = null;

            await using var conn = Conexion.conexion();
            await conn.OpenAsync();
            await using SqlTransaction transaction = (SqlTransaction)await conn.BeginTransactionAsync();
            try
            {
                #region  crea Requisa
                using SqlCommand cmdRequisa = conn.CreateCommand();
                cmdRequisa.Transaction = transaction;
                string queryRequisa = @"
                    DECLARE @NuevoID NVARCHAR(50)
                    SET @NuevoID = 'DOC-' + FORMAT(NEXT VALUE FOR Seq_Casa, '0000');
                    INSERT INTO Requisa (N_DocumentoRequisa,FechaRegistro, Descripcion, Estado)
                    VALUES (@NuevoID,@FechaRegistro, @Descripcion, @Estado); 
                    SELECT @NuevoID;
                    ";
                cmdRequisa.CommandText = queryRequisa;
                cmdRequisa.Parameters.AddWithValue("@FechaRegistro", requisa.FechaRegistro);
                cmdRequisa.Parameters.AddWithValue("@Descripcion", requisa.Descripcion);
                //     cmdRequisa.Parameters.AddWithValue("@IdSucursal", requisa.Sucursal.NumeroSucursal);
                cmdRequisa.Parameters.AddWithValue("@Estado", requisa.Estado);

                var responseRequisa = await cmdRequisa.ExecuteScalarAsync();
                IdRequisa = responseRequisa.ToString();
                #endregion

                foreach (var requisaAjusteRecorrido in requisaAjuste)
                {
                    if (requisaAjusteRecorrido.Reclamo != null)
                    {
                        #region crear documento
                        using SqlCommand cmdDocumento = conn.CreateCommand();
                        cmdDocumento.Transaction = transaction;
                        string queryDocumento = @"
                        INSERT INTO Documento(Nombre, documento, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                        VALUES(@Nombre, @documento, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                        SELECT SCOPE_IDENTITY();";
                        cmdDocumento.CommandText = queryDocumento;
                        cmdDocumento.Parameters.AddWithValue("@Nombre", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.Nombre);
                        cmdDocumento.Parameters.AddWithValue("@documento", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.DocumentoBytes);
                        cmdDocumento.Parameters.AddWithValue("@CreadoPor", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.CreadoPor);
                        cmdDocumento.Parameters.AddWithValue("@ModificadoPor", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.ModificadoPor);
                        cmdDocumento.Parameters.AddWithValue("@FechaCreacion", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.FechaCreacion);
                        cmdDocumento.Parameters.AddWithValue("@FechaModificacion", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.FechaModificacion);

                        var responseDocumento = await cmdDocumento.ExecuteScalarAsync();
                        IdDocumneto = Convert.ToInt32(responseDocumento);
                        #endregion

                        #region crear reclamo
                        using SqlCommand cmdReclamo = conn.CreateCommand();
                        cmdReclamo.Transaction = transaction;
                        string queryReclamo = @"
                            INSERT INTO Reclamo(observacion, id_documento, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                            VALUES(@Observacion, @id_documento, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                            SELECT SCOPE_IDENTITY();
                        ";
                        cmdReclamo.CommandText = queryReclamo;
                        cmdReclamo.Parameters.AddWithValue("@Observacion", requisaAjusteRecorrido.Reclamo.Observacion);
                        cmdReclamo.Parameters.AddWithValue("@id_documento", IdDocumneto);
                        cmdReclamo.Parameters.AddWithValue("@CreadoPor", requisaAjusteRecorrido.Reclamo.CreadoPor);
                        cmdReclamo.Parameters.AddWithValue("@ModificadoPor", requisaAjusteRecorrido.Reclamo.ModificadoPor);
                        cmdReclamo.Parameters.AddWithValue("@FechaCreacion", requisaAjusteRecorrido.Reclamo.FechaCreacion);
                        cmdReclamo.Parameters.AddWithValue("@FechaModificacion", requisaAjusteRecorrido.Reclamo.FechaModificacion);

                        var responseReclamo = await cmdReclamo.ExecuteScalarAsync();
                        IdReclamo = Convert.ToInt32(responseReclamo);
                        #endregion
                    }

                    if (requisaAjusteRecorrido.Transferencia != null)
                    {
                        #region crear transferencia de sucursal
                        using SqlCommand cmdTransferencia = conn.CreateCommand();
                        cmdTransferencia.Transaction = transaction;
                        string queryTransferencia = @"
                        INSERT INTO TransferenciaRequisa(idSucursal, idCasa, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                        VALUES(@idSucursal, @idCasa, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                        SELECT SCOPE_IDENTITY();";
                        cmdTransferencia.CommandText = queryTransferencia.ToString();
                        cmdTransferencia.Parameters.AddWithValue("@idSucursal", requisaAjusteRecorrido.Transferencia.Sucursal.NumeroSucursal);
                        cmdTransferencia.Parameters.AddWithValue("@idCasa", requisaAjusteRecorrido.Transferencia.Sucursal.Casa.CodigoCasa);
                        cmdTransferencia.Parameters.AddWithValue("@CreadoPor", requisaAjusteRecorrido.Transferencia.CreadoPor);
                        cmdTransferencia.Parameters.AddWithValue("@ModificadoPor", requisaAjusteRecorrido.Transferencia.ModificadoPor);
                        cmdTransferencia.Parameters.AddWithValue("@FechaCreacion", requisaAjusteRecorrido.Transferencia.FechaCreacion);
                        cmdTransferencia.Parameters.AddWithValue("@FechaModificacion", requisaAjusteRecorrido.Transferencia.FechaModificacion);

                        var responseTransferencia = await cmdTransferencia.ExecuteScalarAsync();
                        IdTransferencia = Convert.ToInt32(responseTransferencia);
                        #endregion
                    }

                    #region crear Requisa Ajuste
                    using SqlCommand cmdRequisaAjuste = conn.CreateCommand();
                    cmdRequisaAjuste.Transaction = transaction;
                    string queryRequisaAjuste = @"
                        DECLARE 
                            @ConsecutivoID NVARCHAR(50),
                            @NuevoID NVARCHAR(50);
                        SET @ConsecutivoID =  FORMAT(NEXT VALUE FOR seq_RequisaAjuste, '0000');
                        SET @NuevoID = @idRequisaAjuste + '-' + @ConsecutivoID;

                        INSERT INTO Requisa_Ajuste(Id_Requisa_Ajuste, id_Requisa, id_Tipo_Ajuste, id_TransferenciaRequisa, Id_Reclamo, Id_parte_Sucursal, Monto, Descripcion, costoPromedio, costoPromedioExtendido, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                        values(@NuevoID, @idRequisa, @idTipoAjuste, @idTransferenciaRequisa, @Id_Reclamo, @Id_parte_Sucursal, @Monto, @Descripcion, @costoPromedio, @costoPromedioExtendido, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)";
                    cmdRequisaAjuste.CommandText = queryRequisaAjuste;
                    cmdRequisaAjuste.Parameters.AddWithValue("@idRequisaAjuste", requisaAjusteRecorrido.IdRequisaAjuste);
                    cmdRequisaAjuste.Parameters.AddWithValue("@idRequisa", IdRequisa);
                    cmdRequisaAjuste.Parameters.AddWithValue("@idTipoAjuste", requisaAjusteRecorrido.TipoAjuste.TipoAjusteId);
                    cmdRequisaAjuste.Parameters.AddWithValue("@idTransferenciaRequisa", (Object?)IdTransferencia ?? DBNull.Value);
                    cmdRequisaAjuste.Parameters.AddWithValue("@Id_Reclamo", (Object?)IdReclamo ?? DBNull.Value);
                    cmdRequisaAjuste.Parameters.AddWithValue("@Id_parte_Sucursal", requisaAjusteRecorrido.ParteSucursal.IdParteSucursal);
                    cmdRequisaAjuste.Parameters.AddWithValue("@Monto", requisaAjusteRecorrido.MontoAjuste);
                    cmdRequisaAjuste.Parameters.AddWithValue("@Descripcion", requisaAjusteRecorrido.Descripcion);
                    cmdRequisaAjuste.Parameters.AddWithValue("@costoPromedio", requisaAjusteRecorrido.CostoPromedio);
                    cmdRequisaAjuste.Parameters.AddWithValue("@costoPromedioExtendido", requisaAjusteRecorrido.CostoPromedioExtendido);
                    cmdRequisaAjuste.Parameters.AddWithValue("@CreadoPor", requisaAjusteRecorrido.CreadoPor);
                    cmdRequisaAjuste.Parameters.AddWithValue("@ModificadoPor", requisaAjusteRecorrido.ModificadoPor);
                    cmdRequisaAjuste.Parameters.AddWithValue("@FechaCreacion", requisaAjusteRecorrido.FechaRegistro);
                    cmdRequisaAjuste.Parameters.AddWithValue("@FechaModificacion", requisaAjusteRecorrido.FechaModificacion);

                    IdTransferencia = null;
                    IdReclamo = null;
                    await cmdRequisaAjuste.ExecuteNonQueryAsync();
                    #endregion
                }

                await transaction.CommitAsync();
                return DBOResponse<string>.Ok(IdRequisa);
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return DBOResponse<string>.Error("Error al crear la Requisa con Ajustes: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<RequisaAjuste>>> ObtenerRequisaAjustes()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                #region query
                var query = @"
                SELECT
                    ra.id_Requisa_Ajuste [idRequisaAjuste], ra.CreadoPor [requisaAjusteCreadaPor], ra.ModificadoPor [requisaAjusteModificadaPor], ra.FechaCreacion [fechaCreacionRequisaAjuste], ra.FechaModificacion [fechaModificacionRequisaAjuste], ra.Monto [montoAjuste], ra.Descripcion [decripcionRequisaAjuste], ra.costoPromedio [costoPromedioRequisaAjuste], ra.costoPromedioExtendido [costoPromedioExtendidoRequisaAjuste],
                    r.N_DocumentoRequisa [idRequisa], r.Descripcion [descripcionRequisa], r.Estado [estadoRequisa], r.FechaRegistro [fechaRegistroRequisa],
	                ta.id_TipoAjuste [idTipoAjuste], ta.Descripcion_TipoAjuste [descripcionTipoAjuste], ta.Simbolo_TipoAjuste [simboloTipoAjuste], ta.FechaRegistro [fechaRegistroTipoAjuste], ta.FechaModificacion [fechaModificacionTipoAjuste],
	                ps.id_ParteCasa [idParteSucursal], ps.Numero_Parte [numeroParte], ps.CostoUnitario [costoUnitario], ps.Stock [stock], ps.FechaRegistro [fechaRegistroParteSucursal], ps.FechaModificacion [fechaRegistroParteSucursal],
	                s.Numero_Sucursal [numeroSucursal], s.Nombre_Sucursal [nombreSucursal], s.FechaRegistro [fechaRegistroSucursal], s.FechaModificacion [fechaModificacionSucursal],
	                c.Codigo_Casa [codigoCasa], c.Nombre_Casa [nombreCasa], c.FechaRegistro [fechaRegistroCasa], c.FechaModificacion [fechaModificacionCasa],
	                parte.Numero_Parte [numeroParte], parte.Descripcion_Parte [descripcionParte], parte.FechaRegistro [parteFechaRegistro], parte.FechaModificacion [parteFechaModificacion],
	                reclamo.id_Reclamo [idReclamo], reclamo.observacion [observacion], reclamo.CreadoPor [reclamoCreadoPor], reclamo.ModificadoPor [reclamoModificadoPor], reclamo.FechaCreacion [reclamoFechaCreacion], reclamo.FechaModificacion [reclamoFechaModificacion],
	                doc.id_Documento [idDocumento], doc.Nombre [nombreDocumento], doc.documento [documento], doc.CreadoPor [documentoCreadoPor], doc.ModificadoPor [documentoModificadoPor], doc.FechaCreacion [documentoFechaCreacion], doc.FechaModificacion [documentoFechaModificacion],
	                trr.id_TransferenciaRequisa [idTransferencia], trr.idCasa [casaTransferencia], trr.idSucursal [sucursalTransferencia], trr.CreadoPor [transferenciaCreadaPor], trr.ModificadoPor [transferenciaModificadaPor], trr.FechaCreacion [transferenciaFechaCreacion], trr.FechaModificacion [transferenciaFechaModificacion],
	                cTransferencia.Codigo_Casa [idCasaTransferencia], cTransferencia.Nombre_Casa [nombreCasaTransferencia], cTransferencia.FechaRegistro [fechaRegistroCasaTransferencia], cTransferencia.FechaModificacion [fechaModificacionCasaTransferencia],
	                sTransferencia.Numero_Sucursal [numeroSucursalTransferencia], sTransferencia.Nombre_Sucursal [nombreSucursalTransferencia], sTransferencia.FechaRegistro [fechaRegistroSucursalTransferencia], sTransferencia.FechaModificacion [fechaModificacionSucursalTransferencia],
	                cSucursalTransferencia.Codigo_Casa [codigoCasaSucursalTransferencia], cSucursalTransferencia.Nombre_Casa [nombreCasaSucursalTransferencia], cSucursalTransferencia.FechaRegistro [fechaCreacionCasaSucursalTransferencia], cSucursalTransferencia.FechaModificacion [fechaModificacionCasaSucursalTransferencia]
                FROM Requisa_Ajuste ra
                INNER JOIN Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                INNER JOIN Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                INNER JOIN Parte_Sucursal ps on ps.id_ParteCasa = ra.Id_parte_Sucursal
                INNER JOIN Sucursal s on s.Numero_Sucursal = ps.IdSucursal
                INNER JOIN Casa c on c.Codigo_Casa = s.Codigo_Casa
                INNER JOIN Parte parte on parte.Numero_Parte = ps.Numero_Parte
                LEFT JOIN Reclamo reclamo on reclamo.id_Reclamo = ra.Id_Reclamo
                LEFT JOIN Documento doc on doc.id_Documento = reclamo.id_documento
                LEFT JOIN TransferenciaRequisa trr on trr.id_TransferenciaRequisa = ra.id_TransferenciaRequisa
                LEFT JOIN Casa cTransferencia on ctransferencia.Codigo_Casa = trr.idCasa
                LEFT JOIN Sucursal sTransferencia on sTransferencia.Numero_Sucursal = trr.idSucursal
                LEFT JOIN Casa cSucursalTransferencia on cSucursalTransferencia.Codigo_Casa = sTransferencia.Codigo_Casa
                ";
                #endregion

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var requisaAjustes = new List<RequisaAjuste>();

                while (await reader.ReadAsync())
                {
                    #region construir objetos
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("idTipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionTipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("simboloTipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroTipoAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionTipoAjuste")))
                        .Build();

                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("codigoCasa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("numeroSucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("nombreSucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(casa)
                        .Build();

                    var parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("numeroParte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("descripcionParte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("parteFechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("parteFechaModificacion")))
                        .Build();

                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.GetInt32(reader.GetOrdinal("idParteSucursal")))
                        .SetParte(parte)
                        .SetCostoUnitario(reader.GetDecimal(reader.GetOrdinal("costoUnitario")))
                        .SetCantidad(reader.GetInt32(reader.GetOrdinal("stock")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParteSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParteSucursal")))
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(reader.GetOrdinal("idRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionRequisa")))
                        .SetEstado(Convert.ToBoolean(reader.GetOrdinal("estadoRequisa")))
                        .SetSucursal(sucursal)
                        .Build();

                    var documento = new Documento.Builder()
                        .SetIdDocumento(reader.GetInt32(reader.GetOrdinal("idDocumento")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("nombreDocumento")))
                        .SetDocumento((byte[])reader["documento"])
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("documentoCreadoPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("documentoModificadoPor")))
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("documentoFechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("documentoFechaModificacion")))
                        .Build();

                    var reclamo = new Reclamo.Builder()
                        .SetIdReclamo(reader.GetInt32(reader.GetOrdinal("idReclamo")))
                        .SetObservacion(reader.GetString(reader.GetOrdinal("observacion")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("reclamoCreadoPor")))
                        .SetDocumento(documento)
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("reclamoModificadoPor")))
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("reclamoFechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("reclamoFechaModificacion")))
                        .Build();

                    var transferencia = new Transferencia.Builder()
                        .SetIdTransferencia(reader.GetInt32(reader.GetOrdinal("idTransferencia")))
                        .SetCasa(
                            new Casa.Builder()
                                .SetCodigoCasa(reader.GetString(reader.GetOrdinal("idCasaTransferencia")))
                                .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasaTransferencia")))
                                .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasaTransferencia")))
                                .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasaTransferencia")))
                                .Build()
                        )
                        .SetSucursal(
                            new Sucursal.Builder()
                                .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("numeroSucursalTransferencia")))
                                .SetNombreSucursal(reader.GetString(reader.GetOrdinal("nombreSucursalTransferencia")))
                                .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursalTransferencia")))
                                .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursalTransferencia")))
                                .SetCasa(
                                    new Casa.Builder()
                                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("codigoCasaSucursalTransferencia")))
                                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasaSucursalTransferencia")))
                                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacionCasaSucursalTransferencia")))
                                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasaSucursalTransferencia")))
                                        .Build()
                                ).Build()
                        )
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("transferenciaCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("transferenciaModificadaPor")))
                        .SetFechaCreacion(reader.GetDateTime(reader.GetOrdinal("transferenciaFechaCreacion")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("transferenciaFechaModificacion")))
                        .Build();


                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(reader.GetString(reader.GetOrdinal("idRequisaAjuste")))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetParteSucursal(parteSucursal)
                        .SetReclamo(reclamo)
                        .SetTransferencia(transferencia)
                        .SetMontoAjuste(reader.GetDecimal(reader.GetOrdinal("montoAjuste")))
                        .SetCostoPromedio(reader.GetDecimal(reader.GetOrdinal("costoPromedioRequisaAjuste")))
                        .SetCostoPromedioExtendido(reader.GetDecimal(reader.GetOrdinal("costoPromedioExtendidoRequisaAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("decripcionRequisaAjuste")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteModificadaPor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacionRequisaAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionRequisaAjuste")))
                        .Build();
                    #endregion

                    requisaAjustes.Add(requisaAjuste);
                }
                return DBOResponse<IEnumerable<RequisaAjuste>>.Ok(requisaAjustes);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<RequisaAjuste>>.Error("Error al obtener la Parte Casa: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<RequisaAjuste>>> ObtenerRequisaAjustePorIdRequisa(string numeroDocumetoRequisa)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                #region query
                var query = @"
                SELECT
                    ra.id_Requisa_Ajuste [idRequisaAjuste], ra.CreadoPor [requisaAjusteCreadaPor], ra.ModificadoPor [requisaAjusteModificadaPor], ra.FechaCreacion [fechaCreacionRequisaAjuste], ra.FechaModificacion [fechaModificacionRequisaAjuste], ra.Monto [montoAjuste], ra.Descripcion [decripcionRequisaAjuste], ra.costoPromedio [costoPromedioRequisaAjuste], ra.costoPromedioExtendido [costoPromedioExtendidoRequisaAjuste],
                    r.N_DocumentoRequisa [idRequisa], r.Descripcion [descripcionRequisa], r.Estado [estadoRequisa], r.FechaRegistro [fechaRegistroRequisa],
	                ta.id_TipoAjuste [idTipoAjuste], ta.Descripcion_TipoAjuste [descripcionTipoAjuste], ta.Simbolo_TipoAjuste [simboloTipoAjuste], ta.FechaRegistro [fechaRegistroTipoAjuste], ta.FechaModificacion [fechaModificacionTipoAjuste],
	                ps.id_ParteCasa [idParteSucursal], ps.Numero_Parte [numeroParte], ps.CostoUnitario [costoUnitario], ps.Stock [stock], ps.FechaRegistro [fechaRegistroParteSucursal], ps.FechaModificacion [fechaRegistroParteSucursal],
	                s.Numero_Sucursal [numeroSucursal], s.Nombre_Sucursal [nombreSucursal], s.FechaRegistro [fechaRegistroSucursal], s.FechaModificacion [fechaModificacionSucursal],
	                c.Codigo_Casa [codigoCasa], c.Nombre_Casa [nombreCasa], c.FechaRegistro [fechaRegistroCasa], c.FechaModificacion [fechaModificacionCasa],
	                parte.Numero_Parte [numeroParte], parte.Descripcion_Parte [descripcionParte], parte.FechaRegistro [parteFechaRegistro], parte.FechaModificacion [parteFechaModificacion],
	                reclamo.id_Reclamo [idReclamo], reclamo.observacion [observacion], reclamo.CreadoPor [reclamoCreadoPor], reclamo.ModificadoPor [reclamoModificadoPor], reclamo.FechaCreacion [reclamoFechaCreacion], reclamo.FechaModificacion [reclamoFechaModificacion],
	                doc.id_Documento [idDocumento], doc.Nombre [nombreDocumento], doc.documento [documento], doc.CreadoPor [documentoCreadoPor], doc.ModificadoPor [documentoModificadoPor], doc.FechaCreacion [documentoFechaCreacion], doc.FechaModificacion [documentoFechaModificacion],
	                trr.id_TransferenciaRequisa [idTransferencia], trr.idCasa [casaTransferencia], trr.idSucursal [sucursalTransferencia], trr.CreadoPor [transferenciaCreadaPor], trr.ModificadoPor [transferenciaModificadaPor], trr.FechaCreacion [transferenciaFechaCreacion], trr.FechaModificacion [transferenciaFechaModificacion],
	                cTransferencia.Codigo_Casa [idCasaTransferencia], cTransferencia.Nombre_Casa [nombreCasaTransferencia], cTransferencia.FechaRegistro [fechaRegistroCasaTransferencia], cTransferencia.FechaModificacion [fechaModificacionCasaTransferencia],
	                sTransferencia.Numero_Sucursal [numeroSucursalTransferencia], sTransferencia.Nombre_Sucursal [nombreSucursalTransferencia], sTransferencia.FechaRegistro [fechaRegistroSucursalTransferencia], sTransferencia.FechaModificacion [fechaModificacionSucursalTransferencia],
	                cSucursalTransferencia.Codigo_Casa [codigoCasaSucursalTransferencia], cSucursalTransferencia.Nombre_Casa [nombreCasaSucursalTransferencia], cSucursalTransferencia.FechaRegistro [fechaCreacionCasaSucursalTransferencia], cSucursalTransferencia.FechaModificacion [fechaModificacionCasaSucursalTransferencia]
                FROM Requisa_Ajuste ra
                INNER JOIN Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                INNER JOIN Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                INNER JOIN Parte_Sucursal ps on ps.id_ParteCasa = ra.Id_parte_Sucursal
                INNER JOIN Sucursal s on s.Numero_Sucursal = ps.IdSucursal
                INNER JOIN Casa c on c.Codigo_Casa = s.Codigo_Casa
                INNER JOIN Parte parte on parte.Numero_Parte = ps.Numero_Parte
                LEFT JOIN Reclamo reclamo on reclamo.id_Reclamo = ra.Id_Reclamo
                LEFT JOIN Documento doc on doc.id_Documento = reclamo.id_documento
                LEFT JOIN TransferenciaRequisa trr on trr.id_TransferenciaRequisa = ra.id_TransferenciaRequisa
                LEFT JOIN Casa cTransferencia on ctransferencia.Codigo_Casa = trr.idCasa
                LEFT JOIN Sucursal sTransferencia on sTransferencia.Numero_Sucursal = trr.idSucursal
                LEFT JOIN Casa cSucursalTransferencia on cSucursalTransferencia.Codigo_Casa = sTransferencia.Codigo_Casa
                WHERE r.N_DocumentoRequisa = @NDocumentoRequisa
                ";
                #endregion

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NDocumentoRequisa", numeroDocumetoRequisa);

                await using var reader = await cmd.ExecuteReaderAsync();

                var requisaAjustes = new List<RequisaAjuste>();

                while (await reader.ReadAsync())
                {
                    #region construir objetos
                    var tipoAjuste = new TipoAjuste.Builder()
                        .SetTipoAjusteId(reader.GetInt32(reader.GetOrdinal("idTipoAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionTipoAjuste")))
                        .SetSimboloTipoAjuste(reader.GetString(reader.GetOrdinal("simboloTipoAjuste")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroTipoAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionTipoAjuste")))
                        .Build();

                    var casa = new Casa.Builder()
                        .SetCodigoCasa(reader.GetString(reader.GetOrdinal("codigoCasa")))
                        .SetNombreCasa(reader.GetString(reader.GetOrdinal("nombreCasa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroCasa")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionCasa")))
                        .Build();

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(reader.GetString(reader.GetOrdinal("numeroSucursal")))
                        .SetNombreSucursal(reader.GetString(reader.GetOrdinal("nombreSucursal")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionSucursal")))
                        .SetCasa(casa)
                        .Build();

                    var parte = new Parte.Builder()
                        .SetNumeroParte(reader.GetString(reader.GetOrdinal("numeroParte")))
                        .SetDescripcionParte(reader.GetString(reader.GetOrdinal("descripcionParte")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("parteFechaRegistro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("parteFechaModificacion")))
                        .Build();

                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.GetInt32(reader.GetOrdinal("idParteSucursal")))
                        .SetParte(parte)
                        .SetSucursal(sucursal)
                        .SetCostoUnitario(reader.GetDecimal(reader.GetOrdinal("costoUnitario")))
                        .SetCantidad(reader.GetInt32(reader.GetOrdinal("stock")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParteSucursal")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaRegistroParteSucursal")))
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.GetString(reader.GetOrdinal("idRequisa")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaRegistroRequisa")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcionRequisa")))
                        .SetEstado(Convert.ToBoolean(reader.GetOrdinal("estadoRequisa")))
                        .SetSucursal(sucursal)
                        .Build();

                    var documento = new Documento.Builder()
                        .SetIdDocumento(reader.validateTypeData<int?>("idDocumento"))
                        .SetNombre(reader.validateTypeData<string?>("nombreDocumento"))
                        .SetDocumento(reader.validateTypeData<byte[]?>("documento"))
                        .SetCreadoPor(reader.validateTypeData<string?>("documentoCreadoPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("documentoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime?>("documentoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime?>("documentoFechaModificacion"))
                        .Build();

                    var reclamo = new Reclamo.Builder()
                        .SetIdReclamo(reader.validateTypeData<int?>("idReclamo"))
                        .SetObservacion(reader.validateTypeData<string?>("observacion"))
                        .SetCreadoPor(reader.validateTypeData<string?>("reclamoCreadoPor"))
                        .SetDocumento(documento)
                        .SetModificadoPor(reader.validateTypeData<string?>("reclamoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime?>("reclamoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime?>("reclamoFechaModificacion"))
                        .Build();

                    var transferencia = new Transferencia.Builder()
                        .SetIdTransferencia(reader.validateTypeData<int?>("idTransferencia"))
                        .SetCasa(
                            new Casa.Builder()
                                .SetCodigoCasa(reader.validateTypeData<string?>("idCasaTransferencia"))
                                .SetNombreCasa(reader.validateTypeData<string?>("nombreCasaTransferencia"))
                                .SetFechaRegistro(reader.validateTypeData<DateTime?>("fechaRegistroCasaTransferencia"))
                                .SetFechaModificacion(reader.validateTypeData<DateTime?>("fechaModificacionCasaTransferencia"))
                                .Build() ?? null
                        )
                        .SetSucursal(
                            new Sucursal.Builder()
                                .SetNumeroSucursal(reader.validateTypeData<string?>("numeroSucursalTransferencia"))
                                .SetNombreSucursal(reader.validateTypeData<string?>("nombreSucursalTransferencia"))
                                .SetFechaRegistro(reader.validateTypeData<DateTime?>("fechaRegistroSucursalTransferencia"))
                                .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaModificacionSucursalTransferencia"))
                                .SetCasa(
                                    new Casa.Builder()
                                        .SetCodigoCasa(reader.validateTypeData<string?>("codigoCasaSucursalTransferencia"))
                                        .SetNombreCasa(reader.validateTypeData<string?>("nombreCasaSucursalTransferencia"))
                                        .SetFechaRegistro(reader.validateTypeData<DateTime?>("fechaCreacionCasaSucursalTransferencia"))
                                        .SetFechaModificacion(reader.validateTypeData<DateTime?>("fechaModificacionCasaSucursalTransferencia"))
                                        .Build()
                                ).Build() 
                        )
                        .SetCreadoPor(reader.validateTypeData<string?>("transferenciaCreadaPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("transferenciaModificadaPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime?>("transferenciaFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime?>("transferenciaFechaModificacion"))
                        .Build();


                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(reader.GetString(reader.GetOrdinal("idRequisaAjuste")))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetParteSucursal(parteSucursal)
                        .SetReclamo(reclamo)
                        .SetTransferencia(transferencia)
                        .SetMontoAjuste(reader.GetDecimal(reader.GetOrdinal("montoAjuste")))
                        .SetCostoPromedio(reader.GetDecimal(reader.GetOrdinal("costoPromedioRequisaAjuste")))
                        .SetCostoPromedioExtendido(reader.GetDecimal(reader.GetOrdinal("costoPromedioExtendidoRequisaAjuste")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("decripcionRequisaAjuste")))
                        .SetCreadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteCreadaPor")))
                        .SetModificadoPor(reader.GetString(reader.GetOrdinal("requisaAjusteModificadaPor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fechaCreacionRequisaAjuste")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fechaModificacionRequisaAjuste")))
                        .Build();
                    #endregion

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
