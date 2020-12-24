using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DAL.apiClases;

namespace DAL
{
    public class APICall
    {
        public static List<Root> GetCall()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = HttpWebRequest.Create(@"https://fantasy.premierleague.com/api/fixtures/");
            WebResponse responce = request.GetResponse();
            StreamReader reader = new StreamReader(responce.GetResponseStream());
            string football_Jason = reader.ReadToEnd();

            var call = JsonConvert.DeserializeObject<List<Root>>(football_Jason);
            return call;
        }
        public static int getCurrentGameweek()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = HttpWebRequest.Create(@"https://fantasy.premierleague.com/api/bootstrap-static/");
            WebResponse responce = request.GetResponse();
            StreamReader reader = new StreamReader(responce.GetResponseStream());
            string football_Jason = reader.ReadToEnd();

            var call = JsonConvert.DeserializeObject<BooStat>(football_Jason);
            foreach (Event eve in call.events)
            {
                if (eve.finished == false)
                {
                    if (eve.id is int)
                    {
                        return eve.id ?? 1;
                    }
                   
                }
            }
            return 1;
        }
        public static List<Root> sortbyNextGameWeek(List<Root> lr, int currGW)
        {
            List<Root> ret = new List<Root>();
            foreach (Root fixture in lr)
            {
                if (fixture.@event == currGW)
                {
                    ret.Add(fixture);
                }
            }
            return ret;
        }
        private static bool DateInsideOneWeek(DateTime date1, DateTime date2)
        {
            DayOfWeek firstDayOfWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime startDateOfWeek = date1.Date;
            while (startDateOfWeek.DayOfWeek != firstDayOfWeek)
            { startDateOfWeek = startDateOfWeek.AddDays(-1d); }
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6d);
            return date2 >= startDateOfWeek && date2 <= endDateOfWeek;
        }
    }
}
