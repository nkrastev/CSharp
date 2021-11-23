using System.Xml.Serialization;

namespace SoftJail.DataProcessor
{
    [XmlType("Prisoner")]
    public class ImportPrisonerIdsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        //<Prisoners>
        //  <Prisoner id = "15" />
        //</ Prisoners >
    }
}