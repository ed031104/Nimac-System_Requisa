using Microsoft.Identity.Client;
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
    public partial class AsignacionParteSucursal : Form
    {
        private ParteServices _parteServices;
        private SucursalServices _sucursalServices;
        private ParteSucursalServices _parteSucursalServices;

        public AsignacionParteSucursal()
        {
            InitializeComponent();
            _parteServices = new ParteServices();
            _sucursalServices = new SucursalServices();
            _parteSucursalServices = new ParteSucursalServices();
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

                    parteComboBox.DataSource = null;

                    parteComboBox.Items.Clear();
                    parteComboBox.Items.Add(table.Rows[e.RowIndex].Cells["parteColumn"].Value);
                    parteComboBox.SelectedIndex = 0;

                    MostrarButton.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await dataTableLoad();
            await dataParteLoad();
            await dataSucursalLoad();
            MostrarButton.Visible = false;
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
                    parteComboBox.DataSource = null;
                    parteComboBox.Items.Add(response.Data);
                    parteComboBox.SelectedItem = 0;
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
                if(string.IsNullOrWhiteSpace(stockInput.Text) || string.IsNullOrWhiteSpace(costoUnitarioInput.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                if (parteComboBox.SelectedItem == null || sucursalComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un parte y una sucursal.");
                    return;
                }

                var parteSucursal = new ParteSucursal.Builder()
                    .SetParte((Parte)parteComboBox.SelectedItem)
                    .SetSucursal((Sucursal)sucursalComboBox.SelectedItem)
                    .SetCantidad(int.Parse(stockInput.Text.Trim()))
                    .SetCostoUnitario(decimal.Parse(costoUnitarioInput.Text.Trim()))
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
                parteComboBox.SelectedIndex = -1;
                sucursalComboBox.SelectedIndex = -1;

                await dataTableLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            try { 

                if(string.IsNullOrWhiteSpace(idParteCasaInput.Text) || string.IsNullOrWhiteSpace(stockInput.Text) || string.IsNullOrWhiteSpace(costoUnitarioInput.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                if (parteComboBox.SelectedItem == null || sucursalComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un parte y una sucursal.");
                    return;
                }
                var parte = parteComboBox.SelectedItem as Parte;
                var sucursal = sucursalComboBox.SelectedItem as Sucursal;

                var parteSucursal = new ParteSucursal.Builder()
                    .SetIdParteSucursal(int.Parse(idParteCasaInput.Text.Trim()))
                    .SetParte(parte)
                    .SetSucursal(sucursal)
                    .SetCantidad(int.Parse(stockInput.Text.Trim()))
                    .SetCostoUnitario(decimal.Parse(costoUnitarioInput.Text.Trim()))
                    .Build();
                var response = await _parteSucursalServices.ActualizarParteSucursal(parteSucursal);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al editar la asignación de parte a sucursal: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Asignación de parte a sucursal editada correctamente.");

                await dataTableLoad();
                await dataParteLoad();
                await dataSucursalLoad();

                idParteCasaInput.Clear();
                stockInput.Clear();
                costoUnitarioInput.Clear();
                parteComboBox.SelectedIndex = -1;
                sucursalComboBox.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al editar la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try { 
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
                parteComboBox.SelectedIndex = -1;
                sucursalComboBox.SelectedIndex = -1;

                await dataTableLoad();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al eliminar la asignación de parte a sucursal: {ex.Message}");
            }
        }

        private async void AsignacionParteSucursal_Load(object sender, EventArgs e)
        {
            await dataParteLoad();
            await dataSucursalLoad();
            await dataTableLoad();
            idParteCasaInput.Enabled = false;
        }

        #region additional methods for data loading
        private async Task dataParteLoad()
        {
            try
            {

                var response = await _parteServices.ObtenerPartes();
                if (response.Success == false || response.Data.Count() <= 0)
                {
                    MessageBox.Show($"Error al cargar partes: {response.ErrorMessage}");
                    return;
                }
                parteComboBox.DataSource = null;
                parteComboBox.DataSource = response.Data.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del parte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task dataSucursalLoad()
        {
            try
            {
                var response = await _sucursalServices.ObtenerSucursales();
                if (response.Success == false || response.Data.Count() <= 0)
                {
                    MessageBox.Show($"Error al cargar sucursales: {response.ErrorMessage}");
                    return;
                }
                sucursalComboBox.DataSource = null;
                sucursalComboBox.DataSource = response.Data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task dataTableLoad()
        {
            try
            {
                table.DataSource = null;

                var response = await _parteSucursalServices.ObtenerPartesSucursal();
                if (response.Success == false || response.Data.Count() <= 0)
                {
                    MessageBox.Show($"Error al cargar partes sucursales: {response.ErrorMessage}");
                    return;
                }
                table.DataSource = response.Data.Select(ps => new
                {
                    idColumn = ps.IdParteSucursal,
                    parteColumn = ps.Parte,
                    costoUnitarioColumn = ps.CostoUnitario,
                    stockColumn = ps.Stock,
                    fechaRegistroColumn = ps.FechaRegistro.ToString("dd/MM/yyyy"),
                    fechaModificacionColumn = ps.FechaModificacion.ToString("dd/MM/yyyy"),
                    sucursalColumn = ps.Sucursal
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
