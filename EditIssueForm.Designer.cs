namespace MunicipalServicesApp
{
    partial class EditIssueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(51, 39);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(58, 16);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";

            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font(
                "Segoe UI",
                10.2F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(51, 61);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(390, 30);
            this.txtLocation.TabIndex = 1;

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(51, 121);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";

            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[]
            {
                "Sanitation",
                "Roads",
                "Utilities",
                "Electricity",
                "Water"
            });
            this.cmbCategory.Location = new System.Drawing.Point(51, 143);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(390, 24);
            this.cmbCategory.TabIndex = 3;

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(51, 197);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";

            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(51, 219);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(390, 130);
            this.txtDescription.TabIndex = 5;

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(291, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // EditIssueForm
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIssueForm";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Issue";
            this.Load += new System.EventHandler(this.EditIssueForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDescription;
    }
}