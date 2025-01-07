using HospitalProject.Core.Entities;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;

namespace HospitalProject.DAL.Repositories.Implementations
{
    public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
