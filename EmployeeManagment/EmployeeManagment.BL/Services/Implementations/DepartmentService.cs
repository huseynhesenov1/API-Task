using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        public Task<Department> CreateAsync(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetByIdAsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
