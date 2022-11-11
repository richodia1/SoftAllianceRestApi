using System.ComponentModel.DataAnnotations;

namespace SoftAllianceRestApi.Models.modelDtos
{
    public class GenreForCreateUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
