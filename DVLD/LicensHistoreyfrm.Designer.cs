namespace DVLD
{
    partial class LicensHistoreyfrm
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
            this.ctrlDriverLicenseHistorey1 = new DVLD.ctrlDriverLicenseHistorey();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseHistorey1
            // 
            this.ctrlDriverLicenseHistorey1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDriverLicenseHistorey1.Location = new System.Drawing.Point(12, 145);
            this.ctrlDriverLicenseHistorey1.Name = "ctrlDriverLicenseHistorey1";
            this.ctrlDriverLicenseHistorey1.Size = new System.Drawing.Size(929, 293);
            this.ctrlDriverLicenseHistorey1.TabIndex = 0;
            this.ctrlDriverLicenseHistorey1.Load += new System.EventHandler(this.ctrlDriverLicenseHistorey1_Load);
            // 
            // LicensHistoreyfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(962, 450);
            this.Controls.Add(this.ctrlDriverLicenseHistorey1);
            this.Name = "LicensHistoreyfrm";
            this.Text = "LicensHistoreyfrm";
            this.Load += new System.EventHandler(this.LicensHistoreyfrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDriverLicenseHistorey ctrlDriverLicenseHistorey1;
    }
}