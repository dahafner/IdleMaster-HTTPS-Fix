using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmChangelog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangelog));
            this.TxtChangelog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TxtChangelog
            // 
            this.TxtChangelog.BackColor = System.Drawing.Color.White;
            this.TxtChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtChangelog.Location = new System.Drawing.Point(0, 0);
            this.TxtChangelog.Name = "TxtChangelog";
            this.TxtChangelog.ReadOnly = true;
            this.TxtChangelog.Size = new System.Drawing.Size(564, 578);
            this.TxtChangelog.TabIndex = 0;
            this.TxtChangelog.Text = "";
            // 
            // FrmChangelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 578);
            this.Controls.Add(this.TxtChangelog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChangelog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Idle Master Release Notes";
            this.Load += new System.EventHandler(this.FrmChangelog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox TxtChangelog;
    }
}