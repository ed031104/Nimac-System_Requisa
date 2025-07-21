namespace CapaVista.Components
{
    partial class ReportRequisaAjustes
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
            requisaComboBox = new ComboBox();
            label1 = new Label();
            generarReporteButton = new Button();
            panel.SuspendLayout();
            parametrosText.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(reportViewer1);
            panel.Location = new Point(12, 112);
            panel.Name = "panel";
            panel.Size = new Size(765, 391);
            panel.TabIndex = 4;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(765, 391);
            reportViewer1.TabIndex = 0;
            // 
            // parametrosText
            // 
            parametrosText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parametrosText.Controls.Add(generarReporteButton);
            parametrosText.Controls.Add(requisaComboBox);
            parametrosText.Controls.Add(label1);
            parametrosText.Location = new Point(12, 12);
            parametrosText.Name = "parametrosText";
            parametrosText.Size = new Size(765, 94);
            parametrosText.TabIndex = 3;
            parametrosText.TabStop = false;
            parametrosText.Text = "Parámetros";
            // 
            // requisaComboBox
            // 
            requisaComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            requisaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            requisaComboBox.FormattingEnabled = true;
            requisaComboBox.Location = new Point(17, 59);
            requisaComboBox.Name = "requisaComboBox";
            requisaComboBox.Size = new Size(151, 28);
            requisaComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 36);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 3;
            label1.Text = "Requisa:";
            // 
            // generarReporteButton
            // 
            generarReporteButton.Location = new Point(607, 59);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(152, 29);
            generarReporteButton.TabIndex = 5;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = true;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // ReportRequisaAjustes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 515);
            Controls.Add(panel);
            Controls.Add(parametrosText);
            Name = "ReportRequisaAjustes";
            Text = "ReportRequisaAjustes";
            Load += ReportRequisaAjustes_Load;
            panel.ResumeLayout(false);
            parametrosText.ResumeLayout(false);
            parametrosText.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GroupBox parametrosText;
        private ComboBox requisaComboBox;
        private Label label1;
        private Button generarReporteButton;
    }
}