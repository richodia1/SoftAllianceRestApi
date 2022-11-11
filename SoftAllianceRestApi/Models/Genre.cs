using CuttingEdge.Conditions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public virtual ICollection<Movie> Movies { get; set; }

        //public Genre(string name)
        //{
        //    Condition.Requires(name, "name").IsNotNullOrWhiteSpace().IsShorterOrEqual(64);
        //    Name = name;
        //    Movies = new HashSet<Movie>();
        //}
    }
}
