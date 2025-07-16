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
    public partial class ImportarExcelSucursal : Form
    {

        private List<Sucursal> _listSucursales = new();

        public List<Sucursal> ListSucursales { get => _listSucursales; set => _listSucursales = value; }

        public ImportarExcelSucursal()
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
            _listSucursales.Clear();
            this.Close();
        }

        private void ImportarExcelSucursal_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void loadDataTable()
        {
            table.AutoGenerateColumns = false;
            table.DataSource = _listSucursales.Select(s => new
            {
                nombreSucursal = s?.NombreSucursal ?? "",
                numeroSucursalColum = s.NumeroSucursal ?? "",
                codigoCasa = s?.Casa.CodigoCasa ?? ""
            }).ToList();
        }
    }
}
