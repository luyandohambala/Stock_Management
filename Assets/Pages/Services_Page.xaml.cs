using Stock_Management.Assets.ViewModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Stock_Management.Assets.Pages
{
    
    public partial class Services_Page : Page
    {
        public Command_Class clear_txt => new(execute => TxtSearch.Clear());

        public Services_Page()
        {
            InitializeComponent();
            DataContext = new Services_Page_ViewModel();

            clear_button.DataContext = this;

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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //gets button content
            var btn = sender as Button;

            change_nav(null, btn);
            
            //finally execute command
            btn.Command.Execute(btn.CommandParameter);
        }

        private void change_nav(string? button_content, Button? button_)
        {
            //create gradient color
            LinearGradientBrush linearGradientBrush = new()
            {
                StartPoint = new Point(1, 0),
                EndPoint = new Point(1, 1)
            };

            linearGradientBrush.GradientStops.Add(new GradientStop((Color)new ColorConverter().ConvertFrom("#4b4b4b"), 0.2));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            if (button_content is null)
            {
                for (int i = 0; i < cat_grid.Items.Count; i++)
                {
                    //checks content of other butttons in itemscontrol
                    var c = (ContentPresenter)cat_grid.ItemContainerGenerator.ContainerFromItem(cat_grid.Items[i]);
                    Button button = c.ContentTemplate.FindName("cat_grid_button", c) as Button;

                    if (button.Content != button_.Content)
                    {
                        button.ClearValue(ForegroundProperty);
                        button.ClearValue(BackgroundProperty);
                    }
                    else
                    {
                        button.Background = linearGradientBrush;
                        button.Foreground = new SolidColorBrush(Colors.White);
                    }

                }
            }
        }

        private void purchase_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            purchase_txtbox.Text = Quotation_Page.validate_positive_integer(purchase_txtbox.Text, "Decimal");
        }
    }
}
