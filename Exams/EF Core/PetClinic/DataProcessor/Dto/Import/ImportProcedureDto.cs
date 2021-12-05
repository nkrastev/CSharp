using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor
{
    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement("Vet")]
        [Required]
        public string VetName { get; set; }

        [XmlElement("Animal")]
        [Required]
        public string AnimalSerialNumber { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string ProcedureDateTime { get; set; }

        [XmlArray]
        public AnimalAidProcedureNameDto[] AnimalAids { get; set; }
    }

   // <Vet>Niels Bohr</Vet>
   //     <Animal>acattee321</Animal>
	  //<DateTime>14-01-2016</DateTime>
   //     <AnimalAids>
   //         <AnimalAid>
   //             <Name>Nasal Bordetella</Name>
   //         </AnimalAid>
   //         <AnimalAid>
   //             <Name>Internal Deworming</Name>
   //         </AnimalAid>
   //         <AnimalAid>
   //             <Name>Fecal Test</Name>
   //         </AnimalAid>
   //     </AnimalAids>

}