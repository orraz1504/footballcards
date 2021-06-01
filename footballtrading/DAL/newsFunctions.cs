using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class newsFunctions
    {
        public static string[] GetLatestNews()
        {
            string com = "SELECT * FROM [news]";
            DataTable dt = oledbhelper.GetTable(com);
            string[] ret = new string[2];
            int last = dt.Rows.Count - 1;
            ret[0] = dt.Rows[last].ItemArray[1].ToString();
            ret[1] = dt.Rows[last].ItemArray[2].ToString();
            return ret;
        }
        public static string[] GetLatestGame()
        {
            string com = "SELECT * FROM [news]";
            DataTable dt = oledbhelper.GetTable(com);
            string[] ret = new string[2];
            int last = dt.Rows.Count - 1;
            ret[0] = dt.Rows[last].ItemArray[1].ToString();
            ret[1] = dt.Rows[last].ItemArray[2].ToString();
            return ret;
        }
    }
}
