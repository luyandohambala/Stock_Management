using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Stock_Management.Assets.Pages;
using Stock_Management.Assets.ViewModel;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Stock_Management
{

    public partial class MainWindow : Window
    {
        //bool value for maximized window
        private bool Maximized {get; set;}

        internal static MainWindowViewModel MainWindowViewModel { get; set;}

        public MainWindow()
        {
            InitializeComponent();
            Constructor_Methods();
        }

        private void Constructor_Methods()
        {
            Maximized = false;

            MainWindowViewModel = new();

            DataContext = MainWindowViewModel;
        }

        public static IConfiguration AddConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true);
#if DEBUG
            builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
#else
            builder.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
#endif
            return builder.Build();
        }


        //allows dragability of window
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (Maximized)
                {
                    Maximized = false;
                    Width = 1000;
                    Height = 620;
                    Top = (SystemParameters.WorkArea.Height - Height) / 2;
                    Left = (SystemParameters.WorkArea.Width - Width) / 2;
                }
                else
                {
                    Maximized = true;
                    Top = SystemParameters.WorkArea.Top;
                    Left = SystemParameters.WorkArea.Left;
                    Height = SystemParameters.WorkArea.Height;
                    Width = SystemParameters.WorkArea.Width;

                }
            }
        }
    }


    internal class Ticker : ObservableObject
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
            OnPropertyChanged(nameof(Now));
            OnPropertyChanged(nameof(Year));
        }


    }
}