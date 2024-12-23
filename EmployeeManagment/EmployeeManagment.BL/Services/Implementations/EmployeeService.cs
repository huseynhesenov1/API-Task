using AutoMapper;
using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepostory _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepostory employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeCreateDto);
            employee.CreateAt = DateTime.UtcNow.AddHours(4) ;
            
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
