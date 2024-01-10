using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{

    public partial class Sales_Page : Page
    {
        public Sales_Page()
        {
            InitializeComponent();

            List<testing_class> testing_Classes = new List<testing_class>()
            {
                new() { item_name = "testing", quantity=1},

                new() { item_name = "testing2", quantity=400}
            };

            list_items.ItemsSource = testing_Classes;

        }

    }

    public class testing_class
    {
        public testing_class()
        {

        }

        public string item_name { get; set; }
        public int quantity { get; set; }
    }

}
