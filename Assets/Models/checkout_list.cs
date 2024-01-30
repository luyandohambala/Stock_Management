using CommunityToolkit.Mvvm.ComponentModel;

namespace Stock_Management.Assets.Models
{
    internal partial class checkout_list : ObservableObject
    {
        [ObservableProperty]
        public string item_name;
        [ObservableProperty]
        public int quantity;


        public checkout_list(string item_name, int quantity)
        {
            Item_name = item_name;
            Quantity = quantity;
        }

    }
}
