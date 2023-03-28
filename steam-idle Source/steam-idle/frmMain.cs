using Steamworks;
using System;
using System.Windows.Forms;

namespace steam_idle
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept  
                    };
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            long appId = long.Parse(textBox1.Text);
            Environment.SetEnvironmentVariable("SteamAppId", appId.ToString());
            if (!SteamAPI.Init())
            {
                return;
            }

            panel1.Hide();
            this.Text = appId.ToString();
            picApp.Load("https://cdn.cloudflare.steamstatic.com/steam/apps/" + appId.ToString() + "/header_292x136.jpg");
        }
    }
}
