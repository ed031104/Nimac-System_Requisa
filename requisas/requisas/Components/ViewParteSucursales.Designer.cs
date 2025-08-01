﻿namespace CapaVista.Components
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
            nombreParteColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            stockColumn = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            casaColumn = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            label2 = new Label();
            numeroParteSearchInput = new TextBox();
            label1 = new Label();
            buscarPorNombreInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { idparteSucursalColumn, numeroParteColumn, nombreParteColumn, costoUnitarioColumn, stockColumn, sucursalColumn, casaColumn });
            table.Location = new Point(12, 110);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1156, 319);
            table.TabIndex = 0;
            table.CellClick += table_CellClick;
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
            // nombreParteColumn
            // 
            nombreParteColumn.DataPropertyName = "nombreParteColumn";
            nombreParteColumn.HeaderText = "Descripción de Parte";
            nombreParteColumn.MinimumWidth = 6;
            nombreParteColumn.Name = "nombreParteColumn";
            nombreParteColumn.Width = 125;
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
            // sucursalColumn
            // 
            sucursalColumn.DataPropertyName = "sucursalColumn";
            sucursalColumn.HeaderText = "Sucursal";
            sucursalColumn.MinimumWidth = 6;
            sucursalColumn.Name = "sucursalColumn";
            sucursalColumn.Width = 125;
            // 
            // casaColumn
            // 
            casaColumn.DataPropertyName = "casaColumn";
            casaColumn.HeaderText = "Casa";
            casaColumn.MinimumWidth = 6;
            casaColumn.Name = "casaColumn";
            casaColumn.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numeroParteSearchInput);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buscarPorNombreInput);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1140, 79);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 40);
            label2.Name = "label2";
            label2.Size = new Size(198, 20);
            label2.TabIndex = 3;
            label2.Text = "Buscar por Número de Parte:";
            // 
            // numeroParteSearchInput
            // 
            numeroParteSearchInput.Location = new Point(215, 36);
            numeroParteSearchInput.Name = "numeroParteSearchInput";
            numeroParteSearchInput.Size = new Size(281, 27);
            numeroParteSearchInput.TabIndex = 2;
            numeroParteSearchInput.TextChanged += numeroParteSearchInput_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(606, 37);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 1;
            label1.Text = "Buscar por nombre de Parte:";
            // 
            // buscarPorNombreInput
            // 
            buscarPorNombreInput.Location = new Point(811, 33);
            buscarPorNombreInput.Name = "buscarPorNombreInput";
            buscarPorNombreInput.Size = new Size(281, 27);
            buscarPorNombreInput.TabIndex = 0;
            buscarPorNombreInput.TextChanged += buscarPorNombreInput_TextChanged;
            // 
            // ViewParteSucursales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 441);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "ViewParteSucursales";
            Text = "ViewParteSucursales";
            Load += ViewParteSucursales_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView table;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox buscarPorNombreInput;
        private DataGridViewTextBoxColumn idparteSucursalColumn;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn nombreParteColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn stockColumn;
        private DataGridViewTextBoxColumn sucursalColumn;
        private DataGridViewTextBoxColumn casaColumn;
        private Label label2;
        private TextBox numeroParteSearchInput;
    }
}