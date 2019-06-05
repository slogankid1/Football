using System;
using System.Collections.Generic;

namespace WC2019SweepStake
{
    public class Lad
    {
        public string Name;
        public List<Team> Teams { get; set; }

        public Lad(string Name)
        {
            this.Name = Name;
            this.Teams = new List<Team>();
        }

        public void PrintRecievedTeams()
        {
            string printedString = "";
            printedString += Name + ": ";
            foreach (Team t in Teams)
            {
                printedString += t.Name + ", ";
            }

            //printedString = printedString.Substring(printedString.Length - 2);
            printedString = printedString.Remove(printedString.Length - 2, 2);
            Console.WriteLine(printedString);
        }

        public static List<Lad> RandomiseOrder(Random rng, List<Lad> lads)
        {
            int n = lads.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Lad value = lads[k];
                lads[k] = lads[n];
                lads[n] = value;
            }

            return lads;
        }
    }
}
