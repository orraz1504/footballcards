using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.apiClases;

namespace DALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Root> a = APICall.GetCall();
            string p = "";
            foreach (Root match in a)
            {
                p = FPLFunctions.getByClubID(match.team_h) + $"({match.team_h_score} - {match.team_a_score}) " + FPLFunctions.getByClubID(match.team_a)+ "\n";
                try
                {
                    foreach (var goals in match.stats[0].a)
                    {
                        p += $"player {FPLFunctions.getByCardID(goals.element)} scored {goals.value} goals\n";
                    }
                    foreach (var goals in match.stats[0].h)
                    {
                        p += $"player {FPLFunctions.getByCardID(goals.element)} scored {goals.value} goals\n";
                    }
                }
                catch
                {
                    p += $"error with player";
                }

                Console.WriteLine(p);
            }
        }
    }
}
