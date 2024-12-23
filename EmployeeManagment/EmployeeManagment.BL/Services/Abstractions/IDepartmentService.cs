using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagment.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllAsync();
        Task<Department> CreateAsync(DepartmentCreateDto departmentCreateDto);
        Task<Department> GetByIdAsync(int id);
    }
}