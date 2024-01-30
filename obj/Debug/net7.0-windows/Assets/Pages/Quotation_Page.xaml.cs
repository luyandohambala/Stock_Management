using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Stock_Management.Assets.Pages
{
    public partial class Quotation_Page : Page
    {
        public Command_Class quote_command => new(execute => change_color("quote"));
        public Command_Class invoice_command => new(execute => change_color("invoice"));
        public Quotation_Page()
        {
            InitializeComponent();

            DataContext = new Quotation_Page_ViewModel();

            Quote.DataContext = this;
            Invoice.DataContext = this;

            change_color("quote");
        }

        /*private void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (nav == "create")
            {
                create_view.Foreground = new SolidColorBrush(Colors.White);
                create_view.Background = linearGradientBrush;
                history_view.ClearValue(ForegroundProperty);
                history_view.ClearValue(BackgroundProperty);
                Search_Grid.Visibility = Visibility.Hidden;
            }

            else if (nav == "history")
            {
                history_view.Foreground = new SolidColorBrush(Colors.White);
                history_view.Background = linearGradientBrush;
                create_view.ClearValue(ForegroundProperty);
                create_view.ClearValue(BackgroundProperty);
                Search_Grid.Visibility = Visibility.Visible;

            }

        }*/

        private string? validate_positive_integer(string source, string to_match)
        {
            if (to_match == "Decimal")
            {
                string newNumber = string.Empty;
                Match regex = Regex.Match(source, @"(?<Number>^[0-9]*\.?[0-9]*)");
                while (regex.Success) { newNumber += regex.Groups["Number"].Value; regex = regex.NextMatch(); }
                return newNumber;
            }
            else if(to_match == "integer")
            {
                string newNumber = string.Empty;
                Match regex = Regex.Match(source, "(?<Number>[0-9])");
                while (regex.Success) { newNumber += regex.Groups["Number"].Value; regex = regex.NextMatch(); }
                return newNumber;
            }
            return null;
        }

        private void quantity_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            quantity_entry.Text = validate_positive_integer(quantity_entry.Text, "integer");
        }

        private void unit_price_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            unit_price_entry.Text = validate_positive_integer(unit_price_entry.Text, "Decimal");
        }

        private void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (nav == "quote")
            {
                Quote.Foreground = new SolidColorBrush(Colors.White);
                Quote.Background = linearGradientBrush;
                Invoice.ClearValue(ForegroundProperty);
                Invoice.ClearValue(BackgroundProperty);
                quote_view.Visibility = Visibility.Hidden;
                quote_invoice_no.Text = "Quote No.";

            }

            else if (nav == "invoice")
            {
                Invoice.Foreground = new SolidColorBrush(Colors.White);
                Invoice.Background = linearGradientBrush;
                Quote.ClearValue(ForegroundProperty);
                Quote.ClearValue(BackgroundProperty);
                quote_view.Visibility = Visibility.Visible;
                quote_invoice_no.Text = "Invoice No.";

            }

        }
    }

    internal partial class Quotation_Lists : ObservableObject
    {
        [ObservableProperty]
        private string serial_number;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string quantity2;

        [ObservableProperty]
        private string unit_price;

        [ObservableProperty]
        private string row_total_price;

        public Quotation_Lists(string serial_number, string description, string quantity, string unit_price, string row_total_price)
        {
            Serial_number = serial_number; Description = description; Quantity2 = quantity; Unit_price = unit_price; Row_total_price = row_total_price;
        }

        public Quotation_Lists()
        {
            
        }
    }
}
