using Stock_Management.Assets.Pages;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net;
using System.Security.Policy;
using System.Threading;

namespace Stock_Management.Assets
{
    internal class Send_Report_Class
    {
        public Send_Report_Class()
        {
            
        }

        public static bool Check_Internet_Connection(int timeoutMs = 5000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;

            }
        }

        /*public static async Task<bool> Resend_Report()
        {
            var reports_list = Database_Connection_Class.Load_Reports().Where(x => x.Sent == false);
            if (reports_list.Count() > 0)
            {
                //resend report code below
                //insert send email code below
                Send_Email_Class send_Email_Class = new("luyandohambala.1@gmail.com");

                if (await Task.Run(() => send_Email_Class.resend_email(new ObservableCollection<report_data>(reports_list))))
                {
                    return true;
                }
                return true;
            }
            return false;
        }
*/
        public static async Task<bool> Send_Report(ObservableCollection<Sales_list_Class> list)
        {
            if (await Task.Run(() => new Print_Files_Class().prepare_report(list)))
            {
                //insert send email code below
                Send_Email_Class send_Email_Class = new("luyandohambala.1@gmail.com");
                
                if (await Task.Run(() => send_Email_Class.send_email()))
                {
                    return true;
                }            
            }
            return false;
        }

        public static async Task<bool> Send_Backup()
        {
            var backup_location = Database_Connection_Class.Backup_Database();
            if (!string.IsNullOrEmpty(await Task.Run(() => backup_location)) && await Task.Run(() => new Send_Email_Class("luyandohambala.1@gmail.com").send_backup(backup_location)))
            {
                return true;
            }
            else { return false; }
        }


    }
}
