using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ICollection<Employee>> Get()
        {
           return await _employeeService.GetAllAsync();
        }
        [HttpPost]
        public async Task<Employee> Create(EmployeeCreateDto employeeCreateDto)
        {
           return  await _employeeService.CreateAsync(employeeCreateDto);
        }

    }
}
