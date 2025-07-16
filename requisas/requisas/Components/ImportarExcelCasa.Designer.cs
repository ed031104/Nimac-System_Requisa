namespace CapaVista.Components
{
    partial class ImportarExcelCasa
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
            codigoCasaColumn = new DataGridViewTextBoxColumn();
            nombreCasaColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { codigoCasaColumn, nombreCasaColumn });
            table.Location = new Point(12, 120);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1043, 288);
            table.TabIndex = 0;
            // 
            // codigoCasaColumn
            // 
            codigoCasaColumn.DataPropertyName = "codigoCasaColumn";
            codigoCasaColumn.HeaderText = "Código de Casa";
            codigoCasaColumn.MinimumWidth = 6;
            codigoCasaColumn.Name = "codigoCasaColumn";
            codigoCasaColumn.Width = 125;
            // 
            // nombreCasaColumn
            // 
            nombreCasaColumn.DataPropertyName = "nombreCasaColumn";
            nombreCasaColumn.HeaderText = "Nombre de Casa";
            nombreCasaColumn.MinimumWidth = 6;
            nombreCasaColumn.Name = "nombreCasaColumn";
            nombreCasaColumn.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(268, 31);
            label1.TabIndex = 1;
            label1.Text = "Importar datos de Excel";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(12, 450);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(528, 29);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(576, 450);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(479, 29);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ImportarExcelCasa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 518);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(label1);
            Controls.Add(table);
            Name = "ImportarExcelCasa";
            Text = "ImportarExcelCasa";
            Load += ImportarExcelCasa_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button aceptarButton;
        private Button cancelarButton;
        public DataGridView table;
        private DataGridViewTextBoxColumn codigoCasaColumn;
        private DataGridViewTextBoxColumn nombreCasaColumn;
    }
}