using EmployeeManagment.Core.Entities;

namespace EmployeeManagment.BL.DTOs.DepartmentDTOs;

public record DepartmentCreateDto
{
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
    public bool IsDeleted { get; set; }
}
