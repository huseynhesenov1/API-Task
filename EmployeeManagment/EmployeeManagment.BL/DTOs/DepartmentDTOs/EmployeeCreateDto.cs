namespace EmployeeManagment.BL.DTOs.DepartmentDTOs;

public record EmployeeCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public bool IsDeleted { get; set; }
}
