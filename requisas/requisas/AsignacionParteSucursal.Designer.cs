namespace CapaVista
{
    partial class AsignacionParteSucursal
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
            MostrarButton = new Button();
            label7 = new Label();
            numeroParteSearchInput = new TextBox();
            editarButton = new Button();
            eliminarButton = new Button();
            crearButton = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            parteComboBox = new ComboBox();
            label1 = new Label();
            costoUnitarioInput = new TextBox();
            label6 = new Label();
            label3 = new Label();
            idParteCasaText = new Label();
            sucursalComboBox = new ComboBox();
            stockInput = new TextBox();
            idParteCasaInput = new TextBox();
            table = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            parteColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            stockColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            cargaMasivaButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // MostrarButton
            // 
            MostrarButton.Location = new Point(405, 204);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 29;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            MostrarButton.Click += MostrarButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 209);
            label7.Name = "label7";
            label7.Size = new Size(98, 20);
            label7.TabIndex = 28;
            label7.Text = "Codigo Parte:";
            // 
            // numeroParteSearchInput
            // 
            numeroParteSearchInput.Location = new Point(149, 206);
            numeroParteSearchInput.Name = "numeroParteSearchInput";
            numeroParteSearchInput.Size = new Size(221, 27);
            numeroParteSearchInput.TabIndex = 27;
            numeroParteSearchInput.KeyDown += numeroParteSearchInput_KeyDown;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(786, 204);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 26;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(904, 204);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 25;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // crearButton
            // 
            crearButton.Location = new Point(654, 204);
            crearButton.Name = "crearButton";
            crearButton.Size = new Size(94, 29);
            crearButton.TabIndex = 24;
            crearButton.Text = "Crear";
            crearButton.UseVisualStyleBackColor = true;
            crearButton.Click += crearButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(parteComboBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(costoUnitarioInput);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(idParteCasaText);
            groupBox1.Controls.Add(sucursalComboBox);
            groupBox1.Controls.Add(stockInput);
            groupBox1.Controls.Add(idParteCasaInput);
            groupBox1.Location = new Point(33, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(965, 162);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Sucursal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(357, 120);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 15;
            label2.Text = "Parte:";
            // 
            // parteComboBox
            // 
            parteComboBox.FormattingEnabled = true;
            parteComboBox.Location = new Point(425, 116);
            parteComboBox.Name = "parteComboBox";
            parteComboBox.Size = new Size(151, 28);
            parteComboBox.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(697, 55);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 13;
            label1.Text = "Costo Unitario:";
            // 
            // costoUnitarioInput
            // 
            costoUnitarioInput.Location = new Point(810, 50);
            costoUnitarioInput.Name = "costoUnitarioInput";
            costoUnitarioInput.Size = new Size(125, 27);
            costoUnitarioInput.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 119);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 11;
            label6.Text = "Sucursal:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 49);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 8;
            label3.Text = "Stock:";
            // 
            // idParteCasaText
            // 
            idParteCasaText.AutoSize = true;
            idParteCasaText.Location = new Point(27, 50);
            idParteCasaText.Name = "idParteCasaText";
            idParteCasaText.Size = new Size(25, 20);
            idParteCasaText.TabIndex = 6;
            idParteCasaText.Text = "Id:";
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(84, 115);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(151, 28);
            sucursalComboBox.TabIndex = 5;
            // 
            // stockInput
            // 
            stockInput.Location = new Point(451, 49);
            stockInput.Name = "stockInput";
            stockInput.Size = new Size(125, 27);
            stockInput.TabIndex = 2;
            // 
            // idParteCasaInput
            // 
            idParteCasaInput.Location = new Point(81, 48);
            idParteCasaInput.Name = "idParteCasaInput";
            idParteCasaInput.Size = new Size(125, 27);
            idParteCasaInput.TabIndex = 0;
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { idColumn, parteColumn, costoUnitarioColumn, stockColumn, fechaRegistroColumn, fechaModificacionColumn, sucursalColumn });
            table.Location = new Point(24, 259);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1179, 259);
            table.TabIndex = 22;
            table.CellClick += table_CellClick;
            // 
            // idColumn
            // 
            idColumn.DataPropertyName = "idColumn";
            idColumn.HeaderText = "Id";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 125;
            // 
            // parteColumn
            // 
            parteColumn.DataPropertyName = "parteColumn";
            parteColumn.HeaderText = "Parte";
            parteColumn.MinimumWidth = 6;
            parteColumn.Name = "parteColumn";
            parteColumn.ReadOnly = true;
            parteColumn.Width = 125;
            // 
            // costoUnitarioColumn
            // 
            costoUnitarioColumn.DataPropertyName = "costoUnitarioColumn";
            costoUnitarioColumn.HeaderText = "Costo Unitario";
            costoUnitarioColumn.MinimumWidth = 6;
            costoUnitarioColumn.Name = "costoUnitarioColumn";
            costoUnitarioColumn.ReadOnly = true;
            costoUnitarioColumn.Width = 125;
            // 
            // stockColumn
            // 
            stockColumn.DataPropertyName = "stockColumn";
            stockColumn.HeaderText = "Stock";
            stockColumn.MinimumWidth = 6;
            stockColumn.Name = "stockColumn";
            stockColumn.ReadOnly = true;
            stockColumn.Width = 125;
            // 
            // fechaRegistroColumn
            // 
            fechaRegistroColumn.DataPropertyName = "fechaRegistroColumn";
            fechaRegistroColumn.HeaderText = "Fecha de registro";
            fechaRegistroColumn.MinimumWidth = 6;
            fechaRegistroColumn.Name = "fechaRegistroColumn";
            fechaRegistroColumn.ReadOnly = true;
            fechaRegistroColumn.Width = 125;
            // 
            // fechaModificacionColumn
            // 
            fechaModificacionColumn.DataPropertyName = "fechaModificacionColumn";
            fechaModificacionColumn.HeaderText = "Fecha de modificación";
            fechaModificacionColumn.MinimumWidth = 6;
            fechaModificacionColumn.Name = "fechaModificacionColumn";
            fechaModificacionColumn.ReadOnly = true;
            fechaModificacionColumn.Width = 125;
            // 
            // sucursalColumn
            // 
            sucursalColumn.DataPropertyName = "sucursalColumn";
            sucursalColumn.HeaderText = "Sucursal";
            sucursalColumn.MinimumWidth = 6;
            sucursalColumn.Name = "sucursalColumn";
            sucursalColumn.ReadOnly = true;
            sucursalColumn.Width = 125;
            // 
            // cargaMasivaButton
            // 
            cargaMasivaButton.Location = new Point(1055, 200);
            cargaMasivaButton.Name = "cargaMasivaButton";
            cargaMasivaButton.Size = new Size(148, 29);
            cargaMasivaButton.TabIndex = 30;
            cargaMasivaButton.Text = "Carga Masiva";
            cargaMasivaButton.UseVisualStyleBackColor = true;
            cargaMasivaButton.Click += cargaMasivaButton_Click;
            // 
            // AsignacionParteSucursal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 549);
            Controls.Add(cargaMasivaButton);
            Controls.Add(MostrarButton);
            Controls.Add(label7);
            Controls.Add(numeroParteSearchInput);
            Controls.Add(editarButton);
            Controls.Add(eliminarButton);
            Controls.Add(crearButton);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "AsignacionParteSucursal";
            Text = "AsignacionParteSucursal";
            Load += AsignacionParteSucursal_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MostrarButton;
        private Label label7;
        private TextBox numeroParteSearchInput;
        private Button editarButton;
        private Button eliminarButton;
        private Button crearButton;
        private GroupBox groupBox1;
        private Label label6;
        private Label label3;
        private Label idParteCasaText;
        private ComboBox sucursalComboBox;
        private TextBox stockInput;
        private TextBox idParteCasaInput;
        private DataGridView table;
        private Label label1;
        private TextBox costoUnitarioInput;
        private Label label2;
        private ComboBox parteComboBox;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn parteColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn stockColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
        private DataGridViewTextBoxColumn sucursalColumn;
        private Button cargaMasivaButton;
    }
}