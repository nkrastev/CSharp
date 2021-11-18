using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportCardDto
    {
        //Enum check in Deserializer

        [Required]
        [RegularExpression(@"^(\d){4} (\d){4} (\d){4} (\d){4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^(\d){3}$")]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}