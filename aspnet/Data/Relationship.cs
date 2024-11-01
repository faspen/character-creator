using System.ComponentModel.DataAnnotations;
using CharacterCreator.Dtos;

namespace CharacterCreator.Data
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        public int FirstCharacterId { get; set; }
        public Character FirstCharacter { get; set; }

        public int SecondCharacterId { get; set; }
        public Character Character { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }
}