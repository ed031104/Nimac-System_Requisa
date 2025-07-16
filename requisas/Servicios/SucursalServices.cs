
using Dbo;
using Modelos;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SucursalServices
    {
        private SucursalDbo _sucursalDbo;

        public SucursalServices()
        {
            _sucursalDbo = new SucursalDbo();
        }

        public async Task<ServiceResponse<string>> CrearSucursal(Sucursal sucursal)
        {
            try
            {
                if (sucursal == null)
                {
                    return new ServiceResponse<string>.Builder()
                        .SetErrorMessage("Sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }

                if (string.IsNullOrWhiteSpace(sucursal.NumeroSucursal) || string.IsNullOrWhiteSpace(sucursal.NombreSucursal))
                {
                    return new ServiceResponse<string>.Builder()
                        .SetErrorMessage("Número y nombre de sucursal son obligatorios.")
                        .SetSuccess(false)
                        .Build();
                }
                
                sucursal.FechaRegistro = DateTime.Now;
                sucursal.FechaModificacion = DateTime.Now;

                var response = await _sucursalDbo.CrearSucursal(sucursal);

                if (!response.Success)
                {
                    return new ServiceResponse<string>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<string>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal creada exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<bool>> CrearSucursales(List<Sucursal> sucursal)
        {
            try
            {
                if (sucursal == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("Sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _sucursalDbo.CrearSucursalesTransaction(sucursal);

                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Sucursal creada exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }


        public async Task<ServiceResponse<IEnumerable<Sucursal>>> ObtenerSucursales()
        {
            try
            {
                var response = await _sucursalDbo.ObtenerTodasLasSucursales();
                if (!response.Success)
                {
                    return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                .SetData(response.Data)
                .SetMessage("Sucursales obtenidas exitosamente.")
                .SetSuccess(true)
                .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                .SetSuccess(false)
                .SetErrorMessage(ex.Message)
                .Build();
            }
        }

        public async Task<ServiceResponse<Sucursal>> ObtenerSucursalPorNumeroCasa(string numeroCasa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroCasa))
                {
                    return new ServiceResponse<Sucursal>.Builder()
                        .SetErrorMessage("Número de sucursal no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _sucursalDbo.ObtenerSucursalPorCodigoCasa(numeroCasa);

                if (!response.Success)
                {
                    return new ServiceResponse<Sucursal>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<Sucursal>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal obtenida exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Sucursal>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage(ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Sucursal>>> ObtenerSucursalesPorNumeroCasa(string numeroCasa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroCasa))
                {
                    return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                        .SetErrorMessage("Número de sucursal no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _sucursalDbo.ObtenerSucursalesPorCodigoCasa(numeroCasa);

                if (!response.Success || response.Data == null)
                {
                    return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal obtenida exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage(ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> ActualizarSucursal(Sucursal sucursal)
        {
            try
            {
                if (sucursal == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("Sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }
                if (string.IsNullOrWhiteSpace(sucursal.NumeroSucursal) || string.IsNullOrWhiteSpace(sucursal.NombreSucursal))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("Número y nombre de sucursal son obligatorios.")
                        .SetSuccess(false)
                        .Build();
                }
                sucursal.FechaModificacion = DateTime.Now;
                var response = await _sucursalDbo.ActualizarSucursal(sucursal);
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal actualizada exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
        
        public async Task<ServiceResponse<bool>> EliminarSucursal(string numeroSucursal)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroSucursal))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("Número de sucursal no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }
                var response = await _sucursalDbo.EliminarSucursal(numeroSucursal);
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal eliminada exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage(ex.Message)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Sucursal>>> ObtenerSucursalPorNombre(string nombre)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(nombre))
                {
                    return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                        .SetErrorMessage("Nombre de sucursal no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _sucursalDbo.ObtenerSucursalPorNombre(nombre);
                if (!response.Success)
                {
                    return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Sucursal obtenida exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetSuccess(false)
                    .SetErrorMessage(ex.Message)
                    .Build();
            }
        }
    }
}
