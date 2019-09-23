using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetItemsForUser(string userId)
        {
            var shoppingCart = await _appDbContext.ShoppingCarts.Include(s => s.ShoppingCartItems).ThenInclude(s => s.Pie).FirstOrDefaultAsync(s => s.UserId == userId);
            return shoppingCart == null ? Ok(new ShoppingCart()) : Ok(shoppingCart);
        }

        [HttpGet]
        [Route("GetCommandClient/{adminId}")]
        public IActionResult GetCommandClient(string adminId)
        {
            var command = _appDbContext.ShoppingCarts.Include(s => s.ShoppingCartItems).ThenInclude(s => s.Pie).ToList();
            List<ShoppingCart> shoppingCartsToSend = new List<ShoppingCart>();

            if (command != null)
            {
                command.ForEach(i =>
                    {
                        var items = i.ShoppingCartItems.Where(p => p.Pie.UserAdminId == adminId).ToList();

                        ShoppingCart shoppingCart = new ShoppingCart()
                        {
                            UserId = i.UserId,
                            ShoppingCartId = i.ShoppingCartId,
                            ShoppingCartItems = items,
                        };

                        shoppingCartsToSend.Add(shoppingCart);
                    }
                );
            }

            return command == null || shoppingCartsToSend == null ? Ok(new ShoppingCart()) : Ok(shoppingCartsToSend);
        }

        [HttpPost]
        // GET: /<controller>/
        public async Task<IActionResult> Add([FromBody]UserShoppingCartItem userShoppingCartItem)
        {
            ShoppingCartItem shoppingCartItem = new ShoppingCartItem();
            var shoppingCart = _appDbContext.ShoppingCarts.Include(p => p.ShoppingCartItems).SingleOrDefault(s => s.UserId == userShoppingCartItem.UserId);
            if (shoppingCart != null)
            {
                 shoppingCartItem = shoppingCart.ShoppingCartItems?.SingleOrDefault(item => item.PieId == userShoppingCartItem.ShoppingCartItem.Pie.PieId);
                if (shoppingCartItem != null)
                {
                    shoppingCartItem.Quantity++;
                    _appDbContext.Entry(shoppingCartItem).State = EntityState.Modified;
                    await _appDbContext.SaveChangesAsync();
                }

                else
                {
                    //shoppingCart = _appDbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == userShoppingCartItem.UserId);
           

                    var pie = _appDbContext.Pies.FirstOrDefault(p => p.PieId == userShoppingCartItem.ShoppingCartItem.PieId);

                    shoppingCartItem = new ShoppingCartItem
                    {
                        Pie = pie,
                        PieId = userShoppingCartItem.ShoppingCartItem.Pie.PieId,
                        Quantity = userShoppingCartItem.ShoppingCartItem.Quantity,
                        ShoppingCartId = shoppingCart.ShoppingCartId,
                        ClientNumber = userShoppingCartItem.ShoppingCartItem.ClientNumber
                    };
                    _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
                    await _appDbContext.SaveChangesAsync();

                }
            }
            else
            {
               
                    shoppingCart = new ShoppingCart { UserId = userShoppingCartItem.UserId };
                    _appDbContext.ShoppingCarts.Add(shoppingCart);
                    _appDbContext.SaveChanges();
                
            }
           
            

                return Ok(shoppingCartItem);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DeleteShoppingItem(string userId, int ShoppingItem)
        {
            var user = _appDbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == userId);
            var shoppingItem = _appDbContext.ShoppingCartItems.FirstOrDefault(i => i.ShoppingCartItemId == ShoppingItem);
            if (user != null && shoppingItem != null)
            {
                ShoppingCartItem item = _appDbContext.ShoppingCartItems.FirstOrDefault(i => i.ShoppingCartItemId == ShoppingItem);
                _appDbContext.ShoppingCartItems.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return Ok(item);

            }
            else
                return NotFound(new ShoppingCartItem());
           
        }
    }
}
