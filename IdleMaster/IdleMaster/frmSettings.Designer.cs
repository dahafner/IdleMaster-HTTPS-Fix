using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.GrpGeneral = new System.Windows.Forms.GroupBox();
            this.CbxLanguage = new System.Windows.Forms.ComboBox();
            this.LblLanguage = new System.Windows.Forms.Label();
            this.ChbShowUsername = new System.Windows.Forms.CheckBox();
            this.ChbIgnoreClientStatus = new System.Windows.Forms.CheckBox();
            this.ChbMinToTray = new System.Windows.Forms.CheckBox();
            this.GrpPriority = new System.Windows.Forms.GroupBox();
            this.RbnIdleLeastDrops = new System.Windows.Forms.RadioButton();
            this.RbnIdleMostDrops = new System.Windows.Forms.RadioButton();
            this.RbnIdleDefault = new System.Windows.Forms.RadioButton();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TtpHints = new System.Windows.Forms.ToolTip(this.components);
            this.BtnAdvanced = new System.Windows.Forms.Button();
            this.GrpIdlingQuantity = new System.Windows.Forms.GroupBox();
            this.RbnOneThenMany = new System.Windows.Forms.RadioButton();
            this.RbnManyThenOne = new System.Windows.Forms.RadioButton();
            this.RbnOneGameOnly = new System.Windows.Forms.RadioButton();
            this.GrpGeneral.SuspendLayout();
            this.GrpPriority.SuspendLayout();
            this.GrpIdlingQuantity.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpGeneral
            // 
            this.GrpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpGeneral.Controls.Add(this.CbxLanguage);
            this.GrpGeneral.Controls.Add(this.LblLanguage);
            this.GrpGeneral.Controls.Add(this.ChbShowUsername);
            this.GrpGeneral.Controls.Add(this.ChbIgnoreClientStatus);
            this.GrpGeneral.Controls.Add(this.ChbMinToTray);
            this.GrpGeneral.Location = new System.Drawing.Point(13, 13);
            this.GrpGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpGeneral.Name = "GrpGeneral";
            this.GrpGeneral.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpGeneral.Size = new System.Drawing.Size(392, 106);
            this.GrpGeneral.TabIndex = 0;
            this.GrpGeneral.TabStop = false;
            this.GrpGeneral.Text = "General";
            // 
            // CbxLanguage
            // 
            this.CbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxLanguage.FormattingEnabled = true;
            this.CbxLanguage.Items.AddRange(new object[] {
            "English",
            "Chinese (Simplified, China)",
            "Chinese (Traditional, China)",
            "Czech",
            "Dutch",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Hungarian",
            "Italian",
            "Japanese",
            "Korean",
            "Norwegian",
            "Polish",
            "Portuguese",
            "Portuguese (Brazil)",
            "Romanian",
            "Russian",
            "Spanish",
            "Swedish",
            "Thai",
            "Turkish",
            "Ukrainian"});
            this.CbxLanguage.Location = new System.Drawing.Point(135, 76);
            this.CbxLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CbxLanguage.Name = "CbxLanguage";
            this.CbxLanguage.Size = new System.Drawing.Size(190, 21);
            this.CbxLanguage.TabIndex = 4;
            // 
            // LblLanguage
            // 
            this.LblLanguage.AutoSize = true;
            this.LblLanguage.Location = new System.Drawing.Point(26, 79);
            this.LblLanguage.Name = "LblLanguage";
            this.LblLanguage.Size = new System.Drawing.Size(103, 13);
            this.LblLanguage.TabIndex = 3;
            this.LblLanguage.Text = "Interface Language:";
            this.LblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChbShowUsername
            // 
            this.ChbShowUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChbShowUsername.Location = new System.Drawing.Point(8, 54);
            this.ChbShowUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChbShowUsername.Name = "ChbShowUsername";
            this.ChbShowUsername.Size = new System.Drawing.Size(378, 20);
            this.ChbShowUsername.TabIndex = 2;
            this.ChbShowUsername.Text = "Show Steam username of signed on user";
            this.ChbShowUsername.UseVisualStyleBackColor = true;
            // 
            // ChbIgnoreClientStatus
            // 
            this.ChbIgnoreClientStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChbIgnoreClientStatus.Location = new System.Drawing.Point(8, 38);
            this.ChbIgnoreClientStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChbIgnoreClientStatus.Name = "ChbIgnoreClientStatus";
            this.ChbIgnoreClientStatus.Size = new System.Drawing.Size(378, 17);
            this.ChbIgnoreClientStatus.TabIndex = 1;
            this.ChbIgnoreClientStatus.Text = "Ignore Steam client status";
            this.ChbIgnoreClientStatus.UseVisualStyleBackColor = true;
            // 
            // ChbMinToTray
            // 
            this.ChbMinToTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChbMinToTray.Location = new System.Drawing.Point(8, 20);
            this.ChbMinToTray.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChbMinToTray.Name = "ChbMinToTray";
            this.ChbMinToTray.Size = new System.Drawing.Size(378, 17);
            this.ChbMinToTray.TabIndex = 0;
            this.ChbMinToTray.Text = "Minimize Idle Master to system tray";
            this.ChbMinToTray.UseVisualStyleBackColor = true;
            // 
            // GrpPriority
            // 
            this.GrpPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpPriority.Controls.Add(this.RbnIdleLeastDrops);
            this.GrpPriority.Controls.Add(this.RbnIdleMostDrops);
            this.GrpPriority.Controls.Add(this.RbnIdleDefault);
            this.GrpPriority.Location = new System.Drawing.Point(13, 208);
            this.GrpPriority.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpPriority.Name = "GrpPriority";
            this.GrpPriority.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpPriority.Size = new System.Drawing.Size(392, 79);
            this.GrpPriority.TabIndex = 1;
            this.GrpPriority.TabStop = false;
            this.GrpPriority.Text = "Idling Order";
            // 
            // RbnIdleLeastDrops
            // 
            this.RbnIdleLeastDrops.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbnIdleLeastDrops.Location = new System.Drawing.Point(7, 52);
            this.RbnIdleLeastDrops.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnIdleLeastDrops.Name = "RbnIdleLeastDrops";
            this.RbnIdleLeastDrops.Size = new System.Drawing.Size(379, 17);
            this.RbnIdleLeastDrops.TabIndex = 2;
            this.RbnIdleLeastDrops.Text = "Prioritize games with the lowest number of available drops";
            this.RbnIdleLeastDrops.UseVisualStyleBackColor = true;
            // 
            // RbnIdleMostDrops
            // 
            this.RbnIdleMostDrops.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbnIdleMostDrops.Location = new System.Drawing.Point(7, 35);
            this.RbnIdleMostDrops.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnIdleMostDrops.Name = "RbnIdleMostDrops";
            this.RbnIdleMostDrops.Size = new System.Drawing.Size(379, 17);
            this.RbnIdleMostDrops.TabIndex = 1;
            this.RbnIdleMostDrops.Text = "Prioritize games with the highest number of available drops";
            this.RbnIdleMostDrops.UseVisualStyleBackColor = true;
            // 
            // RbnIdleDefault
            // 
            this.RbnIdleDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbnIdleDefault.Checked = true;
            this.RbnIdleDefault.Location = new System.Drawing.Point(7, 18);
            this.RbnIdleDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnIdleDefault.Name = "RbnIdleDefault";
            this.RbnIdleDefault.Size = new System.Drawing.Size(379, 17);
            this.RbnIdleDefault.TabIndex = 0;
            this.RbnIdleDefault.TabStop = true;
            this.RbnIdleDefault.Text = "Default (Alphabetical Order)";
            this.RbnIdleDefault.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(330, 310);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 28);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.Location = new System.Drawing.Point(249, 310);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 28);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "&Accept";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnAdvanced
            // 
            this.BtnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAdvanced.Image = global::IdleMaster.Properties.Resources.imgLock;
            this.BtnAdvanced.Location = new System.Drawing.Point(13, 294);
            this.BtnAdvanced.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAdvanced.Name = "BtnAdvanced";
            this.BtnAdvanced.Size = new System.Drawing.Size(41, 48);
            this.BtnAdvanced.TabIndex = 4;
            this.TtpHints.SetToolTip(this.BtnAdvanced, "Display advanced authentication information");
            this.BtnAdvanced.UseVisualStyleBackColor = true;
            this.BtnAdvanced.Click += new System.EventHandler(this.BtnAdvanced_Click);
            // 
            // GrpIdlingQuantity
            // 
            this.GrpIdlingQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpIdlingQuantity.Controls.Add(this.RbnOneThenMany);
            this.GrpIdlingQuantity.Controls.Add(this.RbnManyThenOne);
            this.GrpIdlingQuantity.Controls.Add(this.RbnOneGameOnly);
            this.GrpIdlingQuantity.Location = new System.Drawing.Point(13, 124);
            this.GrpIdlingQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.GrpIdlingQuantity.Name = "GrpIdlingQuantity";
            this.GrpIdlingQuantity.Padding = new System.Windows.Forms.Padding(2);
            this.GrpIdlingQuantity.Size = new System.Drawing.Size(392, 80);
            this.GrpIdlingQuantity.TabIndex = 5;
            this.GrpIdlingQuantity.TabStop = false;
            this.GrpIdlingQuantity.Text = "Idling Behavior";
            // 
            // RbnOneThenMany
            // 
            this.RbnOneThenMany.AutoSize = true;
            this.RbnOneThenMany.Location = new System.Drawing.Point(7, 53);
            this.RbnOneThenMany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnOneThenMany.Name = "RbnOneThenMany";
            this.RbnOneThenMany.Size = new System.Drawing.Size(338, 17);
            this.RbnOneThenMany.TabIndex = 6;
            this.RbnOneThenMany.TabStop = true;
            this.RbnOneThenMany.Text = "Idle games with more than 2 hours individually, then simultaneously";
            this.RbnOneThenMany.UseVisualStyleBackColor = true;
            // 
            // RbnManyThenOne
            // 
            this.RbnManyThenOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbnManyThenOne.Location = new System.Drawing.Point(7, 35);
            this.RbnManyThenOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnManyThenOne.Name = "RbnManyThenOne";
            this.RbnManyThenOne.Size = new System.Drawing.Size(379, 17);
            this.RbnManyThenOne.TabIndex = 5;
            this.RbnManyThenOne.TabStop = true;
            this.RbnManyThenOne.Text = "Idle games simultaneously up to 2 hours, then individually";
            this.RbnManyThenOne.UseVisualStyleBackColor = true;
            // 
            // RbnOneGameOnly
            // 
            this.RbnOneGameOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbnOneGameOnly.Checked = true;
            this.RbnOneGameOnly.Location = new System.Drawing.Point(7, 18);
            this.RbnOneGameOnly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RbnOneGameOnly.Name = "RbnOneGameOnly";
            this.RbnOneGameOnly.Size = new System.Drawing.Size(379, 17);
            this.RbnOneGameOnly.TabIndex = 4;
            this.RbnOneGameOnly.TabStop = true;
            this.RbnOneGameOnly.Text = "Idle each game individually";
            this.RbnOneGameOnly.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(417, 351);
            this.Controls.Add(this.GrpIdlingQuantity);
            this.Controls.Add(this.BtnAdvanced);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrpPriority);
            this.Controls.Add(this.GrpGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ve";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.GrpGeneral.ResumeLayout(false);
            this.GrpGeneral.PerformLayout();
            this.GrpPriority.ResumeLayout(false);
            this.GrpIdlingQuantity.ResumeLayout(false);
            this.GrpIdlingQuantity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GrpGeneral;
        private CheckBox ChbMinToTray;
        private GroupBox GrpPriority;
        private RadioButton RbnIdleLeastDrops;
        private RadioButton RbnIdleMostDrops;
        private RadioButton RbnIdleDefault;
        private Button BtnCancel;
        private Button BtnOk;
        private Button BtnAdvanced;
        private ToolTip TtpHints;
        private CheckBox ChbIgnoreClientStatus;
        private CheckBox ChbShowUsername;
    private GroupBox GrpIdlingQuantity;
    private RadioButton RbnManyThenOne;
    private RadioButton RbnOneGameOnly;
    private ComboBox CbxLanguage;
    private Label LblLanguage;
    private RadioButton RbnOneThenMany;
    }
}