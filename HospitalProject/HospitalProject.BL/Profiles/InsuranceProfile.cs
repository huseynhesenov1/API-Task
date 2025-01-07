using AutoMapper;
using HospitalProject.BL.DTOs;
using HospitalProject.Core.Entities;

namespace HospitalProject.BL.Profiles
{
    public class InsuranceProfile:Profile
    {
        public InsuranceProfile()
        {
            CreateMap<Insurance , InsuranceCreateDto>();
            CreateMap<Insurance , InsuranceCreateDto>().ReverseMap();
        }
    }
}
