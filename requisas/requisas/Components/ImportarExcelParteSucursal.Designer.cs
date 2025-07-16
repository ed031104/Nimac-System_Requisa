namespace CapaVista.Components
{
    partial class ImportarExcelParteSucursal
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
            cancelarButton = new Button();
            aceptarButton = new Button();
            label1 = new Label();
            table = new DataGridView();
            numeroParteColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            stockColumn = new DataGridViewTextBoxColumn();
            numeroSucursalColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(599, 454);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(479, 29);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(35, 454);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(528, 29);
            aceptarButton.TabIndex = 6;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 31);
            label1.Name = "label1";
            label1.Size = new Size(268, 31);
            label1.TabIndex = 5;
            label1.Text = "Importar datos de Excel";
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { numeroParteColumn, costoUnitarioColumn, stockColumn, numeroSucursalColumn });
            table.Location = new Point(35, 124);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1043, 288);
            table.TabIndex = 4;
            // 
            // numeroParteColumn
            // 
            numeroParteColumn.DataPropertyName = "numeroParteColumn";
            numeroParteColumn.HeaderText = "Número de parte";
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
            // numeroSucursalColumn
            // 
            numeroSucursalColumn.DataPropertyName = "numeroSucursalColumn";
            numeroSucursalColumn.HeaderText = "Número de Sucursal";
            numeroSucursalColumn.MinimumWidth = 6;
            numeroSucursalColumn.Name = "numeroSucursalColumn";
            numeroSucursalColumn.Width = 125;
            // 
            // ImportarExcelParteSucursal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 590);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(label1);
            Controls.Add(table);
            Name = "ImportarExcelParteSucursal";
            Text = "ImportarExcelParteSucursal";
            Load += ImportarExcelParteSucursal_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelarButton;
        private Button aceptarButton;
        private Label label1;
        public DataGridView table;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn stockColumn;
        private DataGridViewTextBoxColumn numeroSucursalColumn;
    }
}