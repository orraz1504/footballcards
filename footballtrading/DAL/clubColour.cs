using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clubColour
    {
        public string mcolour { get; set; }
        public string scolour { get; set; }
        public clubColour(string mcolour, string scolour)
        {
            this.mcolour = mcolour;
            this.scolour = scolour;
        }
    }
}
