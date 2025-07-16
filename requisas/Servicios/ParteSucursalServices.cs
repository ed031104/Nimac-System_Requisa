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
    public class ParteSucursalServices
    {
        private readonly ParteSucursalDbo _parteSucursalDbo;
        
        public ParteSucursalServices()
        {
            _parteSucursalDbo = new ParteSucursalDbo();
        }

        public async Task<ServiceResponse<int>> CrearParteSucursal(ParteSucursal parteSucursal)
        {
            try
            {
                if(parteSucursal == null)
                {
                    return new ServiceResponse<int>.Builder()
                        .SetErrorMessage("El parte sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }
                parteSucursal.FechaRegistro = DateTime.Now;
                parteSucursal.FechaModificacion = DateTime.Now;
                var response = await _parteSucursalDbo.CrearParteSucursal(parteSucursal);

                if (response.Data == null)
                {
                    return new ServiceResponse<int>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<int>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Parte sucursal creado exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>.Builder()
                    .SetMessage("Error al crear parte sucursal: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> CrearParteSucursales(List<ParteSucursal> parteSucursal)
        {
            try
            {
                if (parteSucursal == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("El parte sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _parteSucursalDbo.CrearParteSucursalesTransaction(parteSucursal);

                if (!response.Data)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Parte sucursal creado exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetErrorMessage("Error al crear parte sucursal: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }


        public async Task<ServiceResponse<IEnumerable<ParteSucursal>>> obtenerPartePorNumeroParte(string numeroParte) {
            try { 
           
                var response = await _parteSucursalDbo.ObtenerParteSucursalPorIdParte(numeroParte);
           
                if (response.Data == null) {
                    return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                if (!response.Data.Any()) {
                    return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                        .SetData(null)
                        .SetErrorMessage("No se encontraron partes relacionadas a sucursales con el número proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetData(response.Data)
                    .SetErrorMessage("Parte obtenido exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetData(null)
                    .SetErrorMessage("Error al obtener el parte por número: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<ParteSucursal>>> ObtenerPartesSucursal()
        {
            try
            {
                var response = await _parteSucursalDbo.ObtenerTodasLasPartesSucursal();

                if (response.Data == null || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                        .SetData(null)
                        .SetMessage("No se encontraron partes sucursales.")
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Partes sucursales obtenidos exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener partes sucursales: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<bool>> ActualizarParteSucursal(ParteSucursal parteSucursal)
        {
            try
            {
                if (parteSucursal == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage("El parte sucursal no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }
                parteSucursal.FechaModificacion = DateTime.Now;
                var response = await _parteSucursalDbo.ActualizarParteSucursal(parteSucursal);
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Parte sucursal actualizado exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetMessage("Error al actualizar parte sucursal: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> EliminarParteSucursal(int idParteSucursal)
        {
            try
            {
                var response = await _parteSucursalDbo.EliminarParteSucursal(idParteSucursal);
                if (!response.Success)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Parte sucursal eliminado exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetMessage("Error al eliminar parte sucursal: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    }
}
