using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;

namespace Stock_Management.Assets.Pages
{

    public partial class stock_page : Page
    {
        public Command_Class clear_txt2 => new(execute => TxtSearch.Clear());

        internal static stock_page_viewmodel stock_Page_Viewmodel { get; set; }
        public stock_page()
        {
            InitializeComponent();
            stock_Page_Viewmodel = new();
            DataContext = stock_Page_Viewmodel;
            change_color("stock");
        }
        private string View { get; set; }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (View == "stock")
            {
                TxtSearch_button.Command = stock_Page_Viewmodel.search_for2;
                //invoke search logo command through txtbox txtchanged event
                if (!String.IsNullOrEmpty(TxtSearch.Text))
                {
                    TxtSearch_button.IsEnabled = true;
                    clear_button.Content = "\uf00d";
                    ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();

                }
                else
                {
                    ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();
                    clear_button.Content = "\uf002";
                    TxtSearch_button.IsEnabled = false;
                }
            }
            else if (View == "sales")
            {
                TxtSearch_button.Command = stock_Page_Viewmodel.search_for_2;
                //invoke search logo command through txtbox txtchanged event
                if (!String.IsNullOrEmpty(TxtSearch.Text))
                {

                    TxtSearch_button.IsEnabled = true;
                    clear_button.Content = "\uf00d";
                    ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();

                }
                else
                {

                    ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();
                    clear_button.Content = "\uf002";
                    TxtSearch_button.IsEnabled = false;
                }
            }
        }

        private void add_edit_button_Click(object sender, RoutedEventArgs e)
        {
            //traverse through records to check for duplicate records and notify the user of any duplicated then execute add command.
            for (int i = 0; i < items_grid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)items_grid.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cell1 = items_grid.Columns[0].GetCellContent(row) as TextBlock;
                TextBlock cell2 = items_grid.Columns[1].GetCellContent(row) as TextBlock;
                TextBlock cell3 = items_grid.Columns[2].GetCellContent(row) as TextBlock;
                TextBlock cell5 = items_grid.Columns[4].GetCellContent(row) as TextBlock;

                string comparison = $"{cell1.Text},{cell2.Text},{cell3.Text},{cell5.Text}";

                string compared_to = $"{Name_txtbox.Text.Trim()},{Type_txtbox.Text.Trim()},{Category_txtbox.Text.Trim()}," +
                    $"{Settings_Page_ViewModel.currency_}{double.Parse(Cost_txtbox.Text.Trim()):N2}";

                if (comparison.ToLower() == compared_to.ToLower())
                {
                    items_grid.SelectedItem = items_grid.Items[i];
                    items_grid.ScrollIntoView(items_grid.SelectedItem);
                    row.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                    MessageBox.Show("A record with details inputed already exists, information highlighted in the table.");
                    break;
                }
            }
        }

        private void Cost_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Cost_txtbox.Text = Quotation_Page.validate_positive_integer(Cost_txtbox.Text, "Decimal");
        }

        private void Quantity_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Quantity_txtbox.Text = Quotation_Page.validate_positive_integer(Quantity_txtbox.Text, "integer");
        }

        private void purchase_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            purchase_txtbox.Text = Quotation_Page.validate_positive_integer(purchase_txtbox.Text, "Decimal");
        }

        public void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (nav == "stock")
            {
                stock_records.Foreground = new SolidColorBrush(Colors.White);
                stock_records.Background = linearGradientBrush;
                sales_records.ClearValue(ForegroundProperty);
                sales_records.ClearValue(BackgroundProperty);
                items_grid_border.Visibility = Visibility.Visible;
                sales_grid_border.Visibility = Visibility.Collapsed;
                checkout_panel_hider.Visibility = Visibility.Collapsed;
                View = "stock";

            }

            else if (nav == "sales")
            {
                sales_records.Foreground = new SolidColorBrush(Colors.White);
                sales_records.Background = linearGradientBrush;
                stock_records.ClearValue(ForegroundProperty);
                stock_records.ClearValue(BackgroundProperty);
                items_grid_border.Visibility = Visibility.Collapsed;
                sales_grid_border.Visibility = Visibility.Visible;
                checkout_panel_hider.Visibility = Visibility.Visible;
                View = "sales";
            }
        }

        private void stock_records_Click(object sender, RoutedEventArgs e)
        {
            change_color("stock");
        }

        private void sales_records_Click(object sender, RoutedEventArgs e)
        {
            change_color("sales");
        }

        private void Category_txtbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category_txtbox.SelectedIndex == 0)
            {
                Quantity_text.Visibility = Visibility.Visible;
                Quantity_txtbox.Visibility = Visibility.Visible;

            }
            else if (Category_txtbox.SelectedIndex == 1)
            {
                Quantity_text.Visibility = Visibility.Collapsed;
                Quantity_txtbox.Visibility = Visibility.Collapsed;
            }
        }
    }

    internal partial class Database_list : ObservableObject
    {
        [ObservableProperty]
        private string id;

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

        [ObservableProperty]
        private string profit;

        //initialise properties
        public Database_list(string id, string name, string type, string category, string quantity, string cost, string profit)
        {
            Id = id; Name = name; Type = type; Category = category; Quantity = quantity; Cost = cost; Profit = profit;
        }

        public Database_list(string id, string quantity)
        {
            Id = id; Quantity = quantity;
        }

        public Database_list()
        {

        }

    }

    internal partial class Sales_list_Class : ObservableObject
    {
        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private string item_name;

        [ObservableProperty]
        private string item_quantity;

        [ObservableProperty]
        private string amount;

        [ObservableProperty]
        private string change;

        [ObservableProperty]
        private string profit;

        [ObservableProperty]
        private string cashier;

        //initialise properties
        public Sales_list_Class(string date, string item_name, string item_quantity, string amount, string change, string profit, string cashier)
        {
            Date = date; Item_name = item_name; Item_quantity = item_quantity; Amount = amount; Change = change; Profit = profit; Cashier = cashier;
        }

        public Sales_list_Class()
        {

        }
    }

    internal partial class Notification_List_Class : ObservableObject
    {
        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private string information;

        [ObservableProperty]
        private bool read;

        public Notification_List_Class(string date, string information, bool read)
        {
            Date = date; Information = information; Read = read;
        }

        public Notification_List_Class(string date, bool read)
        {
            Date = date; Read = read;
        }
        public Notification_List_Class()
        {
            
        }
    }

}
