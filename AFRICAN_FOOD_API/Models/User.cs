using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFRICAN_FOOD_API.Models
{
    public class User
    {
        public string Id { get; set; }

        public string UserPhone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CommerceName { get; set; }

        public string CommerceLocate { get; set; }

        public bool TypeUser { get; set; }

        public string Password { get; set; }
    }
}
