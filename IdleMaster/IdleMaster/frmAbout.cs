using System;
using System.Deployment.Application;
using System.Reflection;
using System.Windows.Forms;

namespace IdleMaster
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            this.InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // Localize the form
            BtnOk.Text = localization.strings.ok;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                var version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                LblVersion.Text = "Idle Master v" + version;
            }
            else
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                LblVersion.Text = "Idle Master v" + version;
            }
        }
    }
}
