using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dto.Export
{
    [XmlType("Procedure")]
    public class ExportAllProceduresDto
    {
        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAidDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }

    //<Procedure>
    //<Passport>acattee321</Passport>
    //<OwnerNumber>0887446123</OwnerNumber>
    //<DateTime>14-01-2016</DateTime>
    //<AnimalAids>
    //  <AnimalAid>
    //    <Name>Internal Deworming</Name>
    //    <Price>8.00</Price>
    //  </AnimalAid>

}
