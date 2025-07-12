namespace CapaVista
{
    partial class AsignaciónUsuarioRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label4 = new Label();
            IdUsuarioRolInput = new TextBox();
            MostrarButton = new Button();
            editarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            label3 = new Label();
            label2 = new Label();
            table = new DataGridView();
            rolComboBox = new ComboBox();
            usuarioComboBox = new ComboBox();
            label1 = new Label();
            nombreSearchInput = new TextBox();
            fechaCreacionColumn = new DataGridViewTextBoxColumn();
            usuarioColumn = new DataGridViewTextBoxColumn();
            rolColumn = new DataGridViewTextBoxColumn();
            idRolUsuarioColumn = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(IdUsuarioRolInput);
            groupBox1.Controls.Add(MostrarButton);
            groupBox1.Controls.Add(editarButton);
            groupBox1.Controls.Add(eliminarButton);
            groupBox1.Controls.Add(agregarButton);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(table);
            groupBox1.Controls.Add(rolComboBox);
            groupBox1.Controls.Add(usuarioComboBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nombreSearchInput);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asignación de roles a usuarios";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(516, 17);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 17;
            label4.Text = "Id:";
            // 
            // IdUsuarioRolInput
            // 
            IdUsuarioRolInput.Location = new Point(591, 17);
            IdUsuarioRolInput.Name = "IdUsuarioRolInput";
            IdUsuarioRolInput.Size = new Size(151, 27);
            IdUsuarioRolInput.TabIndex = 16;
            // 
            // MostrarButton
            // 
            MostrarButton.Location = new Point(369, 163);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 15;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            MostrarButton.Click += MostrarButton_Click;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(247, 163);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 9;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(131, 163);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 8;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(21, 163);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(94, 29);
            agregarButton.TabIndex = 7;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(544, 134);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 6;
            label3.Text = "Rol:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(516, 69);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 5;
            label2.Text = "Usuario:";
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { fechaCreacionColumn, usuarioColumn, rolColumn, idRolUsuarioColumn });
            table.Location = new Point(21, 213);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(721, 188);
            table.TabIndex = 4;
            table.CellClick += table_CellClick;
            // 
            // rolComboBox
            // 
            rolComboBox.FormattingEnabled = true;
            rolComboBox.Location = new Point(591, 131);
            rolComboBox.Name = "rolComboBox";
            rolComboBox.Size = new Size(151, 28);
            rolComboBox.TabIndex = 3;
            // 
            // usuarioComboBox
            // 
            usuarioComboBox.FormattingEnabled = true;
            usuarioComboBox.Location = new Point(591, 65);
            usuarioComboBox.Name = "usuarioComboBox";
            usuarioComboBox.Size = new Size(151, 28);
            usuarioComboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 65);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 1;
            label1.Text = "Buscar por Nombre";
            // 
            // nombreSearchInput
            // 
            nombreSearchInput.Location = new Point(21, 100);
            nombreSearchInput.Name = "nombreSearchInput";
            nombreSearchInput.Size = new Size(221, 27);
            nombreSearchInput.TabIndex = 0;
            nombreSearchInput.KeyDown += nombreSearchInput_KeyDown;
            // 
            // fechaCreacionColumn
            // 
            fechaCreacionColumn.DataPropertyName = "fechaCreacionColumn";
            fechaCreacionColumn.HeaderText = "Fecha de creación";
            fechaCreacionColumn.MinimumWidth = 6;
            fechaCreacionColumn.Name = "fechaCreacionColumn";
            fechaCreacionColumn.Width = 125;
            // 
            // usuarioColumn
            // 
            usuarioColumn.DataPropertyName = "usuarioColumn";
            usuarioColumn.HeaderText = "Usuario";
            usuarioColumn.MinimumWidth = 6;
            usuarioColumn.Name = "usuarioColumn";
            usuarioColumn.Width = 125;
            // 
            // rolColumn
            // 
            rolColumn.DataPropertyName = "rolColumn";
            rolColumn.HeaderText = "Rol";
            rolColumn.MinimumWidth = 6;
            rolColumn.Name = "rolColumn";
            rolColumn.Width = 125;
            // 
            // idRolUsuarioColumn
            // 
            idRolUsuarioColumn.DataPropertyName = "idRolUsuarioColumn";
            idRolUsuarioColumn.HeaderText = "Id";
            idRolUsuarioColumn.MinimumWidth = 6;
            idRolUsuarioColumn.Name = "idRolUsuarioColumn";
            idRolUsuarioColumn.ReadOnly = true;
            idRolUsuarioColumn.Width = 125;
            // 
            // AsignaciónUsuarioRoles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "AsignaciónUsuarioRoles";
            Text = "AsignaciónUsuarioRoles";
            Load += AsignaciónUsuarioRoles_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox nombreSearchInput;
        private Label label3;
        private Label label2;
        private DataGridView table;
        private ComboBox rolComboBox;
        private ComboBox usuarioComboBox;
        private Button editarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private Button MostrarButton;
        private Label label4;
        private TextBox IdUsuarioRolInput;
        private DataGridViewTextBoxColumn fechaCreacionColumn;
        private DataGridViewTextBoxColumn usuarioColumn;
        private DataGridViewTextBoxColumn rolColumn;
        private DataGridViewTextBoxColumn idRolUsuarioColumn;
    }
}