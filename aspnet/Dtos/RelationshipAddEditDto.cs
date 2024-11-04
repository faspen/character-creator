namespace CharacterCreator.Dtos
{
    public class RelationshipAddEditDto
    {
        public int Id { get; set; }

        public int FirstCharacterId { get; set; }

        public int SecondCharacterId { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }
}