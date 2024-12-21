using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.Data.Repostories.Abstactions
{
    public interface IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
    {
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity> CreateAsync(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);   //niye entity goturmedu?
        Task<Tentity> GetByIdAsAsync(int Id);
    }
}
