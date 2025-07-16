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

        private string _parteSucursal;

        public string ParteSucursal
        {
            get { return _parteSucursal; }
            set { _parteSucursal = value; }
        }

        private ParteSucursalServices _parteSucursalServices = new ParteSucursalServices();

        public ViewParteSucursales()
        {
            InitializeComponent();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = table.Rows[e.RowIndex];
                var cellValue = row.Cells[e.ColumnIndex].Value;
                if (cellValue != null)
                {
                    MessageBox.Show($"Valor seleccionado: {cellValue.ToString()}");
                }

                _parteSucursal = row.Cells["numeroParteColumn"].Value.ToString() ?? string.Empty;

                this.Close();
            }

        }

        private async void ViewParteSucursales_Load(object sender, EventArgs e)
        {
            await loadData();
        }

        #region services
        private async Task loadData()
        {
            table.AutoGenerateColumns = false;

            var response = await _parteSucursalServices.ObtenerPartesSucursal();

            if (!response.Success || response.Data == null) { 
                return; // Manejo de error
            }

            table.DataSource = response.Data.Select(ps => new
            {
                idparteSucursalColumn = ps.IdParteSucursal,
                numeroParteColumn = ps.Parte.NumeroParte,
                costoUnitarioColumn = ps.CostoUnitario,
                sucursalColumn = ps.Sucursal,
                fechaRegistroColumn = ps.FechaRegistro,
                fechaModificacionColumn = ps.FechaModificacion
            }).ToList();
        }
        #endregion
    }
}
