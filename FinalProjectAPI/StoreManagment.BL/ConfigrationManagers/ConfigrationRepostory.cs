using Microsoft.Extensions.DependencyInjection;
using StoreManagment.DAL.Repostories.Abstractions;
using StoreManagment.DAL.Repostories.Implementations;

namespace StoreManagment.BL.ConfigrationManagers;

public static class ConfigrationRepostory
{
    public static void AddRepostory(this IServiceCollection services)
    {
        services.AddScoped<IProductRepostory, ProductRepostory>();
        services.AddScoped<IColorRepostory, ColorRepostory>();
        services.AddScoped<ISizeRepostory, SizeRepostory>();
        services.AddScoped<ICatagoryRepostory, CatagoryRepostory>();
    }
}
