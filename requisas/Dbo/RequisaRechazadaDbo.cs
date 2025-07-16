using Microsoft.Data.SqlClient;
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
    public class RequisaRechazadaDbo
    {

        public async Task<DBOResponse<bool>> crearRequizaRechazada(RequisaRechazada requisa)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = @"
                insert into Requisas_Rechazadas(Numero_requisa, Descripcion, CreadoPor, modificadoPor, fechaRegistro, fechaModificacion)
                values(@NumeroRequisa, @Descripcion,@CreadoPor, @ModificadoPor, @FechaRegistro, @FechaModificacion)
            ";

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();
            cmd.Parameters.AddWithValue("@NumeroRequisa", requisa.NumeroRequisa);
            cmd.Parameters.AddWithValue("@Descripcion", requisa.Descripcion);
            cmd.Parameters.AddWithValue("@CreadoPor", requisa.CreadoPor);
            cmd.Parameters.AddWithValue("@ModificadoPor", requisa.ModificadoPor);
            cmd.Parameters.AddWithValue("@FechaRegistro", requisa.FechaCreacion);
            cmd.Parameters.AddWithValue("@FechaModificacion", requisa.FechaModificacion);

            try
            {
                await cmd.ExecuteScalarAsync();
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al crear la Parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<RequisaRechazada>> obtenerTodasLasRequisasRechazadas()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                    SELECT 
	                    rc.IdRequisaRechazada, rc.Numero_requisa, rc.Descripcion, rc.CreadoPor, rc.modificadoPor, rc.fechaRegistro, rc.fechaModificacion
                    FROM 
	                    Requisas_Rechazadas rc
                ";
                
                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var requisaRechazada = new RequisaRechazada.Builder()
                        .SetId(reader.GetInt32(0))
                        .SetNumeroRequisa(reader.GetString(1))
                        .SetDescripcion(reader.GetString(2))
                        .SetCreadoPor(reader.GetString(3))
                        .SetModificadoPor(reader.GetString(4))
                        .SetFechaCreacion(reader.GetDateTime(5))
                        .SetFechaModificacion(reader.GetDateTime(6))
                        .Build();

                    return DBOResponse<RequisaRechazada>.Ok(requisaRechazada);
                }
                else
                {
                    return DBOResponse<RequisaRechazada>.Error("Parte no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<RequisaRechazada>.Error("Error al obtener la Parte: " + ex.Message);
            }
        }

        public async Task<DBOResponse<RequisaRechazada>> obtenerRequisasRechazadasPorNumeroRequisa(string numeroRequisa)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = @"
                    SELECT 
	                    rc.IdRequisaRechazada, rc.Numero_requisa, rc.Descripcion, rc.CreadoPor, rc.modificadoPor, rc.fechaRegistro, rc.fechaModificacion
                    FROM 
	                    Requisas_Rechazadas rc
                    WHERE Numero_requisa = @NumeroRequisa
                ";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@NumeroRequisa", numeroRequisa);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var requisaRechazada = new RequisaRechazada.Builder()
                        .SetId(reader.GetInt32(0))
                        .SetNumeroRequisa(reader.GetString(1))
                        .SetDescripcion(reader.GetString(2))
                        .SetCreadoPor(reader.GetString(3))
                        .SetModificadoPor(reader.GetString(4))
                        .SetFechaCreacion(reader.GetDateTime(5))
                        .SetFechaModificacion(reader.GetDateTime(6))
                        .Build();

                    return DBOResponse<RequisaRechazada>.Ok(requisaRechazada);
                }
                else
                {
                    return DBOResponse<RequisaRechazada>.Error("Parte no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<RequisaRechazada>.Error("Error al obtener la Parte: " + ex.Message);
            }
        }


    }
}
