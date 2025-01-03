using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;

namespace StoreManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorDto colorDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _colorService.CreateAsync(colorDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet]
        public async Task<ICollection<Color>> GetAll()
        {
            return await _colorService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _colorService.SoftDeleteAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ColorDto colorDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.UpdateAsync(id, colorDto));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }




    }
}
