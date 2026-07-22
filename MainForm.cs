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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            btnReportIssues.BackColor = Color.LightGray;

            this.Hide();
            using (ReportIssuesForm form = new ReportIssuesForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }


        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ViewIssuesForm form = new ViewIssuesForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevent closing
            }

            base.OnFormClosing(e);
        }


        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            btnServiceStatus.Enabled = false;
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            btnEvents.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyUnifiedTheme(this);

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
