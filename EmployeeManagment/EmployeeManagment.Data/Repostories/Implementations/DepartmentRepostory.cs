using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;

namespace EmployeeManagment.Data.Repostories.Implementations;

public class DepartmentRepostory : GenericRepostory<Department>, IDepartmentRepostory
{
    public DepartmentRepostory(AppDbContext context) : base(context)
    {

    }

}
