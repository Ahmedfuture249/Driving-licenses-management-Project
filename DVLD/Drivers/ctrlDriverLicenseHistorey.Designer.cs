namespace DVLD
{
    partial class ctrlDriverLicenseHistorey
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
            this.tabcontrol1 = new System.Windows.Forms.TabControl();
            this.tbLocal = new System.Windows.Forms.TabPage();
            this.tbinternational = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListLocalLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabcontrol1.SuspendLayout();
            this.tbLocal.SuspendLayout();
            this.tbinternational.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontrol1
            // 
            this.tabcontrol1.Controls.Add(this.tbLocal);
            this.tabcontrol1.Controls.Add(this.tbinternational);
            this.tabcontrol1.Location = new System.Drawing.Point(6, 21);
            this.tabcontrol1.Name = "tabcontrol1";
            this.tabcontrol1.SelectedIndex = 0;
            this.tabcontrol1.Size = new System.Drawing.Size(895, 255);
            this.tabcontrol1.TabIndex = 0;
            // 
            // tbLocal
            // 
            this.tbLocal.Controls.Add(this.label2);
            this.tbLocal.Controls.Add(this.dgvListLocalLicenses);
            this.tbLocal.Location = new System.Drawing.Point(4, 25);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocal.Size = new System.Drawing.Size(887, 226);
            this.tbLocal.TabIndex = 0;
            this.tbLocal.Text = "Local";
            this.tbLocal.UseVisualStyleBackColor = true;
            this.tbLocal.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tbinternational
            // 
            this.tbinternational.Controls.Add(this.label1);
            this.tbinternational.Controls.Add(this.dgvListInternationalLicenses);
            this.tbinternational.Location = new System.Drawing.Point(4, 25);
            this.tbinternational.Name = "tbinternational";
            this.tbinternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbinternational.Size = new System.Drawing.Size(887, 226);
            this.tbinternational.TabIndex = 1;
            this.tbinternational.Text = "International";
            this.tbinternational.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.tabcontrol1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Licenses Historey";
            // 
            // dgvListInternationalLicenses
            // 
            this.dgvListInternationalLicenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListInternationalLicenses.Location = new System.Drawing.Point(16, 22);
            this.dgvListInternationalLicenses.Name = "dgvListInternationalLicenses";
            this.dgvListInternationalLicenses.RowHeadersWidth = 51;
            this.dgvListInternationalLicenses.RowTemplate.Height = 24;
            this.dgvListInternationalLicenses.Size = new System.Drawing.Size(853, 198);
            this.dgvListInternationalLicenses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Local Licenses";
            // 
            // dgvListLocalLicenses
            // 
            this.dgvListLocalLicenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListLocalLicenses.Location = new System.Drawing.Point(17, 30);
            this.dgvListLocalLicenses.Name = "dgvListLocalLicenses";
            this.dgvListLocalLicenses.RowHeadersWidth = 51;
            this.dgvListLocalLicenses.RowTemplate.Height = 24;
            this.dgvListLocalLicenses.Size = new System.Drawing.Size(853, 182);
            this.dgvListLocalLicenses.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "List Local Licenses";
            // 
            // ctrlDriverLicenseHistorey
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenseHistorey";
            this.Size = new System.Drawing.Size(913, 288);
            this.tabcontrol1.ResumeLayout(false);
            this.tbLocal.ResumeLayout(false);
            this.tbLocal.PerformLayout();
            this.tbinternational.ResumeLayout(false);
            this.tbinternational.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrol1;
        private System.Windows.Forms.TabPage tbLocal;
        private System.Windows.Forms.TabPage tbinternational;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListLocalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListInternationalLicenses;
    }
}
