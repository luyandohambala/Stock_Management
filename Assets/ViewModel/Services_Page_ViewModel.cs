using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
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

        [ObservableProperty]
        private bool read_only_quantity1;//used to set the read only fied of the quantity textbox under the checkout list view

        [ObservableProperty]
        private string multiple_price_value1 = string.Empty;//used to store the value of the quantity before the manual increase

        [ObservableProperty]
        private string multiple_quantity_value1 = string.Empty;//used to store the value of the price before the manual increase

        public Command_Class increase1 => new(increase_quantity);

        public Command_Class increase_multiple1 => new(increase_quantity_multpile);

        public Command_Class reduce1 => new(reduce_quantity);
        public Command_Class clear_all1 => new(execute => clear_items("clear"));

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
            Read_only_quantity1 = true;
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
                    stock_page_viewmodel.data_lists.Where(x => x.Category == "Service").Select(x => new items_button(x.Id, x.Name, x.Profit, x.Cost, x.Type)))
            };

            foreach (var item in items_Button.Items_list)
            {
                Items_list1.Add(new items_button(item.Button_id, item.Button_content, item.Button_profit, item.Button_price, item.Button_category));
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
                if (double.Parse(Amount_given_s) >= Total_price1)
                {
                    foreach (var item in Checkout_Lists1)
                    {
                        Sales_list_Class sales_list = new(

                            DateTime.Now.ToString(),
                            item.Item_name,
                            $"{item.Quantity}",
                            item.Item_price,
                            $"{Settings_Page_ViewModel.currency_}{double.Parse(Amount_given_s) - Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}",
                            $"{Settings_Page_ViewModel.currency_}" +
                            $"{Convert.ToDouble(item.Item_profit.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * item.Quantity:N2}",
                            MainWindowViewModel.current_user
                        );

                        Database_Connection_Class.Modify_Sales_Table(sales_list);

                        if (count == Checkout_Lists1.LongCount() - 1)
                        {
                            if (MessageBox.Show("Print receipt?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                Print_Files_Class.print_receipt(Checkout_Lists1, $"{Total_price1:N2}");
                            }

                            clear_items("purchase");
                            MessageBox.Show("Purchase successfull.");
                            stock_page_viewmodel.repopulate_fields();
                            Home_Page_ViewModel.notification_list = Database_Connection_Class.Load_Notifications();
                            Home_Page_ViewModel.pending_reports = Home_Page_ViewModel.notification_list.Where(x => x.Read == false).Count();
                            break;
                        }

                        count++;
                    }
                }
                else
                {
                    MessageBox.Show("Amount received is less than required purchase amount.");
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

            if (Read_only_quantity1)
            {
                Total_price1 -= Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / Value1.Quantity:N2}";

                Value1.Quantity += 1;

                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Value1.Quantity * Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                Total_price1 += Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
            }
            else
            {
                Total_price1 -= Convert.ToDouble(Multiple_price_value1.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Convert.ToDouble(Multiple_price_value1.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / int.Parse(Multiple_quantity_value1):N2}";

                Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                    $"{Value1.Quantity * Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";

                Total_price1 += Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));

                Multiple_price_value1 = string.Empty;
                Multiple_quantity_value1 = string.Empty;
                Read_only_quantity1 = true;
                MessageBox.Show("Manual quantity entry disabled.");
            }
        }

        private void increase_quantity_multpile(object content)
        {
            if (!Read_only_quantity1)
            {
                Read_only_quantity1 = true;
                MessageBox.Show("Manual quantity entry disabled.");
            }
            else
            {
                //alter total price and quantity
                Value1 = Checkout_Lists1.FirstOrDefault(x => x.Item_id == content.ToString());

                Multiple_price_value1 = Value1.Item_price;
                Multiple_quantity_value1 = Value1.Quantity.ToString();
                Read_only_quantity1 = false;

                MessageBox.Show("Manual quantity entry enabled.");
            }

        }

        private void reduce_quantity(object content)
        {
            if (Read_only_quantity1)
            {
                if (Value1.Quantity >= 1)
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
            else
            {
                //alter total price and quantity
                Value1 = Checkout_Lists1.FirstOrDefault(x => x.Item_id == content.ToString());
                if (Value1.Quantity >= 1)
                {
                    Total_price1 -= Convert.ToDouble(Multiple_price_value1.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Multiple_price_value1.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / int.Parse(Multiple_quantity_value1):N2}";

                    Value1.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value1.Quantity * Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                    Total_price1 += Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));


                    Multiple_price_value1 = string.Empty;
                    Multiple_quantity_value1 = string.Empty;
                    Read_only_quantity1 = true;
                    MessageBox.Show("Manual quantity entry disabled.");

                }
                else
                {
                    //alter total price and quantity
                    Total_price1 -= Convert.ToDouble(Multiple_price_value1.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Multiple_price_value1 = string.Empty;
                    Multiple_quantity_value1 = string.Empty;
                    Read_only_quantity1 = true;
                    Checkout_Lists1.Remove(Value1);
                }
            }
        }

        private void add_to_cart(object content)
        {
            var array_values = (object[])content;
            if (Checkout_Lists1.Select(x => x.Item_id).Contains(array_values[4].ToString()))
            {
                //Alert user of already existsing item
                MessageBox.Show($"Item {array_values[0]} already added");
            }
            else
            {
                Checkout_Lists1.Add(new(array_values[4].ToString(),
                    array_values[0].ToString(),
                    array_values[1].ToString(),
                    array_values[2].ToString(),
                    1,
                    array_values[3].ToString()));
                Value1 = Checkout_Lists1.First(x => x.Item_id == array_values[4].ToString());
                Total_price1 += (Convert.ToDouble(Value1.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value1.Quantity);
            }
        }

        private void clear_items(string state)
        {
            if (state == "clear")
            {
                if (Checkout_Lists1.Count >= 1)
                {
                    if (MessageBox.Show("Clear cart?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Checkout_Lists1.Clear();
                        Amount_given_s = string.Empty;
                        Total_price1 = 0;
                    }
                }
            }
            else if (state == "purchase")
            {
                Checkout_Lists1.Clear();
                Amount_given_s = string.Empty;
                Total_price1 = 0;
            }
        }
    }
}
