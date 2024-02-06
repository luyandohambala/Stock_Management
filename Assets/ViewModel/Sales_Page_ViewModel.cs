using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Windows;
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

        [ObservableProperty]
        private bool read_only_quantity;//used to set the read only fied of the quantity textbox under the checkout list view

        [ObservableProperty]
        private string multiple_price_value = string.Empty;//used to store the value of the quantity before the manual increase

        [ObservableProperty]
        private string multiple_quantity_value = string.Empty;//used to store the value of the price before the manual increase

        public Command_Class increase => new(increase_quantity);

        public Command_Class increase_multiple => new(increase_quantity_multpile);

        public Command_Class reduce => new(reduce_quantity);
        public Command_Class clear_all => new(execute => clear_items("clear"));

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
            Read_only_quantity = true;
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
                stock_page_viewmodel.data_lists.Where(x => x.Category == "Product").Select(x => x.Type).Distinct()
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
                Items_list = new(
                    stock_page_viewmodel.data_lists.Where(x => x.Category == "Product" && int.Parse(x.Quantity) > 0).
                    Select(x => new items_button(x.Id, x.Name, x.Profit, x.Cost, x.Type)))
            };

            foreach (var item in items_Button.Items_list)
            {
                Items_list.Add(new items_button(item.Button_id, item.Button_content, item.Button_profit, item.Button_price, item.Button_category));
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
            var count = 0;//keep track of item index
            if (!String.IsNullOrEmpty(Amount_given))
            {
                foreach (var item in Checkout_Lists)
                {
                    if (double.Parse(Amount_given) >= Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")))
                    {
                        stock_page_viewmodel.sales_lists_.Add(new Sales_list_Class
                        (

                            DateTime.Now.ToString(),
                            item.Item_name,
                            $"{item.Quantity}",
                            item.Item_price,
                            $"{Settings_Page_ViewModel.currency_}{double.Parse(Amount_given) - Convert.ToDouble(item.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}",
                            $"{Settings_Page_ViewModel.currency_}" +
                            $"{Convert.ToDouble(item.Item_profit.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * item.Quantity:N2}",
                            MainWindow.Current_user
                        ));

                        foreach (var item1 in stock_page_viewmodel.data_lists)
                        {
                            if (item1.Id == item.Item_id)
                            {
                                item1.Quantity = (int.Parse(item1.Quantity) - item.Quantity).ToString();
                                if (int.Parse(item1.Quantity) <= 5)
                                {
                                    stock_page_viewmodel.notification_list.Add(
                                            new(DateTime.Now.ToString(), $"Item {item1.Name} has a quantity value of less than 5. Please restock.", false)
                                            );
                                }
                            }
                        }

                        if (count == Checkout_Lists.LongCount() - 1)
                        {
                            clear_items("purchase");
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
            Value = Checkout_Lists.FirstOrDefault(x => x.Item_id == content.ToString());

            if (Read_only_quantity)
            {
                if (Value.Quantity <
                    int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value.Item_id).Quantity))
                {
                    Total_price -= Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / Value.Quantity:N2}";

                    Value.Quantity += 1;

                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value.Quantity * Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                    Total_price += Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                }
            }
            else
            {
                if (Value.Quantity <
                    int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value.Item_id).Quantity))
                {
                    Total_price -= Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / int.Parse(Multiple_quantity_value):N2}";

                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value.Quantity * Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";

                    Total_price += Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));

                    Multiple_price_value = string.Empty;
                    Multiple_quantity_value = string.Empty;
                    Read_only_quantity = true;
                    MessageBox.Show("Manual quantity entry disabled.");
                }
                else
                {
                    Value.Quantity -= (Value.Quantity - int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value.Item_id).Quantity));
                    Total_price -= Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / int.Parse(Multiple_quantity_value):N2}";

                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value.Quantity * Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";

                    Total_price += Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                }
            }
        }

        private void increase_quantity_multpile(object content)
        {
            if (!Read_only_quantity)
            {
                Read_only_quantity = true;
                MessageBox.Show("Manual quantity entry disabled.");
            }
            else
            {
                //alter total price and quantity
                Value = Checkout_Lists.FirstOrDefault(x => x.Item_id == content.ToString());
                
                Multiple_price_value = Value.Item_price;
                Multiple_quantity_value = Value.Quantity.ToString();
                Read_only_quantity = false;

                MessageBox.Show("Manual quantity entry enabled.");
            }
            
        }

        private void reduce_quantity(object content)
        {
            //alter total price and quantity
            Value = Checkout_Lists.FirstOrDefault(x => x.Item_id == content.ToString());

            if (Read_only_quantity)
            {
                if (Value.Quantity > 1 && (Value.Quantity <
                    int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value.Item_id).Quantity)))
                {
                    //alter total price and quantity
                    Total_price -= Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / Value.Quantity:N2}";

                    Value.Quantity -= 1;

                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value.Quantity * Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                    Total_price += Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));

                }
                else if (Value.Quantity < 1)
                {
                    //alter total price and quantity
                    Total_price -= Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Checkout_Lists.Remove(Value);
                }
            }
            else
            {
                if (Value.Quantity > 1 && (Value.Quantity <
                    int.Parse(stock_page_viewmodel.data_lists.FirstOrDefault(x => x.Id == Value.Item_id).Quantity)))
                {
                    Total_price -= Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) / int.Parse(Multiple_quantity_value):N2}";

                    Value.Item_price = $"{Settings_Page_ViewModel.currency_}" +
                        $"{Value.Quantity * Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")):N2}";
                    Total_price += Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));


                    Multiple_price_value = string.Empty;
                    Multiple_quantity_value = string.Empty;
                    Read_only_quantity = true;
                    MessageBox.Show("Manual quantity entry disabled.");

                }
                else if (Value.Quantity < 1)
                {
                    //alter total price and quantity
                    Total_price -= Convert.ToDouble(Multiple_price_value.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, ""));
                    Multiple_price_value = string.Empty;
                    Multiple_quantity_value = string.Empty;
                    Read_only_quantity = true;
                    Checkout_Lists.Remove(Value);
                }
            }
        }

        private void add_to_cart(object content)
        {
            var array_values = (object[]) content;
            if (Checkout_Lists.Select(x => x.Item_id).Contains(array_values[4].ToString()))
            {
                //Alert user of already existsing item
                MessageBox.Show($"Item {array_values[0]} already added");
            }
            else
            {
                Checkout_Lists.Add(new(array_values[4].ToString(), 
                    array_values[0].ToString(),
                    array_values[1].ToString(),
                    array_values[2].ToString(), 
                    1, 
                    array_values[3].ToString()));
                Value = Checkout_Lists.First(x => x.Item_id == array_values[4].ToString());
                Total_price += (Convert.ToDouble(Value.Item_price.Replace(",", "").Replace(Settings_Page_ViewModel.currency_, "")) * Value.Quantity);
            }
        }

        private void clear_items(string state)
        {
            if (state == "clear")
            {
                if (Checkout_Lists.Count >= 1)
                {
                    if (MessageBox.Show("Clear cart?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Checkout_Lists.Clear();
                        Amount_given = string.Empty;
                        Total_price = 0;
                    }
                }
            }
            else if (state == "purchase")
            {
                Checkout_Lists.Clear();
                Amount_given = string.Empty;
                Total_price = 0;
            }
        }
    }
}
