namespace CapaVista.Components
{
    partial class ReporteDetalleCantidadRequisaEstado
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
            panel = new Panel();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            parametrosText = new GroupBox();
            generarReporteButton = new Button();
            label1 = new Label();
            estadoComboBox = new ComboBox();
            panel.SuspendLayout();
            parametrosText.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(reportViewer1);
            panel.Location = new Point(30, 129);
            panel.Name = "panel";
            panel.Size = new Size(1081, 524);
            panel.TabIndex = 10;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1081, 524);
            reportViewer1.TabIndex = 0;
            // 
            // parametrosText
            // 
            parametrosText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parametrosText.Controls.Add(estadoComboBox);
            parametrosText.Controls.Add(generarReporteButton);
            parametrosText.Controls.Add(label1);
            parametrosText.Location = new Point(30, 23);
            parametrosText.Name = "parametrosText";
            parametrosText.Size = new Size(1081, 100);
            parametrosText.TabIndex = 9;
            parametrosText.TabStop = false;
            parametrosText.Text = "Parámetros";
            // 
            // generarReporteButton
            // 
            generarReporteButton.Location = new Point(904, 36);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(171, 46);
            generarReporteButton.TabIndex = 5;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = true;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 30);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 3;
            label1.Text = "Estado:";
            // 
            // estadoComboBox
            // 
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(21, 57);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(378, 28);
            estadoComboBox.TabIndex = 6;
            // 
            // ReporteDetalleCantidadRequisaEstado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 717);
            Controls.Add(panel);
            Controls.Add(parametrosText);
            Name = "ReporteDetalleCantidadRequisaEstado";
            Text = "ReporteDetalleCantidadRequisaEstado";
            Load += ReporteDetalleCantidadRequisaEstado_Load;
            panel.ResumeLayout(false);
            parametrosText.ResumeLayout(false);
            parametrosText.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GroupBox parametrosText;
        private Button generarReporteButton;
        private Label label1;
        private ComboBox estadoComboBox;
    }
}