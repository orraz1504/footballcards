using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class predictor
    {
        public static void predict (List<prediction> ls)
        {
            foreach (prediction pred in ls)
            {
                int hplay = FPLFunctions.getNumHPlayByTeamId(1);
                int hGF = FPLFunctions.getGFHByTeamId(1);
                int hGA = FPLFunctions.getGAHByTeamId(1);
                float hAttStrength = hGF / hplay;
                Console.WriteLine(hAttStrength);
            }
        }
    }
}
