using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmSettingsAdvanced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettingsAdvanced));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSessionId = new System.Windows.Forms.TextBox();
            this.TxtSteamMachineAuth = new System.Windows.Forms.TextBox();
            this.TxtSteamLoginSecure = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.TtpHelp = new System.Windows.Forms.ToolTip(this.components);
            this.TxtSteamparental = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GrpNotice = new System.Windows.Forms.GroupBox();
            this.LblFamilyView = new System.Windows.Forms.Label();
            this.LblUseCookie = new System.Windows.Forms.Label();
            this.GrpNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "sessionid:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "steamMachineAuth:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "steamLoginSecure:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtSessionId
            // 
            this.TxtSessionId.Location = new System.Drawing.Point(116, 10);
            this.TxtSessionId.Name = "TxtSessionId";
            this.TxtSessionId.PasswordChar = '*';
            this.TxtSessionId.Size = new System.Drawing.Size(317, 20);
            this.TxtSessionId.TabIndex = 3;
            this.TxtSessionId.TextChanged += new System.EventHandler(this.TxtSessionId_TextChanged);
            // 
            // TxtSteamMachineAuth
            // 
            this.TxtSteamMachineAuth.Location = new System.Drawing.Point(116, 34);
            this.TxtSteamMachineAuth.Name = "TxtSteamMachineAuth";
            this.TxtSteamMachineAuth.PasswordChar = '*';
            this.TxtSteamMachineAuth.Size = new System.Drawing.Size(317, 20);
            this.TxtSteamMachineAuth.TabIndex = 4;
            this.TxtSteamMachineAuth.TextChanged += new System.EventHandler(this.TxtSteamLogin_TextChanged);
            // 
            // TxtSteamLoginSecure
            // 
            this.TxtSteamLoginSecure.Location = new System.Drawing.Point(116, 57);
            this.TxtSteamLoginSecure.Name = "TxtSteamLoginSecure";
            this.TxtSteamLoginSecure.PasswordChar = '*';
            this.TxtSteamLoginSecure.Size = new System.Drawing.Size(317, 20);
            this.TxtSteamLoginSecure.TabIndex = 5;
            this.TxtSteamLoginSecure.TextChanged += new System.EventHandler(this.TxtSteamLoginSecure_TextChanged);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdate.Location = new System.Drawing.Point(358, 232);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "&Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnView
            // 
            this.BtnView.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnView.Image = global::IdleMaster.Properties.Resources.imgView;
            this.BtnView.Location = new System.Drawing.Point(116, 235);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(27, 23);
            this.BtnView.TabIndex = 6;
            this.TtpHelp.SetToolTip(this.BtnView, "Display information above\r\n\r\n[WARNING] \r\nDo not share this information with anyon" +
        "e, \r\nas it could potentially be used by an attacker to log into \r\nyour Steam acc" +
        "ount.");
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // TtpHelp
            // 
            this.TtpHelp.AutoPopDelay = 9000;
            this.TtpHelp.InitialDelay = 500;
            this.TtpHelp.ReshowDelay = 100;
            // 
            // TxtSteamparental
            // 
            this.TxtSteamparental.Location = new System.Drawing.Point(116, 81);
            this.TxtSteamparental.Name = "TxtSteamparental";
            this.TxtSteamparental.PasswordChar = '*';
            this.TxtSteamparental.Size = new System.Drawing.Size(317, 20);
            this.TxtSteamparental.TabIndex = 9;
            this.TxtSteamparental.TextChanged += new System.EventHandler(this.TxtSteamparental_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "steamparental:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // GrpNotice
            // 
            this.GrpNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpNotice.Controls.Add(this.LblFamilyView);
            this.GrpNotice.Controls.Add(this.LblUseCookie);
            this.GrpNotice.Location = new System.Drawing.Point(12, 109);
            this.GrpNotice.Name = "GrpNotice";
            this.GrpNotice.Size = new System.Drawing.Size(421, 116);
            this.GrpNotice.TabIndex = 10;
            this.GrpNotice.TabStop = false;
            this.GrpNotice.Text = "Notice:";
            // 
            // LblFamilyView
            // 
            this.LblFamilyView.Location = new System.Drawing.Point(6, 65);
            this.LblFamilyView.Name = "LblFamilyView";
            this.LblFamilyView.Size = new System.Drawing.Size(408, 39);
            this.LblFamilyView.TabIndex = 1;
            this.LblFamilyView.Text = "2.Leave steamparental to empty if you don\'t open the Steam Family View.";
            // 
            // LblUseCookie
            // 
            this.LblUseCookie.Location = new System.Drawing.Point(7, 23);
            this.LblUseCookie.Name = "LblUseCookie";
            this.LblUseCookie.Size = new System.Drawing.Size(408, 39);
            this.LblUseCookie.TabIndex = 0;
            this.LblUseCookie.Text = "1.Please use the cookie form \"SteamCommunity.com\" instead of \"store.steampowered." +
    "com\",or you can\'t login to SteamCommunity.";
            // 
            // FrmSettingsAdvanced
            // 
            this.AcceptButton = this.BtnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 264);
            this.Controls.Add(this.GrpNotice);
            this.Controls.Add(this.TxtSteamparental);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.TxtSteamLoginSecure);
            this.Controls.Add(this.TxtSteamMachineAuth);
            this.Controls.Add(this.TxtSessionId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSettingsAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Idle Master Authentication Data";
            this.Load += new System.EventHandler(this.FrmSettingsAdvanced_Load);
            this.GrpNotice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TxtSessionId;
        private TextBox TxtSteamMachineAuth;
        private TextBox TxtSteamLoginSecure;
        private Button BtnView;
        private Button BtnUpdate;
        private ToolTip TtpHelp;
        private TextBox TxtSteamparental;
        private Label label4;
        private GroupBox GrpNotice;
        private Label LblFamilyView;
        private Label LblUseCookie;
    }
}