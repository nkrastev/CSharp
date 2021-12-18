namespace Data.Models
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;   

    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string ManufacturerName { get; set; }

        [MaxLength(100)]
        public string Founded { get; set; }

        public ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();        
    }
}
