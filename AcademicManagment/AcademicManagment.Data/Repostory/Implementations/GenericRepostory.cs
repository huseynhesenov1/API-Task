using AcademicManagment.Core.Entities;
using AcademicManagment.Data.Contexts;
using AcademicManagment.Data.Repostory.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagment.Data.Repostory.Implementations
{
    public class GenericRepostory<Tentity> : IGenericRepostory<Tentity> where Tentity : BaseAuditable, new()
    {
        private readonly AppDbContext _context;

        public GenericRepostory(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<Tentity> Table => _context.Set<Tentity>();
        public void Update(Tentity entityDto)
        {
             Table.Update(entityDto);
        }
        public  void SoftDelete(Tentity entity)
        {
            entity.IsDeleted = true;
        }
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task<ICollection<Tentity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public int SaveChanges()
        {
          return _context.SaveChanges();
        }
    }
}
