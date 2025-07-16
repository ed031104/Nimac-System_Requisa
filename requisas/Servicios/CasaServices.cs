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
    public class CasaServices
    {
        private readonly CasaDbo _casaDbo;

        public CasaServices() {
            _casaDbo = new CasaDbo();
        }


        public async Task<ServiceResponse<IEnumerable<Casa>>> ObtenerTodasLasCasas()
        {
            try {
                var casas = await _casaDbo.ObtenerTodasLasCasas();
                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetData(casas.Data)
                    .SetMessage("Casas obtenidas correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetErrorMessage("Error al obtener las casas: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Casa>>> ObtenerCasaPorCodigo(string codigoCasa)
        {
            try {
                if(string.IsNullOrEmpty(codigoCasa)) {
                    return new ServiceResponse<IEnumerable<Casa>>.Builder()
                        .SetMessage("El código de la casa no puede estar vacío.")
                        .SetSuccess(false)
                        .Build();
                }

                var casa = await _casaDbo.ObtenerCasaPorCodigo(codigoCasa);
                
                if (casa.Data == null) {
                    return new ServiceResponse<IEnumerable<Casa>>.Builder()
                        .SetMessage("No se encontró la casa con el código proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetData(casa.Data)
                    .SetMessage("Casa obtenida correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetErrorMessage("Error al obtener la casa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<bool>> CrearCasa(Casa casa)
        {
            try {
                if (casa == null) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("La casa no puede ser nula.")
                        .SetSuccess(false)
                        .Build();
                }

                casa.FechaRegistro = DateTime.Now;
                casa.FechaModificacion = DateTime.Now;

                var result = await _casaDbo.CrearCasa(casa);
                
                if (!result.Success) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage(result.Message)
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Casa creada correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al crear la casa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> CrearCasas(List<Casa> casas)
        {
            try
            {
                if (casas == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("La casa no puede ser nula.")
                        .SetSuccess(false)
                        .Build();
                }

                var result = await _casaDbo.CrearCasasTransaction(casas);

                if (!result.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(result.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Casa creada correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al crear la casa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> ActualizarCasa(Casa casa)
        {
            try {
                if (casa == null) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("La casa no puede ser nula.")
                        .SetSuccess(false)
                        .Build();
                }
                casa.FechaModificacion = DateTime.Now;
                var result = await _casaDbo.ActualizarCasa(casa);
                
                if (!result.Success) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage(result.Message)
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Casa actualizada correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al actualizar la casa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    
        public async Task<ServiceResponse<bool>> EliminarCasa(string codigoCasa)
        {
            try {
                if (string.IsNullOrEmpty(codigoCasa)) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage("El código de la casa no puede estar vacío.")
                        .SetSuccess(false)
                        .Build();
                }
                var result = await _casaDbo.EliminarCasa(codigoCasa);
                
                if (!result.Success) {
                    return new ServiceResponse<bool>.Builder()
                        .SetMessage(result.Message)
                        .SetSuccess(false)
                        .Build();
                }
                
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Casa eliminada correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al eliminar la casa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    
    }
}
