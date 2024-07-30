using System.ComponentModel.DataAnnotations;

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
    }
}