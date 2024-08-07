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

            CreateMap<Race, RaceDto>();
            CreateMap<RaceAddEditDto, Race>();

            CreateMap<Faction, FactionDto>();
            CreateMap<FactionAddEditDto, Faction>();
        }
    }
}