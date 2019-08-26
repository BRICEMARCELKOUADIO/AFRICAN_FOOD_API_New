using AFRICAN_FOOD_API.Models;

namespace AFRICAN_FOOD_API.ViewModel
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
