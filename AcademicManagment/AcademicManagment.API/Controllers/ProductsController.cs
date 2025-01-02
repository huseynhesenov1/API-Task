using AcademicManagment.BL.DTOs;
using AcademicManagment.BL.Services.Abstractions;
using AcademicManagment.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        


        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.SoftDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet]
        public async Task<ICollection<Product>> Get()
        {
           return await _productService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _productService.CreateAsync(productCreateDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto productCreateDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.Update(id, productCreateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
    }
}
