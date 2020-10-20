namespace Archive
{
    partial class Approval
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
            this.approvalGridView = new System.Windows.Forms.DataGridView();
            this.ApprovalButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.approvalGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // approvalGridView
            // 
            this.approvalGridView.AllowUserToAddRows = false;
            this.approvalGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.approvalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.approvalGridView.Location = new System.Drawing.Point(29, 35);
            this.approvalGridView.Name = "approvalGridView";
            this.approvalGridView.RowHeadersVisible = false;
            this.approvalGridView.RowHeadersWidth = 51;
            this.approvalGridView.RowTemplate.Height = 24;
            this.approvalGridView.Size = new System.Drawing.Size(733, 287);
            this.approvalGridView.TabIndex = 0;
            // 
            // ApprovalButton
            // 
            this.ApprovalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApprovalButton.Location = new System.Drawing.Point(606, 359);
            this.ApprovalButton.Name = "ApprovalButton";
            this.ApprovalButton.Size = new System.Drawing.Size(75, 45);
            this.ApprovalButton.TabIndex = 1;
            this.ApprovalButton.Text = "承認";
            this.ApprovalButton.UseVisualStyleBackColor = true;
            this.ApprovalButton.Click += new System.EventHandler(this.ApprovalButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(687, 359);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(86, 45);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "検索画面";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ApprovalButton);
            this.Controls.Add(this.approvalGridView);
            this.Name = "Approval";
            this.Text = "承認画面";
            this.Load += new System.EventHandler(this.Approval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.approvalGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView approvalGridView;
        private System.Windows.Forms.Button ApprovalButton;
        private System.Windows.Forms.Button SearchButton;
    }
}