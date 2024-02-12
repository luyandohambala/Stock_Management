using CommunityToolkit.Mvvm.ComponentModel;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Stock_Management.Assets
{
    internal partial class Send_Email_Class : ObservableObject
    {
        [ObservableProperty]
        private string sender;

        [ObservableProperty]
        private string reciever;

        /*[ObservableProperty]
        private string user;*/

        [ObservableProperty]
        private string subject;

        /*[ObservableProperty]
        private string password_C;*/


        public Send_Email_Class(string rec)
        {
            Reciever = rec;
        }


        public async Task<bool> send_email(string subject = "Sales Report")
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("luyandohambala240@gmail.com", "wnadmobvunjixrjk"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            });

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            try
            {
                var email = Email
                .From("luyandohambala240@gmail.com", "Management")
                .To(Reciever)
                .Subject(subject)
                .UsingTemplateFromFile(System.IO.Path.GetFullPath(@"./Assets/Templates/Email/"), new { })
                .AttachFromFilename(System.IO.Path.GetFullPath($@"./Assets/Sale Reports/Report_{DateTime.Now:d-MM-yyyy}.pdf"), null, $"Sale Report_{DateTime.Now:d-MM-yyyy}")
                .SendAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> resend_email()
        {
            return false;
        }


    }
}
