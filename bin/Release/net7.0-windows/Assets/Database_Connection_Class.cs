﻿using Microsoft.Extensions.Configuration;
using Stock_Management.Assets.Pages;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections.ObjectModel;
using System.Windows;

namespace Stock_Management.Assets
{
    internal static class Database_Connection_Class
    {
        /// <summary>
        /// load sqlite databse connection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Connect(string id = "connection")
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#if DEBUG
            builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
#else
            builder.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
#endif
            return builder.Build().GetConnectionString(id);
        }

        
        /// <summary>
        /// load sales, stock and notification data from database
        /// </summary>
        /// <returns>IEnumerable of above data types</returns>
        public static ObservableCollection<Database_list> Load_Stock()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<Database_list>("SELECT * FROM Stock_Table");
                return new ObservableCollection<Database_list>(result);

            }
        }

        public static ObservableCollection<Sales_list_Class> Load_Sales()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<Sales_list_Class>("SELECT * FROM Sales_Table");
                return new ObservableCollection<Sales_list_Class>(result);

            }
        }

        public static ObservableCollection<Notification_List_Class> Load_Notifications()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<Notification_List_Class>("SELECT Date, Information, " +
                    "CASE WHEN Read = 1 THEN \"true\" ELSE \"false\" END as Read FROM Notification_Table");
                return new ObservableCollection<Notification_List_Class>(result);

            }
        }

       
        /// <summary>
        /// modify stock and notification data in database
        /// </summary>
        /// <param name="to_do"></param>
        /// <param name="stock_object"></param>
        /// <returns></returns>
        public static bool Modify_Stock_Table(string to_do, Database_list stock_object)
        {
            try
            {
                using (IDbConnection db = new SQLiteConnection(Connect()))
                {

                    if (to_do == "insert")
                    {
                        db.Execute(@"INSERT INTO Stock_Table VALUES 
                                                        (@Id,
                                                        @Name,
                                                        @Type,
                                                        @Category,
                                                        @Quantity,
                                                        @Cost,
                                                        @Profit)", stock_object);
                        return true;
                    }
                    else if (to_do == "modify")
                    {
                        db.Execute(@"UPDATE Stock_Table SET Id = @Id,
                                                        Name = @Name,
                                                        Type = @Type,
                                                        Category = @Category,
                                                        Quantity = @Quantity,
                                                        Cost = @Cost,
                                                        Profit = @Profit
                            WHERE (Id = @Id)", stock_object);

                        return true;
                    }
                    else if (to_do == "modify_quantity")
                    {
                        db.Execute(@"UPDATE Stock_Table SET Quantity = @Quantity WHERE (Id = @Id)", stock_object);

                        return true;
                    }
                    else if(to_do == "delete")
                    {
                        db.Execute(@"DELETE FROM Stock_Table WHERE Id = @Id", stock_object);
                        return true;
                    }
                    return false;
                }
            }
            catch (SQLiteException exception)
            {
                MessageBox.Show($"Error code: {exception.Message}. Please try again later.");
                return false;
            }
        }

        public static bool Modify_Notifications_Table(string to_do, Notification_List_Class Notification_object)
        {
            try
            {
                using (IDbConnection db = new SQLiteConnection(Connect()))
                {

                    if (to_do == "insert")
                    {
                        db.Execute(@"INSERT INTO Notification_Table VALUES 
                                                        (@Date,
                                                        @Information,
                                                        @Read)", Notification_object);
                    }
                    else if (to_do == "modify")
                    {
                        db.Execute(@"UPDATE Notification_Table SET Read = @Read
                            WHERE (Date = @Date)", Notification_object);

                        return true;
                    }
                    else if (to_do == "delete")
                    {
                        db.Execute(@"DELETE FROM Notification_Table WHERE Date = @Date", Notification_object);
                        return true;
                    }
                    else if (to_do == "delete all")
                    {
                        db.Execute(@"DELETE FROM Notification_Table");
                        return true;
                    }
                    return false;
                }
            }
            catch (SQLiteException exception)
            {
                MessageBox.Show($"Error code: {exception.Message}. Please try again later.");
                return false;
            }
        }

        public static bool Modify_Sales_Table(Sales_list_Class Sales_List)
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {

                db.Execute(@"INSERT INTO Sales_Table VALUES 
                                (@Date,
                                @Item_name,
                                @Item_quantity,
                                @Amount,
                                @Change,
                                @Profit,
                                @Cashier)", Sales_List);
                return false;
            }
        }


    }
}
