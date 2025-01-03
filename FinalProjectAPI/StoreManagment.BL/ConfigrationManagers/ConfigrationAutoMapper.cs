using Microsoft.Extensions.DependencyInjection;
using StoreManagment.BL.Profiles.AppUserProfiles;
using StoreManagment.BL.Profiles.CatagoryProfiles;
using StoreManagment.BL.Profiles.ColorProfiles;
using StoreManagment.BL.Profiles.ProductProfiles;
using StoreManagment.BL.Profiles.SizeProfiles;
using System.Runtime.CompilerServices;

namespace StoreManagment.BL.ConfigrationManagers;

public static class ConfigrationAutoMapper
{
    public static void AddAutoMapper(this IServiceCollection services )
    {
        services.AddAutoMapper(typeof(CatagoryProfile).Assembly);
        services.AddAutoMapper(typeof(AppUserProfile).Assembly);
        services.AddAutoMapper(typeof(ProductProfile).Assembly);
        services.AddAutoMapper(typeof(SizeProfile).Assembly);
        services.AddAutoMapper(typeof(ColorProfile).Assembly);
    }
}
