using dotnet_rpg_nd.Dtos.Character;

namespace dotnet_rpg_nd
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Character, GetCharacterDto>();//map character into getCharacterDto
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
