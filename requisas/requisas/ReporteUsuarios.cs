using Microsoft.IdentityModel.Tokens;
using Microsoft.Reporting.WinForms;
using Servicios.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class ReporteUsuarios : Form
    {
        private readonly ReporteServices _reporteServices;

        string path = @"D:\user\documentos\Nimac\SISTEMA NICMAC\requisas\requisas\report\UsuariosReporte.rdlc";

        public ReporteUsuarios()
        {
            InitializeComponent();
            _reporteServices = new ReporteServices();
        }

        private async void ReporteUsuarios_Load(object sender, EventArgs e)
        {
            await cargarReporte();
        }

        private async Task cargarReporte()
        {

            Dictionary<string,object> parametros = new();
            

            var response = await _reporteServices.obtenerUsuariosDT(parametros);

            if(response.Data == null)
            {
                MessageBox.Show("No se encontraron datos para mostrar en el reporte.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!response.Success)
            {
                MessageBox.Show("Error al cargar el reporte: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = path;

            ReportDataSource reportDataSource = new ReportDataSource("UsuariosDataSet", response.Data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
        }
    }
}
