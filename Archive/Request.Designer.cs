namespace Archive
{
    partial class Request
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
            this.requestButton = new System.Windows.Forms.Button();
            this.requestGridView = new System.Windows.Forms.DataGridView();
            this.returnButton = new System.Windows.Forms.Button();
            this.user_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // requestButton
            // 
            this.requestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.requestButton.Location = new System.Drawing.Point(480, 388);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(75, 30);
            this.requestButton.TabIndex = 1;
            this.requestButton.Text = "申請";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // requestGridView
            // 
            this.requestGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestGridView.Location = new System.Drawing.Point(56, 42);
            this.requestGridView.Name = "requestGridView";
            this.requestGridView.RowHeadersVisible = false;
            this.requestGridView.RowHeadersWidth = 51;
            this.requestGridView.RowTemplate.Height = 24;
            this.requestGridView.Size = new System.Drawing.Size(595, 316);
            this.requestGridView.TabIndex = 0;
            this.requestGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestGridView_CellClick);
            // 
            // returnButton
            // 
            this.returnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.returnButton.Location = new System.Drawing.Point(576, 388);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 30);
            this.returnButton.TabIndex = 2;
            this.returnButton.Text = "戻る";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // user_id
            // 
            this.user_id.Location = new System.Drawing.Point(56, 365);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(48, 22);
            this.user_id.TabIndex = 3;
            this.user_id.TextChanged += new System.EventHandler(this.user_id_Changed);
            // 
            // Request
            // 
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.user_id);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.requestGridView);
            this.Controls.Add(this.requestButton);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Request";
            this.Text = "申請画面";
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView requestGridView;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Button returnButton;
        public System.Windows.Forms.TextBox user_id;
    }
}