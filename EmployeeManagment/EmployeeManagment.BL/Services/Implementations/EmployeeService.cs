using EmployeeManagment.BL.Services.Abstractions;
using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Employee> CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
