using System.Collections;

namespace EmployeeManagment.Core.Entities;

public class Department: BaseAuditableEntity
{
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
