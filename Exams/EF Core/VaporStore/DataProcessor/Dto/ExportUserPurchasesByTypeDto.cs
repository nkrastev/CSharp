using System.Xml.Serialization;

namespace VaporStore.DataProcessor
{
    [XmlType("User")]
    public class ExportUserPurchasesByTypeDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }

    }
}