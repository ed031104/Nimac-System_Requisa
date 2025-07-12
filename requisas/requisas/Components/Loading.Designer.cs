namespace CapaVista.Components
{
    partial class Loading
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_reloj_de_arena;
            pictureBox1.Location = new Point(394, 216);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(97, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(387, 330);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 1;
            label1.Text = "Cargando...";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.ButtonShadow;
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 250);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(245, 29);
            progressBar1.TabIndex = 0;
            // 
            // Loading
            // 
            Controls.Add(progressBar1);
            Name = "Loading";
            Size = new Size(245, 279);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        public ProgressBar progressBar1;
    }
}