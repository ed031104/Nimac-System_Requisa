namespace CapaVista
{
    partial class DetallesRequisa
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
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            cargarPdfButton = new Button();
            tableAjustes = new DataGridView();
            groupBox2 = new GroupBox();
            tableEstados = new DataGridView();
            idHistorialRequisaColumn = new DataGridViewTextBoxColumn();
            idRequisaColumn = new DataGridViewTextBoxColumn();
            estadoColumn = new DataGridViewTextBoxColumn();
            CreadoPorColumn = new DataGridViewTextBoxColumn();
            fechaCreacionColumn = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            descripcionRequisaRechazadaInput = new TextBox();
            requisaRechazadaLabel = new Label();
            label4 = new Label();
            diasRetrasoLabel = new Label();
            label2 = new Label();
            montoTotalLabel = new Label();
            label10 = new Label();
            cantidadAjusteLabel = new Label();
            label8 = new Label();
            fechaCreacionLabel = new Label();
            label5 = new Label();
            creadoPorLabel = new Label();
            label3 = new Label();
            numeroRequisaLabel = new Label();
            label1 = new Label();
            idTipoAjusteColumn = new DataGridViewTextBoxColumn();
            casaColumn = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            numeroParteColumn = new DataGridViewTextBoxColumn();
            nombreParteColumn = new DataGridViewTextBoxColumn();
            DescripciónAjusteColumn = new DataGridViewTextBoxColumn();
            tipoAjusteColumn = new DataGridViewTextBoxColumn();
            cantidadColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            costoPromedioColumn = new DataGridViewTextBoxColumn();
            costoPromedioExtendidoColumn = new DataGridViewTextBoxColumn();
            reclamoColumn = new DataGridViewTextBoxColumn();
            transferenciaColumn = new DataGridViewTextBoxColumn();
            visualizarColumn = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableAjustes).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableEstados).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(-3, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1543, 1005);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(cargarPdfButton);
            groupBox3.Controls.Add(tableAjustes);
            groupBox3.Location = new Point(15, 195);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1518, 421);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Historial de Ajustes";
            // 
            // cargarPdfButton
            // 
            cargarPdfButton.BackColor = SystemColors.Info;
            cargarPdfButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cargarPdfButton.Location = new Point(1319, 26);
            cargarPdfButton.Name = "cargarPdfButton";
            cargarPdfButton.Size = new Size(185, 29);
            cargarPdfButton.TabIndex = 1;
            cargarPdfButton.Text = "Cargar PDF";
            cargarPdfButton.UseVisualStyleBackColor = false;
            cargarPdfButton.Visible = false;
            cargarPdfButton.Click += cargarPdfButton_Click;
            // 
            // tableAjustes
            // 
            tableAjustes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableAjustes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableAjustes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableAjustes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableAjustes.Columns.AddRange(new DataGridViewColumn[] { idTipoAjusteColumn, casaColumn, sucursalColumn, numeroParteColumn, nombreParteColumn, DescripciónAjusteColumn, tipoAjusteColumn, cantidadColumn, costoUnitarioColumn, costoPromedioColumn, costoPromedioExtendidoColumn, reclamoColumn, transferenciaColumn, visualizarColumn });
            tableAjustes.Location = new Point(20, 90);
            tableAjustes.Name = "tableAjustes";
            tableAjustes.RowHeadersWidth = 51;
            tableAjustes.Size = new Size(1484, 313);
            tableAjustes.TabIndex = 0;
            tableAjustes.CellClick += tableAjustes_CellClick;
            tableAjustes.CellContentClick += tableAjustes_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(tableEstados);
            groupBox2.Location = new Point(15, 622);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1518, 352);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Historial de Estados";
            // 
            // tableEstados
            // 
            tableEstados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableEstados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableEstados.Columns.AddRange(new DataGridViewColumn[] { idHistorialRequisaColumn, idRequisaColumn, estadoColumn, CreadoPorColumn, fechaCreacionColumn });
            tableEstados.Location = new Point(20, 38);
            tableEstados.Name = "tableEstados";
            tableEstados.RowHeadersWidth = 51;
            tableEstados.Size = new Size(1484, 299);
            tableEstados.TabIndex = 0;
            // 
            // idHistorialRequisaColumn
            // 
            idHistorialRequisaColumn.DataPropertyName = "idHistorialRequisaColumn";
            idHistorialRequisaColumn.HeaderText = "Id";
            idHistorialRequisaColumn.MinimumWidth = 6;
            idHistorialRequisaColumn.Name = "idHistorialRequisaColumn";
            idHistorialRequisaColumn.Width = 125;
            // 
            // idRequisaColumn
            // 
            idRequisaColumn.DataPropertyName = "idRequisaColumn";
            idRequisaColumn.HeaderText = "Número de Documento de Requisa";
            idRequisaColumn.MinimumWidth = 6;
            idRequisaColumn.Name = "idRequisaColumn";
            idRequisaColumn.Width = 125;
            // 
            // estadoColumn
            // 
            estadoColumn.DataPropertyName = "estadoColumn";
            estadoColumn.HeaderText = "Estado";
            estadoColumn.MinimumWidth = 6;
            estadoColumn.Name = "estadoColumn";
            estadoColumn.Width = 125;
            // 
            // CreadoPorColumn
            // 
            CreadoPorColumn.DataPropertyName = "CreadoPorColumn";
            CreadoPorColumn.HeaderText = "Creado Por";
            CreadoPorColumn.MinimumWidth = 6;
            CreadoPorColumn.Name = "CreadoPorColumn";
            CreadoPorColumn.Width = 125;
            // 
            // fechaCreacionColumn
            // 
            fechaCreacionColumn.DataPropertyName = "fechaCreacionColumn";
            fechaCreacionColumn.HeaderText = "Fecha de creación";
            fechaCreacionColumn.MinimumWidth = 6;
            fechaCreacionColumn.Name = "fechaCreacionColumn";
            fechaCreacionColumn.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(descripcionRequisaRechazadaInput);
            groupBox1.Controls.Add(requisaRechazadaLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(diasRetrasoLabel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(montoTotalLabel);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cantidadAjusteLabel);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(fechaCreacionLabel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(creadoPorLabel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numeroRequisaLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1519, 151);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles Requisa";
            // 
            // descripcionRequisaRechazadaInput
            // 
            descripcionRequisaRechazadaInput.Location = new Point(1150, 56);
            descripcionRequisaRechazadaInput.Multiline = true;
            descripcionRequisaRechazadaInput.Name = "descripcionRequisaRechazadaInput";
            descripcionRequisaRechazadaInput.ReadOnly = true;
            descripcionRequisaRechazadaInput.Size = new Size(354, 73);
            descripcionRequisaRechazadaInput.TabIndex = 14;
            // 
            // requisaRechazadaLabel
            // 
            requisaRechazadaLabel.AutoSize = true;
            requisaRechazadaLabel.Location = new Point(1251, 23);
            requisaRechazadaLabel.Name = "requisaRechazadaLabel";
            requisaRechazadaLabel.Size = new Size(29, 20);
            requisaRechazadaLabel.TabIndex = 13;
            requisaRechazadaLabel.Text = "No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1150, 23);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 12;
            label4.Text = "Rechazada:";
            // 
            // diasRetrasoLabel
            // 
            diasRetrasoLabel.AutoSize = true;
            diasRetrasoLabel.ForeColor = Color.Red;
            diasRetrasoLabel.Location = new Point(942, 108);
            diasRetrasoLabel.Name = "diasRetrasoLabel";
            diasRetrasoLabel.Size = new Size(124, 20);
            diasRetrasoLabel.TabIndex = 11;
            diasRetrasoLabel.Text = "Requisa Aplicada";
            diasRetrasoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(817, 109);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 10;
            label2.Text = "Días de retraso:";
            // 
            // montoTotalLabel
            // 
            montoTotalLabel.AutoSize = true;
            montoTotalLabel.Location = new Point(587, 109);
            montoTotalLabel.Name = "montoTotalLabel";
            montoTotalLabel.Size = new Size(41, 20);
            montoTotalLabel.TabIndex = 9;
            montoTotalLabel.Text = "0000";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(406, 109);
            label10.Name = "label10";
            label10.Size = new Size(157, 20);
            label10.TabIndex = 8;
            label10.Text = "Monto Total Aplicado:";
            // 
            // cantidadAjusteLabel
            // 
            cantidadAjusteLabel.AutoSize = true;
            cantidadAjusteLabel.Location = new Point(587, 58);
            cantidadAjusteLabel.Name = "cantidadAjusteLabel";
            cantidadAjusteLabel.Size = new Size(41, 20);
            cantidadAjusteLabel.TabIndex = 7;
            cantidadAjusteLabel.Text = "0000";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(406, 58);
            label8.Name = "label8";
            label8.Size = new Size(141, 20);
            label8.TabIndex = 6;
            label8.Text = "Cantidad de Ajustes";
            // 
            // fechaCreacionLabel
            // 
            fechaCreacionLabel.AutoSize = true;
            fechaCreacionLabel.Location = new Point(188, 109);
            fechaCreacionLabel.Name = "fechaCreacionLabel";
            fechaCreacionLabel.Size = new Size(79, 20);
            fechaCreacionLabel.TabIndex = 5;
            fechaCreacionLabel.Text = "dd/mm/yy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 108);
            label5.Name = "label5";
            label5.Size = new Size(112, 20);
            label5.TabIndex = 4;
            label5.Text = "Fecha Creación:";
            // 
            // creadoPorLabel
            // 
            creadoPorLabel.AutoSize = true;
            creadoPorLabel.Location = new Point(949, 56);
            creadoPorLabel.Name = "creadoPorLabel";
            creadoPorLabel.Size = new Size(78, 20);
            creadoPorLabel.TabIndex = 3;
            creadoPorLabel.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(817, 57);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 2;
            label3.Text = "Creada Por:";
            // 
            // numeroRequisaLabel
            // 
            numeroRequisaLabel.AutoSize = true;
            numeroRequisaLabel.Location = new Point(188, 58);
            numeroRequisaLabel.Name = "numeroRequisaLabel";
            numeroRequisaLabel.Size = new Size(0, 20);
            numeroRequisaLabel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 57);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 0;
            label1.Text = "Número de Requisa:";
            // 
            // idTipoAjusteColumn
            // 
            idTipoAjusteColumn.DataPropertyName = "idTipoAjusteColumn";
            idTipoAjusteColumn.HeaderText = "Id de Tipo de Ajuste";
            idTipoAjusteColumn.MinimumWidth = 6;
            idTipoAjusteColumn.Name = "idTipoAjusteColumn";
            idTipoAjusteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            idTipoAjusteColumn.Visible = false;
            idTipoAjusteColumn.Width = 149;
            // 
            // casaColumn
            // 
            casaColumn.DataPropertyName = "casaColumn";
            casaColumn.HeaderText = "Casa";
            casaColumn.MinimumWidth = 6;
            casaColumn.Name = "casaColumn";
            casaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            casaColumn.Width = 46;
            // 
            // sucursalColumn
            // 
            sucursalColumn.DataPropertyName = "sucursalColumn";
            sucursalColumn.HeaderText = "Sucursal";
            sucursalColumn.MinimumWidth = 6;
            sucursalColumn.Name = "sucursalColumn";
            sucursalColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            sucursalColumn.Width = 69;
            // 
            // numeroParteColumn
            // 
            numeroParteColumn.DataPropertyName = "numeroParteColumn";
            numeroParteColumn.HeaderText = "Número de Parte";
            numeroParteColumn.MinimumWidth = 6;
            numeroParteColumn.Name = "numeroParteColumn";
            numeroParteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            numeroParteColumn.Width = 85;
            // 
            // nombreParteColumn
            // 
            nombreParteColumn.DataPropertyName = "nombreParteColumn";
            nombreParteColumn.HeaderText = "Nombre de Parte";
            nombreParteColumn.MinimumWidth = 6;
            nombreParteColumn.Name = "nombreParteColumn";
            nombreParteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            nombreParteColumn.Width = 86;
            // 
            // DescripciónAjusteColumn
            // 
            DescripciónAjusteColumn.DataPropertyName = "DescripciónAjusteColumn";
            DescripciónAjusteColumn.HeaderText = "Descripción de Ajuste";
            DescripciónAjusteColumn.MinimumWidth = 6;
            DescripciónAjusteColumn.Name = "DescripciónAjusteColumn";
            DescripciónAjusteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            DescripciónAjusteColumn.Width = 106;
            // 
            // tipoAjusteColumn
            // 
            tipoAjusteColumn.DataPropertyName = "tipoAjusteColumn";
            tipoAjusteColumn.HeaderText = "Tipo de Ajuste";
            tipoAjusteColumn.MinimumWidth = 6;
            tipoAjusteColumn.Name = "tipoAjusteColumn";
            tipoAjusteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cantidadColumn
            // 
            cantidadColumn.DataPropertyName = "cantidadColumn";
            cantidadColumn.HeaderText = "Cantidad";
            cantidadColumn.MinimumWidth = 6;
            cantidadColumn.Name = "cantidadColumn";
            cantidadColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            cantidadColumn.Width = 75;
            // 
            // costoUnitarioColumn
            // 
            costoUnitarioColumn.DataPropertyName = "costoUnitarioColumn";
            costoUnitarioColumn.HeaderText = "Costo Unitario";
            costoUnitarioColumn.MinimumWidth = 6;
            costoUnitarioColumn.Name = "costoUnitarioColumn";
            costoUnitarioColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            costoUnitarioColumn.Width = 99;
            // 
            // costoPromedioColumn
            // 
            costoPromedioColumn.DataPropertyName = "costoPromedioColumn";
            costoPromedioColumn.HeaderText = "Costo Promedio";
            costoPromedioColumn.MinimumWidth = 6;
            costoPromedioColumn.Name = "costoPromedioColumn";
            costoPromedioColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            costoPromedioColumn.Width = 110;
            // 
            // costoPromedioExtendidoColumn
            // 
            costoPromedioExtendidoColumn.DataPropertyName = "costoPromedioExtendidoColumn";
            costoPromedioExtendidoColumn.HeaderText = "Costo Promedio Extendido";
            costoPromedioExtendidoColumn.MinimumWidth = 6;
            costoPromedioExtendidoColumn.Name = "costoPromedioExtendidoColumn";
            costoPromedioExtendidoColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            costoPromedioExtendidoColumn.Width = 174;
            // 
            // reclamoColumn
            // 
            reclamoColumn.DataPropertyName = "reclamoColumn";
            reclamoColumn.HeaderText = "Reclamo";
            reclamoColumn.MinimumWidth = 6;
            reclamoColumn.Name = "reclamoColumn";
            reclamoColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            reclamoColumn.Width = 73;
            // 
            // transferenciaColumn
            // 
            transferenciaColumn.DataPropertyName = "transferenciaColumn";
            transferenciaColumn.HeaderText = "Transferencia de Sucursal";
            transferenciaColumn.MinimumWidth = 6;
            transferenciaColumn.Name = "transferenciaColumn";
            transferenciaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            transferenciaColumn.Width = 114;
            // 
            // visualizarColumn
            // 
            visualizarColumn.DataPropertyName = "visualizarColumn";
            visualizarColumn.HeaderText = "Visualizar PDF Reclamo";
            visualizarColumn.MinimumWidth = 6;
            visualizarColumn.Name = "visualizarColumn";
            visualizarColumn.Width = 153;
            // 
            // DetallesRequisa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 997);
            Controls.Add(panel1);
            Name = "DetallesRequisa";
            Text = "DetallesRequisa";
            Load += DetallesRequisa_Load;
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableAjustes).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableEstados).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label8;
        private Label label5;
        private Label label3;
        private Label label1;
        private GroupBox groupBox3;
        private DataGridView tableEstados;
        private Label label10;
        private DataGridView tableAjustes;
        private DataGridViewTextBoxColumn idHistorialRequisaColumn;
        private DataGridViewTextBoxColumn idRequisaColumn;
        private DataGridViewTextBoxColumn estadoColumn;
        private DataGridViewTextBoxColumn CreadoPorColumn;
        private DataGridViewTextBoxColumn fechaCreacionColumn;
        public Label numeroRequisaLabel;
        public Label cantidadAjusteLabel;
        public Label fechaCreacionLabel;
        public Label creadoPorLabel;
        public Label montoTotalLabel;
        private Label label2;
        private Label diasRetrasoLabel;
        private TextBox descripcionRequisaRechazadaInput;
        private Label requisaRechazadaLabel;
        private Label label4;
        private Button cargarPdfButton;
        private DataGridViewTextBoxColumn idTipoAjusteColumn;
        private DataGridViewTextBoxColumn casaColumn;
        private DataGridViewTextBoxColumn sucursalColumn;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn nombreParteColumn;
        private DataGridViewTextBoxColumn DescripciónAjusteColumn;
        private DataGridViewTextBoxColumn tipoAjusteColumn;
        private DataGridViewTextBoxColumn cantidadColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn costoPromedioColumn;
        private DataGridViewTextBoxColumn costoPromedioExtendidoColumn;
        private DataGridViewTextBoxColumn reclamoColumn;
        private DataGridViewTextBoxColumn transferenciaColumn;
        private DataGridViewButtonColumn visualizarColumn;
    }
}