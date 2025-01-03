using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;

namespace StoreManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagorysController : ControllerBase
    {
        private readonly ICatagoryService _catagoryService;

        public CatagorysController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatagoryDto catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _catagoryService.CreateAsync(catagoryDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet]
        public async Task<ICollection<Catagory>> GetAll()
        {
            return await _catagoryService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.SoftDeleteAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CatagoryDto catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.UpdateAsync(id, catagoryDto));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
