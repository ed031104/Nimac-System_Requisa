using Modelos.login;
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
    public partial class AsignaciónUsuarioRoles : Form
    {

        private UsuarioServices _usuarioServices;
        private RolServices _rolServices;
        private UsuarioRolServices _usuarioRolServices;

        public AsignaciónUsuarioRoles()
        {
            InitializeComponent();
            _usuarioServices = new UsuarioServices();
            _rolServices = new RolServices();
            _usuarioRolServices = new UsuarioRolServices();
        }

        private async void nombreSearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var nombre = nombreSearchInput.Text.Trim();
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(nombre))
                    {
                        MessageBox.Show("Debe ingresar un nombre o correo para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var response = await _usuarioServices.ObtenerUsuarioPorCorreoONombre(nombre, nombre);
                    if (!response.Success || response.Data == null || !response.Data.Any())
                    {
                        MessageBox.Show("No se encontró ningún usuario con ese nombre o correo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    usuarioComboBox.DataSource = response.Data.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void editarButton_Click(object sender, EventArgs e)
        {
            try {
                var usuarioSeleccionado = usuarioComboBox.SelectedItem as Usuario;
                var rolSeleccionado = rolComboBox.SelectedItem as Role;
                
                if (usuarioSeleccionado == null || rolSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario y un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var usuarioRol = new UsuarioRol.Builder()
                    .SetIdUsuarioRol(Convert.ToInt32(IdUsuarioRolInput.Text.Trim()))
                    .SetUsuario(usuarioSeleccionado)
                    .SetRol(rolSeleccionado)
                    .Build();
                var response = await _usuarioRolServices.ActualizarRolDeUsuario(usuarioRol);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al actualizar el rol: {response.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Rol actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(); // Recargar los datos después de la actualización
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var idUsuarioRol = IdUsuarioRolInput.Text.Trim();
                if (string.IsNullOrWhiteSpace(idUsuarioRol))
                {
                    MessageBox.Show("Debe seleccionar un usuario y un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var response = await _usuarioRolServices.EliminarRolDeUsuario(Convert.ToInt32(idUsuarioRol));
                if (!response.Success)
                {
                    MessageBox.Show($"Error al eliminar el rol: {response.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(); // Recargar los datos después de la eliminación
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioSeleccionado = usuarioComboBox.SelectedItem as Usuario;
                var rolSeleccionado = rolComboBox.SelectedItem as Role;
                if (usuarioSeleccionado == null || rolSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario y un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var usuarioRol = new UsuarioRol.Builder()
                    .SetUsuario(usuarioSeleccionado)
                    .SetRol(rolSeleccionado)
                    .Build();

                var response = await _usuarioRolServices.AsignarRolAUsuario(usuarioRol);
                if (!response.Success)
                {
                    MessageBox.Show($"Error al asignar el rol: {response.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Rol asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(); // Recargar los datos después de la asignación
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    usuarioComboBox.DataSource = null; // Limpiar el DataSource antes de asignar uno nuevo
                    usuarioComboBox.Items.Clear(); 
                    usuarioComboBox.Items.Add(table.Rows[e.RowIndex].Cells["usuarioColumn"].Value);
                    usuarioComboBox.SelectedIndex = 0; // Seleccionar el primer elemento

                    //rolComboBox.DataSource = null; // Limpiar el DataSource antes de asignar uno nuevo
                    //rolComboBox.Items.Clear();
                    //rolComboBox.Items.Add(table.Rows[e.RowIndex].Cells["rolColumn"].Value.ToString() ?? "");
                    //rolComboBox.SelectedIndex = 0; // Seleccionar el primer elemento

                    IdUsuarioRolInput.Text = table.Rows[e.RowIndex].Cells["idRolUsuarioColumn"].Value.ToString() ?? "";

                    MostrarButton.Visible = true; // Habilitar el botón Mostrar después de seleccionar una fila
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void AsignaciónUsuarioRoles_Load(object sender, EventArgs e)
        {
            try
            {
                IdUsuarioRolInput.Enabled = false;
                MostrarButton.Visible = false;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la asignación de roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataAsync()
        {
            var usuariosResponse = await _usuarioServices.ObtenerUsuarios();

            if (!usuariosResponse.Success || usuariosResponse.Data == null)
            {
                MessageBox.Show("Error al cargar los usuarios: " + usuariosResponse.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarioComboBox.DataSource = usuariosResponse.Data.ToList();

            var rolesResponse = await _rolServices.ObtenerRoles();

            if (!rolesResponse.Success || rolesResponse.Data == null)
            {
                MessageBox.Show("Error al cargar los roles: " + rolesResponse.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rolComboBox.DataSource = rolesResponse.Data.ToList();

            var response = await _usuarioRolServices.ObtenerUsuariosConRoles();

            if (!response.Success)
            {
                MessageBox.Show($"Error al cargar las casas: {response.ErrorMessage}");
                return;
            }
            table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
            table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
            table.DataSource = response.Data.Select(c => new
            {
                usuarioColumn = c.Usuario,
                rolColumn = c.Rol,
                fechaCreacionColumn = c.AsignadoEn.ToString("dd/MM/yyyy"),
                idRolUsuarioColumn = c.IdUsuarioRol
            }).ToList();
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false; // Deshabilitar el botón después de mostrar los datos
        }
    }
}
