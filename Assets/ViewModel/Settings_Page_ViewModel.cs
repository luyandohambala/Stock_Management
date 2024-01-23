using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using System.Windows;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Settings_Page_ViewModel : ObservableObject
    {
        /// <summary>
        /// commands section
        /// </summary>
        /*public Command_Class save_settings_command => new(execute => save_settings());
        public Command_Class reset_settings_command => new(execute => reset_settings());
*/
        public Command_Class clearall4 => new(execute => clear_items());

        public Command_Class all_users => new(execute => populate_users("all"), canExecute => User_list.Count != 0);
        public Command_Class admin_users => new(execute => populate_users("admin"), canExecute => User_list.Count != 0);
        public Command_Class non_admin_users => new(execute => populate_users("non_admin"), canExecute => User_list.Count != 0);

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
        private string password_entry;

        [ObservableProperty]
        private string authority_;


        [ObservableProperty]
        private int email_backup;

        [ObservableProperty]
        private int backup_data;

        [ObservableProperty]
        private string printer_name;

        [ObservableProperty]
        private string currency_;

        [ObservableProperty]
        private string quotation_template;

        [ObservableProperty]
        private string invoice_template;

        [ObservableProperty]
        private string receipt_template;

        [ObservableProperty]
        private ObservableCollection<settings_data> user_list;

        [ObservableProperty]
        private settings_data value4;

        [ObservableProperty]
        private string button_state = "Edit";

        private bool edit_values = false;

        public Settings_Page_ViewModel()
        {
            populate_users("all");
        }

        private void populate_users(string to_populate)
        {
            if (to_populate == "all")
            {
                User_list = new()
                {
                    new("luyando", "hambala", "lhambala", "gaming123", "admin"),
                    new("bob", "mike", "bobmike", "gaming123", "non-admin"),
                    new("joseph", "bob", "josephbob", "gaming123", "admin"),
                    new("jill", "jack", "jilljack", "gaming123", "non-admin"),
                    new("someone", "hams", "someonehams", "gaming123", "non-admin")
                };
            }
            else if(to_populate == "admin")
            {
                populate_users("all");
                User_list = new(User_list.Where(x => x.Authority_ == "admin"));
            }
            else if(to_populate == "non_admin")
            {
                populate_users("all");
                User_list = new(User_list.Where(x => x.Authority_ == "non_admin"));
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
                        User_list.Add(
                            new(First_name.Trim(), Last_name.Trim(), User_name.Trim(), Password_entry.Trim(), Authority_.Trim())
                            );

                        clear_items();
                    }
                }
                else if (to_do == "edit")
                {
                    First_name = Value4.First_name;
                    Last_name = Value4.Last_name;
                    User_name = Value4.User_name;
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
                    foreach (var item in User_list.Where(x => x.User_name == User_name))
                    {
                        item.First_name = First_name;
                        item.Last_name = Last_name;
                        item.User_name = User_name;
                        item.Password_entry = Password_entry;
                        item.Authority_ = Authority_;
                    }

                    Button_state = "Edit";
                    edit_values = false;
                    MessageBox.Show("User details edited.");
                    clear_items();
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
                filtered.User_name.Contains(content.ToString().ToLower().Trim())));
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
                User_list.Remove(Value4);
                MessageBox.Show("User deleted.");
            }
        }

        private bool validate_entry()
        {
            if (!String.IsNullOrEmpty(First_name) || !String.IsNullOrEmpty(Last_name) || !String.IsNullOrEmpty(User_name) ||
                !String.IsNullOrEmpty(Password_entry) || !String.IsNullOrEmpty(Authority_))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void clear_items()
        {
            First_name = string.Empty;
            Last_name = string.Empty;
            User_name = string.Empty;
            Password_entry = string.Empty;
            Authority_ = string.Empty;

            edit_values = false;
        }
    }
}
