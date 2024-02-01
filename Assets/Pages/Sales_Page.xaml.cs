using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;

namespace Stock_Management.Assets.Pages
{

    public partial class Sales_Page : Page
    {
        public Command_Class clear_txt => new(execute => TxtSearch.Clear());
        public Sales_Page()
        {
            InitializeComponent();

            DataContext = new Sales_Page_ViewModel();
            clear_button.DataContext = this;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //gets button content
            var btn = sender as Button;

            change_nav(null, btn);

            //finally execute command
            btn.Command.Execute(btn.CommandParameter);
        }


        private void change_nav(string? button_content, Button? button_)
        {
            //create gradient color
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1)
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (button_content is null)
            {
                for (int i = 0; i < cat_grid.Items.Count; i++)
                {
                    //checks content of other butttons in itemscontrol
                    var c = (ContentPresenter)cat_grid.ItemContainerGenerator.ContainerFromItem(cat_grid.Items[i]);
                    Button button = c.ContentTemplate.FindName("cat_grid_button", c) as Button;

                    if (button.Content != button_.Content)
                    {
                        button.ClearValue(ForegroundProperty);
                        button.ClearValue(BackgroundProperty);
                    }
                    else
                    {
                        button.Background = linearGradientBrush;
                        button.Foreground = new SolidColorBrush(Colors.White);
                    }

                }
            }
        }

        private void purchase_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            purchase_txtbox.Text = Quotation_Page.validate_positive_integer(purchase_txtbox.Text, "Decimal");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(purchase_txtbox.Text) && String.IsNullOrEmpty(total_amount_txtblock.Text))
            {
                if (double.Parse(purchase_txtbox.Text) >= double.Parse(total_amount_txtblock.Text))
                {
                    purchase_txtbox.Clear();
                }
            }
        }
    }

    //checkout_list class
    internal partial class checkout_list : ObservableObject
    {
        [ObservableProperty]
        string item_id;

        [ObservableProperty]
        string item_name;

        [ObservableProperty]
        string item_price;

        [ObservableProperty]
        int quantity;

        [ObservableProperty]
        string type;


        public checkout_list(string item_id, string item_name, string item_price, int quantity, string type)
        {
            Item_id = item_id;
            Item_name = item_name;
            Item_price = item_price;
            Quantity = quantity;
            Type = type;
        }

    }


    //items_panel list utilises class below
    internal partial class items_button : ObservableObject
    {
        [ObservableProperty]
        string button_id;

        [ObservableProperty]
        string? button_content;

        [ObservableProperty]
        string? button_price;

        [ObservableProperty]
        string? button_category;

        [ObservableProperty]
        ObservableCollection<items_button> items_list;

        public items_button(string button_id, string button_content, string button_price, string button_category)
        {
            Button_id = button_id;
            Button_content = button_content;
            Button_price = button_price;
            Button_category = button_category;

        }
        public items_button()
        {

        }

    }


    //category_panel list utilises class below
    internal partial class category_button : ObservableObject
    {

        [ObservableProperty]
        string? button_content;

        [ObservableProperty]
        public ObservableCollection<string> category_list;

        public category_button(string button_name, string button_content)
        {
            Button_content = button_content;
        }

        public category_button()
        {

        }

    }
}
