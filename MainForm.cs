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
            this.Hide();

            using (ReportIssuesForm form = new ReportIssuesForm())
            {
                form.ShowDialog();
            }

            this.Show();

            // Reapply the theme when returning to the Main Menu.
            ApplyUnifiedTheme(this);
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
            this.Hide();

            using (LocalEventsForm form = new LocalEventsForm())
            {
                form.ShowDialog();
            }

            this.Show();
        }




        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyUnifiedTheme(this);

            this.Font = new Font("Segoe UI", 10);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
        }

        private void ApplyUnifiedTheme(Control parent)
        {
            // Main background colour
            parent.BackColor = Color.FromArgb(240, 244, 248);

            foreach (Control ctrl in parent.Controls)
            {
                // Buttons
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(0, 122, 204);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                    btn.Cursor = Cursors.Hand;
                }

                // Labels
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(33, 37, 41);

                    // Main heading styling
                    if (lbl.Name.Contains("Heading"))
                    {
                        lbl.ForeColor = Color.FromArgb(0, 82, 155);

                        lbl.Font = new Font(
                            "Segoe UI",
                            18,
                            FontStyle.Bold);
                    }
                }

                // TextBoxes
                if (ctrl is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;

                    txt.Font = new Font(
                        "Segoe UI",
                        10);

                    txt.BackColor = Color.White;
                }

                // ComboBoxes
                if (ctrl is ComboBox cmb)
                {
                    cmb.Font = new Font(
                        "Segoe UI",
                        10);

                    cmb.BackColor = Color.White;
                }

                // ListBoxes
                if (ctrl is ListBox lst)
                {
                    lst.Font = new Font(
                        "Segoe UI",
                        10);

                    lst.BackColor = Color.White;
                }

                // DateTimePickers
                if (ctrl is DateTimePicker dtp)
                {
                    dtp.Font = new Font(
                        "Segoe UI",
                        10);
                }

                // DataGridView
                if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;

                    dgv.BorderStyle = BorderStyle.None;

                    dgv.GridColor = Color.LightGray;

                    dgv.EnableHeadersVisualStyles = false;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor =
                        Color.FromArgb(0, 122, 204);

                    dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                        Color.White;

                    dgv.ColumnHeadersDefaultCellStyle.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Bold);

                    dgv.DefaultCellStyle.Font =
                        new Font(
                            "Segoe UI",
                            10);

                    dgv.RowHeadersVisible = false;
                }

                // PictureBoxes
                if (ctrl is PictureBox pic)
                {
                    pic.BorderStyle = BorderStyle.FixedSingle;
                }

                // Recursively apply styling
                if (ctrl.HasChildren)
                {
                    ApplyUnifiedTheme(ctrl);
                }
            }
        }
    }
}
