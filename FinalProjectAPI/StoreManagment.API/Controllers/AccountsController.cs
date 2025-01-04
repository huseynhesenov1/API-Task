using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagment.BL.DTOs.AppUserDtos;
using StoreManagment.BL.Services.Abstractions;

namespace StoreManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
                return StatusCode(StatusCodes.Status201Created, await _accountService.RegisterAsync(appUserCreateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _accountService.LoginAsync(appUserLoginDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
        [HttpPost("addedRole")]
        public async Task AddedRole()
        {
           await _accountService.CreateRoleAsync();
        }
        [HttpPost("createAdmin")]
        public async Task CreateRole()
        {
            await _accountService.CreateAdminAsync();
        }

        [HttpPost("createManager")]
        public async Task CreateManager()
        {
            await _accountService.CreateManagerAsync();
        }
    }
}
