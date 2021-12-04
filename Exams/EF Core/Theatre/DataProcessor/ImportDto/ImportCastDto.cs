using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [RegularExpression(@"^\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}$")]
        public string PhoneNumber { get; set; }

        [Required] //check if it exists
        public int PlayId { get; set; }
    }
}
//•	PhoneNumber - text in the following format:
//"+44-{2 numbers}-{3 numbers}-{4 numbers}".Valid phone numbers are: +44 - 53 - 468 - 3479,
//+44 - 91 - 842 - 6054, +44 - 59 - 742 - 3119(required)
//< FullName > Van Tyson </ FullName >

//       < IsMainCharacter > false </ IsMainCharacter >

//       < PhoneNumber > +44 - 35 - 745 - 2774 </ PhoneNumber >

//       < PlayId > 26 </ PlayId >