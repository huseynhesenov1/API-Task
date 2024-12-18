namespace EmployeeManagment.Core.Entities;

public class Employee: BaseAuditableEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId {  get; set; }
    public Department Department { get; set; }

}
