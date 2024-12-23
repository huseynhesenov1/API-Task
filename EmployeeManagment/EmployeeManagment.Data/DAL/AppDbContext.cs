using EmployeeManagment.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data.DAL;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

}
