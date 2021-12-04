using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor
{
    public class ImportPictureDto
    {
        [Required]
        [MinLength(1)]
        public string Path { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Size { get; set; }
    }
}