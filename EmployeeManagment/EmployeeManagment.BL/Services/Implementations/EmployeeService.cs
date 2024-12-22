using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepostory _employeeRepo;

        public EmployeeService(IEmployeeRepostory employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = new Employee();
            employee.Surname = employeeCreateDto.Surname;
            employee.Name = employeeCreateDto.Name;
            employee.DepartmentId = employeeCreateDto.DepartmentId;
            employee.Salary = employeeCreateDto.Salary;
            employee.Age = employeeCreateDto.Age;
            employee.IsDeleted = employeeCreateDto.IsDeleted;
            
            var saved = await _employeeRepo.CreateAsync(employee);
            await _employeeRepo.SavaChangesAsync();
            return saved;
        }

        public async Task<ICollection<Employee>> GetAllAsync()
        {
           return await _employeeRepo.GetAllAsync();
        }
    }
}
