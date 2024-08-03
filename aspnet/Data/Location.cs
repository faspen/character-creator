using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Data
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}