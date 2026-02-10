namespace DVLD
{
    partial class ShowLicensInfofrm
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
            this.ctrlShowLicenseInof1 = new DVLD.ctrlShowLicenseInof();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInof1
            // 
            this.ctrlShowLicenseInof1.Location = new System.Drawing.Point(12, 113);
            this.ctrlShowLicenseInof1.Name = "ctrlShowLicenseInof1";
            this.ctrlShowLicenseInof1.Size = new System.Drawing.Size(980, 325);
            this.ctrlShowLicenseInof1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(370, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show License Info";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ShowLicensInfofrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(993, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlShowLicenseInof1);
            this.Name = "ShowLicensInfofrm";
            this.Text = "ShowLicensInfofrm";
            this.Load += new System.EventHandler(this.ShowLicensInfofrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlShowLicenseInof ctrlShowLicenseInof1;
        private System.Windows.Forms.Label label1;
    }
}