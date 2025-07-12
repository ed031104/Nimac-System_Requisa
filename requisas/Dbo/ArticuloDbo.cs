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
    public class ArticuloDBO
    {
        public ArticuloDBO() { }

        public async Task<DBOResponse<int>> CrearArticulo(Articulos articulo)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("insert into Articulos(id_Articulo, codigo_articulo, descripcion, unidad_medida, categoria, precio_unitario, proveedor, fecha_registro, fecha_modificacion) ");
            query.Append("VALUE(@id_Articulo, @codigo_articulo, @descripcion, @unidad_medida, @categoria, @precio_unitario, @proveedor, @fecha_registro, @fecha_modificacion) ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@id_Articulo", articulo.IdArticulo);
            cmd.Parameters.AddWithValue("@codigo_articulo", articulo.CodigoArticulo);
            cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
            cmd.Parameters.AddWithValue("@unidad_medida", articulo.UnidadMedida);
            cmd.Parameters.AddWithValue("@categoria", articulo.Categoria);
            cmd.Parameters.AddWithValue("@precio_unitario", articulo.PrecioUnitario);
            cmd.Parameters.AddWithValue("@proveedor", articulo.Proveedor);
            cmd.Parameters.AddWithValue("@fecha_registro", articulo.FechaRegistro);
            cmd.Parameters.AddWithValue("@fecha_modificacion", articulo.FechaModificacion);

            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear el artículo: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Articulos>> ObtenerArticuloPorCodigo(string codigo) 
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select id_Articulo, codigo_articulo, descripcion, unidad_medida, categoria, precio_unitario, proveedor, fecha_registro, fecha_modificacion from Articulos ");
                query.Append("WHERE codigo_articulo = @CodigoArticulo");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@CodigoArticulo", codigo);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var articulo = new Articulos.Builder()
                        .SetIdArticulo(reader.GetInt32(reader.GetOrdinal("id_Articulo")))
                        .SetCodigoArticulo(reader.GetString(reader.GetOrdinal("codigo_articulo")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcion")))
                        .SetUnidadMedida(reader.GetString(reader.GetOrdinal("unidad_medida")))
                        .SetCategoria(reader.GetString(reader.GetOrdinal("categoria")))
                        .SetPrecioUnitario(reader.GetDecimal(reader.GetOrdinal("precio_unitario")))
                        .SetProveedor(reader.GetString(reader.GetOrdinal("proveedor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fecha_registro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fecha_modificacion")))
                        .Build();

                    return DBOResponse<Articulos>.Ok(articulo);
                }
                else
                {
                    return DBOResponse<Articulos>.Error("Articulo no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Articulos>.Error("Error al obtener el Articulo: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarArticulo(Articulos articulo)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("update Articulos");
            query.Append("SET ");
            query.Append("codigo_articulo = @codigo_articulo, ");
            query.Append("descripcion = @descripcion, ");
            query.Append("unidad_medida = @unidad_medida, ");
            query.Append("categoria = @categoria, ");
            query.Append("precio_unitario = @precio_unitario, ");
            query.Append("fecha_modificacion = @fecha_modificacion ");
            query.Append("WHERE ");
            query.Append("id_Articulo = @id_Articulo;");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@codigo_articulo", articulo.CodigoArticulo);
            cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
            cmd.Parameters.AddWithValue("@unidad_medida", articulo.UnidadMedida);
            cmd.Parameters.AddWithValue("@categoria", articulo.Categoria);
            cmd.Parameters.AddWithValue("@precio_unitario", articulo.PrecioUnitario);
            cmd.Parameters.AddWithValue("@fecha_modificacion", articulo.FechaModificacion);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ningún Artículo. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar el Artículo: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarArticulo(string codigo)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Articulos ");
            query.Append("where codigo_articulo = @CodigoArticulo");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@CodigoArticulo", codigo);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ningún Artículo. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar el Artículo: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Articulos>>> ObtenerTodosLosArticulos()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select id_Articulo, codigo_articulo, descripcion, unidad_medida, categoria, precio_unitario, proveedor, fecha_registro, fecha_modificacion ");
                query.Append("from Articulos");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var articulos = new List<Articulos>();
                while (await reader.ReadAsync())
                {
                    var articulo = new Articulos.Builder()
                        .SetIdArticulo(reader.GetInt32(reader.GetOrdinal("id_Articulo")))
                        .SetCodigoArticulo(reader.GetString(reader.GetOrdinal("codigo_articulo")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("descripcion")))
                        .SetUnidadMedida(reader.GetString(reader.GetOrdinal("unidad_medida")))
                        .SetCategoria(reader.GetString(reader.GetOrdinal("categoria")))
                        .SetPrecioUnitario(reader.GetDecimal(reader.GetOrdinal("precio_unitario")))
                        .SetProveedor(reader.GetString(reader.GetOrdinal("proveedor")))
                        .SetFechaRegistro(reader.GetDateTime(reader.GetOrdinal("fecha_registro")))
                        .SetFechaModificacion(reader.GetDateTime(reader.GetOrdinal("fecha_modificacion")))
                        .Build();

                    articulos.Add(articulo);
                }
                return DBOResponse<IEnumerable<Articulos>>.Ok(articulos);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Articulos>>.Error("Error al obtener los Artículos: " + ex.Message);
            }
        }
    }
}
