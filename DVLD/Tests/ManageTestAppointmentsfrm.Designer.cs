namespace DVLD
{
    partial class ManageTestAppointmentsfrm
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
            this.ctrlDrivingLicenseApplicationInfocs1 = new DVLD.ctrlDrivingLicenseApplicationInfocs();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGetAllAppointments = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNeAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfocs1
            // 
            this.ctrlDrivingLicenseApplicationInfocs1.LocalDrivingLicenseApplicationID = 0;
            this.ctrlDrivingLicenseApplicationInfocs1.Location = new System.Drawing.Point(5, 186);
            this.ctrlDrivingLicenseApplicationInfocs1.Name = "ctrlDrivingLicenseApplicationInfocs1";
            this.ctrlDrivingLicenseApplicationInfocs1.Size = new System.Drawing.Size(710, 321);
            this.ctrlDrivingLicenseApplicationInfocs1.TabIndex = 0;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(-93, 533);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(23, 25);
            this.lblRecordsCount.TabIndex = 28;
            this.lblRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-209, 533);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "#ٌ Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-209, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Appointments";
            // 
            // dgvGetAllAppointments
            // 
            this.dgvGetAllAppointments.AllowUserToAddRows = false;
            this.dgvGetAllAppointments.AllowUserToDeleteRows = false;
            this.dgvGetAllAppointments.AllowUserToOrderColumns = true;
            this.dgvGetAllAppointments.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGetAllAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAllAppointments.Location = new System.Drawing.Point(16, 565);
            this.dgvGetAllAppointments.Name = "dgvGetAllAppointments";
            this.dgvGetAllAppointments.ReadOnly = true;
            this.dgvGetAllAppointments.RowHeadersWidth = 51;
            this.dgvGetAllAppointments.RowTemplate.Height = 24;
            this.dgvGetAllAppointments.Size = new System.Drawing.Size(692, 162);
            this.dgvGetAllAppointments.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(278, 130);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 35);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Vision Test";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 56);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.driving_test_512;
            this.pictureBox1.Location = new System.Drawing.Point(258, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNeAppointment
            // 
            this.btnAddNeAppointment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddNeAppointment.Image = global::DVLD.Properties.Resources.AddAppointment_32;
            this.btnAddNeAppointment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddNeAppointment.Location = new System.Drawing.Point(630, 514);
            this.btnAddNeAppointment.Name = "btnAddNeAppointment";
            this.btnAddNeAppointment.Size = new System.Drawing.Size(67, 45);
            this.btnAddNeAppointment.TabIndex = 25;
            this.btnAddNeAppointment.UseVisualStyleBackColor = false;
            this.btnAddNeAppointment.Click += new System.EventHandler(this.btnAddNeAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(459, 748);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(249, 41);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_323;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_323;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // ManageTestAppointmentsfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(738, 797);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNeAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvGetAllAppointments);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfocs1);
            this.Name = "ManageTestAppointmentsfrm";
            this.Text = "ManageTestAppointmentsfrm";
            this.Load += new System.EventHandler(this.ManageTestAppointmentsfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfocs ctrlDrivingLicenseApplicationInfocs1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNeAppointment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvGetAllAppointments;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}