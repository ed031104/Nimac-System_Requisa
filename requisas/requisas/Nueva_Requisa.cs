using CapaVista;
using CapaVista.utils;
using Modelos;
using Servicios;
using System.Collections.Generic;
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
        private ExcelReader _excelReader = new ExcelReader();

        // listas   
        private List<RequisaAjuste> requisaAjustes = new List<RequisaAjuste>();
        private ParteSucursal _parteSucursal = new ParteSucursal();
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
        }

        private void cargarPdfButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            openFileDialog.Title = "Selecciona un archivo PDF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaPDF = openFileDialog.FileName;

                // Aquí puedes hacer lo que necesites:
                // Mostrarlo, guardarlo como binario, etc.

                MessageBox.Show("PDF cargado correctamente:\n" + rutaPDF);

                // Corrige el error eliminando el uso de 'await' innecesario
                // Si quieres cargarlo en visor externo:
                // System.Diagnostics.Process.Start(new ProcessStartInfo(rutaPDF) { UseShellExecute = true });

                // Si quieres convertirlo a base64:
                // string base64 = Convert.ToBase64String(File.ReadAllBytes(rutaPDF));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void nParteAjusteComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nParteAjusteInput.Enabled = false;
                await buscarPartePorNumeroParte(nParteAjusteInput.Text);
                nParteAjusteInput.Enabled = true;
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            var casa = casaRequisaComboBox.SelectedItem as Casa;
            var sucursal = sucursalRequisaComboBox.SelectedItem as Sucursal;
            var tipoAjuste = tipoAjusteRequisaComboBox.SelectedItem as TipoAjuste;

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

            var parteSucursalBuscada = partesSucursales
                .Where(ps => ps.Parte.NumeroParte.Equals(nParteAjusteInput.Text))
                .Where(ps => ps.Sucursal.NumeroSucursal.Equals(sucursal.NumeroSucursal))
                .Where(ps => ps.Sucursal.Casa.CodigoCasa.Equals(casa.CodigoCasa))
                .FirstOrDefault();

            var requisaAjuste = new RequisaAjuste.Builder()
                .SetCostoPromedio(parteSucursalBuscada.CostoUnitario)
                .SetTipoAjuste(tipoAjuste)
                .SetMontoAjuste(cantidad)
                .SetDescripcion(descripcionParteInput.Text)
                .SetParteSucursal(parteSucursalBuscada)
                .SetMontoAjuste(Convert.ToInt32(cantidadParteInput.Text))
                .SetCostoPromedioExtendido(Convert.ToInt32(cantidadParteInput.Text) * parteSucursalBuscada.CostoUnitario)
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
                var requisa = new Requisa.Builder();

                //var response = await _requisaServices.crearRequisa();
                //if (response.Success == false)
                //{
                //    MessageBox.Show($"Error al crear la requisa: {response.ErrorMessage}");
                //    return;
                //}
                //MessageBox.Show("Requisa creada exitosamente.");

                //requisaAjustes.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la requisa: {ex.Message}");
                return;
            }
        }

        private async void importarExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarExcel importarExcel = new ImportarExcel();
                string ruta = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Selecciona un archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                    MessageBox.Show("Excel cargado correctamente:\n" + ruta);
                }

                var dataParserExcel = await _excelReader.ParserExcelAndRequisa(ruta);

                if (dataParserExcel.Success == false || !dataParserExcel.Data.Any())
                {
                    MessageBox.Show($"Error al procesar el archivo: {dataParserExcel.ErrorMessage}");
                    return;
                }

                IEnumerable<RequisaAjuste> listDataExcel = dataParserExcel.Data;

                importarExcel.ListRequisaAjuste = listDataExcel.ToList();
                importarExcel.ShowDialog();

                if (importarExcel.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Importación cancelada.");
                    return;
                }
                requisaAjustes.AddRange(listDataExcel);
                await cargarTipoAjusteTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar Excel: {ex.Message}");
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {

            if (requisaAjustes.Count <= 0)
            {
                MessageBox.Show("No hay ajustes seleccionados para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar los ajustes seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow fila in table.Rows)
            {
                bool estaMarcado = Convert.ToBoolean(fila.Cells["checkColumn"].Value);

                if (estaMarcado)
                {
                    // Recuperar el objeto original de la fila
                    var item = fila.DataBoundItem;

                    if (item == null)
                    {
                        continue;
                    }

                    var tipoAjuste = item.GetType().GetProperty("tipoAjusteColumn").GetValue(item) as TipoAjuste;
                    var parte = item.GetType().GetProperty("numeroParteColumn").GetValue(item) as Parte;
                    var montoAjuste = Convert.ToInt32(item.GetType().GetProperty("cantidadColumn").GetValue(item));
                    var descripcion = item.GetType().GetProperty("descripcionColumn").GetValue(item) as string;
                    var costoPromedio = Convert.ToDecimal(item.GetType().GetProperty("costoPromedioCOlumn").GetValue(item));
                    var costoPromedioExtendido = Convert.ToDecimal(item.GetType().GetProperty("costoPromedioExtendidoColumn").GetValue(item));

                    requisaAjustes.RemoveAll(ra =>
                            ra.TipoAjuste.Descripcion.Equals(tipoAjuste.Descripcion) &&
                            ra.ParteSucursal.Parte.NumeroParte.Equals(parte.NumeroParte) &&
                            ra.MontoAjuste.Equals(montoAjuste) &&
                            ra.Descripcion.Equals(descripcion) &&
                            ra.CostoPromedio.Equals(costoPromedio) &&
                            ra.CostoPromedioExtendido.Equals(costoPromedioExtendido)
                        );
                }
            }
            await cargarTipoAjusteTabla();
        }

        #region Additional Methods
        private void visibleModuleForRoleUser(int idRole)
        {
            userRole currentUserRole = (userRole)idRole;

            switch (currentUserRole)
            {
                case userRole.Administrador:
                    nDocumentoRequisaInput.Enabled = true;
                    estadoRequisaComboBox.Enabled = true;
                    break;
                case userRole.GereteDeRepuesto:
                    nDocumentoRequisaInput.Enabled = true;
                    estadoRequisaComboBox.Enabled = true;
                    break;
                case userRole.GereteDeOperaciones:
                    nDocumentoRequisaInput.Enabled = true;
                    estadoRequisaComboBox.Enabled = true;
                    break;
                case userRole.Auxiliar:
                    nDocumentoRequisaInput.Enabled = false;
                    estadoRequisaComboBox.Enabled = false;
                    break;
                case userRole.Analista:
                    nDocumentoRequisaInput.Enabled = false;
                    estadoRequisaComboBox.Enabled = true;
                    break;
            }
        }

        private enum userRole
        {
            Administrador = 1,
            GereteDeRepuesto = 2,
            GereteDeOperaciones = 3,
            Auxiliar = 4,
            Analista = 5,
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

        private async Task cargarTipoAjusteTabla()
        {
            if (requisaAjustes.Count <= 0)
            {
                MessageBox.Show("No hay ajustes para mostrar.");
                return;
            }

            table.DataSource = null;
            table.DataSource = requisaAjustes.Select(ra => new
            {
                tipoAjusteColumn = ra.TipoAjuste,
                numeroParteColumn = ra.ParteSucursal.Parte,
                cantidadColumn = ra.MontoAjuste,
                descripcionColumn = ra.Descripcion,
                costoPromedioCOlumn = ra.ParteSucursal.CostoUnitario,
                costoPromedioExtendidoColumn = ra.CostoPromedioExtendido,
                columcasa = ra.ParteSucursal.Sucursal.Casa,
                sucursalColumn = ra.ParteSucursal.Sucursal,
                costoUnitarioColumn = ra.ParteSucursal.CostoUnitario
            }).ToList();
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

            casaRequisaComboBox.DataSource = partesSucursales
                .Select(ps => ps.Sucursal.Casa)
                .Where(ps => ps != null)
                .GroupBy(ps => ps.CodigoCasa)
                .Select(g => g.First())
                .ToList();
        }
        #endregion
    }
}
