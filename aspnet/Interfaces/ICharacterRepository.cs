using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface ICharacterRepository
    {
        ICollection<Character> GetCharacters();
        Character GetCharacter(int characterId);
        bool CharacterExists(int characterId);
        bool CreateCharacter(Character character);
        bool UpdateCharacter(Character character);
        bool DeleteCharacter(Character character);
        bool Save();
    }
}