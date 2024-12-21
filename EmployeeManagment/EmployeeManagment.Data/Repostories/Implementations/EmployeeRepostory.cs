using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;
namespace EmployeeManagment.Data.Repostories.Implementations;

public class EmployeeRepostory : GenericRepostory<Employee>, IEmployeeRepostory
{
    public EmployeeRepostory(AppDbContext context) : base(context)
    {

    }
}
