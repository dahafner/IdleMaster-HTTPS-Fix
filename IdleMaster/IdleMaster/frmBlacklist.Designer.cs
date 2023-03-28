using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmBlacklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlacklist));
            this.LbxBlacklist = new System.Windows.Forms.ListBox();
            this.GrpAdd = new System.Windows.Forms.GroupBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtAppid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.GrpAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbxBlacklist
            // 
            this.LbxBlacklist.FormattingEnabled = true;
            this.LbxBlacklist.Location = new System.Drawing.Point(13, 13);
            this.LbxBlacklist.Name = "LbxBlacklist";
            this.LbxBlacklist.Size = new System.Drawing.Size(270, 316);
            this.LbxBlacklist.Sorted = true;
            this.LbxBlacklist.TabIndex = 0;
            // 
            // GrpAdd
            // 
            this.GrpAdd.Controls.Add(this.BtnAdd);
            this.GrpAdd.Controls.Add(this.TxtAppid);
            this.GrpAdd.Controls.Add(this.label1);
            this.GrpAdd.Location = new System.Drawing.Point(13, 336);
            this.GrpAdd.Name = "GrpAdd";
            this.GrpAdd.Size = new System.Drawing.Size(181, 76);
            this.GrpAdd.TabIndex = 1;
            this.GrpAdd.TabStop = false;
            this.GrpAdd.Text = "Add Game to Blacklist";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(100, 43);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtAppid
            // 
            this.TxtAppid.Location = new System.Drawing.Point(56, 17);
            this.TxtAppid.Name = "TxtAppid";
            this.TxtAppid.Size = new System.Drawing.Size(119, 20);
            this.TxtAppid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "App ID:";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(237, 383);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Image = global::IdleMaster.Properties.Resources.imgTrash;
            this.BtnRemove.Location = new System.Drawing.Point(289, 13);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(28, 28);
            this.BtnRemove.TabIndex = 2;
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // FrmBlacklist
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 418);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.GrpAdd);
            this.Controls.Add(this.LbxBlacklist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBlacklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Idle Master Blacklist";
            this.Load += new System.EventHandler(this.FrmBlacklist_Load);
            this.GrpAdd.ResumeLayout(false);
            this.GrpAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox LbxBlacklist;
        private GroupBox GrpAdd;
        private Button BtnRemove;
        private Button BtnSave;
        private Button BtnAdd;
        private TextBox TxtAppid;
        private Label label1;
    }
}