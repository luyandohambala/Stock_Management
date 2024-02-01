using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using checkout_list = Stock_Management.Assets.Pages.checkout_list;

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

        [ObservableProperty]
        public static string amount_given_s = string.Empty;

        [ObservableProperty]
        private string currency_value1;

        public Command_Class increase1 => new(increase_quantity);
        public Command_Class reduce1 => new(reduce_quantity);
        public Command_Class clear_all1 => new(execute => clear_items());

        public Command_Class purchase_services => new(execute => purchase_service(), canExecute => Checkout_Lists1.Count > 0);


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
            Currency_value1 = Settings_Page_ViewModel.currency_;
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

            category_Button.Category_list = new(
                stock_page_viewmodel.data_lists.Where(x => x.Category == "Service").Select(x => x.Type).Distinct()
                );

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

            items_button items_Button = new()
            {
                Items_list = new (
                    stock_page_viewmodel.data_lists.Where(x => x.Category == "Service").Select(x => new items_button(x.Id, x.Name, x.Cost, x.Type)))
            };

            foreach (var item in items_Button.Items_list)
            {
                Items_list1.Add(new items_button(item.Button_id, item.Button_content, item.Button_price, item.Button_category));
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

        private void purchase_service()
        {
            if (!String.IsNullOrEmpty(Amount_given_s))
            {
                var count = 0;//keep track if item index
                foreach (var item in Checkout_Lists1)
                {
                    if (double.Parse(Amount_given_s) >= Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")))
                    {
                        stock_page_viewmodel.sales_lists_.Add(new Sales_list_Class
                        (

                            DateTime.Now.ToString(),
                            item.Item_name,
                            $"{item.Quantity}",
                            item.Item_price,
                            $"{Settings_Page_ViewModel.currency_}{int.Parse(Amount_given_s) - Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}",
                            MainWindow.Current_user
                        ));

                        foreach (var item1 in stock_page_viewmodel.data_lists)
                        {
                            if (item1.Id == item.Item_id)
                            {
                                item1.Quantity = (int.Parse(item1.Quantity) - item.Quantity).ToString();
                            }
                        }
                        if (count == Checkout_Lists1.LongCount() - 1)
                        {
                            clear_items();
                            MessageBox.Show("Purchase successfull.");
                            break;
                        }

                        count++;
                    }
                    else
                    {
                        MessageBox.Show("Amount received is less than required purchase amount.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in received amount field");
            }
        }

        private void increase_quantity(object content)
        {
            //alter total price and quantity
            Value1 = Checkout_Lists1.FirstOrDefault(x => x.Item_id == content.ToString());

            if (Value1.Quantity <
                int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value1.Item_id).Quantity))
            {
                Total_price1 -= Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / Value1.Quantity:N2}";

                Value1.Quantity += 1;
                
                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Value1.Quantity * Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                Total_price1 += Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
            }

        }

        private void reduce_quantity(object content)
        {
            Value1 = Checkout_Lists1.FirstOrDefault(x => x.Item_id == content.ToString());

            if (Value1.Quantity > 1)
            {
                //alter total price and quantity
                Total_price1 -= Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / Value1.Quantity:N2}";

                Value1.Quantity -= 1;

                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Value1.Quantity * Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                Total_price1 += Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));

            }
            else
            {
                //alter total price and quantity
                Total_price1 -= Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                Checkout_Lists1.Remove(Value1);
            }
        }

        private void add_to_cart(object content)
        {
            var array_values = (object[])content;
            if (Checkout_Lists1.Select(x => x.Item_name).Contains(array_values[3].ToString()))
            {
                //Alert user of already existsing item
                MessageBox.Show($"Item {array_values[3]} already added");
            }
            else
            {
                Checkout_Lists1.Add(new(array_values[3].ToString(), array_values[0].ToString(), array_values[1].ToString(), 1, array_values[2].ToString()));
                Value1 = Checkout_Lists1.First(x => x.Item_name == array_values[0].ToString());
                Total_price1 += (Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value1.Quantity);
            }
        }

        private void clear_items()
        {
            if (Checkout_Lists1.Count >= 1)
            {
                if (MessageBox.Show("Clear cart?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Checkout_Lists1.Clear();
                    Amount_given_s = "0";
                    Total_price1 = 0;
                }
            }
        }
    }
}
