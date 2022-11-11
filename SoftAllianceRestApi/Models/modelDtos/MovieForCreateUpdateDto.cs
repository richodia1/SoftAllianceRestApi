using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models.modelDtos
{
    public class MovieForCreateUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// binary64 blob immage upload
        /// </summary>
        [Required]
        public string Photo { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public List<String> genry { get; set; }



    }
}
