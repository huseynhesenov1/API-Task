using AutoMapper;
using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagment.BL.Profiles.EmployeeProfiles;

public class EmployeeProfile:Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeCreateDto, Employee>();
        CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
    }
}
