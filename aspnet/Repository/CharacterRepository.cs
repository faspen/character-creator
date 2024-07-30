using CharacterCreator.Data;
using CharacterCreator.Interfaces;

namespace CharacterCreator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public CharacterRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public ICollection<Character> GetCharacters()
        {
            return _context.Characters.OrderBy(x => x.Id).ToList();
        }
    }
}