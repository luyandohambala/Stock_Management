using System.Windows;
using System.Windows.Input;

namespace Stock_Management.Assets
{
    /// <summary>
    /// Interaction logic for Internet_Alert.xaml
    /// </summary>
    public partial class Internet_Alert : Window
    {
        public Internet_Alert()
        {
            InitializeComponent();
        }

        

        
        //close application when event is called by close button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //allow dragability of window.
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
