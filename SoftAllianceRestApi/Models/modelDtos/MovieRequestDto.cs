using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models.modelDtos
{
    public class MovieRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Photo { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


    }
}
