using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepostory _departmentRepo;

        public DepartmentService(IDepartmentRepostory departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public async Task<Department> CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            Department department = new Department();
            department.Name = departmentCreateDto.Name;
            department.IsDeleted = departmentCreateDto.IsDeleted;
            department.EmployeeCount = departmentCreateDto.EmployeeCount;
            department.CreateAt = DateTime.UtcNow.AddHours(4);
            var added = await _departmentRepo.CreateAsync(department);
            await _departmentRepo.SavaChangesAsync();
            return added;
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }
    }
}
