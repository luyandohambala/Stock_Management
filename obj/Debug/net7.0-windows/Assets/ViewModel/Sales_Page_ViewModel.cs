using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Sales_Page_ViewModel : ObservableObject
    {
        /// <summary>
        /// list view commands and properties
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<checkout_list> checkout_Lists;

        [ObservableProperty]
        private double total_price = 0;

        public Command_Class increase => new(increase_quantity);
        public Command_Class reduce => new(reduce_quantity);
        public Command_Class clear_all => new(execute => clear_items());


        /// <summary>
        /// items panel commands and properties 
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<items_button> items_list;

        public Command_Class search_for => new(search_items);

        public Command_Class add => new(add_to_cart);



        /// <summary>
        /// category panel commands and properties
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<category_button> category_list;

        public Command_Class search_categ => new(search_category);


        public Sales_Page_ViewModel()
        {
            populate();
        }

        private void populate()
        {
            populate_category();
            populate_items();
            populate_checkout();
        }


        /// <summary>
        /// category panel section below
        /// </summary>
        private void populate_category()
        {
            Category_list = new();
            category_button category_Button = new();
            
            category_Button.Category_list = new()
            {
                "Cables",
                "Keyboards",
                "Mouse"
            };

            //item below added to clear all search filters.
            Category_list.Add(new("All", "All"));
            foreach (var item in category_Button.Category_list)
            {
                Category_list.Add(new(item, item));
            }

            
        }
        private void search_category(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()) && content.ToString().Trim() == "All")
            {
                populate_items();
            }
            else if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_items();
                Items_list = new(Items_list.Where(x => x.Button_category.ToLower().Trim() == content.ToString().ToLower().Trim()));
            }
            else
            {
                populate_items();
            }
        }



        /// <summary>
        /// items section below
        /// </summary>
        private void populate_items()
        {
            Items_list = new ObservableCollection<items_button>();

            items_button items_Button = new items_button();

            items_Button.Items_list = new ObservableCollection<items_button>()
            {
                new ("item1", "10.00", "Cables"),
                new ("item2", "14.00", "Keyboards"),
                new ("item3", "15.00", "Keyboards"),
                new ("item4", "20.00", "Mouse")
            };
            
            foreach (var item in items_Button.Items_list)
            {
                Items_list.Add(new items_button(item.Button_content, item.Button_price, item.Button_category));
            }

        }

        //search list for specific category
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_items();
                Items_list = new(Items_list.Where(x => x.Button_content.ToLower().Trim().Contains(content.ToString().ToLower().Trim())));
            }
            else
            {
                populate_items();
            }
        }



        /// <summary>
        /// checkout section below
        /// </summary>
        private void populate_checkout()
        {
            //instantiate checkout_list with blank object
            Checkout_Lists = new ObservableCollection<checkout_list>();
        }


        private checkout_list value;
        public checkout_list Value { get { return value; } set { this.value = value; OnPropertyChanged(); }  }

        private void increase_quantity(object content)
        {
            //alter total price and quantity
            Value = Checkout_Lists.First(x => x.Item_name == content.ToString());
            Total_price -= (Value.Item_price * Value.Quantity);
            Value.Quantity += 1;
            Total_price += (Value.Item_price * Value.Quantity);

        }

        private void reduce_quantity(object content)
        {
            Value = Checkout_Lists.First(x => x.Item_name == content.ToString());
            
            if (Value.Quantity > 1)
            {
                //alter total price and quantity
                Total_price -= (Value.Item_price * Value.Quantity);
                Value.Quantity -= 1;
                Total_price += (Value.Item_price * Value.Quantity);

            }
            else
            {
                //alter total price and quantity
                Total_price -= (Value.Item_price * Value.Quantity);
                Checkout_Lists.Remove(Value);
            }
        }

        private void add_to_cart(object content)
        {
            var array_values = (object[]) content;
            if (Checkout_Lists.Select(x => x.Item_name).Contains(array_values[0].ToString()))
            {
                //Alert user of already existsing item
                MessageBox.Show($"Item {array_values[0]} already added");
            }
            else
            {
                Checkout_Lists.Add(new(array_values[0].ToString(), Convert.ToDouble(array_values[1]), 1));
                Value = Checkout_Lists.First(x => x.Item_name == array_values[0].ToString());
                Total_price += (Value.Item_price * Value.Quantity);
            }
        }

        private void clear_items()
        {
            if (Checkout_Lists.Count >= 1)
            {
                if (MessageBox.Show("Clear cart?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Checkout_Lists.Clear();
                    Total_price = 0;
                }
            }
        }
    }
}
