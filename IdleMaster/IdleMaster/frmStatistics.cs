using System;
using System.Windows.Forms;

namespace IdleMaster
{
    public partial class FrmStatistics : Form
    {
        private readonly Statistics statistics;

        public FrmStatistics(Statistics statistics)
        {
            InitializeComponent();
            this.statistics = statistics;
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // Localize Form
            this.Text = localization.strings.statistics.Replace("&", "");
            BtnOk.Text = localization.strings.accept;
            LblSessionHeader.Text = localization.strings.this_session + ":";
            LblTotalHeader.Text = localization.strings.total + ":";
            
            TimeSpan sessionMinutesIdled = TimeSpan.FromMinutes(statistics.getSessionMinutesIdled());
            TimeSpan totalMinutesIdled = TimeSpan.FromMinutes(Properties.Settings.Default.totalMinutesIdled);

            int sessionHoursIdled = (sessionMinutesIdled.Days * 24) + sessionMinutesIdled.Hours;
            int totalHoursIdled = (totalMinutesIdled.Days * 24) + totalMinutesIdled.Hours;

            //Session
            if (sessionHoursIdled > 0)
            {
                LblSessionTime.Text = String.Format("{0} hour{1}, {2} minute{3} idled",
                        sessionHoursIdled,
                        sessionHoursIdled == 1 ? "" : "s",
                        sessionMinutesIdled.Minutes,
                        sessionMinutesIdled.Minutes == 1 ? "" : "s");
            }
            else
            {
                LblSessionTime.Text = String.Format("{0} minute{1} idled",
                        sessionMinutesIdled.Minutes,
                        sessionMinutesIdled.Minutes == 1 ? "" : "s");
            }

            LblSessionCards.Text = statistics.getSessionCardIdled().ToString() + " cards idled";

            //Total
            if (totalHoursIdled > 0)
            {
                LblTotalTime.Text = String.Format("{0} hour{1}, {2} minute{3} idled",
                    totalHoursIdled,
                    totalHoursIdled == 1 ? "" : "s",
                    totalMinutesIdled.Minutes,
                    totalMinutesIdled.Minutes == 1 ? "" : "s");
            }
            else
            {
                LblTotalTime.Text = String.Format("{0} minute{1} idled",
                    totalMinutesIdled.Minutes,
                    totalMinutesIdled.Minutes == 1 ? "" : "s");
            }

            LblTotalCards.Text = Properties.Settings.Default.totalCardIdled.ToString() + " cards idled";
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
