using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}