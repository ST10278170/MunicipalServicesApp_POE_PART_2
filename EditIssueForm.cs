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
    public partial class EditIssueForm : Form
    {
        private readonly Issue _issue;

        public EditIssueForm(Issue issue)
        {
            InitializeComponent();

            _issue = issue ??
                throw new ArgumentNullException(nameof(issue));
        }

        private void EditIssueForm_Load(object sender, EventArgs e)
        {
            // Apply the modern municipal theme.
            ApplyUnifiedTheme(this);

            // Configure the form.
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Edit Municipal Issue";

            // Load the selected issue into the controls.
            txtLocation.Text = _issue.Location;
            cmbCategory.SelectedItem = _issue.Category;
            txtDescription.Text = _issue.Description;

            // Fallback if the original category is not selected.
            if (cmbCategory.SelectedIndex == -1)
            {
                cmbCategory.Text = _issue.Category;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool locationMissing =
                string.IsNullOrWhiteSpace(txtLocation.Text);

            bool categoryMissing =
                string.IsNullOrWhiteSpace(cmbCategory.Text);

            bool descriptionMissing =
                string.IsNullOrWhiteSpace(txtDescription.Text);

            HighlightControl(txtLocation, locationMissing);
            HighlightControl(cmbCategory, categoryMissing);
            HighlightControl(txtDescription, descriptionMissing);

            if (locationMissing ||
                categoryMissing ||
                descriptionMissing)
            {
                MessageBox.Show(
                    "Please complete the location, category and description.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Save the changes made to this issue?",
                "Confirm Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            _issue.Location = txtLocation.Text.Trim();
            _issue.Category = cmbCategory.Text;
            _issue.Description = txtDescription.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void HighlightControl(
            Control control,
            bool hasError)
        {
            control.BackColor = hasError
                ? Color.MistyRose
                : Color.White;
        }

        private void ApplyUnifiedTheme(Control parent)
        {
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
                    btn.Height = Math.Max(btn.Height, 38);
                }

                // Labels
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(33, 37, 41);
                    lbl.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);
                }

                // Text entry controls
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = Color.FromArgb(33, 37, 41);
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 10);
                }

                // Category selection
                if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.FromArgb(33, 37, 41);
                    cmb.Font = new Font("Segoe UI", 10);
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                }

                // Theme controls inside panels or group boxes.
                if (ctrl.HasChildren)
                {
                    ApplyUnifiedTheme(ctrl);
                }
            }
        }
    }
}