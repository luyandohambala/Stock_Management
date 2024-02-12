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

        public static async Task<bool> Resend_Report()
        {
            var reports_list = Database_Connection_Class.Load_Reports().Where(x => x.Sent == false);
            if (reports_list.Count() > 0)
            {
                //resend report code below
                //insert send email code below
                Send_Email_Class send_Email_Class = new("");

                if (await Task.Run(() => send_Email_Class.resend_email()))
                {
                    return true;
                }
                return true;
            }
            return false;
        }

        public static async Task<bool> Send_Report(ObservableCollection<Sales_list_Class> list)
        {
            if (await Task.Run(() => new Print_Files_Class().prepare_report(list)))
            {
                //insert send email code below
                Send_Email_Class send_Email_Class = new("");
                
                if (await Task.Run(() => send_Email_Class.send_email()))
                {
                    return true;
                }            
            }
            return false;
        }


    }
}
