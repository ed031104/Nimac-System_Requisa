using Dbo;
using Microsoft.IdentityModel.Tokens;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UsuarioRolServices
    {
        private readonly UsuarioRolDBO _usuarioRolDbo;

        public UsuarioRolServices()
        {
            _usuarioRolDbo = new UsuarioRolDBO();
        }

        public async Task<ServiceResponse<UsuarioRol>> ObtenerUsuarioConRolesPorCorreo(string correo)
        {
            if (correo.IsNullOrEmpty())
            {
                return new ServiceResponse<UsuarioRol>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.BadRequest + @": El correo de usuario no debe estar vacío.")
                    .Build();
            }

            var responseDBO = await _usuarioRolDbo.ObtenerUsuarioConRolPorCorreo(correo);

            if (!responseDBO.Success || responseDBO.Data == null)
            {
                return new ServiceResponse<UsuarioRol>.Builder()
                .SetSuccess(false)
                .SetErrorMessage("Error - " + TypeError.InternalServerError + ": " + responseDBO.Message)
                .Build();
            }
            return new ServiceResponse<UsuarioRol>.Builder()
                .SetData(responseDBO.Data)
                .SetMessage("Roles obtenidos correctamente.")
                .SetSuccess(true)
                .Build();
        }

        public async Task<ServiceResponse<IEnumerable<UsuarioRol>>> ObtenerUsuariosConRoles()
        {
            try {
                var responseDBO = await _usuarioRolDbo.ObtenerTodosLosUsuarios();

                if (!responseDBO.Success || responseDBO.Data == null)
                {
                    return new ServiceResponse<IEnumerable<UsuarioRol>>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.InternalServerError + ": " + responseDBO.Message)
                    .Build();
                }
                return new ServiceResponse<IEnumerable<UsuarioRol>>.Builder()
                    .SetData(responseDBO.Data.ToList())
                    .SetMessage("Usuarios con roles obtenidos correctamente.")
                    .SetSuccess(true)
                    .Build();
            } catch(Exception ex) {
                return new ServiceResponse<IEnumerable<UsuarioRol>>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.InternalServerError + ": " + ex.Message)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<bool>> AsignarRolAUsuario(UsuarioRol usuarioRol)
        {
            if (usuarioRol == null || usuarioRol.Usuario == null || usuarioRol.Rol == null)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.BadRequest + @": El usuario o el rol no pueden ser nulos.")
                    .Build();
            }
            usuarioRol.AsignadoEn = DateTime.Now;
            var responseDBO = await _usuarioRolDbo.CrearUsuarioConRol(usuarioRol);
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al asignar rol al usuario: " + responseDBO.Message)
                    .Build();
            }
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol asignado al usuario correctamente.")
                .SetSuccess(true)
                .Build();
        }
        
        public async Task<ServiceResponse<bool>> EliminarRolDeUsuario(int idUsuarioRol)
        {
            if (idUsuarioRol  <= 0 )
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.BadRequest + @": El ID del usuario con Rol deben ser mayores que cero.")
                    .Build();
            }
            var responseDBO = await _usuarioRolDbo.EliminarUsuario(idUsuarioRol);
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al eliminar el rol del usuario: " + responseDBO.Message)
                    .Build();
            }
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol eliminado del usuario correctamente.")
                .SetSuccess(true)
                .Build();
        }

        public async Task<ServiceResponse<bool>> ActualizarRolDeUsuario(UsuarioRol usuarioRol)
        {
            if (usuarioRol == null || usuarioRol.Usuario == null || usuarioRol.Rol == null)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error - " + TypeError.BadRequest + @": El usuario o el rol no pueden ser nulos.")
                    .Build();
            }
            var responseDBO = await _usuarioRolDbo.ActualizarUsuario(usuarioRol);
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al actualizar el rol del usuario: " + responseDBO.Message)
                    .Build();
            }
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol del usuario actualizado correctamente.")
                .SetSuccess(true)
                .Build();
        }

    }
}
