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
    }
}
