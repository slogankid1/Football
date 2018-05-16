using System;
using System.Collections.Generic;

namespace WC2018SweepStake
{
    public class Lad
    {

        public string name;
        public string PotOneTeam { get; set; }
        public string PotTwoTeam { get; set; }
        public string PotThreeTeam { get; set; }
        public string PotFourTeam { get; set; }

        public Lad(string Name)
        {
            name = Name;
        }

        public void PrintRecievedTeams()
        {
            if (PotOneTeam == null || PotTwoTeam == null || PotThreeTeam == null || PotFourTeam == null)
            {
                Console.WriteLine(name + " has not got four teams associated with them.");
            }
            else
            {
                Console.WriteLine(name + " has: " + PotOneTeam + ", " + PotTwoTeam + ", " + PotThreeTeam + ", and " + PotFourTeam + ".");
            }
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            //Add Teams to each pot
            List<string> PotOneTeams = new List<string>();
            //PotOneTeams.Add("Russia");
            PotOneTeams.Add("Germany");
            PotOneTeams.Add("Brazil");
            PotOneTeams.Add("Portugal");
            PotOneTeams.Add("Argentina");
            PotOneTeams.Add("Belgium");
            PotOneTeams.Add("Poland");
            PotOneTeams.Add("France");

            List<string> PotTwoTeams = new List<string>();
            PotTwoTeams.Add("Spain");
            //PotTwoTeams.Add("Peru");
            PotTwoTeams.Add("Switzerland");
            PotTwoTeams.Add("England");
            PotTwoTeams.Add("Colombia");
            PotTwoTeams.Add("Mexico");
            PotTwoTeams.Add("Uruguay");
            PotTwoTeams.Add("Croatia");

            List<string> PotThreeTeams = new List<string>();
            PotThreeTeams.Add("Denmark");
            PotThreeTeams.Add("Iceland");
            PotThreeTeams.Add("Costa Rica");
            PotThreeTeams.Add("Sweden");
            PotThreeTeams.Add("Tunisia");
            PotThreeTeams.Add("Egypt");
            PotThreeTeams.Add("Senegal");
            //PotThreeTeams.Add("Iran");

            List<string> PotFourTeams = new List<string>();
            PotFourTeams.Add("Serbia");
            PotFourTeams.Add("Nigeria");
            PotFourTeams.Add("Australia");
            PotFourTeams.Add("Japan");
            PotFourTeams.Add("Morocco");
            PotFourTeams.Add("Panama");
            PotFourTeams.Add("South Korea");
            //PotFourTeams.Add("Saudi Arabia");

            //Create Sweepstake players
            List<Lad> lads = new List<Lad>();
            //Lad james = new Lad("James");
            lads.Add(new Lad james("James"));
            Lad harry = new Lad("Harry");
            lads.Add(harry);
            Lad connor = new Lad("Connor");
            lads.Add(connor);
            Lad dan = new Lad("Dan");
            lads.Add(dan);
            Lad glenn = new Lad("Glenn");
            lads.Add(glenn);
            Lad joe = new Lad("Joe");
            lads.Add(joe);
            Lad john = new Lad("John");
            lads.Add(john);

            //Randomises Lad order
            Random rng = new Random();
            int n = lads.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Lad value = lads[k];
                lads[k] = lads[n];
                lads[n] = value;
            }

            //Need some more girls in here
            if (lads.Count > PotOneTeams.Count)
            {
                throw new ArgumentException("Too many lads");
            }

            Random rnd = new Random();
            foreach (Lad lad in lads)
            {
                //chooses at random which team in each pot Lad will get
                int potOneRand = rnd.Next(PotOneTeams.Count);
                int potTwoRand = rnd.Next(PotTwoTeams.Count);
                int potThreeRand = rnd.Next(PotThreeTeams.Count);
                int potFourRand = rnd.Next(PotFourTeams.Count);

                //Assigns lad team from each pot
                lad.PotOneTeam = PotOneTeams[potOneRand];
                PotOneTeams.RemoveAt(potOneRand);

                lad.PotTwoTeam = PotTwoTeams[potTwoRand];
                PotTwoTeams.RemoveAt(potTwoRand);

                lad.PotThreeTeam = PotThreeTeams[potThreeRand];
                PotThreeTeams.RemoveAt(potThreeRand);

                lad.PotFourTeam = PotFourTeams[potFourRand];
                PotFourTeams.RemoveAt(potFourRand);

                lad.PrintRecievedTeams();
            }

            Console.ReadKey();
        }

    }
}
