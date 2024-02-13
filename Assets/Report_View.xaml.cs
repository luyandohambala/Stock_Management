using Stock_Management.Assets.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stock_Management.Assets
{
    /// <summary>
    /// Interaction logic for Report_View.xaml
    /// </summary>
    public partial class Report_View : Window
    {
        
        public Report_View()
        {
            InitializeComponent();
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        //prepare sales report method
        private async void Send_Report()
        {
            if (await Task.Run(() => Send_Report_Class.Check_Internet_Connection()) == true)
            {
                if (await Task.Run(() => Send_Report_Class.Send_Report(new ObservableCollection<Sales_list_Class>(Database_Connection_Class.Load_Sales().
                    Where(x => DateTime.Parse(x.Date).ToString("d/MM/yyyy") == DateTime.Parse("07/02/2024").ToString("d/MM/yyyy"))))) == true)
                {
                    MessageBox.Show("Report successfully sent");
                }

            }
            else
            {
                new Internet_Alert().ShowDialog();
            }
        }

        private void Accept_Btn_Click(object sender, RoutedEventArgs e)
        {
            Send_Report();
            Close();
        }

        private void Not_Ready_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
