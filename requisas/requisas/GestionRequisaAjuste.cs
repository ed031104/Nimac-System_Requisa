using Dbo;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using Modelos;
using Modelos.Enums;
using Modelos.login;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class GestionRequisaAjuste : Form
    {

        private RequisaServices _requisaServices = new RequisaServices();

        private string _numeroRequisaSeleccionada = string.Empty;

        public GestionRequisaAjuste()
        {
            InitializeComponent();
        }

        private async void GestionRequisaAjuste_Load(object sender, EventArgs e)
        {
            await cargarRequisasTable();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return; // Evitar errores si se hace clic en el encabezado o fuera de las celdas
            }

            if (table.Columns[e.ColumnIndex].Name == "viewDatalleColumn")
            {
                var doc = table.Rows[e.RowIndex].Cells["numeroRequisaColumn"].Value.ToString();


                if (String.IsNullOrEmpty(doc))
                {
                    MessageBox.Show("No hay documento asociado al reclamo.");
                    return;
                }

                DetallesRequisa detalleRequisa = new DetallesRequisa();
                detalleRequisa.numeroRequisaLabel.Text = Convert.ToString(doc);
                detalleRequisa.cantidadAjusteLabel.Text = Convert.ToString(table.Rows[e.RowIndex].Cells["cantidadAjusteColumn"].Value);
                detalleRequisa.creadoPorLabel.Text = Convert.ToString(table.Rows[e.RowIndex].Cells["usuarioColumn"].Value);
                detalleRequisa.montoTotalLabel.Text = Convert.ToString(table.Rows[e.RowIndex].Cells["costoTotalColumn"].Value);
                detalleRequisa.Show();
            }
        }

        private async void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                estadoComboBox.DataSource = null;
                RechazarButton.Enabled = true;
                agregarButton.Enabled = true;

                try
                {
                    var numeroRequisa = table.Rows[e.RowIndex].Cells["numeroRequisaColumn"].Value.ToString() ?? "";

                    var statesRequisa = await _requisaServices.obtenerEstadosRequisasPorIdRequisa(numeroRequisa);
                    if (statesRequisa.Data == null)
                    {
                        MessageBox.Show("No se encontró la requisa con el número proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var allStateRequisa = await _requisaServices.obtenerTodosLosEstados();

                    if (allStateRequisa.Data == null)
                    {
                        MessageBox.Show("No se encontraron estados de requisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var stateNotInRequisa = allStateRequisa.Data
                        .Where(s => !statesRequisa.Data.Any(r => r.Estado.IdEstado == s.IdEstado))
                        .Where(s => s.IdEstado != (int)Estados.RECHAZADA) // Excluir el estado RECHAZADA
                        .ToList();

                    if (stateNotInRequisa.Count == 0)
                    {
                        MessageBox.Show("No hay estados disponibles para esta requisa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isRequisaRechazada = statesRequisa.Data.Any(r => r.Estado.IdEstado == (int)Estados.RECHAZADA);

                    if (isRequisaRechazada)
                    {
                        RechazarButton.Enabled = false;
                        agregarButton.Enabled = false;
                    }

                    if (!String.IsNullOrEmpty(_numeroRequisaSeleccionada)) _numeroRequisaSeleccionada = string.Empty;

                    _numeroRequisaSeleccionada = numeroRequisa;
                    estadoComboBox.DataSource = stateNotInRequisa;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var stateSelected = estadoComboBox.SelectedItem as Estado;

                if (stateSelected == null)
                {
                    MessageBox.Show("Por favor, seleccione un estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var isvalidState = await validateState(stateSelected.IdEstado);
                if (!isvalidState) return;

                var response = await _requisaServices.crearEstadoRequisa(_numeroRequisaSeleccionada, stateSelected);
                if (!response.Data || !response.Success)
                {
                    MessageBox.Show("Error al agregar el estado a la requisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Estado agregado correctamente a la requisa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await cargarRequisasTable();
            }
            catch
            {
                MessageBox.Show("Error al agregar el estado a la requisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RechazarButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool Aceptar = MessageBox.Show("¿Está seguro de que desea rechazar la requisa seleccionada?, una vez rechazada ya no se puede utilizar", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                
                if(!Aceptar)
                {
                    return; // Si el usuario no acepta, salir del método
                }

                string descripcionRequisaRechazada = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la descripción de la requisa rechazada:", "Requisa Rechazada", "", -1, -1);

                if (string.IsNullOrEmpty(descripcionRequisaRechazada))
                {
                    MessageBox.Show("La descripción de la requisa rechazada no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string numeroRequisa = _numeroRequisaSeleccionada;
                
                if (string.IsNullOrEmpty(numeroRequisa))
                {
                    MessageBox.Show("Por favor, seleccione una requisa para rechazar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var responseStatus = await _requisaServices.obtenerTodosLosEstados();
                
                if (!responseStatus.Success || responseStatus.Data == null)
                {
                    MessageBox.Show("Error al obtener los estados de la requisa: " + responseStatus.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var statusRechazado = responseStatus.Data.FirstOrDefault(s => s.IdEstado == (int)Estados.RECHAZADA);

                if (statusRechazado == null)
                {
                    MessageBox.Show("El estado 'Rechazada' no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var response = await _requisaServices.RechazarRequisa(numeroRequisa, statusRechazado, descripcionRequisaRechazada);

                if (!response.Data || !response.Success)
                {
                    MessageBox.Show("Error al rechazar la requisa: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Requisa rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                await cargarRequisasTable();
                _numeroRequisaSeleccionada = string.Empty; // Limpiar la selección después de rechazar
            }
            catch { 
                MessageBox.Show("Error al rechazar la requisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private async Task cargarRequisasTable()
        {
            var response = await _requisaServices.ObtenerRequisasagrupadasPorEstado();


            if (!response.Success || response.Data == null)
            {
                MessageBox.Show("Error al cargar las requisas: " + response.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var listOrderByDescAmount = response.Data.OrderByDescending(
                    r => r.costoTotal
                );

            var dt = new DataTable();
            dt.Columns.Add("numeroRequisaColumn", typeof(string));
            dt.Columns.Add("descripcionRequisaColumn", typeof(string));
            dt.Columns.Add("usuarioColumn", typeof(string));
            dt.Columns.Add("cantidadAjusteColumn", typeof(int));
            dt.Columns.Add("costoTotalColumn", typeof(string));
            dt.Columns.Add("estadoRequisaColumn", typeof(Object));
            dt.Columns.Add("viewDatalleColumn", typeof(string));
            dt.Columns.Add("fechaCreacionColumn", typeof(DateTime));
            foreach (var item in  listOrderByDescAmount)
            {
                CultureInfo cultura = new CultureInfo("es-NI");

                var amountFormatted = item.costoTotal.ToString("N2", cultura);

                dt.Rows.Add(item.CodigoRequisa, item.descripcionRequisa, item.Usuario, item.cantidadAjuste, amountFormatted, item.EstadoRequisa, "Revisar", item.FechaCreacion.Date);
            }

            CultureInfo culturaSum = new CultureInfo("es-NI");

            var SumCantidadAjuste = response.Data.Sum(row => row.cantidadAjuste);
            var SumCostoTotal = response.Data.Sum(row => row.costoTotal);

            DataRow dtRow = dt.Rows.Add("Total", "", "", SumCantidadAjuste, SumCostoTotal.ToString("N2", culturaSum), null);
            
            int rowIndex = dt.Rows.IndexOf(dtRow);
            
            table.DataSource = null;
            table.AutoGenerateColumns = false;
            table.DataSource = dt;
            
            table.Rows[rowIndex].DefaultCellStyle.Font = new Font(table.DefaultCellStyle.Font, FontStyle.Bold);
        }
        
        private async Task<bool> validateState(int id)
        {
            bool isValid = false;
            var responseServices = await _requisaServices.obtenerEstadosRequisasPorIdRequisa(_numeroRequisaSeleccionada);
            if (!responseServices.Success || responseServices.Data == null)
            {
                MessageBox.Show("Error al validar el estado: " + responseServices.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var estadosRequisa = responseServices.Data;

            var isRequisaRechazada = estadosRequisa.Any(e => e.Estado.IdEstado == (int)Estados.RECHAZADA);

            if (isRequisaRechazada)
            {
                MessageBox.Show("No se pueden agregar más estados a una requisa rechazada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #region Validación de estados según el rol y estado actual de la requisa

            switch (id)
            {
                case (int)Estados.PENDIENTE_A_REVISION:
                    #region Validación de estado 'Pendiente a Revisión'
                    var stateRequirePendiente = new[] { (int)Estados.CREADA };
                    var statePendienteValidation = stateRequirePendiente.All(stateRequired =>
                        estadosRequisa.Any(e => e.Estado.IdEstado == stateRequired)
                    );

                    if (statePendienteValidation && UserSession.Instance.IdRol == (int)UserRol.Analista)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar el estado 'Pendiente a Revisión' porque la requisa no está en estado 'Creada' o no tienes los permisos necesarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    break;
                case (int)Estados.PENDIENTE_A_APROBACION_1:
                    #region Validación de estado 'Pendiente a Aprobación 1'
                    var stateRequireAprobacion1 = new[] { (int)Estados.CREADA, (int)Estados.PENDIENTE_A_REVISION };
                    var stateAprobacion1Validation = stateRequireAprobacion1.All(stateRequired =>
                        estadosRequisa.Any(e => e.Estado.IdEstado == stateRequired)
                    );

                    if (stateAprobacion1Validation && UserSession.Instance.IdRol == (int)UserRol.GereteDeOperaciones)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar el estado 'Pendiente a Aprobación 1' porque la requisa no tiene los estados: 'Creado', 'Pendiente a Revisión' ,'Aprobación 1'. O no tienes los permisos necesarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    break;
                case (int)Estados.PENDIENTE_A_APROBACION_2:
                    #region Validación de estado 'Pendiente a Aprobación 2'

                    var stateRequireAprobacion2 = new[] { (int)Estados.CREADA, (int)Estados.PENDIENTE_A_REVISION, (int)Estados.PENDIENTE_A_APROBACION_1 };
                    var stateAprobacion2Validation = stateRequireAprobacion2.All(stateRequired =>
                        estadosRequisa.Any(e => e.Estado.IdEstado == stateRequired)
                    );

                    if (stateAprobacion2Validation && UserSession.Instance.IdRol == (int)UserRol.GereteDeRepuesto)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar el estado 'Pendiente a Aprobación 2' porque la requisa no tiene los estados: 'Creado', 'Pendiente a Revisión', 'Aprobación 1'. O no tienes los permisos necesarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    break;
                case (int)Estados.PENDIENTE_A_APLICAR:
                    #region Validación de estado 'Pendiente a Aplicar'

                    var stateRequirePendienteAplicar = new[] { (int)Estados.CREADA, (int)Estados.PENDIENTE_A_REVISION, (int)Estados.PENDIENTE_A_APROBACION_1, (int)Estados.PENDIENTE_A_APROBACION_2 };
                    var statePendienteAplicar = stateRequirePendienteAplicar.All(stateRequired =>
                        estadosRequisa.Any(e => e.Estado.IdEstado == stateRequired)
                    );

                    if (statePendienteAplicar && UserSession.Instance.IdRol == (int)UserRol.Analista)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar el estado 'Pendiente a Aplicar' porque la requisa no tiene los estados: 'Creado', 'Pendiente a Revisión', 'Aprobación 1', 'Aprobación 2'. O no tienes los permisos necesarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    break;
                case (int)Estados.APLICADA:
                    #region Validación de estado 'Aplicado'

                    var stateRequireAplicado = new[] { (int)Estados.CREADA, (int)Estados.PENDIENTE_A_REVISION, (int)Estados.PENDIENTE_A_APROBACION_1, (int)Estados.PENDIENTE_A_APROBACION_2, (int)Estados.PENDIENTE_A_APLICAR };
                    var stateAplicado = stateRequireAplicado.All(stateRequired =>
                        estadosRequisa.Any(e => e.Estado.IdEstado == stateRequired)
                    );

                    if (stateAplicado && UserSession.Instance.IdRol == (int)UserRol.Analista)
                    {
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar el estado 'Aplicado' porque la requisa no tiene los estados: 'Creado', 'Pendiente a Revisión', 'Aprobación 1', 'Aprobación 2', 'Pendiente a Aplicar'. O no tienes los permisos necesarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    break;
                default:
                    break;
            }

            #endregion

            return isValid;
        }

    }
}
