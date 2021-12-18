namespace Data.Models
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;    

    public class Shell
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double ShellWeight { get; set; }

        [Required]
        public string Caliber { get; set; }

        public ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();
    }
}
