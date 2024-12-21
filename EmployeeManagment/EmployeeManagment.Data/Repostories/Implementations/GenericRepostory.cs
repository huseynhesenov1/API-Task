using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data.Repostories.Implementations;

public class GenericRepostory<Tentity> : IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public GenericRepostory(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<Tentity> table => _context.Set<Tentity>();

    public async Task<IEnumerable<Tentity>> GetAllAsync()
    {
         return await table.ToListAsync();
    }

    public async Task<Tentity> CreateAsync(Tentity entity)
    {
        await table.AddAsync(entity);
        return entity;
    }

    public void Delete(Tentity entity)
    {
         table.Remove(entity);
        
    }
    public async Task<Tentity> GetByIdAsAsync(int Id)
    {
       return await table.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Update(Tentity entity)
    {
       table.Update(entity);
    }

    
}
