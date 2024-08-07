using CharacterCreator.Data;
using CharacterCreator.Interfaces;

namespace CharacterCreator.Repositories
{
    public class FactionRepository : IFactionRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public FactionRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public bool CreateFaction(Faction faction)
        {
            _context.Add(faction);
            return Save();
        }

        public bool DeleteFaction(Faction faction)
        {
            _context.Remove(faction);
            return Save();
        }

        public bool FactionExists(int factionId)
        {
            return _context.Factions.Any(x => x.Id == factionId);
        }

        public Faction GetFaction(int factionId)
        {
            return _context.Factions.Where(x => x.Id == factionId).FirstOrDefault();
        }

        public ICollection<Faction> GetFactions()
        {
            return _context.Factions.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateFaction(Faction faction)
        {
            _context.Update(faction);
            return Save();
        }
    }
}