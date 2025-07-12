using Dbo;
using Modelos;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ParteServices
    {

        private readonly ParteDbo _parteDbo;

        public ParteServices()
        {
            _parteDbo = new ParteDbo();
        }

        public async Task<ServiceResponse<string>> CrearParte(Parte parte)
        {
            try
            {
                if (parte == null)
                {
                    return new ServiceResponse<string>.Builder()
                        .SetSuccess(false)
                        .SetErrorMessage("El objeto Parte no puede ser nulo.")
                        .Build();
                }
                
                parte.FechaRegistro = DateTime.Now;
                parte.FechaModificacion = DateTime.Now;

                var response = await _parteDbo.CrearParte(parte);
                
                if (!response.Success)
                {
                    return new ServiceResponse<string>.Builder()
                        .SetSuccess(false)
                        .SetErrorMessage(response.Message)
                        .Build();
                }

                return new ServiceResponse<string>.Builder()
                    .SetData(response.Data)
                    .SetSuccess(true)
                    .SetMessage("Parte creada exitosamente.")
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string >.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage("Error al crear la Parte: " +ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<Parte>> ObtenerPartePorId(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new ServiceResponse<Parte>.Builder()
                        .SetSuccess(false)
                        .SetMessage("El ID de la Parte no puede ser nulo o vacío.")
                        .Build();
                }
                var response = await _parteDbo.ObtenerPartePorId(id);
                
                if (!response.Success)
                {
                    return new ServiceResponse<Parte>.Builder()
                        .SetSuccess(false)
                        .SetMessage(response.Message)
                        .Build();
                }
                return new ServiceResponse<Parte>.Builder().
                        SetData(response.Data)
                        .SetSuccess(true)
                        .SetMessage("Parte obtenida exitosamente.")
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Parte>.Builder()
                    .SetSuccess(false)
                    .SetMessage("Error al obtener la Parte: " + ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Parte>>> ObtenerPartes()
        {
            try
            {
                var response = await _parteDbo.ObtenerTodasLasPartes();
                
                if (!response.Success)
                {
                    return new ServiceResponse<IEnumerable<Parte>>.Builder()
                        .SetSuccess(false)
                        .SetMessage(response.Message)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetData(response.Data)
                    .SetSuccess(true)
                    .SetMessage("Partes obtenidas exitosamente.")
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetSuccess(false)
                    .SetMessage("Error al obtener las Partes: " + ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> ActualizarParte(Parte parte)
        {
            try
            {
                if (parte == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetSuccess(false)
                        .SetMessage("El objeto Parte no puede ser nulo.")
                        .Build();
                }
                
                parte.FechaModificacion = DateTime.Now;
                var response = await _parteDbo.ActualizarParte(parte);
                
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetSuccess(false)
                        .SetMessage(response.Message)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(response.Data)
                    .SetSuccess(true)
                    .SetMessage("Parte actualizada exitosamente.")
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetMessage("Error al actualizar la Parte: " + ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> EliminarParte(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetSuccess(false)
                        .SetMessage("El ID de la Parte no puede ser nulo o vacío.")
                        .Build();
                }
                
                var response = await _parteDbo.EliminarParte(id);
                
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetSuccess(false)
                        .SetMessage(response.Message)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(response.Data)
                    .SetSuccess(true)
                    .SetMessage("Parte eliminada exitosamente.")
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetMessage("Error al eliminar la Parte: " + ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Parte>>> obtenerPartesPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    return new ServiceResponse<IEnumerable<Parte>>.Builder()
                        .SetSuccess(false)
                        .SetMessage("El nombre de la Parte no puede ser nulo o vacío.")
                        .Build();
                }
                
                var response = await _parteDbo.ObtenerPartesPorNombre(nombre);
                
                if (!response.Success)
                {
                    return new ServiceResponse<IEnumerable<Parte>>.Builder()
                        .SetSuccess(false)
                        .SetMessage(response.Message)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetData(response.Data)
                    .SetSuccess(true)
                    .SetMessage("Partes obtenidas por nombre exitosamente.")
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetSuccess(false)
                    .SetMessage("Error al obtener las Partes por nombre: " + ex.Message)
                    .Build();
            }
        }
    }
}
