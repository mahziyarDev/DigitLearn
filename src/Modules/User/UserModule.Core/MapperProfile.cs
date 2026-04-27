using AutoMapper;
using UserModule.Core.Queries._DTOs.User;
using UserModule.Data.Entities.Users;

namespace UserModule.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
