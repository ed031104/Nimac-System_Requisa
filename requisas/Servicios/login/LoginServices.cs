using Dbo;
using Microsoft.IdentityModel.Tokens;
using Modelos.data;
using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.login
{
    public class LoginServices
    {

        private readonly UsuarioRolDBO _usuarioRolDBO;
        
        public LoginServices()
        {
            _usuarioRolDBO = new UsuarioRolDBO();
        }

        public async Task<ServiceResponse<bool>> isLogin(string correo, string contraseña) { 
            
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                return new ServiceResponse<bool>(false,"Error - " + TypeError.BadRequest + ":" + "Correo o contraseña no pueden estar vacíos.", false);
            }

            var responseDBO = await _usuarioRolDBO.ObtenerUsuarioConRolPorCorreo(correo);
            
            if (!responseDBO.Success || responseDBO.Data == null)
            {
                return new ServiceResponse<bool>(false, "Error - " + TypeError.InternalServerError + ": " + responseDBO.Message, false);
            }
            var usuarioRol = responseDBO.Data;

            if (!usuarioRol.Usuario.CorreoElectronico.Equals(correo) || !usuarioRol.Usuario.Contrasena.Equals(contraseña)) { 
                return new ServiceResponse<bool>(false, "Error - " + TypeError.Unauthorized + ": " + "Correo o contraseña incorrectos.", false);
            }
            return new ServiceResponse<bool>(true, "Usuario autenticado correctamente.", true);
        }
    }
}
