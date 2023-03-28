using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdleMaster.Properties;
using Steamworks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Globalization;
using System.Security.Principal;

namespace IdleMaster
{
    public partial class FrmMain : Form
    {
        private readonly Statistics statistics = new Statistics();
        private bool isCookieReady;
        private bool isSteamReady;
        private int timeLeft = 900;
        private int retryCount = 0;
        private int reloadCount = 0;
        private List<Badge> allBadges;
        private Badge currentBadge;
        private int minRuntime = 2;

        public IEnumerable<Badge> CanIdleBadges { get { return allBadges.Where(b => b.RemainingCard != 0); } }
        public int CardsRemaining { get { return CanIdleBadges.Sum(b => b.RemainingCard); } }
        public int GamesRemaining { get { return CanIdleBadges.Count(); } }

        public FrmMain()
        {
            InitializeComponent();
            allBadges = new List<Badge>();
        }

        private void UpdateStateInfo()
        {
            // Update totals
            if (reloadCount == 0)
            {
                LblIdle.Text = string.Format("{0} " + localization.strings.games_left_to_idle + ", {1} " + localization.strings.idle_now + ".", GamesRemaining, CanIdleBadges.Count(b => b.InIdle));
                LblDrops.Text = CardsRemaining + " " + localization.strings.card_drops_remaining;
                LblIdle.Visible = GamesRemaining != 0;
                LblDrops.Visible = CardsRemaining != 0;
            }
        }

