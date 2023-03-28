namespace IdleMaster
{
    public class Statistics
    {
        private uint sessionMinutesIdled = 0;
        private uint sessionCardIdled = 0;
        private uint remainingCards = 0;

        public uint getSessionMinutesIdled()
        {
            return sessionMinutesIdled;
        }

        public uint getSessionCardIdled()
        {
            return sessionCardIdled;
        }

        public uint getRemainingCards()
        {
            return remainingCards;
        }

        public void SetRemainingCards(uint remainingCards)
        {
            this.remainingCards = remainingCards;
        }

        public void CheckCardRemaining(uint actualCardRemaining)
        {
            if (actualCardRemaining < remainingCards)
            {
                IncreaseCardIdled(remainingCards - actualCardRemaining);
                remainingCards = actualCardRemaining;
            }
            else if (actualCardRemaining > remainingCards)
            {
                remainingCards = actualCardRemaining;
            }
        }

        private void IncreaseCardIdled(uint number)
        {
            Properties.Settings.Default.totalCardIdled += number;
            Properties.Settings.Default.Save();
            sessionCardIdled += number;
        }

        public void IncreaseMinutesIdled()
        {
            Properties.Settings.Default.totalMinutesIdled++;
            Properties.Settings.Default.Save();
            sessionMinutesIdled++;
        }
    }
}
