using Microsoft.EntityFrameworkCore;
using StoreManagment.Core.Entities;
using StoreManagment.DAL.Contexts;
using StoreManagment.DAL.Repostories.Abstractions;

namespace StoreManagment.DAL.Repostories.Implementations;

public class GenericRepostory<Tentity> : IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDBContext _context;

    public GenericRepostory(AppDBContext context)
    {
        _context = context;
    }
    public DbSet<Tentity> Table => _context.Set<Tentity>();

    public async Task<Tentity> CreateAsync(Tentity entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public async Task<ICollection<Tentity>> GetAllAsync()
    {
        return await Table.Where(x=>x.IsDeleted==false).ToListAsync();
    }

    public async Task<Tentity> GetByIdAsync(int id)
    {
      return await Table.FirstOrDefaultAsync(x=> x.Id == id  && !x.IsDeleted);
    }

    public async Task<Tentity> GetByIdForUpdateAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
    }

    public  Tentity SoftDelete(Tentity entity)
    {
        entity.IsDeleted = true;
        return entity;
    }

    public Tentity Update(Tentity entity)
    {
        Table.Update(entity);
        return entity;
    }
}
