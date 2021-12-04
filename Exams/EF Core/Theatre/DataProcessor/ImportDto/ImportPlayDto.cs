using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        //validate in dto
        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        //validate in dto
        [Required]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}


//< Play >
//    < Title > The Hsdfoming </ Title >
   
//       < Duration > 03:40:00 </ Duration >
      
//          < Rating > 8.2 </ Rating >
      
//          < Genre > Action </ Genre >
      
//          < Description > A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled Pinter Pause, which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
//    <Screenwriter>Roger Nciotti</Screenwriter>
//  </Play>