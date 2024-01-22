using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
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
        public Command_Class print_quotation => new(execute => print_quote(), canExecute => Quotation_list.Count != 0 && Quotation_number == string.Empty);

        //assign add command 
        public Command_Class add_record2 => new(execute => add_to_database(), canExecute => !validate_entry());


        //assign search command 
        public Command_Class search_for3 => new(search_items);


        /// <summary>
        /// view model properties section 
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Quotation_Lists> quotation_list = new();

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

        [ObservableProperty]
        private double quot_total_price = 0;
        
        [ObservableProperty]
        private bool use_tax;

        [ObservableProperty]
        private string quotation_number;

        [ObservableProperty]
        private Quotation_Lists value3;


        public Quotation_Page_ViewModel()
        {
            populate_table();
            Use_tax = false;
        }


        private void add_to_database()
        {
            
            ObservableCollection<string> to_compare = new();

            foreach (var item in Quotation_list)
            {
                to_compare.Add($"{item.Serial_number.ToLower()}, {item.Description.ToLower()}, {item.Quantity2.ToLower()}, " +
                    $"{item.Unit_price.ToLower()}, {item.Row_total_price.ToLower()}");
            }

            if (!to_compare.Contains($"{Serial_number.ToLower()}, {Description.ToLower()}, {Quantity2.ToLower()}, " +
                    $"{Unit_price.ToLower()}, {int.Parse(Quantity2) * double.Parse(Unit_price)}"))
            {
                Quotation_list.Add(
                    new(Serial_number.Trim(), Description.Trim(), Quantity2.Trim(), Unit_price.Trim(), $"{int.Parse(Quantity2.Trim()) * double.Parse(Unit_price.Trim())}")
                    );

                Value3 = Quotation_list.First(x => x.Serial_number ==  Serial_number);
                Quot_total_price += (int.Parse(Value3.Quantity2) * double.Parse(Value3.Unit_price));

                clear_items();
            }
        }

        private void print_quote()
        {
            if (Quotation_number == string.Empty)
            {
                Use_tax = false;
            }
        }

        private void populate_table()
        {
            Quotation_list = new();
        }

        //search list for specific quotation
        private void search_items(object content)
        {
            if (!String.IsNullOrEmpty(content.ToString()))
            {
                populate_table();
                /*Quotation_list = new(Quotation_list.Where(
                filtered => filtered.Name.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Type.ToLower().Contains(content.ToString().ToLower().Trim()) ||
                filtered.Category.Contains(content.ToString().ToLower().Trim()) ||
                filtered.Quantity.Contains(content.ToString().ToLower().Trim())));*/
            }
            else
            {
                populate_table();
            }
        }

        private void remove()
        {
            if (MessageBox.Show("Remove Record?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Quot_total_price -= (int.Parse(Value3.Quantity2) * double.Parse(Value3.Unit_price));
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
