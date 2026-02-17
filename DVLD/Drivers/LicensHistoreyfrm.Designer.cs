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
            this.userControl21 = new DVLD.UserControl2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseHistorey1
            // 
            this.ctrlDriverLicenseHistorey1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDriverLicenseHistorey1.Location = new System.Drawing.Point(21, 418);
            this.ctrlDriverLicenseHistorey1.Name = "ctrlDriverLicenseHistorey1";
            this.ctrlDriverLicenseHistorey1.Size = new System.Drawing.Size(929, 293);
            this.ctrlDriverLicenseHistorey1.TabIndex = 0;
            this.ctrlDriverLicenseHistorey1.Load += new System.EventHandler(this.ctrlDriverLicenseHistorey1_Load);
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.userControl21.FilterByEnabled = true;
            this.userControl21.Location = new System.Drawing.Point(205, 18);
            this.userControl21.Name = "userControl21";
            this.userControl21.showAddPerson = true;
            this.userControl21.Size = new System.Drawing.Size(726, 394);
            this.userControl21.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(21, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LicensHistoreyfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(936, 700);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.ctrlDriverLicenseHistorey1);
            this.Name = "LicensHistoreyfrm";
            this.Text = "LicensHistoreyfrm";
            this.Load += new System.EventHandler(this.LicensHistoreyfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDriverLicenseHistorey ctrlDriverLicenseHistorey1;
        private UserControl2 userControl21;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}