using HospitalProject.BL.DTOs;
using HospitalProject.BL.Exceptions;
using HospitalProject.BL.Services.Abstractions;
using HospitalProject.BL.Services.Implementations;
using HospitalProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly IInsuranceService _InsService;

        public InsurancesController(IInsuranceService InsService)
        {
            _InsService = InsService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InsuranceCreateDto insuranceCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _InsService.CreateAsync(insuranceCreateDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);

            }
        }

        [HttpGet]
        public async Task<ICollection<Insurance>> GetAll()
        {
            return await _InsService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _InsService.GetByIdAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InsuranceCreateDto insuranceCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _InsService.UpdateAsync(id, insuranceCreateDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _InsService.SoftDeleteAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
    }
}
