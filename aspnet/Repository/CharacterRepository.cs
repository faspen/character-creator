using CharacterCreator.Data;
using CharacterCreator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public CharacterRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public bool CharacterExists(int characterId)
        {
            return _context.Characters.Any(x => x.Id == characterId);
        }

        public bool CreateCharacter(Character character)
        {
            _context.Add(character);
            return Save();
        }

        public bool DeleteCharacter(Character character)
        {
            foreach (var rel in character.RelationshipsAsFirst)
            {
                _context.Remove(rel);
            }
            foreach (var rel in character.RelationshipsAsSecond)
            {
                _context.Remove(rel);
            }
            _context.Remove(character);
            return Save();
        }

        public Character GetCharacter(int characterId)
        {
            return _context.Characters
                .Include(x => x.Race)
                .Include(x => x.Faction)
                .Include(x => x.Location)
                .Include(x => x.RelationshipsAsFirst)
                .Include(x => x.RelationshipsAsSecond)
                .Where(x => x.Id == characterId)
                .FirstOrDefault();
        }

        public ICollection<Character> GetCharacters()
        {
            return _context.Characters
                .Include(x => x.Race)
                .Include(x => x.Faction)
                .Include(x => x.Location)
                .Include(x => x.RelationshipsAsFirst)
                .Include(x => x.RelationshipsAsSecond)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCharacter(Character character)
        {
            _context.Update(character);
            return Save();
        }
    }
}