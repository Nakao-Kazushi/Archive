namespace Archive
{
    partial class Edit
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
            this.editGridView = new System.Windows.Forms.DataGridView();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // editGridView
            // 
            this.editGridView.AllowUserToAddRows = false;
            this.editGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editGridView.Location = new System.Drawing.Point(32, 38);
            this.editGridView.Name = "editGridView";
            this.editGridView.RowHeadersVisible = false;
            this.editGridView.RowHeadersWidth = 51;
            this.editGridView.RowTemplate.Height = 24;
            this.editGridView.Size = new System.Drawing.Size(554, 235);
            this.editGridView.TabIndex = 1;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(511, 329);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 30);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "更新";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 399);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.editGridView);
            this.Name = "Edit";
            this.Text = "更新画面";
            ((System.ComponentModel.ISupportInitialize)(this.editGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView editGridView;
        private System.Windows.Forms.Button editButton;
    }
}