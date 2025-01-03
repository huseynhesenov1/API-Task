using AutoMapper;
using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Profiles.CatagoryProfiles;

public class CatagoryProfile:Profile
{
    public CatagoryProfile()
    {
        CreateMap<Catagory , CatagoryDto>();
        CreateMap<Catagory , CatagoryDto>().ReverseMap();
    }
}
