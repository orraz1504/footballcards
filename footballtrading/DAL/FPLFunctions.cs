using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FPLFunctions
    {
        public static string getByClubID(int ID)
        {
            string com = "SELECT * FROM [Clubs] where [ID] = "+ID;
            DataTable dt = oledbhelper.GetTable(com);
            string ret = dt.Rows[0].ItemArray[1].ToString();
            return ret;
        }
        public static Dictionary<int, string> getdicOfClubs()
        {
            Dictionary<int, string> clubs = new Dictionary<int, string>();
            string com = "SELECT * FROM [Clubs]";
            DataTable dt = oledbhelper.GetTable(com);
            foreach (DataRow dr in dt.Rows)
            {
                clubs.Add(Convert.ToInt32(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString());
            }
            return clubs;
        }
        public static string getByCardID(int ID)
        {
            string com = "SELECT * FROM [card] where [CardID] = " + ID;
            DataTable dt = oledbhelper.GetTable(com);
            return dt.Rows[0].ItemArray[1].ToString();
        }
    }
}
