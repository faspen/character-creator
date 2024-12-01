using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface IRelationShipRepository
    {
        ICollection<Relationship> GetRelationships();
        Relationship GetRelationship(int relationshipId);
        bool RelationshipExists(int relationshipId);
        bool CreateRelationship(Relationship relationship);
        bool UpdateRelationship(Relationship relationship);
        bool DeleteRelationship(Relationship relationship);
        bool Save();
    }
}