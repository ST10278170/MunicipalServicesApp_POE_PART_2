namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblUpcomingEvents = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(157, 38);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(498, 36);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Local Events and Announcements";
            this.lblHeading.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(53, 118);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(147, 115);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(130, 24);
            this.cmbCategory.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(56, 171);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Location = new System.Drawing.Point(147, 171);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(250, 22);
            this.dtpEventDate.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(230, 218);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(59, 275);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersWidth = 51;
            this.dgvEvents.RowTemplate.Height = 24;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(650, 180);
            this.dgvEvents.TabIndex = 6;
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Location = new System.Drawing.Point(56, 474);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(145, 16);
            this.lblRecommendations.TabIndex = 7;
            this.lblRecommendations.Text = "Recommended Events";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 16;
            this.lstRecommendations.Location = new System.Drawing.Point(59, 504);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(400, 100);
            this.lstRecommendations.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(654, 594);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblUpcomingEvents
            // 
            this.lblUpcomingEvents.AutoSize = true;
            this.lblUpcomingEvents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingEvents.Location = new System.Drawing.Point(54, 244);
            this.lblUpcomingEvents.Name = "lblUpcomingEvents";
            this.lblUpcomingEvents.Size = new System.Drawing.Size(176, 28);
            this.lblUpcomingEvents.TabIndex = 10;
            this.lblUpcomingEvents.Text = "Upcoming Events";
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 653);
            this.Controls.Add(this.lblUpcomingEvents);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpEventDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblHeading);
            this.Name = "LocalEventsForm";
            this.Text = "Municipal Services - Local Events and Announcements";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblUpcomingEvents;
    }
}