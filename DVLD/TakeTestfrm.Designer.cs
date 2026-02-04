namespace DVLD
{
    partial class TakeTestfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeTestfrm));
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbyes = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlTakeTest1 = new DVLD.ctrlTakeTest();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(4, 528);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(361, 67);
            this.txtNotes.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Notes";
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(197, 486);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(46, 20);
            this.rbNo.TabIndex = 71;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbyes
            // 
            this.rbyes.AutoSize = true;
            this.rbyes.Location = new System.Drawing.Point(120, 486);
            this.rbyes.Name = "rbyes";
            this.rbyes.Size = new System.Drawing.Size(52, 20);
            this.rbyes.TabIndex = 70;
            this.rbyes.TabStop = true;
            this.rbyes.Text = "Yes";
            this.rbyes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Is Passed";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(216, 617);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 46);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlTakeTest1
            // 
            this.ctrlTakeTest1.Location = new System.Drawing.Point(4, 12);
            this.ctrlTakeTest1.Name = "ctrlTakeTest1";
            this.ctrlTakeTest1.Size = new System.Drawing.Size(370, 478);
            this.ctrlTakeTest1.TabIndex = 0;
            // 
            // TakeTestfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 678);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbNo);
            this.Controls.Add(this.rbyes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlTakeTest1);
            this.Name = "TakeTestfrm";
            this.Text = "TakeTestfrm";
            this.Load += new System.EventHandler(this.TakeTestfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlTakeTest ctrlTakeTest1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbyes;
        private System.Windows.Forms.Label label2;
    }
}