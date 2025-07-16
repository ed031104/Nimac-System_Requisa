using Modelos;
using Modelos.requisas;
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
    public partial class ImportarExcelCasa : Form
    {
        private List<Casa> _listCasas = new();

        public List<Casa> ListCasa { get => _listCasas; set => _listCasas = value; }


        public ImportarExcelCasa()
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
            _listCasas.Clear();
            this.Close();
        }

        private void ImportarExcelCasa_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void loadDataTable() {
            table.DataSource = _listCasas.Select(c => new
            {
                nombreCasaColumn = c?.NombreCasa ?? "",
                codigoCasaColumn = c?.CodigoCasa ?? ""
            }).ToList();
        }
    }
}
