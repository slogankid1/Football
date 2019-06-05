using System.Collections.Generic;

namespace WC2019SweepStake
{
    public class Pot
    {
        public int PotNumber;
        public List<Team> Teams;

        public Pot(int PotNumber)
        {
            this.PotNumber = PotNumber;
            Teams = new List<Team>();
        }
    }
}