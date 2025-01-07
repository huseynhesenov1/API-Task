using HospitalProject.Core.Entities;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalProject.DAL.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
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
            return await Table.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<Tentity> GetByIdForUpdateAsync(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public Tentity SoftDelete(Tentity entity)
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
}
