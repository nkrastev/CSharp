using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor
{
    public class ImportAnimalDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(1, 2147483647)]
        public int Age { get; set; }

        [Required]
        public ImportPassportDto Passport { get; set; }
    }
}