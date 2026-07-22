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
    public partial class ReportIssuesForm : Form
    {
        public ReportIssuesForm()
        {
            InitializeComponent();
        }


        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            ApplyUnifiedTheme(this);

            cmbCategory.Items.Add("Sanitation");
            cmbCategory.Items.Add("Roads");
            cmbCategory.Items.Add("Utilities");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Water");
        }


        private string _mediaPath;

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images and Documents|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _mediaPath = ofd.FileName;
                    lblEngagement.Text = "Attachment added. Thank you for providing more detail.";

                    // Show preview only for images
                    if (ofd.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        ofd.FileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        ofd.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        picPreview.Image = Image.FromFile(ofd.FileName);
                    }
                    else
                    {
                        picPreview.Image = null; // No preview for documents
                    }
                }
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // CONFIRMATION FIRST
            DialogResult result = MessageBox.Show(
                "Submit this report?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; // User cancelled
            }

            // VALIDATION FIRST (before clearing fields)
            bool locationError = string.IsNullOrWhiteSpace(txtLocation.Text);
            bool categoryError = cmbCategory.SelectedItem == null;
            bool descriptionError = string.IsNullOrWhiteSpace(rtbDescription.Text);

            HighlightControl(txtLocation, locationError);
            HighlightControl(cmbCategory, categoryError);
            HighlightControl(rtbDescription, descriptionError);

            if (locationError || categoryError || descriptionError)
            {
                MessageBox.Show("Please complete all required fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblEngagement.Text = "Let’s complete all fields so your report can help the community.";
                return;
            }

            // CREATE ISSUE OBJECT
            Issue issue = new Issue
            {
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text,
                MediaPath = _mediaPath,
                CreatedAt = DateTime.Now
            };

            IssueRepository.Issues.Add(issue);

            MessageBox.Show("Your issue has been submitted. Thank you for helping improve municipal services.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblEngagement.Text = "Great job reporting this issue—your input supports better service delivery.";

            // CLEAR FIELDS AFTER SUCCESS
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            picPreview.Image = null;
            _mediaPath = null;

            // Reset highlight colors
            HighlightControl(txtLocation, false);
            HighlightControl(cmbCategory, false);
            HighlightControl(rtbDescription, false);
        }


        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HighlightControl(Control control, bool hasError)
        {
            control.BackColor = hasError ? Color.LightPink : Color.White;
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            // Optional: open full image preview
            if (!string.IsNullOrEmpty(_mediaPath) &&
                (_mediaPath.EndsWith(".jpg") || _mediaPath.EndsWith(".jpeg") || _mediaPath.EndsWith(".png")))
            {
                System.Diagnostics.Process.Start(_mediaPath);
            }
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Clear all fields?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            picPreview.Image = null;
            _mediaPath = null;

            HighlightControl(txtLocation, false);
            HighlightControl(cmbCategory, false);
            HighlightControl(rtbDescription, false);

            lblEngagement.Text = "Fields cleared. You can start a new report anytime.";
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
