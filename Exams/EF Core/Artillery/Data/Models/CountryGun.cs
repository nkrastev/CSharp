using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class CountryGun
    {        
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int GunId { get; set; }
        public Gun Gun { get; set; }
    }
}