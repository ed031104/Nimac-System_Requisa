using CapaVista;
using CapaVista.Components;
using CapaVista.utils;
using Dbo;
using Modelos;
using Modelos.Enums;
using Modelos.login;
using Modelos.requisas;
using Servicios;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace requisas
{
    public partial class Nueva_Requisa : Form
    {
        #region dendencias
        // servicios
        private RequisaServices _requisaServices = new RequisaServices();
        private TipoAjusteServices _tipoAjusteServices = new TipoAjusteServices();
        private ParteSucursalServices _parteSucursalServices = new ParteSucursalServices();
        private SucursalServices _sucursalServices = new SucursalServices();
        private CasaServices _casaServices = new CasaServices();
        private ExcelReader _excelReader = new ExcelReader();

        private (string? nombre, Byte[]? value) archivo;

        // listas   
        private List<RequisaAjuste> requisaAjustes = new List<RequisaAjuste>();
        List<ParteSucursal> partesSucursales = new();
        #endregion

        public Nueva_Requisa()
        {
            InitializeComponent();
        }

        private async void Nueva_Requisa_Load(object sender, EventArgs e)
        {
            visibleModuleForRoleUser(UserSession.Instance.ID);
            await cargarTiposAjustes();
            await cargarSucursalTransferir();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return; // Evitar errores si se hace clic en el encabezado o fuera de las celdas
            }

            if (table.Columns[e.ColumnIndex].Name == "viewDocumentColumn")
            {
                var doc = table.Rows[e.RowIndex].Cells["reclamoColumn"].Value as Reclamo;

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

        private async void nParteAjusteComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nParteAjusteInput.Enabled = false;
                await buscarPartePorNumeroParte(nParteAjusteInput.Text);
                nParteAjusteInput.Enabled = true;
            }
            if (e.KeyCode == Keys.F1)
            {
                ViewParteSucursales viewParteSucursales = new ViewParteSucursales();
                viewParteSucursales.ShowDialog();

                var partesucursalSeleccionada = viewParteSucursales.ParteSucursal;

                if (partesucursalSeleccionada == null)
                {
                    MessageBox.Show("No se ha seleccionado ninguna parte sucursal.");
                    return;
                }

                nParteAjusteInput.Enabled = false;
                await buscarPartePorNumeroParte(partesucursalSeleccionada);
                nParteAjusteInput.Enabled = true;

                nParteAjusteInput.Text = partesucursalSeleccionada;
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            var casa = casaRequisaComboBox.SelectedItem as Casa;
            var sucursal = sucursalRequisaComboBox.SelectedItem as Sucursal;
            var tipoAjuste = tipoAjusteRequisaComboBox.SelectedItem as TipoAjuste;
            Reclamo reclamo = null;
            Transferencia transferencia = null;
            Documento documento = null;

            if (casa == null || sucursal == null || tipoAjuste == null)
            {
                MessageBox.Show("Por favor, seleccione una casa, sucursal y tipo de ajuste válidos.");
                return;
            }
            if (string.IsNullOrWhiteSpace(nParteAjusteInput.Text) || string.IsNullOrWhiteSpace(cantidadParteInput.Text) || string.IsNullOrWhiteSpace(descripcionParteInput.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }
            if (!int.TryParse(cantidadParteInput.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
                return;
            }

            if (cantidad == 0)
            {
                MessageBox.Show("La cantidad no puede ser cero.");
                return;
            }

            if (tipoAjuste.SimboloTipoAjuste.Equals("-"))
            {
                cantidad *= -1; // Si el símbolo es negativo, multiplicamos la cantidad por -1
            }

            if (moduleReclamo.Visible)
            {
                if (string.IsNullOrWhiteSpace(observacionReclamoInput.Text) || archivo.nombre == null || archivo.value == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos del reclamo y seleccione un archivo.");
                    return;
                }

                documento = new Documento.Builder()
                    .SetNombre(archivo.nombre)
                    .SetDocumento(archivo.value)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();

                reclamo = new Reclamo.Builder()
                    .SetObservacion(observacionReclamoInput.Text)
                    .SetDocumento(documento)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();
            }

            if (moduleTransferir.Visible)
            {
                if (casaTransferirComboBox.SelectedItem == null || sucursalTransferirComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione una casa y sucursal para la transferencia.");
                    return;
                }
                var casaTransferir = casaTransferirComboBox.SelectedItem as Casa;
                var sucursalTransferir = sucursalTransferirComboBox.SelectedItem as Sucursal;

                if (casaTransferir == null || sucursalTransferir == null)
                {
                    MessageBox.Show("Por favor, seleccione una casa y sucursal válidas para la transferencia.");
                    return;
                }

                transferencia = new Transferencia.Builder()
                    .SetCasa(casaTransferir)
                    .SetSucursal(sucursalTransferir)
                    .SetCreadoPor(UserSession.Instance.NombreUsuario)
                    .SetModificadoPor(UserSession.Instance.NombreUsuario)
                    .SetFechaCreacion(DateTime.Now)
                    .SetFechaModificacion(DateTime.Now)
                    .Build();
            }

            var parteSucursalBuscada = partesSucursales
                .Where(ps => ps.Parte.NumeroParte.Equals(nParteAjusteInput.Text))
                .Where(ps => ps.Sucursal.NumeroSucursal.Equals(sucursal.NumeroSucursal))
                .Where(ps => ps.Sucursal.Casa.CodigoCasa.Equals(casa.CodigoCasa))
                .FirstOrDefault();

            string idRequisaAjuste = sucursal.NumeroSucursal + "-" + tipoAjuste.Descripcion.Substring(0, 1);



            var requisaAjuste = new RequisaAjuste.Builder()
                .SetIdRequisaAjuste(idRequisaAjuste)
                .SetCostoPromedio(parteSucursalBuscada.CostoUnitario)
                .SetTipoAjuste(tipoAjuste)
                .SetMontoAjuste(cantidad)
                .SetReclamo(reclamo)
                .SetTransferencia(transferencia)
                .SetDescripcion(descripcionParteInput.Text)
                .SetParteSucursal(parteSucursalBuscada)
                .SetCreadoPor(UserSession.Instance.NombreUsuario)
                .SetModificadoPor(UserSession.Instance.NombreUsuario)
                .SetFechaRegistro(DateTime.Now)
                .SetFechaModificacion(DateTime.Now)
                .SetCostoPromedioExtendido(cantidad * parteSucursalBuscada.CostoUnitario)
                .Build();

            requisaAjustes.Add(requisaAjuste);

            await cargarTipoAjusteTabla();
        }

        private void casaRequisaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var casaSeleccionada = casaRequisaComboBox.SelectedItem as Casa;
            if (casaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione una casa válida.");
                sucursalRequisaComboBox.DataSource = null;
                return;
            }
            var sucursales = partesSucursales
                .Where(ps => ps.Sucursal.Casa.CodigoCasa == casaSeleccionada.CodigoCasa)
                .Select(ps => ps.Sucursal)
                .Distinct()
                .ToList();
            sucursalRequisaComboBox.DataSource = sucursales;
            sucursalRequisaComboBox.DisplayMember = "NombreSucursal";
            sucursalRequisaComboBox.ValueMember = "NumeroSucursal";
        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!partesSucursales.Any())
                {
                    MessageBox.Show("No se han seleccionado partes válidas.");
                    return;
                }

                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas guardar estos ajustes seleccionados?, una vez guardados no se pueden modificar y puede ser rechazada la requisa.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                guardarButton.Enabled = false;

                if (String.IsNullOrEmpty(descripcionParteInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para la requisa.");
                    return;
                }

                var requisa = new Requisa.Builder()
                    .SetDescripcion(descripcionRequisaInput.Text)
                    .SetEstado(true)
                    .SetFechaRegistro(DateTime.Now)
                    .Build();

                var response = await _requisaServices.crearRequisaConAjustes(requisa, requisaAjustes);

                if (response.Success == false)
                {
                    MessageBox.Show($"Error al crear la requisa: {response.ErrorMessage}");
                    return;
                }
                MessageBox.Show("Requisa creada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la requisa: {ex.Message}");
                return;
            }
            finally
            {
                requisaAjustes.Clear();
                table.DataSource = null; // Limpiar la tabla
                guardarButton.Enabled = true;
                archivo.nombre = null;
                archivo.value = null; // Reiniciar el archivo cargado
                observacionReclamoInput.Clear(); // Limpiar el campo de observación del reclamo
                cantidadParteInput.Clear(); // Limpiar el campo de cantidad
                descripcionParteInput.Clear(); // Limpiar el campo de descripción
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {

            if (requisaAjustes.Count <= 0)
            {
                MessageBox.Show("No hay ajustes agregados para eliminar.");
                await cargarTipoAjusteTabla();
                return;
            }

            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar los ajustes seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            var indicesAEliminar = new List<int>();

            foreach (DataGridViewRow fila in table.Rows)
            {
                bool estaMarcado = Convert.ToBoolean(fila.Cells["checkColumn"].Value);
                if (estaMarcado)
                {
                    indicesAEliminar.Add(fila.Index);
                }
            }

            if (indicesAEliminar.Count <= 0)
            {
                MessageBox.Show("No se han seleccionado ajustes para eliminar.");
                return;
            }

            indicesAEliminar.Sort((a, b) => b.CompareTo(a)); // Ordenar de mayor a menor para evitar problemas al eliminar filas

            foreach (int index in indicesAEliminar)
            {
                if (index >= 0 && index < requisaAjustes.Count)
                {
                    requisaAjustes.RemoveAt(index);
                }
            }

            await cargarTipoAjusteTabla();
        }

        private async void importarExcelButton_Click(object sender, EventArgs e)
        {

        }

        private void cargarPdfButton_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;

            try
            {
                archivo.nombre = null; // Reiniciar el archivo antes de cargar uno nuevo
                archivo.value = null;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Documento cargado correctamente:\n" + ruta);
                }

                Byte[] fileBytes = File.ReadAllBytes(ruta);
                archivo.value = fileBytes;
                archivo.nombre = Path.GetFileName(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el documento: {ex.Message}");
                return;
            }
        }

        private void tipoAjusteRequisaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectItem = tipoAjusteRequisaComboBox.SelectedItem as TipoAjuste;

            if (selectItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de ajuste válido.");
                return;
            }

            switch (selectItem.TipoAjusteId)
            {
                case (int)Ajuste.Transferencia:
                    moduleTransferir.Visible = true;
                    moduleReclamo.Visible = false;
                    cargarPdfButton.Visible = false;
                    break;
                case (int)Ajuste.malEnviado:
                    moduleTransferir.Visible = false;
                    moduleReclamo.Visible = true;
                    cargarPdfButton.Visible = true;
                    break;
                case (int)Ajuste.Reverso:
                    moduleTransferir.Visible = false;
                    moduleReclamo.Visible = true;
                    cargarPdfButton.Visible = true;
                    break;
                default:
                    moduleTransferir.Visible = false;
                    moduleReclamo.Visible = false;
                    cargarPdfButton.Visible = false;
                    break;
            }
        }

        private async void casaTransferirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var casaSeleccionada = casaTransferirComboBox.SelectedItem as Casa;

            if (casaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione una casa válida para la transferencia.");
                sucursalTransferirComboBox.DataSource = null;
                return;
            }

            var responseSucursales = await _sucursalServices.ObtenerSucursalesPorNumeroCasa(casaSeleccionada.CodigoCasa);

            if (responseSucursales.Success == false || responseSucursales.Data == null)
            {
                MessageBox.Show($"Error al cargar sucursales: {responseSucursales.ErrorMessage}");
                return;
            }
            sucursalTransferirComboBox.DataSource = responseSucursales.Data;
        }

        #region Additional Methods

        private void visibleModuleForRoleUser(int idRole)
        {
            UserRol currentUserRole = (UserRol)idRole;

            switch (currentUserRole)
            {
                case UserRol.Administrador:
                    break;
                case UserRol.GereteDeRepuesto:
                    break;
                case UserRol.GereteDeOperaciones:
                    break;
                case UserRol.Auxiliar:
                    break;
                case UserRol.Analista:
                    break;
            }
        }

        private async Task cargarTiposAjustes()
        {
            var tipoAjustes = await _tipoAjusteServices.ObtenerTiposAjuste();
            if (tipoAjustes.Success == false || tipoAjustes.Data.Count() <= 0)
            {
                MessageBox.Show($"Error al cargar tipos de ajuste: {tipoAjustes.ErrorMessage}");
                return;
            }
            tipoAjusteRequisaComboBox.DataSource = tipoAjustes.Data.ToList();
        }

        private async Task cargarSucursalTransferir()
        {
            var response = await _casaServices.ObtenerTodasLasCasas();
            if (response.Success == false || response.Data == null)
            {
                MessageBox.Show($"Error al cargar partes de sucursal: {response.ErrorMessage}");
                return;
            }
            casaTransferirComboBox.DataSource = response.Data.ToList();
        }

        private async Task cargarTipoAjusteTabla()
        {
            if (requisaAjustes.Count <= 0)
            {
                MessageBox.Show("No hay ajustes para mostrar.");
                return;
            }

            // Crear el DataTable
            var dt = new DataTable();
            dt.Columns.Add("tipoAjusteColumn", typeof(Object));
            dt.Columns.Add("numeroParteColumn", typeof(Object));
            dt.Columns.Add("cantidadColumn", typeof(decimal));
            dt.Columns.Add("descripcionColumn", typeof(string));
            dt.Columns.Add("costoPromedioCOlumn", typeof(decimal));
            dt.Columns.Add("costoPromedioExtendidoColumn", typeof(decimal));
            dt.Columns.Add("columcasa", typeof(Object));
            dt.Columns.Add("sucursalColumn", typeof(Object));
            dt.Columns.Add("costoUnitarioColumn", typeof(decimal));
            dt.Columns.Add("reclamoColumn", typeof(Object));
            dt.Columns.Add("transferirColumn", typeof(Object));
            dt.Columns.Add("viewDocumentColumn", typeof(string));

            // Agregar los datos normales
            foreach (var ra in requisaAjustes)
            {
                dt.Rows.Add(
                    ra.TipoAjuste,
                    ra.ParteSucursal.Parte,
                    ra.MontoAjuste ?? 0,
                    ra.Descripcion,
                    ra.ParteSucursal?.CostoUnitario ?? 0,
                    ra.CostoPromedioExtendido,
                    ra.ParteSucursal?.Sucursal?.Casa,
                    ra.ParteSucursal?.Sucursal,
                    ra.ParteSucursal?.CostoUnitario ?? 0,
                    ra.Reclamo,
                    ra.Transferencia,
                    ra.Reclamo?.DocumentoReclamo?.DocumentoBytes != null ? "Ver Documento" : "Sin Documento"
                );
            }

            // Calcular totales
            decimal totalCostoPromedioExtendido = requisaAjustes.Sum(ra => ra.CostoPromedioExtendido);
            decimal totalCostoPromedio = requisaAjustes.Sum(ra => ra.ParteSucursal.CostoUnitario);
            decimal totalCantidad = requisaAjustes.Sum(ra => ra.MontoAjuste ?? 0);

            // Agregar la fila de totales
            dt.Rows.Add(
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

            table.DataSource = null;
            table.AutoGenerateColumns = false;
            table.DataSource = dt;
        }

        private async Task buscarPartePorNumeroParte(string numeroParte)
        {
            var response = await _parteSucursalServices.obtenerPartePorNumeroParte(numeroParte);
            if (response.Success == false || response.Data == null)
            {
                MessageBox.Show($"Error al buscar parte por número: {response.ErrorMessage}");
                return;
            }
            partesSucursales = response.Data.ToList();

            descripcionLabel.Text = partesSucursales.FirstOrDefault()?.Parte.DescripcionParte ?? string.Empty;
            casaRequisaComboBox.DataSource = partesSucursales
                    .Select(ps => ps.Sucursal.Casa)
                    .Where(ps => ps != null)
                    .GroupBy(ps => ps.CodigoCasa)
                    .Select(g => g.First())
                    .ToList();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private enum Ajuste
        {
            Faltante = 1,
            Sobrante = 2,
            Transferencia = 3,
            malEnviado = 4,
            Reverso = 5,
            costoCero = 6
        }

        #endregion

    }
}
