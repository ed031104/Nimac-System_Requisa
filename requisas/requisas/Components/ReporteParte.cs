using Configuraciones;
using Microsoft.Reporting.WinForms;
using Servicios.report;
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
    public partial class ReporteParte : Form
    {
        private readonly ReporteServices _reporteServices;
        string nameReport = Configuracion.Get("nameReports:ParteReporte");


        public ReporteParte()
        {
            InitializeComponent();
            _reporteServices = new ReporteServices();
        }

        private async void generarReporteButton_Click(object sender, EventArgs e)
        {
            string casa = CasaInput.Text;
            string sucursal = SucursalInput.Text;

            if (string.IsNullOrEmpty(casa) || string.IsNullOrEmpty(sucursal))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "@casa", casa},
                { "@sucursal", sucursal}
            };

            await cargarReporte(parametros);
        }

        #region additional methods

        private async Task cargarReporte(Dictionary<string, object> parametros)
        {
            string rutaReporte = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nameReport);

            var response = await _reporteServices.obtenerPartes(parametros);

            if (response.Data == null)
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
            reportViewer1.LocalReport.ReportPath = rutaReporte;

            ReportDataSource reportDataSource = new ReportDataSource("ParteDataSet", response.Data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
        }
        #endregion

    }
}
