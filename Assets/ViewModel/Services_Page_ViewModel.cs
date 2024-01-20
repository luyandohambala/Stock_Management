using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Windows;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Services_Page_ViewModel : ObservableObject
    {
        /// <summary>
        /// list view commands and properties
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<checkout_list> checkout_Lists1;

        [ObservableProperty]
        private double total_price1 = 0;

        public Command_Class increase1 => new(increase_quantity);
        public Command_Class reduce1 => new(reduce_quantity);
        public Command_Class clear_all1 => new(execute => clear_items());


        /// <summary>
        /// items panel commands and properties 
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<items_button> items_list1;

        public Command_Class search_for1 => new(search_items);

        public Command_Class add1 => new(add_to_cart);


        /// <summary>
        /// category panel commands and properties
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<category_button> category_list1;

        public Command_Class search_categ1 => new(search_category);

        public Services_Page_ViewModel()
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
            Category_list1 = new();
            category_button category_Button = new();

            category_Button.Category_list = new()
            {
                "Printing",
                "Laminating",
                "Binding"
            };

            //item below added to clear all search filters.
            Category_list1.Add(new("All", "All"));
            foreach (var item in category_Button.Category_list)
            {
                Category_list1.Add(new(item, item));
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
                Items_list1 = new(Items_list1.Where(x => x.Button_category.ToLower().Trim() == content.ToString().ToLower().Trim()));
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
            Items_list1 = new ObservableCollection<items_button>();

            items_button items_Button = new items_button();

            items_Button.Items_list = new ObservableCollection<items_button>()
            {
                new ("black & white printing", "4.00", "printing"),
                new ("color printing", "15.00", "printing"),
                new ("binding", "15.00", "binding"),
                new ("laminating", "10.00", "laminating")
            };

            foreach (var item in items_Button.Items_list)
            {
                Items_list1.Add(new items_button(item.Button_content, item.Button_price, item.Button_category));
            }

        }

        //search list for specific category
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_items();
                Items_list1 = new(Items_list1.Where(x => x.Button_content.ToLower().Trim().Contains(content.ToString().ToLower().Trim())));
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
            Checkout_Lists1 = new ObservableCollection<checkout_list>();
        }


        private checkout_list value1;
        public checkout_list Value1 { get { return value1; } set { this.value1 = value; OnPropertyChanged(); } }

        private void increase_quantity(object content)
        {
            //alter total price and quantity
            Value1 = Checkout_Lists1.First(x => x.Item_name == content.ToString());
            Total_price1 -= (Value1.Item_price * Value1.Quantity);
            Value1.Quantity += 1;
            Total_price1 += (Value1.Item_price * Value1.Quantity);

        }

        private void reduce_quantity(object content)
        {
            Value1 = Checkout_Lists1.First(x => x.Item_name == content.ToString());

            if (Value1.Quantity > 1)
            {
                //alter total price and quantity
                Total_price1 -= (Value1.Item_price * Value1.Quantity);
                Value1.Quantity -= 1;
                Total_price1 += (Value1.Item_price * Value1.Quantity);

            }
            else
            {
                //alter total price and quantity
                Total_price1 -= (Value1.Item_price * Value1.Quantity);
                Checkout_Lists1.Remove(Value1);
            }
        }

        private void add_to_cart(object content)
        {
            var array_values = (object[])content;
            if (Checkout_Lists1.Select(x => x.Item_name).Contains(array_values[0].ToString()))
            {
                //Alert user of already existsing item
                MessageBox.Show($"Item {array_values[0]} already added");
            }
            else
            {
                Checkout_Lists1.Add(new(array_values[0].ToString(), Convert.ToDouble(array_values[1]), 1));
                Value1 = Checkout_Lists1.First(x => x.Item_name == array_values[0].ToString());
                Total_price1 += (Value1.Item_price * Value1.Quantity);
            }
        }

        private void clear_items()
        {
            if (Checkout_Lists1.Count >= 1)
            {
                if (MessageBox.Show("Clear cart?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Checkout_Lists1.Clear();
                    Total_price1 = 0;
                }
            }
        }
    }
}
