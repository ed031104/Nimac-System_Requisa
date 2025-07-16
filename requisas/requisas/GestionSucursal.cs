using CapaVista.Components;
using CapaVista.utils;
using Modelos;
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
    public partial class GestionSucursal : Form
    {
        SucursalServices _sucursalServices;
        CasaServices _casaServices;
        private ExcelReader _excelReader = new ExcelReader();


        public GestionSucursal()
        {
            InitializeComponent();
            _sucursalServices = new SucursalServices();
            _casaServices = new CasaServices();
        }

        private async void crearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroSucursalInput.Text) || string.IsNullOrWhiteSpace(nombreInput.Text) || casaComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var sucursal = new Sucursal.Builder()
                    .SetNumeroSucursal(numeroSucursalInput.Text.Trim())
                    .SetNombreSucursal(nombreInput.Text.Trim())
                    .SetCasa((Casa)casaComboBox.SelectedItem)
                    .Build();

                var response = await _sucursalServices.CrearSucursal(sucursal);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al crear sucursal: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Sucursal creada correctamente.");

                numeroSucursalInput.Clear();
                nombreInput.Clear();
                casaComboBox.SelectedIndex = -1;

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la sucursal: {ex.Message}");
            }
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroSucursalInput.Text) || string.IsNullOrWhiteSpace(nombreInput.Text) || casaComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var sucursal = new Sucursal.Builder()
                    .SetNumeroSucursal(numeroSucursalInput.Text.Trim())
                    .SetNombreSucursal(nombreInput.Text.Trim())
                    .SetCasa((Casa)casaComboBox.SelectedItem)
                    .Build();

                var response = await _sucursalServices.ActualizarSucursal(sucursal);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al editar sucursal: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Sucursal editada correctamente.");

                numeroSucursalInput.Clear();
                nombreInput.Clear();
                casaComboBox.SelectedIndex = -1;

                await LoadDataAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar la sucursal: {ex.Message}");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroSucursalInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese el número de la sucursal a eliminar.");
                    return;
                }

                var response = await _sucursalServices.EliminarSucursal(numeroSucursalInput.Text.Trim());

                if (!response.Success)
                {
                    MessageBox.Show($"Error al eliminar sucursal: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Sucursal eliminada correctamente.");

                numeroSucursalInput.Clear();
                nombreInput.Clear();
                casaComboBox.SelectedIndex = -1;

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la sucursal: {ex.Message}");
            }
        }

        private async void numeroSucuarSearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(numeroSucuarSearchInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese un código de casa para buscar.");
                    return;
                }
                var codigoCasa = numeroSucuarSearchInput.Text.Trim();

                var response = await _sucursalServices.ObtenerSucursalPorNombre(codigoCasa);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al buscar la casa: {response.ErrorMessage}");
                    return;
                }
                if (response.Data == null)
                {
                    MessageBox.Show("No se encontró la casa con el código proporcionado.");
                    return;
                }

                table.DataSource = null;
                table.DataSource = response.Data.Select(s => new
                {
                    numeroSucursalColumn = s.NumeroSucursal,
                    nombreSucursalColumn = s.NombreSucursal,
                    fechaRegistroColumn = s.FechaRegistro?.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = s.FechaModificacion?.ToString("dd/MM/yyyy"),
                    casaColumn = s.Casa
                }).ToList();

                MostrarButton.Visible = true;
            }
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    numeroSucursalInput.Text = table.Rows[e.RowIndex].Cells["numeroSucursalColumn"].Value.ToString() ?? "";
                    nombreInput.Text = table.Rows[e.RowIndex].Cells["nombreSucursalColumn"].Value.ToString() ?? "";

                    casaComboBox.SelectedItem = table.Rows[e.RowIndex].Cells["casaColumn"].Value; // Asumiendo que la columna de casa es de tipo Casa
                    casaComboBox.SelectedIndex = 0;

                    MostrarButton.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void GestionSucursal_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var response = await _sucursalServices.ObtenerSucursales();
                if (!response.Success)
                {
                    MessageBox.Show($"Error al cargar los partes: {response.ErrorMessage}");
                    return;
                }
                table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
                table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
                table.DataSource = response.Data.Select(s => new
                {
                    numeroSucursalColumn = s.NumeroSucursal,
                    nombreSucursalColumn = s.NombreSucursal,
                    fechaRegistroColumn = s.FechaRegistro?.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = s.FechaModificacion?.ToString("dd/MM/yyyy"),
                    casaColumn = s.Casa
                }).ToList();

                var casasResponse = await _casaServices.ObtenerTodasLasCasas();
                if (!casasResponse.Success)
                {
                    MessageBox.Show($"Error al cargar las casas: {casasResponse.ErrorMessage}");
                    return;
                }
                casaComboBox.DataSource = casasResponse.Data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los partes: {ex.Message}");
            }
        }

        private async void cargaMasivaButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarExcelSucursal importarExcel = new ImportarExcelSucursal();
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Excel cargado correctamente:\n" + ruta);
                }

                var dataParserExcel = await _excelReader.ParserExcelAndSucursal(ruta);

                if (dataParserExcel.Success == false || !dataParserExcel.Data.Any())
                {
                    MessageBox.Show($"Error al procesar el archivo: {dataParserExcel.ErrorMessage}");
                    return;
                }

                IEnumerable<Sucursal> listDataExcel = dataParserExcel.Data;

                importarExcel.ListSucursales = listDataExcel.ToList();
                importarExcel.ShowDialog();

                if (importarExcel.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Importación cancelada.");
                    return;
                }

                var response = await _sucursalServices.CrearSucursales(listDataExcel.ToList());
                if (!response.Success)
                {
                    MessageBox.Show($"Error al importar sucursales: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Sucursales importadas correctamente.");
                
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar Sucursales: {ex.Message}");

            }
        }
    }
}
