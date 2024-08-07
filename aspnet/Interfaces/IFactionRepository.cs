using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface IFactionRepository
    {
        ICollection<Faction> GetFactions();
        Faction GetFaction(int factionId);
        bool FactionExists(int factionId);
        bool CreateFaction(Faction faction);
        bool UpdateFaction(Faction faction);
        bool DeleteFaction(Faction faction);
        bool Save();
    }
}