using CommunityToolkit.Mvvm.ComponentModel;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Stock_Management.Assets
{
    internal partial class Send_Email_Class : ObservableObject
    {
        [ObservableProperty]
        private string sender;

        [ObservableProperty]
        private string reciever;

        [ObservableProperty]
        private string user;

        [ObservableProperty]
        private string subject;

        [ObservableProperty]
        private string password_C;


        public Send_Email_Class(string rec)
        {
            Reciever = rec;
        }

        public Send_Email_Class(string user, string rec, string password)
        {
            Reciever = rec;
            Password_C = password;
        }


        public async Task<bool> send_email(string subject = "Sales Report")
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("luyandohambala240@gmail.com", "rbkjsepioyuflcdf"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            });

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            try
            {
                string file_name = $"Report_{DateTime.Now:d-MM-yyyy}.pdf";
                var email = Email
                .From("luyandohambala240@gmail.com", "Management")
                .To(Reciever)
                .Subject(subject)
                .UsingTemplateFromFile(System.IO.Path.GetFullPath(@"./Assets/Templates/Email/SalesReportLayout.cshtml"), new { })
                .AttachFromFilename(System.IO.Path.GetFullPath($@"./Assets/Sale Reports/{file_name}"), null, file_name);

                await email.SendAsync();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later");
                return false;
            }

        }

        public async Task<bool> reset_password(ObservableCollection<report_data> list)
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("luyandohambala240@gmail.com", "rbkjsepioyuflcdf"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            });

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            try
            {
                var email = Email
                .From("luyandohambala240@gmail.com", "Management")
                .To(Reciever)
                .Subject("Reset password")
                .UsingTemplateFromFile(System.IO.Path.GetFullPath(@"./Assets/Templates/Email/SalesReportLayout.cshtml"), new { User = User, Password = Password_C })
                .SendAsync();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later");
                return false;
            }
        }

        public async Task<bool> send_backup(string database_location)
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("luyandohambala240@gmail.com", "rbkjsepioyuflcdf"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            });

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            try
            {
                var email = Email
                .From("luyandohambala240@gmail.com", "Management")
                .To(Reciever)
                .Subject("Data Backup")
                .UsingTemplateFromFile(System.IO.Path.GetFullPath(@"./Assets/Templates/Email/BackupReportLayout.cshtml"), new { })
                .AttachFromFilename(System.IO.Path.GetFullPath(database_location), null, $"Resource_BackUp.db");
                
                await email.SendAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error code: {ex.Message}. Please try again later");
                return false;
            }
        }


    }
}
