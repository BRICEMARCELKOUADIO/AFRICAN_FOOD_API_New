using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFRICAN_FOOD_API.Models
{
    public class Pie
    {
        [Key]
        public int PieId { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        //[StringLength(2000)]
        //public string LongDescription { get; set; }

        //[StringLength(500)]
        //public string AllergyInformation { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal PrixPromotionnel { get; set; }
        //[Required]
        //public string ImageUrl { get; set; }
        //[Required]
        //public string ImageThumbnailUrl { get; set; }

        [Required]
        public string Image { get; set; }

        public bool IsPieOfTheWeek { get; set; }
        public string UserPhone { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public string PositionGeo { get; set; }

        public int quantite { get; set; }

        public bool InStock { get; set; }
        [Required]
        public string UserAdminId { get; set; }

    }
}
