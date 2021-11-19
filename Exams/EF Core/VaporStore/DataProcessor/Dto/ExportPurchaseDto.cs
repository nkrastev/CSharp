using System;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public ExportGameDto Game { get; set; }

        //<Card>7991 7779 5123 9211</Card>
        //<Cvc>340</Cvc>
        //<Date>2017-08-31 17:09</Date>
        //<Game title = "Counter-Strike: Global Offensive" >
        //  < Genre > Action </ Genre >
        //  < Price > 12.49 </ Price >
        //</ Game >

    }
}