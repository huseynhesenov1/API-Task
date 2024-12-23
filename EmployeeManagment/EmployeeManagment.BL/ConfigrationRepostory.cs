using EmployeeManagment.Data.Repostories.Abstactions;
using EmployeeManagment.Data.Repostories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagment.BL;

public static class ConfigrationRepostory
{
    public static void AddRepostory(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepostory, EmployeeRepostory>();
        services.AddScoped<IDepartmentRepostory, DepartmentRepostory>();
    }
}
