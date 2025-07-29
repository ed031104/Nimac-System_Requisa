using Configuraciones;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class ReporteCantidadRequisaEstados : Form
    {
        private readonly ReporteServices _reporteServices;
        string nameReport = Configuracion.Get("nameReports:CantidadRequisa");


        public ReporteCantidadRequisaEstados()
        {
            InitializeComponent();
            _reporteServices = new ReporteServices();
        }

        private async void ReporteCantidadRequisaEstados_Load(object sender, EventArgs e)
        {
            await cargarReporte();
        }

        #region additional methods

        private async Task cargarReporte()
        {
            string rutaReporte = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nameReport);

            Dictionary<string, object> parametros = new();

            var response = await _reporteServices.obtenerRequisasAgrupadasPorEstado(parametros);

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

            ReportDataSource reportDataSource = new ReportDataSource("CantidadRequisasEstadoDataSet", response.Data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
        }
        #endregion
    }
}
