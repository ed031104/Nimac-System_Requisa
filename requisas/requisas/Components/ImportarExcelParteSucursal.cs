using Modelos;
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
    public partial class ImportarExcelParteSucursal : Form
    {
        private List<ParteSucursal> _listParteSucursal = new();

        public List<ParteSucursal> ListParteSucursal { get => _listParteSucursal; set => _listParteSucursal = value; }

        public ImportarExcelParteSucursal()
        {
            InitializeComponent();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            _listParteSucursal.Clear();
            this.Close();
        }

        private void ImportarExcelParteSucursal_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void loadDataTable()
        {
            table.DataSource = _listParteSucursal.Select(p => new
            {
                numeroParteColumn = p?.Parte.NumeroParte,
                costoUnitarioColumn = p?.CostoUnitario,
                stockColumn = p?.Stock,
                numeroSucursalColumn = p?.Sucursal.NumeroSucursal
            }).ToList();
        }
    }
}
