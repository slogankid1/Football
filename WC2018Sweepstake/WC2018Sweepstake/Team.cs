namespace WC2019SweepStake
{
    public class Team
    {
        public string Name;
        public int FifaRanking;
        public double Odds;
        public Pot Pot;

        public Team(string Name, int FifaRanking, double Odds)
        {
            this.Name = Name;
            this.FifaRanking = FifaRanking;
            this.Odds = Odds;
        }
    }
}