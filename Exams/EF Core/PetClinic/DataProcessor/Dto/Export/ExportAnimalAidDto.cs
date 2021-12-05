using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dto.Export
{
    [XmlType("AnimalAid")]
    public class ExportAnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        //<Name>Internal Deworming</Name>
        //<Price>8.00</Price>

    }
}