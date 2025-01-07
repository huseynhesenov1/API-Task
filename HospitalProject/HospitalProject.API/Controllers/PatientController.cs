using HospitalProject.BL.DTOs;
using HospitalProject.BL.Services.Abstractions;
using HospitalProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ICollection<Patient>> GetAll()
        {
          return await _patientService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _patientService.GetByIdAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatinetCreateDto patinetCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _patientService.UpdateAsync(id, patinetCreateDto));

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
                return StatusCode(StatusCodes.Status201Created, await _patientService.SoftDeleteAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PatinetCreateDto patinetCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _patientService.CreateAsync(patinetCreateDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
    }
}
