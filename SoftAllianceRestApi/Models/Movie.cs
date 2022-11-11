using CuttingEdge.Conditions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models
{
    public class Movie 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public Movie()
        {
            this.Genres = new HashSet<Genre>();
        }
        public virtual ICollection<Genre> Genres { get; set; }

        //public Movie(string name, string description, decimal rating, decimal ticketprice, string country, DateTime releaseDate, string photo)
        //{
        //    Name = name;
        //    Description = description;
        //    Rating = rating;
        //    TicketPrice = ticketprice;
        //    Country = country;
        //    ReleaseDate = releaseDate;
        //    Photo = photo;
        //    Genres = new HashSet<Genre>();
        //}
    }
}