using FluentValidation;
using StoreManagment.BL.DTOs.ProductDtos;

namespace StoreManagment.BL.DTOs.SizeDTOs;

public class SizeDto
{
    public string Name { get; set; }
}
public class SIzeDtoValidation : AbstractValidator<SizeDto>
{
    public SIzeDtoValidation()
    {
        
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("20 simvoldan cox ola bilmez").MinimumLength(3).WithMessage("3 simvoldan az ola bilmez");
    }
}