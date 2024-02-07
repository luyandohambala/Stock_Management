using Stock_Management.Assets.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stock_Management.Assets
{
    /// <summary>
    /// Interaction logic for Print_View.xaml
    /// </summary>
    public partial class Print_View : Window
    {
        public Print_View()
        {
            InitializeComponent();

            DataContext = Settings_Page.Settings_Page_ViewModel;
        }

        //make window draggable
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //close window after saving printer name
            Close();
        }
    }
}
