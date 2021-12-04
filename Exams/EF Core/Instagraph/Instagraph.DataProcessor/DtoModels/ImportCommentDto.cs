using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    [XmlType("comment")]
    public class ImportCommentDto
    {
        [XmlElement("content")]
        [Required]
        public string Content { get; set; }

        [XmlElement("user")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [XmlElement("post")]
        [Required]
        public ImportCommentPostDto Post { get; set; }
    }
}