using Dbo;
using Modelos;
using Modelos.Enums;
using Modelos.login;
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
        Reclamo _reclamo;
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
            dt.Columns.Add("nombreParteColumn", typeof(Object)); // Monto del ajuste
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
                    ra.ParteSucursal?.Descripcion ?? "Parte Vacía",
                    ra.MontoAjuste ?? 0,
                    ra.Descripcion ?? "",
                    ra.ParteSucursal?.CostoUnitario ?? 0,
                    ra?.CostoPromedioExtendido ?? 0,
                    ra?.ParteSucursal?.Casa ?? "Casa Vacía",
                    ra?.ParteSucursal?.Sucursal ?? "Sucursal Vacía",
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
                null,
                totalCantidad,
                "",
                totalCostoPromedio,
                totalCostoPromedioExtendido,
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

            TimeSpan daysDelayed = DateTime.Now - dateCreatedRequisa.Value;

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

        private async Task loadRequisaRechazada()
        {

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

        private async void cargarPdfButton_Click(object sender, EventArgs e)
        {
            Documento archivo = new Documento();
            try
            {
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Documento cargado correctamente:\n" + ruta);
                }

                Byte[] fileBytes = File.ReadAllBytes(ruta);
                archivo.DocumentoBytes = fileBytes;
                archivo.Nombre = Path.GetFileName(ruta);

                int idReclamo = (int)_reclamo.IdReclamo;

                var response = await _requisaServices.AsginarDocuemtoReclamoAjuste(archivo, idReclamo);

                if (!response.Success)
                {
                    MessageBox.Show("Error al cargar el PDF: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("PDF cargado correctamente al reclamo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await loadDataAjusteTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el PDF: {ex.Message}");
                return;
            }
        }

        private void tableAjustes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                try
                {
                    var ajuste = tableAjustes.Rows[e.RowIndex].Cells["tipoAjusteColumn"].Value as TipoAjuste;
                    var reclamo = tableAjustes.Rows[e.RowIndex].Cells["reclamoColumn"].Value as Reclamo;

                    if (tableAjustes.Columns[e.ColumnIndex].Name == "visualizarColumn")
                    {
                        return;
                    }

                    if (reclamo?.DocumentoReclamo?.IdDocumento != null || reclamo?.DocumentoReclamo?.IdDocumento == 0)
                    {
                        MessageBox.Show("Ya el reclamo tiene asociado un PDF.");
                        cargarPdfButton.Visible = false;
                        return;
                    }

                    if (ajuste.TipoAjusteId != (int)Ajustes.Reverso && ajuste.TipoAjusteId != (int)Ajustes.MalEnviado)
                    {
                        return;
                    }

                    if (UserSession.Instance.IdRol != (int)UserRol.Analista)
                    {
                        MessageBox.Show("No tienes permisos para cargar un PDF en el reclamo.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _reclamo = reclamo;
                    cargarPdfButton.Visible = true;
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }
    }
}
