﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.IO;
using System.Management;
using System.Windows;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Settings_Page_ViewModel : ObservableObject
    {
        /// <summary>
        /// commands section
        /// </summary>
        public Command_Class save_settings_command => new(execute => save_settings());
        public Command_Class reset_settings_command => new(execute => reset_settings());
        public Command_Class Restore_Backup_Command => new(execute => Restore_Backups());
        
        public Command_Class choose_printer_command => new(select_printer);
        public Command_Class save_printer_command => new(save_printer);

        public Command_Class choose_quote_inv_receipt_command => new(choose_file);

        public Command_Class clearall4 => new(execute => clear_items());

        public Command_Class all_users => new(execute => populate_users("all"), canExecute => User_list.Count != 0);
        public Command_Class admin_users => new(execute => populate_users("admin"), canExecute => User_list.Count != 0);
        public Command_Class non_admin_users => new(execute => populate_users("non-admin"), canExecute => User_list.Count != 0);

        public Command_Class add_users_command => new(execute => add_users("add"));
        public Command_Class edit_users_command => new(execute => add_users("edit"), canExecute => Value4 != null);
        public Command_Class remove_users_command => new(execute => remove_users(), canExecute => Value4 != null);

        public Command_Class search_for4 => new(search_items);

        /// <summary>
        /// properties section
        /// </summary>
        [ObservableProperty]
        private string first_name;

        [ObservableProperty]
        private string last_name;

        [ObservableProperty]
        private string user_name;
        
        [ObservableProperty]
        private string email_address;

        [ObservableProperty]
        private string password_entry;

        [ObservableProperty]
        private string authority_;

        [ObservableProperty]
        private ObservableCollection<string> authority_listItems = new()
        {
            "Admin", "Non-Admin"
        };


        [ObservableProperty]
        public static string backup_data;

        [ObservableProperty]
        private ObservableCollection<string> backup_data_list = new()
        {
            "7", "28", "Not set"
        };

        [ObservableProperty]
        public static string printer_name;

        [ObservableProperty]
        public static string receipt_printer;

        [ObservableProperty]
        public static string currency_;
        
        [ObservableProperty]
        public static decimal value_added_tax;

        [ObservableProperty]
        public static string quotation_template;

        [ObservableProperty]
        public static string invoice_template;

        [ObservableProperty]
        public static string receipt_template;

        [ObservableProperty]
        public static ObservableCollection<settings_data> user_list;

        [ObservableProperty]
        private ObservableCollection<printer_data> printer_list;

        private string Printer_Type = string.Empty;

        [ObservableProperty]
        private settings_data value4;

        [ObservableProperty]
        private string button_state = "Edit";

        private bool edit_values = false;
        private readonly IConfiguration configuration;

        public Settings_Page_ViewModel(IConfiguration configuration)
        {
            populate_users("all");
            this.configuration = configuration;
            populate_properties();

            Printer_list = new();
        }
        public Settings_Page_ViewModel()
        {
            Printer_list = new();
        }

        private void populate_properties()
        { 
            Backup_data = configuration.GetValue<string>("General_Settings:backup_data");
            Printer_name = configuration.GetValue<string>("General_Settings:printer_name");
            Receipt_printer = configuration.GetValue<string>("General_Settings:receipt_printer");
            Currency_ = configuration.GetValue<string>("General_Settings:currency_value");
            Value_added_tax = configuration.GetValue<decimal>("General_Settings:vat_rate");
            Quotation_template = configuration.GetValue<string>("General_Settings:quotation_temp_location");
            Invoice_template = configuration.GetValue<string>("General_Settings:invoice_temp_location");
            Receipt_template = configuration.GetValue<string>("General_Settings:receipt_temp_location");
        }

        private void populate_users(string to_populate)
        {
            if (to_populate == "all")
            {
                User_list = new(Database_Connection_Class.Load_Users());
            }
            else if(to_populate == "admin")
            {
                populate_users("all");
                User_list = new(User_list.Where(x => x.Authority_ == "Admin"));
            }
            else if(to_populate == "non-admin")
            {
                populate_users("all");
                User_list = new(User_list.Where(x => x.Authority_ == "Non-Admin"));
            }

        }

        private void add_users(string to_do)
        {

            if (!edit_values)
            {
                if (to_do == "add")
                {
                    if (User_list.Select(x => x.User_name).Contains(User_name))
                    {
                        MessageBox.Show("Username already in use");
                    }
                    else
                    {
                        settings_data user = new(First_name.Trim(), Last_name.Trim(), User_name.Trim(), Email_address.Trim(), Password_entry.Trim(), Authority_.Trim());

                        if (Database_Connection_Class.Modify_User_Table("insert", user))
                        {
                            clear_items();
                            populate_users("all");
                        }
                    }
                }
                else if (to_do == "edit")
                {
                    First_name = Value4.First_name;
                    Last_name = Value4.Last_name;
                    User_name = Value4.User_name;
                    Email_address = Value4.Email_address;
                    Password_entry = Value4.Password_entry;
                    Authority_ = Value4.Authority_;
                    
                    edit_values = true;
                    Button_state = "Save";
                }
            }
            else
            {
                if (Value4 != null && validate_entry())
                {
                    
                    settings_data user = new(First_name.Trim(), Last_name.Trim(), User_name.Trim(), Email_address.Trim(), Password_entry.Trim(), Authority_.Trim());

                    if (Database_Connection_Class.Modify_User_Table("modify", user))
                    {
                        Button_state = "Edit";
                        edit_values = false;
                        MessageBox.Show("User details edited.");
                        clear_items();
                        populate_users("all");
                    }
                }
            }
        }

        //search list for specific product
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_users("all");
                User_list = new(User_list.Where(
                filtered => filtered.First_name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Last_name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.User_name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Email_address.Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_users("all");
            }
        }

        private void remove_users()
        {
            if (MessageBox.Show("Remove selected user?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (Database_Connection_Class.Modify_User_Table("delete", Value4))
                {
                    populate_users("all");
                    MessageBox.Show("User deleted.");
                }
            }
        }

        private bool validate_entry()
        {
            if (!String.IsNullOrEmpty(First_name) || !String.IsNullOrEmpty(Last_name) || !String.IsNullOrEmpty(User_name) ||
                !String.IsNullOrEmpty(Password_entry) || !String.IsNullOrEmpty(Email_address) || !String.IsNullOrEmpty(Authority_))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validate_settings()
        {
            if (String.IsNullOrEmpty(Printer_name) || String.IsNullOrEmpty(Currency_) || String.IsNullOrEmpty(Quotation_template) 
                || String.IsNullOrEmpty(Invoice_template) || String.IsNullOrEmpty(Receipt_template))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void clear_items()
        {
            First_name = string.Empty;
            Last_name = string.Empty;
            User_name = string.Empty;
            Email_address = string.Empty;
            Password_entry = string.Empty;
            Authority_ = string.Empty;

            edit_values = false;
        }

        //open custom printer dialog to select printer of choice.
        private void select_printer(object content)
        {
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                if (!Printer_list.Contains(new($"{name}", $"{status}")))
                {
                    Printer_list.Add(new($"{name}", $"{status}"));
                }

            }

            Printer_Type = content.ToString();

            new Print_View().ShowDialog();

        }


        //assign name of printer to respective property
        private void save_printer(object content)
        {
            if (content != null)
            {
                if (Printer_Type == "invoice/quotation")
                {
                    Printer_name = content.ToString();
                }
                else if (Printer_Type == "receipt")
                {
                    Receipt_printer = content.ToString();
                }
            }
            Printer_Type = string.Empty;
        }


        //choose quote/invoice/receipt tempate using file dialog
        private void choose_file(object content)
        {
            OpenFileDialog fileDialog = new();
            if (fileDialog.ShowDialog() == true && !string.IsNullOrEmpty(fileDialog.FileName))
            {
                try
                {
                    var path = System.IO.Path.GetFullPath(@"./Assets/Templates");

                    if (content.ToString() == "quotation")
                    {
                        if (!Directory.Exists(path + "/Quotation"))
                        {
                            Directory.CreateDirectory(path + "/Quotation");
                            File.Copy(fileDialog.FileName, path + "/Quotation/template.docx");

                            Quotation_template = path + @"\Quotation\template.docx";

                        }
                        else
                        {
                            foreach (var item in Directory.GetFiles(path + "/Quotation"))
                            {
                                File.Delete(item);
                            }
                            File.Copy(fileDialog.FileName, path + "/Quotation/template.docx");

                            Quotation_template = path + @"\Quotation\template.docx";
                        }
                    }
                    else if (content.ToString() == "invoice")
                    {
                        if (!Directory.Exists(path + "/Invoice"))
                        {
                            Directory.CreateDirectory(path + "/Invoice");
                            File.Copy(fileDialog.FileName, path + "/Invoice/template.docx");

                            Invoice_template = path + @"\Invoice\template.docx";

                        }
                        else
                        {
                            foreach (var item in Directory.GetFiles(path + "/Invoice"))
                            {
                                File.Delete(item);
                            }
                            File.Copy(fileDialog.FileName, path + "/Invoice/template.docx");

                            Invoice_template = path + @"\Invoice\template.docx";
                        }

                    }
                    else if (content.ToString() == "receipt")
                    {
                        if (!Directory.Exists(path + "/Receipt"))
                        {
                            Directory.CreateDirectory(path + "/Receipt");
                            File.Copy(fileDialog.FileName, path + "/Receipt/template.docx");

                            Receipt_template = path + @"\Receipt\template.docx";

                        }
                        else
                        {
                            foreach (var item in Directory.GetFiles(path + "/Receipt"))
                            {
                                File.Delete(item);
                            }
                            File.Copy(fileDialog.FileName, path + "/Receipt/template.docx");

                            Receipt_template = path + @"\Receipt\template.docx";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error code: {ex.Message}. Please try again later.");
                }
            }
        }

        private void save_settings()
        {
            if (!validate_settings())
            {
                MessageBox.Show("Please fill in all fields in settings section.");
            }
            else
            {
                string[] section_key_names = { "General_Settings:backup_data", "General_Settings:printer_name", "General_Settings:receipt_printer", "General_Settings:currency_value",
                                                "General_Settings:vat_rate", "General_Settings:quotation_temp_location", "General_Settings:invoice_temp_location", "General_Settings:receipt_temp_location"};
                string[] section_key_values = {Backup_data, Printer_name, Receipt_printer, Currency_, Value_added_tax.ToString(), Quotation_template, Invoice_template, Receipt_template};
                
                int counter = 0; //index value for section_key_value array
                foreach (var item in section_key_names)
                {
                    if (write_to_settings(item, section_key_values[counter]))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                MessageBox.Show("Settings have been saved.");
                populate_properties();

            }
        }

        private void reset_settings()
        {
            if (MessageBox.Show("Reset all settings?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string[] section_key_names = { "General_Settings:backup_data", "General_Settings:printer_name", "General_Settings:receipt_printer", "General_Settings:currency_value",
                                                "General_Settings:vat_rate", "General_Settings:quotation_temp_location", "General_Settings:invoice_temp_location", "General_Settings:receipt_temp_location"};
                string[] section_key_values = { "7", "Not set", "Not set", "Not set", "16", "Not set", "Not set", "Not set" };

                int counter = 0; //index value for section_key_value array
                foreach (var item in section_key_names)
                {
                    if (write_to_settings(item, section_key_values[counter]))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
                MessageBox.Show("Settings have been reset.");
                populate_properties();
            }
        }

        private bool write_to_settings<T>(string sectionPathKey, T value)
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppContext.BaseDirectory, "appsettings.Development.json");
                string json = File.ReadAllText(filePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var sectionPath = sectionPathKey.Split(":")[0];

                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyPath = sectionPathKey.Split(":")[1];
                    jsonObj[sectionPath][keyPath] = value;
                }
                else
                {
                    jsonObj[sectionPath] = value; // if no sectionpath just set the value
                }

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in saving settings. Error code: {ex.Message}");
                return false;
            }
        }

        private bool Restore_Backups()
        {
            try
            {
                string file_path = System.IO.Path.GetFullPath(@".\Assets\Backup\Resources_BackUp.db");
                if (File.Exists(file_path) && MessageBox.Show("A backup has been located. Restore?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (var item in Directory.GetFiles(file_path))
                    {
                        File.Delete(item);
                    }
                    File.Copy(file_path, System.IO.Path.GetFullPath(@".\Assets\Resources_Database.db"));

                    MessageBox.Show("Data successfully restored.");
                    return true;
                }
                else
                {
                    MessageBox.Show($"No backups found.");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later");
                return false;
            }
        }
    }
}
