
using Microsoft.EntityFrameworkCore;
using StoreManagment.Core.Entities;

namespace StoreManagment.DAL.Contexts;

public class AppDBContext:DbContext
{
    public AppDBContext(DbContextOptions opt):base(opt){}
    public DbSet<Catagory> Catagories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }    
    public DbSet<Size> Sizes { get; set; }

}