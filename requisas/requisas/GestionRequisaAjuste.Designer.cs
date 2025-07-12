namespace CapaVista
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
            MostrarButton = new Button();
            label7 = new Label();
            numeroSucuarSearchInput = new TextBox();
            editarButton = new Button();
            eliminarButton = new Button();
            crearButton = new Button();
            groupBox1 = new GroupBox();
            label6 = new Label();
            label3 = new Label();
            label1 = new Label();
            casaComboBox = new ComboBox();
            nombreInput = new TextBox();
            numeroSucursalInput = new TextBox();
            table = new DataGridView();
            numeroSucursalColumn = new DataGridViewTextBoxColumn();
            nombreSucursalColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            casaColumn = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // MostrarButton
            // 
            MostrarButton.Location = new Point(376, 161);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 29;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 167);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 28;
            label7.Text = "Nombre:";
            // 
            // numeroSucuarSearchInput
            // 
            numeroSucuarSearchInput.Location = new Point(120, 163);
            numeroSucuarSearchInput.Name = "numeroSucuarSearchInput";
            numeroSucuarSearchInput.Size = new Size(221, 27);
            numeroSucuarSearchInput.TabIndex = 27;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(785, 162);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 26;
            editarButton.Text = "Rechazar";
            editarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(903, 162);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 25;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // crearButton
            // 
            crearButton.Location = new Point(653, 162);
            crearButton.Name = "crearButton";
            crearButton.Size = new Size(94, 29);
            crearButton.TabIndex = 24;
            crearButton.Text = "Aprobar";
            crearButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(casaComboBox);
            groupBox1.Controls.Add(nombreInput);
            groupBox1.Controls.Add(numeroSucursalInput);
            groupBox1.Location = new Point(32, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(965, 104);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestión de Requisa con Ajustes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(699, 51);
            label6.Name = "label6";
            label6.Size = new Size(43, 20);
            label6.TabIndex = 11;
            label6.Text = "Casa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 50);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 8;
            label3.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 50);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 6;
            label1.Text = "Número:";
            // 
            // casaComboBox
            // 
            casaComboBox.FormattingEnabled = true;
            casaComboBox.Location = new Point(767, 47);
            casaComboBox.Name = "casaComboBox";
            casaComboBox.Size = new Size(151, 28);
            casaComboBox.TabIndex = 5;
            // 
            // nombreInput
            // 
            nombreInput.Location = new Point(440, 50);
            nombreInput.Name = "nombreInput";
            nombreInput.Size = new Size(125, 27);
            nombreInput.TabIndex = 2;
            // 
            // numeroSucursalInput
            // 
            numeroSucursalInput.Location = new Point(103, 50);
            numeroSucursalInput.Name = "numeroSucursalInput";
            numeroSucursalInput.Size = new Size(125, 27);
            numeroSucursalInput.TabIndex = 0;
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { numeroSucursalColumn, nombreSucursalColumn, fechaRegistroColumn, fechaModificacionColumn, casaColumn });
            table.Location = new Point(23, 217);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(974, 259);
            table.TabIndex = 22;
            // 
            // numeroSucursalColumn
            // 
            numeroSucursalColumn.DataPropertyName = "numeroSucursalColumn";
            numeroSucursalColumn.HeaderText = "Número de Sucursal";
            numeroSucursalColumn.MinimumWidth = 6;
            numeroSucursalColumn.Name = "numeroSucursalColumn";
            numeroSucursalColumn.Width = 125;
            // 
            // nombreSucursalColumn
            // 
            nombreSucursalColumn.DataPropertyName = "nombreSucursalColumn";
            nombreSucursalColumn.HeaderText = "Nombre de Sucursal";
            nombreSucursalColumn.MinimumWidth = 6;
            nombreSucursalColumn.Name = "nombreSucursalColumn";
            nombreSucursalColumn.ReadOnly = true;
            nombreSucursalColumn.Width = 125;
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
            fechaModificacionColumn.HeaderText = "Fecha de Modificación";
            fechaModificacionColumn.MinimumWidth = 6;
            fechaModificacionColumn.Name = "fechaModificacionColumn";
            fechaModificacionColumn.ReadOnly = true;
            fechaModificacionColumn.Width = 125;
            // 
            // casaColumn
            // 
            casaColumn.DataPropertyName = "casaColumn";
            casaColumn.HeaderText = "Casa";
            casaColumn.MinimumWidth = 6;
            casaColumn.Name = "casaColumn";
            casaColumn.ReadOnly = true;
            casaColumn.Width = 125;
            // 
            // GestionRequisaAjuste
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 535);
            Controls.Add(MostrarButton);
            Controls.Add(label7);
            Controls.Add(numeroSucuarSearchInput);
            Controls.Add(editarButton);
            Controls.Add(eliminarButton);
            Controls.Add(crearButton);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "GestionRequisaAjuste";
            Text = "GestionRequisaAjuste";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MostrarButton;
        private Label label7;
        private TextBox numeroSucuarSearchInput;
        private Button editarButton;
        private Button eliminarButton;
        private Button crearButton;
        private GroupBox groupBox1;
        private Label label6;
        private Label label3;
        private Label label1;
        private ComboBox casaComboBox;
        private TextBox nombreInput;
        private TextBox numeroSucursalInput;
        private DataGridView table;
        private DataGridViewTextBoxColumn numeroSucursalColumn;
        private DataGridViewTextBoxColumn nombreSucursalColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
        private DataGridViewTextBoxColumn casaColumn;
    }
}