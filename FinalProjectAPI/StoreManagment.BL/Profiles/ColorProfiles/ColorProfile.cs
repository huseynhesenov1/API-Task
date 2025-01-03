using AutoMapper;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Profiles.ColorProfiles;

public class ColorProfile:Profile
{
    public ColorProfile()
    {
        CreateMap<Color, ColorDto>();
        CreateMap<Color, ColorDto>().ReverseMap();
    }
}
