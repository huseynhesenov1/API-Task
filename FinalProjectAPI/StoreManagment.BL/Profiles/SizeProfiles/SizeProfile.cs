using AutoMapper;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Profiles.SizeProfiles;

public class SizeProfile:Profile
{
    public SizeProfile()
    {
        CreateMap<SizeDto, Size>();
        CreateMap<SizeDto, Size>().ReverseMap();
    }
}
