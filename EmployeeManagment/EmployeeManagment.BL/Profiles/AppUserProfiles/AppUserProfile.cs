using AutoMapper;
using EmployeeManagment.BL.DTOs.AppUserDto;
using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.BL.Profiles.AppUserProfiles;

public class AppUserProfile:Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUserCreateDto, AppUser>();
    }
}
