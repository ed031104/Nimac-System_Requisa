using Dbo;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UsuarioServices
    {
        private UsuarioDbo _usuarioDbo;

        public UsuarioServices()
        {
            _usuarioDbo = new UsuarioDbo();
        }

        public async Task<ServiceResponse<IEnumerable<Usuario>>> ObtenerUsuarios()
        {
            var responseDBO = await _usuarioDbo.ObtenerTodosLosUsuarios();
            var response = new ServiceResponse<IEnumerable<Usuario>>();

            if (!responseDBO.Success || responseDBO.Data == null)
            {
                response.Success = false;
                response.Message = "Error - " + TypeError.InternalServerError + ": " + responseDBO.Message;
            }

            response.Data = responseDBO.Data.ToList();
            response.Success = true;
            response.Message = "Usuarios obtenidos correctamente.";
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Usuario>>> ObtenerUsuarioPorCorreoONombre(string email, string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(nombre))
                {
                    return new ServiceResponse<IEnumerable<Usuario>>.Builder()
                        .SetMessage("Debe proporcionar al menos un correo electrónico o nombre.")
                        .SetSuccess(false)
                        .Build();
                }

                var responseDBO = await _usuarioDbo.ObtenerUsuarioPorNombreOCorreo(email, nombre);
                
                if (!responseDBO.Success || responseDBO.Data == null)
                {
                    return new ServiceResponse<IEnumerable<Usuario>>.Builder()
                        .SetMessage("No se encontró el usuario con el correo o nombre proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<Usuario>>.Builder()
                    .SetData(responseDBO.Data)
                    .SetMessage("Usuario obtenido correctamente.")
                    .SetSuccess(true)
                    .Build();

            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Usuario>>.Builder()
                    .SetErrorMessage("Error al obtener el usuario: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<bool>> AgregarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("El usuario no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }
                usuario.CreadoEn = DateTime.Now; // Asignar la fecha de creación al usuario
                var responseDBO = await _usuarioDbo.CrearUsuario(usuario);
                
                if (!responseDBO.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("Error al agregar el usuario: " + responseDBO.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Usuario agregado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al agregar el usuario: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> ActualizarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("El usuario no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }
                var responseDBO = await _usuarioDbo.ActualizarUsuario(usuario);
                
                if (!responseDBO.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("Error al actualizar el usuario: " + responseDBO.Message)
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Usuario actualizado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al actualizar el usuario: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> EliminarUsuario(int id)
        {
            try
            {
                if (int.IsNegative(id))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("El correo electrónico del usuario no puede estar vacío.")
                        .SetSuccess(false)
                        .Build();
                }
                var responseDBO = await _usuarioDbo.EliminarUsuario(id);
                
                if (!responseDBO.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("Error al eliminar el usuario: " + responseDBO.Message)
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Usuario eliminado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al eliminar el usuario: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<Usuario>> obtenerUsuarioPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ServiceResponse<Usuario>.Builder()
                        .SetMessage("El ID del usuario debe ser mayor que cero.")
                        .SetSuccess(false)
                        .Build();
                }
                var responseDBO = await _usuarioDbo.ObtenerUsuarioPorId(id);
                
                if (!responseDBO.Success || responseDBO.Data == null)
                {
                    return new ServiceResponse<Usuario>.Builder()
                        .SetMessage("No se encontró el usuario con el ID proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<Usuario>.Builder()
                    .SetData(responseDBO.Data)
                    .SetMessage("Usuario obtenido correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Usuario>.Builder()
                    .SetErrorMessage("Error al obtener el usuario: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    }
}
