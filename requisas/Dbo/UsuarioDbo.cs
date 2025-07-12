using Microsoft.Data.SqlClient;
using Modelos.data;
using Modelos.login;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class UsuarioDbo : IDisposable
    {
        public UsuarioDbo()
        {
        }

        public async Task<DBOResponse<int>> CrearUsuario(Usuario usuario)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("INSERT INTO Usuarios (Nombre, Correo_Electronico, Contrasena, Creado_En) ");
            query.Append("VALUES (@Nombre, @CorreoElectronico, @Contrasena, @FechaRegistro); ");
            query.Append("SELECT SCOPE_IDENTITY();");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
            cmd.Parameters.AddWithValue("@FechaRegistro", usuario.CreadoEn);
            try
            {
                return DBOResponse<int>.Ok(Convert.ToInt32(await cmd.ExecuteScalarAsync()));
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<int>.Error("Error al crear el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Usuario>> ObtenerUsuarioPorId(int id)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Usuario, Nombre, Correo_Electronico, Contrasena, Creado_En ");
                query.Append("FROM Usuarios WHERE id_Usuario = @IdUsuario");

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

                    return DBOResponse<Usuario>.Ok(usuario);
                }
                else
                {
                    return DBOResponse<Usuario>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Usuario>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<Usuario>> ObtenerUsuarioPorCorreo(string correoElectronico)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Usuario, Nombre, Correo_Electronico, Contrasena, Creado_En ");
                query.Append("FROM Usuarios WHERE Correo_Electronico = @Correo_Electronico");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Correo_Electronico", correoElectronico);

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

                    return DBOResponse<Usuario>.Ok(usuario);
                }
                else
                {
                    return DBOResponse<Usuario>.Error("Usuario no encontrado.");
                }
            }
            catch (SqlException ex)
            {
                return DBOResponse<Usuario>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Usuario>>> ObtenerUsuarioPorNombreOCorreo(string correoElectronico, string nombre)
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Usuario, Nombre, Correo_Electronico, Contrasena, Creado_En ");
                query.Append("FROM Usuarios WHERE Correo_Electronico LIKE '%' + @Correo_Electronico + '%'");
                query.Append("OR Nombre LIKE '%' + @Nombre + '%'");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();
                cmd.Parameters.AddWithValue("@Correo_Electronico", correoElectronico);
                cmd.Parameters.AddWithValue("@Nombre", nombre);


                await using var reader = await cmd.ExecuteReaderAsync();

                var usuarios = new List<Usuario>();

                while (await reader.ReadAsync())
                {
                    Usuario usuario = new Usuario.Builder()
                        .SetId(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("Nombre")))
                        .SetCorreoElectronico(reader.GetString(reader.GetOrdinal("Correo_Electronico")))
                        .SetContrasena(reader.GetString(reader.GetOrdinal("Contrasena")))
                        .SetCreadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();
                    usuarios.Add(usuario);
                }
                    return DBOResponse<IEnumerable<Usuario>>.Ok(usuarios);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Usuario>>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> ActualizarUsuario(Usuario usuario)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("UPDATE Usuarios ");
            query.Append("SET ");
            query.Append("Nombre = @Nombre, ");
            query.Append("Correo_Electronico = @CorreoElectronico,");
            query.Append("Contrasena = @Contraseña ");
            query.Append("WHERE ");
            query.Append("id_Usuario = @IdUsuario");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdUsuario", usuario.Id);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Contrasena);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se actualizó ningún usuario. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al actualizar el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<bool>> EliminarUsuario(int id)
        {
            await using var conn = Conexion.conexion();
            await conn.OpenAsync();

            var query = new StringBuilder();

            query.Append("DELETE FROM Usuarios ");
            query.Append("WHERE ");
            query.Append("id_Usuario = @IdUsuario");

            var cmd = conn.CreateCommand();

            cmd.CommandText = query.ToString();

            cmd.Parameters.AddWithValue("@IdUsuario", id);
            try
            {
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    return DBOResponse<bool>.Error("No se eliminó ningún usuario. Verifique el ID.");
                }
                return DBOResponse<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                // Manejo de excepciones
                return DBOResponse<bool>.Error("Error al eliminar el usuario: " + ex.Message);
            }
        }

        public async Task<DBOResponse<IEnumerable<Usuario>>> ObtenerTodosLosUsuarios()
        {
            try
            {
                await using var conn = Conexion.conexion();
                await conn.OpenAsync();

                var query = new StringBuilder();
                query.Append("SELECT id_Usuario, Nombre, Correo_Electronico, Contrasena, Creado_En ");
                query.Append("FROM Usuarios");

                using var cmd = conn.CreateCommand();
                cmd.CommandText = query.ToString();

                await using var reader = await cmd.ExecuteReaderAsync();

                var usuarios = new List<Usuario>();
                while (await reader.ReadAsync())
                {
                    Usuario usuario = new Usuario.Builder()
                        .SetId(reader.GetInt32(reader.GetOrdinal("id_Usuario")))
                        .SetNombre(reader.GetString(reader.GetOrdinal("Nombre")))
                        .SetCorreoElectronico(reader.GetString(reader.GetOrdinal("Correo_Electronico")))
                        .SetContrasena(reader.GetString(reader.GetOrdinal("Contrasena")))
                        .SetCreadoEn(reader.GetDateTime(reader.GetOrdinal("Creado_En")))
                        .Build();
                    usuarios.Add(usuario);
                }
                    return DBOResponse<IEnumerable<Usuario>>.Ok(usuarios);
            }
            catch (SqlException ex)
            {
                return DBOResponse<IEnumerable<Usuario>>.Error("Error al obtener el usuario: " + ex.Message);
            }
        }

        public void Dispose()
        {
        }
    }
}