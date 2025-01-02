using AcademicManagment.BL.DTOs;
using AcademicManagment.Core.Entities;
using AutoMapper;

namespace AcademicManagment.BL.Profiles.ProductProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
