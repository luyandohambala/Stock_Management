using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Xml.Linq;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Quotation_Page_ViewModel : ObservableObject
    {
        //assign clear input fields command
        public Command_Class clearall3 => new(execute => clear_items());


        //assign remove command 
        public Command_Class remove_record2 => new(execute => remove(), canExecute => Value3 != null);


        //assign print command
        public Command_Class print_quotation => new(execute => print_quote());

        //assign add command 
        public Command_Class add_record2 => new(execute => add_to_quotation_list(), canExecute => !validate_entry());


        //add tax command
        public Command_Class tax_command => new(execute => tax_method());


        /// <summary>
        /// view model properties section 
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Quotation_Lists> quotation_list = new();

        [ObservableProperty]
        private string serial_number = string.Empty;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string quantity2;

        [ObservableProperty]
        private string unit_price;
        
        [ObservableProperty]
        private string row_total_price;

        [ObservableProperty]
        private double quot_total_price = 0;
        
        [ObservableProperty]
        private bool use_tax;

        [ObservableProperty]
        private string quotation_number;

        [ObservableProperty]
        private string invoice_reference_number;

        [ObservableProperty]
        private string currency_value;

        [ObservableProperty]
        private string tax_value;

        [ObservableProperty]
        private Quotation_Lists value3;

        public Quotation_Page_ViewModel()
        {
            Use_tax = false;

            Currency_value = Settings_Page_ViewModel.currency_;
        }


        private void add_to_quotation_list()
        {
            
            ObservableCollection<string> to_compare = new();

            var formatted_unit_price = Unit_price.Replace(",", ""); //used for calculation in code below.
            formatted_unit_price = formatted_unit_price.Replace(" ", ""); //used for calculation in code below.

            foreach (var item in Quotation_list)
            {
                to_compare.Add($"{item.Description.ToLower()}, {item.Quantity2.ToLower()}, " +
                    $"{item.Unit_price.ToLower()}, {item.Row_total_price.ToLower()}");
            }

            if (!to_compare.Contains($"{Description.ToLower()}, {Quantity2.ToLower()}, " +
                    $"{Unit_price.ToLower()}, {int.Parse(Quantity2) * double.Parse(formatted_unit_price):N2}"))
            {
                Quotation_list.Add(
                    new(Serial_number.Trim(), Description.Trim(), Quantity2.Trim(), $"{double.Parse(formatted_unit_price):N2}", $"{int.Parse(Quantity2.Trim()) * double.Parse(formatted_unit_price):N2}")
                    );

                Quot_total_price += (int.Parse(Quantity2) * double.Parse(formatted_unit_price));

                clear_items();
            }
        }

        private void print_quote()
        {
            if (Quotation_list.Count != 0 && Quotation_number != string.Empty)
            {
                //Use_tax = false;
                //empty_table();
            }
            else
            {
                MessageBox.Show("To print or save, Quote No. must not be empty and Quote items must be more than 1.");
            }
        }

        //add tax method
        private void tax_method()
        {
            if (Use_tax)
            {
                Tax_value = $"VAT: {(Convert.ToDouble(Settings_Page_ViewModel.value_added_tax) / 100) * Quot_total_price:N2}";
            }
            else
            {
                Tax_value = string.Empty;
            }
        }

        private void empty_table()
        {
            Quotation_list = new();
        }

        private void remove()
        {
            if (MessageBox.Show("Remove Record?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Quot_total_price -= (int.Parse(Value3.Quantity2) * double.Parse(Value3.Unit_price.Replace(",", "")));
                Quotation_list.Remove(Value3);
            }
        }

        private bool validate_entry()
        {
            if (String.IsNullOrEmpty(Description) || String.IsNullOrEmpty(Quantity2) || String.IsNullOrEmpty(Unit_price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void clear_items()
        {
            Serial_number = string.Empty;
            Description = string.Empty;
            Quantity2 = string.Empty;
            Unit_price = string.Empty;
        }

    }
}
