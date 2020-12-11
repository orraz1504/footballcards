using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.apiClases
{
    public class A
    {
        public int value { get; set; }
        public int element { get; set; }
    }

    public class H
    {
        public int value { get; set; }
        public int element { get; set; }
    }

    public class Stat
    {
        public string identifier { get; set; }
        public IList<A> a { get; set; }
        public IList<H> h { get; set; }
    }

    public class Root
    {
        public int code { get; set; }
        public int? @event { get; set; }
        public bool finished { get; set; }
        public bool finished_provisional { get; set; }
        public int id { get; set; }
        public DateTime? kickoff_time { get; set; }
        public int minutes { get; set; }
        public bool provisional_start_time { get; set; }
        public bool? started { get; set; }
        public int team_a { get; set; }
        public int? team_a_score { get; set; }
        public int team_h { get; set; }
        public int? team_h_score { get; set; }
        public IList<Stat> stats { get; set; }
        public int team_h_difficulty { get; set; }
        public int team_a_difficulty { get; set; }
        public int pulse_id { get; set; }
    }
}
