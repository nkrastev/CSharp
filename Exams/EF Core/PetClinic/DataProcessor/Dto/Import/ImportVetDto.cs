using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor
{
    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("Profession")]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Profession { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(22,65)]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^(\+359|0)\d{9}$")]
        //check if it is unique in the Deserializer
        public string PhoneNumber { get; set; }
    }

    //<Name>Michael Jordan</Name>
    //    <Profession>Emergency and Critical Care</Profession>
    //    <Age>45</Age>
    //    <PhoneNumber>0897665544</PhoneNumber>

}