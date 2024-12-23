using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.Data.Repostories.Abstactions
{
    public interface IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
    {
        Task<ICollection<Tentity>> GetAllAsync();
        Task<Tentity> CreateAsync(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);
        Task<Tentity> SoftDeleteAsync(Tentity entity);
        Task<Tentity> GetByIdAsync(int Id);
        Task<bool> IsExistsAsync(int Id);
        Task<int> SavaChangesAsync();
    }
}