        private void CopyResource(string resourceName, string file)
        {
            using (var resource = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    return;
                }

                using (Stream output = File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }

        private void SortBadges(string method)
        {
            LblDrops.Text = localization.strings.sorting_results;
            switch (method)
            {
                case "mostcards":
                    allBadges = allBadges.OrderByDescending(b => b.RemainingCard).ToList();
                    break;
                case "leastcards":
                    allBadges = allBadges.OrderBy(b => b.RemainingCard).ToList();
                    break;
                //case "mostvalue":
                //    try
                //    {
                //        var query = string.Format("http://api.enhancedsteam.com/market_data/average_card_prices/im.php?appids={0}",
                //        string.Join(",", AllBadges.Select(b => b.AppId)));
                //        var json = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString(query);
                //        var convertedJson = JsonConvert.DeserializeObject<EnhancedsteamHelper>(json);
                //        foreach (var price in convertedJson.Avg_Values)
                //        {
                //            var badge = AllBadges.SingleOrDefault(b => b.AppId == price.AppId);
                //            if (badge != null)
                //            {
                //                badge.AveragePrice = price.Avg_Price;
                //            }
                //        }

                //        AllBadges = AllBadges.OrderByDescending(b => b.AveragePrice).ToList();
                //    }
                //    catch
                //    {
                //    }

                //    break;

                default:
                    return;
            }
        }
                
        private void UpdateIdleProcesses()
        {
            foreach (var badge in CanIdleBadges.Where(b => !Equals(b, currentBadge)))
            {
                if (badge.HoursPlayed >= minRuntime && badge.InIdle)
                {
                    badge.StopIdle();
                }

                if (badge.HoursPlayed < minRuntime && CanIdleBadges.Count(b => b.InIdle) < 30)
                {
                    badge.Idle();
                }
            }

            RefreshGamesStateListView();

            if (!CanIdleBadges.Any(b => b.InIdle))
            {
                NextIdle();
            }

            UpdateStateInfo();
        }

        private void NextIdle()
        {
            // Stop idling the current game
            StopIdle();

            // Check if user is authenticated and if any badge left to idle
            // There should be check for IsCookieReady, but property is set in timer tick, so it could take some time to be set.
            if (string.IsNullOrWhiteSpace(Settings.Default.sessionid) || !isSteamReady)
            {
                ResetClientStatus();
            }
            else
            {
                if (CanIdleBadges.Any())
                {
                    // Give the user notification that the next game will start soon
                    LblCurrentStatus.Text = localization.strings.loading_next;

                    // Make a short but random amount of time pass
                    var rand = new Random();
                    var wait = rand.Next(3, 9);
                    wait = wait * 1000;

                    TmrStartNext.Interval = wait;
                    TmrStartNext.Enabled = true;
                }
                else
                {
                    IdleComplete();
                }
            }
        }

        private void StartIdle()
        {
            // Kill all existing processes before starting any new ones
            // This prevents rogue processes from interfering with idling time and slowing card drops
            try
            {
                String username = WindowsIdentity.GetCurrent().Name;
                foreach (var process in Process.GetProcessesByName("steam-idle"))
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ProcessID = " + process.Id);
                    ManagementObjectCollection processList = searcher.Get();

                    foreach (ManagementObject obj in processList)
                    {
                        string[] argList = new string[] { string.Empty, string.Empty };
                        int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                        if (returnVal == 0)
                        {
                            if (argList[1] + "\\" + argList[0] == username)
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            // Check if user is authenticated and if any badge left to idle
            // There should be check for IsCookieReady, but property is set in timer tick, so it could take some time to be set.
            if (string.IsNullOrWhiteSpace(Settings.Default.sessionid) || !isSteamReady)
            {
                ResetClientStatus();
            }
            else
            {
                if (reloadCount != 0)
                {
                    return;
                }

                if (CanIdleBadges.Any())
                {
                    statistics.SetRemainingCards((uint)CardsRemaining);
                    TmrStatistics.Enabled = true;
                    TmrStatistics.Start();
                    if (Settings.Default.OnlyOneGameIdle)
                    {
                        StartSoloIdle(CanIdleBadges.First());
                    }
                    else
                    {
                        if (Settings.Default.OneThenMany)
                        {
                            var multi = CanIdleBadges.Where(b => b.HoursPlayed >= minRuntime);
                            if (multi.Count() >= 1)
                            {
                                StartSoloIdle(multi.First());
                            }
                            else
                            {
                                StartMultipleIdle();
                            }
                        }
                        else
                        {
                            var multi = CanIdleBadges.Where(b => b.HoursPlayed < minRuntime);
                            if (multi.Count() >= 2)
                            {
                                StartMultipleIdle();
                            }
                            else
                            {
                                StartSoloIdle(CanIdleBadges.First());
                            }
                        }
                    }
                }
                else
                {
                    IdleComplete();
                }

                UpdateStateInfo();
            }
        }

        private void StartSoloIdle(Badge badge)
        {
            // Set the currentAppID value
            currentBadge = badge;

            // Place user "In game" for card drops
            currentBadge.Idle();

            // Update game name
            LblGameName.Visible = true;
            LblGameName.Text = currentBadge.Name;

            GamesState.Visible = false;
            MnuGame.Enabled = true;

            // Update game image            
            try
            {
                PbxApp.Load("https://cdn.cloudflare.steamstatic.com/steam/apps/" + currentBadge.StringId + "/header_292x136.jpg");
                PbxApp.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "frmMain -> StartIdle -> load pic, for id = " + currentBadge.AppId);
                PbxApp.Image = Resources.NoImage;
                PbxApp.Visible = true;
            }

            // Update label controls
            LblCurrentRemaining.Text = currentBadge.RemainingCard + " " + localization.strings.card_drops_remaining;
            LblCurrentStatus.Text = "Solo Idle";
            LblHoursPlayed.Visible = true;
            LblHoursPlayed.Text = currentBadge.HoursPlayed + " " + localization.strings.hrs_on_record;

            // Set progress bar values and show the footer
            PgrIdle.Maximum = currentBadge.RemainingCard;
            PgrIdle.Value = 0;
            StrFooter.Visible = true;

            // Start the animated "working" gif
            PbxIdleStatus.Image = Resources.imgSpin;

            // Start the timer that will check if drops remain
            TmrCardDropCheck.Enabled = true;

            // Reset the timer
            timeLeft = currentBadge.RemainingCard == 1 ? 300 : 900;

            // Set the correct buttons on the form for pause / resume
            BtnResume.Visible = false;
            BtnPause.Visible = true;
            BtnSkip.Visible = true;
            MnuGameResume.Enabled = false;
            MnuGamePause.Enabled = false;
            MnuGameSkip.Enabled = false;

            var scale = CreateGraphics().DpiY * 3.9;
            Height = Convert.ToInt32(scale);
        }

        private void StartMultipleIdle()
        {
            UpdateIdleProcesses();

            // Update label controls
            LblCurrentRemaining.Text = localization.strings.update_games_status;
            LblCurrentStatus.Text = "Multi Idle";

            LblGameName.Visible = false;
            LblHoursPlayed.Visible = false;
            StrFooter.Visible = true;
            MnuGame.Enabled = false;

            // Start the animated "working" gif
            PbxIdleStatus.Image = Resources.imgSpin;

            // Start the timer that will check if drops remain
            TmrCardDropCheck.Enabled = true;

            // Reset the timer
            timeLeft = 360;

            // Show game
            GamesState.Visible = true;
            PbxApp.Visible = false;
            RefreshGamesStateListView();

            // Set the correct buttons on the form for pause / resume
            BtnResume.Visible = false;
            BtnPause.Visible = false;
            BtnSkip.Visible = false;
            MnuGameResume.Enabled = false;
            MnuGamePause.Enabled = false;
            MnuGameSkip.Enabled = false;

            var scale = CreateGraphics().DpiY * 3.86;
            Height = Convert.ToInt32(scale);
        }

        private void RefreshGamesStateListView()
        {
            GamesState.Items.Clear();
            foreach (var badge in CanIdleBadges.Where(b => b.InIdle))
            {
                var line = new ListViewItem(badge.Name);
                line.SubItems.Add(badge.HoursPlayed.ToString());
                GamesState.Items.Add(line);
            }
        }

        private void StopIdle()
        {
            try
            {
                LblGameName.Visible = false;
                PbxApp.Image = null;
                PbxApp.Visible = false;
                GamesState.Visible = false;
                BtnPause.Visible = false;
                BtnSkip.Visible = false;
                LblCurrentStatus.Text = localization.strings.not_ingame;
                LblHoursPlayed.Visible = false;
                PbxIdleStatus.Image = null;

                // Stop the card drop check timer
                TmrCardDropCheck.Enabled = false;

                // Stop the statistics timer
                TmrStatistics.Stop();
                TmrStatistics.Enabled = false;

                // Hide the status bar
                StrFooter.Visible = false;

                // Resize the form
                var graphics = CreateGraphics();
                var scale = graphics.DpiY * 1.9583;
                Height = Convert.ToInt32(scale);

                // Kill the idling process
                foreach (var badge in allBadges.Where(b => b.InIdle))
                    badge.StopIdle();
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "frmMain -> StopIdle");
            }
        }

        private void IdleComplete()
        {
            // Deactivate the timer control and inform the user that the program is finished
            TmrCardDropCheck.Enabled = false;
            LblCurrentStatus.Text = localization.strings.idling_complete;

            LblGameName.Visible = false;
            BtnPause.Visible = false;
            BtnSkip.Visible = false;

            // Resize the form
            var graphics = CreateGraphics();
            var scale = graphics.DpiY * 1.9583;
            Height = Convert.ToInt32(scale);
        }

        private async Task LoadBadgesAsync()
        {
            // Settings.Default.myProfileURL = https://steamcommunity.com/id/USER
            // Refresh every time so it will be more stable            
            var profileLink = Settings.Default.myProfileURL + "/badges";
            var pages = new List<string>() { "?p=1" };
            var document = new HtmlDocument();
            int pagesCount = 1;

            try
            {
                // Load Page 1 and check how many pages there are
                //var pageURL = string.Format("{0}/?p={1}", profileLink, 1);
                var response = await CookieClient.GetHttpAsync(profileLink);
                // Response should be empty. User should be unauthorised.
                if (string.IsNullOrEmpty(response))
                {
                    retryCount++;
                    if (retryCount == 18)
                    {
                        ResetClientStatus();
                        return;
                    }

                    throw new Exception("");
                }

                document.LoadHtml(response);

                // If user is authenticated, check page count. If user is not authenticated, pages are different.
                var pageNodes = document.DocumentNode.SelectNodes("//a[@class=\"pagelink\"]");
                if (pageNodes != null)
                {
                    pages.AddRange(pageNodes.Select(p => p.Attributes["href"].Value).Distinct());
                    pages = pages.Distinct().ToList();
                }

                string lastpage = pages.Last().ToString().Replace("?p=", "");
                pagesCount = Convert.ToInt32(lastpage);

                // Get all badges from current page
                ProcessBadgesOnPage(document);

                // Load other pages
                //for (var i = 2; i <= pagesCount; i++)
                //{
                //    lblDrops.Text = string.Format(localization.strings.reading_badge_page + " {0}/{1}, " + localization.strings.please_wait, i, pagesCount);

                //    // Load Page 2+
                //    pageURL = string.Format("{0}/?p={1}", profileLink, i);
                //    response = await CookieClient.GetHttpAsync(pageURL);
                //    // Response should be empty. User should be unauthorised.
                //    if (string.IsNullOrEmpty(response))
                //    {
                //        RetryCount++;
                //        if (RetryCount == 18)
                //        {
                //            ResetClientStatus();
                //            return;
                //        }
                //        throw new Exception("");
                //    }
                //    document.LoadHtml(response);

                //    // Get all badges from current page
                //    ProcessBadgesOnPage(document);
                //}
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Badge -> LoadBadgesAsync, for profile = " + Settings.Default.myProfileURL);
                // badge page didn't load
                PbxReadingPage.Image = null;
                PbxIdleStatus.Image = null;
                LblDrops.Text = localization.strings.badge_didnt_load.Replace("__num__", "10");
                LblIdle.Text = "";

                // Set the form height
                var graphics = CreateGraphics();
                var scale = graphics.DpiY * 1.625;
                Height = Convert.ToInt32(scale);
                StrFooter.Visible = false;

                reloadCount = 1;
                TmrBadgeReload.Enabled = true;
                return;
            }

            retryCount = 0;
            SortBadges(Settings.Default.sort);

            PbxReadingPage.Visible = false;
            UpdateStateInfo();

            if (CardsRemaining == 0)
            {
                IdleComplete();
            }
        }

        private void ProcessBadgesOnPage(HtmlDocument document)
        {
            var badges = document.DocumentNode.SelectNodes("//div[@class=\"badge_row is_link\"]");
            if (badges == null)
            {
                return;
            }

            foreach (var badge in badges)
            {
                var appIdNode = badge.SelectSingleNode(".//a[@class=\"badge_row_overlay\"]").Attributes["href"].Value;
                var appid = Regex.Match(appIdNode, @"gamecards/(\d+)/").Groups[1].Value;

                if (string.IsNullOrWhiteSpace(appid) || Settings.Default.blacklist.Contains(appid) || appid == "368020" || appid == "335590" || appIdNode.Contains("border=1"))
                {
                    continue;
                }

                var hoursNode = badge.SelectSingleNode(".//div[@class=\"badge_title_stats_playtime\"]");
                var hours = hoursNode == null ? string.Empty : Regex.Match(hoursNode.InnerText, @"[0-9\.,]+").Value;

                var nameNode = badge.SelectSingleNode(".//div[@class=\"badge_title\"]");
                var name = WebUtility.HtmlDecode(nameNode.FirstChild.InnerText).Trim();

                var cardNode = badge.SelectSingleNode(".//span[@class=\"progress_info_bold\"]");
                var cards = cardNode == null ? string.Empty : Regex.Match(cardNode.InnerText, @"[0-9]+").Value;

                var badgeInMemory = allBadges.FirstOrDefault(b => b.StringId == appid);
                if (badgeInMemory != null)
                {
                    badgeInMemory.UpdateStats(cards, hours);
                }
                else
                {
                    allBadges.Add(new Badge(appid, name, cards, hours));
                }
            }
        }

        private async Task CheckCardDrops(Badge badge)
        {
            if (!await badge.CanCardDrops())
                NextIdle();
            else
            {
                // Resets the clock based on the number of remaining drops
                timeLeft = badge.RemainingCard == 1 ? 300 : 900;
            }

            LblCurrentRemaining.Text = badge.RemainingCard + " " + localization.strings.card_drops_remaining;
            PgrIdle.Value = PgrIdle.Maximum - badge.RemainingCard;
            LblHoursPlayed.Text = badge.HoursPlayed + " " + localization.strings.hrs_on_record;
            UpdateStateInfo();
        }
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Copy external references to the output directory.  This allows ClickOnce install.
            if (File.Exists(Environment.CurrentDirectory + "\\steam_api.dll") == false)
            {
                CopyResource("IdleMaster.Resources.steam_api.dll", Environment.CurrentDirectory + @"\steam_api.dll");
            }
            /*if (File.Exists(Environment.CurrentDirectory + "\\CSteamworks.dll") == false)
            {
                CopyResource("IdleMaster.Resources.CSteamworks.dll", Environment.CurrentDirectory + @"\CSteamworks.dll");
            }*/
            if (File.Exists(Environment.CurrentDirectory + "\\steam-idle.exe") == false)
            {
                CopyResource("IdleMaster.Resources.steam-idle.exe", Environment.CurrentDirectory + @"\steam-idle.exe");
            }

            // Update the settings, if needed.  When the application updates, settings will persist.
            if (Settings.Default.updateNeeded)
            {
                Settings.Default.Upgrade();
                Settings.Default.updateNeeded = false;
                Settings.Default.Save();
            }

            // Set the interface language from the settings
            if (Settings.Default.language != "")
            {
                string language_string = "";
                switch (Settings.Default.language)
                {
                    case "Bulgarian":
                        language_string = "bg";
                        break;
                    case "Chinese (Simplified, China)":
                        language_string = "zh-CN";
                        break;
                    case "Chinese (Traditional, China)":
                        language_string = "zh-TW";
                        break;
                    case "Czech":
                        language_string = "cs";
                        break;
                    case "Danish":
                        language_string = "da";
                        break;
                    case "Dutch":
                        language_string = "nl";
                        break;
                    case "English":
                        language_string = "en";
                        break;
                    case "Finnish":
                        language_string = "fi";
                        break;
                    case "French":
                        language_string = "fr";
                        break;
                    case "German":
                        language_string = "de";
                        break;
                    case "Greek":
                        language_string = "el";
                        break;
                    case "Hungarian":
                        language_string = "hu";
                        break;
                    case "Italian":
                        language_string = "it";
                        break;
                    case "Japanese":
                        language_string = "ja";
                        break;
                    case "Korean":
                        language_string = "ko";
                        break;
                    case "Norwegian":
                        language_string = "no";
                        break;
                    case "Polish":
                        language_string = "pl";
                        break;
                    case "Portuguese":
                        language_string = "pt-PT";
                        break;
                    case "Portuguese (Brazil)":
                        language_string = "pt-BR";
                        break;
                    case "Romanian":
                        language_string = "ro";
                        break;
                    case "Russian":
                        language_string = "ru";
                        break;
                    case "Spanish":
                        language_string = "es";
                        break;
                    case "Swedish":
                        language_string = "sv";
                        break;
                    case "Thai":
                        language_string = "th";
                        break;
                    case "Turkish":
                        language_string = "tr";
                        break;
                    case "Ukrainian":
                        language_string = "uk";
                        break;
                    default:
                        language_string = "en";
                        break;
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language_string);
            }

            // Localize form elements
            MnuFile.Text = localization.strings.file;
            MnuGame.Text = localization.strings.game;
            MnuHelp.Text = localization.strings.help;
            MnuFileSettings.Text = localization.strings.settings;
            MnuFileBlacklist.Text = localization.strings.blacklist;
            MnuFileExit.Text = localization.strings.exit;
            MnuGamePause.Text = localization.strings.pause_idling;
            MnuGameResume.Text = localization.strings.resume_idling;
            MnuGameSkip.Text = localization.strings.skip_current_game;
            MnuGameBlacklist.Text = localization.strings.blacklist_current_game;
            MnuHelpStats.Text = localization.strings.statistics;
            MnuHelpChangelog.Text = localization.strings.release_notes;
            MnuHelpOfficial.Text = localization.strings.official_group;
            MnuHelpAbout.Text = localization.strings.about;
            LnkSignIn.Text = "(" + localization.strings.sign_in + ")";
            LnkResetCookies.Text = "(" + localization.strings.sign_out + ")";
            LblNextCheck.Text = localization.strings.next_check;
            LblNextCheck.ToolTipText = localization.strings.next_check;

            LblSignedOnAs.Text = localization.strings.signed_in_as;
            GamesState.Columns[0].Text = localization.strings.name;
            GamesState.Columns[1].Text = localization.strings.hours;

            // Set the form height
            var graphics = CreateGraphics();
            var scale = graphics.DpiY * 1.625;
            Height = Convert.ToInt32(scale);

            // Set the location of certain elements so that they scale correctly for different DPI settings
            var point = new Point(Convert.ToInt32(graphics.DpiX * 1.14), Convert.ToInt32(LblGameName.Location.Y));
            LblGameName.Location = point;
            point = new Point(Convert.ToInt32(graphics.DpiX * 2.35), Convert.ToInt32(LnkSignIn.Location.Y));
            LnkSignIn.Location = point;
            point = new Point(Convert.ToInt32(graphics.DpiX * 2.15), Convert.ToInt32(LnkResetCookies.Location.Y));
            LnkResetCookies.Location = point;
        }

        private void FrmMain_FormClose(object sender, FormClosedEventArgs e)
        {
            StopIdle();
        }

        private void TmrCheckCookieData_Tick(object sender, EventArgs e)
        {
            var connected = !string.IsNullOrWhiteSpace(Settings.Default.sessionid) && !string.IsNullOrWhiteSpace(Settings.Default.steamLoginSecure);
            LblCookieStatus.Text = connected ? localization.strings.idle_master_connected : localization.strings.idle_master_notconnected;
            LblCookieStatus.ForeColor = connected ? Color.Green : Color.Black;
            PbxCookieStatus.Image = connected ? Resources.imgTrue : Resources.imgFalse;
            LnkSignIn.Visible = !connected;
            LnkResetCookies.Visible = connected;
            isCookieReady = connected;
        }

        private void TmrCheckSteam_Tick(object sender, EventArgs e)
        {
            var isSteamRunning = SteamAPI.IsSteamRunning() || Settings.Default.ignoreclient;
            LblSteamStatus.Text = isSteamRunning ? (Settings.Default.ignoreclient ? localization.strings.steam_ignored : localization.strings.steam_running) : localization.strings.steam_notrunning;
            LblSteamStatus.ForeColor = isSteamRunning ? Color.Green : Color.Black;
            PbxSteamStatus.Image = isSteamRunning ? Resources.imgTrue : Resources.imgFalse;
            TmrCheckSteam.Interval = isSteamRunning ? 5000 : 500;
            MnuGameSkip.Enabled = isSteamRunning;
            MnuGamePause.Enabled = isSteamRunning;
            isSteamReady = isSteamRunning;
        }

        private void LblGameName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://store.steampowered.com/app/" + currentBadge.AppId);
        }

