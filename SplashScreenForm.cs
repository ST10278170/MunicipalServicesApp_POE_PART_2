using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3500; // 3.5 seconds
            timer1.Start();
            ApplyUnifiedTheme(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close(); // Splash screen closes automatically
        }

        private void ApplyUnifiedTheme(Control parent)
        {
            // Form background
            parent.BackColor = Color.WhiteSmoke;

            foreach (Control ctrl in parent.Controls)
            {
                // Style buttons
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.SteelBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }

                // Style labels
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.Black;
                }

                // Engagement label (special styling)
                if (ctrl.Name == "lblEngagement")
                {
                    ctrl.ForeColor = Color.DimGray;
                    ctrl.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }

                // Picture preview border
                if (ctrl is PictureBox pic)
                {
                    pic.BorderStyle = BorderStyle.FixedSingle;
                }

                // Recursively style nested controls (panels, group boxes)
                if (ctrl.HasChildren)
                {
                    ApplyUnifiedTheme(ctrl);
                }
            }
        }

    }
}
