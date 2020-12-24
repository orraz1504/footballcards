using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.apiClases
{
    public class Event
    {
        public int? id { get; set; }
        public string name { get; set; }
        public DateTime? deadline_time { get; set; }
        public int? average_entry_score { get; set; }
        public bool? finished { get; set; }
        public bool? data_checked { get; set; }
        public object highest_scoring_entry { get; set; }
        public int? deadline_time_epoch { get; set; }
        public int? deadline_time_game_offset { get; set; }
        public object highest_score { get; set; }
        public bool? is_previous { get; set; }
        public bool? is_current { get; set; }
        public bool? is_next { get; set; }
        public List<object> chip_plays { get; set; }
        public object most_selected { get; set; }
        public object most_transferred_in { get; set; }
        public object top_element { get; set; }
        public object top_element_info { get; set; }
        public int? transfers_made { get; set; }
        public object most_captained { get; set; }
        public object most_vice_captained { get; set; }
    }

    public class GameSettings
    {
    }

    public class BooStat
    {
        public List<Event> events { get; set; }
        public GameSettings game_settings { get; set; }
        public List<object> phases { get; set; }
        public List<object> teams { get; set; }
        public int total_players { get; set; }
        public List<object> elements { get; set; }
        public List<object> element_stats { get; set; }
        public List<object> element_types { get; set; }
    }
}
