using StoreManagment.Core.Entities;

namespace StoreManagment.DAL.Repostories.Abstractions;

public interface IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
{
    Task<ICollection<Tentity>> GetAllAsync();
    Task<Tentity> CreateAsync(Tentity entity);
    Task<Tentity> GetByIdAsync(int id);
    Task<Tentity> GetByIdForUpdateAsync(int id);

    Tentity SoftDelete(Tentity entity);
    Tentity Update(Tentity entity);

}