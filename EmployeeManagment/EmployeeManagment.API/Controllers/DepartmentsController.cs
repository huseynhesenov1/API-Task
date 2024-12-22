using EmployeeManagment.BL.DTOs.DepartmentDTOs;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.BL.Services.Implementations;
using EmployeeManagment.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _depertmentService;

        public DepartmentsController(IDepartmentService depertmentService)
        {
            _depertmentService = depertmentService;
        }
        [HttpGet]
        public async Task<ICollection<Department>> GetAll()
        {
           return await  _depertmentService.GetAllAsync();
        }
        [HttpPost]
        public Task<Department> Create(DepartmentCreateDto departmentCreateDto)
        {
           return _depertmentService.CreateAsync(departmentCreateDto);
        }
    }
}
