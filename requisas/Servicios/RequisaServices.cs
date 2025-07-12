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
    public class RequisaServices
    {
        private readonly RequisaAjusteDbo _requisaAjusteDbo;
        private readonly RequisaDbo _requisaDbo;

        public RequisaServices()
        {
            _requisaAjusteDbo = new RequisaAjusteDbo();
            _requisaDbo = new RequisaDbo();
        }

        //public async Task<ServiceResponse<bool>> crearRequisa(Requisa requisa, IEnumerable<RequisaAjuste> ajustes)
        //{
        //    try
        //    {
        //        if (requisa == null || ajustes == null || ajustes.Count() <= 0)
        //        {
        //            return new ServiceResponse<bool>.Builder()
        //                .SetData(false)
        //                .SetMessage("Requisa o ajustes no pueden ser nulos o vacíos.")
        //                .SetSuccess(false)
        //                .Build();
        //        }

        //        var responseRequisa = await _requisaDbo.CrearRequisa(requisa);
        //        if (responseRequisa.Data < 0)
        //        {
        //            return new ServiceResponse<bool>.Builder()
        //                .SetData(false)
        //                .SetMessage(responseRequisa.Message)
        //                .SetSuccess(false)
        //                .Build();
        //        }

        //        foreach (var ajuste in ajustes)
        //        {
        //            ajuste.Requisa = requisa;
        //            var responseAjuste = await _requisaAjusteDbo.CrearRequisaAjuste(ajuste);
        //            if (!responseAjuste.Success)
        //            {
        //                return new ServiceResponse<bool>.Builder()
        //                    .SetData(false)
        //                    .SetMessage(responseAjuste.Message)
        //                    .SetSuccess(false)
        //                    .Build();
        //            }
        //        }

        //        return new ServiceResponse<bool>.Builder()
        //            .SetData(true)
        //            .SetMessage("Requisa y ajustes creados exitosamente.")
        //            .SetSuccess(true)
        //            .Build();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ServiceResponse<bool>.Builder()
        //            .SetData(false)
        //            .SetMessage("Error al crear la requisa: " + ex.Message)
        //            .SetSuccess(false)
        //            .Build();
        //    }
        //}

        public async Task<ServiceResponse<IEnumerable<Requisa>>> ObtenerTodasLasRequisas()
        {
            try
            {
                var response = await _requisaDbo.ObtenerTodasLasRequisas();
                if (!response.Success)
                {
                    return new ServiceResponse<IEnumerable<Requisa>>.Builder()
                        .SetData(null)
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
        
    }
}
