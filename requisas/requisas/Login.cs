using CapaVista;
using CapaVista.Components;
using CapaVista.utils;
using Configuraciones;
using Dbo;
using Microsoft.Data.SqlClient;
using Modelos.login;
using Servicios;
using Servicios.login;
using Servicios.utils;

namespace requisas
{
    public partial class Login : Form
    {
        private Loading loading;
        private readonly LoginServices loginService = new LoginServices();

        public Login()
        {
            InitializeComponent();
        }

        int progreso = 0;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btningresar_Click(object sender, EventArgs e)
        {

            ingresarButton.Enabled = false; // Deshabilitar el botón de ingresar mientras se procesa la solicitud
            try
            {
                MostrarLoading(); // Mostrar el formulario de carga
                loading.SetProgress(0);

                string correo = correoInput.Text.Trim();
                string contrasena = contraseñaInput.Text.Trim();

                if (!ValidatorInput.IsValidEmail(correo))
                {
                    loading.SetProgress(100);
                    OcultarLoading(); 
                    MessageBox.Show("Correo electrónico no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
                {
                    loading.SetProgress(100);
                    OcultarLoading();
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var response = await loginService.isLogin(correo, contrasena);
                loading.SetProgress(30);
                if (!response.Success || !response.Data)
                {
                    OcultarLoading();
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si el inicio de sesión es exitoso, crear una sesión de usuario

                var usuarioRolService = new UsuarioRolServices();
                var usuarioBuscadoPorCorreo = await usuarioRolService.ObtenerUsuarioConRolesPorCorreo(correo);
                loading.SetProgress(60);
                if (!usuarioBuscadoPorCorreo.Success || usuarioBuscadoPorCorreo.Data == null)
                {
                    OcultarLoading();
                    MessageBox.Show(usuarioBuscadoPorCorreo.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserSession userSession = new UserSession.Builder()
                    .SetId(usuarioBuscadoPorCorreo.Data.Usuario.Id)
                    .SetNombreUsuario(usuarioBuscadoPorCorreo.Data.Usuario.Nombre)
                    .SetCorreo(usuarioBuscadoPorCorreo.Data.Usuario.CorreoElectronico)
                    .SetIdRol(usuarioBuscadoPorCorreo.Data.Rol.IdRole)
                    .SetRol(usuarioBuscadoPorCorreo.Data.Rol.NombreRol)
                    .Build();

                loading.SetProgress(100);
                OcultarLoading();
                MessageBox.Show("Bienvenido " + userSession.NombreUsuario, "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Menu_Principal nuevoFormulario = new Menu_Principal();
                this.Hide();

                nuevoFormulario.FormClosed += (s, args) => this.Show(); // Cerrar el formulario de inicio de sesión al cerrar el menú principal
                nuevoFormulario.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ingresarButton.Enabled = true; // Habilitar el botón de ingresar después de procesar la solicitud
                OcultarLoading();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación
            //  Application.Exit();
        }

        void MostrarLoading()
        {
            if (loading == null)
            {
                loading = new Loading();
                this.Controls.Add(loading);
                loading.BringToFront();
            }
        }

        private void OcultarLoading()
        {
            if (loading != null)
            {
                this.Controls.Remove(loading);
                loading.Dispose();
                loading = null;
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    progressBar1.Value = progreso;
        //    progreso += 5;
        //    if (progreso >progressBar1.Maximum)
        //    {
        //        timer1.Stop();
        //        progreso = 0;
        //        btningresar.Enabled = true;
        //    }
        //}
    }

}
