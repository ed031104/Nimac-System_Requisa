namespace CapaVista
{
    partial class Gestion_Usuarios
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
            table = new DataGridView();
            idUsuarioColumn = new DataGridViewTextBoxColumn();
            nombreColumn = new DataGridViewTextBoxColumn();
            emailColum = new DataGridViewTextBoxColumn();
            contrasenaColumn = new DataGridViewTextBoxColumn();
            creadoEnColumn = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            FechaCreacionInput = new TextBox();
            CorreoInput = new TextBox();
            ContraseñaInput = new TextBox();
            NombreInput = new TextBox();
            IdInput = new TextBox();
            crearButton = new Button();
            eliminarButton = new Button();
            editarButton = new Button();
            label7 = new Label();
            nombreSearchInput = new TextBox();
            MostrarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { idUsuarioColumn, nombreColumn, emailColum, contrasenaColumn, creadoEnColumn });
            table.Location = new Point(12, 237);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(974, 259);
            table.TabIndex = 0;
            table.CellClick += table_CellClick;
            // 
            // idUsuarioColumn
            // 
            idUsuarioColumn.DataPropertyName = "idUsuarioColumn";
            idUsuarioColumn.HeaderText = "Id Usuario";
            idUsuarioColumn.MinimumWidth = 6;
            idUsuarioColumn.Name = "idUsuarioColumn";
            idUsuarioColumn.ReadOnly = true;
            idUsuarioColumn.Width = 125;
            // 
            // nombreColumn
            // 
            nombreColumn.DataPropertyName = "nombreColumn";
            nombreColumn.HeaderText = "Nombre";
            nombreColumn.MinimumWidth = 6;
            nombreColumn.Name = "nombreColumn";
            nombreColumn.ReadOnly = true;
            nombreColumn.Width = 125;
            // 
            // emailColum
            // 
            emailColum.DataPropertyName = "emailColum";
            emailColum.HeaderText = "Correo Electrónico";
            emailColum.MinimumWidth = 6;
            emailColum.Name = "emailColum";
            emailColum.ReadOnly = true;
            emailColum.Width = 125;
            // 
            // contrasenaColumn
            // 
            contrasenaColumn.DataPropertyName = "contrasenaColumn";
            contrasenaColumn.HeaderText = "Contraseña";
            contrasenaColumn.MinimumWidth = 6;
            contrasenaColumn.Name = "contrasenaColumn";
            contrasenaColumn.ReadOnly = true;
            contrasenaColumn.Width = 125;
            // 
            // creadoEnColumn
            // 
            creadoEnColumn.DataPropertyName = "creadoEnColumn";
            creadoEnColumn.HeaderText = "Fecha de creación";
            creadoEnColumn.MinimumWidth = 6;
            creadoEnColumn.Name = "creadoEnColumn";
            creadoEnColumn.ReadOnly = true;
            creadoEnColumn.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(FechaCreacionInput);
            groupBox1.Controls.Add(CorreoInput);
            groupBox1.Controls.Add(ContraseñaInput);
            groupBox1.Controls.Add(NombreInput);
            groupBox1.Controls.Add(IdInput);
            groupBox1.Location = new Point(21, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(965, 151);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(665, 53);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 10;
            label5.Text = "Creado en:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 108);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 9;
            label4.Text = "Correo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 50);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 8;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 111);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 7;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 50);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 6;
            label1.Text = "Id:";
            // 
            // FechaCreacionInput
            // 
            FechaCreacionInput.Enabled = false;
            FechaCreacionInput.Location = new Point(765, 50);
            FechaCreacionInput.Name = "FechaCreacionInput";
            FechaCreacionInput.Size = new Size(125, 27);
            FechaCreacionInput.TabIndex = 4;
            // 
            // CorreoInput
            // 
            CorreoInput.Location = new Point(440, 105);
            CorreoInput.Name = "CorreoInput";
            CorreoInput.Size = new Size(125, 27);
            CorreoInput.TabIndex = 3;
            // 
            // ContraseñaInput
            // 
            ContraseñaInput.Location = new Point(440, 50);
            ContraseñaInput.Name = "ContraseñaInput";
            ContraseñaInput.Size = new Size(125, 27);
            ContraseñaInput.TabIndex = 2;
            // 
            // NombreInput
            // 
            NombreInput.Location = new Point(103, 104);
            NombreInput.Name = "NombreInput";
            NombreInput.Size = new Size(125, 27);
            NombreInput.TabIndex = 1;
            // 
            // IdInput
            // 
            IdInput.Enabled = false;
            IdInput.Location = new Point(103, 50);
            IdInput.Name = "IdInput";
            IdInput.Size = new Size(125, 27);
            IdInput.TabIndex = 0;
            // 
            // crearButton
            // 
            crearButton.Location = new Point(642, 182);
            crearButton.Name = "crearButton";
            crearButton.Size = new Size(94, 29);
            crearButton.TabIndex = 2;
            crearButton.Text = "Crear";
            crearButton.UseVisualStyleBackColor = true;
            crearButton.Click += crearButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(892, 182);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(774, 182);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 4;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 187);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 13;
            label7.Text = "Nombre:";
            // 
            // nombreSearchInput
            // 
            nombreSearchInput.Location = new Point(109, 183);
            nombreSearchInput.Name = "nombreSearchInput";
            nombreSearchInput.Size = new Size(221, 27);
            nombreSearchInput.TabIndex = 12;
            nombreSearchInput.KeyDown += nombreSearchInput_KeyDown;
            // 
            // MostrarButton
            // 
            MostrarButton.Location = new Point(384, 182);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 14;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            MostrarButton.Click += MostrarButton_Click;
            // 
            // Gestion_Usuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 521);
            Controls.Add(MostrarButton);
            Controls.Add(label7);
            Controls.Add(nombreSearchInput);
            Controls.Add(editarButton);
            Controls.Add(eliminarButton);
            Controls.Add(crearButton);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "Gestion_Usuarios";
            Text = "Gestion_Usuarios";
            Load += Gestion_Usuarios_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox FechaCreacionInput;
        private TextBox CorreoInput;
        private TextBox ContraseñaInput;
        private TextBox NombreInput;
        private TextBox IdInput;
        private Button crearButton;
        private Button eliminarButton;
        private Button editarButton;
        private Label label5;
        private Label label4;
        private Label label7;
        private TextBox nombreSearchInput;
        private Button MostrarButton;
        private DataGridViewTextBoxColumn idUsuarioColumn;
        private DataGridViewTextBoxColumn nombreColumn;
        private DataGridViewTextBoxColumn emailColum;
        private DataGridViewTextBoxColumn contrasenaColumn;
        private DataGridViewTextBoxColumn creadoEnColumn;
    }
}