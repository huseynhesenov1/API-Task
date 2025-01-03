using AutoMapper;
using StoreManagment.BL.DTOs.AppUserDtos;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Profiles.AppUserProfiles;

public class AppUserProfile:Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUserCreateDto, AppUser>();
        CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
    }
}
