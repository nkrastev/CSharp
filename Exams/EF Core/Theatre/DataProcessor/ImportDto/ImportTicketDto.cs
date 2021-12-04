using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketDto
    {
        [Required]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [Required]
        //check if it is valid
        public int PlayId { get; set; }
    }
}



//        "Price": 7.63,
//        "RowNumber": 5,
//        "PlayId": 4
//      },