using System.Xml.Serialization;

namespace BookShop.DataProcessor
{
    [XmlType("Book")]
    public class ExportOldestBooksDto
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Date { get; set; }
    }
}