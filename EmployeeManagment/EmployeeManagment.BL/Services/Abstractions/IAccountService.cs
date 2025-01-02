using EmployeeManagment.BL.DTOs.AppUserDto;
using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.BL.Services.Abstractions;

public interface IAccountService
{
    Task<bool> RegisterAsync(AppUserCreateDto appUserCreateDto);
    Task<bool> LoginAsync(AppUserLoginDto appUserLoginDto);
    Task<ICollection<AppUser>> GetAllUserAsync();
    Task<AppUser> GetUserByName(string name);
}
