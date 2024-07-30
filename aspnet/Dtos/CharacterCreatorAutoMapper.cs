using AutoMapper;
using CharacterCreator.Data;

namespace CharacterCreator.Dtos
{
    public class CharacterCreatorAutoMapper : Profile
    {
        public CharacterCreatorAutoMapper()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterAddEditDto, Character>();
        }
    }
}