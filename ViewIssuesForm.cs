using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Font = System.Drawing.Font;

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
            ConfigureForm();
            ConfigureIssuesGrid();
            LoadFilterCategories();
            RefreshGrid();
        }

        private void ConfigureForm()
        {
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Municipal Services - Submitted Issues";
        }

        private void ConfigureIssuesGrid()
        {
            dgvIssues.ReadOnly = true;
            dgvIssues.AllowUserToAddRows = false;
            dgvIssues.AllowUserToDeleteRows = false;
            dgvIssues.MultiSelect = false;

            // Selecting any cell selects the complete issue record.
            dgvIssues.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvIssues.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvIssues.BackgroundColor = Color.White;
            dgvIssues.BorderStyle = BorderStyle.None;
            dgvIssues.GridColor = Color.FromArgb(220, 225, 230);
            dgvIssues.RowHeadersVisible = false;
            dgvIssues.EnableHeadersVisualStyles = false;

            dgvIssues.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 82, 155);

            dgvIssues.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvIssues.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvIssues.ColumnHeadersHeight = 38;

            dgvIssues.DefaultCellStyle.BackColor =
                Color.White;

            dgvIssues.DefaultCellStyle.ForeColor =
                Color.FromArgb(33, 37, 41);

            dgvIssues.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(207, 226, 243);

            dgvIssues.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(20, 46, 75);

            dgvIssues.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvIssues.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(247, 249, 252);
        }

        private void LoadFilterCategories()
        {
            cmbFilterCategory.Items.Clear();

            cmbFilterCategory.Items.Add("All Categories");
            cmbFilterCategory.Items.Add("Sanitation");
            cmbFilterCategory.Items.Add("Roads");
            cmbFilterCategory.Items.Add("Utilities");
            cmbFilterCategory.Items.Add("Electricity");
            cmbFilterCategory.Items.Add("Water");

            cmbFilterCategory.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            dgvIssues.DataSource = null;
            dgvIssues.DataSource = IssueRepository.Issues.ToList();

            EnableColumnSorting();

            if (dgvIssues.Rows.Count > 0)
            {
                dgvIssues.ClearSelection();

                dgvIssues.Rows[0].Selected = true;
                dgvIssues.CurrentCell =
                    dgvIssues.Rows[0].Cells[0];
            }
        }

        private void EnableColumnSorting()
        {
            foreach (DataGridViewColumn column in dgvIssues.Columns)
            {
                column.SortMode =
                    DataGridViewColumnSortMode.Automatic;
            }
        }

        private Issue GetSelectedIssue()
        {
            if (dgvIssues.CurrentRow == null)
            {
                return null;
            }

            return dgvIssues.CurrentRow.DataBoundItem as Issue;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyIssueFilter();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyIssueFilter();
        }

        private void ApplyIssueFilter()
        {
            string search =
                txtSearch.Text.Trim();

            string category =
                cmbFilterCategory.SelectedItem?.ToString()
                ?? "All Categories";

            var filteredIssues = IssueRepository.Issues
                .Where(issue =>
                    (string.IsNullOrWhiteSpace(search) ||
                     (!string.IsNullOrWhiteSpace(issue.Location) &&
                      issue.Location.IndexOf(
                          search,
                          StringComparison.OrdinalIgnoreCase) >= 0) ||
                     (!string.IsNullOrWhiteSpace(issue.Description) &&
                      issue.Description.IndexOf(
                          search,
                          StringComparison.OrdinalIgnoreCase) >= 0))
                    &&
                    (category == "All Categories" ||
                     string.Equals(
                         issue.Category,
                         category,
                         StringComparison.OrdinalIgnoreCase)))
                .ToList();

            dgvIssues.DataSource = null;
            dgvIssues.DataSource = filteredIssues;

            EnableColumnSorting();

            if (dgvIssues.Rows.Count > 0)
            {
                dgvIssues.ClearSelection();

                dgvIssues.Rows[0].Selected = true;
                dgvIssues.CurrentCell =
                    dgvIssues.Rows[0].Cells[0];
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            RefreshGrid();
        }

        private void dgvIssues_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            dgvIssues.ClearSelection();
            dgvIssues.Rows[e.RowIndex].Selected = true;
            dgvIssues.CurrentCell =
                dgvIssues.Rows[e.RowIndex].Cells[e.ColumnIndex];

            Issue selectedIssue =
                dgvIssues.Rows[e.RowIndex].DataBoundItem as Issue;

            if (selectedIssue == null)
            {
                return;
            }

            string details =
                "Issue Details\n\n" +
                $"Location: {selectedIssue.Location}\n" +
                $"Category: {selectedIssue.Category}\n" +
                $"Description: {selectedIssue.Description}\n" +
                $"Reported: {selectedIssue.CreatedAt:yyyy-MM-dd HH:mm}";

            MessageBox.Show(
                details,
                "Issue Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEditIssue_Click(object sender, EventArgs e)
        {
            Issue selectedIssue = GetSelectedIssue();

            if (selectedIssue == null)
            {
                MessageBox.Show(
                    "Please select an issue to edit.",
                    "Edit Issue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (EditIssueForm editForm =
                   new EditIssueForm(selectedIssue))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();

                    MessageBox.Show(
                        "Issue updated successfully.",
                        "Edit Issue",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteIssue_Click(object sender, EventArgs e)
        {
            Issue selectedIssue = GetSelectedIssue();

            if (selectedIssue == null)
            {
                MessageBox.Show(
                    "Please select an issue to delete.",
                    "Delete Issue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to delete this issue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            IssueRepository.Issues.Remove(selectedIssue);
            RefreshGrid();

            MessageBox.Show(
                "Issue deleted successfully.",
                "Delete Issue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (IssueRepository.Issues.Count == 0)
            {
                MessageBox.Show(
                    "No issues are available to export.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog saveDialog =
                   new SaveFileDialog())
            {
                saveDialog.Filter =
                    "CSV Files (*.csv)|*.csv";

                saveDialog.FileName =
                    "MunicipalIssues.csv";

                if (saveDialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                StringBuilder csvContent =
                    new StringBuilder();

                csvContent.AppendLine(
                    "Location,Category,Description,MediaPath,CreatedAt");

                foreach (Issue issue in IssueRepository.Issues)
                {
                    csvContent.AppendLine(
                        $"{EscapeCsv(issue.Location)}," +
                        $"{EscapeCsv(issue.Category)}," +
                        $"{EscapeCsv(issue.Description)}," +
                        $"{EscapeCsv(issue.MediaPath)}," +
                        $"{issue.CreatedAt:yyyy-MM-dd HH:mm}");
                }

                File.WriteAllText(
                    saveDialog.FileName,
                    csvContent.ToString());

                MessageBox.Show(
                    "Issues exported successfully.",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "\"\"";
            }

            return "\"" +
                   value.Replace("\"", "\"\"") +
                   "\"";
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (IssueRepository.Issues.Count == 0)
            {
                MessageBox.Show(
                    "No issues are available to export.",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog saveDialog =
                   new SaveFileDialog())
            {
                saveDialog.Filter =
                    "PDF Files (*.pdf)|*.pdf";

                saveDialog.FileName =
                    "MunicipalIssues.pdf";

                if (saveDialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                Document document =
                    new Document(
                        PageSize.A4,
                        40,
                        40,
                        40,
                        40);

                try
                {
                    PdfWriter.GetInstance(
                        document,
                        new FileStream(
                            saveDialog.FileName,
                            FileMode.Create));

                    document.Open();

                    iTextSharp.text.Font headerFont =
                        new iTextSharp.text.Font(
                            iTextSharp.text.Font.FontFamily.HELVETICA,
                            18,
                            iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Font bodyFont =
                        new iTextSharp.text.Font(
                            iTextSharp.text.Font.FontFamily.HELVETICA,
                            12,
                            iTextSharp.text.Font.NORMAL);

                    document.Add(
                        new Paragraph(
                            "Municipal Issues Report",
                            headerFont));

                    document.Add(
                        new Paragraph(
                            "Generated: " +
                            DateTime.Now.ToString(
                                "yyyy-MM-dd HH:mm"),
                            bodyFont));

                    document.Add(new Paragraph("\n"));

                    foreach (Issue issue
                             in IssueRepository.Issues)
                    {
                        Paragraph issueParagraph =
                            new Paragraph(
                                $"Location: {issue.Location}\n" +
                                $"Category: {issue.Category}\n" +
                                $"Description: {issue.Description}\n" +
                                $"Media: {issue.MediaPath}\n" +
                                $"Created: " +
                                $"{issue.CreatedAt:yyyy-MM-dd HH:mm}\n",
                                bodyFont);

                        document.Add(issueParagraph);

                        document.Add(
                            new Paragraph(
                                "----------------------------------------\n"));
                    }
                }
                finally
                {
                    if (document.IsOpen())
                    {
                        document.Close();
                    }
                }

                MessageBox.Show(
                    "PDF exported successfully.",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ApplyUnifiedTheme(Control parent)
        {
            parent.BackColor =
                Color.FromArgb(240, 244, 248);

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor =
                        Color.FromArgb(0, 122, 204);

                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                    btn.Cursor = Cursors.Hand;
                    btn.Height = Math.Max(btn.Height, 36);
                }

                if (ctrl is Label lbl)
                {
                    lbl.ForeColor =
                        Color.FromArgb(33, 37, 41);

                    lbl.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Regular);

                    if (lbl.Name.Contains("Heading"))
                    {
                        lbl.ForeColor =
                            Color.FromArgb(0, 82, 155);

                        lbl.Font = new Font(
                            "Segoe UI",
                            18,
                            FontStyle.Bold);
                    }
                }

                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;

                    txt.ForeColor =
                        Color.FromArgb(33, 37, 41);

                    txt.BorderStyle =
                        BorderStyle.FixedSingle;

                    txt.Font =
                        new Font("Segoe UI", 10);
                }

                if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;

                    cmb.ForeColor =
                        Color.FromArgb(33, 37, 41);

                    cmb.Font =
                        new Font("Segoe UI", 10);

                    cmb.DropDownStyle =
                        ComboBoxStyle.DropDownList;
                }

                if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;

                    dgv.GridColor =
                        Color.FromArgb(220, 225, 230);

                    dgv.EnableHeadersVisualStyles = false;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor =
                        Color.FromArgb(0, 82, 155);

                    dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                        Color.White;

                    dgv.ColumnHeadersDefaultCellStyle.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Bold);

                    dgv.ColumnHeadersHeight = 38;

                    dgv.DefaultCellStyle.BackColor =
                        Color.White;

                    dgv.DefaultCellStyle.ForeColor =
                        Color.FromArgb(33, 37, 41);

                    dgv.DefaultCellStyle.SelectionBackColor =
                        Color.FromArgb(207, 226, 243);

                    dgv.DefaultCellStyle.SelectionForeColor =
                        Color.FromArgb(20, 46, 75);

                    dgv.DefaultCellStyle.Font =
                        new Font("Segoe UI", 10);

                    dgv.AlternatingRowsDefaultCellStyle.BackColor =
                        Color.FromArgb(247, 249, 252);

                    dgv.RowHeadersVisible = false;

                    dgv.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dgv.MultiSelect = false;
                }

                if (ctrl.HasChildren)
                {
                    ApplyUnifiedTheme(ctrl);
                }
            }
        }
    }
}