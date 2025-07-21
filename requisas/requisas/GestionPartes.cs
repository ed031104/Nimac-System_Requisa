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
    public partial class GestionPartes : Form
    {

        private ParteServices _parteServices;
        private ExcelReader _excelReader = new ExcelReader();

        public GestionPartes()
        {
            InitializeComponent();
            _parteServices = new ParteServices();
        }


        private async void crearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroParteInput.Text) || string.IsNullOrWhiteSpace(descripcionInput.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                var parte = new Parte.Builder()
                    .SetNumeroParte(numeroParteInput.Text.Trim())
                    .SetDescripcionParte(descripcionInput.Text.Trim())
                    .Build();
                var response = await _parteServices.CrearParte(parte);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al crear parte: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Parte creado correctamente.");
                numeroParteInput.Clear();
                descripcionInput.Clear();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el parte: {ex.Message}");
            }
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroParteInput.Text) || string.IsNullOrWhiteSpace(descripcionInput.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                var parte = new Parte.Builder()
                    .SetNumeroParte(numeroParteInput.Text.Trim())
                    .SetDescripcionParte(descripcionInput.Text.Trim())
                    .Build();
                var response = await _parteServices.ActualizarParte(parte);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al editar el parte: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Parte editado correctamente.");
                numeroParteInput.Clear();
                descripcionInput.Clear();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar el parte: {ex.Message}");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroParteInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese el número de parte a eliminar.");
                    return;
                }
                var response = await _parteServices.EliminarParte(numeroParteInput.Text.Trim());
                if (!response.Success)
                {
                    MessageBox.Show($"Error al eliminar el parte: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Parte eliminado correctamente.");
                numeroParteInput.Clear();
                descripcionInput.Clear();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el parte: {ex.Message}");
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    numeroParteInput.Text = table.Rows[e.RowIndex].Cells["numeroParteColumn"].Value.ToString() ?? "";
                    descripcionInput.Text = table.Rows[e.RowIndex].Cells["decripcionParteColumn"].Value.ToString() ?? "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var response = await _parteServices.ObtenerPartes();
                if (!response.Success)
                {
                    MessageBox.Show($"Error al cargar los partes: {response.ErrorMessage}");
                    return;
                }
                table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
                table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
                table.DataSource = response.Data.Select(p => new
                {
                    numeroParteColumn = p.NumeroParte,
                    decripcionParteColumn = p.DescripcionParte,
                    fechaRegistroColumn = p.FechaRegistro.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = p.FechaModificacion.ToString("dd/MM/yyyy")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los partes: {ex.Message}");
            }
        }

        private async void GestionPartes_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void códigoInput_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(codigoInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese un código de casa para buscar.");
                    return;
                }
                var codigoCasa = codigoInput.Text.Trim();

                var response = await _parteServices.ObtenerPartePorId(codigoCasa);

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

                var partes = new List<Parte> { response.Data };

                table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
                table.DataSource = partes.Select(c => new
                {
                    numeroParteColumn = c.NumeroParte,
                    decripcionParteColumn = c.DescripcionParte,
                    fechaRegistroColumn = c.FechaRegistro.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = c.FechaModificacion.ToString("dd/MM/yyyy")
                }).ToList();

                MostrarButton.Visible = true;
            }
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false;
        }

        private async void cargaMasivaButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarExcelParte importarExcel = new ImportarExcelParte();
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Excel cargado correctamente:\n" + ruta);
                }

                var dataParserExcel = await _excelReader.ParserExcelAndParte(ruta);

                if (dataParserExcel.Success == false || !dataParserExcel.Data.Any())
                {
                    MessageBox.Show($"Error al procesar el archivo: {dataParserExcel.ErrorMessage}");
                    return;
                }

                IEnumerable<Parte> listDataExcel = dataParserExcel.Data;

                importarExcel.ListParte = listDataExcel.ToList();
                importarExcel.ShowDialog();

                if (importarExcel.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Importación cancelada.");
                    return;
                }

                var response = await _parteServices.CrearPartes(importarExcel.ListParte);
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
