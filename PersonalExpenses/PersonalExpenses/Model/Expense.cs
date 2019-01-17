using Microsoft.AppCenter.Crashes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenses.Model
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }


        //public bool InsertExpense()
        //{
        //    try
        //    {
        //        using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //        {
        //            conn.CreateTable<Expense>();
        //            conn.Insert(expense);

        //        }
        //        return true;
        //    }
        //    catch(Exception e)
        //    {
        //        return false;
        //    }

        //}

        public static List<Expense> GetExpenses()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable(typeof(Expense));
                    return conn.Table<Expense>().ToList();
                }
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
                return new List<Expense>();
            }
        }
    }


}
