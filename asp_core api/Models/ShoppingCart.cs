using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFRICAN_FOOD_API.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
