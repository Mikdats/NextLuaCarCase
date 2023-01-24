using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;

namespace NextLua.Business.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Source>>Destination
        CreateMap<Car, SoldCarDto>();
        CreateMap<Car, CarResponseDto>();
        CreateMap<Car, BoughtCarDto>();
        CreateMap<IdentityUser, UserDto>();
    }
}