namespace CapaVista
{
    partial class ImportarExcel
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
            ExcelVisorTable = new DataGridView();
            tipoAjusteColumnTE = new DataGridViewTextBoxColumn();
            numeroParteColumnTE = new DataGridViewTextBoxColumn();
            cantidadColumnTe = new DataGridViewTextBoxColumn();
            descripcionColumnTE = new DataGridViewTextBoxColumn();
            costoPromedioColumnTE = new DataGridViewTextBoxColumn();
            costoPromedioExtendidoColumnTE = new DataGridViewTextBoxColumn();
            casaColumnTE = new DataGridViewTextBoxColumn();
            sucursalColumnTE = new DataGridViewTextBoxColumn();
            costoUnitarioColumnTE = new DataGridViewTextBoxColumn();
            importarButton = new Button();
            cancelarButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ExcelVisorTable).BeginInit();
            SuspendLayout();
            // 
            // ExcelVisorTable
            // 
            ExcelVisorTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ExcelVisorTable.Columns.AddRange(new DataGridViewColumn[] { tipoAjusteColumnTE, numeroParteColumnTE, cantidadColumnTe, descripcionColumnTE, costoPromedioColumnTE, costoPromedioExtendidoColumnTE, casaColumnTE, sucursalColumnTE, costoUnitarioColumnTE });
            ExcelVisorTable.Location = new Point(29, 118);
            ExcelVisorTable.Name = "ExcelVisorTable";
            ExcelVisorTable.RowHeadersWidth = 51;
            ExcelVisorTable.Size = new Size(1016, 329);
            ExcelVisorTable.TabIndex = 0;
            // 
            // tipoAjusteColumnTE
            // 
            tipoAjusteColumnTE.DataPropertyName = "tipoAjusteColumnTE";
            tipoAjusteColumnTE.HeaderText = "Tipo de Ajuste";
            tipoAjusteColumnTE.MinimumWidth = 6;
            tipoAjusteColumnTE.Name = "tipoAjusteColumnTE";
            tipoAjusteColumnTE.ReadOnly = true;
            tipoAjusteColumnTE.Width = 125;
            // 
            // numeroParteColumnTE
            // 
            numeroParteColumnTE.DataPropertyName = "numeroParteColumnTE";
            numeroParteColumnTE.HeaderText = "Número de Parte";
            numeroParteColumnTE.MinimumWidth = 6;
            numeroParteColumnTE.Name = "numeroParteColumnTE";
            numeroParteColumnTE.ReadOnly = true;
            numeroParteColumnTE.Width = 125;
            // 
            // cantidadColumnTe
            // 
            cantidadColumnTe.DataPropertyName = "cantidadColumnTe";
            cantidadColumnTe.HeaderText = "Cantidad de Ajuste";
            cantidadColumnTe.MinimumWidth = 6;
            cantidadColumnTe.Name = "cantidadColumnTe";
            cantidadColumnTe.ReadOnly = true;
            cantidadColumnTe.Width = 125;
            // 
            // descripcionColumnTE
            // 
            descripcionColumnTE.DataPropertyName = "descripcionColumnTE";
            descripcionColumnTE.HeaderText = "Descripción";
            descripcionColumnTE.MinimumWidth = 6;
            descripcionColumnTE.Name = "descripcionColumnTE";
            descripcionColumnTE.ReadOnly = true;
            descripcionColumnTE.Width = 125;
            // 
            // costoPromedioColumnTE
            // 
            costoPromedioColumnTE.DataPropertyName = "costoPromedioColumnTE";
            costoPromedioColumnTE.HeaderText = "Costo Promedio";
            costoPromedioColumnTE.MinimumWidth = 6;
            costoPromedioColumnTE.Name = "costoPromedioColumnTE";
            costoPromedioColumnTE.ReadOnly = true;
            costoPromedioColumnTE.Width = 125;
            // 
            // costoPromedioExtendidoColumnTE
            // 
            costoPromedioExtendidoColumnTE.DataPropertyName = "costoPromedioExtendidoColumnTE";
            costoPromedioExtendidoColumnTE.HeaderText = "Costo Promedio Extendido";
            costoPromedioExtendidoColumnTE.MinimumWidth = 6;
            costoPromedioExtendidoColumnTE.Name = "costoPromedioExtendidoColumnTE";
            costoPromedioExtendidoColumnTE.ReadOnly = true;
            costoPromedioExtendidoColumnTE.Width = 125;
            // 
            // casaColumnTE
            // 
            casaColumnTE.DataPropertyName = "casaColumnTE";
            casaColumnTE.HeaderText = "Casa";
            casaColumnTE.MinimumWidth = 6;
            casaColumnTE.Name = "casaColumnTE";
            casaColumnTE.ReadOnly = true;
            casaColumnTE.Width = 125;
            // 
            // sucursalColumnTE
            // 
            sucursalColumnTE.DataPropertyName = "sucursalColumnTE";
            sucursalColumnTE.HeaderText = "Sucursal";
            sucursalColumnTE.MinimumWidth = 6;
            sucursalColumnTE.Name = "sucursalColumnTE";
            sucursalColumnTE.ReadOnly = true;
            sucursalColumnTE.Width = 125;
            // 
            // costoUnitarioColumnTE
            // 
            costoUnitarioColumnTE.DataPropertyName = "costoUnitarioColumnTE";
            costoUnitarioColumnTE.HeaderText = "Costo Unitario";
            costoUnitarioColumnTE.MinimumWidth = 6;
            costoUnitarioColumnTE.Name = "costoUnitarioColumnTE";
            costoUnitarioColumnTE.ReadOnly = true;
            costoUnitarioColumnTE.Width = 125;
            // 
            // importarButton
            // 
            importarButton.Location = new Point(29, 498);
            importarButton.Name = "importarButton";
            importarButton.Size = new Size(455, 45);
            importarButton.TabIndex = 1;
            importarButton.Text = "IMPORTAR";
            importarButton.UseVisualStyleBackColor = true;
            importarButton.Click += importarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(590, 498);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(455, 45);
            cancelarButton.TabIndex = 2;
            cancelarButton.Text = "CANCELAR";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 34);
            label1.Name = "label1";
            label1.Size = new Size(293, 31);
            label1.TabIndex = 3;
            label1.Text = "IMPORTARCIÓN DE EXCEL";
            // 
            // ImportarExcel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 576);
            Controls.Add(label1);
            Controls.Add(cancelarButton);
            Controls.Add(importarButton);
            Controls.Add(ExcelVisorTable);
            Name = "ImportarExcel";
            Text = "ImportarExcel";
            Load += ImportarExcel_Load;
            ((System.ComponentModel.ISupportInitialize)ExcelVisorTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button importarButton;
        private Button cancelarButton;
        private Label label1;
        public DataGridView ExcelVisorTable;
        private DataGridViewTextBoxColumn tipoAjusteColumnTE;
        private DataGridViewTextBoxColumn numeroParteColumnTE;
        private DataGridViewTextBoxColumn cantidadColumnTe;
        private DataGridViewTextBoxColumn descripcionColumnTE;
        private DataGridViewTextBoxColumn costoPromedioColumnTE;
        private DataGridViewTextBoxColumn costoPromedioExtendidoColumnTE;
        private DataGridViewTextBoxColumn casaColumnTE;
        private DataGridViewTextBoxColumn sucursalColumnTE;
        private DataGridViewTextBoxColumn costoUnitarioColumnTE;
    }
}