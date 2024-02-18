using Dapper;
using Microsoft.Extensions.Configuration;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
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

        public static ObservableCollection<settings_data> Load_Users()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<settings_data>("SELECT * FROM User_Table");
                return new ObservableCollection<settings_data>(result);

            }
        }

        public static bool Verify_User(settings_data user_data)
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<settings_data>(@"Select User_name, Password_entry FROM User_Table 
                                                        WHERE User_name = @User_name AND Password_entry = @Password_entry", user_data);
                if (result.Count() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public static ObservableCollection<report_data> Load_Reports()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                var result = db.Query<report_data>("SELECT Date, " +
                    "CASE WHEN Sent = 1 THEN \"true\" ELSE \"false\" END as Sent FROM Report_Table");
                return new ObservableCollection<report_data>(result);

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
                try
                {
                    db.Execute(@"INSERT INTO Sales_Table VALUES 
                                                        (@Date,
                                                        @Item_name,
                                                        @Item_quantity,
                                                        @Amount,
                                                        @Change,
                                                        @Profit,
                                                        @Cashier)", Sales_List);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                    return false;
                }
            }
        }

        public static bool Modify_User_Table(string to_do, settings_data User_Object)
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                try
                {
                    if (to_do == "insert")
                    {
                        db.Execute(@"INSERT INTO User_Table VALUES 
                                                        (@First_name,
                                                        @Last_name,
                                                        @User_name,
                                                        @Email_address,
                                                        @Password_entry,
                                                        @Authority_)", User_Object);
                        return true;
                    }
                    else if (to_do == "modify")
                    {
                        db.Execute(@"UPDATE User_Table SET First_name = @First_name,
                                                    Last_name = @Last_name,
                                                    User_name = @User_name,
                                                    Email_address = @Email_address,
                                                    Password_entry = @Password_entry,
                                                    Authority_ = @Authority_
                                                    WHERE User_name = @User_name", User_Object);
                        return true;
                    }
                    else if (to_do == "delete")
                    {
                        db.Execute(@"DELETE FROM User_Table WHERE User_name = @User_name", User_Object);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                    return false;
                }
            }
            
        }

        public static bool Modify_Report_Table(string to_do, report_data Report_Object)
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                try
                {
                    if (to_do == "insert")
                    {
                        db.Execute(@"INSERT INTO Report_Table VALUES 
                                                        (@Date,
                                                        @Sent)", Report_Object);
                        return true;
                    }
                    else if (to_do == "modify")
                    {
                        db.Execute(@"UPDATE User_Table SET Sent = @Sent
                                                    WHERE Date = @Date", Report_Object);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                    return false;
                }
            }
        }


        //back up database after set amount of time
        public static string Backup_Database()
        {
            using (IDbConnection db = new SQLiteConnection(Connect()))
            {
                //delete previous backup
                foreach (var item in Directory.GetFiles(@".\Assets\Backup"))
                {
                    File.Delete(item);
                }

                //prepare and store backup
                string backup_location = System.IO.Path.GetFullPath(@".\Assets\Backup\Resource_BackUp.db");
                db.Execute($"VACUUM INTO \".\\Assets\\Backup\\Resource_BackUp.db\"");
                return backup_location;

            }
        }


    }
}
