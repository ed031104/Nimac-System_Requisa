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
    public class UsuarioRolDBO : IDisposable
    {
        public UsuarioRolDBO()
        {
        }

        public async Task<DBOResponse<int>> CrearUsuarioConRol(UsuarioRol usuarioAndRol)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("INSERT INTO Usuarios_Roles(id_Usuario, id_Rol, Asignado_En) ");
            query.Append("values(@IdUsuario, @IdRol, @FechaAsignacion) ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdUsuario", usuarioAndRol.Usuario.Id);
            cmd.Parameters.AddWithValue("@IdRol", usuarioAndRol.Rol.IdRole);
            cmd.Parameters.AddWithValue("@FechaAsignacion", usuarioAndRol.AsignadoEn);
            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear el usuario con su rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<UsuarioRol>> ObtenerUsuarioConRolPorId(int id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select ur.Id,u.id_Usuario, u.Nombre, u.Correo_Electronico, u.Contrasena, u.Creado_En, r.id_Rol, r.Nombre_Rol, r.Nombre_Rol ");
                query.Append("from Usuarios_Roles ur ");
                query.Append("INNER JOIN Usuarios u on u.id_Usuario = ur.id_Usuario ");
                query.Append("INNER JOIN Roles r on r.id_Rol = ur.id_Rol");
                query.Append("WHERE u.id_Usuario = @IdUsuario");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@IdUsuario", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    Usuario usuario = new Usuario.Builder()
                        .SetId(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("Nombre")))
                        .SetCorreoElectronico(reader.GetString(reader.GetOrdinal("Correo_Electronico")))
                        .SetContrasena(reader.GetString(reader.GetOrdinal("Contrasena")))
                        .SetCreadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();

                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();

                    UsuarioRol usuarioRol = new UsuarioRol.Builder()
                        .SetIdUsuarioRol(reader.GetInt32(reader.GetOrdinal("Id")))
                        .SetUsuario(usuario)
                        .SetRol(rol)
                        .SetAsignadoEn(reader.GetDateTime(reader.GetOrdinal("Asignado_En")))
                        .Build();
                    return DBOResponse<UsuarioRol>.Ok(usuarioRol);
                }
                else
                {
                    return DBOResponse<UsuarioRol>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<UsuarioRol>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<UsuarioRol>> ObtenerUsuarioConRolPorCorreo(string correoElectronico)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select ur.Id, u.id_Usuario, u.Nombre, u.Correo_Electronico, u.Contrasena, u.Creado_En, r.id_Rol, r.Nombre_Rol, r.Nombre_Rol, r.Descripcion ");
                query.Append("from Usuarios_Roles ur ");
                query.Append("INNER JOIN Usuarios u on u.id_Usuario = ur.id_Usuario ");
                query.Append("INNER JOIN Roles r on r.id_Rol = ur.id_Rol ");
                query.Append("WHERE u.Correo_Electronico = @Correo");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Correo", correoElectronico);

                await using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    Usuario usuario = new Usuario.Builder()
                        .SetId(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("Nombre")))
                        .SetCorreoElectronico(reader.GetString(reader.GetOrdinal("Correo_Electronico")))
                        .SetContrasena(reader.GetString(reader.GetOrdinal("Contrasena")))
                        .SetCreadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();

                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Rol")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();

                    UsuarioRol usuarioRol = new UsuarioRol.Builder()
                        .SetIdUsuarioRol(reader.GetInt32(reader.GetOrdinal("Id")))
                        .SetUsuario(usuario)
                        .SetRol(rol)
                        .SetAsignadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();
                    return DBOResponse<UsuarioRol>.Ok(usuarioRol);
                }
                else
                {
                    return DBOResponse<UsuarioRol>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<UsuarioRol>.Error("Error al obtener el usuario: " + ex.Message);

            }
        }

        public async Task<DBOResponse<bool>> ActualizarUsuario(UsuarioRol usuarioAndRol)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Usuarios_Roles ");
            query.Append("SET ");
            query.Append("id_Rol = @IdRol ");
            query.Append("where Usuarios_Roles.Id = @IdUsuarioRol");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdRol", usuarioAndRol.Rol.IdRole);
            cmd.Parameters.AddWithValue("@IdUsuarioRol", usuarioAndRol.IdUsuarioRol);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected <= 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ningún usuario con rol. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar el usuario con su rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarUsuario(int idUsuario)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Usuarios_Roles ");
            query.Append("WHERE ");
            query.Append("Id = @IdUsuarioRol");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();
            cmd.Parameters.AddWithValue("@IdUsuarioRol", idUsuario);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ningún usuario con rol. Verifique los ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar el usuario con rol: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<UsuarioRol>>> ObtenerTodosLosUsuarios()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("select ur.Id,u.id_Usuario, u.Nombre, u.Correo_Electronico, u.Contrasena, u.Creado_En, r.id_Rol, r.Nombre_Rol, r.Descripcion, ur.Asignado_En ");
                query.Append("from Usuarios_Roles ur ");
                query.Append("INNER JOIN Usuarios u on u.id_Usuario = ur.id_Usuario ");
                query.Append("INNER JOIN Roles r on r.id_Rol = ur.id_Rol");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var usuariosRoles = new List<UsuarioRol>();
                while (await reader.ReadAsync())
                {
                    Usuario usuario = new Usuario.Builder()
                        .SetId(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("Nombre")))
                        .SetCorreoElectronico(reader.GetString(reader.GetOrdinal("Correo_Electronico")))
                        .SetContrasena(reader.GetString(reader.GetOrdinal("Contrasena")))
                        .SetCreadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();

                    Role rol = new Role.Builder()
                        .SetIdRole(reader.GetInt32(reader.GetOrdinal("id_Rol")))
                        .SetNombreRol(reader.GetString(reader.GetOrdinal("Nombre_Rol")))
                        .SetDescripcion(reader.GetString(reader.GetOrdinal("Descripcion")))
                        .Build();

                    UsuarioRol usuarioRol = new UsuarioRol.Builder()
                        .SetIdUsuarioRol(reader.GetInt32(reader.GetOrdinal("Id")))
                        .SetUsuario(usuario)
                        .SetRol(rol)
                        .SetAsignadoEn(reader.GetDateTime(reader.GetOrdinal("Asignado_En")))
                        .Build();
                    usuariosRoles.Add(usuarioRol);
                }
                return DBOResponse<IEnumerable<UsuarioRol>>.Ok(usuariosRoles);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<UsuarioRol>>.Error("Error al obtener el usuario: " + ex.Message);

            }
        }

        public void Dispose()
        {
        }
    }
}
