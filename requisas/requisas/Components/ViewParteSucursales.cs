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

namespace CapaVista.Components
{
    public partial class ViewParteSucursales : Form
    {

        private ParteSucursalServices _parteSucursalServices = new ParteSucursalServices();
        private List<ParteSucursal> _parteSucursales = new List<ParteSucursal>();

        private string _parteSucursal;
        public string ParteSucursal { get => _parteSucursal; set => _parteSucursal = value; }


        public ViewParteSucursales()
        {
            InitializeComponent();
        }
        
        private async void ViewParteSucursales_Load(object sender, EventArgs e)
        {
            var response = await _parteSucursalServices.ObtenerPartesSucursal();
            if (!response.Success || response.Data == null)
            {
                MessageBox.Show("Error al cargar los datos de las partes sucursales.");
                return; // Manejo de error
            }
            _parteSucursales = response.Data.ToList();

            await loadData();
        }

        private async void buscarPorNombreInput_TextChanged(object sender, EventArgs e)
        {
            table.DataSource = null;

            var listTemp = _parteSucursales;

            if (String.IsNullOrEmpty(buscarPorNombreInput.Text))
            {
                await loadData();
                return;
            }

            var listFilter = listTemp.Where(x =>
                x.Descripcion.ToLower().Contains(buscarPorNombreInput.Text.ToLower()
            )).ToList();

            table.AutoGenerateColumns = false;
            table.DataSource = listFilter.Select(ps => new
            {
                idparteSucursalColumn = ps.IdParteSucursal,
                numeroParteColumn = ps.Parte,
                nombreParteColumn = ps.Descripcion,
                costoUnitarioColumn = ps.CostoUnitario,
                sucursalColumn = ps.Sucursal,
                stockColumn = ps.Stock,
                casaColumn = ps.Casa
            }).ToList();
        }

        private async void numeroParteSearchInput_TextChanged(object sender, EventArgs e)
        {
            table.DataSource = null;

            var listTemp = _parteSucursales;

            if (String.IsNullOrEmpty(buscarPorNombreInput.Text))
            {
                await loadData();
                return;
            }

            var listFilter = listTemp.Where(x =>
                x.Parte.ToLower().Contains(numeroParteSearchInput.Text.ToLower()
            ))
            .ToList();

            table.AutoGenerateColumns = false;
            table.DataSource = listFilter.Select(ps => new
            {
                idparteSucursalColumn = ps.IdParteSucursal,
                numeroParteColumn = ps.Parte,
                nombreParteColumn = ps.Descripcion,
                costoUnitarioColumn = ps.CostoUnitario,
                sucursalColumn = ps.Sucursal,
                stockColumn = ps.Stock,
                casaColumn = ps.Casa
            }).ToList();
        }
    
        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = table.Rows[e.RowIndex];
                var cellValue = row.Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    MessageBox.Show($"Valor seleccionado: {cellValue.ToString()}");
                }

                _parteSucursal = row.Cells["numeroParteColumn"].Value?.ToString() ?? string.Empty;

                this.Close();
            }
        }

 
        #region services
        private async Task loadData()
        {
            table.AutoGenerateColumns = false;

            table.DataSource = _parteSucursales.Select(ps => new
            {
                idparteSucursalColumn = ps.IdParteSucursal,
                numeroParteColumn = ps.Parte,
                nombreParteColumn = ps.Descripcion,
                costoUnitarioColumn = ps.CostoUnitario,
                sucursalColumn = ps.Sucursal,
                stockColumn = ps.Stock,
                casaColumn = ps.Casa
            }).ToList();
        }
        #endregion

    }
}
