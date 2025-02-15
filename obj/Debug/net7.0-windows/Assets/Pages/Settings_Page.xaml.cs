﻿using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;

namespace Stock_Management.Assets.Pages
{
    
    public partial class Settings_Page : Page
    {
        public Command_Class general_settings_command => new(execute => change_color("general"));
        public Command_Class user_settings_command => new(execute => change_color("user"));

        public Command_Class clear_txt4 => new(execute => TxtSearch.Clear());

        public Settings_Page()
        {
            InitializeComponent();

            DataContext = new Settings_Page_ViewModel(MainWindow.AddConfiguration());

            general_settings.DataContext = this;
            user_settings.DataContext = this;

            change_color("general");
        }

        private void change_color(string nav)
        {
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (nav == "general")
            {
                general_settings.Foreground = new SolidColorBrush(Colors.White);
                general_settings.Background = linearGradientBrush;
                user_settings.ClearValue(ForegroundProperty);
                user_settings.ClearValue(BackgroundProperty);
                general_view.Visibility = Visibility.Visible;
                user_view.Visibility = Visibility.Hidden;
                Search_Grid.Visibility = Visibility.Hidden;

            }

            else if (nav == "user")
            {
                user_settings.Foreground = new SolidColorBrush(Colors.White);
                user_settings.Background = linearGradientBrush;
                general_settings.ClearValue(ForegroundProperty);
                general_settings.ClearValue(BackgroundProperty);
                general_view.Visibility = Visibility.Hidden;
                user_view.Visibility = Visibility.Visible;
                Search_Grid.Visibility = Visibility.Visible;

            }

            else if(nav == "all")
            {
                category_all.Foreground = new SolidColorBrush(Colors.White);
                category_all.Background = linearGradientBrush;
                category_admin.ClearValue(ForegroundProperty);
                category_admin.ClearValue(BackgroundProperty);
                category_non_admin.ClearValue(ForegroundProperty);
                category_non_admin.ClearValue(BackgroundProperty);

            }
            else if(nav == "admin")
            {
                category_admin.Foreground = new SolidColorBrush(Colors.White);
                category_admin.Background = linearGradientBrush;
                category_all.ClearValue(ForegroundProperty);
                category_all.ClearValue(BackgroundProperty);
                category_non_admin.ClearValue(ForegroundProperty);
                category_non_admin.ClearValue(BackgroundProperty);
            }
            else if(nav == "non-admin")
            {
                category_non_admin.Foreground = new SolidColorBrush(Colors.White);
                category_non_admin.Background = linearGradientBrush;
                category_all.ClearValue(ForegroundProperty);
                category_all.ClearValue(BackgroundProperty);
                category_admin.ClearValue(ForegroundProperty);
                category_admin.ClearValue(BackgroundProperty);
            }

        }

        //validate entry for numbers
        private string? validate_positive_integer(string source, string to_match)
        {
            if (to_match == "Decimal")
            {
                string newNumber = string.Empty;
                Match regex = Regex.Match(source, @"(?<Number>^[0-9]*\.?[0-9]*)");
                while (regex.Success) { newNumber += regex.Groups["Number"].Value; regex = regex.NextMatch(); }
                return newNumber;
            }
            else if (to_match == "integer")
            {
                string newNumber = string.Empty;
                Match regex = Regex.Match(source, "(?<Number>[0-9])");
                while (regex.Success) { newNumber += regex.Groups["Number"].Value; regex = regex.NextMatch(); }
                return newNumber;
            }
            return null;
        }

        private void email_backup_TextChanged(object sender, TextChangedEventArgs e)
        {
            email_backup.Text = validate_positive_integer(email_backup.Text, "integer");
        }

        private void backup_data_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            backup_data_txtbox.Text = validate_positive_integer(backup_data_txtbox.Text, "integer");
        }


        private void category_all_Click(object sender, RoutedEventArgs e)
        {
            change_color("all");
        }

        private void category_admin_Click(object sender, RoutedEventArgs e)
        {
            change_color("admin");
        }

        private void category_non_admin_Click(object sender, RoutedEventArgs e)
        {
            change_color("non-admin");
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //invoke search logo command through txtbox txtchanged event
            if (!String.IsNullOrEmpty(TxtSearch.Text))
            {
                TxtSearch_button.IsEnabled = true;
                clear_button.Content = "\uf00d";
                ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();

            }
            else
            {
                ((IInvokeProvider)(new ButtonAutomationPeer(TxtSearch_button).GetPattern(PatternInterface.Invoke))).Invoke();
                clear_button.Content = "\uf002";
                TxtSearch_button.IsEnabled = false;
            }
        }
    }

    internal partial class settings_data : ObservableObject
    {
        
        [ObservableProperty]
        private string first_name;

        [ObservableProperty]
        private string last_name;

        [ObservableProperty]
        private string user_name;

        [ObservableProperty]
        private string password_entry;

        [ObservableProperty]
        private string authority_;

        public settings_data(string first, string last, string user, string password, string authority)
        {
            First_name = first; Last_name = last; User_name = user; Password_entry = password; Authority_ = authority;
        }

        public settings_data()
        {
            
        }
    }
}
