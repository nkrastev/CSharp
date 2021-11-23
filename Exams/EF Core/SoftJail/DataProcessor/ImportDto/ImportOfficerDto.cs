using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor
{
    [XmlType("Officer")]
    public class ImportOfficerDto
    {

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [Required]
        //validated in Deserializer
        public string Position { get; set; }

        [Required]
        //validated in Deserializer
        public string Weapon { get; set; }

        [Required]
        //validated in Deserializer
        public int DepartmentId { get; set; }

        public ImportPrisonerIdsDto[] Prisoners { get; set; }

        //    <Name>Minerva Kitchingman</Name>
        //<Money>2582</Money>
        //<Position>Invalid</Position>
        //<Weapon>ChainRifle</Weapon>
        //<DepartmentId>2</DepartmentId>
        //<Prisoners>
        //  <Prisoner id = "15" />
        //</ Prisoners >

    }
}
