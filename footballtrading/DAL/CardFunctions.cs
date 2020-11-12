using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CardFunctions
    {
        public static List<string[]> getByClub(string club)
        {
            List<string[]> ret = new List<string[]>();
            string com = "SELECT * FROM [card] where [club] = '" + club + "'";
            DataTable dt = oledbhelper.GetTable(com);
            foreach (DataRow row in dt.Rows)
            {
                int itmLength = row.ItemArray.Length;
                string[] mrow = new string[itmLength];
                for (int i = 0; i < itmLength; i++)
                {
                    mrow[i] = row.ItemArray[i].ToString();
                }
                ret.Add(mrow);
            }
            return ret;
        }
        public static Card getByRating(int ratinglow, int ratinghigh)
        {
            /*
            Random rnd = new Random();
            List<string[]> ret = new List<string[]>();
            string com = "SELECT * FROM [card] where [rating] >= " + ratinglow+ " and [rating] <="+ ratinghigh;
            DataTable dt = oledbhelper.GetTable(com);
            int j = rnd.Next(0, dt.Rows.Count);
            DataRow dr = dt.Rows[j];
            int itmLength = dr.ItemArray.Length;
            string[] mrow = new string[itmLength];
            for (int i = 0; i < itmLength; i++)
            {
                mrow[i] = dr.ItemArray[i].ToString();
            }
            return mrow;
            */
            string com = "SELECT * FROM [card] where [rating] >= " + ratinglow + " and [rating] <=" + ratinghigh;
            DataTable dt = oledbhelper.GetTable(com);
            Random rnd = new Random();
            int num = rnd.Next(0, dt.Rows.Count);
            DataRow dr = dt.Rows[num];
            int itemNum = dr.ItemArray.Length;
            Card c = new Card(Convert.ToInt32(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), Convert.ToInt32(dr.ItemArray[5].ToString()), dr.ItemArray[6].ToString(), dr.ItemArray[7].ToString());
            return c;

        }
        public static string[] getByCardId(int Id)
        {
            string com = "SELECT * FROM [card] where [cardID] = " + Id;
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows[0].ItemArray.Length;
            string[] mrow = new string[itmLength];
            for (int i = 0; i < itmLength; i++)
            {
                mrow[i] = dt.Rows[0].ItemArray[i].ToString();
            }
            return mrow;
        }
    }
}
