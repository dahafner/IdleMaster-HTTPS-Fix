using System;
using System.Linq;
using System.Windows.Forms;
using IdleMaster.Properties;

namespace IdleMaster
{
    public partial class FrmBlacklist : Form
    {
        public FrmBlacklist()
        {
            this.InitializeComponent();
        }

        public void SaveBlacklist()
        {
            Settings.Default.blacklist.Clear();
            Settings.Default.blacklist.AddRange(LbxBlacklist.Items.Cast<string>().ToArray());
            Settings.Default.Save();
        }

        private void FrmBlacklist_Load(object sender, EventArgs e)
        {
            // Localize form
            BtnAdd.Text = localization.strings.add;
            BtnSave.Text = localization.strings.save;
            this.Text = localization.strings.manage_blacklist;
            GrpAdd.Text = localization.strings.add_game_blacklist;

            LbxBlacklist.Items.AddRange(Settings.Default.blacklist.Cast<string>().ToArray());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.SaveBlacklist();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtAppid.Text, out int result))
            {
                if (LbxBlacklist.Items.Cast<string>().All(blApp => blApp != TxtAppid.Text))
                {
                    LbxBlacklist.Items.Add(TxtAppid.Text);
                }
            }

            TxtAppid.Text = string.Empty;
            TxtAppid.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            LbxBlacklist.Items.Remove(LbxBlacklist.SelectedItem);
        }
    }
}
