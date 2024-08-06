using CharacterCreator.Data;

namespace CharacterCreator.Dtos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }

        public int? RaceId { get; set; }
        public RaceDto Race { get; set; }
    }
}