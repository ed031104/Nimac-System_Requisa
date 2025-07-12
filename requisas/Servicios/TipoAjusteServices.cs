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
    public class TipoAjusteServices
    {
        private readonly TipoAjusteDbo _tipoAjusteDbo;

        public TipoAjusteServices()
        {
            _tipoAjusteDbo = new TipoAjusteDbo();
        }

        public async Task<ServiceResponse<IEnumerable<TipoAjuste>>> ObtenerTiposAjuste()
        {
            try
            {
                var response = await _tipoAjusteDbo.ObtenerTodasLosTiposAjuste();
                if (response.Data == null || !response.Data.Any())
                {
                    return new ServiceResponse<IEnumerable<TipoAjuste>>.Builder()
                        .SetData(Enumerable.Empty<TipoAjuste>())
                        .SetMessage("No se encontraron tipos de ajuste.")
                        .SetSuccess(false)
                        .Build();
                }
                return new ServiceResponse<IEnumerable<TipoAjuste>>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Tipos de ajuste obtenidos correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TipoAjuste>>.Builder()
                    .SetData(null)
                    .SetMessage($"Error al obtener tipos de ajuste: {ex.Message}")
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<TipoAjuste>> ObtenerTiposAjustePorId(int id)
        {
            try
            {
                var response = await _tipoAjusteDbo.ObtenerTipoAjustePorId(id);
                
                if (response.Data == null)
                {
                    return new ServiceResponse<TipoAjuste>.Builder()
                        .SetMessage("No se encontraron tipos de ajuste.")
                        .SetSuccess(false)
                        .Build();
                }

                return new ServiceResponse<TipoAjuste>.Builder()
                    .SetData(response.Data)
                    .SetMessage("Tipos de ajuste obtenidos correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TipoAjuste>.Builder()
                    .SetData(null)
                    .SetMessage($"Error al obtener tipos de ajuste: {ex.Message}")
                    .SetSuccess(false)
                    .Build();
            }
        }

    }
}
