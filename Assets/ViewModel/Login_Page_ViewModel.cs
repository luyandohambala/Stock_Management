using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Login_Page_ViewModel : ObservableObject 
    {
        /// <summary>
        /// login in commands
        /// </summary>
        public Command_Class Login_Command => new(execute => Login_Method());
        public Command_Class Cancel_Command => new(execute => Cancel_Method());

        /// <summary>
        /// sign up section
        /// </summary>
        public Command_Class Sign_up_Command => new(execute => SignUp_Method());


        /// <summary>
        /// reset password commands
        /// </summary>
        public Command_Class Reset_Password_Command => new(execute => Reset_Method());


        [ObservableProperty]
        public static string login_firstname = string.Empty;
        
        [ObservableProperty]
        private string login_lastname = string.Empty;

        [ObservableProperty]
        private string login_username = string.Empty;
        
        [ObservableProperty]
        private static string login_email= string.Empty;

        [ObservableProperty]
        private string login_password = string.Empty;


        [ObservableProperty]
        private string reset_Timer = string.Empty;

        public Login_Page_ViewModel()
        {
            
        }


        //login in function 
        private void Login_Method()
        {
            if (validate_entry() && Database_Connection_Class.Verify_User(new settings_data(Login_username, Login_password)))
            {
                MainWindow.MainWindowViewModel.Assign_Current_User(Login_username);
                MainWindow.MainWindowViewModel.Change_View(true);
                Clear_Fields();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                Clear_Fields();
            }
        }


        //sign up function
        private void SignUp_Method()
        {
            if (validate_sign_up())
            {

            }
            else
            {
                MessageBox.Show("Fill in all the required details.");
            }
        }
        
        //sign up function
        private void Reset_Method()
        {

        }


        //cancel login function 
        private void Cancel_Method()
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
            {
                Application.Current.Shutdown();
            }
        }

        public void Clear_Fields()
        {
            Login_username = string.Empty;
            Login_password = string.Empty;
        }

        //clear sign up fields
        public void Clear_Sign_up()
        {
            Login_firstname = string.Empty;
            Login_lastname = string.Empty;
            Login_username = string.Empty;
            Login_email = string.Empty;
            Login_password = string.Empty;
        }

        //clear reset fields
        public void Clear_Reset()
        {
            Login_email = string.Empty;
        }

        private bool validate_entry()
        {
            if (string.IsNullOrEmpty(Login_username) || string.IsNullOrEmpty(Login_password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //validate sign up fields
        private bool validate_sign_up()
        {
            if (string.IsNullOrEmpty(Login_username) || string.IsNullOrEmpty(Login_password) || string.IsNullOrEmpty(Login_firstname) ||
                string.IsNullOrEmpty(Login_lastname) || string.IsNullOrEmpty(Login_email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
