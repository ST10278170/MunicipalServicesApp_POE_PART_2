using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewIssuesForm : Form
    {
        public ViewIssuesForm()
        {
            InitializeComponent();
        }

        private void ViewIssuesForm_Load(object sender, EventArgs e)
        {
            ApplyUnifiedTheme(this);


            // Bind issues to grid
            dgvIssues.DataSource = IssueRepository.Issues;

            // Enable sorting on all columns
            foreach (DataGridViewColumn column in dgvIssues.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Load categories into filter dropdown
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Sanitation");
            cmbFilterCategory.Items.Add("Roads");
            cmbFilterCategory.Items.Add("Utilities");
            cmbFilterCategory.Items.Add("Electricity");
            cmbFilterCategory.Items.Add("Water");
            cmbFilterCategory.Items.Insert(0, "All Categories");

            cmbFilterCategory.SelectedIndex = 0;

       
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower().Trim();
            string category = cmbFilterCategory.SelectedItem.ToString();

            var filtered = IssueRepository.Issues
                .Where(i =>
                    (string.IsNullOrEmpty(search) ||
                     i.Location.ToLower().Contains(search) ||
                     i.Description.ToLower().Contains(search))
                    &&
                    (category == "All Categories" || i.Category == category)
                )
                .ToList();

            dgvIssues.DataSource = filtered;
        }


        private void dgvIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Issue selectedIssue = dgvIssues.Rows[e.RowIndex].DataBoundItem as Issue;
            if (selectedIssue == null) return;

            string details =
                "=== Issue Details ===\n" +
                $"• Location:     {selectedIssue.Location}\n" +
                $"• Category:     {selectedIssue.Category}\n" +
                $"• Description:  {selectedIssue.Description}\n" +
                $"• Reported:     {selectedIssue.CreatedAt:yyyy-MM-dd HH:mm}\n";

            MessageBox.Show(details, "Issue Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower().Trim();
            string category = cmbFilterCategory.SelectedItem.ToString();

            var filtered = IssueRepository.Issues
                .Where(i =>
                    // Search filter
                    (string.IsNullOrEmpty(search) ||
                     i.Location.ToLower().Contains(search) ||
                     i.Description.ToLower().Contains(search))
                    &&
                    // Category filter
                    (category == "All Categories" || i.Category == category)
                )
                .ToList();

            dgvIssues.DataSource = filtered;
        }


        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            dgvIssues.DataSource = IssueRepository.Issues;
        }


        private void RefreshGrid()
        {
            dgvIssues.DataSource = null;
            dgvIssues.DataSource = IssueRepository.Issues;
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


        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (IssueRepository.Issues.Count == 0)
            {
                MessageBox.Show("No issues available to export.", "Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "MunicipalIssues.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Location,Category,Description,MediaPath,CreatedAt");

                    foreach (var issue in IssueRepository.Issues)
                    {
                        sb.AppendLine(
                            $"{Escape(issue.Location)}," +
                            $"{Escape(issue.Category)}," +
                            $"{Escape(issue.Description)}," +
                            $"{Escape(issue.MediaPath)}," +
                            $"{issue.CreatedAt:yyyy-MM-dd HH:mm}"
                        );
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString());

                    MessageBox.Show("Issues exported successfully.", "Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private void btnDeleteIssue_Click(object sender, EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an issue to delete.", "Delete Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Issue selectedIssue = dgvIssues.SelectedRows[0].DataBoundItem as Issue;

            if (selectedIssue == null)
                return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this issue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                IssueRepository.Issues.Remove(selectedIssue);
                RefreshGrid();

                MessageBox.Show("Issue deleted successfully.", "Delete Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditIssue_Click(object sender, EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an issue to edit.", "Edit Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Issue selectedIssue = dgvIssues.SelectedRows[0].DataBoundItem as Issue;

            if (selectedIssue == null)
                return;

            // Open a simple edit dialog
            using (EditIssueForm editForm = new EditIssueForm(selectedIssue))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                    MessageBox.Show("Issue updated successfully.", "Edit Issue",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (IssueRepository.Issues.Count == 0)
            {
                MessageBox.Show("No issues available to export.", "Export PDF",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = "MunicipalIssues.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    doc.Open();

                    // Header font
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA,
                        18,
                        iTextSharp.text.Font.BOLD
                    );

                    // Body font
                    iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA,
                        12,
                        iTextSharp.text.Font.NORMAL
                    );

                    // Title
                    doc.Add(new Paragraph("Municipal Issues Report", headerFont));
                    doc.Add(new Paragraph("Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"), bodyFont));
                    doc.Add(new Paragraph("\n"));

                    // Loop through issues
                    foreach (var issue in IssueRepository.Issues)
                    {
                        Paragraph p = new Paragraph(
                            $"Location: {issue.Location}\n" +
                            $"Category: {issue.Category}\n" +
                            $"Description: {issue.Description}\n" +
                            $"Media: {issue.MediaPath}\n" +
                            $"Created: {issue.CreatedAt:yyyy-MM-dd HH:mm}\n",
                            bodyFont
                        );

                        doc.Add(p);
                        doc.Add(new Paragraph("--------------------------------------------\n"));
                    }

                    doc.Close();

                    MessageBox.Show("PDF exported successfully.", "Export PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
