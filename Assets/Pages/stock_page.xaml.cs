using CommunityToolkit.Mvvm.ComponentModel;
using Stock_Management.Assets.ViewModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{

    public partial class stock_page : Page
    {
        public Command_Class clear_txt2 => new(execute => TxtSearch.Clear());
        public stock_page()
        {
            InitializeComponent();
            DataContext = new stock_page_viewmodel();
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

        private void add_edit_button_Click(object sender, RoutedEventArgs e)
        {
            //traverse through records to check for duplicate records and notify the user of any duplicated then execute add command.
            for (int i = 0; i < items_grid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)items_grid.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cell1 = items_grid.Columns[0].GetCellContent(row) as TextBlock;
                TextBlock cell2 = items_grid.Columns[1].GetCellContent(row) as TextBlock;
                TextBlock cell3 = items_grid.Columns[2].GetCellContent(row) as TextBlock;
                TextBlock cell4 = items_grid.Columns[3].GetCellContent(row) as TextBlock;
                TextBlock cell5 = items_grid.Columns[4].GetCellContent(row) as TextBlock;


                if ((cell1 != null && cell2 != null && cell3 != null && cell4 != null && cell5 != null) &&
                    (cell1.Text.ToLower() == Name_txtbox.Text.ToLower().Trim() 
                    && cell2.Text.ToLower() == Type_txtbox.Text.ToLower().Trim() 
                    && cell3.Text.ToLower() == Category_txtbox.Text.ToLower().Trim() 
                    && cell4.Text.ToLower() == Quantity_txtbox.Text.ToLower().Trim() 
                    && cell5.Text.ToLower() == Cost_txtbox.Text.ToLower().Trim()))
                {
                    items_grid.SelectedItem = items_grid.Items[i];
                    items_grid.ScrollIntoView(items_grid.SelectedItem);
                    row.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                    MessageBox.Show("A record with details inputed already exists, information highlighted in the table.");
                    break;
                }
            }
        }

        private void Cost_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Cost_txtbox.Text = Quotation_Page.validate_positive_integer(Cost_txtbox.Text, "Decimal");
        }

        private void Quantity_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Quantity_txtbox.Text = Quotation_Page.validate_positive_integer(Quantity_txtbox.Text, "integer");
        }
    }

    internal partial class Database_list : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string type;

        [ObservableProperty]
        private string category;

        [ObservableProperty]
        private string quantity;

        [ObservableProperty]
        private string cost;

        //initialise properties
        public Database_list(string name, string type, string category, string quantity, string cost)
        {
            Name = name; Type = type; Category = category; Quantity = quantity; Cost = cost;
        }

        public Database_list()
        {
            
        }

    }


}
