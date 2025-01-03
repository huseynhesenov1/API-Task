using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using StoreManagment.BL.DTOs.CatagoryDtos;
using StoreManagment.BL.DTOs.ColorDTOs;
using StoreManagment.BL.DTOs.ProductDtos;
using StoreManagment.BL.DTOs.SizeDTOs;

namespace StoreManagment.BL.ConfigrationManagers;

public static class ConfigrationValidation
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ProductCreateDtoValidation).Assembly);
        services.AddValidatorsFromAssembly(typeof(SIzeDtoValidation).Assembly);
        services.AddValidatorsFromAssembly(typeof(ColorDtoValidation).Assembly);
        services.AddValidatorsFromAssembly(typeof(CatagoryDtoValidation).Assembly);
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }
}
