namespace CharacterCreator.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CharacterDto> Characters { get; set; }
    }
}