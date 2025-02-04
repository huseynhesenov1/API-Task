﻿using Microsoft.Extensions.DependencyInjection;
using StoreManagment.BL.Services.Abstractions;
using StoreManagment.BL.Services.Implementations;
using StoreManagment.BL.TokenServices.Abstractions;
using StoreManagment.BL.TokenServices.Implementations;

namespace StoreManagment.BL.ConfigrationManagers;

public static class ConfigrationService
{
    public static void AddService(this IServiceCollection services )
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICatagoryService, CatagoryService>();
        services.AddScoped<ISizeService, SizeService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}
