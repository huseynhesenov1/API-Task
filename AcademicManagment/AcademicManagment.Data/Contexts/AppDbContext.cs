using AcademicManagment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagment.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions opt):base(opt)
    {
        
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

}
