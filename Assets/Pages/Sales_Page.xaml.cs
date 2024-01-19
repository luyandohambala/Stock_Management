using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

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
    }

    //checkout_list class
    internal partial class checkout_list : ObservableObject
    {
        [ObservableProperty]
        string item_name;

        [ObservableProperty]
        double item_price;

        [ObservableProperty]
        int quantity;


        public checkout_list(string item_name, double item_price, int quantity)
        {
            Item_name = item_name;
            Item_price = item_price;
            Quantity = quantity;
        }

    }


    //items_panel list utilises class below
    internal partial class items_button : ObservableObject
    {
        [ObservableProperty]
        string? button_content;

        [ObservableProperty]
        string? button_price;

        [ObservableProperty]
        string? button_category;

        [ObservableProperty]
        ObservableCollection<items_button> items_list;

        public items_button(string button_content, string button_price, string button_category)
        {
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
