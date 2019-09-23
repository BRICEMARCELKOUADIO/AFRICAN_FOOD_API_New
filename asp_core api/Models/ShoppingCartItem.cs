﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFRICAN_FOOD_API.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        public Pie Pie { get; set; }

        public int PieId { get; set; }
        public string ClientNumber { get; set; }

        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
