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
    public partial class EditIssueForm : Form
    {
        private Issue _issue;

        public EditIssueForm(Issue issue)
        {
            InitializeComponent();
            _issue = issue;
        }

        private void EditIssueForm_Load(object sender, EventArgs e)
        {
            txtLocation.Text = _issue.Location;
            cmbCategory.Text = _issue.Category;
            txtDescription.Text = _issue.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _issue.Location = txtLocation.Text;
            _issue.Category = cmbCategory.Text;
            _issue.Description = txtDescription.Text;

            DialogResult = DialogResult.OK;
            Close();
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
