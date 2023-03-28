namespace IdleMaster
{
    partial class FrmStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatistics));
            this.BtnOk = new System.Windows.Forms.Button();
            this.LblSessionTime = new System.Windows.Forms.Label();
            this.LblSessionCards = new System.Windows.Forms.Label();
            this.LblTotalCards = new System.Windows.Forms.Label();
            this.LblTotalTime = new System.Windows.Forms.Label();
            this.LblSessionHeader = new System.Windows.Forms.Label();
            this.LblTotalHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.Location = new System.Drawing.Point(175, 129);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "&OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblSessionTime
            // 
            this.LblSessionTime.AutoSize = true;
            this.LblSessionTime.Location = new System.Drawing.Point(12, 29);
            this.LblSessionTime.Name = "LblSessionTime";
            this.LblSessionTime.Size = new System.Drawing.Size(65, 13);
            this.LblSessionTime.TabIndex = 1;
            this.LblSessionTime.Text = "sessionTime";
            // 
            // LblSessionCards
            // 
            this.LblSessionCards.AutoSize = true;
            this.LblSessionCards.Location = new System.Drawing.Point(12, 44);
            this.LblSessionCards.Name = "LblSessionCards";
            this.LblSessionCards.Size = new System.Drawing.Size(69, 13);
            this.LblSessionCards.TabIndex = 2;
            this.LblSessionCards.Text = "sessionCards";
            // 
            // LblTotalCards
            // 
            this.LblTotalCards.AutoSize = true;
            this.LblTotalCards.Location = new System.Drawing.Point(12, 104);
            this.LblTotalCards.Name = "LblTotalCards";
            this.LblTotalCards.Size = new System.Drawing.Size(54, 13);
            this.LblTotalCards.TabIndex = 3;
            this.LblTotalCards.Text = "totalCards";
            // 
            // LblTotalTime
            // 
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.Location = new System.Drawing.Point(12, 89);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(50, 13);
            this.LblTotalTime.TabIndex = 4;
            this.LblTotalTime.Text = "totalTime";
            // 
            // LblSessionHeader
            // 
            this.LblSessionHeader.AutoSize = true;
            this.LblSessionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSessionHeader.Location = new System.Drawing.Point(10, 9);
            this.LblSessionHeader.Name = "LblSessionHeader";
            this.LblSessionHeader.Size = new System.Drawing.Size(81, 13);
            this.LblSessionHeader.TabIndex = 5;
            this.LblSessionHeader.Text = "This session:";
            // 
            // LblTotalHeader
            // 
            this.LblTotalHeader.AutoSize = true;
            this.LblTotalHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalHeader.Location = new System.Drawing.Point(10, 69);
            this.LblTotalHeader.Name = "LblTotalHeader";
            this.LblTotalHeader.Size = new System.Drawing.Size(40, 13);
            this.LblTotalHeader.TabIndex = 6;
            this.LblTotalHeader.Text = "Total:";
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 157);
            this.Controls.Add(this.LblTotalHeader);
            this.Controls.Add(this.LblSessionHeader);
            this.Controls.Add(this.LblTotalTime);
            this.Controls.Add(this.LblTotalCards);
            this.Controls.Add(this.LblSessionCards);
            this.Controls.Add(this.LblSessionTime);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblSessionTime;
        private System.Windows.Forms.Label LblSessionCards;
        private System.Windows.Forms.Label LblTotalCards;
        private System.Windows.Forms.Label LblTotalTime;
        private System.Windows.Forms.Label LblSessionHeader;
        private System.Windows.Forms.Label LblTotalHeader;
    }
}