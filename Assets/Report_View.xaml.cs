using Stock_Management.Assets.Pages;
using System;
using System.Collections.Generic;
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

        private void Accept_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NotReady_Btn_Field = false;
            MainWindow.Accept_Btn_Field = true;
            Close();
        }

        private void Not_Ready_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Accept_Btn_Field = false;
            MainWindow.NotReady_Btn_Field = true;
            Close();
        }
    }
}
