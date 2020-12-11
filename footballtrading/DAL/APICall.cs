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
        public static Root GetCall()
        {
            WebRequest request = HttpWebRequest.Create(@"http://api.football-data.org/v2/matches/303789");
            request.Headers.Add("x-auth-token", "728c349faecd47eab36bbb6b8a952bbb");
            WebResponse responce = request.GetResponse();
            StreamReader reader = new StreamReader(responce.GetResponseStream());
            string football_Jason = reader.ReadToEnd();

            Root call = JsonConvert.DeserializeObject<Root>(football_Jason);
            return call;
        }
    }
}
