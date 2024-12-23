using AutoMapper;
using EmployeeManagment.BL.DTOs.AppUserDto;
using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeManagment.BL.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    
    public AccountService(UserManager<AppUser> userManager, IMapper mapper, AppDbContext context)
    {
        _userManager = userManager;
        _mapper = mapper;
        _context = context;
    }

    public async Task<ICollection<AppUser>> GetAllUserAsync()
    {
        ICollection<AppUser> user = await _context.Set<AppUser>().ToListAsync();
        return user;
    }

    public async Task<AppUser> GetUserByName(string name)
    {
        return await _context.Set<AppUser>()
        .FirstOrDefaultAsync(x => x.FirstName == name);
    }

    public async Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto)
    {
        AppUser user = _mapper.Map<AppUser>(appUserCreateDto);
        var result =  await _userManager.CreateAsync(user, appUserCreateDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Could not created");
        }
        return true;
    }
}
