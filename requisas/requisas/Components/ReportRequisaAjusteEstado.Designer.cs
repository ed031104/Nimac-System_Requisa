namespace CapaVista.Components
{
    partial class ReportRequisaAjusteEstado
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
            FechaFinalDatePicker = new DateTimePicker();
            label2 = new Label();
            fechaInicioDatePicker = new DateTimePicker();
            generarReporteButton = new Button();
            label1 = new Label();
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
            panel.Size = new Size(1081, 474);
            panel.TabIndex = 6;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1081, 474);
            reportViewer1.TabIndex = 0;
            // 
            // parametrosText
            // 
            parametrosText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parametrosText.Controls.Add(FechaFinalDatePicker);
            parametrosText.Controls.Add(label2);
            parametrosText.Controls.Add(fechaInicioDatePicker);
            parametrosText.Controls.Add(generarReporteButton);
            parametrosText.Controls.Add(label1);
            parametrosText.Location = new Point(12, 12);
            parametrosText.Name = "parametrosText";
            parametrosText.Size = new Size(1081, 94);
            parametrosText.TabIndex = 5;
            parametrosText.TabStop = false;
            parametrosText.Text = "Parámetros";
            // 
            // FechaFinalDatePicker
            // 
            FechaFinalDatePicker.Location = new Point(302, 55);
            FechaFinalDatePicker.Name = "FechaFinalDatePicker";
            FechaFinalDatePicker.Size = new Size(250, 27);
            FechaFinalDatePicker.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(302, 30);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 7;
            label2.Text = "Fecha final:";
            // 
            // fechaInicioDatePicker
            // 
            fechaInicioDatePicker.Location = new Point(17, 55);
            fechaInicioDatePicker.Name = "fechaInicioDatePicker";
            fechaInicioDatePicker.Size = new Size(250, 27);
            fechaInicioDatePicker.TabIndex = 6;
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
            label1.Size = new Size(111, 20);
            label1.TabIndex = 3;
            label1.Text = "Fecha de Inicio:";
            // 
            // ReportRequisaAjusteEstado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 598);
            Controls.Add(panel);
            Controls.Add(parametrosText);
            Name = "ReportRequisaAjusteEstado";
            Text = "ReportRequisaAjusteEstado";
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
        private DateTimePicker FechaFinalDatePicker;
        private Label label2;
        private DateTimePicker fechaInicioDatePicker;
    }
}