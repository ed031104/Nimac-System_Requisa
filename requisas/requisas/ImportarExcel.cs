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

namespace CapaVista
{
    public partial class ImportarExcel : Form
    {
        private List<RequisaAjuste> _listRequisaAjuste = new();

        public List<RequisaAjuste> ListRequisaAjuste { get => _listRequisaAjuste; set => _listRequisaAjuste = value; }

        public ImportarExcel()
        {
            InitializeComponent();
        }

        private void importarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            _listRequisaAjuste.Clear();
            this.Close();
        }

        private async void ImportarExcel_Load(object sender, EventArgs e)
        {
            await cargarListEnDataGid();
        }

        private async Task cargarListEnDataGid() {
            ExcelVisorTable.DataSource = _listRequisaAjuste.Select(ra => new
            {
                tipoAjusteColumnTE = ra.TipoAjuste,
                numeroParteColumnTE = ra.ParteSucursal.Parte.NumeroParte,
                cantidadColumnTe = ra.MontoAjuste,
                descripcionColumnTE = ra.Descripcion,
                costoPromedioColumnTE = ra.CostoPromedio,
                costoPromedioExtendidoColumnTE = ra.CostoPromedioExtendido,
                casaColumnTE = ra.ParteSucursal.Sucursal.Casa.NombreCasa,
                sucursalColumnTE = ra.ParteSucursal.Sucursal.NombreSucursal,
                costoUnitarioColumnTE = ra.ParteSucursal.CostoUnitario,
            }).ToList();
        }
    }
}
