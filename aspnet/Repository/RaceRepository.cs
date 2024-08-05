using CharacterCreator.Data;
using CharacterCreator.Interfaces;

namespace CharacterCreator.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public RaceRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public bool CreateRace(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool DeleteRace(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public Race GetRace(int raceId)
        {
            return _context.Races.Where(x => x.Id == raceId).FirstOrDefault();
        }

        public ICollection<Race> GetRaces()
        {
            var races = _context.Races.OrderBy(x => x.Id).ToList();
            return races;
        }

        public bool RaceExists(int raceId)
        {
            return _context.Races.Any(x => x.Id == raceId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRace(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}