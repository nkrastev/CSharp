using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    
    public class ImportCommentPostDto
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }
}