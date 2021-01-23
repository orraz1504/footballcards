using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bet
    {
        public string gameId { get; set; }
        public string winner { get; set; }
        public string score { get; set; }
        public string scorer { get; set; }
        public bool didClaim { get; set; }
        public Bet(string gameID, string winner, string score, string scorer, int didClaim)
        {
            this.gameId = gameID;
            this.winner = winner;
            this.score = score;
            this.scorer = scorer;
            if (didClaim == 0)
                this.didClaim = false;
            else
                this.didClaim = true;
        }

    }
}