        private void LnkResetCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetClientStatus();
        }

        private void ResetClientStatus()
        {
            // Clear the settings
            Settings.Default.sessionid = string.Empty;
            Settings.Default.steamId = string.Empty;
            Settings.Default.myProfileURL = string.Empty;
            Settings.Default.steamLoginSecure = string.Empty;
            Settings.Default.steamparental = string.Empty;
            Settings.Default.Save();

            // Stop the steam-idle process
            StopIdle();

            // Clear the badges list
            allBadges.Clear();

            // Resize the form
            var graphics = CreateGraphics();
            var scale = graphics.DpiY * 1.625;
            Height = Convert.ToInt32(scale);

            // Set timer intervals
            TmrCheckSteam.Interval = 500;
            TmrCheckCookieData.Interval = 500;

            // Hide signed user name
            if (Settings.Default.showUsername)
            {
                LblSignedOnAs.Text = String.Empty;
                LblSignedOnAs.Visible = false;
            }

            // Hide spinners
            PbxReadingPage.Visible = false;

            // Hide lblDrops and lblIdle
            LblDrops.Visible = false;
            LblIdle.Visible = false;

            // Set IsCookieReady to false
            isCookieReady = false;

            // Re-enable tmrReadyToGo
            TmrReadyToGo.Enabled = true;
        }

