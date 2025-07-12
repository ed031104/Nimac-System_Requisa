namespace CapaVista
{
    partial class GestionPartes
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
            label3 = new Label();
            codigoInput = new TextBox();
            editarButton = new Button();
            eliminarButton = new Button();
            crearButton = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            descripcionInput = new TextBox();
            numeroParteInput = new TextBox();
            table = new DataGridView();
            numeroParteColumn = new DataGridViewTextBoxColumn();
            decripcionParteColumn = new DataGridViewTextBoxColumn();
            fechaRegistroColumn = new DataGridViewTextBoxColumn();
            fechaModificacionColumn = new DataGridViewTextBoxColumn();
            MostrarButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 183);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 18;
            label3.Text = "Código:";
            // 
            // codigoInput
            // 
            codigoInput.Location = new Point(90, 180);
            codigoInput.Name = "codigoInput";
            codigoInput.Size = new Size(221, 27);
            codigoInput.TabIndex = 17;
            codigoInput.KeyDown += códigoInput_KeyDown;
            // 
            // editarButton
            // 
            editarButton.Location = new Point(601, 178);
            editarButton.Name = "editarButton";
            editarButton.Size = new Size(94, 29);
            editarButton.TabIndex = 16;
            editarButton.Text = "Editar";
            editarButton.UseVisualStyleBackColor = true;
            editarButton.Click += editarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(719, 178);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 15;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // crearButton
            // 
            crearButton.Location = new Point(469, 178);
            crearButton.Name = "crearButton";
            crearButton.Size = new Size(94, 29);
            crearButton.TabIndex = 14;
            crearButton.Text = "Crear";
            crearButton.UseVisualStyleBackColor = true;
            crearButton.Click += crearButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(descripcionInput);
            groupBox1.Controls.Add(numeroParteInput);
            groupBox1.Location = new Point(23, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(790, 113);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(390, 57);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 7;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 6;
            label1.Text = "Número de parte:";
            // 
            // descripcionInput
            // 
            descripcionInput.Location = new Point(486, 50);
            descripcionInput.Name = "descripcionInput";
            descripcionInput.Size = new Size(125, 27);
            descripcionInput.TabIndex = 1;
            // 
            // numeroParteInput
            // 
            numeroParteInput.Location = new Point(168, 50);
            numeroParteInput.Name = "numeroParteInput";
            numeroParteInput.Size = new Size(125, 27);
            numeroParteInput.TabIndex = 0;
            // 
            // table
            // 
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { numeroParteColumn, decripcionParteColumn, fechaRegistroColumn, fechaModificacionColumn });
            table.Location = new Point(14, 237);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(799, 259);
            table.TabIndex = 12;
            table.CellClick += table_CellClick;
            // 
            // numeroParteColumn
            // 
            numeroParteColumn.DataPropertyName = "numeroParteColumn";
            numeroParteColumn.HeaderText = "Número de Parte";
            numeroParteColumn.MinimumWidth = 6;
            numeroParteColumn.Name = "numeroParteColumn";
            numeroParteColumn.ReadOnly = true;
            numeroParteColumn.Width = 125;
            // 
            // decripcionParteColumn
            // 
            decripcionParteColumn.DataPropertyName = "decripcionParteColumn";
            decripcionParteColumn.HeaderText = "Descripción Parte";
            decripcionParteColumn.MinimumWidth = 6;
            decripcionParteColumn.Name = "decripcionParteColumn";
            decripcionParteColumn.ReadOnly = true;
            decripcionParteColumn.Width = 125;
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
            // MostrarButton
            // 
            MostrarButton.Location = new Point(330, 180);
            MostrarButton.Name = "MostrarButton";
            MostrarButton.Size = new Size(94, 29);
            MostrarButton.TabIndex = 19;
            MostrarButton.Text = "👁";
            MostrarButton.UseVisualStyleBackColor = true;
            MostrarButton.Click += MostrarButton_Click;
            // 
            // GestionPartes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 540);
            Controls.Add(MostrarButton);
            Controls.Add(label3);
            Controls.Add(codigoInput);
            Controls.Add(editarButton);
            Controls.Add(eliminarButton);
            Controls.Add(crearButton);
            Controls.Add(groupBox1);
            Controls.Add(table);
            Name = "GestionPartes";
            Text = "GestionPartes";
            Load += GestionPartes_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox codigoInput;
        private Button editarButton;
        private Button eliminarButton;
        private Button crearButton;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox descripcionInput;
        private TextBox numeroParteInput;
        private DataGridView table;
        private DataGridViewTextBoxColumn numeroParteColumn;
        private DataGridViewTextBoxColumn decripcionParteColumn;
        private DataGridViewTextBoxColumn fechaRegistroColumn;
        private DataGridViewTextBoxColumn fechaModificacionColumn;
        private Button MostrarButton;
    }
}