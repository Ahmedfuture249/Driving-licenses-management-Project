namespace DVLD
{
    partial class ctrlShowLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlShowLicenseInof1 = new DVLD.ctrlShowLicenseInof();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInof1
            // 
            this.ctrlShowLicenseInof1.Location = new System.Drawing.Point(3, 56);
            this.ctrlShowLicenseInof1.Name = "ctrlShowLicenseInof1";
            this.ctrlShowLicenseInof1.Size = new System.Drawing.Size(891, 330);
            this.ctrlShowLicenseInof1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "LicenseID";
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(98, 21);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(208, 22);
            this.txtFindBy.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD.Properties.Resources.License_View_322;
            this.btnSearch.Location = new System.Drawing.Point(342, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(47, 34);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.btnSearch);
            this.groupBoxFilter.Controls.Add(this.txtFindBy);
            this.groupBoxFilter.Location = new System.Drawing.Point(16, 5);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(434, 59);
            this.groupBoxFilter.TabIndex = 9;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // ctrlShowLicenseInfoWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.ctrlShowLicenseInof1);
            this.Name = "ctrlShowLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(891, 389);
            this.Load += new System.EventHandler(this.ctrlShowLicenseInfoWithFilter_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowLicenseInof ctrlShowLicenseInof1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBoxFilter;
    }
}
