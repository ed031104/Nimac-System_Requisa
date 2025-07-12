namespace CapaVista
{
    partial class reporte1
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
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(66, 20);
            label1.Name = "label1";
            label1.Size = new Size(347, 37);
            label1.TabIndex = 0;
            label1.Text = "Tabla de Reportes NIMAC";
            // 
            // button1
            // 
            button1.Location = new Point(66, 457);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(111, 39);
            button1.TabIndex = 1;
            button1.Text = "VER REPORTE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column2, Column1, Column3, Column4, Column5, Column6, Column8, Column7 });
            dataGridView1.Location = new Point(31, 133);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(877, 245);
            dataGridView1.TabIndex = 2;
            // 
            // Column2
            // 
            Column2.HeaderText = "No.";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Nombre del reporte";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Descripción";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Fecha de creación";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Usuario";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "Estado";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 125;
            // 
            // Column8
            // 
            Column8.HeaderText = "Fecha modificacion";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 125;
            // 
            // Column7
            // 
            Column7.HeaderText = "ultimo usuario modificacion";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 125;
            // 
            // reporte1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 695);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "reporte1";
            Text = "reporte1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column7;
    }
}