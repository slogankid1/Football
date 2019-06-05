using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace WC2019SweepStake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Populate Team List
            List<Team> Teams = new List<Team>
            {
                new Team("United States", 1, 4.5),
                new Team("France", 3, 4.5),
                new Team("Germany", 2, 6.5),
                new Team("England", 4, 7),
                new Team("Canada", 5, 21),
                new Team("Australia", 6, 15),
                new Team("Netherlands", 7, 15),
                new Team("Japan", 8, 15),
                new Team("Sweden", 9, 26),
                new Team("Brazil", 10, 26),
                new Team("Spain", 12, 26),
                new Team("Norway", 13, 34),
                new Team("South Korea", 14, 101),
                new Team("China PR", 15, 67),
                new Team("Italy", 16, 51),
                new Team("New Zealand", 19, 126),
                new Team("Scotland", 20, 151),
                new Team("Thailand", 29, 1501),
                new Team("Argentina", 36, 401),
                new Team("Chile", 38, 501),
                new Team("Nigeria", 39, 501),
                new Team("Cameroon", 46, 751),
                new Team("South Africa", 48, 501),
                new Team("Jamaica", 53, 1001)
            };

            //Order Teams
            Teams = Teams.OrderBy(x => x.Odds).ToList();
            //Teams = Teams.OrderBy(x => x.FifaRanking).ToList();

            //Create Sweepstake players
            List<Lad> lads = new List<Lad>
            {
                new Lad("James"),
                new Lad("Harry"),
                new Lad("Connor"),
                new Lad("Dan"),
                new Lad("Glenn"),
                new Lad("Joe"),
                new Lad("John")
            };

            //Create and Assign Teams to Pots
            int potNo = 1;
            int i = 1;
            Pot currentPot = new Pot(potNo);
            List<Pot> pots = new List<Pot> { currentPot };
            foreach (Team t in Teams)
            {
                t.Pot = currentPot;
                currentPot.Teams.Add(t);

                if (i % lads.Count == 0)
                {
                    potNo++;
                    currentPot = new Pot(potNo);
                    pots.Add(currentPot);
                }
                i++;
            }

            foreach (Pot pot in pots)
            {
                int n = 0;
                //Randomises Lad order
                Random rng = new Random();
                lads = Lad.RandomiseOrder(rng, lads);

                foreach (var lad in lads)
                {
                    if (n < pot.Teams.Count) { lad.Teams.Add(pot.Teams[n]);}
                    n++;
                }
            }

            foreach (var lad in lads)
            {
                lad.PrintRecievedTeams();
            }

            Console.ReadKey();
        }

    }
}
