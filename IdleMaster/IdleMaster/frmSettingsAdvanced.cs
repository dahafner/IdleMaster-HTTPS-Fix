using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdleMaster.Properties;

namespace IdleMaster
{
    public partial class FrmSettingsAdvanced : Form
    {
        public FrmSettingsAdvanced()
        {
            InitializeComponent();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            TxtSessionId.PasswordChar = '\0';
            TxtSteamMachineAuth.PasswordChar = '\0';
            TxtSteamLoginSecure.PasswordChar = '\0';
            TxtSteamparental.PasswordChar = '\0';

            TxtSessionId.Enabled = true;
            TxtSteamMachineAuth.Enabled = true;
            TxtSteamLoginSecure.Enabled = true;
            TxtSteamparental.Enabled = true;

            BtnView.Visible = false;
        }

        private void FrmSettingsAdvanced_Load(object sender, EventArgs e)
        {
            // Localize Form
            BtnUpdate.Text = localization.strings.update;
            this.Text = localization.strings.auth_data;
            TtpHelp.SetToolTip(BtnView, localization.strings.cookie_warning);
            GrpNotice.Text = localization.strings.notice;
            LblUseCookie.Text = localization.strings.notice_usecookie;
            LblFamilyView.Text = localization.strings.notice_familyview;

            if (!string.IsNullOrWhiteSpace(Settings.Default.sessionid))
            {
                TxtSessionId.Text = Settings.Default.sessionid;
                TxtSessionId.Enabled = false;
            }
            else
            {
                TxtSessionId.PasswordChar = '\0';
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.steamId))
            {
                TxtSteamMachineAuth.Text = Settings.Default.steamId;
                TxtSteamMachineAuth.Enabled = false;
            }
            else
            {
                TxtSteamMachineAuth.PasswordChar = '\0';
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.steamLoginSecure))
            {
                TxtSteamLoginSecure.Text = Settings.Default.steamLoginSecure;
                TxtSteamLoginSecure.Enabled = false;
            }
            else
            {
                TxtSteamLoginSecure.PasswordChar = '\0';
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.steamparental))
            {
                TxtSteamparental.Text=Settings.Default.steamparental;
                TxtSteamparental.Enabled = false;
            }
            else
            {
                TxtSteamparental.PasswordChar = '\0';
            }

            if (TxtSessionId.Enabled && TxtSteamMachineAuth.Enabled && TxtSteamLoginSecure.Enabled)
            {
                BtnView.Visible = false;
            }

            BtnUpdate.Enabled = false;
        }

        private void TxtSessionId_TextChanged(object sender, EventArgs e)
        {
            BtnUpdate.Enabled = true;
        }

        private void TxtSteamLogin_TextChanged(object sender, EventArgs e)
        {
            BtnUpdate.Enabled = true;
        }

        private void TxtSteamLoginSecure_TextChanged(object sender, EventArgs e)
        {
            BtnUpdate.Enabled = true;
        }

        private void TxtSteamparental_TextChanged(object sender, EventArgs e)
        {
            BtnUpdate.Enabled = true;
        }

        private async Task CheckAndSave()
        {
            try
            {
                Settings.Default.sessionid = TxtSessionId.Text.Trim();
                Settings.Default.steamMachineAuth = TxtSteamMachineAuth.Text.Trim();
                Settings.Default.steamLoginSecure = TxtSteamLoginSecure.Text.Trim();
                Settings.Default.myProfileURL = SteamProfile.GetSteamUrl();
                Settings.Default.steamparental = TxtSteamparental.Text.Trim();

                if (await CookieClient.IsLogined())
                {
                    Settings.Default.Save();
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "frmSettingsAdvanced -> CheckAndSave");
            }

            // Invalid cookie data, reset the form
            BtnUpdate.Text = localization.strings.update;
            TxtSessionId.Text = "";
            TxtSteamMachineAuth.Text = "";
            TxtSteamLoginSecure.Text = "";
            TxtSteamparental.Text = "";
            TxtSessionId.PasswordChar = '\0';
            TxtSteamMachineAuth.PasswordChar = '\0';
            TxtSteamLoginSecure.PasswordChar = '\0';
            TxtSteamparental.PasswordChar = '\0';
            TxtSessionId.Enabled = true;
            TxtSteamMachineAuth.Enabled = true;
            TxtSteamLoginSecure.Enabled = true;
            TxtSteamparental.Enabled = true;
            TxtSessionId.Focus();
            MessageBox.Show(localization.strings.validate_failed);
            BtnUpdate.Enabled = true;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            BtnUpdate.Enabled = false;
            TxtSessionId.Enabled = false;
            TxtSteamMachineAuth.Enabled = false;
            TxtSteamLoginSecure.Enabled = false;
            TxtSteamparental.Enabled = false;
            BtnUpdate.Text = localization.strings.validating;
            await CheckAndSave();
        }
    }
}
