using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.BL.Services.Abstractions;

public interface IEmployeeService
{
    Task<ICollection<Employee>> GetAllAsync();
    Task<Employee> CreateAsync(EmployeeCreateDto employeeCreateDto);    
}
