using StoreManagment.BL.DTOs.AppUserDtos;

namespace StoreManagment.BL.Services.Abstractions;

public interface IAccountService
{
    Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto);
    Task<string> LoginAsync (AppUserLoginDto appUserLoginDto);
}
