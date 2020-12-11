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
            return dt.Rows[0].ItemArray[1].ToString();
        }
        public static string getByCardID(int ID)
        {
            string com = "SELECT * FROM [card] where [CardID] = " + ID;
            DataTable dt = oledbhelper.GetTable(com);
            return dt.Rows[0].ItemArray[1].ToString();
        }
    }
}
