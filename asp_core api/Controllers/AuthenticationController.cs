using System;
using System.Linq;
using System.Threading.Tasks;
using AFRICAN_FOOD_API.Models;
using AFRICAN_FOOD_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AFRICAN_FOOD_API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        public readonly AppDbContext _dbContext;
        public AuthenticationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Authenticate(string Email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null || user.Password != password)
            {
                return NotFound(
                    new AuthenticationResponse()
                    {
                        IsAuthenticated = false
                    });
                //return Ok(new AuthenticationResponse
                //{
                //    IsAuthenticated = false
                //});
            }
            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserPhone = user.UserPhone,
                    TypeUser = user.TypeUser,
                    CommerceLocate = user.CommerceLocate,
                    CommerceName = user.CommerceName,
                    Latitude = user.Latitude,
                    Longitude = user.Longitude,
                    PositionGeo = user.PositionGeo
                }
            }) ;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(string FirstName, string LastName, string Email,bool Typeuser, string CommerceName, string CommerceLocate, string UserPhone, double Longitude, double Latitude, string PositionGeo, string Password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email && u.UserPhone == UserPhone && u.Password == Password);

            if (user != null) 
            {
                return NotFound(
                    new AuthenticationResponse
                    {
                        IsAuthenticated = false
                    }) ;
                //return Ok(new AuthenticationResponse
                //{
                //    IsAuthenticated = false

                //});
            }

            user = new User()
            {
                Email = Email,
                FirstName =FirstName,
                LastName = LastName,
                UserPhone = UserPhone,
                TypeUser = Typeuser,
                CommerceLocate = CommerceLocate,
                CommerceName = CommerceName,
                Password = Password,
                Latitude = Latitude,
                Longitude = Longitude,
                PositionGeo = PositionGeo
            };

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    UserPhone = UserPhone,
                    TypeUser = Typeuser,
                    CommerceLocate = CommerceLocate,
                    CommerceName = CommerceName,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    PositionGeo = PositionGeo
                }
            });
        }
    }
}
