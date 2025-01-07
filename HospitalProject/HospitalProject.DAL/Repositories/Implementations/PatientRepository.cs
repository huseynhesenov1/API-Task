using HospitalProject.Core.Entities;
using HospitalProject.DAL.Contexts;
using HospitalProject.DAL.Repositories.Abstractions;

namespace HospitalProject.DAL.Repositories.Implementations
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }
    }
}
