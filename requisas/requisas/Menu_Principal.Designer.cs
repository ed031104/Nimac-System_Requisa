namespace CapaVista
{
    partial class Menu_Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Principal));
            menuStrip = new MenuStrip();
            editMenu = new ToolStripMenuItem();
            nUEVAToolStripMenuItem = new ToolStripMenuItem();
            gESTIONDEREQUISAToolStripMenuItem = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            statusBarToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            aignarRolButton = new ToolStripMenuItem();
            rEPORTESToolStripMenuItem = new ToolStripMenuItem();
            requisaMenuButton = new ToolStripMenuItem();
            requisasCompletadasToolStripMenuItem = new ToolStripMenuItem();
            ajustesRequisaToolStripMenuItem = new ToolStripMenuItem();
            cantidadDeRequisasPorEstadoToolStripMenuItem = new ToolStripMenuItem();
            parteToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            gestionarToolStripMenuItem = new ToolStripMenuItem();
            reporteDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            oPCIONESToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            label1 = new Label();
            usuarioText = new Label();
            notifyIcon1 = new NotifyIcon(components);
            revisionTimer = new System.Windows.Forms.Timer(components);
            detallesDeRequisaPorEstadoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { editMenu, viewMenu, helpMenu, rEPORTESToolStripMenuItem, usuariosToolStripMenuItem, oPCIONESToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(911, 34);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // editMenu
            // 
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { nUEVAToolStripMenuItem, gESTIONDEREQUISAToolStripMenuItem });
            editMenu.Image = (Image)resources.GetObject("editMenu.Image");
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(115, 28);
            editMenu.Text = "REQUISAS";
            // 
            // nUEVAToolStripMenuItem
            // 
            nUEVAToolStripMenuItem.Image = (Image)resources.GetObject("nUEVAToolStripMenuItem.Image");
            nUEVAToolStripMenuItem.Name = "nUEVAToolStripMenuItem";
            nUEVAToolStripMenuItem.Size = new Size(239, 26);
            nUEVAToolStripMenuItem.Text = "NUEVA";
            nUEVAToolStripMenuItem.Click += nUEVAToolStripMenuItem_Click;
            // 
            // gESTIONDEREQUISAToolStripMenuItem
            // 
            gESTIONDEREQUISAToolStripMenuItem.Name = "gESTIONDEREQUISAToolStripMenuItem";
            gESTIONDEREQUISAToolStripMenuItem.Size = new Size(239, 26);
            gESTIONDEREQUISAToolStripMenuItem.Text = "GESTION DE REQUISA";
            gESTIONDEREQUISAToolStripMenuItem.Click += gESTIONDEREQUISAToolStripMenuItem_Click;
            // 
            // viewMenu
            // 
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { statusBarToolStripMenuItem });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(64, 28);
            viewMenu.Text = "PARTE";
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new Size(283, 26);
            statusBarToolStripMenuItem.Text = "Gestion Parte Sucursal y Casa";
            statusBarToolStripMenuItem.Click += StatusBarToolStripMenuItem_Click;
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { aignarRolButton });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(128, 28);
            helpMenu.Text = "AUTORIZACIÓN";
            // 
            // aignarRolButton
            // 
            aignarRolButton.Name = "aignarRolButton";
            aignarRolButton.ShortcutKeys = Keys.Control | Keys.F1;
            aignarRolButton.Size = new Size(291, 26);
            aignarRolButton.Text = "Asignar Rol a Usuario";
            aignarRolButton.Click += aignarRolButton_Click;
            // 
            // rEPORTESToolStripMenuItem
            // 
            rEPORTESToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { requisaMenuButton, parteToolStripMenuItem });
            rEPORTESToolStripMenuItem.Name = "rEPORTESToolStripMenuItem";
            rEPORTESToolStripMenuItem.Size = new Size(91, 28);
            rEPORTESToolStripMenuItem.Text = "REPORTES";
            rEPORTESToolStripMenuItem.ToolTipText = "2 - notificaciones";
            // 
            // requisaMenuButton
            // 
            requisaMenuButton.DropDownItems.AddRange(new ToolStripItem[] { requisasCompletadasToolStripMenuItem, ajustesRequisaToolStripMenuItem, cantidadDeRequisasPorEstadoToolStripMenuItem, detallesDeRequisaPorEstadoToolStripMenuItem });
            requisaMenuButton.Name = "requisaMenuButton";
            requisaMenuButton.Size = new Size(224, 26);
            requisaMenuButton.Text = "Requisa";
            // 
            // requisasCompletadasToolStripMenuItem
            // 
            requisasCompletadasToolStripMenuItem.Name = "requisasCompletadasToolStripMenuItem";
            requisasCompletadasToolStripMenuItem.Size = new Size(311, 26);
            requisasCompletadasToolStripMenuItem.Text = "Requisas Completadas";
            requisasCompletadasToolStripMenuItem.Click += requisasCompletadasToolStripMenuItem_Click;
            // 
            // ajustesRequisaToolStripMenuItem
            // 
            ajustesRequisaToolStripMenuItem.Name = "ajustesRequisaToolStripMenuItem";
            ajustesRequisaToolStripMenuItem.Size = new Size(311, 26);
            ajustesRequisaToolStripMenuItem.Text = "Ajustes Requisa";
            ajustesRequisaToolStripMenuItem.Click += ajustesRequisaToolStripMenuItem_Click;
            // 
            // cantidadDeRequisasPorEstadoToolStripMenuItem
            // 
            cantidadDeRequisasPorEstadoToolStripMenuItem.Name = "cantidadDeRequisasPorEstadoToolStripMenuItem";
            cantidadDeRequisasPorEstadoToolStripMenuItem.Size = new Size(311, 26);
            cantidadDeRequisasPorEstadoToolStripMenuItem.Text = "Cantidad de Requisas por Estado";
            cantidadDeRequisasPorEstadoToolStripMenuItem.Click += cantidadDeRequisasPorEstadoToolStripMenuItem_Click;
            // 
            // parteToolStripMenuItem
            // 
            parteToolStripMenuItem.Name = "parteToolStripMenuItem";
            parteToolStripMenuItem.Size = new Size(224, 26);
            parteToolStripMenuItem.Text = "Parte";
            parteToolStripMenuItem.Click += parteToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarToolStripMenuItem, reporteDeUsuariosToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(93, 28);
            usuariosToolStripMenuItem.Text = "USUARIOS";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // gestionarToolStripMenuItem
            // 
            gestionarToolStripMenuItem.Name = "gestionarToolStripMenuItem";
            gestionarToolStripMenuItem.Size = new Size(224, 26);
            gestionarToolStripMenuItem.Text = "Gestionar";
            gestionarToolStripMenuItem.Click += gestionarToolStripMenuItem_Click;
            // 
            // reporteDeUsuariosToolStripMenuItem
            // 
            reporteDeUsuariosToolStripMenuItem.Name = "reporteDeUsuariosToolStripMenuItem";
            reporteDeUsuariosToolStripMenuItem.Size = new Size(224, 26);
            reporteDeUsuariosToolStripMenuItem.Text = "Reporte de usuarios";
            reporteDeUsuariosToolStripMenuItem.Click += reporteDeUsuariosToolStripMenuItem_Click;
            // 
            // oPCIONESToolStripMenuItem
            // 
            oPCIONESToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem });
            oPCIONESToolStripMenuItem.Name = "oPCIONESToolStripMenuItem";
            oPCIONESToolStripMenuItem.Size = new Size(93, 28);
            oPCIONESToolStripMenuItem.Text = "OPCIONES";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(177, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 2;
            label1.Text = "Usuario:";
            // 
            // usuarioText
            // 
            usuarioText.AutoSize = true;
            usuarioText.Location = new Point(88, 48);
            usuarioText.Name = "usuarioText";
            usuarioText.Size = new Size(51, 20);
            usuarioText.TabIndex = 3;
            usuarioText.Text = "admin";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // detallesDeRequisaPorEstadoToolStripMenuItem
            // 
            detallesDeRequisaPorEstadoToolStripMenuItem.Name = "detallesDeRequisaPorEstadoToolStripMenuItem";
            detallesDeRequisaPorEstadoToolStripMenuItem.Size = new Size(311, 26);
            detallesDeRequisaPorEstadoToolStripMenuItem.Text = "Detalles de Requisa por Estado";
            detallesDeRequisaPorEstadoToolStripMenuItem.Click += detallesDeRequisaPorEstadoToolStripMenuItem_Click;
            // 
            // Menu_Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(911, 697);
            Controls.Add(usuarioText);
            Controls.Add(label1);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(5);
            Name = "Menu_Principal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NIMAC";
            WindowState = FormWindowState.Maximized;
            FormClosing += Menu_Principal_FormClosing;
            Load += Menu_Principal_Load_1;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem aignarRolButton;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem rEPORTESToolStripMenuItem;
        private ToolStripMenuItem nUEVAToolStripMenuItem;
        private ToolStripMenuItem requisaMenuButton;
        private Label label1;
        private Label usuarioText;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem gestionarToolStripMenuItem;
        private ToolStripMenuItem oPCIONESToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Timer revisionTimer;
        private ToolStripMenuItem reporteDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem gESTIONDEREQUISAToolStripMenuItem;
        private ToolStripMenuItem requisasCompletadasToolStripMenuItem;
        private ToolStripMenuItem ajustesRequisaToolStripMenuItem;
        private ToolStripMenuItem parteToolStripMenuItem;
        private ToolStripMenuItem cantidadDeRequisasPorEstadoToolStripMenuItem;
        private ToolStripMenuItem detallesDeRequisaPorEstadoToolStripMenuItem;
    }
}



