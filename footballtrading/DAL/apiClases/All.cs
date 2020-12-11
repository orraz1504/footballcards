using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.apiClases
{
    public class Filters
    {
        public string matchday { get; set; }
    }

    public class Area
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Competition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class Season
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int currentMatchday { get; set; }
    }

    public class Coach
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countryOfBirth { get; set; }
        public string nationality { get; set; }
    }

    public class Captain
    {
        public int id { get; set; }
        public string name { get; set; }
        public int shirtNumber { get; set; }
    }

    public class Lineup
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int shirtNumber { get; set; }
    }

    public class Bench
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int shirtNumber { get; set; }
    }

    public class HomeTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coach coach { get; set; }
        public Captain captain { get; set; }
        public List<Lineup> lineup { get; set; }
        public List<Bench> bench { get; set; }
    }

    public class Coach2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countryOfBirth { get; set; }
        public string nationality { get; set; }
    }

    public class Captain2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int shirtNumber { get; set; }
    }

    public class Lineup2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int shirtNumber { get; set; }
    }

    public class Bench2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int shirtNumber { get; set; }
    }

    public class AwayTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coach2 coach { get; set; }
        public Captain2 captain { get; set; }
        public List<Lineup2> lineup { get; set; }
        public List<Bench2> bench { get; set; }
    }

    public class FullTime
    {
        public int? homeTeam { get; set; }
        public int? awayTeam { get; set; }
    }

    public class HalfTime
    {
        public int? homeTeam { get; set; }
        public int? awayTeam { get; set; }
    }

    public class ExtraTime
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Penalties
    {
        public object homeTeam { get; set; }
        public object awayTeam { get; set; }
    }

    public class Score
    {
        public string winner { get; set; }
        public string duration { get; set; }
        public FullTime fullTime { get; set; }
        public HalfTime halfTime { get; set; }
        public ExtraTime extraTime { get; set; }
        public Penalties penalties { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Scorer
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Assist
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Goal
    {
        public int minute { get; set; }
        public object type { get; set; }
        public Team team { get; set; }
        public Scorer scorer { get; set; }
        public Assist assist { get; set; }
    }

    public class Team2
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Booking
    {
        public int minute { get; set; }
        public Team2 team { get; set; }
        public Player player { get; set; }
        public string card { get; set; }
    }

    public class Team3
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PlayerOut
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PlayerIn
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Substitution
    {
        public int minute { get; set; }
        public Team3 team { get; set; }
        public PlayerOut playerOut { get; set; }
        public PlayerIn playerIn { get; set; }
    }

    public class Referee
    {
        public int id { get; set; }
        public string name { get; set; }
        public object nationality { get; set; }
    }

    public class Match
    {
        public int id { get; set; }
        public Season season { get; set; }
        public DateTime utcDate { get; set; }
        public string status { get; set; }
        public int attendance { get; set; }
        public int matchday { get; set; }
        public string stage { get; set; }
        public string group { get; set; }
        public DateTime lastUpdated { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public Score score { get; set; }
        public List<Goal> goals { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Substitution> substitutions { get; set; }
        public List<Referee> referees { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public Filters filters { get; set; }
        public Competition competition { get; set; }
        public List<Match> matches { get; set; }
    }
}
