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

        public Command_Class remove_record => new(execute => remove(), canExecute => Value2 != null);

        public Command_Class add_record => new(execute => add_to_database());

        public Command_Class search_for2 => new(search_items);


        [ObservableProperty]
        private ObservableCollection<Database_list> data_lists = new ObservableCollection<Database_list>();

        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string type;
        [ObservableProperty]
        private string category;
        [ObservableProperty]
        private string quantity;
        [ObservableProperty]
        private string cost;
        

        public stock_page_viewmodel()
        {
            populate_table();
        }

        [ObservableProperty]
        private Database_list value2;

        private void add_to_database()
        {
            if (validate_entry())
            {
                MessageBox.Show("fill in all details.");
            }
            else
            {
                
                ObservableCollection<string> to_compare = new();

                foreach (var item in Data_lists)
                {
                    to_compare.Add($"{item.Name.ToLower()}, {item.Type.ToLower()}, {item.Category.ToLower()}, {item.Quantity.ToLower()}, {item.Cost.ToLower()}");
                }

                if (!to_compare.Contains($"{Name.ToLower().Trim()}, {Type.ToLower().Trim()}, {Category.ToLower().Trim()}, {Quantity.ToLower().Trim()}, {Cost.ToLower().Trim()}"))
                {
                    Data_lists.Add(
                        new(Name.Trim(), Type.Trim(), Category.Trim(), Quantity.Trim(), Cost.Trim())
                        );

                    clear_items();
                }                
                
            }
        }

        private void populate_table()
        {
            Data_lists = new();
        }

        //search list for specific category
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
            Category = string.Empty;
            Quantity = string.Empty;
            Cost = string.Empty;
        }
    }
}
