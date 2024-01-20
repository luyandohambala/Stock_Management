using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{

    public partial class stock_page : Page
    {
        public Command_Class clear_txt2 => new(execute => TxtSearch.Clear());
        public stock_page()
        {
            InitializeComponent();
            DataContext = new stock_page_viewmodel();
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

    internal partial class Database_list : ObservableObject
    {
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

        //initialise properties
        public Database_list(string name, string type, string category, string quantity, string cost)
        {
            Name = name; Type = type; Category = category; Quantity = quantity; Cost = cost;
        }

        public Database_list()
        {
            
        }

    }


}
