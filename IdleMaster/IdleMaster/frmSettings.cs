using System;
using System.Windows.Forms;
using IdleMaster.Properties;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Text;

namespace IdleMaster
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (RbnIdleDefault.Checked)
            {
                Settings.Default.sort = "default";
            }
            
            if (RbnIdleLeastDrops.Checked)
            {
                Settings.Default.sort = "leastcards";
            }

            if (RbnIdleMostDrops.Checked)
            {
                Settings.Default.sort = "mostcards";
            }

            if (CbxLanguage.Text != "")
            {
                if (CbxLanguage.Text != Settings.Default.language)
                {
                    MessageBox.Show(localization.strings.please_restart);
                }

                Settings.Default.language = CbxLanguage.Text;
            }

            if (RbnOneThenMany.Checked)
            {
                Settings.Default.OnlyOneGameIdle = false;
                Settings.Default.OneThenMany = true;
            }
            else
            {
                Settings.Default.OnlyOneGameIdle = RbnOneGameOnly.Checked && !RbnManyThenOne.Checked;
                Settings.Default.OneThenMany = false;
            }

            Settings.Default.minToTray = ChbMinToTray.Checked;
            Settings.Default.ignoreclient = ChbIgnoreClientStatus.Checked;
            Settings.Default.showUsername = ChbShowUsername.Checked;
            Settings.Default.Save();
            Close();
        }
                
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        private string MinRuntime_s;
        private void LoadForm()
        {
            try
            {                
                StringBuilder temp = new StringBuilder(500);
                GetPrivateProfileString("AutoNext", "MinRuntime", "2", temp, 500, ".\\Settings.ini");
                if (temp.ToString() == "")
                { 
                    MinRuntime_s = "2"; }
                else
                {
                    MinRuntime_s = temp.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序发生错误，即将退出！\r\n错误信息：" + ex.Message);
                Environment.Exit(0);
            }
        }
    
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            LoadForm();
            if (Settings.Default.language != "")
            {
                CbxLanguage.SelectedItem = Settings.Default.language;
            }
            else
            {
                switch (Thread.CurrentThread.CurrentUICulture.EnglishName)
                {
                    case "Chinese (Simplified, China)":
                    case "Chinese (Traditional, China)":
                    case "Portuguese (Brazil)":
                        CbxLanguage.SelectedItem = Thread.CurrentThread.CurrentUICulture.EnglishName;
                        break;
                    default:
                        CbxLanguage.SelectedItem = Regex.Replace(Thread.CurrentThread.CurrentUICulture.EnglishName, @"\(.+\)", "").Trim();
                        break;
                }
            }

            switch (Settings.Default.sort)
            {
                case "leastcards":
                    RbnIdleLeastDrops.Checked = true;
                    break;
                case "mostcards":
                    RbnIdleMostDrops.Checked = true;
                    break;
                default:
                    break;
            }

            // Load translation
            this.Text = localization.strings.idle_master_settings;
            GrpGeneral.Text = localization.strings.general;
            GrpIdlingQuantity.Text = localization.strings.idling_behavior;
            GrpPriority.Text = localization.strings.idling_order;
            BtnOk.Text = localization.strings.accept;
            BtnCancel.Text = localization.strings.cancel;
            TtpHints.SetToolTip(BtnAdvanced, localization.strings.advanced_auth);
            ChbMinToTray.Text = localization.strings.minimize_to_tray;
            TtpHints.SetToolTip(ChbMinToTray, localization.strings.minimize_to_tray);
            ChbIgnoreClientStatus.Text = localization.strings.ignore_client_status;
            TtpHints.SetToolTip(ChbIgnoreClientStatus, localization.strings.ignore_client_status);
            ChbShowUsername.Text = localization.strings.show_username;
            TtpHints.SetToolTip(ChbShowUsername, localization.strings.show_username);
            RbnOneGameOnly.Text = localization.strings.idle_individual;
            TtpHints.SetToolTip(RbnOneGameOnly, localization.strings.idle_individual);

            //以下为魔改代码
            //radManyThenOne.Text = localization.strings.idle_simultaneous;
            //ttHints.SetToolTip(radManyThenOne, localization.strings.idle_simultaneous);
            //radOneThenMany.Text = localization.strings.idle_onethenmany;
            //ttHints.SetToolTip(radOneThenMany, localization.strings.idle_onethenmany);
            RbnManyThenOne.Text = localization.strings.idle_simultaneous.Replace("2", MinRuntime_s);
            TtpHints.SetToolTip(RbnManyThenOne, localization.strings.idle_simultaneous.Replace("2", MinRuntime_s));
            RbnOneThenMany.Text = localization.strings.idle_onethenmany.Replace("2", MinRuntime_s);
            TtpHints.SetToolTip(RbnOneThenMany, localization.strings.idle_onethenmany.Replace("2", MinRuntime_s));

            RbnIdleDefault.Text = localization.strings.order_default;
            TtpHints.SetToolTip(RbnIdleDefault, localization.strings.order_default);
            RbnIdleMostDrops.Text = localization.strings.order_most;
            TtpHints.SetToolTip(RbnIdleMostDrops, localization.strings.order_most);
            RbnIdleLeastDrops.Text = localization.strings.order_least;
            TtpHints.SetToolTip(RbnIdleLeastDrops, localization.strings.order_least);
            LblLanguage.Text = localization.strings.interface_language;

            if (Settings.Default.OneThenMany)
            {
                RbnOneThenMany.Checked = true;
            }
            else
            {
                RbnOneGameOnly.Checked = Settings.Default.OnlyOneGameIdle;
                RbnManyThenOne.Checked = !Settings.Default.OnlyOneGameIdle;
            }

            if (Settings.Default.minToTray)
            {
                ChbMinToTray.Checked = true;
            }

            if (Settings.Default.ignoreclient)
            {
                ChbIgnoreClientStatus.Checked = true;
            }

            if (Settings.Default.showUsername)
            {
                ChbShowUsername.Checked = true;
            }
        }

        private void BtnAdvanced_Click(object sender, EventArgs e)
        {
            var frm = new FrmSettingsAdvanced();
            frm.ShowDialog();
        }
    }
}
