﻿namespace CapaVista
{
    partial class GestionRequisaAjuste
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
            label7 = new Label();
            numeroRequisaInput = new TextBox();
            RechazarButton = new Button();
            agregarButton = new Button();
            groupBox1 = new GroupBox();
            label6 = new Label();
            estadoComboBox = new ComboBox();
            table = new DataGridView();
            numeroRequisaColumn = new DataGridViewTextBoxColumn();
            descripcionRequisaColumn = new DataGridViewTextBoxColumn();
            cantidadAjusteColumn = new DataGridViewTextBoxColumn();
            costoTotalColumn = new DataGridViewTextBoxColumn();
            estadoRequisaColumn = new DataGridViewTextBoxColumn();
            fechaCreacionColumn = new DataGridViewTextBoxColumn();
            diasDemoraColumn = new DataGridViewTextBoxColumn();
            usuarioColumn = new DataGridViewTextBoxColumn();
            viewDatalleColumn = new DataGridViewButtonColumn();
            filtroComboBox = new ComboBox();
            filtroEstadoComboBox = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 167);
            label7.Name = "label7";
            label7.Size = new Size(196, 20);
            label7.TabIndex = 28;
            label7.Text = "Buscar por Número Requisa:";
            // 
            // numeroRequisaInput
            // 
            numeroRequisaInput.Location = new Point(240, 164);
            numeroRequisaInput.Name = "numeroRequisaInput";
            numeroRequisaInput.Size = new Size(221, 27);
            numeroRequisaInput.TabIndex = 27;
            numeroRequisaInput.TextChanged += numeroRequisaInput_TextChanged;
            // 
            // RechazarButton
            // 
            RechazarButton.Location = new Point(1175, 50);
            RechazarButton.Name = "RechazarButton";
            RechazarButton.Size = new Size(94, 29);
            RechazarButton.TabIndex = 26;
            RechazarButton.Text = "Rechazar";
            RechazarButton.UseVisualStyleBackColor = true;
            RechazarButton.Click += RechazarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(1287, 50);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(94, 29);
            agregarButton.TabIndex = 24;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(estadoComboBox);
            groupBox1.Controls.Add(agregarButton);
            groupBox1.Controls.Add(RechazarButton);
            groupBox1.Location = new Point(32, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1387, 104);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestión de Requisa con Ajustes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 50);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 11;
            label6.Text = "Estado:";
            // 
            // estadoComboBox
            // 
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(93, 42);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(454, 28);
            estadoComboBox.TabIndex = 5;
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { numeroRequisaColumn, descripcionRequisaColumn, cantidadAjusteColumn, costoTotalColumn, estadoRequisaColumn, fechaCreacionColumn, diasDemoraColumn, usuarioColumn, viewDatalleColumn });
            table.Location = new Point(23, 217);
            table.Name = "table";
            table.ReadOnly = true;
            table.RowHeadersWidth = 51;
            table.Size = new Size(1396, 322);
            table.TabIndex = 22;
            table.CellClick += table_CellClick;
            table.CellContentClick += table_CellContentClick;
            // 
            // numeroRequisaColumn
            // 
            numeroRequisaColumn.DataPropertyName = "numeroRequisaColumn";
            numeroRequisaColumn.HeaderText = "Número de Requisa";
            numeroRequisaColumn.MinimumWidth = 6;
            numeroRequisaColumn.Name = "numeroRequisaColumn";
            numeroRequisaColumn.ReadOnly = true;
            numeroRequisaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            numeroRequisaColumn.Width = 132;
            // 
            // descripcionRequisaColumn
            // 
            descripcionRequisaColumn.DataPropertyName = "descripcionRequisaColumn";
            descripcionRequisaColumn.HeaderText = "Descripción Requisa";
            descripcionRequisaColumn.MinimumWidth = 6;
            descripcionRequisaColumn.Name = "descripcionRequisaColumn";
            descripcionRequisaColumn.ReadOnly = true;
            descripcionRequisaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            descripcionRequisaColumn.Width = 134;
            // 
            // cantidadAjusteColumn
            // 
            cantidadAjusteColumn.DataPropertyName = "cantidadAjusteColumn";
            cantidadAjusteColumn.HeaderText = "Cantidad de Items";
            cantidadAjusteColumn.MinimumWidth = 6;
            cantidadAjusteColumn.Name = "cantidadAjusteColumn";
            cantidadAjusteColumn.ReadOnly = true;
            cantidadAjusteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            cantidadAjusteColumn.Width = 90;
            // 
            // costoTotalColumn
            // 
            costoTotalColumn.DataPropertyName = "costoTotalColumn";
            costoTotalColumn.HeaderText = "Costo Total";
            costoTotalColumn.MinimumWidth = 6;
            costoTotalColumn.Name = "costoTotalColumn";
            costoTotalColumn.ReadOnly = true;
            costoTotalColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            costoTotalColumn.Width = 81;
            // 
            // estadoRequisaColumn
            // 
            estadoRequisaColumn.DataPropertyName = "estadoRequisaColumn";
            estadoRequisaColumn.HeaderText = "Estado de Requisa";
            estadoRequisaColumn.MinimumWidth = 6;
            estadoRequisaColumn.Name = "estadoRequisaColumn";
            estadoRequisaColumn.ReadOnly = true;
            estadoRequisaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            estadoRequisaColumn.Width = 123;
            // 
            // fechaCreacionColumn
            // 
            fechaCreacionColumn.DataPropertyName = "fechaCreacionColumn";
            fechaCreacionColumn.HeaderText = "Fecha de Creación";
            fechaCreacionColumn.MinimumWidth = 6;
            fechaCreacionColumn.Name = "fechaCreacionColumn";
            fechaCreacionColumn.ReadOnly = true;
            fechaCreacionColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            fechaCreacionColumn.Width = 123;
            // 
            // diasDemoraColumn
            // 
            diasDemoraColumn.DataPropertyName = "diasDemoraColumn";
            diasDemoraColumn.HeaderText = "Días de demora";
            diasDemoraColumn.MinimumWidth = 6;
            diasDemoraColumn.Name = "diasDemoraColumn";
            diasDemoraColumn.ReadOnly = true;
            diasDemoraColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            diasDemoraColumn.Width = 109;
            // 
            // usuarioColumn
            // 
            usuarioColumn.DataPropertyName = "usuarioColumn";
            usuarioColumn.HeaderText = "Creado Por";
            usuarioColumn.MinimumWidth = 6;
            usuarioColumn.Name = "usuarioColumn";
            usuarioColumn.ReadOnly = true;
            usuarioColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            usuarioColumn.Width = 79;
            // 
            // viewDatalleColumn
            // 
            viewDatalleColumn.DataPropertyName = "viewDatalleColumn";
            viewDatalleColumn.HeaderText = "Ver Detalles";
            viewDatalleColumn.MinimumWidth = 6;
            viewDatalleColumn.Name = "viewDatalleColumn";
            viewDatalleColumn.ReadOnly = true;
            viewDatalleColumn.Width = 85;
            // 
            // filtroComboBox
            // 
            filtroComboBox.FormattingEnabled = true;
            filtroComboBox.Items.AddRange(new object[] { "Fecha Creación", "Costo Total", "dias de demora", "Cantidad de Items", "Estado", "Mostrar Todo" });
            filtroComboBox.Location = new Point(1166, 167);
            filtroComboBox.Name = "filtroComboBox";
            filtroComboBox.Size = new Size(253, 28);
            filtroComboBox.TabIndex = 30;
            filtroComboBox.SelectedIndexChanged += filtroComboBox_SelectedIndexChanged;
            // 
            // filtroEstadoComboBox
            // 
            filtroEstadoComboBox.FormattingEnabled = true;
            filtroEstadoComboBox.Location = new Point(907, 167);
            filtroEstadoComboBox.Name = "filtroEstadoComboBox";
            filtroEstadoComboBox.Size = new Size(230, 28);
            filtroEstadoComboBox.TabIndex = 31;
            filtroEstadoComboBox.Visible = false;
            filtroEstadoComboBox.SelectedIndexChanged += filtroEstadoComboBox_SelectedIndexChanged;
            // 
            // GestionRequisaAjuste
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 551);
            Controls.Add(filtroEstadoComboBox);
            Controls.Add(filtroComboBox);
            Controls.Add(label7);
            Controls.Add(numeroRequisaInput);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "GestionRequisaAjuste";
            Text = "GestionRequisaAjuste";
            Load += GestionRequisaAjuste_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private TextBox numeroRequisaInput;
        private Button RechazarButton;
        private Button agregarButton;
        private GroupBox groupBox1;
        private Label label6;
        private ComboBox estadoComboBox;
        private DataGridView table;
        private ComboBox filtroComboBox;
        private ComboBox filtroEstadoComboBox;
        private DataGridViewTextBoxColumn numeroRequisaColumn;
        private DataGridViewTextBoxColumn descripcionRequisaColumn;
        private DataGridViewTextBoxColumn cantidadAjusteColumn;
        private DataGridViewTextBoxColumn costoTotalColumn;
        private DataGridViewTextBoxColumn estadoRequisaColumn;
        private DataGridViewTextBoxColumn fechaCreacionColumn;
        private DataGridViewTextBoxColumn diasDemoraColumn;
        private DataGridViewTextBoxColumn usuarioColumn;
        private DataGridViewButtonColumn viewDatalleColumn;
    }
}