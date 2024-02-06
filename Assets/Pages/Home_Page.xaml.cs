using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.CodeDom;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{
    /// <summary>
    /// Interaction logic for Home_Page.xaml
    /// </summary>
    public partial class Home_Page : Page
    {
        public Home_Page()
        {
            InitializeComponent();

            DataContext = new Home_Page_ViewModel();
        }


    }

    
}
