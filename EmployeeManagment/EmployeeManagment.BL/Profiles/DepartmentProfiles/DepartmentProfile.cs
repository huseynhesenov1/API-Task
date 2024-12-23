using AutoMapper;
using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.Core.Entities;
namespace EmployeeManagment.BL.Profiles.DepartmentProfiles;
public class DepartmentProfile:Profile
{
    public DepartmentProfile()
    {
        CreateMap<DepartmentCreateDto, Department>();
        CreateMap<DepartmentCreateDto, Department>().ReverseMap();
    }
}