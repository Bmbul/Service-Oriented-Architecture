using AutoMapper;
using SOA.Common.Models;
using SOA.Data.Entities;

namespace SoftwareEngineering.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    { 
        CreateMap<UserEntity, UserDto>()
            .ConstructUsing(src => new UserDto($"{src.FirstName} {src.LastName}"));
    }
}
