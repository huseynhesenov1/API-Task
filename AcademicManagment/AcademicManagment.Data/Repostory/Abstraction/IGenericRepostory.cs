using AcademicManagment.Core.Entities;

namespace AcademicManagment.Data.Repostory.Abstraction;

public interface IGenericRepostory<Tentity> where Tentity : BaseAuditable
{
    Task<ICollection<Tentity>> GetAllAsync();
    Task<Tentity> CreateAsync(Tentity entity);
    Task<Tentity> GetByIdAsync(int id);
    void SoftDelete(Tentity entity);
    void Update(Tentity entityDto);
    int SaveChanges();

}
