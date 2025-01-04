using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StoreManagment.BL.DTOs.AppUserDtos;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.BL.TokenServices.Abstractions;
using StoreManagment.Core.Entities;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StoreManagment.BL.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManger;
    private readonly RoleManager<IdentityRole> _roleManger;
    private readonly IMapper _mapper;
    private readonly ITokenService _jwtTokenService;

    public AccountService(UserManager<AppUser> userManger, IMapper mapper, RoleManager<IdentityRole> roleManger, ITokenService jwtTokenService)
    {
        _userManger = userManger;
        _mapper = mapper;
        _roleManger = roleManger;
        _jwtTokenService = jwtTokenService;
    }

    public async Task CreateAdminAsync()
    {
        AppUser user = new AppUser();
        user.FirstName = "Admin";
        user.LastName = "Admin";
        user.UserName = "Admin";
        user.Email = "admin12@store.com";
        await _userManger.CreateAsync(user, "Admin123!");
        await _userManger.AddToRoleAsync(user, "Admin");
    }

    public async Task CreateManagerAsync()
    {
        AppUser user = new AppUser();
        user.FirstName = "Manager";
        user.LastName = "Manager";
        user.UserName = "Manager";
        user.Email = "manager12@store.com";
        await _userManger.CreateAsync(user, "Manager123!");
        await _userManger.AddToRoleAsync(user, "Manager");
    }

    public async Task CreateRoleAsync()
    {
        await _roleManger.CreateAsync(new IdentityRole { Name = "Admin" });
        await _roleManger.CreateAsync(new IdentityRole { Name = "Manager" });
        await _roleManger.CreateAsync(new IdentityRole { Name = "User" });
    }

    public async Task<string> LoginAsync(AppUserLoginDto appUserLoginDto)
    {
        AppUser? exsistingUser = await _userManger.FindByNameAsync(appUserLoginDto.UserName);
        if (exsistingUser == null)
        {
            throw new Exception("Not Found");
        }
        bool result = await _userManger.CheckPasswordAsync(exsistingUser, appUserLoginDto.Password);

        if (!result) { throw new Exception("Username or password is wrong"); }
        IList<string> userRoles = await _userManger.GetRolesAsync(exsistingUser);
        string token = _jwtTokenService.GenerateToken(exsistingUser, userRoles);
        return token;
    }

    public async Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto)
    {
        AppUser user = _mapper.Map<AppUser>(appUserCreateDto);
        var result = await _userManger.CreateAsync(user, appUserCreateDto.Password);
        await _userManger.AddToRoleAsync(user, "User");
        if (!result.Succeeded)
        {
            throw new Exception("Smth went wrong");
        }
        return true;
    }
}