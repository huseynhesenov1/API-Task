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
        public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _depertmentService.CreateAsync(departmentCreateDto)); 
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _depertmentService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            
        }
    }
}
