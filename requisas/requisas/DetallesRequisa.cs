using Dbo;
using Modelos;
using Modelos.Enums;
using Modelos.requisas;
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

namespace CapaVista
{
    public partial class DetallesRequisa : Form
    {

        private RequisaServices _requisaServices = new RequisaServices();

        public DetallesRequisa()
        {
            InitializeComponent();
        }

        private async void DetallesRequisa_Load(object sender, EventArgs e)
        {
            await loadDataEstadoTable();
            await loadDataAjusteTable();
            await loadRequisa();
            await calculateDaysDelayed();
            await loadRequisaRechazada();
        }

        private async Task loadDataEstadoTable()
        {

            if (String.IsNullOrEmpty(numeroRequisaLabel.Text))
            {
                MessageBox.Show("El código de la requisa no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var response = await _requisaServices.obtenerEstadosRequisasPorIdRequisa(numeroRequisaLabel.Text);

            if (!response.Success || response.Data == null)
            {
                MessageBox.Show("Error al cargar los estados de la requisa: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tableEstados.DataSource = null;
            tableEstados.AutoGenerateColumns = false;
            tableEstados.DataSource = response.Data.Select(e => new
            {
                idHistorialRequisaColumn = e.IdEstadoRequisa,
                idRequisaColumn = e.Requisa.NDocumentoRequisa,
                estadoColumn = e.Estado,
                CreadoPorColumn = e.CreadoPor,
                fechaCreacionColumn = e.FechaCreacion.ToString("dd/MM/yyyy HH:mm:ss"),
            }).ToList();
        }

        private async Task loadDataAjusteTable()
        {
            if (String.IsNullOrEmpty(numeroRequisaLabel.Text))
            {
                MessageBox.Show("El código de la requisa no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var response = await _requisaServices.ObtenerTodasLasRequisasConAjustesPorIdRequisa(numeroRequisaLabel.Text);
            if (!response.Success || response.Data == null)
            {
                MessageBox.Show("Error al cargar los ajustes de la requisa: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var requisaAjustes = response.Data.ToList();

            if (requisaAjustes.Count <= 0)
            {
                MessageBox.Show("No hay ajustes para mostrar.");
                return;
            }

            // Crear el DataTable
            var dt = new DataTable();
            dt.Columns.Add("idTipoAjusteColumn", typeof(Object)); // Tipo de ajuste
            dt.Columns.Add("tipoAjusteColumn", typeof(Object));
            dt.Columns.Add("numeroParteColumn", typeof(Object));
            dt.Columns.Add("cantidadColumn", typeof(decimal));
            dt.Columns.Add("DescripciónAjusteColumn", typeof(string));
            dt.Columns.Add("costoPromedioColumn", typeof(decimal));
            dt.Columns.Add("costoPromedioExtendidoColumn", typeof(decimal));
            dt.Columns.Add("casaColumn", typeof(Object));
            dt.Columns.Add("sucursalColumn", typeof(Object));
            dt.Columns.Add("costoUnitarioColumn", typeof(decimal));
            dt.Columns.Add("reclamoColumn", typeof(Object));
            dt.Columns.Add("transferenciaColumn", typeof(Object));
            dt.Columns.Add("visualizarColumn", typeof(string));

            // Agregar los datos normales
            foreach (var ra in requisaAjustes)
            {
                ra.Reclamo = ra.Reclamo.IdReclamo == null ? null : ra.Reclamo;
                ra.Transferencia = ra.Transferencia.IdTransferencia == null ? null : ra.Transferencia;

                dt.Rows.Add(
                    ra.IdRequisaAjuste,
                    ra.TipoAjuste,
                    ra.ParteSucursal?.Parte,
                    ra.MontoAjuste ?? 0,
                    ra.Descripcion ?? "",
                    ra.ParteSucursal?.CostoUnitario ?? 0,
                    ra?.CostoPromedioExtendido ?? 0,
                    ra?.ParteSucursal?.Sucursal?.Casa?.NombreCasa ?? "Casa Vacía",
                    ra?.ParteSucursal?.Sucursal?.NombreSucursal ?? "Sucursal Vacía",
                    ra.ParteSucursal?.CostoUnitario ?? 0,
                    ra?.Reclamo,
                    ra?.Transferencia,
                    ra?.Reclamo?.DocumentoReclamo?.DocumentoBytes != null ? "Ver Documento" : ""
                );
            }

            // Calcular totales
            decimal totalCostoPromedioExtendido = requisaAjustes.Sum(ra => ra.CostoPromedioExtendido);
            decimal totalCostoPromedio = requisaAjustes.Sum(ra => ra.ParteSucursal.CostoUnitario);
            decimal totalCantidad = requisaAjustes.Sum(ra => ra.MontoAjuste ?? 0);

            // Agregar la fila de totales
            dt.Rows.Add(
                "",
                "Total",
                null,
                totalCantidad,
                "",
                totalCostoPromedio,
                totalCostoPromedioExtendido,
                null,
                null,
                null,
                null,
                null,
                ""
            );

            tableAjustes.DataSource = null;
            tableAjustes.AutoGenerateColumns = false;
            tableAjustes.DataSource = dt;
        }

        private async void tableAjustes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return; // Evitar errores si se hace clic en el encabezado o fuera de las celdas
            }

            if (tableAjustes.Columns[e.ColumnIndex].Name == "visualizarColumn")
            {
                var doc = tableAjustes.Rows[e.RowIndex].Cells["reclamoColumn"].Value as Reclamo;

                if (doc == null || doc.DocumentoReclamo == null || doc.DocumentoReclamo.DocumentoBytes == null)
                {
                    MessageBox.Show("No hay documento asociado al reclamo.");
                    return;
                }

                reportView viewReport = new reportView();
                viewReport.Show();
                await viewReport.CargarPdf(doc.DocumentoReclamo.Nombre, doc.DocumentoReclamo.DocumentoBytes);
            }
        }

        private async Task loadRequisa()
        {
            var response = await _requisaServices.obtenerEstadosRequisasPorIdRequisa(numeroRequisaLabel.Text);

            if (response.Data == null)
            {
                MessageBox.Show("No se encontró la requisa con el número proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var dateCreatedRequisa = response.Data.FirstOrDefault()?.Requisa.FechaRegistro;

            if (dateCreatedRequisa == null)
            {
                fechaCreacionLabel.Text = "Fecha no disponible";
                return;
            }
            fechaCreacionLabel.Text = dateCreatedRequisa.Value.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private async Task calculateDaysDelayed()
        {
            var response = await _requisaServices.obtenerEstadosRequisasPorIdRequisa(numeroRequisaLabel.Text);

            if (response.Data == null)
            {
                MessageBox.Show("No se encontró la requisa con el número proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var isRequisaAplicada = response.Data.Any(e => e.Estado.IdEstado == Estados.APLICADA as int?);

            if (isRequisaAplicada)
            {
                diasRetrasoLabel.Text = "Requisa Aplicada";
                return;
            }

            // obtiene el el ultimo día del que se le asignó un estado a la requisa
            //var ultimeDateStateRequisa = response.Data
            //    .Where(e => e.Estado.IdEstado != Estados.APLICADA as int?)
            //    .OrderByDescending(e => e.Estado.FechaRegistro)
            //    .FirstOrDefault();


            var dateCreatedRequisa = response.Data.FirstOrDefault()?.Requisa.FechaRegistro;

            TimeSpan daysDelayed =  DateTime.Now - dateCreatedRequisa.Value;

            if (daysDelayed.Days < 0)
            {
                diasRetrasoLabel.Text = "Requisa no registrada";
                diasRetrasoLabel.ForeColor = Color.Black;
            }
            else
            {
                diasRetrasoLabel.Text = $"{daysDelayed.Days} días de retraso";
            }
        }

        private async Task loadRequisaRechazada() { 
            
            var numeroRequisa = numeroRequisaLabel.Text;
            if (string.IsNullOrEmpty(numeroRequisa))
            {
                return;
            }

            var response = await _requisaServices.obtenerRequisasRechazadasPorNumeroRequisa(numeroRequisa);
            if (response.Data == null)
            {
                return;
            }

            requisaRechazadaLabel.Text = string.IsNullOrEmpty(response.Data.Descripcion) ? "No" : "Si";
            descripcionRequisaRechazadaInput.Text = string.IsNullOrEmpty(response.Data.Descripcion) ? "La requisa no ha sido Rechazada" : response.Data.Descripcion;
        }
    }
}
