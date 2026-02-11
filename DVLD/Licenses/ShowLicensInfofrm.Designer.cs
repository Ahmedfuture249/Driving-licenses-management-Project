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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowLicenseInof1 = new DVLD.ctrlShowLicenseInof();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(305, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show License Info";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ctrlShowLicenseInof1
            // 
            this.ctrlShowLicenseInof1.Location = new System.Drawing.Point(-2, 174);
            this.ctrlShowLicenseInof1.Name = "ctrlShowLicenseInof1";
            this.ctrlShowLicenseInof1.Size = new System.Drawing.Size(889, 334);
            this.ctrlShowLicenseInof1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(293, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ShowLicensInfofrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(885, 506);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlShowLicenseInof1);
            this.Name = "ShowLicensInfofrm";
            this.Text = "ShowLicensInfofrm";
            this.Load += new System.EventHandler(this.ShowLicensInfofrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlShowLicenseInof ctrlShowLicenseInof1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}