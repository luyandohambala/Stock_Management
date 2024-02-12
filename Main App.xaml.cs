using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Stock_Management.Assets;
using Stock_Management.Assets.Pages;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Stock_Management
{

    public partial class MainWindow : Window
    {
        //bool value for maximized window
        private bool Maximized {get; set;}

        private System.Timers.Timer Timer { get; set;}

        public static bool Accept_Btn_Field { get; set; } = false;
        public static bool NotReady_Btn_Field { get; set; } = false;

        public static string? Current_user { get; set; }

        public static Content_Page Content_Page { get; set; }   

        public MainWindow()
        {
            InitializeComponent();
            Constructor_Methods();
        }

        private void Constructor_Methods()
        {
            Maximized = false;
            Content_Page = new Content_Page();
            Display_Frame.Content = Content_Page;
            DataContext = this;
            Current_user = "Welcome User!";

            Check_Reports();
            Report_Timer();
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

        private async Task Check_Reports()
        {
            //check for unsent reports
            if (await Task.Run(() => Send_Report_Class.Resend_Report()) == true)
            {
                MessageBox.Show("All previously unsent Sales Reports have been successfully sent");
            }

        }

        private async Task Report_Timer()
        {
            Timer = new System.Timers.Timer
            {
                Interval = 1000 // 1 hour updates
            };
            Timer.Elapsed += timer_Elapsed;
            Timer.Start();
        }

        async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //if the current time is 5pm call the report_view window and notify user of report send function
            if (DateTime.Now.ToString("t") == DateTime.Parse("12:32 pm").ToString("t"))
            {
                Timer.Stop();
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    // your code
                    Report_View report_View = new();
                    report_View.ShowDialog();
                    if (Accept_Btn_Field == true)
                    {
                        /*while (await Task.Run(() => Send_Report_Class.Check_Internet_Connection()) == true)
                        {
                            if (await Task.Run(() => Send_Report_Class.Send_Report(new ObservableCollection<Sales_list_Class>(Database_Connection_Class.Load_Sales().
                                Where(x => DateTime.Parse(x.Date).ToString("d/MM/yyyy") == DateTime.Now.ToString("d/MM/yyyy"))))) == true)
                            {
                                break;
                            }
                        }*/
                        MessageBox.Show("Ready");
                        Accept_Btn_Field = false;
                    }
                    else if (NotReady_Btn_Field == true)
                    {
                        MessageBox.Show("Reports will be sent after an hour!");
                        NotReady_Btn_Field = false;
                        Timer.Elapsed -= timer_Elapsed;
                        Timer.Elapsed += Timer_Elapsed;
                        Timer.Start();
                    }
                });
            }
        }

        async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //if the current time is 5pm call the report_view window and notify user of report send function
            if (DateTime.Now.ToString("t") == DateTime.Parse("12:33 pm").ToString("t"))
            {
                Timer.Stop();
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    // your code
                    MessageBox.Show("Report will now be sent");
                });
            }
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