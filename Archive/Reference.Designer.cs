﻿namespace Archive
{
    partial class Reference
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
            this.usageStateView = new System.Windows.Forms.DataGridView();
            this.retturnButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.user_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.usageStateView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "利用状況照会";
            // 
            // usageStateView
            // 
            this.usageStateView.AllowUserToAddRows = false;
            this.usageStateView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usageStateView.Location = new System.Drawing.Point(44, 89);
            this.usageStateView.Name = "usageStateView";
            this.usageStateView.RowHeadersVisible = false;
            this.usageStateView.RowHeadersWidth = 62;
            this.usageStateView.RowTemplate.Height = 27;
            this.usageStateView.Size = new System.Drawing.Size(906, 250);
            this.usageStateView.TabIndex = 1;
            // 
            // retturnButton
            // 
            this.retturnButton.Location = new System.Drawing.Point(687, 369);
            this.retturnButton.Name = "retturnButton";
            this.retturnButton.Size = new System.Drawing.Size(94, 42);
            this.retturnButton.TabIndex = 2;
            this.retturnButton.Text = "返却";
            this.retturnButton.UseVisualStyleBackColor = true;
            this.retturnButton.Click += new System.EventHandler(this.RetturnButton_Clicked);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchButton.Location = new System.Drawing.Point(801, 369);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(149, 42);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "書籍検索画面";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Clicked);
            // 
            // user_id
            // 
            this.user_id.Location = new System.Drawing.Point(850, 44);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(100, 25);
            this.user_id.TabIndex = 4;
            // 
            // Reference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.user_id);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.retturnButton);
            this.Controls.Add(this.usageStateView);
            this.Controls.Add(this.label1);
            this.Name = "Reference";
            this.Text = "利用状況照会";
            ((System.ComponentModel.ISupportInitialize)(this.usageStateView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView usageStateView;
        private System.Windows.Forms.Button retturnButton;
        private System.Windows.Forms.Button searchButton;
        public System.Windows.Forms.TextBox user_id;
    }
}