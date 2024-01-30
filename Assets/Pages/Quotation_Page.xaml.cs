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

        private void add_edit_button_Click(object sender, RoutedEventArgs e)
        {
            //traverse through records to check for duplicate records and notify the user of any duplicated then execute add command.
            for (int i = 0; i < items_grid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)items_grid.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cell2 = items_grid.Columns[1].GetCellContent(row) as TextBlock;
                TextBlock cell3 = items_grid.Columns[2].GetCellContent(row) as TextBlock;
                TextBlock cell4 = items_grid.Columns[3].GetCellContent(row) as TextBlock;

                if ((cell2 != null && cell3 != null && cell4 != null) &&
                    (cell2.Text.ToLower() == description_entry.Text.ToLower().Trim()
                    && cell3.Text.ToLower() == quantity_entry.Text.ToLower().Trim()
                    && cell4.Text.ToLower() == unit_price_entry.Text.ToLower().Trim()))
                {
                    items_grid.SelectedItem = items_grid.Items[i];
                    items_grid.ScrollIntoView(items_grid.SelectedItem);
                    row.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                    MessageBox.Show("A record with details inputed already exists, information highlighted in the table.");
                    break;
                }
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
