using AutoMapper;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Profiles.ProductProfiles;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductCreateDto, Product>().ReverseMap();
    }
}
