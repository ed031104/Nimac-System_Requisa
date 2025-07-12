namespace requisas
{
    partial class Nueva_Requisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nueva_Requisa));
            label7 = new Label();
            label8 = new Label();
            estadoRequisaComboBox = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            table = new DataGridView();
            groupBox1 = new GroupBox();
            casaRequisaComboBox = new ComboBox();
            label11 = new Label();
            descripcionRequisaInput = new TextBox();
            label6 = new Label();
            sucursalRequisaComboBox = new ComboBox();
            label5 = new Label();
            tipoAjusteRequisaComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            nDocumentoRequisaInput = new TextBox();
            label10 = new Label();
            nParteAjusteInput = new TextBox();
            groupBox2 = new GroupBox();
            descripcionParteInput = new TextBox();
            label13 = new Label();
            cantidadParteInput = new TextBox();
            label12 = new Label();
            agregarButton = new Button();
            guardarButton = new Button();
            cargarPdfButton = new Button();
            importarExcelButton = new Button();
            eliminarButton = new Button();
            checkColumn = new DataGridViewCheckBoxColumn();
            numeroParteColumn = new DataGridViewTextBoxColumn();
            columcasa = new DataGridViewTextBoxColumn();
            sucursalColumn = new DataGridViewTextBoxColumn();
            descripcionColumn = new DataGridViewTextBoxColumn();
            tipoAjusteColumn = new DataGridViewTextBoxColumn();
            cantidadColumn = new DataGridViewTextBoxColumn();
            costoUnitarioColumn = new DataGridViewTextBoxColumn();
            costoPromedioCOlumn = new DataGridViewTextBoxColumn();
            costoPromedioExtendidoColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(1130, 652);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 35;
            label7.Text = "copyright © NIMAC";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 95);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 37;
            label8.Text = "Estado:";
            // 
            // estadoRequisaComboBox
            // 
            estadoRequisaComboBox.Enabled = false;
            estadoRequisaComboBox.FormattingEnabled = true;
            estadoRequisaComboBox.Items.AddRange(new object[] { "Revisión", "Aprobada", "Aplicada" });
            estadoRequisaComboBox.Location = new Point(137, 92);
            estadoRequisaComboBox.Margin = new Padding(3, 4, 3, 4);
            estadoRequisaComboBox.Name = "estadoRequisaComboBox";
            estadoRequisaComboBox.Size = new Size(133, 28);
            estadoRequisaComboBox.TabIndex = 38;
            estadoRequisaComboBox.Text = "Revisión";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, 5);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(257, 4);
            label1.Name = "label1";
            label1.Size = new Size(542, 41);
            label1.TabIndex = 46;
            label1.Text = "NICARAGUA MACHINERY COMPANY";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(347, 45);
            label2.Name = "label2";
            label2.Size = new Size(314, 37);
            label2.TabIndex = 47;
            label2.Text = "AJUSTES AL INVENTARIO";
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToOrderColumns = true;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { checkColumn, numeroParteColumn, columcasa, sucursalColumn, descripcionColumn, tipoAjusteColumn, cantidadColumn, costoUnitarioColumn, costoPromedioCOlumn, costoPromedioExtendidoColumn });
            table.Location = new Point(9, 321);
            table.Margin = new Padding(3, 4, 3, 4);
            table.Name = "table";
            table.RowHeadersWidth = 62;
            table.Size = new Size(1235, 317);
            table.TabIndex = 48;
            table.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(casaRequisaComboBox);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(descripcionRequisaInput);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(sucursalRequisaComboBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tipoAjusteRequisaComboBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(nDocumentoRequisaInput);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(estadoRequisaComboBox);
            groupBox1.Location = new Point(9, 99);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(1235, 144);
            groupBox1.TabIndex = 49;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos De Requisa";
            // 
            // casaRequisaComboBox
            // 
            casaRequisaComboBox.FormattingEnabled = true;
            casaRequisaComboBox.Location = new Point(595, 92);
            casaRequisaComboBox.Margin = new Padding(3, 4, 3, 4);
            casaRequisaComboBox.Name = "casaRequisaComboBox";
            casaRequisaComboBox.Size = new Size(154, 28);
            casaRequisaComboBox.TabIndex = 55;
            casaRequisaComboBox.SelectedIndexChanged += casaRequisaComboBox_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(810, 23);
            label11.Name = "label11";
            label11.Size = new Size(162, 20);
            label11.TabIndex = 54;
            label11.Text = "Descripcion/comments";
            // 
            // descripcionRequisaInput
            // 
            descripcionRequisaInput.Location = new Point(810, 50);
            descripcionRequisaInput.Margin = new Padding(2, 3, 2, 3);
            descripcionRequisaInput.Multiline = true;
            descripcionRequisaInput.Name = "descripcionRequisaInput";
            descripcionRequisaInput.Size = new Size(400, 88);
            descripcionRequisaInput.TabIndex = 53;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(549, 95);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 51;
            label6.Text = "Casa";
            // 
            // sucursalRequisaComboBox
            // 
            sucursalRequisaComboBox.FormattingEnabled = true;
            sucursalRequisaComboBox.Location = new Point(349, 92);
            sucursalRequisaComboBox.Margin = new Padding(3, 4, 3, 4);
            sucursalRequisaComboBox.Name = "sucursalRequisaComboBox";
            sucursalRequisaComboBox.Size = new Size(159, 28);
            sucursalRequisaComboBox.TabIndex = 50;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(280, 94);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 49;
            label5.Text = "Sucursal";
            // 
            // tipoAjusteRequisaComboBox
            // 
            tipoAjusteRequisaComboBox.FormattingEnabled = true;
            tipoAjusteRequisaComboBox.Items.AddRange(new object[] { "Faltante (-)", "Sobrante (+)", "Transferencia (-)", "Mal enviado (-)", "Reverso (-)", "Costo Cero (-)", "" });
            tipoAjusteRequisaComboBox.Location = new Point(644, 46);
            tipoAjusteRequisaComboBox.Margin = new Padding(3, 4, 3, 4);
            tipoAjusteRequisaComboBox.Name = "tipoAjusteRequisaComboBox";
            tipoAjusteRequisaComboBox.Size = new Size(105, 28);
            tipoAjusteRequisaComboBox.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(535, 48);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 47;
            label4.Text = "Tipo De Ajuste";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 48);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 46;
            label3.Text = "No. Documento:";
            // 
            // nDocumentoRequisaInput
            // 
            nDocumentoRequisaInput.Enabled = false;
            nDocumentoRequisaInput.Location = new Point(168, 46);
            nDocumentoRequisaInput.Margin = new Padding(2, 3, 2, 3);
            nDocumentoRequisaInput.Name = "nDocumentoRequisaInput";
            nDocumentoRequisaInput.Size = new Size(102, 27);
            nDocumentoRequisaInput.TabIndex = 45;
            nDocumentoRequisaInput.Text = "DOC-00001";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 29);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 53;
            label10.Text = "No. Parte:";
            // 
            // nParteAjusteInput
            // 
            nParteAjusteInput.Location = new Point(81, 24);
            nParteAjusteInput.Margin = new Padding(2, 3, 2, 3);
            nParteAjusteInput.Name = "nParteAjusteInput";
            nParteAjusteInput.Size = new Size(98, 27);
            nParteAjusteInput.TabIndex = 54;
            nParteAjusteInput.KeyDown += nParteAjusteComboBox_KeyDown;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(descripcionParteInput);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(cantidadParteInput);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(nParteAjusteInput);
            groupBox2.Location = new Point(9, 244);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(632, 68);
            groupBox2.TabIndex = 55;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos De Ajuste";
            // 
            // descripcionParteInput
            // 
            descripcionParteInput.Location = new Point(315, 24);
            descripcionParteInput.Margin = new Padding(3, 4, 3, 4);
            descripcionParteInput.Name = "descripcionParteInput";
            descripcionParteInput.Size = new Size(114, 27);
            descripcionParteInput.TabIndex = 58;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(191, 28);
            label13.Name = "label13";
            label13.Size = new Size(119, 20);
            label13.TabIndex = 57;
            label13.Text = "Descripcion Part.";
            // 
            // cantidadParteInput
            // 
            cantidadParteInput.Location = new Point(509, 24);
            cantidadParteInput.Margin = new Padding(2, 3, 2, 3);
            cantidadParteInput.Name = "cantidadParteInput";
            cantidadParteInput.Size = new Size(105, 27);
            cantidadParteInput.TabIndex = 56;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(439, 28);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 55;
            label12.Text = "Cantidad";
            // 
            // agregarButton
            // 
            agregarButton.BackColor = Color.RosyBrown;
            agregarButton.Location = new Point(669, 273);
            agregarButton.Margin = new Padding(2, 3, 2, 3);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(89, 32);
            agregarButton.TabIndex = 56;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = false;
            agregarButton.Click += agregarButton_Click;
            // 
            // guardarButton
            // 
            guardarButton.BackColor = Color.Lime;
            guardarButton.Location = new Point(883, 273);
            guardarButton.Margin = new Padding(2, 3, 2, 3);
            guardarButton.Name = "guardarButton";
            guardarButton.Size = new Size(89, 31);
            guardarButton.TabIndex = 57;
            guardarButton.Text = "Guardar";
            guardarButton.UseVisualStyleBackColor = false;
            guardarButton.Click += guardarButton_Click;
            // 
            // cargarPdfButton
            // 
            cargarPdfButton.Location = new Point(982, 274);
            cargarPdfButton.Margin = new Padding(3, 4, 3, 4);
            cargarPdfButton.Name = "cargarPdfButton";
            cargarPdfButton.Size = new Size(120, 31);
            cargarPdfButton.TabIndex = 58;
            cargarPdfButton.Text = "Cargar PDF";
            cargarPdfButton.UseVisualStyleBackColor = true;
            cargarPdfButton.Click += cargarPdfButton_Click;
            // 
            // importarExcelButton
            // 
            importarExcelButton.Location = new Point(1112, 273);
            importarExcelButton.Name = "importarExcelButton";
            importarExcelButton.Size = new Size(132, 32);
            importarExcelButton.TabIndex = 59;
            importarExcelButton.Text = "Importar Excel";
            importarExcelButton.UseVisualStyleBackColor = true;
            importarExcelButton.Click += importarExcelButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(770, 274);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 60;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // checkColumn
            // 
            checkColumn.DataPropertyName = "checkColumn";
            checkColumn.HeaderText = "Seleccionar";
            checkColumn.MinimumWidth = 6;
            checkColumn.Name = "checkColumn";
            checkColumn.Width = 125;
            // 
            // numeroParteColumn
            // 
            numeroParteColumn.DataPropertyName = "numeroParteColumn";
            numeroParteColumn.HeaderText = "No. de Parte";
            numeroParteColumn.MinimumWidth = 8;
            numeroParteColumn.Name = "numeroParteColumn";
            numeroParteColumn.Width = 150;
            // 
            // columcasa
            // 
            columcasa.DataPropertyName = "columcasa";
            columcasa.HeaderText = "Casa";
            columcasa.MinimumWidth = 8;
            columcasa.Name = "columcasa";
            columcasa.Width = 150;
            // 
            // sucursalColumn
            // 
            sucursalColumn.DataPropertyName = "sucursalColumn";
            sucursalColumn.HeaderText = "Sucursal";
            sucursalColumn.MinimumWidth = 8;
            sucursalColumn.Name = "sucursalColumn";
            sucursalColumn.Width = 150;
            // 
            // descripcionColumn
            // 
            descripcionColumn.DataPropertyName = "descripcionColumn";
            descripcionColumn.HeaderText = "Descripción";
            descripcionColumn.MinimumWidth = 8;
            descripcionColumn.Name = "descripcionColumn";
            descripcionColumn.Width = 150;
            // 
            // tipoAjusteColumn
            // 
            tipoAjusteColumn.DataPropertyName = "tipoAjusteColumn";
            tipoAjusteColumn.HeaderText = "Tipo de Ajuste";
            tipoAjusteColumn.MinimumWidth = 8;
            tipoAjusteColumn.Name = "tipoAjusteColumn";
            tipoAjusteColumn.Width = 150;
            // 
            // cantidadColumn
            // 
            cantidadColumn.DataPropertyName = "cantidadColumn";
            cantidadColumn.HeaderText = "Cantidad";
            cantidadColumn.MinimumWidth = 8;
            cantidadColumn.Name = "cantidadColumn";
            cantidadColumn.Width = 150;
            // 
            // costoUnitarioColumn
            // 
            costoUnitarioColumn.DataPropertyName = "costoUnitarioColumn";
            costoUnitarioColumn.HeaderText = "Costo Unit.";
            costoUnitarioColumn.MinimumWidth = 8;
            costoUnitarioColumn.Name = "costoUnitarioColumn";
            costoUnitarioColumn.Width = 150;
            // 
            // costoPromedioCOlumn
            // 
            costoPromedioCOlumn.DataPropertyName = "costoPromedioCOlumn";
            costoPromedioCOlumn.HeaderText = "Costo Promedio";
            costoPromedioCOlumn.MinimumWidth = 8;
            costoPromedioCOlumn.Name = "costoPromedioCOlumn";
            costoPromedioCOlumn.Width = 150;
            // 
            // costoPromedioExtendidoColumn
            // 
            costoPromedioExtendidoColumn.DataPropertyName = "costoPromedioExtendidoColumn";
            costoPromedioExtendidoColumn.HeaderText = "Costo Promedio Extendido";
            costoPromedioExtendidoColumn.MinimumWidth = 8;
            costoPromedioExtendidoColumn.Name = "costoPromedioExtendidoColumn";
            costoPromedioExtendidoColumn.Width = 150;
            // 
            // Nueva_Requisa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 676);
            Controls.Add(eliminarButton);
            Controls.Add(importarExcelButton);
            Controls.Add(cargarPdfButton);
            Controls.Add(guardarButton);
            Controls.Add(agregarButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Nueva_Requisa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NUEVA REQUISA";
            Load += Nueva_Requisa_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox sucursalRequisaComboBox;
        private Label label7;
        private Label label8;
        private ComboBox estadoRequisaComboBox;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private DataGridView table;
        private GroupBox groupBox1;
        private TextBox nDocumentoRequisaInput;
        private Label label10;
        private Label label6;
        private Label label5;
        private ComboBox tipoAjusteRequisaComboBox;
        private Label label4;
        private Label label3;
        private Label label11;
        private TextBox descripcionRequisaInput;
        private TextBox nParteAjusteInput;
        private GroupBox groupBox2;
        private TextBox cantidadParteInput;
        private Label label12;
        private Button agregarButton;
        private Button guardarButton;
        private ComboBox casaRequisaComboBox;
        private TextBox descripcionParteInput;
        private Label label13;
        private Button cargarPdfButton;
        private Button importarExcelButton;
        private Button eliminarButton;
        private DataGridViewCheckBoxColumn checkColumn;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn columcasa;
        private DataGridViewTextBoxColumn sucursalColumn;
        private DataGridViewTextBoxColumn descripcionColumn;
        private DataGridViewTextBoxColumn tipoAjusteColumn;
        private DataGridViewTextBoxColumn cantidadColumn;
        private DataGridViewTextBoxColumn costoUnitarioColumn;
        private DataGridViewTextBoxColumn costoPromedioCOlumn;
        private DataGridViewTextBoxColumn costoPromedioExtendidoColumn;
    }
}