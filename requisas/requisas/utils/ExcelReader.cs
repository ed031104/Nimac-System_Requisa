using Modelos;
using Modelos.data;
using OfficeOpenXml;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVista.utils
{
    public class ExcelReader
    {
        #region dependencies
        private readonly ParteSucursalServices _parteSucursalServices;
        private readonly TipoAjusteServices _tipoAjusteServices;
        #endregion

        public ExcelReader() {
            _parteSucursalServices = new ParteSucursalServices();
            _tipoAjusteServices = new TipoAjusteServices();
        }

        public async Task<ServiceResponse<IEnumerable<RequisaAjuste>>> ParserExcelAndRequisa(string filePath)
        {
            var ajustes = new List<RequisaAjuste>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                for(int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var responseParteSucursal = await _parteSucursalServices.obtenerPartePorNumeroParte(hoja.Cells[fila, 3].Text);
                    
                    if(responseParteSucursal.Data == null || !responseParteSucursal.Data.Any())
                    {
                        return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                            .SetErrorMessage("Parte no encontrado en la fila " + fila + ".")
                            .SetSuccess(false)
                            .Build();
                    }

                    var parteSucursal = responseParteSucursal.Data
                        .Where(ps => ps.Sucursal.Casa.CodigoCasa == hoja.Cells[fila,1].Text)
                        .Where(ps => ps.Sucursal.NumeroSucursal == hoja.Cells[fila, 2].Text)
                        .Where(ps => ps.Parte.NumeroParte == hoja.Cells[fila, 3].Text)
                        .FirstOrDefault();
                 
                    if (parteSucursal == null) { 
                        return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                            .SetErrorMessage("Parte no encontrado en la fila " + fila + ".")
                            .SetSuccess(false)
                            .Build();
                    }

                    var responseTipoAjuste = await _tipoAjusteServices.ObtenerTiposAjustePorId(Convert.ToInt32(hoja.Cells[fila, 6].Text));
                    
                    if (!responseTipoAjuste.Success || responseTipoAjuste.Data == null) { 
                        return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                            .SetErrorMessage("Tipo de ajuste no encontrado en la fila " + fila + ".")
                            .SetSuccess(false)
                            .Build();
                    }

                    var requisaAjuste = new RequisaAjuste.Builder()
                        .SetCostoPromedio(parteSucursal.CostoUnitario)
                        .SetTipoAjuste(responseTipoAjuste.Data)
                        .SetParteSucursal(parteSucursal)
                        .SetMontoAjuste(Convert.ToDecimal(hoja.Cells[fila, 5].Text))
                        .SetDescripcion(hoja.Cells[fila, 4].Text)
                        .SetFechaRegistro(DateTime.Now)
                        .SetFechaModificacion(DateTime.Now)
                        .SetCostoPromedioExtendido(parteSucursal.CostoUnitario * Convert.ToDecimal(hoja.Cells[fila, 5].Text))
                        .Build();
                    ajustes.Add(requisaAjuste);
                }

                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetData(ajustes)
                    .SetMessage("Archivo procesado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch(Exception e) { 
                return new ServiceResponse<IEnumerable<RequisaAjuste>>.Builder()
                    .SetErrorMessage("Error al procesar el archivo: " + e.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Casa>>> ParserExcelAndCasa(string filePath)
        {
            var casas = new List<Casa>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                for (int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var casa = new Casa.Builder()
                        .SetCodigoCasa(hoja.Cells[fila, 1].Text)
                        .SetNombreCasa(hoja.Cells[fila, 4].Text)
                        .SetFechaRegistro(DateTime.Now)
                        .SetFechaModificacion(DateTime.Now)
                        .Build();
                    casas.Add(casa);
                }

                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetData(casas)
                    .SetMessage("Archivo procesado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception e)
            {
                return new ServiceResponse<IEnumerable<Casa>>.Builder()
                    .SetErrorMessage("Error al procesar el archivo: " + e.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Casa>>> ParserExcelAndSucursal(string filePath) { return null; }

        public async Task<ServiceResponse<IEnumerable<Casa>>> ParserExcelAndParte(string filePath) { return null; }

        public async Task<ServiceResponse<IEnumerable<Casa>>> ParserExcelAndParteSucursal(string filePath) { return null; }

        private bool validarColumnas()
        {

            return false;
        }
    }
}
