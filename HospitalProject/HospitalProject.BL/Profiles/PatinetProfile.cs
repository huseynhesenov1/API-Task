using AutoMapper;
using HospitalProject.BL.DTOs;
using HospitalProject.Core.Entities;

namespace HospitalProject.BL.Profiles
{
    public class PatinetProfile:Profile
    {
        public PatinetProfile()
        {
            CreateMap<Patient, PatinetCreateDto>();
            CreateMap<Patient, PatinetCreateDto>().ReverseMap();
        }
    }
}
