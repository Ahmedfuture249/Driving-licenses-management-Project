namespace DVLD
{
    partial class ManageLocalDrivingLicensesApplicationfrm
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
            this.components = new System.ComponentModel.Container();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterByValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvGetAllApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showApplicationDetailesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicensesHistoreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVisioinTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemwrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(118, 690);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(23, 25);
            this.lblRecordsCount.TabIndex = 19;
            this.lblRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 690);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "#ٌ Records";
            // 
            // txtFilterByValue
            // 
            this.txtFilterByValue.Location = new System.Drawing.Point(257, 232);
            this.txtFilterByValue.Name = "txtFilterByValue";
            this.txtFilterByValue.Size = new System.Drawing.Size(146, 22);
            this.txtFilterByValue.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(411, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Manage Local Driving Licenses Applications";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID             ",
            "First Name            ",
            "Last Name             ",
            "Third Name            ",
            "Nationality CountryID ",
            "National No           ",
            "Gendor              ",
            "Email                ",
            "Phone                            ",
            "DateOfBirth  ",
            "CountryID        "});
            this.cbFilterBy.Location = new System.Drawing.Point(99, 232);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(133, 24);
            this.cbFilterBy.TabIndex = 12;
            // 
            // dgvGetAllApplications
            // 
            this.dgvGetAllApplications.AllowUserToAddRows = false;
            this.dgvGetAllApplications.AllowUserToDeleteRows = false;
            this.dgvGetAllApplications.AllowUserToOrderColumns = true;
            this.dgvGetAllApplications.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGetAllApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAllApplications.Location = new System.Drawing.Point(12, 262);
            this.dgvGetAllApplications.Name = "dgvGetAllApplications";
            this.dgvGetAllApplications.ReadOnly = true;
            this.dgvGetAllApplications.RowHeadersWidth = 51;
            this.dgvGetAllApplications.RowTemplate.Height = 24;
            this.dgvGetAllApplications.Size = new System.Drawing.Size(1389, 400);
            this.dgvGetAllApplications.TabIndex = 10;
            this.dgvGetAllApplications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGetAllPeople_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailesToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicatonToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicensesHistoreyToolStripMenuItem,
            this.sheduleTestToolStripMenuItem,
            this.shduleTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(297, 266);
            // 
            // shduleTestToolStripMenuItem
            // 
            this.shduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.shduleTestToolStripMenuItem.Name = "shduleTestToolStripMenuItem";
            this.shduleTestToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.shduleTestToolStripMenuItem.Text = "Shedule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.writtenTestToolStripMenuItem.Text = "Written Test";
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            // 
            // showApplicationDetailesToolStripMenuItem
            // 
            this.showApplicationDetailesToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_322;
            this.showApplicationDetailesToolStripMenuItem.Name = "showApplicationDetailesToolStripMenuItem";
            this.showApplicationDetailesToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showApplicationDetailesToolStripMenuItem.Text = "Show Application Detailes";
            this.showApplicationDetailesToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailesToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_322;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicatonToolStripMenuItem
            // 
            this.deleteApplicatonToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.deleteApplicatonToolStripMenuItem.Name = "deleteApplicatonToolStripMenuItem";
            this.deleteApplicatonToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.deleteApplicatonToolStripMenuItem.Text = "Delete Applicaton";
            this.deleteApplicatonToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicatonToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_322;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicensesHistoreyToolStripMenuItem
            // 
            this.showPersonLicensesHistoreyToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicensesHistoreyToolStripMenuItem.Name = "showPersonLicensesHistoreyToolStripMenuItem";
            this.showPersonLicensesHistoreyToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showPersonLicensesHistoreyToolStripMenuItem.Text = "Show person Licenses Historey";
            // 
            // sheduleTestToolStripMenuItem
            // 
            this.sheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemVisioinTest,
            this.toolStripMenuItemwrittenTest,
            this.toolStripMenuItemStreetTest});
            this.sheduleTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_32;
            this.sheduleTestToolStripMenuItem.Name = "sheduleTestToolStripMenuItem";
            this.sheduleTestToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.sheduleTestToolStripMenuItem.Text = "Shedule Test";
            this.sheduleTestToolStripMenuItem.Click += new System.EventHandler(this.sheduleTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItemVisioinTest
            // 
            this.toolStripMenuItemVisioinTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.toolStripMenuItemVisioinTest.Name = "toolStripMenuItemVisioinTest";
            this.toolStripMenuItemVisioinTest.Size = new System.Drawing.Size(171, 26);
            this.toolStripMenuItemVisioinTest.Text = "Vision Test";
            // 
            // toolStripMenuItemwrittenTest
            // 
            this.toolStripMenuItemwrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.toolStripMenuItemwrittenTest.Name = "toolStripMenuItemwrittenTest";
            this.toolStripMenuItemwrittenTest.Size = new System.Drawing.Size(171, 26);
            this.toolStripMenuItemwrittenTest.Text = "Written Test";
            // 
            // toolStripMenuItemStreetTest
            // 
            this.toolStripMenuItemStreetTest.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.toolStripMenuItemStreetTest.Name = "toolStripMenuItemStreetTest";
            this.toolStripMenuItemStreetTest.Size = new System.Drawing.Size(171, 26);
            this.toolStripMenuItemStreetTest.Text = "Street Test";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(748, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1326, 183);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(75, 76);
            this.btnAddNewPerson.TabIndex = 16;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(611, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(1164, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(237, 41);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ManageLocalDrivingLicensesApplicationfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 724);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterByValue);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvGetAllApplications);
            this.Name = "ManageLocalDrivingLicensesApplicationfrm";
            this.Text = "ManageLocalDrivingLicensesApplicationfrm";
            this.Load += new System.EventHandler(this.ManageLocalDrivingLicensesApplicationfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterByValue;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvGetAllApplications;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVisioinTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemwrittenTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStreetTest;
        private System.Windows.Forms.ToolStripMenuItem shduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
    }
}