namespace CharacterCreator.Dtos
{
    public class RelationshipDto
    {
        public int Id { get; set; }

        public int FirstCharacterId { get; set; }
        public CharacterDto FirstCharacter { get; set; }

        public int SecondCharacterId { get; set; }
        public CharacterDto SecondCharacter { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }
}