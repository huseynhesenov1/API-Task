using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;

namespace StoreManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _prodService;

        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Admin, Manager")]

        public async Task<IActionResult> Create([FromForm]ProductCreateDto productCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _prodService.CreateAsync(productCreateDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet]
        public async Task<ICollection<Product>> GetAll()
        {
            return await _prodService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _prodService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _prodService.SoftDeleteAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto productCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _prodService.UpdateAsync(id, productCreateDto));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
