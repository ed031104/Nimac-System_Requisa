namespace CapaVista.Components
{
    partial class ImportarExcelSucursal
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
            numeroSucursalColum = new DataGridViewTextBoxColumn();
            nombreSucursal = new DataGridViewTextBoxColumn();
            codigoCasa = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(615, 477);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(479, 29);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(51, 477);
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
            label1.Location = new Point(51, 54);
            label1.Name = "label1";
            label1.Size = new Size(268, 31);
            label1.TabIndex = 5;
            label1.Text = "Importar datos de Excel";
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { numeroSucursalColum, nombreSucursal, codigoCasa });
            table.Location = new Point(51, 147);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1043, 288);
            table.TabIndex = 4;
            // 
            // numeroSucursalColum
            // 
            numeroSucursalColum.DataPropertyName = "numeroSucursalColum";
            numeroSucursalColum.HeaderText = "Número de Sucursal";
            numeroSucursalColum.MinimumWidth = 6;
            numeroSucursalColum.Name = "numeroSucursalColum";
            numeroSucursalColum.Width = 125;
            // 
            // nombreSucursal
            // 
            nombreSucursal.DataPropertyName = "nombreSucursal";
            nombreSucursal.HeaderText = "Nombre de Sucursal";
            nombreSucursal.MinimumWidth = 6;
            nombreSucursal.Name = "nombreSucursal";
            nombreSucursal.Width = 125;
            // 
            // codigoCasa
            // 
            codigoCasa.DataPropertyName = "codigoCasa";
            codigoCasa.HeaderText = "Código de Casa";
            codigoCasa.MinimumWidth = 6;
            codigoCasa.Name = "codigoCasa";
            codigoCasa.Width = 125;
            // 
            // ImportarExcelSucursal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 555);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(label1);
            Controls.Add(table);
            Name = "ImportarExcelSucursal";
            Text = "ImportarExcelSucursal";
            Load += ImportarExcelSucursal_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelarButton;
        private Button aceptarButton;
        private Label label1;
        public DataGridView table;
        private DataGridViewTextBoxColumn numeroSucursalColum;
        private DataGridViewTextBoxColumn nombreSucursal;
        private DataGridViewTextBoxColumn codigoCasa;
    }
}