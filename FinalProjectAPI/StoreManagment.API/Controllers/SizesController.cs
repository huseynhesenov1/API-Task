using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin, Manager")]

        public async Task<IActionResult> Create(SizeDto sizeDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _sizeService.CreateAsync(sizeDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet]
        public async Task<ICollection<Size>> GetAll()
        {
            return await _sizeService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _sizeService.SoftDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SizeDto sizeDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.UpdateAsync(id, sizeDto));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
