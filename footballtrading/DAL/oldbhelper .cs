using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Web;

public static class oledbhelper
{
    static OleDbConnection cn = new OleDbConnection(ConnectionString);     

    public static string ConnectionString
    {
        get
        {
            string path = @"C:\DB\football.accdb";
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        }
    }

    //שאילתות עדכון מבנה ה –Database ושאילתות עדכון ,מחיקה והוספת רשומות.

    public static void Execute(string com)
    {
        //Connection  יצירת אובייקט מסוג 
        //OleDbConnection cn = new OleDbConnection(ConnectionString);
        //cn.Open();
           
        if (cn.State != ConnectionState.Open)
        {
            cn.Open();
        }
        // command יצירת אובייקט מסוג
        OleDbCommand command = new OleDbCommand();
        command.Connection = cn;
        command.CommandText = com;

        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
           
    }
    public static DataTable GetTable(string com)
    {
        //Connection  יצירת אובייקט מסוג 
        OleDbConnection cn = new OleDbConnection(ConnectionString);
        // command יצירת אובייקט מסוג 
        OleDbCommand command = new OleDbCommand();
        command.Connection = cn;
        command.CommandText = com;

        //יצירת אובייקט מסוג דטהסט - אוסף טבלאות בזיכרון 
        DataTable dt = new DataTable();
        dt.TableName = "tbl";

        //יצירת אובייקט אדפטר מטרתו לתאם בין הדטהסט לדטהבייס
        OleDbDataAdapter adapter = new OleDbDataAdapter(command);

        cn.Open();

        try
        {
            //הפעולה פותחת את הדטהבייס ומחזירה את כל הנתונים לתוך טבלה חדשה בדטהסט

            adapter.Fill(dt);
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            cn.Close();
        }

        return dt;
    }
}