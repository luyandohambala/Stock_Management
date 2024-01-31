using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using Stock_Management.Assets.Models;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using checkout_list = Stock_Management.Assets.Pages.checkout_list;

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

        [ObservableProperty]
        public static string amount_given = string.Empty;

        [ObservableProperty]
        private string currency_value;

        public Command_Class increase => new(increase_quantity);
        public Command_Class reduce => new(reduce_quantity);
        public Command_Class clear_all => new(execute => clear_items());

        public Command_Class purchase_items => new(execute => purchase_item(), canExecute => Checkout_Lists.Count > 0);


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

            Currency_value = Settings_Page_ViewModel.currency_;
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

            category_Button.Category_list = new(
                stock_page_viewmodel.data_lists.Where(x => x.Category == "Product").Select(x => x.Type)
                );

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

            items_button items_Button = new()
            {
                Items_list = new ObservableCollection<items_button>(
                stock_page_viewmodel.data_lists.Where(x => x.Category == "Product").Select(x => new items_button(x.Name, x.Cost, x.Type)))
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

        private void purchase_item()
        {
            foreach(var item in Checkout_Lists)
            {
                if (double.Parse(Amount_given) >= Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")))
                {
                    stock_page_viewmodel.sales_lists_.Add(new Sales_list_Class
                    (

                        DateTime.Now.ToString(),
                        item.Item_name,
                        $"{item.Quantity}",
                        item.Item_price,
                        $"{Settings_Page_ViewModel.currency_}{int.Parse(Amount_given) - Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}",
                        MainWindow.Current_user
                    ));

                    foreach (var item1 in stock_page_viewmodel.data_lists)
                    {
                        if (item1.Name == item.Item_name && item1.Cost == item.Item_price && int.Parse(item1.Quantity) == item.Quantity)
                        {
                            item1.Quantity = (item.Quantity - int.Parse(item1.Quantity)).ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Amount received is less than required purchase amount.");
                    break;
                }
            }
            Checkout_Lists.Clear();
            Total_price = 0;
            Amount_given = string.Empty;
        }

        private void increase_quantity(object content)
        {
            //alter total price and quantity
            Value = Checkout_Lists.First(x => x.Item_name == content.ToString());
            if (Value.Quantity <
                int.Parse(stock_page_viewmodel.data_lists.First(x => x.Name == Value.Item_name && x.Cost == Value.Item_price && x.Type == Value.Type).Quantity))
            {
                Total_price -= (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
                Value.Quantity += 1;
                Total_price += (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
            }
        }

        private void reduce_quantity(object content)
        {
            Value = Checkout_Lists.First(x => x.Item_name == content.ToString());
            
            if (Value.Quantity > 1)
            {
                //alter total price and quantity
                Total_price -= (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
                Value.Quantity -= 1;
                Total_price += (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);

            }
            else
            {
                //alter total price and quantity
                Total_price -= (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
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
                Checkout_Lists.Add(new(array_values[0].ToString(), array_values[1].ToString(), 1, array_values[2].ToString()));
                Value = Checkout_Lists.First(x => x.Item_name == array_values[0].ToString());
                Total_price += (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
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
                    Amount_given = string.Empty;
                }
            }
        }
    }
}
