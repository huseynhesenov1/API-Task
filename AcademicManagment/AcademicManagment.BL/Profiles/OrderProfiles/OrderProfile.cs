using AcademicManagment.BL.DTOs;
using AcademicManagment.Core.Entities;
using AutoMapper;

namespace AcademicManagment.BL.Profiles.OrderProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
