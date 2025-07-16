using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class reportView : Form
    {
        public reportView()
        {
            InitializeComponent();
        }

        private async void reporte1_Load(object sender, EventArgs e)
        {
            await layoutWeb.EnsureCoreWebView2Async();
        }

        public async Task CargarPdf(string name, Byte[] bytePdf)
        {
            try
            {
                string rutaPdf = Path.Combine(Path.GetTempPath(), name);
                File.WriteAllBytes(rutaPdf, bytePdf);
                layoutWeb.Source = new Uri($"file:///{rutaPdf.Replace("\\", "/")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el PDF: {ex.Message}");
                return;
            }
        }
    }
}
