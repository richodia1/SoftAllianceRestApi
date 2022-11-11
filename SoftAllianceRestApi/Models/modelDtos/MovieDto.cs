using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models.modelDto
{
    public class MovieDto
    {
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public decimal Rating { get; set; }
      
        public decimal TicketPrice { get; set; }
     
        public string Country { get; set; }
      
        public string Photo { get; set; }
        public ICollection<GenreDto> genres { get; set; } = new List<GenreDto>();
    }
}
