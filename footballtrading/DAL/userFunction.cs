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
           string com = "insert into [users] ([username],[password],[isAdmin]) VALUES ('" + username+"' ,'"+ AesCryp.encrypt(password)+"','n')";
           oledbhelper.Execute(com);
        }
        public static bool isAdmin(string username)
        {
            string com = "SELECT [isAdmin] FROM [users] where [username] = '" + username + "'";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows[0].ItemArray[0].ToString() == "y")
                return true;
            return false;
        }
        public static void toggleAdmin(string username)
        {
            string com = "SELECT [isAdmin] FROM [users] where [username] = '" + username + "'";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows[0].ItemArray[0].ToString() == "y")
            {
                string com2 = $"update [users] set [isAdmin]='n' where [username]='{username}'";
                oledbhelper.Execute(com2);
            }
            else
            {
                string com2 = $"update [users] set [isAdmin]='y' where [username]='{username}'";
                oledbhelper.Execute(com2);
            }
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
            string com = $"update [users] set [password]='{password}' where [username]='{username}'";
            oledbhelper.Execute(com);
        }
    
        public static void Deleteuser(string username)
        {
            string com = $"DELETE FROM [users] WHERE [username] ='{username}'";
            oledbhelper.Execute(com);
        }
        public static string GetUsers()
        {
            string sql = "Select * from [users]";
            return oledbhelper.printDataTable(sql);
        }
    }
}
