namespace CapaVista
{
    partial class reportView
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
            layoutWeb = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)layoutWeb).BeginInit();
            SuspendLayout();
            // 
            // layoutWeb
            // 
            layoutWeb.AllowExternalDrop = true;
            layoutWeb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            layoutWeb.CreationProperties = null;
            layoutWeb.DefaultBackgroundColor = Color.White;
            layoutWeb.Location = new Point(-8, 0);
            layoutWeb.Name = "layoutWeb";
            layoutWeb.Size = new Size(946, 696);
            layoutWeb.TabIndex = 3;
            layoutWeb.ZoomFactor = 1D;
            // 
            // reporte1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 695);
            Controls.Add(layoutWeb);
            Margin = new Padding(3, 4, 3, 4);
            Name = "reporte1";
            Text = "reporte1";
            Load += reporte1_Load;
            ((System.ComponentModel.ISupportInitialize)layoutWeb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 layoutWeb;
    }
}