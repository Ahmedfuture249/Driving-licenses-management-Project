namespace DVLD
{
    partial class UserControl2
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
            this.components = new System.ComponentModel.Container();
            this.userControl11 = new DVLD.UserControl1();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gbFilterBY = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterBY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(3, 71);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(701, 334);
            this.userControl11.TabIndex = 1;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbFilterBy.Location = new System.Drawing.Point(121, 21);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(208, 24);
            this.cbFilterBy.TabIndex = 2;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gbFilterBY
            // 
            this.gbFilterBY.Controls.Add(this.btnAddPerson);
            this.gbFilterBY.Controls.Add(this.label1);
            this.gbFilterBY.Controls.Add(this.txtFindBy);
            this.gbFilterBY.Controls.Add(this.btnFindPerson);
            this.gbFilterBY.Controls.Add(this.cbFilterBy);
            this.gbFilterBY.Location = new System.Drawing.Point(3, 13);
            this.gbFilterBY.Name = "gbFilterBY";
            this.gbFilterBY.Size = new System.Drawing.Size(701, 64);
            this.gbFilterBY.TabIndex = 3;
            this.gbFilterBY.TabStop = false;
            this.gbFilterBY.Text = "Filter by";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(627, 11);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(47, 34);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter By";
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(350, 21);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(208, 22);
            this.txtFindBy.TabIndex = 4;
            this.txtFindBy.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindBy_KeyPress);
            this.txtFindBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtFindBy_Validating);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnFindPerson.Location = new System.Drawing.Point(575, 11);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(47, 34);
            this.btnFindPerson.TabIndex = 0;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UserControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbFilterBY);
            this.Controls.Add(this.userControl11);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(733, 387);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            this.gbFilterBY.ResumeLayout(false);
            this.gbFilterBY.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindPerson;
        private UserControl1 userControl11;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox gbFilterBY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
