using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Components
{
    public partial class Loading : UserControl
    {
        public int progresValue { get; set; } = 0;

        public Loading()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(75, Color.Black); // semi-transparente
            progressBar1.Minimum = progresValue;
            progressBar1.Maximum = 100; // Valor máximo del progreso
        }

        public void SetProgress(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El valor del progreso debe estar entre 0 y 100.");
            }
            progresValue = value;
            progressBar1.Value = progresValue;
        }
    }
}
