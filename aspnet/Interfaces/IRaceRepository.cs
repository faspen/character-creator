using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface IRaceRepository
    {
        ICollection<Race> GetRaces();
        Race GetRace(int raceId);
        bool RaceExists(int raceId);
        bool CreateRace(Race race);
        bool UpdateRace(Race race);
        bool DeleteRace(Race race);
        bool Save();
    }
}