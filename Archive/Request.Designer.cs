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
            this.requestGridView = new System.Windows.Forms.DataGridView();
            this.requestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // requestGridView
            // 
            this.requestGridView.AllowUserToAddRows = false;
            this.requestGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestGridView.Location = new System.Drawing.Point(31, 40);
            this.requestGridView.Name = "requestGridView";
            this.requestGridView.RowHeadersVisible = false;
            this.requestGridView.RowHeadersWidth = 51;
            this.requestGridView.RowTemplate.Height = 24;
            this.requestGridView.Size = new System.Drawing.Size(554, 235);
            this.requestGridView.TabIndex = 0;
            this.requestGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestGridView_CellClick);
            // 
            // requestButton
            // 
            this.requestButton.Location = new System.Drawing.Point(509, 320);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(75, 30);
            this.requestButton.TabIndex = 1;
            this.requestButton.Text = "申請";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // Request
            // 
            this.ClientSize = new System.Drawing.Size(638, 388);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.requestGridView);
            this.Name = "Request";
            this.Text = "申請画面";
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView requestGridView;
        private System.Windows.Forms.Button requestButton;
    }
}