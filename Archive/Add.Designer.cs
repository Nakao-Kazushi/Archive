namespace Archive
{
    partial class Add
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.add_button = new System.Windows.Forms.Button();
            this.book_id = new System.Windows.Forms.TextBox();
            this.book_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(474, 288);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(164, 56);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "登録";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.addButtonClicked);
            // 
            // book_id
            // 
            this.book_id.Location = new System.Drawing.Point(147, 107);
            this.book_id.Name = "book_id";
            this.book_id.Size = new System.Drawing.Size(298, 22);
            this.book_id.TabIndex = 1;
            // 
            // book_name
            // 
            this.book_name.Location = new System.Drawing.Point(147, 147);
            this.book_name.Name = "book_name";
            this.book_name.Size = new System.Drawing.Size(298, 22);
            this.book_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "書籍ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "書籍名";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(474, 382);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 30);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.book_name);
            this.Controls.Add(this.book_id);
            this.Controls.Add(this.add_button);
            this.Name = "Add";
            this.RightToLeftLayout = true;
            this.Text = "書籍登録画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.TextBox book_id;
        private System.Windows.Forms.TextBox book_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;
    }
}

