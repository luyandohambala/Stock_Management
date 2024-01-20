using Stock_Management.Assets.ViewModel;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{
    
    public partial class Services_Page : Page
    {
        public Command_Class clear_txt => new(execute => TxtSearch.Clear());

        public Services_Page()
        {
            InitializeComponent();
            DataContext = new Services_Page_ViewModel();

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
}
