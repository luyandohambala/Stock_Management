using Caliburn.Micro;
using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stock_Management.Assets.ViewModel
{
    internal partial class Home_Page_ViewModel : ObservableObject
    {
        public Command_Class change_view => new(change_content_view);//change current view depending on 

        public Command_Class show_notification_command => new(execute => show_notifications());

        public Command_Class clear_notifications_command => new(execute => clear_notifications());


        [ObservableProperty]
        private int total_stock_available;
        
        [ObservableProperty]
        private int total_sales_p_month;
        
        [ObservableProperty]
        private int pending_reports;

        [ObservableProperty]
        private Visibility notification_visibility;

        [ObservableProperty]
        private int number_of_users;

        public Home_Page_ViewModel()
        {
            Total_stock_available = stock_page_viewmodel.data_lists.Where(x => x.Category == "Product" && int.Parse(x.Quantity) > 0).Count();
            Total_sales_p_month = stock_page_viewmodel.sales_lists_.Where(x => DateTime.Parse(x.Date).Month.ToString() == DateTime.Now.Month.ToString()).Count();
            Pending_reports = stock_page_viewmodel.notification_list.Where(x => x.Read == false).Count();
            Number_of_users = Settings_Page_ViewModel.user_list.Count;

            Notification_visibility = Visibility.Collapsed;
        }

        private void change_content_view(object content)
        {
            
            if (content.ToString() == "stock")
            {
                MainWindow.Content_Page.change_color(content.ToString());

            }
            else if (content.ToString() == "stock_sales")
            {
                MainWindow.Content_Page.change_color("stock");
                MainWindow.Content_Page.stock_Page.change_color("sales");
            }
            else
            {
                MainWindow.Content_Page.change_color(content.ToString());
                MainWindow.Content_Page.settings_Page.change_color("user");
            }
        }

        private void show_notifications()
        {
            if (stock_page_viewmodel.notification_list.Count > 0)
            {
                if (Notification_visibility == Visibility.Collapsed)
                {
                    Notification_visibility = Visibility.Visible;

                }
                else if (Notification_visibility == Visibility.Visible)
                {
                    Notification_visibility = Visibility.Collapsed;
                }
            }
        }

        private void clear_notifications()
        {
            if (MessageBox.Show("Clear all?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
            {
                stock_page_viewmodel.notification_list = new();
            }
        }

    }
}
