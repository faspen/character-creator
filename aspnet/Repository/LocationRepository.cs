using CharacterCreator.Data;
using CharacterCreator.Interfaces;

namespace CharacterCreator.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CharacterCreatorDbContext _context;

        public LocationRepository(CharacterCreatorDbContext context)
        {
            _context = context;
        }

        public bool CreateLocation(Location location)
        {
            _context.Add(location);
            return Save();
        }

        public bool DeleteLocation(Location location)
        {
            _context.Remove(location);
            return Save();
        }

        public Location GetLocation(int locationId)
        {
            return _context.Locations.Where(x => x.Id == locationId).FirstOrDefault();
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.OrderBy(x => x.Id).ToList();
        }

        public bool LocationExists(int locationId)
        {
            return _context.Locations.Any(x => x.Id == locationId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLocation(Location location)
        {
            _context.Update(location);
            return Save();
        }
    }
}