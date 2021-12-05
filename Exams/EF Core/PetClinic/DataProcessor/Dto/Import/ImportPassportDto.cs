using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor
{
    public class ImportPassportDto
    {
        [RegularExpression(@"^[A-z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"^(\+359|0)\d{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        //validated in Deserializer
        public string RegistrationDate { get; set; }
    }
}