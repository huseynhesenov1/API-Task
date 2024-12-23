using EmployeeManagment.BL.DTOs.AppUserDto;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.BL.Services.Implementations;
using EmployeeManagment.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return  StatusCode(StatusCodes.Status201Created,  await _accountService.RegisterAsync(appUserCreateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ICollection<AppUser>> GetAllUser()
        {
            return await _accountService.GetAllUserAsync();
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetOneUser(string name)
        {
            var user = await _accountService.GetUserByName(name);
            if (user == null)
            {
                return NotFound($"İstifadəçi '{name}' tapılmadı.");
            }
            return Ok(user);
        }
        
    }
}
