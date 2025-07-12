using Modelos;
using requisas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CapaVista
{
    public partial class Menu_Principal : Form
    {
        private int childFormNumber = 0;

        private Form currentChildForm = null;

        public Menu_Principal()
        {
            InitializeComponent();
        }

       

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void nUEVAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Cerrar el formulario actualmente abierto si existe
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            Nueva_Requisa m1 = new Nueva_Requisa();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;

        }

        private void irAReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            reporte1 ventana = new reporte1();
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.Size = new Size(1024, 768); // o ventana.WindowState = FormWindowState.Maximized;
            ventana.Show();

        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSession.Instance.CloseSession(); // Cierra la sesión del usuario actual
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSession.Instance.CloseSession(); // Cierra la sesión del usuario actual
            this.Close();
        }


        private void visibleModuleForRoleUser(int idRole)
        {
            userRole currentUserRole = (userRole)idRole;

            switch (currentUserRole)
            {
                case userRole.Administrador:
                    usuariosToolStripMenuItem.Visible = true;
                    editMenu.Visible = true;
                    viewMenu.Visible = true;
                    toolsMenu.Visible = true;
                    windowsMenu.Visible = true;
                    helpMenu.Visible = true;
                    rEPORTESToolStripMenuItem.Visible = true;
                    timerNotification();
                    break;
                case userRole.GereteDeRepuesto:
                    usuariosToolStripMenuItem.Visible = true;
                    editMenu.Visible = true;
                    viewMenu.Visible = true;
                    toolsMenu.Visible = true;
                    windowsMenu.Visible = true;
                    helpMenu.Visible = true;
                    rEPORTESToolStripMenuItem.Visible = true;
                    timerNotification();
                    break;
                case userRole.GereteDeOperaciones:
                    usuariosToolStripMenuItem.Visible = true;
                    editMenu.Visible = true;
                    viewMenu.Visible = true;
                    toolsMenu.Visible = true;
                    windowsMenu.Visible = true;
                    helpMenu.Visible = true;
                    rEPORTESToolStripMenuItem.Visible = true;
                    timerNotification();
                    break;
                case userRole.Auxiliar:
                    editMenu.Visible = true;
                    viewMenu.Visible = false;
                    usuariosToolStripMenuItem.Visible = false;
                    toolsMenu.Visible = false;
                    windowsMenu.Visible = false;
                    helpMenu.Visible = false;
                    rEPORTESToolStripMenuItem.Visible = false;
                    break;
                case userRole.Analista:
                    usuariosToolStripMenuItem.Visible = false;
                    editMenu.Visible = true;
                    viewMenu.Visible = false;
                    toolsMenu.Visible = false;
                    windowsMenu.Visible = false;
                    helpMenu.Visible = false;
                    rEPORTESToolStripMenuItem.Visible = true;
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

        private void Menu_Principal_Load_1(object sender, EventArgs e)
        {
            var rolUsuario = UserSession.Instance.Rol;
            usuarioText.Text = UserSession.Instance.NombreUsuario + " - " + UserSession.Instance.Rol;
            visibleModuleForRoleUser(UserSession.Instance.IdRol);
        }

        #region notificacion
        private void NotificacionButton_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Nuevo artículo";
            notifyIcon1.BalloonTipText = "Se ha cargado un nuevo PDF para revisión.";
            notifyIcon1.ShowBalloonTip(5000); // Milisegundos
        }

        private void timerNotification()
        {
            revisionTimer.Enabled = true; // Habilita el temporizador para verificar notificaciones periódicamente
            revisionTimer.Interval = 20000; // Intervalo de 1 minuto (60000 ms)
            revisionTimer.Tick += verifyNotificationRepoprt; // Asocia el evento Tick del temporizador
            revisionTimer.Start(); // Inicia el temporizador
        }

        // método para mostrar las notificaciones
        private void verifyNotificationRepoprt(Object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Nuevo artículo";
            notifyIcon1.BalloonTipText = "Se ha cargado un nuevo PDF para revisión.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info; // Info, Warning, Error
            notifyIcon1.ShowBalloonTip(5000); // Milisegundos

        }
        #endregion

        private async void reporteDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteUsuarios ventana = new ReporteUsuarios();
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.Size = new Size(1024, 768); // o ventana.WindowState = FormWindowState.Maximized
            ventana.ShowDialog(); // Muestra el formulario como un diálogo modal

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Cerrar el formulario actualmente abierto si existe
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            GestionCasa gesitonCasaView = new GestionCasa();
            gesitonCasaView.MdiParent = this;
            gesitonCasaView.Show();

            currentChildForm = gesitonCasaView;

        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            Gestion_Usuarios m1 = new Gestion_Usuarios();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;
        }

        private void aignarRolButton_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            AsignaciónUsuarioRoles m1 = new AsignaciónUsuarioRoles();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            GestionSucursal m1 = new GestionSucursal();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            GestionPartes m1 = new GestionPartes();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

            AsignacionParteSucursal m1 = new AsignacionParteSucursal();
            m1.MdiParent = this;
            m1.Show();

            currentChildForm = m1;
        }
    }
}
