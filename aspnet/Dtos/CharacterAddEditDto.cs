using System.ComponentModel.DataAnnotations;
using CharacterCreator.Data;

namespace CharacterCreator.Dtos
{
    public class CharacterAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }

        public int? RaceId { get; set; }
        public int? LocationId { get; set; }
        public int? FactionId { get; set; }
    }
}