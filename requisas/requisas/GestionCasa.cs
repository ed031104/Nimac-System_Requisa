using CapaVista.Components;
using CapaVista.utils;
using Modelos;
using Modelos.requisas;
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
    public partial class GestionCasa : Form
    {
        CasaServices _casaServices;
        private ExcelReader _excelReader = new ExcelReader();

        public GestionCasa()
        {
            InitializeComponent();
            _casaServices = new CasaServices();
        }

        private async void crearButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombreInput.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var casa = new Modelos.Casa.Builder()
                .SetNombreCasa(NombreInput.Text)
                .Build();

            var response = await _casaServices.CrearCasa(casa);

            if (!response.Success)
            {
                MessageBox.Show($"Error al crear la casa: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Casa creada correctamente.");
            CodigoInput.Clear();
            NombreInput.Clear();

            await LoadDataAsync();
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoInput.Text) || string.IsNullOrEmpty(NombreInput.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            var casa = new Modelos.Casa
            {
                CodigoCasa = CodigoInput.Text,
                NombreCasa = NombreInput.Text
            };
            var response = await _casaServices.ActualizarCasa(casa);
            if (!response.Success)
            {
                MessageBox.Show($"Error al actualizar la casa: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Casa actualizada correctamente.");
            await LoadDataAsync();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoInput.Text))
            {
                MessageBox.Show("Por favor, ingrese el código de la casa a eliminar.");
                return;
            }
            var response = await _casaServices.EliminarCasa(CodigoInput.Text);
            if (!response.Success)
            {
                MessageBox.Show($"Error al eliminar la casa: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Casa eliminada correctamente.");
            await LoadDataAsync();
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false;
        }

        private async void GestionCasa_Load(object sender, EventArgs e)
        {
            MostrarButton.Visible = false;
            await LoadDataAsync();
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    CodigoInput.Text = table.Rows[e.RowIndex].Cells["codigoCasaColumn"].Value.ToString() ?? "";
                    NombreInput.Text = table.Rows[e.RowIndex].Cells["nombreCasaColumn"].Value.ToString() ?? "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async Task LoadDataAsync()
        {
            var response = await _casaServices.ObtenerTodasLasCasas();

            if (!response.Success)
            {
                MessageBox.Show($"Error al cargar las casas: {response.ErrorMessage}");
                return;
            }
            table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
            table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
            table.DataSource = response.Data.Select(c => new
            {
                codigoCasaColumn = c.CodigoCasa,
                nombreCasaColumn = c.NombreCasa,
                fechaRegistroColumn = c.FechaRegistro?.ToString("dd/MM/yyyy") ?? "",
                fechaModificacionColumn = c.FechaModificacion?.ToString("dd/MM/yyyy")
            }).ToList();
        }

        private async void codigoSearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(codigoSearchInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese un código de casa para buscar.");
                    return;
                }
                var codigoCasa = codigoSearchInput.Text.Trim();

                var response = await _casaServices.ObtenerCasaPorCodigo(codigoCasa);

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
                table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
                table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
                table.DataSource = response.Data.Select(c => new
                {
                    codigoCasaColumn = c.CodigoCasa,
                    nombreCasaColumn = c.NombreCasa,
                    fechaRegistroColumn = c.FechaRegistro?.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = c.FechaModificacion?.ToString("dd/MM/yyyy")
                }).ToList();

                MostrarButton.Visible = true;
            }
        }

        private async void cargaMasivaButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarExcelCasa importarExcel = new ImportarExcelCasa();
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Excel cargado correctamente:\n" + ruta);
                }

                var dataParserExcel = await _excelReader.ParserExcelAndCasa(ruta);

                if (dataParserExcel.Success == false || !dataParserExcel.Data.Any())
                {
                    MessageBox.Show($"Error al procesar el archivo: {dataParserExcel.ErrorMessage}");
                    return;
                }

                IEnumerable<Casa> listDataExcel = dataParserExcel.Data;

                importarExcel.ListCasa = listDataExcel.ToList();
                importarExcel.ShowDialog();

                if (importarExcel.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Importación cancelada.");
                    return;
                }

                var response = await _casaServices.CrearCasas(importarExcel.ListCasa);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al importar casas: {response.ErrorMessage}");
                    return;
                }

                MessageBox.Show("Casas importadas correctamente.");

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar Excel: {ex.Message}");
            }
        }
    }
}
