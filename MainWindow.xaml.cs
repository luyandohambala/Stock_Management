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
            Display_Frame.Content = new Sales_Page();
        }
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