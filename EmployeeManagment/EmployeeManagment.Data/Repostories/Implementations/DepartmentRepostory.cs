using EmployeeManagment.Core.Entities;
using EmployeeManagment.Data.DAL;
using EmployeeManagment.Data.Repostories.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagment.Data.Repostories.Implementations
{
    public class DepartmentRepostory : GenericRepostory<Department>, IDepartmentRepostory
    {
        public DepartmentRepostory(AppDbContext context) : base(context)
        {
        }

        

       
    }
}
