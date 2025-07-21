using Configuraciones;
using Microsoft.Reporting.WinForms;
using Modelos.Dto;
using Modelos.Enums;
using Modelos.requisas;
using Servicios;
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
    public partial class ReportRequisaAjustes : Form
    {
        private readonly RequisaServices _requisaServices;
        private readonly ReporteServices _reporteServices;

        string nameReport = Configuracion.Get("nameReports:requisaAjusteReport");

        public ReportRequisaAjustes()
        {
            InitializeComponent();
            _requisaServices = new RequisaServices();
            _reporteServices = new ReporteServices();
        }

        private async void ReportRequisaAjustes_Load(object sender, EventArgs e)
        {
            await loadDataComboBox();
        }


        private async void generarReporteButton_Click(object sender, EventArgs e)
        {
            var selectedRequisa = requisaComboBox.SelectedItem as RequisaJoinEstado;

            if (selectedRequisa == null)
            {
                MessageBox.Show("Por favor, seleccione una requisa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "@NumeroRequisa", selectedRequisa.CodigoRequisa}
            };

            await cargarReporte(parametros);
        }

        #region additional methods

        private async Task loadDataComboBox()
        {
            var response = await _requisaServices.ObtenerRequisasagrupadasPorEstado();

            if (!response.Success || response.Data == null)
            {
                MessageBox.Show("Error al cargar las requisas: " + response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var requisaFilterStatus = response.Data.Where(r => r.EstadoRequisa.IdEstado == (int)Estados.APLICADA).ToList();

            var data = requisaFilterStatus;

            requisaComboBox.DataSource = data;
        }

        private async Task cargarReporte(Dictionary<string, object> parametros)
        {
            string rutaReporte = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nameReport);

            var response = await _reporteServices.obtenerRequisasConAjustesPorNumeroRequisa(parametros);

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

            ReportDataSource reportDataSource = new ReportDataSource("RequisaAjustesDataSet", response.Data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
        }
        #endregion
    }
}
