namespace PlatformService.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class PlatformReadDto
    {       
        public int Id { get; set; } 
        
        public string Name { get; set; }
        
        public string Publisher { get; set; }

        public string Cost { get; set; }
    }
}