        private void LnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new FrmBrowser();
            frm.ShowDialog();
        }

        private void MnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void TmrReadyToGo_Tick(object sender, EventArgs e)
        {

            if (!isCookieReady || !isSteamReady)
                return;

            // Update the form elements
            if (Settings.Default.showUsername)
            {
                LblSignedOnAs.Text = SteamProfile.GetSignedAs();
                LblSignedOnAs.Visible = true;
            }

            LblDrops.Visible = true;
            LblDrops.Text = localization.strings.reading_badge_page + ", " + localization.strings.please_wait;
            LblIdle.Visible = false;
            PbxReadingPage.Visible = true;

            TmrReadyToGo.Enabled = false;

            // Call the loadBadges() function asynchronously
            await LoadBadgesAsync();

            StartIdle();
        }

        private async void TmrCardDropCheck_Tick(object sender, EventArgs e)
        {
            if (timeLeft <= 0)
            {
                TmrCardDropCheck.Enabled = false;
                if (currentBadge != null)
                {
                    currentBadge.Idle();
                    await CheckCardDrops(currentBadge);
                }

                var isMultipleIdle = CanIdleBadges.Any(b => !Equals(b, currentBadge) && b.InIdle);
                if (isMultipleIdle)
                {
                    await LoadBadgesAsync();
                    UpdateIdleProcesses();

                    isMultipleIdle = CanIdleBadges.Any(b => b.HoursPlayed < minRuntime && b.InIdle);
                    if (isMultipleIdle)
                        timeLeft = 360;
                }

                // Check if user is authenticated and if any badge left to idle
                // There should be check for IsCookieReady, but property is set in timer tick, so it could take some time to be set.
                TmrCardDropCheck.Enabled = !string.IsNullOrWhiteSpace(Settings.Default.sessionid) && isSteamReady && CanIdleBadges.Any() && timeLeft != 0;
            }
            else
            {
                timeLeft = timeLeft - 1;
                LblTimer.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");
            }
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            RunNextIdle();
        }

        private void RunNextIdle()
        {
            if (!isSteamReady)
                return;

            StopIdle();
            allBadges.RemoveAll(b => Equals(b, currentBadge));
            StartIdle();
        }
        
        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!isSteamReady)
                return;

            // Stop the steam-idle process
            StopIdle();

            // Indicate to the user that idling has been paused
            LblCurrentStatus.Text = localization.strings.idling_paused;

            // Set the correct button visibility
            BtnResume.Visible = true;
            BtnPause.Visible = false;
            MnuGamePause.Enabled = false;
            MnuGameResume.Enabled = true;

            // Focus the resume button
            BtnResume.Focus();
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            // Resume idling
            StartIdle();

            MnuGamePause.Enabled = true;
            MnuGameResume.Enabled = false;
        }

        private void MnuFileSettings_Click(object sender, EventArgs e)
        {
            // Show the form
            String previous = Settings.Default.sort;
            Boolean previous_behavior = Settings.Default.OnlyOneGameIdle;
            Boolean previous_behavior2 = Settings.Default.OneThenMany;
            Form frm = new FrmSettings();
            frm.ShowDialog();

            if (previous != Settings.Default.sort || previous_behavior != Settings.Default.OnlyOneGameIdle || previous_behavior2 != Settings.Default.OneThenMany)
            {
                StopIdle();
                allBadges.Clear();
                TmrReadyToGo.Enabled = true;
            }

            if (Settings.Default.showUsername && isCookieReady)
            {
                LblSignedOnAs.Text = SteamProfile.GetSignedAs();
                LblSignedOnAs.Visible = Settings.Default.showUsername;
            }
        }

        private void MnuGamePause_Click(object sender, EventArgs e)
        {
            BtnPause.PerformClick();
        }

        private void MnuGameResume_Click(object sender, EventArgs e)
        {
            BtnResume.PerformClick();
        }

        private void MnuGameSkip_Click(object sender, EventArgs e)
        {
            BtnSkip.PerformClick();
        }

        private void MnuHelpAbout_Click(object sender, EventArgs e)
        {
            var frm = new FrmAbout();
            frm.ShowDialog();
        }

        private void LblCurrentRemaining_Click(object sender, EventArgs e)
        {
            if (timeLeft > 2)
            {
                timeLeft = 2;
            }
        }

        private void MnuFileBlacklist_Click(object sender, EventArgs e)
        {
            var frm = new FrmBlacklist();
            frm.ShowDialog();

            if (Settings.Default.blacklist.Cast<string>().Any(appid => appid == currentBadge.StringId))
                BtnSkip.PerformClick();
        }

        private void MnuGameBlacklist_Click(object sender, EventArgs e)
        {
            Settings.Default.blacklist.Add(currentBadge.StringId);
            Settings.Default.Save();

            BtnSkip.PerformClick();
        }

        private void TmrStartNext_Tick(object sender, EventArgs e)
        {
            TmrStartNext.Enabled = false;
            StartIdle();
        }

        private void MnuHelpChangelog_Click(object sender, EventArgs e)
        {
            var frm = new FrmChangelog();
            frm.Show();
        }

        private void MnuHelpStatistics_Click(object sender, EventArgs e)
        {
            var frm = new FrmStatistics(statistics);
            frm.ShowDialog();
        }

        private void MnuHelpOfficial_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/groups/idlemastery");
        }

        private void TmrBadgeReload_Tick(object sender, EventArgs e)
        {
            reloadCount = reloadCount + 1;
            LblDrops.Text = localization.strings.badge_didnt_load.Replace("__num__", (10 - reloadCount).ToString());

            if (reloadCount == 10)
            {
                TmrBadgeReload.Enabled = false;
                TmrReadyToGo.Enabled = true;
                reloadCount = 0;
            }
        }

        private void TmrStatistics_Tick(object sender, EventArgs e)
        {
            statistics.IncreaseMinutesIdled();
            statistics.CheckCardRemaining((uint)CardsRemaining);
        }
    }
}