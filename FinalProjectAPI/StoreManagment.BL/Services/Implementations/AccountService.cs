using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StoreManagment.BL.DTOs.AppUserDtos;
using StoreManagment.BL.Services.Abstractions;
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


    public AccountService(UserManager<AppUser> userManger, IMapper mapper, RoleManager<IdentityRole> roleManger)
    {
        _userManger = userManger;
        _mapper = mapper;
        _roleManger = roleManger;
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
        //bool result = await _signInManager.CheckPasswordSignInAsync(exsistingUser, appUserLoginDto.Password, true);
        bool result = await _userManger.CheckPasswordAsync(exsistingUser, appUserLoginDto.Password);
        if (!result)
        {
            throw new Exception("Username or Password is wrong");
        }

        string issuer = "https://localhost:7139";
        string audience = "https://localhost:7139";
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("71b3aeea-8275-494a-be9b-5382b1212526"));


        var userRoles = await _userManger.GetRolesAsync(exsistingUser);
        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, exsistingUser.Id));
        claims.Add(new Claim(ClaimTypes.GivenName, exsistingUser.FirstName));
        claims.Add(new Claim(ClaimTypes.Name, exsistingUser.UserName));
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        JwtSecurityToken generateToken = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            signingCredentials: signingCredentials,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60)

            );

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(generateToken);

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