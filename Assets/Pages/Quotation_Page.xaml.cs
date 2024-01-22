using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Text.RegularExpressions;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{
    public partial class Quotation_Page : Page
    {
        public Command_Class clear_txt3 => new(execute => TxtSearch.Clear());

        public Quotation_Page()
        {
            InitializeComponent();

            DataContext = new Quotation_Page_ViewModel();
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
