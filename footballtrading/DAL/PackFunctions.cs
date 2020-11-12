using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PackFunctions
    {
        public static string[] getByPackId(int Id)
        {
            string com = "SELECT * FROM [pack] where [packID] = " + Id;
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows[0].ItemArray.Length;
            string[] mrow = new string[itmLength - 1];
            for (int i = 1; i < itmLength; i++)
            {
                mrow[i - 1] = dt.Rows[0].ItemArray[i].ToString();
            }
            return mrow;
        }
        public static List<int> packsByUsername(string username)
        {
            List<int> ret = new List<int>();
            string com = "SELECT * FROM [packinventory] where [username] = '" + username+"'";
            DataTable dt = oledbhelper.GetTable(com);
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(Convert.ToInt32(dr.ItemArray[2]));
            }
            return ret;
        }
        public static void deletePack(int packID)
        {
            string com = "DELETE * FROM [packinventory] where [ID] = " + packID;
            oledbhelper.Execute(com);
        }
    }
}
