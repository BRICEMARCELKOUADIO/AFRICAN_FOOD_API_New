using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AFRICAN_FOOD_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFRICAN_FOOD_API.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CatalogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? 
                throw new ArgumentNullException(nameof(appDbContext));

            appDbContext.ChangeTracker.QueryTrackingBehavior = 
                QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Pies([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var items = await _appDbContext.Pies
                              .OrderBy(p => p.Name)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPies_2([FromBody] Pie content)
        {
            //var response = await content.ReadAsAsync<Pie>();
            Pie result = content;
            if(result != null)
            {
                //
                await _appDbContext.AddAsync(result);
                await _appDbContext.SaveChangesAsync();
            }

            return Ok(result);
        }


        [HttpPost()]
        [Route("[action]")]
        public async Task<IActionResult> AddPies(
            string name, string shortDescription, 
            decimal price ,decimal prixPromotionnel, 
            /*byte[] image,*/ bool inStock, string userAdminId,
            string image)
        {
            var pie = new Pie()
            {
                Name = name,
                ShortDescription = shortDescription,
               // LongDescription = longDescription,
                //AllergyInformation = allergyInformation,
                Price = price,
                PrixPromotionnel = prixPromotionnel,
                //ImageThumbnailUrl = imageThumbnailUrl,
                //ImageUrl = imageUrl,
                Image = image,
               // IsPieOfTheWeek = isPieOfTheWeek,
                InStock = inStock,
                UserAdminId = userAdminId
            };

            if (pie == null)
               return NotFound();

            await _appDbContext.AddAsync(pie);
            await _appDbContext.SaveChangesAsync();

            return Ok(pie);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> PiesOfTheWeek()
        {
            var items = await _appDbContext.Pies.Where(p => p.IsPieOfTheWeek).OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("GetPieByAdminId/{id}")]
        public async Task<IActionResult> GetPieByAdminId(string id)
        {
            List<Pie> Pie = new List<Pie>();
            if (!string.IsNullOrEmpty(id))
            {
                Pie = await _appDbContext.Pies.Where(p => p.UserAdminId == id).ToListAsync();
                if (Pie != null)
                {
                    return Ok(Pie);
                }
            }
                return Ok(Pie);
        }
    }
}
