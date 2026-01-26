namespace DVLD
{
    partial class frmAddNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUser));
            this.lblMode = new System.Windows.Forms.Label();
            this.tabPageLoginInfo = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPagePersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.userControl22 = new DVLD.UserControl2();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPageLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPagePersonInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMode.Location = new System.Drawing.Point(317, 28);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(206, 32);
            this.lblMode.TabIndex = 9;
            this.lblMode.Text = "Add New User";
            // 
            // tabPageLoginInfo
            // 
            this.tabPageLoginInfo.Controls.Add(this.pictureBox2);
            this.tabPageLoginInfo.Controls.Add(this.pictureBox1);
            this.tabPageLoginInfo.Controls.Add(this.pictureBox5);
            this.tabPageLoginInfo.Controls.Add(this.pictureBox3);
            this.tabPageLoginInfo.Controls.Add(this.lblUserID);
            this.tabPageLoginInfo.Controls.Add(this.checkBoxIsActive);
            this.tabPageLoginInfo.Controls.Add(this.label1);
            this.tabPageLoginInfo.Controls.Add(this.label2);
            this.tabPageLoginInfo.Controls.Add(this.label3);
            this.tabPageLoginInfo.Controls.Add(this.txtUserName);
            this.tabPageLoginInfo.Controls.Add(this.txtPassword);
            this.tabPageLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tabPageLoginInfo.Controls.Add(this.label4);
            this.tabPageLoginInfo.Controls.Add(this.btnSave);
            this.tabPageLoginInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageLoginInfo.Name = "tabPageLoginInfo";
            this.tabPageLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoginInfo.Size = new System.Drawing.Size(791, 395);
            this.tabPageLoginInfo.TabIndex = 1;
            this.tabPageLoginInfo.Text = "Login Info";
            this.tabPageLoginInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(203, 163);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 31);
            this.pictureBox2.TabIndex = 73;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(203, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 31);
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(203, 126);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(41, 31);
            this.pictureBox5.TabIndex = 71;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(203, 83);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 31);
            this.pictureBox3.TabIndex = 70;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(265, 43);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(36, 16);
            this.lblUserID.TabIndex = 69;
            this.lblUserID.Text = "[???]";
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Location = new System.Drawing.Point(237, 212);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(79, 20);
            this.checkBoxIsActive.TabIndex = 8;
            this.checkBoxIsActive.Text = "Is Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "User ID";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(268, 86);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(204, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(268, 129);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(204, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(268, 172);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(204, 22);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(632, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 46);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPagePersonInfo
            // 
            this.tabPagePersonInfo.Controls.Add(this.btnNext);
            this.tabPagePersonInfo.Controls.Add(this.userControl22);
            this.tabPagePersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPagePersonInfo.Name = "tabPagePersonInfo";
            this.tabPagePersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersonInfo.Size = new System.Drawing.Size(791, 395);
            this.tabPagePersonInfo.TabIndex = 0;
            this.tabPagePersonInfo.Text = "Personal Info";
            this.tabPagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(632, 337);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(147, 40);
            this.btnNext.TabIndex = 69;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // userControl22
            // 
            this.userControl22.FilterByEnabled = true;
            this.userControl22.Location = new System.Drawing.Point(6, 6);
            this.userControl22.Name = "userControl22";
            this.userControl22.showAddPerson = true;
            this.userControl22.Size = new System.Drawing.Size(779, 371);
            this.userControl22.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePersonInfo);
            this.tabControl1.Controls.Add(this.tabPageLoginInfo);
            this.tabControl1.Location = new System.Drawing.Point(24, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 424);
            this.tabControl1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(660, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 46);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(843, 570);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAddNewUser";
            this.Text = "frmAddNewUser";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            this.tabPageLoginInfo.ResumeLayout(false);
            this.tabPageLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPagePersonInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TabPage tabPageLoginInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private UserControl2 userControl22;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}