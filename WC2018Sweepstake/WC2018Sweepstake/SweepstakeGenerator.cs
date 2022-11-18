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
            List<Team> teams2018 = new List<Team>
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

            List<Team> teams2020 = new List<Team>
            {
                //Odds from bet365 as of 2/6/2021
                new Team("Austria", 23, 80),
                new Team("Belgium", 1, 6),
                new Team("Croatia", 14, 33),
                new Team("Czech Republic", 40, 150),
                new Team("Denmark", 10, 28),
                new Team("England", 4, 5),
                new Team("Finland", 54, 500),
                new Team("France", 2, 4.5),
                new Team("Germany", 12, 7),
                new Team("Hungary", 37, 400),
                new Team("Italy", 7, 11),
                new Team("Netherlands", 16, 12),
                new Team("North Macedonia", 62, 500),
                new Team("Poland", 21, 80),
                new Team("Portugal", 5, 8),
                new Team("Russia", 38, 66),
                new Team("Scotland", 44, 250),
                new Team("Slovakia", 36, 250),
                new Team("Spain", 6, 7.5),
                new Team("Sweden", 18, 100),
                new Team("Switzerland", 13, 66),
                new Team("Turkey", 29, 66),
                new Team("Ukraine", 24, 66),
                new Team("Wales", 17, 100)
            };
            
            List<Team> teams2022 = new List<Team>
            {
                //Odds from skybet as of 18/11/2021. CBA to do fifa ranking
                new Team("Brazil", 23, 3.5),
                new Team("Argentina", 1, 5.5),
                new Team("France", 14, 5.5),
                new Team("England", 40, 7.5),
                new Team("Spain", 10, 8),
                new Team("Germany", 4, 10),
                new Team("Netherlands", 54, 11),
                new Team("Portugal", 2, 14),
                new Team("Belgium", 12, 16),
                new Team("Denmark", 37, 28),
                new Team("Uruguay", 7, 40),
                new Team("Croatia", 16, 50),
                new Team("Serbia", 62, 80),
                new Team("Switzerland", 21, 80),
                new Team("Mexico", 5, 100),
                new Team("Poland", 38, 100),
                new Team("Senegal", 44, 100),
                new Team("USA", 36, 100),
                new Team("Ecuador", 6, 150),
                new Team("Wales", 18, 150),
                new Team("Japan", 13, 200),
                new Team("Cameroon", 29, 250),
                new Team("Morocco", 24, 250),
                new Team("South Korea", 17, 250),
                new Team("Australia", 6, 500),
                new Team("Canada", 18, 500),
                new Team("Ghana", 13, 500),
                new Team("Iran", 29, 500),
                new Team("Tunisia", 24, 250),
                new Team("Costa Rica", 17, 750),
                new Team("Qatar", 17, 750),
                new Team("Saudi Arabia", 17, 750),
            };

            //Select which tournament
            List<Team> Teams = teams2022;

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
                new Lad("John"),
                new Lad("Tim")
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

            //Print out pots
            int line = 1;
            Console.WriteLine($"Pot 1");
            foreach (Team team in Teams)
            {
                Console.WriteLine($"{team.Name} - {team.FifaRanking} - {team.Odds}");
                if (line % lads.Count == 0) { Console.WriteLine($"\nPot {(line / lads.Count) + 1}"); }
                line++;
            }

            Console.WriteLine($"\n----------------------------------\n");
            Console.WriteLine($"Press Enter to draw...\n");
            Console.ReadKey();


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

            foreach (var lad in lads){lad.PrintRecievedTeams();}

            Console.ReadKey();
        }

    }
}
