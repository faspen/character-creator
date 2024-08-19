using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CharacterCreator.Data
{
    public class Faction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Character> Characters { get; set; }
    }
}