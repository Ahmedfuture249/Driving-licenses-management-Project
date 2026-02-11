namespace DVLD
{
    partial class FindPersonfrm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.userControl21 = new DVLD.UserControl2();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find Person";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(502, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(231, 49);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // userControl21
            // 
            this.userControl21.FilterByEnabled = true;
            this.userControl21.Location = new System.Drawing.Point(12, 55);
            this.userControl21.Name = "userControl21";
            this.userControl21.showAddPerson = false;
            this.userControl21.Size = new System.Drawing.Size(721, 371);
            this.userControl21.TabIndex = 0;
            this.userControl21.Load += new System.EventHandler(this.userControl21_Load);
            // 
            // FindPersonfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 494);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControl21);
            this.Name = "FindPersonfrm";
            this.Text = "FindPersonfrm";
            this.Load += new System.EventHandler(this.FindPersonfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl2 userControl21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}