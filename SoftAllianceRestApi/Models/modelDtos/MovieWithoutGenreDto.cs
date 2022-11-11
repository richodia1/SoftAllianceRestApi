using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models.modelDtos
{
    public class MovieWithoutGenreDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
    }
}
