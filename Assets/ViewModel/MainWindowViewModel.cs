using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public static string? current_user;

        public static Content_Page Content_Page { get; set; }
        public static Login_Page Login_Page { get; set; }

        [ObservableProperty]
        private static object current_View;

        public MainWindowViewModel()
        {
            Content_Page = new Content_Page();            
            Login_Page = new Login_Page();

            Change_View(false);
        }

        public void Assign_Current_User(string username)
        {
            Current_user = username;
        }

        public void Change_View(bool login)
        {
            if (login == true)
            {
                Current_View = Content_Page;
            }
            else
            {
                Current_View = Login_Page;
            }
        }
    }
}
