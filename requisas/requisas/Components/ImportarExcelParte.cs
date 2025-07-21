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
    public partial class ImportarExcelParte : Form
    {
        private List<Parte> _listPartes = new();

        public List<Parte> ListParte { get => _listPartes; set => _listPartes = value; }


        public ImportarExcelParte()
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
            _listPartes.Clear();
            this.Close();
        }

        private void ImportarExcelParte_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void loadDataTable()
        {
            table.DataSource = _listPartes.Select(p => new
            {
                numeroParteColumn = p?.NumeroParte ?? "",
                descripcionParteColumn = p?.DescripcionParte ?? ""
            }).ToList();
        }
    }
}
