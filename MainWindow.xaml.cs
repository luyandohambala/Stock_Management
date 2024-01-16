using Stock_Management.Assets.Pages;
using System.ComponentModel;
using System.Timers;
using System.Windows;

namespace Stock_Management
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            home_button.Focus();
            Display_Frame.Content = new Settings_Page();
        }

        /*private void home_button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Display_Frame.Content = new Home_Page();
        }

        private void sales_button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Display_Frame.Content = new Sales_Page();
        }

        private void services_button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Display_Frame.Content = new Services_Page();
        }

        private void Stock_button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Display_Frame.Content = new stock_page();
        }

        private void quotation_button_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Display_Frame.Content = new Quotation_Page();
        }*/
    }

    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 1000 // 1 second updates
            };
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public string Year
        {
            get { return Now.ToString("yyyy"); }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Year)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}