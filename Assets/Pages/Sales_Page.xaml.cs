using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{

    public partial class Sales_Page : Page
    {

        public Sales_Page()
        {
            InitializeComponent();

            DataContext = new Sales_Page_ViewModel();

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
        
        [ObservableProperty]
        ObservableCollection<items_button> price_list;

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
    public class category_button
    {
        string? button_name { get; set; }
        public string? button_content { get; set; }

        public ObservableCollection<category_button> category_list { get; set; }

        public category_button(string button_name, string button_content)
        {
            this.button_name = button_name;
            this.button_content = button_content;
            category_list = new ObservableCollection<category_button>();
        }

        public category_button()
        {
            category_list = new ObservableCollection<category_button>();
        }

    }

}
