namespace DVLD
{
    partial class IssueLicense
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
            this.ctrlDrivingLicenseApplicationInfocs1 = new DVLD.ctrlDrivingLicenseApplicationInfocs();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnissue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfocs1
            // 
            this.ctrlDrivingLicenseApplicationInfocs1.LocalDrivingLicenseApplicationID = 0;
            this.ctrlDrivingLicenseApplicationInfocs1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDrivingLicenseApplicationInfocs1.Name = "ctrlDrivingLicenseApplicationInfocs1";
            this.ctrlDrivingLicenseApplicationInfocs1.Size = new System.Drawing.Size(713, 328);
            this.ctrlDrivingLicenseApplicationInfocs1.TabIndex = 0;
            this.ctrlDrivingLicenseApplicationInfocs1.Load += new System.EventHandler(this.ctrlDrivingLicenseApplicationInfocs1_Load);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(12, 361);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(577, 77);
            this.txtNotes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes :";
            // 
            // btnclose
            // 
            this.btnclose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(455, 450);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(134, 46);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            // 
            // btnissue
            // 
            this.btnissue.Image = global::DVLD.Properties.Resources.License_View_321;
            this.btnissue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnissue.Location = new System.Drawing.Point(601, 450);
            this.btnissue.Name = "btnissue";
            this.btnissue.Size = new System.Drawing.Size(134, 46);
            this.btnissue.TabIndex = 3;
            this.btnissue.Text = "Issue";
            this.btnissue.UseVisualStyleBackColor = true;
            this.btnissue.Click += new System.EventHandler(this.btnissue_Click);
            // 
            // IssueLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(737, 512);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnissue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfocs1);
            this.Name = "IssueLicense";
            this.Text = "IssueLicense";
            this.Load += new System.EventHandler(this.IssueLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfocs ctrlDrivingLicenseApplicationInfocs1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnissue;
        private System.Windows.Forms.Button btnclose;
    }
}