using AFRICAN_FOOD_API.Models;

namespace AFRICAN_FOOD_API.ViewModel
{
    public class UserShoppingCartItem
    {
        public string UserId { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set; }
    }
}
