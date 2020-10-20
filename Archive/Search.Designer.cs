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
            this.requestButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.bookListView = new System.Windows.Forms.DataGridView();
            this.adminiCheckBox = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.canBorrowCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "書籍ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "書籍名";
            // 
            // book_id
            // 
            this.book_id.Location = new System.Drawing.Point(131, 50);
            this.book_id.Margin = new System.Windows.Forms.Padding(4);
            this.book_id.Name = "book_id";
            this.book_id.Size = new System.Drawing.Size(135, 25);
            this.book_id.TabIndex = 1;
            this.book_id.TextChanged += new System.EventHandler(this.book_id_TextChanged);
            // 
            // book_name
            // 
            this.book_name.Location = new System.Drawing.Point(440, 50);
            this.book_name.Margin = new System.Windows.Forms.Padding(4);
            this.book_name.Name = "book_name";
            this.book_name.Size = new System.Drawing.Size(148, 25);
            this.book_name.TabIndex = 2;
            // 
            // expiredCheckBox
            // 
            this.expiredCheckBox.AutoSize = true;
            this.expiredCheckBox.Location = new System.Drawing.Point(131, 129);
            this.expiredCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.expiredCheckBox.Name = "expiredCheckBox";
            this.expiredCheckBox.Size = new System.Drawing.Size(22, 21);
            this.expiredCheckBox.TabIndex = 4;
            this.expiredCheckBox.UseVisualStyleBackColor = true;
            this.expiredCheckBox.CheckedChanged += new System.EventHandler(this.expiredCheckBox_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "返却期限切れのみ表示";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(676, 98);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(134, 44);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // requestButton
            // 
            this.requestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.requestButton.Location = new System.Drawing.Point(66, 466);
            this.requestButton.Margin = new System.Windows.Forms.Padding(4);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(94, 42);
            this.requestButton.TabIndex = 13;
            this.requestButton.Text = "申請";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(776, 466);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(94, 42);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "編集";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(878, 466);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 42);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // bookListView
            // 
            this.bookListView.AllowUserToAddRows = false;
            this.bookListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookListView.Location = new System.Drawing.Point(66, 194);
            this.bookListView.Margin = new System.Windows.Forms.Padding(4);
            this.bookListView.Name = "bookListView";
            this.bookListView.RowHeadersVisible = false;
            this.bookListView.RowHeadersWidth = 51;
            this.bookListView.RowTemplate.Height = 24;
            this.bookListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bookListView.Size = new System.Drawing.Size(906, 264);
            this.bookListView.TabIndex = 19;
            this.bookListView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookListView_CellValueChanged);
            this.bookListView.CurrentCellDirtyStateChanged += new System.EventHandler(this.bookListView_CurrentCellDirtyStateChanged);
            this.bookListView.Sorted += new System.EventHandler(this.bookListView_Sorted);
            // 
            // adminiCheckBox
            // 
            this.adminiCheckBox.AutoSize = true;
            this.adminiCheckBox.Location = new System.Drawing.Point(34, 476);
            this.adminiCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.adminiCheckBox.Name = "adminiCheckBox";
            this.adminiCheckBox.Size = new System.Drawing.Size(22, 21);
            this.adminiCheckBox.TabIndex = 21;
            this.adminiCheckBox.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(675, 466);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 42);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "登録";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // canBorrowCheckBox
            // 
            this.canBorrowCheckBox.AutoSize = true;
            this.canBorrowCheckBox.Location = new System.Drawing.Point(131, 92);
            this.canBorrowCheckBox.Name = "canBorrowCheckBox";
            this.canBorrowCheckBox.Size = new System.Drawing.Size(22, 21);
            this.canBorrowCheckBox.TabIndex = 3;
            this.canBorrowCheckBox.UseVisualStyleBackColor = true;
            this.canBorrowCheckBox.CheckedChanged += new System.EventHandler(this.canBorrowcheckBox_Changed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "貸出可能のみ表示";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.canBorrowCheckBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.adminiCheckBox);
            this.Controls.Add(this.bookListView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expiredCheckBox);
            this.Controls.Add(this.book_name);
            this.Controls.Add(this.book_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.DataGridView bookListView;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.CheckBox adminiCheckBox;
        public System.Windows.Forms.Button addButton;
        private System.Windows.Forms.CheckBox canBorrowCheckBox;
        private System.Windows.Forms.Label label10;
    }
}