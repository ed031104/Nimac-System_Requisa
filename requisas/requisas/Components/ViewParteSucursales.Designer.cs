namespace CapaVista.Components
{
    partial class ViewParteSucursales
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
            idparteSucursalColumn = new DataGridViewTextBoxColumn();
            numeroParteColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            stockColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // table
            // 
            table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { idparteSucursalColumn, numeroParteColumn, costoUnitarioColumn, stockColumn, fechaRegistroColumn, fechaModificacionColumn, sucursalColumn });
            table.Location = new Point(12, 4);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(947, 425);
            table.TabIndex = 0;
            table.CellContentClick += table_CellContentClick;
            // 
            // idparteSucursalColumn
            // 
            idparteSucursalColumn.DataPropertyName = "idparteSucursalColumn";
            idparteSucursalColumn.HeaderText = "Id";
            idparteSucursalColumn.MinimumWidth = 6;
            idparteSucursalColumn.Name = "idparteSucursalColumn";
            idparteSucursalColumn.Width = 125;
            // 
            // numeroParteColumn
            // 
            numeroParteColumn.DataPropertyName = "numeroParteColumn";
            numeroParteColumn.HeaderText = "Número de Parte";
            numeroParteColumn.MinimumWidth = 6;
            numeroParteColumn.Name = "numeroParteColumn";
            numeroParteColumn.Width = 125;
            // 
            // costoUnitarioColumn
            // 
            costoUnitarioColumn.DataPropertyName = "costoUnitarioColumn";
            costoUnitarioColumn.HeaderText = "Costo Unitario";
            costoUnitarioColumn.MinimumWidth = 6;
            costoUnitarioColumn.Name = "costoUnitarioColumn";
            costoUnitarioColumn.Width = 125;
            // 
            // stockColumn
            // 
            stockColumn.DataPropertyName = "stockColumn";
            stockColumn.HeaderText = "Stock";
            stockColumn.MinimumWidth = 6;
            stockColumn.Name = "stockColumn";
            stockColumn.Width = 125;
            // 
            // fechaRegistroColumn
            // 
            fechaRegistroColumn.DataPropertyName = "fechaRegistroColumn";
            fechaRegistroColumn.HeaderText = "Fecha de Registro";
            fechaRegistroColumn.MinimumWidth = 6;
            fechaRegistroColumn.Name = "fechaRegistroColumn";
            fechaRegistroColumn.Width = 125;
            // 
            // fechaModificacionColumn
            // 
            fechaModificacionColumn.DataPropertyName = "fechaModificacionColumn";
            fechaModificacionColumn.HeaderText = "Fecha de Modificación";
            fechaModificacionColumn.MinimumWidth = 6;
            fechaModificacionColumn.Name = "fechaModificacionColumn";
            fechaModificacionColumn.Width = 125;
            // 
            // sucursalColumn
            // 
            sucursalColumn.DataPropertyName = "sucursalColumn";
            sucursalColumn.HeaderText = "Sucursal";
            sucursalColumn.MinimumWidth = 6;
            sucursalColumn.Name = "sucursalColumn";
            sucursalColumn.Width = 125;
            // 
            // ViewParteSucursales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 441);
            Controls.Add(table);
            Name = "ViewParteSucursales";
            Text = "ViewParteSucursales";
            Load += ViewParteSucursales_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView table;
        private DataGridViewTextBoxColumn idparteSucursalColumn;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn stockColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
        private DataGridViewTextBoxColumn sucursalColumn;
    }
}