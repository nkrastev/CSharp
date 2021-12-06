using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        [XmlAttribute("price")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [XmlAttribute("seat")]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        public string Seat { get; set; }

        [Required]
        public ImportTicketTripDto Trip { get; set; }

        public ImportTicketCardDto Card { get; set; }
    }
}
