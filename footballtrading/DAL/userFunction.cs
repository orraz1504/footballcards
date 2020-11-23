using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace DAL
{
    public static class userFunction
    {
        public static void AddUser(string username, string password)
        {
           string com = "insert into [users] ([username],[password]) VALUES ('"+username+"' ,'"+ AesCryp.encrypt(password)+"')";
           oledbhelper.Execute(com);
        }
        public static bool checkPassword(string username, string password)
        {
            string com = "SELECT [password] FROM [users] where [username] = '"+username+"'";
            DataTable dt = oledbhelper.GetTable(com);
            string pass =dt.Rows[0].ItemArray[0].ToString();
            if (AesCryp.Decrypt(pass) == password)
                return true;
            return false;
        }
        public static bool isUsername(string username)
        {
            string com = "SELECT * FROM [users] where [username] = '"+username+"'";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static void UpdatePassword(string username, string password)
        {
            string com = "update [users] set [password]='{password}' where [username]='{username}'";
            oledbhelper.Execute(com);
        }
    
        public static void Deleteuser(string username)
        {
            string com = "DELETE FROM [users] WHERE [username] ='{username}'";
            oledbhelper.Execute(com);
        }
    }
}
