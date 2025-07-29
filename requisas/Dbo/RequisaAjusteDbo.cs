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
                cmdRequisa.Parameters.AddWithValue("@Estado", requisa.Estado);

                var responseRequisa = await cmdRequisa.ExecuteScalarAsync();
                IdRequisa = responseRequisa.ToString();
                #endregion

                foreach (var requisaAjusteRecorrido in requisaAjuste)
                {
                    if (requisaAjusteRecorrido.Reclamo != null)
                    {
                        #region crear documento
                        //using SqlCommand cmdDocumento = conn.CreateCommand();
                        //cmdDocumento.Transaction = transaction;
                        //string queryDocumento = @"
                        //INSERT INTO Documento(Nombre, documento, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                        //VALUES(@Nombre, @documento, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                        //SELECT SCOPE_IDENTITY();";
                        //cmdDocumento.CommandText = queryDocumento;
                        //cmdDocumento.Parameters.AddWithValue("@Nombre", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.Nombre);
                        //cmdDocumento.Parameters.AddWithValue("@documento", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.DocumentoBytes);
                        //cmdDocumento.Parameters.AddWithValue("@CreadoPor", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.CreadoPor);
                        //cmdDocumento.Parameters.AddWithValue("@ModificadoPor", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.ModificadoPor);
                        //cmdDocumento.Parameters.AddWithValue("@FechaCreacion", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.FechaCreacion);
                        //cmdDocumento.Parameters.AddWithValue("@FechaModificacion", requisaAjusteRecorrido.Reclamo.DocumentoReclamo.FechaModificacion);

                        //var responseDocumento = await cmdDocumento.ExecuteScalarAsync();
                        //IdDocumneto = Convert.ToInt32(responseDocumento);
                        #endregion

                        #region crear reclamo
                        using SqlCommand cmdReclamo = conn.CreateCommand();
                        cmdReclamo.Transaction = transaction;
                        string queryReclamo = @"
                            INSERT INTO Reclamo(observacion, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                            VALUES(@Observacion, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                            SELECT SCOPE_IDENTITY();
                        ";
                        cmdReclamo.CommandText = queryReclamo;
                        cmdReclamo.Parameters.AddWithValue("@Observacion", requisaAjusteRecorrido.Reclamo.Observacion);
                    //  cmdReclamo.Parameters.AddWithValue("@id_documento", IdDocumneto);
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
                        INSERT INTO TransferenciaRequisa(SucursalPrecedencia, SucursalTransferida, CreadoPor, ModificadoPor, FechaCreacion, FechaModificacion)
                        VALUES(@sucursalPrecedencia, @sucursalTransferencia, @CreadoPor, @ModificadoPor, @FechaCreacion, @FechaModificacion)
                        SELECT SCOPE_IDENTITY();";
                        cmdTransferencia.CommandText = queryTransferencia.ToString();
                        cmdTransferencia.Parameters.AddWithValue("@sucursalPrecedencia", requisaAjusteRecorrido.Transferencia.SucursalPrecedencia);
                        cmdTransferencia.Parameters.AddWithValue("@sucursalTransferencia", requisaAjusteRecorrido.Transferencia.SucursalTransferida);
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

                    #region Restar Stock de Parte Sucursal
                    //using SqlCommand cmdParteSucursal = conn.CreateCommand();
                    //cmdParteSucursal.Transaction = transaction;
                    //string queryUpdateStock = @"
                    //    update Parte_Sucursal
                    //    set
	                   //     Stock = Stock - @Cantidad
                    //    where
                    //      Numero_Parte = @idParte
                    //    and
                    //      IdSucursal = @idSucursal;
                    //";
                    //cmdParteSucursal.CommandText = queryUpdateStock;
                    //cmdParteSucursal.Parameters.AddWithValue("@idParte", requisaAjusteRecorrido.ParteSucursal.Parte.NumeroParte);
                    //cmdParteSucursal.Parameters.AddWithValue("@idSucursal", requisaAjusteRecorrido.ParteSucursal.Sucursal.NumeroSucursal);
                    //cmdParteSucursal.Parameters.AddWithValue("@Cantidad", requisaAjusteRecorrido);
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
                     r.N_DocumentoRequisa [idRequisa], r.Descripcion [descripcionRequisa], r.Estado [estadoRequisa], r.FechaRegistro [fechaRegistroRequisa], r.IdSucursal [sucursalRequisa],
                     ta.id_TipoAjuste [idTipoAjuste], ta.Descripcion_TipoAjuste [descripcionTipoAjuste], ta.Simbolo_TipoAjuste [simboloTipoAjuste], ta.FechaRegistro [fechaRegistroTipoAjuste], ta.FechaModificacion [fechaModificacionTipoAjuste],
                     ps.id_ParteCasa [idParteSucursal], ps.Numero_Parte [numeroParte], ps.CostoUnitario [costoUnitario], ps.Stock [stock], ps.FechaRegistro [fechaRegistroParteSucursal], ps.FechaModificacion [fechaRegistroParteSucursal], ps.IdSucursal [sucursalParteSucursal], ps.idCasa [casaParteSucursal], ps.DescripcionParte [descripcionParteSucursal],
                     reclamo.id_Reclamo [idReclamo], reclamo.observacion [observacion], reclamo.CreadoPor [reclamoCreadoPor], reclamo.ModificadoPor [reclamoModificadoPor], reclamo.FechaCreacion [reclamoFechaCreacion], reclamo.FechaModificacion [reclamoFechaModificacion],
                     doc.id_Documento [idDocumento], doc.Nombre [nombreDocumento], doc.documento [documento], doc.CreadoPor [documentoCreadoPor], doc.ModificadoPor [documentoModificadoPor], doc.FechaCreacion [documentoFechaCreacion], doc.FechaModificacion [documentoFechaModificacion],
                     trr.id_TransferenciaRequisa [idTransferencia], trr.SucursalPrecedencia [SucursaPrecedencia], trr.SucursalTransferida [SucursalTransferida], trr.CreadoPor [transferenciaCreadaPor], trr.ModificadoPor [transferenciaModificadaPor], trr.FechaCreacion [transferenciaFechaCreacion], trr.FechaModificacion [transferenciaFechaModificacion], trr.SucursalPrecedencia [sucursalPrecedencia], trr.SucursalTransferida [sucursalTransferida]
                 FROM Requisa_Ajuste ra
                 INNER JOIN Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                 INNER JOIN Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                 INNER JOIN Parte_Sucursal ps on ps.id_ParteCasa = ra.Id_parte_Sucursal
                 LEFT JOIN Reclamo reclamo on reclamo.id_Reclamo = ra.Id_Reclamo
                 LEFT JOIN Documento doc on doc.id_Documento = reclamo.id_documento
                 LEFT JOIN TransferenciaRequisa trr on trr.id_TransferenciaRequisa = ra.id_TransferenciaRequisa
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
                        .SetTipoAjusteId(reader.validateTypeData<int>("idTipoAjuste"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionTipoAjuste"))
                        .SetSimboloTipoAjuste(reader.validateTypeData<string>("simboloTipoAjuste"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroTipoAjuste"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaModificacionTipoAjuste"))
                        .Build();


                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.validateTypeData<int>("idParteSucursal"))
                        .SetParte(reader.validateTypeData<string>("numeroParte"))
                        .SetCostoUnitario(reader.validateTypeData<decimal>("costoUnitario"))
                        .SetCantidad(reader.validateTypeData<int>("stock"))
                        .SetSucursal(reader.validateTypeData<string>("sucursalParteSucursal"))
                        .SetCasa(reader.validateTypeData<string>("casaParteSucursal"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionParteSucursal"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroParteSucursal"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaRegistroParteSucursal"))
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.validateTypeData<string>("idRequisa"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroRequisa"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionRequisa"))
                        .SetEstado(reader.validateTypeData<bool>("estadoRequisa"))
                        .SetSucursal(reader.validateTypeData<string>("sucursalRequisa"))
                        .Build();

                    var documento = new Documento.Builder()
                        .SetIdDocumento(reader.validateTypeData<int>("idDocumento"))
                        .SetNombre(reader.validateTypeData<string>("nombreDocumento"))
                        .SetDocumento(reader.validateTypeData<byte[]>("documento"))
                        .SetCreadoPor(reader.validateTypeData<string>("documentoCreadoPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("documentoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("documentoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("documentoFechaModificacion"))
                        .Build();

                    var reclamo = new Reclamo.Builder()
                        .SetIdReclamo(reader.validateTypeData<int>("idReclamo"))
                        .SetObservacion(reader.validateTypeData<string>("observacion"))
                        .SetCreadoPor(reader.validateTypeData<string>("reclamoCreadoPor"))
                        .SetDocumento(documento)
                        .SetModificadoPor(reader.validateTypeData<string>("reclamoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("reclamoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("reclamoFechaModificacion"))
                        .Build();

                    var transferencia = new Transferencia.Builder()
                        .SetIdTransferencia(reader.validateTypeData<int>("idTransferencia"))
                        .SetSucursalPrecedencia(reader.validateTypeData<string>("SucursaPrecedencia"))
                        .SetSucursalTransferida(reader.validateTypeData<string>("SucursalTransferida"))
                        .SetCreadoPor(reader.validateTypeData<string>("transferenciaCreadaPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("transferenciaModificadaPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("transferenciaFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("transferenciaFechaModificacion"))
                        .Build();


                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(reader.validateTypeData<string>("idRequisaAjuste"))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetParteSucursal(parteSucursal)
                        .SetReclamo(reclamo)
                        .SetTransferencia(transferencia)
                        .SetMontoAjuste(reader.validateTypeData<decimal>("montoAjuste"))
                        .SetCostoPromedio(reader.validateTypeData<decimal>("costoPromedioRequisaAjuste"))
                        .SetCostoPromedioExtendido(reader.validateTypeData<decimal>("costoPromedioExtendidoRequisaAjuste"))
                        .SetDescripcion(reader.validateTypeData<string>("decripcionRequisaAjuste"))
                        .SetCreadoPor(reader.validateTypeData<string>("requisaAjusteCreadaPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("requisaAjusteModificadaPor"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaCreacionRequisaAjuste"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaModificacionRequisaAjuste"))
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
                     r.N_DocumentoRequisa [idRequisa], r.Descripcion [descripcionRequisa], r.Estado [estadoRequisa], r.FechaRegistro [fechaRegistroRequisa], r.IdSucursal [sucursalRequisa],
                     ta.id_TipoAjuste [idTipoAjuste], ta.Descripcion_TipoAjuste [descripcionTipoAjuste], ta.Simbolo_TipoAjuste [simboloTipoAjuste], ta.FechaRegistro [fechaRegistroTipoAjuste], ta.FechaModificacion [fechaModificacionTipoAjuste],
                     ps.id_ParteCasa [idParteSucursal], ps.Numero_Parte [numeroParte], ps.CostoUnitario [costoUnitario], ps.Stock [stock], ps.FechaRegistro [fechaRegistroParteSucursal], ps.FechaModificacion [fechaRegistroParteSucursal], ps.IdSucursal [sucursalParteSucursal], ps.idCasa [casaParteSucursal], ps.DescripcionParte [descripcionParteSucursal],
                     reclamo.id_Reclamo [idReclamo], reclamo.observacion [observacion], reclamo.CreadoPor [reclamoCreadoPor], reclamo.ModificadoPor [reclamoModificadoPor], reclamo.FechaCreacion [reclamoFechaCreacion], reclamo.FechaModificacion [reclamoFechaModificacion],
                     doc.id_Documento [idDocumento], doc.Nombre [nombreDocumento], doc.documento [documento], doc.CreadoPor [documentoCreadoPor], doc.ModificadoPor [documentoModificadoPor], doc.FechaCreacion [documentoFechaCreacion], doc.FechaModificacion [documentoFechaModificacion],
                     trr.id_TransferenciaRequisa [idTransferencia], trr.SucursalPrecedencia [SucursaPrecedencia], trr.SucursalTransferida [SucursalTransferida], trr.CreadoPor [transferenciaCreadaPor], trr.ModificadoPor [transferenciaModificadaPor], trr.FechaCreacion [transferenciaFechaCreacion], trr.FechaModificacion [transferenciaFechaModificacion], trr.SucursalPrecedencia [sucursalPrecedencia], trr.SucursalTransferida [sucursalTransferida]
                 FROM Requisa_Ajuste ra
                 INNER JOIN Requisa r on ra.id_requisa = r.N_DocumentoRequisa
                 INNER JOIN Tipo_Ajuste ta on ra.id_Tipo_Ajuste = ta.id_TipoAjuste
                 INNER JOIN Parte_Sucursal ps on ps.id_ParteCasa = ra.Id_parte_Sucursal
                 LEFT JOIN Reclamo reclamo on reclamo.id_Reclamo = ra.Id_Reclamo
                 LEFT JOIN Documento doc on doc.id_Documento = reclamo.id_documento
                 LEFT JOIN TransferenciaRequisa trr on trr.id_TransferenciaRequisa = ra.id_TransferenciaRequisa
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
                        .SetTipoAjusteId(reader.validateTypeData<int?>("idTipoAjuste"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionTipoAjuste"))
                        .SetSimboloTipoAjuste(reader.validateTypeData<string>("simboloTipoAjuste"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroTipoAjuste"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaModificacionTipoAjuste"))
                        .Build();


                    var parteSucursal = new ParteSucursal.Builder()
                        .SetIdParteSucursal(reader.validateTypeData<int?>("idParteSucursal"))
                        .SetParte(reader.validateTypeData<string>("numeroParte"))
                        .SetCostoUnitario(reader.validateTypeData<decimal>("costoUnitario"))
                        .SetCantidad(reader.validateTypeData<int>("stock"))
                        .SetSucursal(reader.validateTypeData<string>("sucursalParteSucursal"))
                        .SetCasa(reader.validateTypeData<string>("casaParteSucursal"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionParteSucursal"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroParteSucursal"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaRegistroParteSucursal"))
                        .Build();

                    var requisa = new Requisa.Builder()
                        .SetNDocumentoRequisa(reader.validateTypeData<string>("idRequisa"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaRegistroRequisa"))
                        .SetDescripcion(reader.validateTypeData<string>("descripcionRequisa"))
                        .SetEstado(reader.validateTypeData<bool>("estadoRequisa"))
                        .SetSucursal(reader.validateTypeData<string>("sucursalRequisa"))
                        .Build();

                    var documento = new Documento.Builder()
                        .SetIdDocumento(reader.validateTypeData<int?>("idDocumento"))
                        .SetNombre(reader.validateTypeData<string>("nombreDocumento"))
                        .SetDocumento(reader.validateTypeData<byte[]>("documento"))
                        .SetCreadoPor(reader.validateTypeData<string>("documentoCreadoPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("documentoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("documentoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("documentoFechaModificacion"))
                        .Build();

                    var reclamo = new Reclamo.Builder()
                        .SetIdReclamo(reader.validateTypeData<int?>("idReclamo"))
                        .SetObservacion(reader.validateTypeData<string>("observacion"))
                        .SetCreadoPor(reader.validateTypeData<string>("reclamoCreadoPor"))
                        .SetDocumento(documento)
                        .SetModificadoPor(reader.validateTypeData<string>("reclamoModificadoPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("reclamoFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("reclamoFechaModificacion"))
                        .Build();

                    var transferencia = new Transferencia.Builder()
                        .SetIdTransferencia(reader.validateTypeData<int?>("idTransferencia"))
                        .SetSucursalPrecedencia(reader.validateTypeData<string>("SucursaPrecedencia"))
                        .SetSucursalTransferida(reader.validateTypeData<string>("SucursalTransferida"))
                        .SetCreadoPor(reader.validateTypeData<string>("transferenciaCreadaPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("transferenciaModificadaPor"))
                        .SetFechaCreacion(reader.validateTypeData<DateTime>("transferenciaFechaCreacion"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("transferenciaFechaModificacion"))
                        .Build();


                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetIdRequisaAjuste(reader.validateTypeData<string>("idRequisaAjuste"))
                        .SetRequisa(requisa)
                        .SetTipoAjuste(tipoAjuste)
                        .SetParteSucursal(parteSucursal)
                        .SetReclamo(reclamo)
                        .SetTransferencia(transferencia)
                        .SetMontoAjuste(reader.validateTypeData<decimal>("montoAjuste"))
                        .SetCostoPromedio(reader.validateTypeData<decimal>("costoPromedioRequisaAjuste"))
                        .SetCostoPromedioExtendido(reader.validateTypeData<decimal>("costoPromedioExtendidoRequisaAjuste"))
                        .SetDescripcion(reader.validateTypeData<string>("decripcionRequisaAjuste"))
                        .SetCreadoPor(reader.validateTypeData<string>("requisaAjusteCreadaPor"))
                        .SetModificadoPor(reader.validateTypeData<string>("requisaAjusteModificadaPor"))
                        .SetFechaRegistro(reader.validateTypeData<DateTime>("fechaCreacionRequisaAjuste"))
                        .SetFechaModificacion(reader.validateTypeData<DateTime>("fechaModificacionRequisaAjuste"))
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
