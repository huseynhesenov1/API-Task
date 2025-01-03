
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagment.Core.Entities;
using System.Reflection;

namespace StoreManagment.DAL.Contexts;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions opt) : base(opt) { }
    public DbSet<Catagory> Catagories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}