namespace Archive
{
    partial class Login
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
            this.user_pw = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserPw = new System.Windows.Forms.Label();
            this.AdministratorCheckBox = new System.Windows.Forms.CheckBox();
            this.Administrator = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.Label();
            this.department_comboBox = new System.Windows.Forms.ComboBox();
            this.user_id = new System.Windows.Forms.TextBox();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // user_pw
            // 
            this.user_pw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_pw.Location = new System.Drawing.Point(152, 217);
            this.user_pw.Name = "user_pw";
            this.user_pw.Size = new System.Drawing.Size(450, 22);
            this.user_pw.TabIndex = 3;
            this.user_pw.TextChanged += new System.EventHandler(this.pwTextChanged);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.Location = new System.Drawing.Point(613, 304);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 39);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "ログイン";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserPw
            // 
            this.UserPw.AutoSize = true;
            this.UserPw.Location = new System.Drawing.Point(71, 220);
            this.UserPw.Name = "UserPw";
            this.UserPw.Size = new System.Drawing.Size(64, 15);
            this.UserPw.TabIndex = 10;
            this.UserPw.Text = "パスワード";
            // 
            // AdministratorCheckBox
            // 
            this.AdministratorCheckBox.AutoSize = true;
            this.AdministratorCheckBox.Location = new System.Drawing.Point(152, 260);
            this.AdministratorCheckBox.Name = "AdministratorCheckBox";
            this.AdministratorCheckBox.Size = new System.Drawing.Size(18, 17);
            this.AdministratorCheckBox.TabIndex = 4;
            this.AdministratorCheckBox.UseVisualStyleBackColor = true;
            // 
            // Administrator
            // 
            this.Administrator.AutoSize = true;
            this.Administrator.Location = new System.Drawing.Point(76, 260);
            this.Administrator.Name = "Administrator";
            this.Administrator.Size = new System.Drawing.Size(52, 15);
            this.Administrator.TabIndex = 11;
            this.Administrator.Text = "管理者";
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Location = new System.Drawing.Point(76, 159);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(37, 15);
            this.department.TabIndex = 7;
            this.department.Text = "部署";
            // 
            // UserId
            // 
            this.UserId.AutoSize = true;
            this.UserId.Location = new System.Drawing.Point(71, 192);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(69, 15);
            this.UserId.TabIndex = 8;
            this.UserId.Text = "ユーザーID";
            // 
            // department_comboBox
            // 
            this.department_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.department_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department_comboBox.FormattingEnabled = true;
            this.department_comboBox.Items.AddRange(new object[] {
            "",
            "BKS",
            "ZS"});
            this.department_comboBox.Location = new System.Drawing.Point(152, 156);
            this.department_comboBox.Name = "department_comboBox";
            this.department_comboBox.Size = new System.Drawing.Size(450, 23);
            this.department_comboBox.TabIndex = 0;
            // 
            // user_id
            // 
            this.user_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_id.Location = new System.Drawing.Point(152, 189);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(450, 22);
            this.user_id.TabIndex = 1;
            this.user_id.TextChanged += new System.EventHandler(this.userIdTextChanged);
            // 
            // AddUserButton
            // 
            this.AddUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddUserButton.Location = new System.Drawing.Point(613, 358);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(110, 39);
            this.AddUserButton.TabIndex = 6;
            this.AddUserButton.Text = "アカウント登録";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.user_id);
            this.Controls.Add(this.department_comboBox);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.department);
            this.Controls.Add(this.Administrator);
            this.Controls.Add(this.AdministratorCheckBox);
            this.Controls.Add(this.UserPw);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.user_pw);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Login";
            this.Text = "ログイン画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox user_pw;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label UserPw;
        private System.Windows.Forms.Label Administrator;
        public System.Windows.Forms.CheckBox AdministratorCheckBox;
        private System.Windows.Forms.Label department;
        private System.Windows.Forms.Label UserId;
        private System.Windows.Forms.ComboBox department_comboBox;
        private System.Windows.Forms.TextBox user_id;
        private System.Windows.Forms.Button AddUserButton;
    }
}