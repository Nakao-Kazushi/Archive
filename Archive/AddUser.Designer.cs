namespace Archive
{
    partial class AddUser
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
            this.user_id = new System.Windows.Forms.TextBox();
            this.user_name = new System.Windows.Forms.TextBox();
            this.user_pw = new System.Windows.Forms.TextBox();
            this.user_pw2 = new System.Windows.Forms.TextBox();
            this.UserPw2 = new System.Windows.Forms.Label();
            this.UserPw = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.Label();
            this.userAddButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.department_comboBox = new System.Windows.Forms.ComboBox();
            this.department = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // user_id
            // 
            this.user_id.Location = new System.Drawing.Point(169, 144);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(298, 22);
            this.user_id.TabIndex = 1;
            // 
            // user_name
            // 
            this.user_name.Location = new System.Drawing.Point(169, 172);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(298, 22);
            this.user_name.TabIndex = 2;
            // 
            // user_pw
            // 
            this.user_pw.Location = new System.Drawing.Point(169, 200);
            this.user_pw.Name = "user_pw";
            this.user_pw.Size = new System.Drawing.Size(298, 22);
            this.user_pw.TabIndex = 3;
            // 
            // user_pw2
            // 
            this.user_pw2.Location = new System.Drawing.Point(169, 228);
            this.user_pw2.Name = "user_pw2";
            this.user_pw2.Size = new System.Drawing.Size(298, 22);
            this.user_pw2.TabIndex = 4;
            // 
            // UserPw2
            // 
            this.UserPw2.AutoSize = true;
            this.UserPw2.Location = new System.Drawing.Point(43, 231);
            this.UserPw2.Name = "UserPw2";
            this.UserPw2.Size = new System.Drawing.Size(109, 15);
            this.UserPw2.TabIndex = 11;
            this.UserPw2.Text = "パスワード再入力";
            // 
            // UserPw
            // 
            this.UserPw.AutoSize = true;
            this.UserPw.Location = new System.Drawing.Point(71, 203);
            this.UserPw.Name = "UserPw";
            this.UserPw.Size = new System.Drawing.Size(64, 15);
            this.UserPw.TabIndex = 10;
            this.UserPw.Text = "パスワード";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(70, 175);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(70, 15);
            this.UserName.TabIndex = 9;
            this.UserName.Text = "ユーザー名";
            // 
            // UserId
            // 
            this.UserId.AutoSize = true;
            this.UserId.Location = new System.Drawing.Point(71, 147);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(69, 15);
            this.UserId.TabIndex = 8;
            this.UserId.Text = "ユーザーID";
            // 
            // userAddButton
            // 
            this.userAddButton.Location = new System.Drawing.Point(424, 301);
            this.userAddButton.Name = "userAddButton";
            this.userAddButton.Size = new System.Drawing.Size(75, 41);
            this.userAddButton.TabIndex = 5;
            this.userAddButton.Text = "登録";
            this.userAddButton.UseVisualStyleBackColor = true;
            this.userAddButton.Click += new System.EventHandler(this.userAddButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(518, 301);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 41);
            this.returnButton.TabIndex = 6;
            this.returnButton.Text = "戻る";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // department_comboBox
            // 
            this.department_comboBox.FormattingEnabled = true;
            this.department_comboBox.Items.AddRange(new object[] {
            "",
            "BKS",
            "ZS"});
            this.department_comboBox.Location = new System.Drawing.Point(169, 115);
            this.department_comboBox.Name = "department_comboBox";
            this.department_comboBox.Size = new System.Drawing.Size(121, 23);
            this.department_comboBox.TabIndex = 0;
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Location = new System.Drawing.Point(71, 118);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(37, 15);
            this.department.TabIndex = 7;
            this.department.Text = "部署";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 412);
            this.Controls.Add(this.department_comboBox);
            this.Controls.Add(this.department);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.userAddButton);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.UserPw);
            this.Controls.Add(this.UserPw2);
            this.Controls.Add(this.user_pw2);
            this.Controls.Add(this.user_pw);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.user_id);
            this.Name = "AddUser";
            this.Text = "ユーザー登録";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_id;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.TextBox user_pw;
        private System.Windows.Forms.TextBox user_pw2;
        private System.Windows.Forms.Label UserPw2;
        private System.Windows.Forms.Label UserPw;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label UserId;
        private System.Windows.Forms.Button userAddButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.ComboBox department_comboBox;
        private System.Windows.Forms.Label department;
    }
}