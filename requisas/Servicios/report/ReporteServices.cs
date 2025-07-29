using Dbo;
using Modelos.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.report
{
    public class ReporteServices
    {

        private readonly ExecuteStoredProcedure _executeStoredProcedure;

        public ReporteServices()
        {
            _executeStoredProcedure = new ExecuteStoredProcedure();
        }

        public async Task<ServiceResponse<DataTable>> obtenerUsuariosDT(Dictionary<String, object> parametros) {
            try {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:UsuarioSP");
                
                if (string.IsNullOrEmpty(nameSP)) {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }
                
                var response = await _executeStoredProcedure.ExecuteSP(parametros, nameSP);
                
                if (!response.Success) {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();                    
                }
                
                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch(Exception ex) {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<DataTable>> obtenerRequisasConAjustesPorNumeroRequisa(Dictionary<String, object> parametros)
        {
            try
            {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:RequisaAjusteSP");

                if (string.IsNullOrEmpty(nameSP))
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _executeStoredProcedure.ExecuteSP(parametros, nameSP);

                if (!response.Success)
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<DataTable>> obtenerRequisaAjustesConEstados(Dictionary<String, object> parametros)
        {
            try
            {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:RequisaAjusteEstadoSP");

                if (string.IsNullOrEmpty(nameSP))
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _executeStoredProcedure.ExecuteSP(parametros, nameSP);

                if (!response.Success)
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<DataTable>> obtenerPartes(Dictionary<String, object> parametros)
        {
            try
            {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:ParteSp");

                if (string.IsNullOrEmpty(nameSP))
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _executeStoredProcedure.ExecuteSP(parametros, nameSP);

                if (!response.Success)
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<DataTable>> obtenerRequisasAgrupadasPorEstado(Dictionary<String, object> parametros)
        {
            try
            {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:CantidadRequisasEstadoSp");

                if (string.IsNullOrEmpty(nameSP))
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _executeStoredProcedure.ExecuteSP(parametros ,nameSP);

                if (!response.Success)
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<DataTable>> obtenerDetallesRequisasAgrupadasPorEstado(Dictionary<String, object> parametros)
        {
            try
            {
                var nameSP = Configuraciones.Configuracion.Get("nameSP:DetallesCantidadRequisasEstadoSp");

                if (string.IsNullOrEmpty(nameSP))
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage("El nombre del procedimiento almacenado no está configurado.")
                        .SetSuccess(false)
                        .Build();
                }

                var response = await _executeStoredProcedure.ExecuteSP(parametros, nameSP);

                if (!response.Success)
                {
                    return new ServiceResponse<DataTable>.Builder()
                        .SetErrorMessage(response.Message)
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<DataTable>.Builder()
                        .SetData(response.Data)
                        .SetMessage("Usuarios obtenidos correctamente.")
                        .SetSuccess(true)
                        .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DataTable>.Builder()
                    .SetErrorMessage("Error al obtener los usuarios: " + ex.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }
    }
}
