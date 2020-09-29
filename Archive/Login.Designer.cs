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
            this.user_name = new System.Windows.Forms.TextBox();
            this.user_pw = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.Label();
            this.UserPw = new System.Windows.Forms.Label();
            this.AdministratorCheckBox = new System.Windows.Forms.CheckBox();
            this.Administrator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // user_name
            // 
            this.user_name.Location = new System.Drawing.Point(126, 131);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(298, 22);
            this.user_name.TabIndex = 6;
            // 
            // user_pw
            // 
            this.user_pw.Location = new System.Drawing.Point(126, 199);
            this.user_pw.Name = "user_pw";
            this.user_pw.Size = new System.Drawing.Size(298, 22);
            this.user_pw.TabIndex = 7;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(461, 332);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 39);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "ログイン";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(39, 134);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(70, 15);
            this.UserName.TabIndex = 10;
            this.UserName.Text = "ユーザー名";
            // 
            // UserPw
            // 
            this.UserPw.AutoSize = true;
            this.UserPw.Location = new System.Drawing.Point(45, 202);
            this.UserPw.Name = "UserPw";
            this.UserPw.Size = new System.Drawing.Size(64, 15);
            this.UserPw.TabIndex = 11;
            this.UserPw.Text = "パスワード";
            // 
            // AdministratorCheckBox
            // 
            this.AdministratorCheckBox.AutoSize = true;
            this.AdministratorCheckBox.Location = new System.Drawing.Point(126, 260);
            this.AdministratorCheckBox.Name = "AdministratorCheckBox";
            this.AdministratorCheckBox.Size = new System.Drawing.Size(18, 17);
            this.AdministratorCheckBox.TabIndex = 12;
            this.AdministratorCheckBox.UseVisualStyleBackColor = true;
            // 
            // Administrator
            // 
            this.Administrator.AutoSize = true;
            this.Administrator.Location = new System.Drawing.Point(51, 260);
            this.Administrator.Name = "Administrator";
            this.Administrator.Size = new System.Drawing.Size(52, 15);
            this.Administrator.TabIndex = 13;
            this.Administrator.Text = "管理者";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 449);
            this.Controls.Add(this.Administrator);
            this.Controls.Add(this.AdministratorCheckBox);
            this.Controls.Add(this.UserPw);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.user_pw);
            this.Controls.Add(this.user_name);
            this.Name = "Login";
            this.Text = "ログイン画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.TextBox user_pw;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label UserPw;
        private System.Windows.Forms.Label Administrator;
        public System.Windows.Forms.CheckBox AdministratorCheckBox;
    }
}