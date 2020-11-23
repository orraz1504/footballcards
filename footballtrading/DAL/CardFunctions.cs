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
        public static List<Card> getByClub(string club)
        {
            List<Card> ret = new List<Card>();
            string com = "SELECT * FROM [card] where [club] = '" + club + "'";
            DataTable dt = oledbhelper.GetTable(com);
            foreach (DataRow dr in dt.Rows)
            {
                Card c = new Card(Convert.ToInt32(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), Convert.ToInt32(dr.ItemArray[5].ToString()), dr.ItemArray[6].ToString(), dr.ItemArray[7].ToString());

                ret.Add(c);
            }
            return ret;
        }
        public static Card getByRating(int ratinglow, int ratinghigh)
        {
            string com = "SELECT * FROM [card] where [rating] >= " + ratinglow + " and [rating] <=" + ratinghigh;
            DataTable dt = oledbhelper.GetTable(com);
            Random rnd = new Random();
            int num = rnd.Next(0, dt.Rows.Count);
            DataRow dr = dt.Rows[num];
            int itemNum = dr.ItemArray.Length;
            Card c = new Card(Convert.ToInt32(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), Convert.ToInt32(dr.ItemArray[5].ToString()), dr.ItemArray[6].ToString(), dr.ItemArray[7].ToString());
            return c;
        }
        public static Card getByCardId(int Id)
        {
            string com = "SELECT * FROM [card] where [cardID] = " + Id;
            DataTable dt = oledbhelper.GetTable(com);
            DataRow dr = dt.Rows[0];
            int itemNum = dr.ItemArray.Length;
            Card c = new Card(Convert.ToInt32(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), Convert.ToInt32(dr.ItemArray[5].ToString()), dr.ItemArray[6].ToString(), dr.ItemArray[7].ToString());
            return c;
        }
    }
}
