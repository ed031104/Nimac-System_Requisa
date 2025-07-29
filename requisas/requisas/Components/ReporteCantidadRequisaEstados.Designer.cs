namespace CapaVista.Components
{
    partial class ReporteCantidadRequisaEstados
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
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(reportViewer1);
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(1097, 588);
            panel.TabIndex = 9;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1097, 588);
            reportViewer1.TabIndex = 0;
            // 
            // ReporteCantidadRequisaEstados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 612);
            Controls.Add(panel);
            Name = "ReporteCantidadRequisaEstados";
            Text = "ReporteCantidadRequisaEstados";
            Load += ReporteCantidadRequisaEstados_Load;
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}