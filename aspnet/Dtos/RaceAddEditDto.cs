using System.ComponentModel.DataAnnotations;
using CharacterCreator.Data;

namespace CharacterCreator.Dtos
{
    public class RaceAddEditDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}