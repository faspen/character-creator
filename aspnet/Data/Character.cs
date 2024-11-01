using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterCreator.Data
{
    public class Character
    {
        [Key]
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
        public Race Race { get; set; }

        public int? FactionId { get; set; }
        public Faction Faction { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<Relationship> Relationships { get; set; }
    }
}