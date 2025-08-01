﻿using Modelos;
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

             

                for (int fila = filaInicio; fila <= totalFilas; fila++)
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
                        .Where(ps => ps.Casa == hoja.Cells[fila,1].Text)
                        .Where(ps => ps.Sucursal == hoja.Cells[fila, 2].Text)
                        .Where(ps => ps.Parte == hoja.Cells[fila, 3].Text)
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
     
        public async Task<ServiceResponse<IEnumerable<ParteSucursal>>> ParserExcelAndParteSucursal(string filePath) {
            var parteSucursales = new List<ParteSucursal>();
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                using var package = new ExcelPackage(new FileInfo(filePath));
                var hoja = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja

                int filaInicio = 2; // Asumiendo que la primera fila es el encabezado
                int totalFilas = hoja.Dimension.Rows;

                var validatorColumnsExcel = validarColumnas(filePath, new List<string> { "Numero de Parte", "Costo Unitario", "Stock", "Numero de Sucursal", "Numero de Casa", "Descripcion Parte" });

                if (!validatorColumnsExcel)
                {
                    return new ServiceResponse<IEnumerable<ParteSucursal>>.Builder()
                        .SetErrorMessage("El archivo no contiene las columnas esperadas: \n \"Numero de Parte\", \"Costo Unitario\", \"Stock\", \"Numero de Sucursal\" ")
                        .SetSuccess(false)
                        .Build();
                }

                for (int fila = filaInicio; fila <= totalFilas; fila++)
                {

                    var parteSucursal = new ParteSucursal.Builder()
                        .SetParte(hoja.Cells[fila, 1].Text)
                        .SetCostoUnitario(Convert.ToDecimal(hoja.Cells[fila, 2].Text))
                        .SetCantidad(Convert.ToInt32(hoja.Cells[fila, 3].Text))
                        .SetSucursal(hoja.Cells[fila, 4].Text)
                        .SetCasa(hoja.Cells[fila, 5].Text)
                        .SetDescripcion(hoja.Cells[fila, 6].Text)
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
     
        private bool validarColumnas(string filePath, List<string>encabezadosEsperados)
        {

            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Primera hoja
                int totalColumnas = worksheet.Dimension.End.Column;

                for (int col = 1; col <= encabezadosEsperados.Count; col++)
                {
                    string valorCelda = worksheet.Cells[1, col].Text.Trim(); // Primera fila

                    if (!string.Equals(valorCelda, encabezadosEsperados[col - 1].Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return false; // Encabezado incorrecto
                    }
                }
            }
            return true; // Todos los encabezados son correctos
        }
    }
}
