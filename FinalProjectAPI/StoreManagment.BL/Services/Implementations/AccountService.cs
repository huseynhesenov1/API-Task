using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreManagment.BL.DTOs.AppUserDtos;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.Core.Entities;

namespace StoreManagment.BL.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManger;
    private readonly IMapper _mapper;


    public AccountService(UserManager<AppUser> userManger, IMapper mapper)
    {
        _userManger = userManger;
        _mapper = mapper;
    }

    public async Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto)
    {
       AppUser user =  _mapper.Map<AppUser>(appUserCreateDto);
       var result = await _userManger.CreateAsync(user, appUserCreateDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Smth went wrong");
        }
        return true;
    }
}
