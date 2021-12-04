using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    [XmlType("user")]
    public class ExportUsersDto
    {
        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("MostComments")]
        public int MostComments { get; set; }
    }


}