using CapaVista.utils;
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
    public partial class Gestion_Usuarios : Form
    {
        private readonly UsuarioServices _usuarioServices;

        public Gestion_Usuarios()
        {
            InitializeComponent();
            _usuarioServices = new UsuarioServices();
        }

        private async void MostrarButton_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MostrarButton.Visible = false;
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdInput.Text))
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }

            var idUsuario = Convert.ToInt32(IdInput.Text.Trim());
            var response = await _usuarioServices.EliminarUsuario(idUsuario);

            if (!response.Success)
            {
                MessageBox.Show($"Error al eliminar el usuario: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Usuario eliminado correctamente.");

            await LoadDataAsync();
            limpiarInput();
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    IdInput.Text = table.Rows[e.RowIndex].Cells["idUsuarioColumn"].Value.ToString() ?? "";
                    NombreInput.Text = table.Rows[e.RowIndex].Cells["nombreColumn"].Value.ToString() ?? "";
                    ContraseñaInput.Text = table.Rows[e.RowIndex].Cells["contrasenaColumn"].Value.ToString() ?? "";
                    CorreoInput.Text = table.Rows[e.RowIndex].Cells["emailColum"].Value.ToString() ?? "";
                    FechaCreacionInput.Text = table.Rows[e.RowIndex].Cells["creadoEnColumn"].Value.ToString() ?? "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar la fila: {ex.Message}");
                }
            }
        }

        private async void Gestion_Usuarios_Load(object sender, EventArgs e)
        {
            MostrarButton.Visible = false;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var response = await _usuarioServices.ObtenerUsuarios();

            if (!response.Success)
            {
                MessageBox.Show($"Error al cargar las casas: {response.ErrorMessage}");
                return;
            }
            table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
            table.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
            table.DataSource = response.Data.Select(c => new
            {
                idUsuarioColumn = c.Id,
                nombreColumn = c.Nombre,
                contrasenaColumn = c.Contrasena,
                emailColum = c.CorreoElectronico,
                creadoEnColumn = c.CreadoEn.ToString("dd/MM/yyyy")
            }).ToList();
        }

        private void limpiarInput()
        {
            IdInput.Clear();
            NombreInput.Clear();
            ContraseñaInput.Clear();
            CorreoInput.Clear();
            FechaCreacionInput.Clear();
        }

        private async void nombreSearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(nombreSearchInput.Text))
                {
                    MessageBox.Show("Por favor, ingrese un código de casa para buscar.");
                    return;
                }
                var codigoCasa = nombreSearchInput.Text.Trim();

                var response = await _usuarioServices.ObtenerUsuarioPorCorreoONombre(email: codigoCasa, nombre: codigoCasa);

                if (!response.Success)
                {
                    MessageBox.Show($"Error al buscar la casa: {response.ErrorMessage}");
                    return;
                }
                if (response.Data == null)
                {
                    MessageBox.Show("No se encontró la casa con el código proporcionado.");
                    return;
                }
                table.DataSource = null; // Limpiar la tabla antes de cargar nuevos datos
                table.DataSource = response.Data.Select(c => new
                {
                    idUsuarioColumn = c.Id,
                    nombreColumn = c.Nombre,
                    emailColum = c.CorreoElectronico,
                    contrasenaColumn = c.Contrasena,
                    creadoEnColumn = c.CreadoEn.ToString("dd/MM/yyyy")
                }).ToList();

                MostrarButton.Visible = true;
            }
        }

        private async void crearButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombreInput.Text) || string.IsNullOrEmpty(CorreoInput.Text) || string.IsNullOrEmpty(ContraseñaInput.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!ValidatorInput.IsValidEmail(CorreoInput.Text)) { 
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            var Usuario = new Modelos.login.Usuario.Builder()
                .SetNombre(NombreInput.Text)
                .SetCorreoElectronico(CorreoInput.Text)
                .SetContrasena(ContraseñaInput.Text)
                .Build();
            var response = await _usuarioServices.AgregarUsuario(Usuario);
            
            if (!response.Success)
            {
                MessageBox.Show($"Error al crear el usuario: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Usuario creado correctamente.");
            await LoadDataAsync();
            limpiarInput();
        }

        private async void editarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombreInput.Text) || string.IsNullOrEmpty(CorreoInput.Text) || string.IsNullOrEmpty(ContraseñaInput.Text) || string.IsNullOrEmpty(IdInput.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!ValidatorInput.IsValidEmail(CorreoInput.Text))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            var Usuario = new Modelos.login.Usuario.Builder()
                .SetId(Convert.ToInt32(IdInput.Text))
                .SetNombre(NombreInput.Text)
                .SetCorreoElectronico(CorreoInput.Text)
                .SetContrasena(ContraseñaInput.Text)
                .Build();
            var response = await _usuarioServices.ActualizarUsuario(Usuario);

            if (!response.Success)
            {
                MessageBox.Show($"Error al crear el usuario: {response.ErrorMessage}");
                return;
            }
            MessageBox.Show("Usuario creado correctamente.");
            await LoadDataAsync();
            limpiarInput();
        }
    }
}
