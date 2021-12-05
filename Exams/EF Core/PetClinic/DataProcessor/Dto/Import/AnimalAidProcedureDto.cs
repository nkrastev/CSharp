using System.Xml.Serialization;

namespace PetClinic.DataProcessor
{
    [XmlType("AnimalAid")]
    public class AnimalAidProcedureNameDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }       
    }
}