﻿using System.Linq;
using AFRICAN_FOOD_API.Models;
using AFRICAN_FOOD_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFRICAN_FOOD_API.Controllers
{
    [Route("api/[controller]/")]
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCartController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetItemsForUser(string userId)
        {
            var shoppingCart = _appDbContext.ShoppingCarts.Include(s => s.ShoppingCartItems).ThenInclude(s => s.Pie).FirstOrDefault(s => s.UserId == userId);
            return shoppingCart == null ? Ok(new ShoppingCart()) : Ok(shoppingCart);
        }

        [HttpPost]
        // GET: /<controller>/
        public IActionResult Add([FromBody]UserShoppingCartItem userShoppingCartItem)
        {
            var shoppingCart = _appDbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == userShoppingCartItem.UserId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { UserId = userShoppingCartItem.UserId };
                _appDbContext.ShoppingCarts.Add(shoppingCart);
                _appDbContext.SaveChanges();
            }

            var pie = _appDbContext.Pies.FirstOrDefault(p => p.PieId == userShoppingCartItem.ShoppingCartItem.PieId);

            var shoppingCartItem = new ShoppingCartItem
            {
                Pie = pie,
                PieId = userShoppingCartItem.ShoppingCartItem.Pie.PieId,
                Quantity = userShoppingCartItem.ShoppingCartItem.Quantity,
                ShoppingCartId = shoppingCart.ShoppingCartId
            };
            _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            _appDbContext.SaveChanges();

            return Ok(shoppingCartItem);
        }
    }
}
