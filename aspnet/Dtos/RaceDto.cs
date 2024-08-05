namespace CharacterCreator.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CharacterDto> Characters { get; set; }
    }
}