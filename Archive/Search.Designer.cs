namespace Archive
{
    partial class Search
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
            this.label2 = new System.Windows.Forms.Label();
            this.book_id = new System.Windows.Forms.TextBox();
            this.book_name = new System.Windows.Forms.TextBox();
            this.expiredCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.requestButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.bookListView = new System.Windows.Forms.DataGridView();
            this.approvalButton = new System.Windows.Forms.Button();
            this.adminiCheckBox = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.AdduserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "書籍ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "書籍名";
            // 
            // book_id
            // 
            this.book_id.Location = new System.Drawing.Point(105, 42);
            this.book_id.Name = "book_id";
            this.book_id.Size = new System.Drawing.Size(109, 22);
            this.book_id.TabIndex = 2;
            // 
            // book_name
            // 
            this.book_name.Location = new System.Drawing.Point(352, 42);
            this.book_name.Name = "book_name";
            this.book_name.Size = new System.Drawing.Size(119, 22);
            this.book_name.TabIndex = 3;
            // 
            // expiredCheckBox
            // 
            this.expiredCheckBox.AutoSize = true;
            this.expiredCheckBox.Location = new System.Drawing.Point(105, 82);
            this.expiredCheckBox.Name = "expiredCheckBox";
            this.expiredCheckBox.Size = new System.Drawing.Size(18, 17);
            this.expiredCheckBox.TabIndex = 4;
            this.expiredCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "返却期限切れのみ抽出する";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(541, 82);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(107, 37);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "選択";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "書籍ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "書籍名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "貸出日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(564, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "返却期日";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(718, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "状態";
            // 
            // requestButton
            // 
            this.requestButton.Location = new System.Drawing.Point(703, 388);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(75, 35);
            this.requestButton.TabIndex = 13;
            this.requestButton.Text = "申請";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(541, 388);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 35);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "編集";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(622, 388);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 35);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // bookListView
            // 
            this.bookListView.AllowUserToAddRows = false;
            this.bookListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookListView.Location = new System.Drawing.Point(53, 180);
            this.bookListView.Name = "bookListView";
            this.bookListView.RowHeadersVisible = false;
            this.bookListView.RowHeadersWidth = 51;
            this.bookListView.RowTemplate.Height = 24;
            this.bookListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bookListView.Size = new System.Drawing.Size(725, 202);
            this.bookListView.TabIndex = 19;
            this.bookListView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookListView_CellValueChanged);
            this.bookListView.CurrentCellDirtyStateChanged += new System.EventHandler(this.bookListView_CurrentCellDirtyStateChanged);
            // 
            // approvalButton
            // 
            this.approvalButton.Location = new System.Drawing.Point(53, 388);
            this.approvalButton.Name = "approvalButton";
            this.approvalButton.Size = new System.Drawing.Size(75, 35);
            this.approvalButton.TabIndex = 20;
            this.approvalButton.Text = "承認";
            this.approvalButton.UseVisualStyleBackColor = true;
            this.approvalButton.Click += new System.EventHandler(this.approvalButton_Click);
            // 
            // adminiCheckBox
            // 
            this.adminiCheckBox.AutoSize = true;
            this.adminiCheckBox.Location = new System.Drawing.Point(27, 397);
            this.adminiCheckBox.Name = "adminiCheckBox";
            this.adminiCheckBox.Size = new System.Drawing.Size(18, 17);
            this.adminiCheckBox.TabIndex = 21;
            this.adminiCheckBox.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(460, 388);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 35);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "登録";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AdduserButton
            // 
            this.AdduserButton.Location = new System.Drawing.Point(151, 388);
            this.AdduserButton.Name = "AdduserButton";
            this.AdduserButton.Size = new System.Drawing.Size(109, 35);
            this.AdduserButton.TabIndex = 23;
            this.AdduserButton.Text = "アカウント登録";
            this.AdduserButton.UseVisualStyleBackColor = true;
            this.AdduserButton.Click += new System.EventHandler(this.AdduserButton_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AdduserButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.adminiCheckBox);
            this.Controls.Add(this.approvalButton);
            this.Controls.Add(this.bookListView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expiredCheckBox);
            this.Controls.Add(this.book_name);
            this.Controls.Add(this.book_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Search";
            this.Text = "書籍検索画面";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox book_id;
        private System.Windows.Forms.TextBox book_name;
        private System.Windows.Forms.CheckBox expiredCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.DataGridView bookListView;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.Button approvalButton;
        public System.Windows.Forms.CheckBox adminiCheckBox;
        public System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button AdduserButton;
    }
}