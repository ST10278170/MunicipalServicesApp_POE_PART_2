using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MunicipalServicesApp
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();

            // Ensure each event is connected only once.
            this.Load -= SplashScreenForm_Load;
            this.Load += SplashScreenForm_Load;

            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_Tick;
        }

        private void SplashScreenForm_Load(
            object sender,
            EventArgs e)
        {
            ConfigureSplashScreen();
            ApplySplashTheme();
            CentreSplashContent();

            // Display the splash screen for 3.5 seconds.
            timer1.Interval = 3500;
            timer1.Start();
        }

        private void ConfigureSplashScreen()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.BackColor = Color.FromArgb(240, 244, 248);
        }

        private void ApplySplashTheme()
        {
            // Main application title.
            lblTitle.ForeColor = Color.FromArgb(0, 82, 155);
            lblTitle.Font = new Font(
                "Segoe UI",
                22,
                FontStyle.Bold);

            lblTitle.AutoSize = true;
            lblTitle.Text = "Municipal Services Application";

            // Loading message.
            lblLoading.ForeColor = Color.FromArgb(108, 117, 125);
            lblLoading.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Italic);

            lblLoading.AutoSize = true;
            lblLoading.Text = "Preparing municipal services...";
        }

        private void CentreSplashContent()
        {
            lblTitle.Left =
                (this.ClientSize.Width - lblTitle.Width) / 2;

            lblTitle.Top =
                (this.ClientSize.Height - lblTitle.Height) / 2 - 35;

            lblLoading.Left =
                (this.ClientSize.Width - lblLoading.Width) / 2;

            lblLoading.Top =
                lblTitle.Bottom + 25;
        }

        private void timer1_Tick(
            object sender,
            EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}