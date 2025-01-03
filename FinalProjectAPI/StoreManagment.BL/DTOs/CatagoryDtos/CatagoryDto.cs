using FluentValidation;
using StoreManagment.BL.DTOs.SizeDTOs;

namespace StoreManagment.BL.DTOs.CatagoryDtos;

public class CatagoryDto
{
    public string Name { get; set; }
}
public class CatagoryDtoValidation : AbstractValidator<CatagoryDto>
{
    public CatagoryDtoValidation()
    {

        RuleFor(x => x.Name).MaximumLength(20).WithMessage("20 simvoldan cox ola bilmez").MinimumLength(3).WithMessage("3 simvoldan az ola bilmez");
    }
}