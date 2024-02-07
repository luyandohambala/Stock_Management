using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class stock_page_viewmodel : ObservableObject
    {
        //clear input items from itemsbox 
        public Command_Class clear_all2 => new(execute => clear_items());

        //assign remove command 
        public Command_Class remove_record => new(execute => remove(), canExecute => Value2 != null);

        //assign add command 
        public Command_Class add_record => new(execute => add_to_database("add"), canExecute => !edit_values1);

        //assign edit command
        public Command_Class edit_users_command1 => new(execute => add_to_database("edit"), canExecute => Value2 != null);

        //assign search command 
        public Command_Class search_for2 => new(search_items);
        public Command_Class search_for_2 => new(search_items_);


        [ObservableProperty]
        public static ObservableCollection<Database_list> data_lists = new();

        [ObservableProperty]
        public static ObservableCollection<Sales_list_Class> sales_lists_ = new();

        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string type;
        [ObservableProperty]
        private string? category = string.Empty;
        [ObservableProperty]
        private string quantity;
        [ObservableProperty]
        private string profit;
        [ObservableProperty]
        private string cost;

        [ObservableProperty]
        private string button_state1 = "Edit";

        private bool edit_values1 = false;

        [ObservableProperty]
        private List<string> category_listItems = new() { "Product", "Service"};// category combobx items.


        public stock_page_viewmodel()
        {
            populate_table(false);
        }

        [ObservableProperty]
        private Database_list value2;

        private void add_to_database(string to_do)
        {

            if (!edit_values1)
            {
                if (to_do == "add")
                {
                    if (validate_entry())
                    {
                        MessageBox.Show("Fill in all fields before adding a record!");
                    }
                    else
                    {
                        ObservableCollection<string> to_compare = new();

                        foreach (var item in Data_lists)
                        {
                            to_compare.Add($"{item.Name.ToLower()}, {item.Type.ToLower()}, {item.Category.ToLower()}, {item.Quantity}, {item.Cost.ToLower()}");
                        }

                        var comparison = Data_lists.FirstOrDefault(x => x.Id.ToLower() == $"{Name},{Type},{Category},{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}".ToLower());

                        if (comparison == null)
                        {
                            if (Category == "Product")
                            {
                                Database_list stock_entry = new($"{Name},{Type},{Category},{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                Name.Trim(), Type.Trim(), Category.Trim(), Quantity, $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                $"{Settings_Page_ViewModel.currency_}{double.Parse(Profit.Trim()):N2}");

                                if (Database_Connection_Class.Modify_Stock_Table("insert", stock_entry)) 
                                {
                                    clear_items();
                                    MessageBox.Show("Record added.");
                                };
                                
                            }
                            else if (Category == "Service")
                            {
                                Database_list stock_entry = new($"{Name},{Type},{Category},{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                Name.Trim(), Type.Trim(), Category.Trim(), "N/A", $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                $"{Settings_Page_ViewModel.currency_}{double.Parse(Profit.Trim()):N2}");

                                if (Database_Connection_Class.Modify_Stock_Table("insert", stock_entry))
                                {
                                    clear_items();
                                    MessageBox.Show("Record added.");
                                };
                            }

                            populate_table(true);
                            
                        }

                    }
                }
                else if(to_do == "edit")
                {
                    if (Value2.Category == "Product")
                    {
                        Name = Value2.Name;
                        Type = Value2.Type;
                        Category = Value2.Category;
                        Quantity = Value2.Quantity;
                        Cost = Value2.Cost.Replace(Settings_Page_ViewModel.currency_, "");
                        Profit = Value2.Profit.Replace(Settings_Page_ViewModel.currency_, "");
                    }
                    else if (Value2.Category == "Service")
                    {
                        Name = Value2.Name;
                        Type = Value2.Type;
                        Category = Value2.Category;
                        Cost = Value2.Cost.Replace(Settings_Page_ViewModel.currency_, "");
                        Profit = Value2.Profit.Replace(Settings_Page_ViewModel.currency_, "");
                    }

                    
                    edit_values1 = true;
                    Button_state1 = "Save";
                }
            }
            else
            {
                if (Value2 != null && !validate_entry())
                {
                    
                    if (Category == "Product")
                    {
                        Database_list stock_entry = new($"{Name},{Type},{Category},{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                Name.Trim(), Type.Trim(), Category.Trim(), Quantity, $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                $"{Settings_Page_ViewModel.currency_}{double.Parse(Profit.Trim()):N2}");

                        if (Database_Connection_Class.Modify_Stock_Table("modify", stock_entry))
                        {
                            Button_state1 = "Edit";
                            edit_values1 = false;
                            MessageBox.Show("Record details edited.");
                            populate_table(true);
                            clear_items();
                        };
                    }
                    else if (Category == "Service")
                    {
                        Database_list stock_entry = new($"{Name},{Type},{Category},{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                Name.Trim(), Type.Trim(), Category.Trim(), "N/A", $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}",
                                $"{Settings_Page_ViewModel.currency_}{double.Parse(Profit.Trim()):N2}");

                        if (Database_Connection_Class.Modify_Stock_Table("modify", stock_entry))
                        {
                            Button_state1 = "Edit";
                            edit_values1 = false;
                            MessageBox.Show("Record details edited.");
                            populate_table(true);
                            clear_items();
                        };
                    }
                    
                }
            }
        }

        private void populate_table(bool modify)
        {
            Data_lists = Database_Connection_Class.Load_Stock();
            Sales_lists_ = Database_Connection_Class.Load_Sales();
        }

        public static void repopulate_fields()
        {
            data_lists = Database_Connection_Class.Load_Stock();
            sales_lists_ = Database_Connection_Class.Load_Sales();            
        }

        //search list for specific product
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_table(true);
                Data_lists = new(Data_lists.Where(
                filtered => filtered.Name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Type.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Category.Contains(content.ToString().ToLower().Trim()) ||
                filtered.Quantity.Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_table(true);
            }
        }

        private void search_items_(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_table(true);
                Sales_lists_ = new(Sales_lists_.Where(
                filtered => filtered.Date.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Item_name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Cashier.Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_table(true);
            }
        }

        private void remove()
        {
            if (MessageBox.Show("Remove Record?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (Database_Connection_Class.Modify_Stock_Table("delete", Value2))
                {
                    MessageBox.Show("Record Deleted");
                    populate_table(true);
                }
                
            }
        }

        private bool validate_entry()
        {

            if (Category == "Product" && (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Type) || String.IsNullOrEmpty(Category)
                 || String.IsNullOrEmpty(Quantity) || String.IsNullOrEmpty(Profit) || String.IsNullOrEmpty(Cost)))
            {
                return true;
            }
            else if (Category == "Service" && (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Type) || String.IsNullOrEmpty(Category)
                    || String.IsNullOrEmpty(Profit) || String.IsNullOrEmpty(Cost)))
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
            if (Category == "Product")
            {
                Name = string.Empty;
                Type = string.Empty;
                Category = null;
                Quantity = string.Empty;
                Profit = string.Empty;
                Cost = string.Empty;
            }
            else if (Category == "Service")
            {
                Name = string.Empty;
                Type = string.Empty;
                Category = null;
                Profit = string.Empty;
                Cost = string.Empty;
            }
            else
            {
                Name = string.Empty;
                Type = string.Empty;
                Category = null;
                Quantity = string.Empty;
                Profit = string.Empty;
                Cost = string.Empty;
            }
        }

        
    }
}
