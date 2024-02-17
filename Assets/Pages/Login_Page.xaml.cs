using Stock_Management.Assets.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{
    public partial class Login_Page : Page
    {
        private Login_Page_ViewModel Login_Page_View { get; set; }

        public Login_Page()
        {
            InitializeComponent();
            Login_Page_View = new();
            DataContext = Login_Page_View;
        }

        private void Cancel_Reset_Password_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel Reset?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Login_Grid.Visibility = Visibility.Visible;
                Reset_Password_Grid.Visibility = Visibility.Collapsed;
                Login_Page_View.Clear_Reset();
            }
        }

        private void Cancel_SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel SignUp?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Login_Grid.Visibility = Visibility.Visible;
                SignUp_Grid.Visibility = Visibility.Collapsed;
                Login_Page_View.Clear_Sign_up();
            }
        }

        private void Forgot_Password_Command_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login_Grid.Visibility = Visibility.Collapsed;
            Reset_Password_Grid.Visibility = Visibility.Visible;
            Login_Page_View.Clear_Fields();
        }

        private void SignUp_Command_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login_Grid.Visibility = Visibility.Collapsed;
            SignUp_Grid.Visibility = Visibility.Visible;
            Login_Page_View.Clear_Fields();
        }

        private void Passtxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Passtxt.Password))
            {
                Passtxtblock.Visibility = Visibility.Collapsed;
                Login_Page_View.Login_password = Passtxt.Password;
            }
            else
            {
                Passtxtblock.Visibility = Visibility.Visible;
                
            }
        }

        private void S_Passtxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(S_Passtxt.Password))
            {
                S_Passtxtblock.Visibility = Visibility.Collapsed;
                Login_Page_View.Login_password = S_Passtxt.Password;
            }
            else
            {
                S_Passtxtblock.Visibility = Visibility.Visible;

            }
        }

        private void Passtxtblock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Passtxt.Focus();
        }

        private void S_Passtxtblock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            S_Passtxt.Focus();
        }
    }
}
