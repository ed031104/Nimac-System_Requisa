namespace requisas
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label3 = new Label();
            correoInput = new TextBox();
            label4 = new Label();
            ingresarButton = new Button();
            cancelarButton = new Button();
            contraseñaInput = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 7);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 135);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 7;
            label3.Text = "Correo:";
            // 
            // correoInput
            // 
            correoInput.Location = new Point(119, 131);
            correoInput.Margin = new Padding(3, 4, 3, 4);
            correoInput.Name = "correoInput";
            correoInput.Size = new Size(203, 27);
            correoInput.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 191);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 11;
            label4.Text = "Contraseña:";
            // 
            // ingresarButton
            // 
            ingresarButton.Location = new Point(111, 261);
            ingresarButton.Margin = new Padding(3, 4, 3, 4);
            ingresarButton.Name = "ingresarButton";
            ingresarButton.Size = new Size(103, 37);
            ingresarButton.TabIndex = 18;
            ingresarButton.Text = "Ingresar";
            ingresarButton.UseVisualStyleBackColor = true;
            ingresarButton.Click += btningresar_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(219, 261);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(103, 37);
            cancelarButton.TabIndex = 19;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += button2_Click;
            // 
            // contraseñaInput
            // 
            contraseñaInput.Location = new Point(119, 187);
            contraseñaInput.Margin = new Padding(3, 4, 3, 4);
            contraseñaInput.Name = "contraseñaInput";
            contraseñaInput.PasswordChar = '*';
            contraseñaInput.Size = new Size(203, 27);
            contraseñaInput.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(271, 319);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 36;
            label7.Text = "copyright © NIMAC";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 340);
            Controls.Add(label7);
            Controls.Add(contraseñaInput);
            Controls.Add(cancelarButton);
            Controls.Add(ingresarButton);
            Controls.Add(label4);
            Controls.Add(correoInput);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESION";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label3;
        private TextBox correoInput;
        private Label label4;
        private Button ingresarButton;
        private Button cancelarButton;
        private TextBox contraseñaInput;
        private Label label7;
    }
}
