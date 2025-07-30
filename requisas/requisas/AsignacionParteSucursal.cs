using CapaVista.Components;
using CapaVista.utils;
using Microsoft.Identity.Client;
using Modelos;
using Modelos.Dto;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class AsignacionParteSucursal : Form
    {
        private ParteSucursalServices _parteSucursalServices;
        private ExcelReader _excelReader = new ExcelReader();

        private List<ParteSucursal> _listParteSucursal;


        public AsignacionParteSucursal()
        {
            InitializeComponent();
            _parteSucursalServices = new ParteSucursalServices();
            _listParteSucursal = new List<ParteSucursal>();
        }

        private async void AsignacionParteSucursal_Load(object sender, EventArgs e)
        {
            var response = await _parteSucursalServices.ObtenerPartesSucursal();
            if (response.Success == false || response.Data.Count() <= 0)
            {
                MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                return;
            }
            _listParteSucursal = response.Data.ToList();
            await CargarParteSucursalesTabla();
            idParteCasaInput.Enabled = false;
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    idParteCasaInput.Text = table.Rows[e.RowIndex].Cells["idColumn"].Value.ToString() ?? "";
                    stockInput.Text = table.Rows[e.RowIndex].Cells["stockColumn"].Value.ToString() ?? "";
                    costoUnitarioInput.Text = table.Rows[e.RowIndex].Cells["costoUnitarioColumn"].Value.ToString() ?? "";
                    descripcionInput.Text = table.Rows[e.RowIndex].Cells["descripcionColumn"].Value.ToString() ?? "";
                    casaInput.Text = table.Rows[e.RowIndex].Cells["casaColumn"].Value.ToString() ?? "";
                    parteInput.Text = table.Rows[e.RowIndex].Cells["parteColumn"].Value.ToString() ?? "";
                    sucursalInput.Text = table.Rows[e.RowIndex].Cells["sucursalColumn"].Value.ToString() ?? "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
        }

        private async void numeroParteSearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    string numeroParte = numeroParteSearchInput.Text.Trim();
                    if (string.IsNullOrEmpty(numeroParte))
                    {
                        MessageBox.Show("Por favor, ingrese un número de parte válido.");
                        return;
                    }
                    var response = await _parteSucursalServices.obtenerPartePorNumeroParte(numeroParte);
                    if (response.Success == false || response.Data == null)
                    {
                        MessageBox.Show($"Error al buscar el número de parte: {response.ErrorMessage}");
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el número de parte: {ex.Message}");
            }
        }

        private async void crearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrWhiteSpace(stockInput.Text) || string.IsNullOrWhiteSpace(costoUnitarioInput.Text) ||
                    string.IsNullOrEmpty(parteInput.Text) || string.IsNullOrEmpty(sucursalInput.Text) ||
                    string.IsNullOrEmpty(descripcionInput.Text) || string.IsNullOrEmpty(casaInput.Text)
                )
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var parteSucursal = new ParteSucursal.Builder()
                    .SetParte(parteInput.Text)
                    .SetSucursal(sucursalInput.Text)
                    .SetCantidad(int.Parse(stockInput.Text.Trim()))
                    .SetCostoUnitario(decimal.Parse(costoUnitarioInput.Text.Trim()))
                    .SetDescripcion(descripcionInput.Text)
                    .SetCasa(casaInput.Text)
                    .Build();

                var response = await _parteSucursalServices.CrearParteSucursal(parteSucursal);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al crear la asignación de parte a sucursal: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Asignación de parte a sucursal creada correctamente.");

                idParteCasaInput.Clear();
                stockInput.Clear();
                costoUnitarioInput.Clear();
                parteInput.Clear();
                sucursalInput.Clear();
                descripcionInput.Clear();
                casaInput.Clear();

                var responseParteSucursal = await _parteSucursalServices.ObtenerPartesSucursal();
              
                if (response.Success == false || response?.Data == null)
                {
                    MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                    return;
                }

                _listParteSucursal.Clear();
                _listParteSucursal = responseParteSucursal.Data.ToList();
                await dataTableLoad(responseParteSucursal.Data.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (
                     string.IsNullOrWhiteSpace(stockInput.Text) || string.IsNullOrWhiteSpace(costoUnitarioInput.Text) ||
                     string.IsNullOrEmpty(parteInput.Text) || string.IsNullOrEmpty(sucursalInput.Text) ||
                     string.IsNullOrEmpty(descripcionInput.Text) || string.IsNullOrEmpty(casaInput.Text)
                 )
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var parteSucursal = new ParteSucursal.Builder()
                    .SetIdParteSucursal(int.Parse(idParteCasaInput.Text))
                    .SetParte(parteInput.Text)
                    .SetSucursal(sucursalInput.Text)
                    .SetCantidad(int.Parse(stockInput.Text.Trim()))
                    .SetCostoUnitario(decimal.Parse(costoUnitarioInput.Text.Trim()))
                    .SetDescripcion(descripcionInput.Text)
                    .SetCasa(casaInput.Text)
                    .Build();

                var response = await _parteSucursalServices.ActualizarParteSucursal(parteSucursal);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al editar la asignación de parte a sucursal: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Asignación de parte a sucursal editada correctamente.");

                //await dataParteLoad();
                //await dataSucursalLoad();

                idParteCasaInput.Clear();
                stockInput.Clear();
                costoUnitarioInput.Clear();
                parteInput.Clear();
                sucursalInput.Clear();
                descripcionInput.Clear();
                casaInput.Clear();

                var responseParteSucursal = await _parteSucursalServices.ObtenerPartesSucursal();
                if (response.Success == false || response?.Data == null)
                {
                    MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                    return;
                }

                _listParteSucursal.Clear();
                _listParteSucursal = responseParteSucursal.Data.ToList();
                await dataTableLoad(responseParteSucursal.Data.ToList());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var idParteSucursal = idParteCasaInput.Text.Trim();
                if (string.IsNullOrWhiteSpace(idParteSucursal))
                {
                    MessageBox.Show("Por favor, ingrese un ID de parte sucursal válido.");
                    return;
                }
                var response = await _parteSucursalServices.EliminarParteSucursal(int.Parse(idParteSucursal));
                if (!response.Success)
                {
                    MessageBox.Show($"Error al eliminar la asignación de parte a sucursal: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Asignación de parte a sucursal eliminada correctamente.");

                idParteCasaInput.Clear();
                stockInput.Clear();
                costoUnitarioInput.Clear();
                parteInput.Clear();
                sucursalInput.Clear();
                descripcionInput.Clear();
                casaInput.Clear();

                var responseParteSucursal = await _parteSucursalServices.ObtenerPartesSucursal();
                if (response.Success == false || response?.Data == null)
                {
                    MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                    return;
                }

                _listParteSucursal.Clear();
                _listParteSucursal = responseParteSucursal.Data.ToList();
                await dataTableLoad(responseParteSucursal.Data.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void cargaMasivaButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarExcelParteSucursal importarExcel = new ImportarExcelParteSucursal();
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Excel cargado correctamente:\n" + ruta);
                }

                var dataParserExcel = await _excelReader.ParserExcelAndParteSucursal(ruta);

                if (dataParserExcel.Success == false || !dataParserExcel.Data.Any())
                {
                    MessageBox.Show($"Error al procesar el archivo: {dataParserExcel.ErrorMessage}");
                    return;
                }

                IEnumerable<ParteSucursal> listDataExcel = dataParserExcel.Data;

                importarExcel.ListParteSucursal = listDataExcel.ToList();
                importarExcel.ShowDialog();

                if (importarExcel.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Importación cancelada.");
                    return;
                }

                var response = await _parteSucursalServices.CrearParteSucursales(listDataExcel.ToList());
                if (!response.Success)
                {
                    MessageBox.Show($"Error al importar sucursales: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Sucursales importadas correctamente.");

                var responseParteSucursal = await _parteSucursalServices.ObtenerPartesSucursal();
                if (response.Success == false || response?.Data == null)
                {
                    MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                    return;
                }

                _listParteSucursal.Clear();
                _listParteSucursal = responseParteSucursal.Data.ToList();
                await dataTableLoad(responseParteSucursal.Data.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar Sucursales: {ex.Message}");

            }
        }

        #region additional methods for data loading

        private async Task CargarParteSucursalesTabla()
        {
            var listTemp = _listParteSucursal;
            await dataTableLoad(listTemp);
        }

        private async Task dataTableLoad(List<ParteSucursal> list)
        {
            try
            {
                table.DataSource = null;


                table.DataSource = list.Select(ps => new
                {
                    idColumn = ps.IdParteSucursal,
                    parteColumn = ps.Parte,
                    costoUnitarioColumn = ps.CostoUnitario,
                    stockColumn = ps.Stock,
                    fechaRegistroColumn = ps.FechaRegistro.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = ps.FechaModificacion.ToString("dd/MM/yyyy"),
                    sucursalColumn = ps.Sucursal,
                    casaColumn = ps.Casa,
                    descripcionColumn = ps.Descripcion
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private async void numeroParteSearchInput_TextChanged(object sender, EventArgs e)
        {
            table.DataSource = null;

            var listTemp = _listParteSucursal;

            if (String.IsNullOrEmpty(numeroParteSearchInput.Text))
            {
                await CargarParteSucursalesTabla();
            }

            var listFilter = listTemp.Where(x =>
                x.Parte.ToLower().Contains(numeroParteSearchInput.Text.ToLower()
            ))
            .ToList();

            await dataTableLoad(listFilter);
        }
    }
}
