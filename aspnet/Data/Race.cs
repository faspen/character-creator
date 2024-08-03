using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Data
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}