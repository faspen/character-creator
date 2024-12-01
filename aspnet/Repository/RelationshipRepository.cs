using CharacterCreator.Data;
using CharacterCreator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Repositories
{
    public class RelationshipRepository : IRelationShipRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public RelationshipRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public bool CreateRelationship(Relationship relationship)
        {
            _context.Add(relationship);
            return Save();
        }

        public bool DeleteRelationship(Relationship relationship)
        {
            _context.Remove(relationship);
            return Save();
        }

        public Relationship GetRelationship(int relationshipId)
        {
            return _context.Relationships.Where(x => x.Id == relationshipId).FirstOrDefault();
        }

        public ICollection<Relationship> GetRelationships()
        {
            return _context.Relationships
                .Include(x => x.FirstCharacter)
                .Include(x => x.SecondCharacter)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool RelationshipExists(int relationshipId)
        {
            return _context.Relationships.Any(x => x.Id == relationshipId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRelationship(Relationship relationship)
        {
            _context.Update(relationship);
            return Save();
        }
    }
}