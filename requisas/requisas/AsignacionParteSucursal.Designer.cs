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
            label7 = new Label();
            numeroParteSearchInput = new TextBox();
            editarButton = new Button();
            eliminarButton = new Button();
            crearButton = new Button();
            groupBox1 = new GroupBox();
            descripcionInput = new TextBox();
            label5 = new Label();
            parteInput = new TextBox();
            casaInput = new TextBox();
            label4 = new Label();
            sucursalInput = new TextBox();
            label2 = new Label();
            label1 = new Label();
            costoUnitarioInput = new TextBox();
            label6 = new Label();
            label3 = new Label();
            stockInput = new TextBox();
            idParteCasaInput = new TextBox();
            table = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            parteColumn = new DataGridViewTextBoxColumn();
            descripcionColumn = new DataGridViewTextBoxColumn();
            stockColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            casaColumn = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            cargaMasivaButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
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
            numeroParteSearchInput.TextChanged += numeroParteSearchInput_TextChanged;
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
            groupBox1.Controls.Add(descripcionInput);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(parteInput);
            groupBox1.Controls.Add(casaInput);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(sucursalInput);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(costoUnitarioInput);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(stockInput);
            groupBox1.Controls.Add(idParteCasaInput);
            groupBox1.Location = new Point(33, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1158, 162);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Sucursal";
            // 
            // descripcionInput
            // 
            descripcionInput.Location = new Point(880, 111);
            descripcionInput.Name = "descripcionInput";
            descripcionInput.Size = new Size(184, 27);
            descripcionInput.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(773, 114);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 20;
            label5.Text = "Descripción:";
            // 
            // parteInput
            // 
            parteInput.Location = new Point(448, 119);
            parteInput.Name = "parteInput";
            parteInput.Size = new Size(184, 27);
            parteInput.TabIndex = 19;
            // 
            // casaInput
            // 
            casaInput.Location = new Point(85, 117);
            casaInput.Name = "casaInput";
            casaInput.Size = new Size(150, 27);
            casaInput.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(771, 45);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 17;
            label4.Text = "Sucursal:";
            // 
            // sucursalInput
            // 
            sucursalInput.Location = new Point(880, 42);
            sucursalInput.Name = "sucursalInput";
            sucursalInput.Size = new Size(173, 27);
            sucursalInput.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 120);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 15;
            label2.Text = "Parte:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 53);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 13;
            label1.Text = "Costo Unitario:";
            // 
            // costoUnitarioInput
            // 
            costoUnitarioInput.Location = new Point(459, 48);
            costoUnitarioInput.Name = "costoUnitarioInput";
            costoUnitarioInput.Size = new Size(173, 27);
            costoUnitarioInput.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 119);
            label6.Name = "label6";
            label6.Size = new Size(43, 20);
            label6.TabIndex = 11;
            label6.Text = "Casa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 49);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 8;
            label3.Text = "Stock:";
            // 
            // stockInput
            // 
            stockInput.Location = new Point(84, 49);
            stockInput.Name = "stockInput";
            stockInput.Size = new Size(151, 27);
            stockInput.TabIndex = 2;
            // 
            // idParteCasaInput
            // 
            idParteCasaInput.Location = new Point(1119, 26);
            idParteCasaInput.Name = "idParteCasaInput";
            idParteCasaInput.Size = new Size(33, 27);
            idParteCasaInput.TabIndex = 0;
            idParteCasaInput.Visible = false;
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { idColumn, parteColumn, descripcionColumn, stockColumn, costoUnitarioColumn, casaColumn, sucursalColumn, fechaRegistroColumn, fechaModificacionColumn });
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
            // descripcionColumn
            // 
            descripcionColumn.DataPropertyName = "descripcionColumn";
            descripcionColumn.HeaderText = "Descripción";
            descripcionColumn.MinimumWidth = 6;
            descripcionColumn.Name = "descripcionColumn";
            descripcionColumn.Width = 125;
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
            // costoUnitarioColumn
            // 
            costoUnitarioColumn.DataPropertyName = "costoUnitarioColumn";
            costoUnitarioColumn.HeaderText = "Costo Unitario";
            costoUnitarioColumn.MinimumWidth = 6;
            costoUnitarioColumn.Name = "costoUnitarioColumn";
            costoUnitarioColumn.ReadOnly = true;
            costoUnitarioColumn.Width = 125;
            // 
            // casaColumn
            // 
            casaColumn.DataPropertyName = "casaColumn";
            casaColumn.HeaderText = "Casa";
            casaColumn.MinimumWidth = 6;
            casaColumn.Name = "casaColumn";
            casaColumn.Width = 125;
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
        private Label label7;
        private TextBox numeroParteSearchInput;
        private Button editarButton;
        private Button eliminarButton;
        private Button crearButton;
        private GroupBox groupBox1;
        private Label label6;
        private Label label3;
        private TextBox stockInput;
        private TextBox idParteCasaInput;
        private DataGridView table;
        private Label label1;
        private TextBox costoUnitarioInput;
        private Label label2;
        private Button cargaMasivaButton;
        private Label label4;
        private TextBox sucursalInput;
        private TextBox descripcionInput;
        private Label label5;
        private TextBox parteInput;
        private TextBox casaInput;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn parteColumn;
        private DataGridViewTextBoxColumn descripcionColumn;
        private DataGridViewTextBoxColumn stockColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn casaColumn;
        private DataGridViewTextBoxColumn sucursalColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
    }
}