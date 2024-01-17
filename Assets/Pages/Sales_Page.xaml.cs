using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace Stock_Management.Assets.Pages
{

    public partial class Sales_Page : Page
    {

        //category items list

        public Sales_Page()
        {
            InitializeComponent();

            populate();
        }

        private void populate()
        {
            populate_category();
            populate_items();
            populate_checkout();
        }

        private void populate_category()
        {
            List<string> strings = new List<string>()
            {
                "button1",
                "button2",
                "button3",
                "button4",
                "button5"

            };

            category_button category_Button = new category_button();
            foreach (var item in strings)
            {

                category_Button.category_list.Add(new category_button(item, item));

            }
            category_items.DataContext = category_Button;
        }

        private void populate_items()
        {
            List<string> strings = new List<string>()
            {
                "item1",
                "item2",
                "item3",
                "item4",
                "item5"
            };

            items_button items_Button = new items_button();
            foreach (var item in strings)
            {
                items_Button.items_list.Add(new items_button(item, item));
            }

            items_panel.DataContext = items_Button;
        }

        private void populate_checkout()
        {
            List<checkout_list> checkout_Lists = new List<checkout_list>()
            {
                new("item1", 4),
                new("item2", 6),
                new("item3", 3),
                new("item4", 1),
                new("item5", 6)
            };

            list_items.ItemsSource = checkout_Lists;
        }

    }

    public class checkout_list
    {
        string item_name { get; set; }

        int quantity { get; set; }

        public checkout_list(string item_name, int quantity)
        {
            this.item_name = item_name;
            this.quantity = quantity;
        }
    }

    public class items_button
    {
        string? button_name { get; set; }

        public string? button_content { get; set; }

        public ObservableCollection<items_button> items_list { get; set; }

        public items_button(string button_name, string button_content)
        {
            this.button_name = button_name;
            this.button_content = button_content;
            items_list = new ObservableCollection<items_button>();
        }
        public items_button()
        {
            items_list = new ObservableCollection<items_button>();
        }
    }

    public class category_button
    {
        string? button_name { get; set; }
        public string? button_content { get; set; }

        public ObservableCollection<category_button> category_list { get; set; }

        public category_button(string button_name, string button_content)
        {
            this.button_name = button_name;
            this.button_content = button_content;
            category_list = new ObservableCollection<category_button>();
        }

        public category_button()
        {
            category_list = new ObservableCollection<category_button>();
        }

    }

}
