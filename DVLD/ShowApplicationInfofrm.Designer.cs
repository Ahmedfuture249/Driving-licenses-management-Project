namespace DVLD
{
    partial class ShowApplicationInfofrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseApplicationInfocs1 = new DVLD.ctrlDrivingLicenseApplicationInfocs();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Applicaation Detailes";
            // 
            // ctrlDrivingLicenseApplicationInfocs1
            // 
            this.ctrlDrivingLicenseApplicationInfocs1.Location = new System.Drawing.Point(12, 75);
            this.ctrlDrivingLicenseApplicationInfocs1.Name = "ctrlDrivingLicenseApplicationInfocs1";
            this.ctrlDrivingLicenseApplicationInfocs1.Size = new System.Drawing.Size(791, 326);
            this.ctrlDrivingLicenseApplicationInfocs1.TabIndex = 0;
            // 
            // ShowApplicationInfofrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(732, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfocs1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "ShowApplicationInfofrm";
            this.Text = "ShowApplicationInfofrm";
            this.Load += new System.EventHandler(this.ShowApplicationInfofrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfocs ctrlDrivingLicenseApplicationInfocs1;
        private System.Windows.Forms.Label label1;
    }
}