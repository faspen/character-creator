using System.ComponentModel.DataAnnotations;

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
    }
}