using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Dtos
{
    public class LocationAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}