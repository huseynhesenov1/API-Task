using EmployeeManagment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

}
