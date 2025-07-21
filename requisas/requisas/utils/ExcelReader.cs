using Modelos;
using Modelos.data;
using Modelos.requisas;
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

        public async Task<ServiceResponse<IEnumerable< RequisaAjuste>>> ParserExcelAndRequisa(string filePath)
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
                        .SetNombreCasa(hoja.Cells[fila, 2].Text)
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

        public async Task<ServiceResponse<IEnumerable<Sucursal>>> ParserExcelAndSucursal(string filePath) {
            var sucursales = new List<Sucursal>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                for (int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var sucursal = new Sucursal.Builder()
                        .SetNumeroSucursal(hoja.Cells[fila, 1].Text)
                        .SetNombreSucursal(hoja.Cells[fila, 2].Text)
                        .SetCasa( new Casa.Builder()
                            .SetCodigoCasa(hoja.Cells[fila, 3].Text)
                            .Build()
                        )
                        .SetFechaRegistro(DateTime.Now)
                        .SetFechaModificacion(DateTime.Now)
                        .Build();
                    sucursales.Add(sucursal);
                }

                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetData(sucursales)
                    .SetMessage("Archivo procesado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception e)
            {
                return new ServiceResponse<IEnumerable<Sucursal>>.Builder()
                    .SetErrorMessage("Error al procesar el archivo: " + e.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<ParteSucursal>>> ParserExcelAndParteSucursal(string filePath) {
            var parteSucursales = new List<ParteSucursal>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                for (int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var parteSucursal = new ParteSucursal.Builder()
                        .SetParte(
                            new Parte.Builder()
                                .SetNumeroParte(hoja.Cells[fila, 1].Text)
                                .Build()
                        )
                        .SetCostoUnitario(Convert.ToDecimal(hoja.Cells[fila, 2].Text))
                        .SetCantidad(Convert.ToInt32(hoja.Cells[fila, 3].Text))
                        .SetSucursal(new Sucursal.Builder()
                            .SetNumeroSucursal(hoja.Cells[fila, 4].Text)
                            .Build()
                        )
                        .SetFechaRegistro(DateTime.Now)
                        .SetFechaModificacion(DateTime.Now)
                        .Build();

                    parteSucursales.Add(parteSucursal);
                }

                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetData(parteSucursales)
                    .SetMessage("Archivo procesado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception e)
            {
                return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                    .SetErrorMessage("Error al procesar el archivo: " + e.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }

        public async Task<ServiceResponse<IEnumerable<Parte>>> ParserExcelAndParte(string filePath) {
            var partes = new List<Parte>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                for (int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var parte = new Parte.Builder()
                        .SetNumeroParte(hoja.Cells[fila, 1].Text)
                        .SetDescripcionParte(hoja.Cells[fila, 2].Text)
                        .SetFechaRegistro(DateTime.Now)
                        .SetFechaModificacion(DateTime.Now)
                        .Build();
                    partes.Add(parte);
                }

                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetData(partes)
                    .SetMessage("Archivo procesado correctamente.")
                    .SetSuccess(true)
                    .Build();
            }
            catch (Exception e)
            {
                return new ServiceResponse<IEnumerable<Parte>>.Builder()
                    .SetErrorMessage("Error al procesar el archivo: " + e.Message)
                    .SetSuccess(false)
                    .Build();
            }
        }


        private bool validarColumnas()
        {

            return false;
        }
    }
}
