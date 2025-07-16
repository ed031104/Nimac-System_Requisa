namespace CapaVista
{
    partial class GestionCasa
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
            editarButton = new Button();
            eliminarButton = new Button();
            crearButton = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            NombreInput = new TextBox();
            CodigoInput = new TextBox();
            table = new DataGridView();
            codigoCasaColumn = new DataGridViewTextBoxColumn();
            nombreCasaColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            codigoSearchInput = new TextBox();
            label3 = new Label();
            MostrarButton = new Button();
            cargaMasivaButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // editarButton
            // 
            editarButton.Location = new Point(599, 181);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 9;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(717, 181);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 8;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // crearButton
            // 
            crearButton.Location = new Point(467, 181);
            crearButton.Name = "crearButton";
            crearButton.Size = new Size(94, 29);
            crearButton.TabIndex = 7;
            crearButton.Text = "Crear";
            crearButton.UseVisualStyleBackColor = true;
            crearButton.Click += crearButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(NombreInput);
            groupBox1.Controls.Add(CodigoInput);
            groupBox1.Location = new Point(21, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1060, 113);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Casa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(325, 57);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 7;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 6;
            label1.Text = "Código:";
            // 
            // NombreInput
            // 
            NombreInput.Location = new Point(401, 50);
            NombreInput.Name = "NombreInput";
            NombreInput.Size = new Size(125, 27);
            NombreInput.TabIndex = 1;
            // 
            // CodigoInput
            // 
            CodigoInput.Enabled = false;
            CodigoInput.Location = new Point(103, 50);
            CodigoInput.Name = "CodigoInput";
            CodigoInput.Size = new Size(125, 27);
            CodigoInput.TabIndex = 0;
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { codigoCasaColumn, nombreCasaColumn, fechaRegistroColumn, fechaModificacionColumn });
            table.Location = new Point(12, 240);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(1069, 259);
            table.TabIndex = 5;
            table.CellClick += table_CellClick;
            // 
            // codigoCasaColumn
            // 
            codigoCasaColumn.DataPropertyName = "codigoCasaColumn";
            codigoCasaColumn.HeaderText = "Código Casa";
            codigoCasaColumn.MinimumWidth = 6;
            codigoCasaColumn.Name = "codigoCasaColumn";
            codigoCasaColumn.ReadOnly = true;
            codigoCasaColumn.Width = 125;
            // 
            // nombreCasaColumn
            // 
            nombreCasaColumn.DataPropertyName = "nombreCasaColumn";
            nombreCasaColumn.HeaderText = "Nombre Casa";
            nombreCasaColumn.MinimumWidth = 6;
            nombreCasaColumn.Name = "nombreCasaColumn";
            nombreCasaColumn.ReadOnly = true;
            nombreCasaColumn.Width = 125;
            // 
            // fechaRegistroColumn
            // 
            fechaRegistroColumn.DataPropertyName = "fechaRegistroColumn";
            fechaRegistroColumn.HeaderText = "Fecha de Registro";
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
            // codigoSearchInput
            // 
            codigoSearchInput.Location = new Point(88, 183);
            codigoSearchInput.Name = "codigoSearchInput";
            codigoSearchInput.Size = new Size(221, 27);
            codigoSearchInput.TabIndex = 10;
            codigoSearchInput.KeyDown += codigoSearchInput_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 186);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 11;
            label3.Text = "Código:";
            // 
            // MostrarButton
            // 
            MostrarButton.Location = new Point(335, 183);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 12;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            MostrarButton.Click += MostrarButton_Click;
            // 
            // cargaMasivaButton
            // 
            cargaMasivaButton.Location = new Point(929, 186);
            cargaMasivaButton.Name = "cargaMasivaButton";
            cargaMasivaButton.Size = new Size(150, 29);
            cargaMasivaButton.TabIndex = 13;
            cargaMasivaButton.Text = "Carga Masiva";
            cargaMasivaButton.UseVisualStyleBackColor = true;
            cargaMasivaButton.Click += cargaMasivaButton_Click;
            // 
            // GestionCasa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 543);
            Controls.Add(cargaMasivaButton);
            Controls.Add(MostrarButton);
            Controls.Add(label3);
            Controls.Add(codigoSearchInput);
            Controls.Add(editarButton);
            Controls.Add(eliminarButton);
            Controls.Add(crearButton);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "GestionCasa";
            Text = "GestionCasa";
            Load += GestionCasa_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button editarButton;
        private Button eliminarButton;
        private Button crearButton;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox NombreInput;
        private TextBox CodigoInput;
        private DataGridView table;
        private TextBox codigoSearchInput;
        private Label label3;
        private Button MostrarButton;
        private DataGridViewTextBoxColumn codigoCasaColumn;
        private DataGridViewTextBoxColumn nombreCasaColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
        private Button cargaMasivaButton;
    }
}