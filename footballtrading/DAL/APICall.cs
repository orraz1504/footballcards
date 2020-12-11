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
            WebRequest request = HttpWebRequest.Create(@"https://fantasy.premierleague.com/api/fixtures/");
            WebResponse responce = request.GetResponse();
            StreamReader reader = new StreamReader(responce.GetResponseStream());
            string football_Jason = reader.ReadToEnd();

            var call = JsonConvert.DeserializeObject<List<Root>>(football_Jason);
            return call;
        }
    }
}
