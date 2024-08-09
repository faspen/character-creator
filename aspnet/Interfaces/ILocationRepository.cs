using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();
        Location GetLocation(int locationId);
        bool LocationExists(int locationId);
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();
    }
}