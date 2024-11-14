using AutoMapper;
using CharacterCreator.Data;

namespace CharacterCreator.Dtos
{
    public class CharacterCreatorAutoMapper : Profile
    {
        public CharacterCreatorAutoMapper()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.RelationshipsAsFirst, opt => opt.MapFrom(src => src.RelationshipsAsFirst))
                .ForMember(dest => dest.RelationshipsAsSecond, opt => opt.MapFrom(src => src.RelationshipsAsSecond));
            CreateMap<CharacterAddEditDto, Character>();

            CreateMap<Race, RaceDto>();
            CreateMap<RaceAddEditDto, Race>();

            CreateMap<Faction, FactionDto>();
            CreateMap<FactionAddEditDto, Faction>();

            CreateMap<Location, LocationDto>();
            CreateMap<LocationAddEditDto, Location>();

            CreateMap<Relationship, RelationshipDto>();
            CreateMap<RelationshipAddEditDto, Relationship>();
        }
    }
}