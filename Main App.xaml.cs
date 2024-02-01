﻿using Caliburn.Micro;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Stock_Management.Assets.Pages;
using Stock_Management.Assets.ViewModel;
using Syncfusion.UI.Xaml.Charts;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Stock_Management
{

    public partial class MainWindow : Window
    {
        //bool value for maximized window
        private bool Maximized {get; set;}

        public Command_Class close_app => new(execute => close_application());

        public static string? Current_user { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Maximized = false;
            change_color("settings");//initialise settings for use throughout the application.
            change_color("stock");

            DataContext = this;
            Current_user = "Welcome User!";
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

        //color navigator method
        private void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.3));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.8));

            if (nav == "home")
            {
                home_button.Foreground = linearGradientBrush;
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);

                Display_Frame.Content = new Home_Page();
            }

            else if (nav == "sales")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.Foreground = linearGradientBrush;
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Sales_Page();
            }

            else if (nav == "services")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.Foreground = linearGradientBrush;
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Services_Page();
            }

            else if (nav == "stock")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.Foreground = linearGradientBrush;
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.ClearValue(ForegroundProperty);

                Display_Frame.Content = new stock_page();
            }

            else if (nav == "quote")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.Foreground = linearGradientBrush;
                Settings_button.ClearValue(ForegroundProperty);
                Display_Frame.Content = new Quotation_Page();
            }

            else if (nav == "settings")
            {
                home_button.ClearValue(ForegroundProperty);
                sales_button.ClearValue(ForegroundProperty);
                services_button.ClearValue(ForegroundProperty);
                Stock_button.ClearValue(ForegroundProperty);
                quotation_button.ClearValue(ForegroundProperty);
                Settings_button.Foreground = linearGradientBrush;
                Display_Frame.Content = new Settings_Page();
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


        private void home_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("home");
        }

        private void sales_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("sales");
        }

        private void services_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("services");
        }

        private void Stock_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("stock");
        }

        private void quotation_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("quote");
        }

        private void Settings_button_Click(object sender, RoutedEventArgs e)
        {
            change_color("settings");
        }

        private void close_application()
        {
            if (MessageBox.Show("Proceed to exit?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
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