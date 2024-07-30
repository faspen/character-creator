using CharacterCreator.Data;

namespace CharacterCreator.Interfaces
{
    public interface ICharacterRepository
    {
        ICollection<Character> GetCharacters();
    }
}