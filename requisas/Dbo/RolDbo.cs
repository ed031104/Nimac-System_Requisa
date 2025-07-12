using Microsoft.Data.SqlClient;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class RolDbo 
    {
        public RolDbo()
        {
        }

        public async Task<DBOResponse<int>> CrearRol(Role rol)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("insert into Roles(Descripcion, Nombre_Rol) ");
            query.Append("values(@Descripcion, @NombreROl); ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
            cmd.Parameters.AddWithValue("@NombreROl", rol.NombreRol);
            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear el Rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Role>> ObtenerRolPorId(int id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Rol, Nombre_Rol, Descripcion FROM Roles ");
                query.Append("WHERE id_Rol = @IdRol");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@IdRol", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {

                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Rol")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();

                    return DBOResponse<Role>.Ok(rol);
                }
                else
                {
                    return DBOResponse<Role>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Role>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Role>> ObtenerRolPorNombre(string nombre)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Rol, Nombre_Rol, Descripcion FROM Roles ");
                query.Append("WHERE id_Rol = @Nombre");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Rol")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();

                    return DBOResponse<Role>.Ok(rol);
                }
                else
                {
                    return DBOResponse<Role>.Error("Rol no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Role>.Error("Error al obtener el Rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarRol(Role rol)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Roles ");
            query.Append("SET ");
            query.Append("Nombre_Rol = @Nombre, ");
            query.Append("Descripcion = @Descripcion ");
            query.Append("WHERE ");
            query.Append("id_Rol = @IdRol");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdRol", rol.IdRole);
            cmd.Parameters.AddWithValue("@Nombre", rol.NombreRol);
            cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ningún rol. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar el rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarRol(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Roles ");
            query.Append("WHERE ");
            query.Append("id_Rol = @IdRol");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdRol", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ningún rol. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar el rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Role>>> ObtenerTodosLosRoles()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Rol, Nombre_Rol, Descripcion ");
                query.Append("FROM Roles");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var roles = new List<Role>();
                while (await reader.ReadAsync())
                {
                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Rol")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();
                    roles.Add(rol);
                }
                return DBOResponse<IEnumerable<Role>>.Ok(roles);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Role>>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }
    }
}
