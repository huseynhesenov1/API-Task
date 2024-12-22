using EmployeeManagment.Core.Entities;
using FluentValidation;

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
public class EmployeeCreateDtoValidation:AbstractValidator<EmployeeCreateDto>
{
    public EmployeeCreateDtoValidation()
    {
        RuleFor(e => e.Age).NotEmpty().NotNull().WithMessage("Null ve Bos ola bilmez").
            GreaterThan(0).WithMessage("0 den boyuk ola bilmez").
            LessThan(65).WithMessage("65 dan kicik ola bilmez");
    }
}