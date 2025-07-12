namespace CapaVista
{
    partial class ReporteUsuarios
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            parametrosText = new GroupBox();
            fechaModificacionPicker = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            NombreInput = new TextBox();
            idUsuarioInput = new TextBox();
            panel = new Panel();
            parametrosText.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(881, 472);
            reportViewer1.TabIndex = 0;
            // 
            // parametrosText
            // 
            parametrosText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            parametrosText.Controls.Add(fechaModificacionPicker);
            parametrosText.Controls.Add(label3);
            parametrosText.Controls.Add(label2);
            parametrosText.Controls.Add(label1);
            parametrosText.Controls.Add(NombreInput);
            parametrosText.Controls.Add(idUsuarioInput);
            parametrosText.Location = new Point(12, 12);
            parametrosText.Name = "parametrosText";
            parametrosText.Size = new Size(881, 94);
            parametrosText.TabIndex = 1;
            parametrosText.TabStop = false;
            parametrosText.Text = "Parámetros";
            // 
            // fechaModificacionPicker
            // 
            fechaModificacionPicker.Location = new Point(352, 59);
            fechaModificacionPicker.Name = "fechaModificacionPicker";
            fechaModificacionPicker.Size = new Size(250, 27);
            fechaModificacionPicker.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(352, 36);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 5;
            label3.Text = "Fecha Modificación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 36);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 36);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 3;
            label1.Text = "ID Usuario:";
            // 
            // NombreInput
            // 
            NombreInput.Location = new Point(192, 59);
            NombreInput.Name = "NombreInput";
            NombreInput.Size = new Size(125, 27);
            NombreInput.TabIndex = 1;
            // 
            // idUsuarioInput
            // 
            idUsuarioInput.Location = new Point(17, 59);
            idUsuarioInput.Name = "idUsuarioInput";
            idUsuarioInput.Size = new Size(125, 27);
            idUsuarioInput.TabIndex = 0;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(reportViewer1);
            panel.Location = new Point(12, 112);
            panel.Name = "panel";
            panel.Size = new Size(881, 472);
            panel.TabIndex = 2;
            // 
            // ReporteUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 596);
            Controls.Add(panel);
            Controls.Add(parametrosText);
            Name = "ReporteUsuarios";
            Text = "ReporteUsuarios";
            Load += ReporteUsuarios_Load;
            parametrosText.ResumeLayout(false);
            parametrosText.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GroupBox parametrosText;
        private DateTimePicker fechaModificacionPicker;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox NombreInput;
        private TextBox idUsuarioInput;
        private Panel panel;
    }
}