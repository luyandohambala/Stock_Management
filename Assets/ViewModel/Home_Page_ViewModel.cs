using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using System.Linq;


namespace Stock_Management.Assets.ViewModel
{
    internal partial class Home_Page_ViewModel : ObservableObject
    {
        public Command_Class change_view => new(change_content_view);//change current view depending on 

        public Command_Class show_notification_command => new(execute => show_notifications());

        public Command_Class mark_as_read_command => new(mark_as_read);

        public Command_Class delete_notification_command => new(delete_notification);

        public Command_Class clear_notifications_command => new(execute => clear_notifications());


        [ObservableProperty]
        private int total_stock_available;
        
        [ObservableProperty]
        private int total_sales_p_month;

        [ObservableProperty]
        public static int pending_reports = 0;

        [ObservableProperty]
        public static ObservableCollection<Notification_List_Class> notification_list = new();

        [ObservableProperty]
        private Visibility notification_visibility;

        [ObservableProperty]
        private int number_of_users;

        [ObservableProperty]
        private ISeries[] series;

        [ObservableProperty]
        private Axis[] xaxes;

        [ObservableProperty]
        private Axis[] yaxes;

        public Home_Page_ViewModel()
        {
            stock_page_viewmodel.repopulate_fields();

            Total_stock_available = stock_page_viewmodel.data_lists.Where(x => x.Category == "Product" && int.Parse(x.Quantity) > 0).Count();
            Total_sales_p_month = stock_page_viewmodel.sales_lists_.Where(x => DateTime.Parse(x.Date).Month.ToString() == DateTime.Now.Month.ToString()).Count();

            Notification_list = Database_Connection_Class.Load_Notifications();
            Pending_reports = Notification_list.Where(x => x.Read == false).Count();
            Number_of_users = Settings_Page_ViewModel.user_list.Count;

            Notification_visibility = Visibility.Collapsed;

            populate_graph();
        }

        private void populate_graph()
        {
            var digits = new List<int>();

            var sales = stock_page_viewmodel.sales_lists_.Where(x => DateTime.Parse(x.Date).Month.ToString() == DateTime.Now.Month.ToString());

            var group = sales.GroupBy(i => DateTime.Parse(i.Date).Day.ToString());

            foreach (var item in group)
            {
                digits.Add(item.Count());
            }

            Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = digits,
                    Fill = null,
                    Stroke = new SolidColorPaint(SKColors.DarkRed) {StrokeCap = SKStrokeCap.Round, StrokeThickness = 2},
                    GeometryFill = new SolidColorPaint(SKColors.IndianRed),
                    GeometryStroke = new SolidColorPaint(SKColors.IndianRed),
                    YToolTipLabelFormatter = (chartPoint) => $"Sales: {chartPoint.PrimaryValue}"
                }
            };

            ///
            //days of month section
            ///
            var days = new List<string>();

            foreach (var item1 in stock_page_viewmodel.sales_lists_.Where(x => DateTime.Parse(x.Date).Month.ToString() == DateTime.Now.Month.ToString()).
                    Select(x => DateTime.Parse(x.Date).Day.ToString()))
            {
                if (!days.Contains(item1))
                {
                    days.Add(item1);
                }
            }

            Xaxes = new Axis[]
            {
                new() {
                    Name = $"Month of {DateTime.Now:MMMM}",
                    NamePaint = new SolidColorPaint(SKColors.DarkRed),

                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize=12,
            
                    Labels = days,

                    SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) {StrokeThickness = 2}
                }
            };

            ///
            //sales of month section
            ///
            var total = new List<string>();

            for (int i = 1; i <= Total_sales_p_month; i++)
            {
                total.Add($"{i}");
            }

            Yaxes = new Axis[]
            {
                new() {
                    Name = "Sales",
                    NamePaint = new SolidColorPaint(SKColors.DarkRed),

                    LabelsPaint = new SolidColorPaint(SKColors.Black),

                    TextSize=12,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) {StrokeThickness = 2, PathEffect = new DashEffect(new float[] {3, 3})}
                }
            };
        }

        private void change_content_view(object content)
        {
            
            if (content.ToString() == "stock")
            {
                MainWindowViewModel.Content_Page.change_color(content.ToString());

            }
            else if (content.ToString() == "stock_sales")
            {
                MainWindowViewModel.Content_Page.change_color("stock");
                MainWindowViewModel.Content_Page.stock_Page.change_color("sales");
            }
            else
            {
                MainWindowViewModel.Content_Page.change_color(content.ToString());
                MainWindowViewModel.Content_Page.settings_Page.change_color("user");
            }
        }

        private void show_notifications()
        {
            if (Notification_list.Count > 0)
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
                Database_Connection_Class.Modify_Notifications_Table("delete all", null);
                Notification_list = Database_Connection_Class.Load_Notifications();
                Notification_visibility = Visibility.Collapsed;
                Pending_reports = Notification_list.Where(x => x.Read == false).Count();
            }
        }


        private void mark_as_read(object content)
        {
            var array_values = (object[])content;
            var read = Convert.ToBoolean(array_values[1]);

            if (read == true)
            {
                Database_Connection_Class.Modify_Notifications_Table("modify", new(array_values[0].ToString(), true));
            }
            else
            {
                Database_Connection_Class.Modify_Notifications_Table("modify", new(array_values[0].ToString(), false));
            }
            Notification_list = Database_Connection_Class.Load_Notifications();
            Pending_reports = Notification_list.Where(x => x.Read == false).Count();

        }

        private void delete_notification(object content)
        {
            var array_values = (object[])content;

            Notification_List_Class notification = new(array_values[0].ToString(), array_values[1].ToString(), Convert.ToBoolean(array_values[2]));
         
            Database_Connection_Class.Modify_Notifications_Table("delete", notification);

            Notification_list = Database_Connection_Class.Load_Notifications();

            if (Notification_list == null)
            {
                Notification_visibility = Visibility.Collapsed;
            }
            
            Pending_reports = Notification_list.Where(x => x.Read == false).Count();
        }

    }
}
