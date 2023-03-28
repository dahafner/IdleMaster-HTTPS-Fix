using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowser));
            this.LblSaving = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TmrCheck = new System.Windows.Forms.Timer(this.components);
            this.WvwBrowser = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WvwBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSaving
            // 
            this.LblSaving.AutoSize = true;
            this.LblSaving.Location = new System.Drawing.Point(34, 11);
            this.LblSaving.Name = "LblSaving";
            this.LblSaving.Size = new System.Drawing.Size(180, 13);
            this.LblSaving.TabIndex = 1;
            this.LblSaving.Text = "Idle Master is saving your information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IdleMaster.Properties.Resources.imgSpin;
            this.pictureBox1.Location = new System.Drawing.Point(13, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // TmrCheck
            // 
            this.TmrCheck.Interval = 1000;
            this.TmrCheck.Tick += new System.EventHandler(this.TmrCheck_Tick);
            // 
            // WvwBrowser
            // 
            this.WvwBrowser.AllowExternalDrop = true;
            this.WvwBrowser.CreationProperties = null;
            this.WvwBrowser.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WvwBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WvwBrowser.Location = new System.Drawing.Point(0, 0);
            this.WvwBrowser.Name = "WvwBrowser";
            this.WvwBrowser.Size = new System.Drawing.Size(976, 798);
            this.WvwBrowser.TabIndex = 3;
            this.WvwBrowser.ZoomFactor = 1D;
            this.WvwBrowser.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.WvwBrowser_NavigationStarting);
            this.WvwBrowser.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.WvwBrowser_NavigationCompleted);
            // 
            // FrmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 798);
            this.Controls.Add(this.WvwBrowser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblSaving);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Login to Steam";
            this.Load += new System.EventHandler(this.FrmBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WvwBrowser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label LblSaving;
        private PictureBox pictureBox1;
        private Timer TmrCheck;
        private Microsoft.Web.WebView2.WinForms.WebView2 WvwBrowser;
    }
}