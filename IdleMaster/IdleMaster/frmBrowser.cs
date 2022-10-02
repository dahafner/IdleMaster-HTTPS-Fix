using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IdleMaster.Properties;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace IdleMaster
{
    public partial class frmBrowser : Form
    {

        public int SecondsWaiting = GetMaxTimeout();

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetSetOption(int hInternet, int dwOption, string lpBuffer, int dwBufferLength);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);

        public frmBrowser()
        {
            // This initializes the components on the form
            InitializeComponent();
        }

        public static int GetMaxTimeout()
        {
            int[] tmpTimeList = { 15, 30, 60, 90, 125800 };
            return tmpTimeList[Settings.Default.LoginTimeout];
        }

        private async void frmBrowser_Load(object sender, EventArgs e)
        {
            // Remove any existing session state data
            InternetSetOption(0, 42, null, 0);

            // Localize form
            this.Text = localization.strings.please_login;
            lblSaving.Text = localization.strings.saving_info;

            // Delete Steam cookie data from the browser control
            InternetSetCookie("https://steamcommunity.com", "sessionid", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");
            InternetSetCookie("https://steamcommunity.com", "steamLoginSecure", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");
            InternetSetCookie("https://steamcommunity.com", "steamRememberLogin", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");

            // When the form is loaded, navigate to the Steam login page using the web browser control            
            string[] PageStr = new string[] { "profile", "badges", "inventory", "screenshots", "recommended", "groups" };
            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Settings.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            webView21.CoreWebView2.Navigate("https://steamcommunity.com/login/home/?goto=my/" + PageStr[Settings.Default.LoginPageRedirect]);            
        }

        private async void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Find the page header, and remove it.  This gives the login form a more streamlined look.
            dynamic htmldoc = await webView21.ExecuteScriptAsync("document.documentElement.outerHTML;");

            htmldoc = Regex.Unescape(htmldoc);
            htmldoc = htmldoc.Remove(0, 1);
            htmldoc = htmldoc.Remove(htmldoc.Length - 1, 1);

            try
            {
                dynamic globalHeader = htmldoc.GetElementById("global_header");
                if (globalHeader != null)
                {
                    globalHeader.parentNode.removeChild(globalHeader);
                }
            }
            catch (Exception)
            {
            }

            // Get the URL of the page that just finished loading
            var url = webView21.Source.ToString();

            // If the page it just finished loading is the login page
            //if (url == "https://steamcommunity.com/login/home/?goto=my/profile" ||
            if (url.StartsWith("https://steamcommunity.com/login/home/?goto=my/") ||
                url == "https://store.steampowered.com/login/transfer" ||
                url == "https://store.steampowered.com//login/transfer")
            {
                // Get a list of cookies from the current page
                CookieContainer container = GetUriCookieContainer(webView21.Source);
                var cookies = container.GetCookies(webView21.Source);
                foreach (Cookie cookie in cookies)
                {
                    if (cookie.Name.StartsWith("steamMachineAuth"))
                        Settings.Default.steamMachineAuth = cookie.Value;
                }
            }
            // If the page it just finished loading isn't the login page
            else if (url.StartsWith("javascript:") == false && url.StartsWith("about:") == false)
            {

                try
                {
                    dynamic parentalNotice = htmldoc.GetElementById("parental_notice");
                    if (parentalNotice != null)
                    {
                        if (parentalNotice.OuterHtml != "")
                        {
                            // Steam family options enabled
                            webView21.Show();
                            Width = 1000;
                            Height = 350;
                            return;
                        }
                    }
                }
                catch (Exception)
                {

                }

                // Get a list of cookies from the current page
                var container = GetUriCookieContainer(webView21.Source);
                var cookies = container.GetCookies(webView21.Source);

                // Go through the cookie data so that we can extract the cookies we are looking for
                foreach (Cookie cookie in cookies)
                {
                    // Save the "sessionid" cookie
                    if (cookie.Name == "browserid")
                    {
                        Settings.Default.sessionid = cookie.Value;
                    }

                    // Save the "steamLogin" cookie and construct and save the user's profile link
                    // steamLogin is now Change to steamLoginSecure
                    /*else if (cookie.Name == "steamLogin")
                    {
                      Settings.Default.steamLogin = cookie.Value;
                      Settings.Default.myProfileURL = SteamProfile.GetSteamUrl();
                    }*/

                    // Save the "steamLogin" cookie and construct and save the user's profile link
                    else if (cookie.Name.StartsWith("steamMachineAuth"))
                    {
                        Settings.Default.steamLoginSecure = cookie.Value;
                        Settings.Default.myProfileURL = "https://steamcommunity.com/profiles/" + cookie.Name.Replace("steamMachineAuth", "");
                    }

                    else if (cookie.Name == "steamRememberLogin")
                    {
                        Settings.Default.steamRememberLogin = cookie.Value;
                    }
                    else if (cookie.Name == "steamparental")
                    {
                        Settings.Default.steamparental = cookie.Value;
                    }
                }

                // Save all of the data to the program settings file, and close this form
                Settings.Default.Save();
                tmrCheck.Enabled = false;
                Close();
            }
        }

        // Imports the InternetGetCookieEx function from wininet.dll which allows the application to access the cookie data from the web browser control
        // Reference: http://stackoverflow.com/questions/3382498/is-it-possible-to-transfer-authentication-from-webbrowser-to-webrequest
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookieEx(
            string url,
            string cookieName,
            StringBuilder cookieData,
            ref int size,
            int dwFlags,
            IntPtr lpReserved);

        // Assigns the hex value for the DLL flag that allows Idle Master to be able to access cookie data marked as "HTTP Only"
        private const int InternetCookieHttponly = 0x2000;

        // This function returns cookie data based on a uniform resource identifier
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            // First, create a null cookie container
            CookieContainer cookies = null;

            // Determine the size of the cookie
            var datasize = 8192 * 16;
            var cookieData = new StringBuilder(datasize);

            // Call InternetGetCookieEx from wininet.dll
            if (!InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(
                    uri.ToString(),
                    null, cookieData,
                    ref datasize,
                    InternetCookieHttponly,
                    IntPtr.Zero))
                    return null;
            }

            // If the cookie contains data, add it to the cookie container
            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }

            // Return the cookie container
            return cookies;
        }


        private void webView21_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            // Get the url that's being navigated to
            var url = e.Uri;

            if (url.StartsWith("data:text"))
            {
                return;
            }

            // Check to see if the page it's navigating to isn't the Steam login page or related calls
            //if (url != "https://steamcommunity.com/login/home/?goto=my/profile"
            if (!url.StartsWith("https://steamcommunity.com/login/home/?goto=my/")
                      && url != "https://store.steampowered.com/login/transfer" && url != "https://store.steampowered.com//login/transfer" && url.StartsWith("javascript:") == false && url.StartsWith("about:") == false)
            {
                // start the sanity check timer
                tmrCheck.Enabled = true;

                // If it's navigating to a page other than the Steam login page, hide the browser control and resize the form
                webView21.Visible = false;

                // Scale the form based on the user's DPI settings
                var graphics = CreateGraphics();
                var scaleY = graphics.DpiY * 0.84375;
                var scaleX = graphics.DpiX * 2.84;
                Height = Convert.ToInt32(scaleY);
                Width = Convert.ToInt32(scaleX);
            }
        }

        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            // Prevents the application from "saving" for more than 30 seconds and will attempt to save the cookie data after that time
            if (SecondsWaiting > 0)
            {
                SecondsWaiting = SecondsWaiting - 1;
            }
            else
            {
                tmrCheck.Enabled = false;
                //MessageBox.Show("等待超时，退出");
                Close();
            }
        }
    }
}
