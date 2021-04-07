using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class prediction
    {
        public int gameID { get; set; }
        public int hteam { get; set; }
        public int ateam { get; set; }

        public int hwin { get; set; }
        public int draw { get; set; }
        public int awin { get; set; }

        public prediction(int gameID ,int hteam, int ateam)
        {
            this.gameID = gameID;
            this.hteam = hteam;
            this.ateam = ateam;
        }
    }
}
