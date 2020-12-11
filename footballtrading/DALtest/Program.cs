using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.apiClases;

namespace DALtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Root a = APICall.GetCall();
            foreach (Match match in a.matches)
            {
                string w = $"match: {match.homeTeam.name} vs {match.awayTeam.name} \n {match.utcDate.Date} status: {match.status}";
                if (match.status == "FINISHED")
                {
                    w += $"({match.score.fullTime.homeTeam}-{match.score.fullTime.awayTeam})\n";
                    try
                    {
                        foreach (Goal goal in match.goals)
                        {
                            w += $"{goal.scorer} - {goal.minute}min\n";
                        }
                    }
                    catch
                    {
                        w += "no goals";
                    }
                }
                Console.WriteLine(w);
            }

        }
    }
}
