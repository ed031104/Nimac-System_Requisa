using Dbo;
using Modelos;
using Modelos.data;
using Modelos.Dto;
using Modelos.Enums;
using Modelos.login;
using Modelos.requisas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class RequisaServices
    {
        #region dependencias
        private readonly RequisaAjusteDbo _requisaAjusteDbo;
        private readonly RequisaDbo _requisaDbo;
        private readonly EstadoDbo _estadoDbo;
        private readonly RequisaEstadoDBO _requisaEstadoDbo;
        private readonly RequisaRechazadaDbo _requisaRechazadaDbo;
        #endregion

        public RequisaServices()
        {
            _requisaAjusteDbo = new RequisaAjusteDbo();
            _requisaDbo = new RequisaDbo();
            _requisaEstadoDbo = new RequisaEstadoDBO();
            _estadoDbo = new EstadoDbo();
            _requisaRechazadaDbo = new RequisaRechazadaDbo();
        }

        public async Task<ServiceResponse<bool>> crearRequisaConAjustes(Requisa requisa, IEnumerable<RequisaAjuste> ajustes)
        {
            try
            {

                #region creacion de la requisa
                if (requisa == null || ajustes == null || ajustes.Count() <= 0)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("Requisa o ajustes no pueden ser nulos o vacíos.")
                        .SetSuccess(false)
                        .Build();
                }

                var responseRequisa = await _requisaAjusteDbo.CrearRequisaAjuste(requisa, ajustes.ToList());

                if (!responseRequisa.Success || String.IsNullOrEmpty(responseRequisa.Data))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage(responseRequisa.Message ?? "Excepción no manejada.")
                        .SetSuccess(false)
                        .Build();
                }
                #endregion

                #region Asignacion de Estado
                // Si la creación de la requisa y ajustes fue exitosa, se le asigna estado inicial
                var estadoInicial = await _estadoDbo.ObtenerEstadoPorId((int)Estados.CREADA); // Asumiendo que el ID 1 es el estado inicial
                var requisaBuscada = await _requisaDbo.ObtenerRequisaPorId(responseRequisa.Data);

                if (requisaBuscada == null || !requisaBuscada.Success || requisaBuscada.Data == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("No se pudo encontrar la requisa creada.")
                        .SetSuccess(false)
                        .Build();
                }

                if (estadoInicial == null || !estadoInicial.Success || estadoInicial.Data == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("No se pudo obtener el estado inicial.")
                        .SetSuccess(false)
                        .Build();
                }

                var requisaEstado = new RequisaEstado.Builder()
                    .SetRequisa(requisaBuscada.Data)
                    .SetEstado(estadoInicial.Data)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();

                var responseEstadoRequisa = await _requisaEstadoDbo.crearEstadoRequisa(requisaEstado);

                if (!responseEstadoRequisa.Success || !responseEstadoRequisa.Data)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("No se pudo asignar el estado inicial a la requisa.")
                        .SetSuccess(false)
                        .Build();
                }
                #endregion

                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Requisa y ajustes creados exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetData(false)
                    .SetErrorMessage("Error al crear la requisa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> crearEstadoRequisa(string numeroRequisa, Estado estado)
        {
            try
            {
                if (estado == null || string.IsNullOrEmpty(numeroRequisa))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("El estado de la requisa no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }

                var requisaResponse = await _requisaDbo.ObtenerRequisaPorId(numeroRequisa);

                if( requisaResponse == null || !requisaResponse.Success || requisaResponse.Data == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("No se pudo encontrar la requisa con el número proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }

                var requisaEstado = new RequisaEstado.Builder()
                    .SetRequisa(requisaResponse.Data)
                    .SetEstado(estado)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();

                var response = await _requisaEstadoDbo.crearEstadoRequisa(requisaEstado);
                
                if (!response.Success || !response.Data)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage(response.Message ?? "Excepción no manejada.")
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Estado de la requisa creado exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetData(false)
                    .SetErrorMessage("Error al crear el estado de la requisa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<bool>> RechazarRequisa(string numeroRequisa, Estado estado, string descripcion)
        {
            try
            {
                if (estado == null || string.IsNullOrEmpty(numeroRequisa))
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("El estado de la requisa no puede ser nulo.")
                        .SetSuccess(false)
                        .Build();
                }

                var requisaResponse = await _requisaDbo.ObtenerRequisaPorId(numeroRequisa);

                if (requisaResponse == null || !requisaResponse.Success || requisaResponse.Data == null)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage("No se pudo encontrar la requisa con el número proporcionado.")
                        .SetSuccess(false)
                        .Build();
                }

                var requisaEstado = new RequisaEstado.Builder()
                    .SetRequisa(requisaResponse.Data)
                    .SetEstado(estado)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();

                var response = await _requisaEstadoDbo.crearEstadoRequisa(requisaEstado);

                if (!response.Success || !response.Data)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage(response.Message ?? "Excepción no manejada.")
                        .SetSuccess(false)
                        .Build();
                }

                // Registrar la requisa rechazada

                var requisaRechazada = new RequisaRechazada.Builder()
                    .SetNumeroRequisa(numeroRequisa)
                    .SetDescripcion(descripcion)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();

                var responseRechazada = await _requisaRechazadaDbo.crearRequizaRechazada(requisaRechazada);

                if (!responseRechazada.Success || !responseRechazada.Data)
                {
                    return new ServiceResponse<bool>.Builder()
                        .SetData(false)
                        .SetErrorMessage(responseRechazada.Message ?? "Excepción no manejada al registrar la requisa rechazada.")
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<bool>.Builder()
                    .SetData(true)
                    .SetMessage("Se rechazó exitosamente la Requisa.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>.Builder()
                    .SetData(false)
                    .SetErrorMessage("Error al crear el estado de la requisa: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<RequisaAjuste>>> ObtenerTodasLasRequisasConAjustes()
        {
            try
            {
                var response = await _requisaAjusteDbo.ObtenerRequisaAjustes();
                if (!response.Success || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                        .SetMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Requisas obtenidas exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener las requisas: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<RequisaAjuste>>> ObtenerTodasLasRequisasConAjustesPorIdRequisa(string id)
        {
            try
            {
                var response = await _requisaAjusteDbo.ObtenerRequisaAjustePorIdRequisa(id);
                if (!response.Success || response.Data == null)
                {
                    return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Requisas obtenidas exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetData(null)
                    .SetErrorMessage("Error al obtener las requisas: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Requisa>>> ObtenerTodasLasRequisas()
        {
            try
            {
                var response = await _requisaDbo.ObtenerTodasLasRequisas();
                if (!response.Success || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<Requisa>>.Builder()
                        .SetMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Requisa>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Requisas obtenidas exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Requisa>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener las requisas: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<RequisaJoinEstado>>> ObtenerRequisasagrupadasPorEstado()
        {
            try
            {
                var response = await _requisaDbo.ObtenerRequisasagrupadaPorEstado();
                if (!response.Success || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<RequisaJoinEstado>>.Builder()
                        .SetMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<RequisaJoinEstado>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Requisas agrupadas por estado obtenidas exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RequisaJoinEstado>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener las requisas agrupadas por estado: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<RequisaEstado>>> obtenerEstadosRequisasPorIdRequisa(string idRequisa)
        {
            try
            {
                if (string.IsNullOrEmpty(idRequisa))
                {
                    return new ServiceResponse<IEnumerable<RequisaEstado>>.Builder()
                        .SetData(null)
                        .SetErrorMessage("El ID de la requisa no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _requisaEstadoDbo.obtenerEstadosRequisaPorIdRequisa(idRequisa);
                
                if (!response.Success || response.Data == null)
                {
                    return new ServiceResponse<IEnumerable<RequisaEstado>>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<IEnumerable<RequisaEstado>>.Builder()
                    .SetData(response.Data)
                    .SetErrorMessage("Estados de requisas obtenidos exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RequisaEstado>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener los estados de las requisas: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<IEnumerable<Estado>>> obtenerTodosLosEstados()
        {
            try
            {
                var response = await _estadoDbo.ObtenerEstados();
                if (!response.Success || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<Estado>>.Builder()
                        .SetMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<Estado>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Estados obtenidos exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<Estado>>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener los estados: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
        
        public async Task<ServiceResponse<RequisaRechazada>> obtenerRequisasRechazadasPorNumeroRequisa(string numeroRequisa)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroRequisa))
                {
                    return new ServiceResponse<RequisaRechazada>.Builder()
                        .SetData(null)
                        .SetErrorMessage("El número de requisa no puede ser nulo o vacío.")
                        .SetSuccess(false)
                        .Build();
                }
                var response = await _requisaRechazadaDbo.obtenerRequisasRechazadasPorNumeroRequisa(numeroRequisa);
                
                if (!response.Success || response.Data == null)
                {
                    return new ServiceResponse<RequisaRechazada>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<RequisaRechazada>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Requisa rechazada obtenida exitosamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<RequisaRechazada>.Builder()
                    .SetData(null)
                    .SetMessage("Error al obtener la requisa rechazada: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    }
}
