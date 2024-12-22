using EmployeeManagment.Core.Entities;
using FluentValidation;

namespace EmployeeManagment.BL.DTOs.DepartmentDTOs;

public record DepartmentCreateDto
{
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
    public bool IsDeleted { get; set; }
}
public class DepartmentCreateDtoValidation : AbstractValidator<DepartmentCreateDto>
{
    public DepartmentCreateDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not Empty").
            NotNull().WithMessage("name cannot null").
            //EmailAddress().
            MaximumLength(13).WithMessage("13 den cox ola bilmez");
        RuleFor(x => x.EmployeeCount).NotNull().NotEmpty().GreaterThan(0).WithMessage("0 dan boyuk olmaldir").LessThan(65).WithMessage("say 65 den az olmalidir");

    }
}