namespace AsyncWindowsApplication
{
    partial class Form1
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
            this.refreshBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.userIdTxtBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.GroupUpaddBtn = new System.Windows.Forms.Button();
            this.GroupDeleteBtn = new System.Windows.Forms.Button();
            this.GroupUpdateBtn = new System.Windows.Forms.Button();
            this.GroupIdTextBox = new System.Windows.Forms.TextBox();
            this.GroupTitleTextBox = new System.Windows.Forms.TextBox();
            this.groupIdlabel = new System.Windows.Forms.Label();
            this.GroupTitleLabel = new System.Windows.Forms.Label();
            this.GroupListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(544, 11);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(226, 44);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(544, 58);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(106, 44);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(544, 106);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(106, 44);
            this.deleteBtn.TabIndex = 0;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(544, 153);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(106, 44);
            this.updateBtn.TabIndex = 0;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Location = new System.Drawing.Point(9, 8);
            this.userListBox.Margin = new System.Windows.Forms.Padding(2);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(315, 368);
            this.userListBox.TabIndex = 1;
            // 
            // userIdTxtBox
            // 
            this.userIdTxtBox.Location = new System.Drawing.Point(396, 21);
            this.userIdTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userIdTxtBox.Name = "userIdTxtBox";
            this.userIdTxtBox.Size = new System.Drawing.Size(144, 20);
            this.userIdTxtBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(396, 53);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(144, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(396, 82);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(144, 20);
            this.ageTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.IdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(362, 21);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(29, 20);
            this.IdLabel.TabIndex = 3;
            this.IdLabel.Text = "Id : ";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(396, 119);
            this.groupTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(144, 20);
            this.groupTextBox.TabIndex = 4;
            // 
            // AgeLabel
            // 
            this.AgeLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgeLabel.Location = new System.Drawing.Point(344, 82);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(47, 20);
            this.AgeLabel.TabIndex = 5;
            this.AgeLabel.Text = "Age : ";
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(329, 53);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(62, 20);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name : ";
            // 
            // GroupLabel
            // 
            this.GroupLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupLabel.Location = new System.Drawing.Point(329, 119);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(62, 20);
            this.GroupLabel.TabIndex = 7;
            this.GroupLabel.Text = "Group Id: ";
            // 
            // GroupUpaddBtn
            // 
            this.GroupUpaddBtn.BackColor = System.Drawing.Color.Red;
            this.GroupUpaddBtn.Location = new System.Drawing.Point(664, 56);
            this.GroupUpaddBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GroupUpaddBtn.Name = "GroupUpaddBtn";
            this.GroupUpaddBtn.Size = new System.Drawing.Size(106, 44);
            this.GroupUpaddBtn.TabIndex = 0;
            this.GroupUpaddBtn.Text = "Add";
            this.GroupUpaddBtn.UseVisualStyleBackColor = false;
            this.GroupUpaddBtn.Click += new System.EventHandler(this.GroupUpaddBtn_Click);
            // 
            // GroupDeleteBtn
            // 
            this.GroupDeleteBtn.BackColor = System.Drawing.Color.Red;
            this.GroupDeleteBtn.Location = new System.Drawing.Point(664, 104);
            this.GroupDeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GroupDeleteBtn.Name = "GroupDeleteBtn";
            this.GroupDeleteBtn.Size = new System.Drawing.Size(106, 44);
            this.GroupDeleteBtn.TabIndex = 0;
            this.GroupDeleteBtn.Text = "Delete";
            this.GroupDeleteBtn.UseVisualStyleBackColor = false;
            this.GroupDeleteBtn.Click += new System.EventHandler(this.GroupDeleteBtn_Click);
            // 
            // GroupUpdateBtn
            // 
            this.GroupUpdateBtn.BackColor = System.Drawing.Color.Red;
            this.GroupUpdateBtn.Location = new System.Drawing.Point(664, 151);
            this.GroupUpdateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GroupUpdateBtn.Name = "GroupUpdateBtn";
            this.GroupUpdateBtn.Size = new System.Drawing.Size(106, 44);
            this.GroupUpdateBtn.TabIndex = 0;
            this.GroupUpdateBtn.Text = "Update";
            this.GroupUpdateBtn.UseVisualStyleBackColor = false;
            this.GroupUpdateBtn.Click += new System.EventHandler(this.GroupUpdateBtn_Click);
            // 
            // GroupIdTextBox
            // 
            this.GroupIdTextBox.Location = new System.Drawing.Point(844, 24);
            this.GroupIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GroupIdTextBox.Name = "GroupIdTextBox";
            this.GroupIdTextBox.Size = new System.Drawing.Size(144, 20);
            this.GroupIdTextBox.TabIndex = 2;
            // 
            // GroupTitleTextBox
            // 
            this.GroupTitleTextBox.Location = new System.Drawing.Point(844, 56);
            this.GroupTitleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GroupTitleTextBox.Name = "GroupTitleTextBox";
            this.GroupTitleTextBox.Size = new System.Drawing.Size(144, 20);
            this.GroupTitleTextBox.TabIndex = 2;
            // 
            // groupIdlabel
            // 
            this.groupIdlabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupIdlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupIdlabel.Location = new System.Drawing.Point(810, 24);
            this.groupIdlabel.Name = "groupIdlabel";
            this.groupIdlabel.Size = new System.Drawing.Size(29, 20);
            this.groupIdlabel.TabIndex = 3;
            this.groupIdlabel.Text = "Id : ";
            // 
            // GroupTitleLabel
            // 
            this.GroupTitleLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTitleLabel.Location = new System.Drawing.Point(791, 56);
            this.GroupTitleLabel.Name = "GroupTitleLabel";
            this.GroupTitleLabel.Size = new System.Drawing.Size(48, 20);
            this.GroupTitleLabel.TabIndex = 6;
            this.GroupTitleLabel.Text = "Title : ";
            // 
            // GroupListBox
            // 
            this.GroupListBox.FormattingEnabled = true;
            this.GroupListBox.Location = new System.Drawing.Point(1005, 11);
            this.GroupListBox.Margin = new System.Windows.Forms.Padding(2);
            this.GroupListBox.Name = "GroupListBox";
            this.GroupListBox.Size = new System.Drawing.Size(212, 368);
            this.GroupListBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 389);
            this.Controls.Add(this.GroupListBox);
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.GroupTitleLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.groupIdlabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.GroupTitleTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.GroupIdTextBox);
            this.Controls.Add(this.userIdTxtBox);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.GroupUpdateBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.GroupDeleteBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.GroupUpaddBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.refreshBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.TextBox userIdTxtBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Button GroupUpaddBtn;
        private System.Windows.Forms.Button GroupDeleteBtn;
        private System.Windows.Forms.Button GroupUpdateBtn;
        private System.Windows.Forms.TextBox GroupIdTextBox;
        private System.Windows.Forms.TextBox GroupTitleTextBox;
        private System.Windows.Forms.Label groupIdlabel;
        private System.Windows.Forms.Label GroupTitleLabel;
        private System.Windows.Forms.ListBox GroupListBox;
    }
}

