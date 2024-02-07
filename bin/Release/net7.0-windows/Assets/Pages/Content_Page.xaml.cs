using Stock_Management.Assets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stock_Management.Assets.Pages
{
    /// <summary>
    /// Interaction logic for Content_Page.xaml
    /// </summary>
    public partial class Content_Page : Page
    {
        public Command_Class close_app => new(execute => close_application());

        public stock_page stock_Page { get; set; }
        public Settings_Page settings_Page { get; set; }

        public Content_Page()
        {
            InitializeComponent();
            change_color("settings");//initialise settings for use throughout the application.
            change_color("home");
            DataContext = this;
            
        }

        public void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.3));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.8));

            if (nav == "home")
            {
                home_button.Foreground = linearGradientBrush;
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);

                Display_Frame.Content = new Home_Page();
            }

            else if (nav == "sales")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.Foreground = linearGradientBrush;
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Sales_Page();
            }

            else if (nav == "services")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.Foreground = linearGradientBrush;
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Services_Page();
            }

            else if (nav == "stock")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.Foreground = linearGradientBrush;
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);

                stock_Page = new();
                Display_Frame.Content = stock_Page;
            }

            else if (nav == "quote")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.Foreground = linearGradientBrush;
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Quotation_Page();
            }

            else if (nav == "settings")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.Foreground = linearGradientBrush;
                
                settings_Page = new();
                Display_Frame.Content = settings_Page;
            }
        }

        private void home_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("home");
        }

        private void sales_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("sales");
        }

        private void services_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("services");
        }

        private void Stock_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("stock");
        }

        private void quotation_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("quote");
        }

        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("settings");
        }

        private void close_application()
        {
            if (MessageBox.Show("Proceed to exit?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
