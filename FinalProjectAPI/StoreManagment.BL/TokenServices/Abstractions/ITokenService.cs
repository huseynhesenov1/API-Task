using StoreManagment.Core.Entities;

namespace StoreManagment.BL.TokenServices.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(AppUser appUser, IList<string> roles);
    }
}
