using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace UpdateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            FPLFunctions.numofplayers(); // updates the number of players from each cat
            Console.WriteLine("Updated numver of players");
            Console.WriteLine("\n");

            Console.WriteLine("adding games to db");
            APICall.addGamesToDB();

            Console.WriteLine(APICall.getCurrentGameweek(0));
            predictions();
            Console.WriteLine("done with predictions");
            Console.WriteLine("\n");
        }
        public static void predictions()
        {
            int gw = APICall.getCurrentGameweek(0);
            Console.WriteLine("predicting gameweek: "+gw);
            Dictionary<int, string> dic = FPLFunctions.getdicOfClubs();
            foreach (prediction pred in GameFunctions.byGameweek(gw))
            {
                if (pred.awin != null || pred.awin == 0)
                {
                    Console.WriteLine("home team: " + dic[pred.hteam]);
                    Console.WriteLine("away team: " + dic[pred.ateam]);
                    predict(pred.hteam, pred.ateam, pred.gameID);
                    Console.WriteLine("\n");
                }
            }
        }
        public static void predict(int htea, int ateam, int matchID)
        {
            float avggoalsscoredH = FPLFunctions.getallH() / (float)FPLFunctions.getNumHPlayByTeamId(1) / 20;
            //Console.WriteLine("avrage num of goals scored at home " + avggoalsscoredH);
            float avggoalconceededH = FPLFunctions.getallA() / (float)FPLFunctions.getNumHPlayByTeamId(1) / 20;
            //Console.WriteLine("avrage num of goals conceded at home "+ avggoalconceededH);
            
            
            float hattstrength = attackstrength(htea, avggoalsscoredH, true);
            float aattstrength = attackstrength(ateam, avggoalconceededH, false);
            //Console.WriteLine("attacking strength for home team: " + hattstrength);
            //Console.WriteLine("attacking strength for away team: " + aattstrength);



            float hdefstrength = defencetrength(htea, avggoalconceededH ,true);
            float adefstrength = defencetrength(ateam, avggoalsscoredH ,false);
            //Console.WriteLine("defence strength for home team: " + hdefstrength);
            //Console.WriteLine("defenve strength for away team: " + adefstrength);

            float exgH = avggoalconceededH * adefstrength * hattstrength;
            //Console.WriteLine("xg for home team: "+ exgH);
            float exgA = avggoalconceededH * hdefstrength * aattstrength;
            //Console.WriteLine("xg for away team: " + exgA);


            //Console.WriteLine("home prob");
            double[] a = posDeb(exgH, 5);
            foreach (double d in posDeb(exgH,5))
            {
                //Console.WriteLine(d);
            }
            //Console.WriteLine("away prob");
            double[] b = posDeb(exgA, 5);
            foreach (double d in b)
            {
                //Console.WriteLine(d);
            }


            double[,] outcomes = multipleOutcomes(a, b);
            //Console.WriteLine(outcomes.Length);
            for (int i = 0; i < outcomes.GetLength(0); i++)
            {
                for (int j = 0; j < outcomes.GetLength(1); j++)
                {
                    //Console.Write(outcomes[i,j]+", ");
                }
                //Console.WriteLine("\n");
            }
            double draw = Math.Round(addupoutcomes(outcomes, "d") * 100);
            double home = Math.Round(addupoutcomes(outcomes, "H") * 100);
            double away = Math.Round(addupoutcomes(outcomes, "a") * 100);
            Console.WriteLine("draw: "+draw+"%");
            Console.WriteLine("Home Win: "+home + "%");
            Console.WriteLine("Away Win: " + away + "%");
            GameFunctions.addPrecent(home, draw, away, matchID);
        }
        public static float addupoutcomes(double[,] outcomes, string who)
        {
            if (who.ToUpper() == "D")
            {
                float total = 0;
                for (int i = 0; i < outcomes.GetLength(1); i++)
                {
                    total += (float)outcomes[i, i];
                }
                return total;
            }
            else if (who.ToUpper() == "H")
            {
                float total = 0;
                int not = 1;
                for (int i = 1; i < outcomes.GetLength(1); i++)
                {
                    for (int j = 0; j < not; j++)
                    {
                        total += (float)outcomes[i, j];
                    }
                    not++;
                }
                return total;
            }
            else
            {
                float total = 0;
                int not = 1;
                for (int i = 0; i < outcomes.GetLength(1); i++)
                {
                    for (int j = not; j < outcomes.GetLength(1); j++)
                    {
                        total += (float)outcomes[i, j];
                    }
                    not++;
                }
                return total;
            }
        }
        public static double[,] multipleOutcomes(double[] a, double[] b)
        {
            double[,] ret = new double[a.Length, a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    ret[i, j] = a[i] * b[j];
                }
            }
            return ret;
        }
        public static double[] posDeb(float L, int n)
        {
            double[] final = new double[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                final[i] = (Math.Pow(L, i) * Math.Pow(Math.E, -L)) / factorial(i);
            }
            return final;
        }
        public static double factorial(int n)
        {
            if (n == 0)
                return 1;
            int res = 1;
            while (n != 1)
            {
                res = res * n;
                n = n - 1;
            }
            return res;
        }
        public static float attackstrength(int clubId, float avg, bool home)
        {
            int GF = 1;
            int played = 1;
            if (home)
            {
                played = FPLFunctions.getNumHPlayByTeamId(clubId);
                GF = FPLFunctions.getGFHByTeamId(clubId);
            }
            else
            {
                played = FPLFunctions.getNumAPlayByTeamId(clubId);
                GF = FPLFunctions.getGFAByTeamId(clubId);
            }
            return GF / (float)played / avg;
        }
        public static float defencetrength(int clubId, float avg, bool home)
        {
            int GA = 1;
            int played = 1;
            if (home)
            {
                played = FPLFunctions.getNumHPlayByTeamId(clubId);
                GA = FPLFunctions.getGAHByTeamId(clubId);
            }
            else
            {
                played = FPLFunctions.getNumAPlayByTeamId(clubId);
                GA = FPLFunctions.getGAAAByTeamId(clubId);
            }
            return GA / (float)played / avg;
        }
    }
}
