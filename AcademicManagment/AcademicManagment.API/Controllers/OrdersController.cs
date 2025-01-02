using AcademicManagment.BL.DTOs;
using AcademicManagment.BL.Services.Abstractions;
using AcademicManagment.BL.Services.Implementations;
using AcademicManagment.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _orderService.CreateAsync(orderDto));
        }
        [HttpGet]
        public async Task<ICollection<Order>> GetAll()
        {
          return  await _orderService.GetAllAsync();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _orderService.SoftDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPut("{id}")]
        public Task<Order> Update(int id, OrderCreateDto orderCreateDto)
        {
           return _orderService.Update(id,orderCreateDto);
        }
    }
}
