using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    [XmlType("post")]
    public  class ImportPostDto
    {
        [XmlElement("caption")]
        [Required]
        public string Caption { get; set; }

        [XmlElement("user")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [XmlElement("picture")]
        [Required]
        public string PictureUrl { get; set; }
    }

}