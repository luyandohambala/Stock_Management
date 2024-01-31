using CommunityToolkit.Mvvm.ComponentModel;
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
        public Command_Class add_record => new(execute => add_to_database());

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
        private string cost;

        [ObservableProperty]
        private List<string> category_listItems = new() { "Product", "Service"};// category combobx items.


        public stock_page_viewmodel()
        {
            //populate_table();
        }

        [ObservableProperty]
        private Database_list value2;

        private void add_to_database()
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

                if (!to_compare.Contains($"{Name.ToLower().Trim()}, {Type.ToLower().Trim()}, {Category.ToLower().Trim()}, {Quantity}, {Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}"))
                {
                    Data_lists.Add(
                        new(Name.Trim(), Type.Trim(), Category.Trim(), Quantity, $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost.Trim()):N2}")
                        );

                    clear_items();
                    
                    MessageBox.Show("Record added.");
                }
                
            }
        }

        private void populate_table()
        {
            Data_lists = new();
            Sales_lists_ = new();
        }

        //search list for specific product
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_table();
                Data_lists = new(Data_lists.Where(
                filtered => filtered.Name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Type.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Category.Contains(content.ToString().ToLower().Trim()) ||
                filtered.Quantity.Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_table();
            }
        }

        private void search_items_(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_table();
                Sales_lists_ = new(Sales_lists_.Where(
                filtered => filtered.Date.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Item_name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Cashier.Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_table();
            }
        }

        private void remove()
        {
            if (MessageBox.Show("Remove Record?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Data_lists.Remove(Value2);
                populate_table();
            }
        }

        private bool validate_entry()
        {
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Type) || String.IsNullOrEmpty(Category)
                || String.IsNullOrEmpty(Quantity) || String.IsNullOrEmpty(Cost))
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
            Name = string.Empty;
            Type = string.Empty;
            Category = null;
            Quantity = string.Empty;
            Cost = string.Empty;
        }
    }
}
