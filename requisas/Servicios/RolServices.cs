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
    public class RolServices
    {
        private readonly RolDbo _rolDbo;

        public RolServices()
        {
            _rolDbo = new RolDbo();
        }

        public async Task<ServiceResponse<IEnumerable<Role>>> ObtenerRoles()
        {
            var responseDBO = await _rolDbo.ObtenerTodosLosRoles();
            
            if (!responseDBO.Success || responseDBO.Data == null)
            {
                return new ServiceResponse<IEnumerable<Role>>.Builder()
                .SetSuccess(false)
                .SetErrorMessage("Error - " + TypeError.InternalServerError + ": " + responseDBO.Message)
                .Build();
            }

            return new ServiceResponse<IEnumerable<Role>>.Builder()
                .SetData(responseDBO.Data.ToList())
                .SetMessage("Roles obtenidos correctamente.")
                .SetSuccess(true)
                .Build();            
        }
        
        public async Task<ServiceResponse<bool>> ActualizarRol(Role rol)
        {
            if (rol == null)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("El rol no puede ser nulo.")
                    .Build();
            }
            var responseDBO = await _rolDbo.ActualizarRol(rol);
            
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al actualizar el rol: " + responseDBO.Message)
                    .Build();
            }
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol actualizado correctamente.")
                .SetSuccess(true)
                .Build();
        }

        public async Task<ServiceResponse<bool>> EliminarRol(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("El ID del rol debe ser mayor que cero.")
                    .Build();
            }
            
            var responseDBO = await _rolDbo.EliminarRol(id);
            
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al eliminar el rol: " + responseDBO.Message)
                    .Build();
            }
            
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol eliminado correctamente.")
                .SetSuccess(true)
                .Build();
        }

        public async Task<ServiceResponse<Role>> ObtenerRolPorId(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<Role>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("El ID del rol debe ser mayor que cero.")
                    .Build();
            }
            
            var responseDBO = await _rolDbo.ObtenerRolPorId(id);
            
            if (!responseDBO.Success || responseDBO.Data == null)
            {
                return new ServiceResponse<Role>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al obtener el rol: " + responseDBO.Message)
                    .Build();
            }
            
            return new ServiceResponse<Role>.Builder()
                .SetData(responseDBO.Data)
                .SetMessage("Rol obtenido correctamente.")
                .SetSuccess(true)
                .Build();
        }

        public async Task<ServiceResponse<bool>> CrearRol(Role rol)
        {
            if (rol == null)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("El rol no puede ser nulo.")
                    .Build();
            }
            
            var responseDBO = await _rolDbo.CrearRol(rol);
            
            if (!responseDBO.Success)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al crear el rol: " + responseDBO.Message)
                    .Build();
            }
            
            return new ServiceResponse<bool>.Builder()
                .SetData(true)
                .SetMessage("Rol creado correctamente.")
                .SetSuccess(true)
                .Build();
        }

    }
}
