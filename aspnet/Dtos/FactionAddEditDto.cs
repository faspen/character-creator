using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Dtos
{
    public class FactionAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}